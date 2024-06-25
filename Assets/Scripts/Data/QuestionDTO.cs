
public class QuestionDTO
{
    public string correctAnswer;
    public string incorrectAnswers;
    public string question;

    public Question ToQuestion()
    {
        return new Question(
            correctAnswer, 
            Utils.stringToArray('/', incorrectAnswers),
            question
        );
    }
}
