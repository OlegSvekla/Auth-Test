namespace IRLIX.Ef.TreeSearchBfs;

public class BfsSearcherTree<TNode> : BfsSearcherTree<Guid, TNode>
    where TNode : class, ITreeNode<Guid, TNode>
{
}
