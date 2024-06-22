namespace TddVocabulary;

public static class VocabularyExtensions
{
    private static readonly List<VocabularyUnit> totalVocabulary = new List<VocabularyUnit>
    {
        new VocabularyUnit("こんにちは", "Hello"),
    };

    public static VocabularySet CreateSet(int optionCount)
    {
        var options = Enumerable.Range(0, optionCount).Select(_ => GetNewVocabularyUnit());

        return new VocabularySet(options);
    }

    private static VocabularyUnit GetNewVocabularyUnit()
    {
        return totalVocabulary[new Random().Next(totalVocabulary.Count)];
    }

    public static VocabularyTask CreateTask(int optionCount)
    {
        return new VocabularyTask(CreateSet(optionCount));
    }
}
