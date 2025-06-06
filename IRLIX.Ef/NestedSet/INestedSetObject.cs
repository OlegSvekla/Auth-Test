namespace IRLIX.Ef.NestedSet;

public interface INestedSetObject<T>
{
    public T Value { get; set; }

    public int Left { get; set; }

    public int Right { get; set; }
}
