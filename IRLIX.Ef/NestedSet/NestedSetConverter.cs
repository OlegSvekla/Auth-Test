namespace IRLIX.Ef.NestedSet;

public interface INestedSetConverter<T, out TNestedObject, TNode>
    where TNestedObject : INestedSetObject<T>, new()
    where TNode : INestedSetNode<T, TNode>
{
    IEnumerable<TNestedObject> RecalculateHierarchy(IEnumerable<TNode> allEntities);
}
//TODO: Add NestedSetToNode
public class NestedSetConverter<T, TNestedObject, TNode>
    : INestedSetConverter<T, TNestedObject, TNode>
    where TNestedObject : INestedSetObject<T>, new()
    where TNode : INestedSetNode<T, TNode>
{
    private int currentLeft;

    public IEnumerable<TNestedObject> RecalculateHierarchy(IEnumerable<TNode> allEntities)
    {
        var nestedSetList = new List<TNestedObject>();

        foreach (var entity in allEntities)
        {
            CalculateTariffNestedSetValues(entity, nestedSetList);
        }

        return nestedSetList;
    }

    private void CalculateTariffNestedSetValues(TNode node, ICollection<TNestedObject> nestedSetList)
    {
        var left = currentLeft++;

        if (node.Children != null)
        {
            foreach (var child in node.Children)
            {
                CalculateTariffNestedSetValues(child, nestedSetList);
            }
        }

        var right = currentLeft++;

        nestedSetList.Add(new TNestedObject { Value = node.Value, Left = left, Right = right });
    }
}
