using Unity.VisualScripting;

public enum DifficultyLevel
{
    Random,
    Easy,
    Medium,
    Hard
}

public class DifficultyLevelExtension
{
    public static string ToString(DifficultyLevel difficultyLevel)
    {
        switch (difficultyLevel)
        {
            case DifficultyLevel.Random:
                return "Aléatoire";
            case DifficultyLevel.Easy:
                return "Facile";
            case DifficultyLevel.Medium:
                return "Moyen";
            case DifficultyLevel.Hard:
                return "Difficile";
            default:
                return "Non définis";
        }
    }
}