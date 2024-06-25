
public enum Difficulty
{
    RANDOM,
    EASY,
    MEDIUM,
    HARD
}

public class DifficultyLevelExtension
{
    public static string ToString(Difficulty difficultyLevel)
    {
        switch (difficultyLevel)
        {
            case Difficulty.RANDOM:
                return "Aleatoire";
            case Difficulty.EASY:
                return "Facile";
            case Difficulty.MEDIUM:
                return "Moyen";
            case Difficulty.HARD:
                return "Difficile";
            default:
                return "Non definis";
        }
    }
}