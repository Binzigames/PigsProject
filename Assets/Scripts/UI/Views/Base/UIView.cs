using System;
using UnityEngine.UIElements;

public abstract class UIView : IDisposable
{
    protected VisualElement _root;

    public UIView(VisualElement root)
    {
        _root = root;
        Initialize();
    }

    private void Initialize()
    {
        SetVisualElements();
        RegisterButtonCallbacks();
    }

    protected virtual void SetVisualElements() { }
    protected virtual void RegisterButtonCallbacks() { }

    public virtual void Show()
    {
        _root.style.display = DisplayStyle.Flex;
    }
    public virtual void Hide()
    {
        _root.style.display = DisplayStyle.None;
    }

    public virtual void Dispose() { }
}
