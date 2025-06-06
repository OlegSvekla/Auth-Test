namespace IRLIX.Ef.TreeSearchBfs;

public interface IBfsSearcherTree<T, TNode>
    where T : struct, IEquatable<T>
    where TNode : ITreeNode<T, TNode>
{
    bool HasCircle(TNode root);
}

public class BfsSearcherTree<T, TNode> : IBfsSearcherTree<T, TNode>
    where TNode : class, ITreeNode<T, TNode>
    where T : struct, IEquatable<T>
{
    public bool HasCircle(TNode root)
    {
        var queue = new Queue<TNode>();

        queue.Enqueue(root);

        var rootId = root.Id;
        var rootParentId = root.ParentEntityId;

        while (queue.Count > 0)
        {
            var node = queue.Dequeue();

            foreach (var child in node.Children)
            {
                if (rootId.Equals(child.Id) || (rootParentId.Equals(child.Id) && rootParentId is not null))
                {
                    return true;
                }

                queue.Enqueue(child);
            }
        }

        return false;
    }
}
