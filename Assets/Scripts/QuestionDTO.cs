
public class QuestionDTO
{
    public string correctAnswer { get; private set; }
    public string incorrectAnswers { get; private set; }
    public string question { get; private set; }

    public Question toQuestion()
    {
        return new Question(
            correctAnswer, 
            Utils.stringToArray('/', incorrectAnswers),
            question
        );
    }
}
