using Cysharp.Threading.Tasks;
using DG.Tweening;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoadService : ISceneLoadService
{
    private const int DURATION_TO_TARGET_PROGRESS = 1;
    private const int DELAY_WHEN_LOADED_IN_MILLISECONDS = 2000;

    private float _startedProgress = 0f;
    private Tween _progressTween;

    public void LoadSceneAsync(string sceneName)
    {
        SceneManager.LoadSceneAsync(sceneName, LoadSceneMode.Single);
    }

    public async UniTask LoadSceneAsyncWithLoading(string sceneName)
    {
        LoadingEvents.OnShowLoadingScreen?.Invoke();

        var asyncOperation = SceneManager.LoadSceneAsync(sceneName, LoadSceneMode.Single);

        while (!asyncOperation.isDone)
        {
            var targetProgress = Mathf.Clamp01(asyncOperation.progress / 0.9f) * 100f;

            _progressTween?.Kill();

            _progressTween = DOTween.To(() => _startedProgress,
                x => { _startedProgress = x; LoadingEvents.OnChangedProgress?.Invoke(x); },
                    targetProgress, DURATION_TO_TARGET_PROGRESS);

            await UniTask.Yield();
        }

        _progressTween?.Kill();

        LoadingEvents.OnChangedProgress?.Invoke(100f);
        await UniTask.Delay(DELAY_WHEN_LOADED_IN_MILLISECONDS);
        LoadingEvents.OnHideLoadingScreen?.Invoke();
    }
}
