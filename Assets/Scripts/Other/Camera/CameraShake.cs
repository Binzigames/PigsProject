using DG.Tweening;
using UnityEngine;
using Zenject;

public class CameraShake : MonoBehaviour
{
    [Inject] private readonly Player _player;

    [SerializeField]
    private Camera _camera;

    [SerializeField]
    private float _duration = 1f;

    [SerializeField]
    private float _strength = 3f;

    [SerializeField]
    private int _vibrato = 10;

    [SerializeField]
    private float _randomness = 90f;

    private void OnValidate()
    {
        _camera = _camera != null ? _camera : GetComponent<Camera>();
    }

    private void Awake()
    {
        _player.OnPlayerCrashed += Shake;
    }

    private void OnDestroy()
    {
        _player.OnPlayerCrashed -= Shake;
    }

    private void Shake()
    {
        _camera.DOShakePosition(_duration, _strength, _vibrato, _randomness, fadeOut: true);
    }

}
