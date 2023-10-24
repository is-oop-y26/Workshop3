using Expressions.Operators;

namespace Expressions.Extensions;

public static class ExpressionExtensions
{
    public static IExpression Add(this IExpression left, IExpression right)
    {
        return new BinaryExpression(
            left,
            right,
            new DelegateBinaryOperator("+", (a, b) => a + b));
    }

    public static IExpression Subtract(this IExpression left, IExpression right)
    {
        return new BinaryExpression(
            left,
            right,
            new DelegateBinaryOperator("-", (a, b) => a - b));
    }

    public static IExpression Multiply(this IExpression left, IExpression right)
    {
        return new BinaryExpression(
            left,
            right,
            new DelegateBinaryOperator("*", (a, b) => a * b));
    }

    public static IExpression Divide(this IExpression left, IExpression right)
    {
        return new BinaryExpression(
            left,
            right,
            new DelegateBinaryOperator("/", (a, b) => a / b));
    }
}