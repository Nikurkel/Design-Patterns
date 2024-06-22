namespace TddVocabularyTests;

using TddVocabulary;

public class TVocabularyTaskGenerator
{
    [Test]
    public void CreateNew_ShouldReturnNewVocabularyTask()
    {
        var generator = TVocabularyTaskGenerator ;

        var expectedOptionCount = 5;

        var vocabularyTask = generator.CreateNew(expectedOptionCount);

        Assert.That(vocabularyTask.Vocabulary.Count(), Is.EqualTo(expectedOptionCount));
    }
}