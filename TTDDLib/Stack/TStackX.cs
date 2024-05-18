namespace TDDLibTests.Stack;

using NUnit.Framework;
using TDDLib.Stack;

public class TStackX
{

    [Test]
    public void Constructor_ShouldCreateStack()
    {
        var stack = new StackX<dynamic>();

        Assert.That(stack, Is.Not.Null);
    }

    [Test]
    public void Pop_ShouldReturnHead()
    {
        var stack = new StackX<dynamic>();
        var result = stack.Pop();

        Assert.That(result, Is.Null);
    }

    [Test]
    public void Push_ShouldChangeHead()
    {
        var expected = "x";
        var stack = new StackX<dynamic>();
        stack.Push(expected);

        var result = stack.Pop();

        Assert.That(result, Is.EqualTo(expected));
    }

    [Test]
    public void Pop_ShouldChangeHead()
    {
        var stack = new StackX<dynamic>();
        stack.Push("x");
        stack.Pop();

        var result = stack.Pop();

        Assert.That(result, Is.Null);
    }

    [Test]
    public void Count_ShouldReturnStackCount()
    {
        var expectedSize = 10;
        var stack = new StackX<dynamic>();

        foreach (var item in Enumerable.Range(0, expectedSize))
        {
            stack.Push(item);
        }

        Assert.That(stack.Size, Is.EqualTo(expectedSize));
    }
}