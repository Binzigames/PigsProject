using UnityEngine;
using UnityEngine.UIElements;

public class HUDView : UIView
{
    private const string SCORE_LABLE = "score-lable";

    private Label _scoreLable;

    public HUDView(VisualElement root) : base(root)
    {
        // test
        _scoreLable.text = "5";
    }

    protected override void SetVisualElements()
    {
        _scoreLable = _root.Q<Label>(SCORE_LABLE);
    }
    
}
