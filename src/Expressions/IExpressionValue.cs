namespace Expressions;

public interface IExpressionValue : IExpression
{
    double Value { get; }
}