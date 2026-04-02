using UnityEngine;

[RequireComponent(typeof(PlayerTouchController))]
public class Player : MonoBehaviour
{
    [SerializeField] private Rigidbody _rigidbody;
    [SerializeField] private PlayerTouchController _playerController;

    public Rigidbody RigidBody => _rigidbody;
    public PlayerTouchController PlayerController => _playerController;

    private void OnValidate()
    {
        _rigidbody = GetComponent<Rigidbody>();

        _playerController = GetComponent<PlayerTouchController>();
    }
    

}
