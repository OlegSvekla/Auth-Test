namespace IRLIX.Ef.TreeSearchBfs;

public interface ITreeNode<T, TNode>
    where T : struct, IEquatable<T>
    where TNode : ITreeNode<T, TNode>
{
    public T Id { get; set; }

    public T? ParentEntityId { get; set; }

    public IList<TNode> Children { get; set; }
}
