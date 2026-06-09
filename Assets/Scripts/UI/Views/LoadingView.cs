using System;
using System.Threading;
using Cysharp.Threading.Tasks;
using DG.Tweening;
using UnityEngine;

[RequireComponent(typeof(CanvasGroup))]
public class LoadingView : MonoBehaviour
{
    private const int DELAY_AFTER_VIEW_HIDE = 1000;

    [SerializeField]
    private CanvasGroup _canvasGroup;

    [SerializeField]
    private GameObject _loadingCircle;

    [SerializeField]
    [Tooltip("It can impact on the speed")]
    private float _durationCicleRotation = 0.5f;

    private CancellationTokenSource _cts;
    private Tween _loadingTween;
    private bool _isShown = false;

    private void OnValidate()
    {
        _canvasGroup = _canvasGroup ? _canvasGroup : GetComponent<CanvasGroup>();
    }

    private void Awake()
    {
        _canvasGroup.alpha = 0f;

        LoadingEvents.OnShowLoadingScreen += ShowView;
        LoadingEvents.OnHideLoadingScreen += HideView;
    }

    private void OnDestroy()
    {
        DOTween.KillAll();

        LoadingEvents.OnShowLoadingScreen -= ShowView;
        LoadingEvents.OnHideLoadingScreen -= HideView;
    }

    private async void ShowView()
    {
        await SetViewActive(true);
    }

    private async void HideView()
    {
        await SetViewActive(false);
    }

    private async UniTask SetViewActive(bool isActive)
    {
        if (isActive)
        {
            FadeIn();
            _loadingTween = AnimateLoading();
        }
        else
        {
            try
            {
                _cts?.Cancel();
                _cts?.Dispose();

                _cts = new CancellationTokenSource();

                FadeOut();
                await UniTask.Delay(DELAY_AFTER_VIEW_HIDE, cancellationToken: _cts.Token);
                _loadingTween?.Kill();
                _loadingCircle.transform.rotation = Quaternion.Euler(0, 0, 0); // reset rot
            }
            catch(OperationCanceledException)
            {
                return;
            }
        }

        _canvasGroup.interactable = isActive;
        _canvasGroup.blocksRaycasts = isActive;
    }

    private Tween AnimateLoading()
    {
        return _loadingCircle.transform
            .DORotate(new Vector3(0, 0, -360), _durationCicleRotation, RotateMode.FastBeyond360)
                .SetEase(Ease.Linear)
                    .SetLoops(-1, LoopType.Restart);
    }

    private Tween FadeIn()
    {
        return _canvasGroup.DOFade(1f, 1f);
    }

    private Tween FadeOut()
    {
        return _canvasGroup.DOFade(0f, 1f);
    }
}
