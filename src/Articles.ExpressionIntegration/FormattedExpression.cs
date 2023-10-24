using Expressions;
using Expressions.Results;

namespace Articles.ExpressionIntegration;

public class FormattedExpression : IExpression
{
    private readonly IExpression _expression;
    private readonly IRenderableModifier _modifier;

    public FormattedExpression(IExpression expression, IRenderableModifier modifier)
    {
        _expression = expression;
        _modifier = modifier;
    }

    public ExpressionEvaluationResult Evaluate(IExpressionContext context)
    {
        return _expression.Evaluate(context) switch
        {
            ExpressionEvaluationResult.Full full
                => new ExpressionEvaluationResult.Full(new FormattedExpressionValue(full.Value, _modifier)),

            ExpressionEvaluationResult.Partial partial
                => new ExpressionEvaluationResult.Partial(new FormattedExpression(partial.Result, _modifier)),

            _ => throw new ArgumentOutOfRangeException(),
        };
    }

    public string Format()
    {
        return _modifier.Modify(_expression.Format());
    }
}