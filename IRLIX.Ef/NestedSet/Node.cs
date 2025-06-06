namespace IRLIX.Ef.NestedSet;

public interface INestedSetNode<T, TNode>
    where TNode : INestedSetNode<T, TNode>
{
    public T Value { get; set; }

    public ICollection<TNode>? Children { get; set; }
}

public class Node<T> : INestedSetNode<T, Node<T>>
{
    public T Value { get; set; } = default!;

    public ICollection<Node<T>>? Children { get; set; }
}
