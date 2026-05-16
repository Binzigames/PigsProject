using UnityEngine;

[CreateAssetMenu(fileName = nameof(LevelDifficultyDataContainer), menuName = "ScriptableObject/DataContainer/" + nameof(LevelDifficultyDataContainer))]
public class LevelDifficultyDataContainer : BaseStaticDataContainer
{
    [SerializeField] private LevelDifficultyData[] _levelDifficultyData;

    public LevelDifficultyData GetLevelDifficulty(LevelDifficultyType type)
    {
        foreach (var levelData in _levelDifficultyData)
        {
            if (levelData.DifficultyType == type)
            {
                return levelData;
            }
            else
            {
                Debug.Log($"{levelData} has not found in container.");
            }
        }
        return null;
    }

}