using Expressions.Results;

namespace Expressions;

public interface IExpressionContext
{
    VariableResolutionResult GetVariableValue(string name);
}