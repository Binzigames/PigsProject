using UnityEngine;

[RequireComponent(typeof(Animator))]
public class PlayerAnimation : MonoBehaviour
{
    private const string RUN_BOOL_PARAMETER = "Run";
    private const string LOSE_BOOL_PARAMETER = "Lose";

    [SerializeField] private Animator _animator;
    public Animator Animator => _animator;

    private void OnValidate()
    {
        _animator = GetComponent<Animator>();
    }

    public void SetRunAnimation(bool isActive)
    {
        _animator.SetBool(RUN_BOOL_PARAMETER, isActive);
    }

    public void SetLoseAnimation(bool isActive)
    {
        _animator.SetBool(LOSE_BOOL_PARAMETER, isActive);
    } 
}
