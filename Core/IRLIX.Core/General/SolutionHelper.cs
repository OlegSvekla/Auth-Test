namespace IRLIX.Core.General;

//TODO: add cache for used types in methods
public static class SolutionHelper
{
    public static IEnumerable<Type> GetSolutionClassesByInterface<TInterface>(
        Func<Type, bool>? predicate = null)
    {
        var types = AppDomain.CurrentDomain.GetAssemblies()
            .SelectMany(assembly => assembly.GetTypes())
            .Where(x => x.IsClass && !x.IsAbstract && typeof(TInterface).IsAssignableFrom(x));

        if (predicate != null)
        {
            types = types.Where(predicate);
        }

        return types;
    }

    public static IEnumerable<Type> GetSolutionDerivedClasses<TBaseClass>(
        Func<Type, bool>? predicate = null)
    {
        var types = AppDomain.CurrentDomain.GetAssemblies()
            .SelectMany(assembly => assembly.GetTypes())
            .Where(x => x.IsClass && !x.IsAbstract && x.IsSubclassOf(typeof(TBaseClass)));

        if (predicate != null)
        {
            types = types.Where(predicate);
        }

        return types;
    }

    public static IEnumerable<Type> GetSolutionAttributedClasses<TAttribute>()
    {
        var types = AppDomain.CurrentDomain.GetAssemblies()
            .SelectMany(assembly => assembly.GetTypes())
            .Where(x => x.IsClass && !x.IsAbstract && x.GetCustomAttributes(typeof(TAttribute), false).Length != 0);

        return types;
    }
}
