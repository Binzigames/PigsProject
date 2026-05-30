using UnityEngine;

[CreateAssetMenu (fileName = nameof(LevelDifficultyData), menuName = "ScriptableObject/Data/" + nameof(LevelDifficultyData))]
public class LevelDifficultyData : ScriptableObject
{
    [SerializeField] private LevelDifficultyType _difficultyType;
    [SerializeField] private float _moveSpeed;

    public LevelDifficultyType DifficultyType => _difficultyType;
    public float MoveSpeed => _moveSpeed;
}
