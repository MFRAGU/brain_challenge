
using System.Collections.Generic;
using System.Linq;

public class QuestionResultDTO
{
    public string name;
    public List<QuestionDTO> data;

    public QuestionResult ToQuestionResult()
    {
        List<Question> questionList = data.Select(q => q.ToQuestion()).ToList();
        return new QuestionResult(name, questionList);
    }

}
