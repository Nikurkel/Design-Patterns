using TddVocabulary;

public class Manager
{
    public int SuccessCount { get; private set; }
    public int FailureCount { get; private set; }

    private readonly int taskOptionCount = 4;
    private VocabularyTask currentTask;

    public Manager()
    {
        SuccessCount = 0;
        FailureCount = 0;
        currentTask = VocabularyExtensions.CreateTask(taskOptionCount);
    }

    public VocabularyTask GetCurrentTask() => currentTask;

    public bool CheckAnswer(VocabularyUnit answer)
    {
        if (answer != currentTask.CorrectAnswer)
        {
            FailureCount++;
            return false;
        }

        SuccessCount++;
        return true;
    }

    public VocabularyTask CreateNextTask()
    {
        var set = VocabularyExtensions.CreateTask(taskOptionCount);
        currentTask = new VocabularyTask(set);
        return GetCurrentTask();
    }
}
