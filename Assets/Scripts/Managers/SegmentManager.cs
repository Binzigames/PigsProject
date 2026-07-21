using Assets.Scripts.Patterns.ObjectPool;
using DevConfigs.GameStateMachine;
using UnityEngine;
using Zenject;

public class SegmentManager : MonoBehaviour
{
    private ObjectPool _objectPool;
    private LevelDifficultyDataContainer _levelDifficultyDataContainer;
    private GameManager _gameManager;

    [SerializeField] private float _moveSpeed;
    [SerializeField] private Transform _spawnPosition;

    [Inject]
    public void Construct(ObjectPool objectPool, IStaticDataProvider dataProvider, GameManager gameManager)
    {
        _objectPool = objectPool;
        _levelDifficultyDataContainer = dataProvider.GetDataContainer<LevelDifficultyDataContainer>();
        _gameManager = gameManager;
    }

    private void Awake()
    {
        SetLevelSpeedUp(LevelDifficultyType.Ease);
        _gameManager.GameSpeedTimer.OnTimeReached += SwitchToNextLevelSpeedUp;
    }

    private void OnDestroy()
    {
        _gameManager.GameSpeedTimer.OnTimeReached -= SwitchToNextLevelSpeedUp;
    }

    private void FixedUpdate()
    {
        if (_gameManager.GameStateMachine.CurrentState is RunningState)
        {
            MoveSegmentsIfActive();
        }
    }

    private void MoveSegmentsIfActive()
    {
        foreach (var segment in _objectPool.PooledObjectList)
        {
            if (segment.activeInHierarchy)
            {
                MoveSegment(segment);
            }
        }
    }

    private void MoveSegment(GameObject segment)
    {
        segment.transform.position += _moveSpeed * Time.fixedDeltaTime * Vector3.back;
    }

    private void SetLevelSpeedUp(LevelDifficultyType type)
    {
        var difficultyData = _levelDifficultyDataContainer.GetLevelDifficulty(type);
        _moveSpeed = difficultyData.MoveSpeed;
    }

    private void SwitchToNextLevelSpeedUp()
    {
        var difficultyData = _levelDifficultyDataContainer.GetNextDifficulty();

        if (difficultyData != null)
        {
            _moveSpeed = difficultyData.MoveSpeed;
            Debug.Log($"{difficultyData}, {_moveSpeed}");
        }
    }

    public void GetSegmentFromPool()
    {
        var pooledSegment = _objectPool.GetObjectFromPool();
        pooledSegment.transform.SetPositionAndRotation(_spawnPosition.position, Quaternion.identity);
    }

    public void ReleaseSegmentToPool(GameObject gameObject)
    {
        _objectPool.ReleaseObjectToPool(gameObject);
    }

}