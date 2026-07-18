using ModestTree;
using UnityEngine;

[CreateAssetMenu(fileName = nameof(LevelDifficultyDataContainer), menuName = "ScriptableObject/DataContainer/" + nameof(LevelDifficultyDataContainer))]
public class LevelDifficultyDataContainer : BaseStaticDataContainer
{
    [SerializeField]
    private LevelDifficultyData[] _levelDifficultyData;

    private LevelDifficultyData _currentLevel;
    public LevelDifficultyData CurrentLevel => _currentLevel;

    public LevelDifficultyData GetLevelDifficulty(LevelDifficultyType type)
    {
        foreach (var levelData in _levelDifficultyData)
        {
            if (levelData.DifficultyType == type)
            {
                _currentLevel = levelData;
                return levelData;
            }
            else
            {
                Debug.Log($"{levelData} has not found in container.");
            }
        }
        return null;
    }

    public LevelDifficultyData GetNextDifficulty()
    {
        var currentIndex = _levelDifficultyData.IndexOf(_currentLevel);

        if (currentIndex == -1 || currentIndex >= _levelDifficultyData.Length - 1)
            return null;

        _currentLevel = _levelDifficultyData[currentIndex + 1];
        return _currentLevel;
    }

}