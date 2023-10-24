using Expressions.Results;

namespace Expressions;

public class Variable : IExpression
{
    private readonly string _name;

    public Variable(string name)
    {
        _name = name;
    }

    public ExpressionEvaluationResult Evaluate(
        IExpressionContext context)
    {
        return context.GetVariableValue(_name) switch
        {
            VariableResolutionResult.Success success
                => new ExpressionEvaluationResult.Full(success.Value),

            VariableResolutionResult.NotFound
                => new ExpressionEvaluationResult.Partial(this),

            _ => throw new ArgumentOutOfRangeException(),
        };
    }

    public string Format()
    {
        return _name;
    }
}