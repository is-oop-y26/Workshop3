namespace Expressions.Operators;

public class DelegateBinaryOperator : IBinaryOperator
{
    private readonly Func<double, double, double> _func;
    private readonly string _stringRepresentation;

    public DelegateBinaryOperator(
        string stringRepresentation,
        Func<double, double, double> func)
    {
        _stringRepresentation = stringRepresentation;
        _func = func;
    }

    public IExpressionValue Apply(IExpressionValue left, IExpressionValue right)
    {
        var value = _func.Invoke(left.Value, right.Value);
        return new Constant(value);
    }

    public string Format(IExpression left, IExpression right)
    {
        return $"({left.Format()} {_stringRepresentation} {right.Format()})";
    }
}