using System;
using System.Threading;
using Cysharp.Threading.Tasks;
using UnityEngine.SceneManagement;

public class LoadSceneService : ILoadSceneService
{
    private const int TWO_SECONDS_DELAY = 2000;
    private CancellationTokenSource _cts;
    private bool _isLoading = false;
    public bool IsLoading => _isLoading;

    public void LoadSceneAsync(string sceneName)
    {
        SceneManager.LoadSceneAsync(sceneName, LoadSceneMode.Single);
    }

    public async UniTask LoadSceneAsyncWithLoading(string sceneName)
    {
        _isLoading = true;
        LoadingEvents.OnShowLoadingScreen?.Invoke();

        _cts?.Cancel();
        _cts?.Dispose();

        _cts = new CancellationTokenSource();
        try
        {
            await UniTask.Delay(TWO_SECONDS_DELAY, cancellationToken: _cts.Token);
            var asyncOperation = SceneManager.LoadSceneAsync(sceneName, LoadSceneMode.Single);

            while (!asyncOperation.isDone)
            {
                await UniTask.Yield();
            }
            await UniTask.Delay(TWO_SECONDS_DELAY, cancellationToken: _cts.Token);
        }
        catch (OperationCanceledException)
        {
            return;
        }
        finally
        {
            _isLoading = false;
            LoadingEvents.OnHideLoadingScreen?.Invoke();
        }
    }
}
