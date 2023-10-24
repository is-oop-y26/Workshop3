using Expressions.Results;

namespace Expressions;

public class UnaryMinus : IExpression
{
    private readonly IExpression _value;

    public UnaryMinus(IExpression value)
    {
        _value = value;
    }

    public ExpressionEvaluationResult Evaluate(IExpressionContext context)
    {
        return _value.Evaluate(context) switch
        {
            ExpressionEvaluationResult.Full full
                => new ExpressionEvaluationResult.Full(new Constant(-full.Value.Value)),

            ExpressionEvaluationResult.Partial
                => new ExpressionEvaluationResult.Partial(this),

            _ => throw new ArgumentOutOfRangeException(),
        };
    }

    public string Format()
    {
        return $"(-{_value.Format()})";
    }
}