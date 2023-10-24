namespace Expressions.Results;

public abstract record VariableResolutionResult
{
    private VariableResolutionResult() { }

    public sealed record Success(IExpressionValue Value) : VariableResolutionResult;

    public sealed record NotFound : VariableResolutionResult;
}