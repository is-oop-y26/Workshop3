using Expressions;

namespace Articles.ExpressionIntegration.Extensions;

public static class ExpressionExtensions
{
    public static IExpression AddModifier(
        this IExpression expression,
        IRenderableModifier modifier)
    {
        return new FormattedExpression(expression, modifier);
    }
}