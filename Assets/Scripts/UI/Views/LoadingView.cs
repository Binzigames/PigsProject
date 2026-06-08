using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;

public class LoadingView : MonoBehaviour
{
    [SerializeField] private CanvasGroup _canvasGroup;
    [SerializeField] private GameObject _loadingCircle;

    private void Awake()
    {

    }

    private void OnDestroy()
    {
        DOTween.Kill(AnimateLoading());
    }

    private Tween AnimateLoading()
    {
        return _loadingCircle.transform
            .DORotate(new Vector3(0, 0, -360), 0.5f, RotateMode.FastBeyond360)
                .SetEase(Ease.Linear)
                    .SetLoops(-1, LoopType.Restart);
    }

    public void SetViewActive(bool isActive)
    {
        if (isActive)
        {
            FadeIn();
            AnimateLoading();
        }
        else
        {
            FadeOut();
            DOTween.Kill(AnimateLoading());
        }

        _canvasGroup.interactable = isActive;
        _canvasGroup.blocksRaycasts = isActive;
    }

    private void FadeIn()
    {
        _canvasGroup.DOFade(1f, 1f);
    }

    private void FadeOut()
    {
        _canvasGroup.DOFade(0f, 1f);
    }
}
