using System.Globalization;
using Expressions.Results;

namespace Expressions;

public class Constant : IExpressionValue
{
    public Constant(double value)
    {
        Value = value;
    }

    public double Value { get; }

    public ExpressionEvaluationResult Evaluate(IExpressionContext context)
    {
        return new ExpressionEvaluationResult.Full(this);
    }

    public string Format()
    {
        return Value.ToString(CultureInfo.InvariantCulture);
    }
}