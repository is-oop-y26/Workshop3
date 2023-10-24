using Expressions.Results;

namespace Expressions.Contexts;

public class ExpressionContext : IExpressionContext
{
    private readonly IReadOnlyDictionary<string, double> _variables;

    private ExpressionContext(IReadOnlyDictionary<string, double> variables)
    {
        _variables = variables;
    }

    public static Builder Build => new Builder();

    public VariableResolutionResult GetVariableValue(string name)
    {
        return _variables.TryGetValue(name, out var value)
            ? new VariableResolutionResult.Success(new Constant(value))
            : new VariableResolutionResult.NotFound();
    }

    public class Builder
    {
        private readonly Dictionary<string, double> _variables;

        public Builder()
        {
            _variables = new Dictionary<string, double>();
        }

        public Builder AddVariable(string name, double value)
        {
            _variables[name] = value;
            return this;
        }

        public ExpressionContext Build()
        {
            return new ExpressionContext(_variables);
        }
    }
}