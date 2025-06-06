namespace IRLIX.Ef.Filtering;

public static class Consts
{
    public const char ConditionsSeparator = ',';
    public const string ExpressionArgName = "x";
    public const string ExpressionSeparator = "::";
    public const int ExpressionPartsCount = 3;

    public static class Operators
    {
        public const string Eq = "eq";
        public const string Neq = "neq";
        public const string Ss = "ss";
        public const string Gt = "gt";
        public const string Gte = "gte";
        public const string Lt = "lt";
        public const string Lte = "lte";
    }
}
