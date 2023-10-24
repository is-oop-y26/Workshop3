using Expressions;
using Expressions.Results;

namespace Articles.ExpressionIntegration;

public class FormattedExpressionValue : IExpressionValue
{
    private readonly IExpressionValue _value;
    private readonly IRenderableModifier _modifier;

    public FormattedExpressionValue(
        IExpressionValue value,
        IRenderableModifier modifier)
    {
        _value = value;
        _modifier = modifier;
    }

    public double Value => _value.Value;

    public ExpressionEvaluationResult Evaluate(IExpressionContext context)
    {
        return new ExpressionEvaluationResult.Full(this);
    }

    public string Format()
    {
        return _modifier.Modify(_value.Format());
    }
}