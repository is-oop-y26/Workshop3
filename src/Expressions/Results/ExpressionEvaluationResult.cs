namespace Expressions.Results;

public abstract record ExpressionEvaluationResult
{
    private ExpressionEvaluationResult() { }

    public sealed record Full(IExpressionValue Value) : ExpressionEvaluationResult
    {
        public override string ToString()
        {
            return Value.Format();
        }
    }

    public sealed record Partial(IExpression Result) : ExpressionEvaluationResult
    {
        public override string ToString()
        {
            return Result.Format();
        }
    }
}