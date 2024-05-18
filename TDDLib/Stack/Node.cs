namespace TDDLib.Stack;

public sealed record NodeX<T>(T Value, NodeX<T> Next = null);