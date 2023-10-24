using Expressions.Results;

namespace Expressions;

public interface IExpression
{
    ExpressionEvaluationResult Evaluate(IExpressionContext context);

    string Format();
}