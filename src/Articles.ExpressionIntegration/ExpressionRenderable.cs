using Expressions;

namespace Articles.ExpressionIntegration;

public class ExpressionRenderable : IRenderable
{
    private readonly IExpression _expression;
    private readonly IExpressionContext _context;

    public ExpressionRenderable(IExpression expression, IExpressionContext context)
    {
        _expression = expression;
        _context = context;
    }

    public string Render()
    {
        return _expression.Evaluate(_context).ToString() ?? string.Empty;
    }
}