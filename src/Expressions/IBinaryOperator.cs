namespace Expressions;

public interface IBinaryOperator
{
    IExpressionValue Apply(IExpressionValue left, IExpressionValue right);

    string Format(IExpression left, IExpression right);
}