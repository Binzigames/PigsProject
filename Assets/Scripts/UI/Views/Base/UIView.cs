using System;
using System.Diagnostics;
using System.Threading;
using Cysharp.Threading.Tasks;
using UnityEngine.UIElements;

public abstract class UIView : IDisposable
{
    protected VisualElement _root;
    private CancellationTokenSource _cts;

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

    /// <summary>
    /// Show view after delay.
    /// </summary>
    /// <param name="delay">In milliseconds</param>
    public async virtual UniTask ShowOnDelay(int delay)
    {

        try
        {
            _cts?.Cancel();
            _cts?.Dispose();
            _cts = new CancellationTokenSource();

            await UniTask.Delay(delay, cancellationToken: _cts.Token);
            _root.style.display = DisplayStyle.Flex;
        }
        catch (OperationCanceledException)
        {
            return;
        }
        finally
        {
            _root.style.display = DisplayStyle.Flex;
        }
    }

    /// <summary>
    /// Hide view after delay.
    /// </summary>
    /// <param name="delay">In milliseconds</param>
    public async virtual UniTask HideOnDelay(int delay)
    {
        try
        {
            _cts?.Cancel();
            _cts?.Dispose();
            _cts = new CancellationTokenSource();

            await UniTask.Delay(delay, cancellationToken: _cts.Token);
            _root.style.display = DisplayStyle.None;
        }
        catch (OperationCanceledException)
        {
            return;
        }
        finally
        {
            _root.style.display = DisplayStyle.None;
        }
    }


    public virtual void Dispose() { }
}
