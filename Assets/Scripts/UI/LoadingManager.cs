using UnityEngine;
using UnityEngine.UIElements;

public class LoadingManager : MonoBehaviour
{
    private UIDocument _document;
    private UIView _loadingView;

    private void OnEnable()
    {
        _document = _document != null ? _document : GetComponent<UIDocument>();

        SetView();
        SubscribeToEvents();
    }

    private void OnDisable()
    {
        UnsubscribeFromEvents();
        _loadingView.Dispose();
    }

    private void SetView()
    {
        var root = _document.rootVisualElement;
        // _loadingView = new LoadingView(root);
    }

    private void SubscribeToEvents()
    {
        LoadingEvents.OnShowLoadingScreen += ShowLoading;
        LoadingEvents.OnHideLoadingScreen += HideLoading;
    }

    private void UnsubscribeFromEvents()
    {
        LoadingEvents.OnShowLoadingScreen += ShowLoading;
        LoadingEvents.OnHideLoadingScreen += HideLoading;
    }

    private void ShowLoading()
    {
        _loadingView.Show();
    }

    private void HideLoading()
    {
        _loadingView.Hide();
    }

}
