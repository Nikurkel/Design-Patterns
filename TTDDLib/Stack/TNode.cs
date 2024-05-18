namespace TDDLibTests.Stack;

using NUnit.Framework;
using TDDLib.Stack;

public class TNodeX
{

    [Test]
    public void Constructor_ShouldCreateNode()
    {
        var expectedValue = "x";
        var node = new NodeX<string>(expectedValue);

        Assert.That(node, Is.Not.Null);
        Assert.Multiple(() =>
        {
            Assert.That(node.Value, Is.EqualTo(expectedValue));
            Assert.That(node.Next, Is.Null);
        });
    }

    [Test]
    public void Constructor_ShouldCreateReferencingNode()
    {
        var expectedValue = "x";
        var node = new NodeX<string>(expectedValue);
        var topNode = new NodeX<string>(expectedValue, node);

        Assert.Multiple(() =>
        {
            Assert.That(topNode.Value, Is.EqualTo(expectedValue));
            Assert.That(topNode.Next, Is.EqualTo(node));
        });
    }
}