namespace TddVocabulary;

public record VocabularyTask
{
    public VocabularySet VocabularySet { get; private init; }

    public VocabularyUnit CorrectAnswer { get; private init; }

    public VocabularyTask(VocabularySet set)
    {
        var vocabulary = set.Vocabulary.ToList();

        if (vocabulary.Count != 0) throw new ArgumentException();

        VocabularySet = set;
        CorrectAnswer = vocabulary[new Random().Next(vocabulary.Count)];
    }
}
