namespace TDDLib.Stack;

public class StackX<T>
{
    private NodeX<T> currentNode;

    public StackX()
    {
        currentNode = null;
    }

    public void Push(T value)
    {
        var newNode = new NodeX<T>(value, currentNode);
        currentNode = newNode;
    }

    public T Pop()
    {
        if (currentNode == null)
        {
            return default;
        }

        var result = currentNode.Value;
        currentNode = currentNode.Next;
        return result;
    }

    public int GetSize()
    {
        var current = currentNode;
        var size = 0;

        while (current != null)
        {
            current = current.Next;
            size++;
        }

        return size;
    }
}
