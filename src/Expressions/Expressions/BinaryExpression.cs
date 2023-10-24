using Expressions.Results;

namespace Expressions;

public class BinaryExpression : IExpression
{
    private readonly IExpression _left;
    private readonly IExpression _right;
    private readonly IBinaryOperator _binaryOperator;

    public BinaryExpression(
        IExpression left,
        IExpression right,
        IBinaryOperator binaryOperator)
    {
        _left = left;
        _right = right;
        _binaryOperator = binaryOperator;
    }

    public ExpressionEvaluationResult Evaluate(
        IExpressionContext context)
    {
        var left = _left.Evaluate(context);
        var right = _right.Evaluate(context);

        return (left, right) switch
        {
            (ExpressionEvaluationResult.Full l, ExpressionEvaluationResult.Full r)
                => new ExpressionEvaluationResult.Full(_binaryOperator.Apply(l.Value, r.Value)),
            
            (ExpressionEvaluationResult.Full l, ExpressionEvaluationResult.Partial r)
                => new ExpressionEvaluationResult.Partial( new BinaryExpression(l.Value, r.Result, _binaryOperator)),
            
            (ExpressionEvaluationResult.Partial l, ExpressionEvaluationResult.Full r)
                => new ExpressionEvaluationResult.Partial(new BinaryExpression(l.Result, r.Value, _binaryOperator)),
            
            _ => new ExpressionEvaluationResult.Partial(this),
        };
    }

    public string Format()
    {
        return _binaryOperator.Format(_left, _right);
    }
}