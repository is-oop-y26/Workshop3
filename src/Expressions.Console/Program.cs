// See https://aka.ms/new-console-template for more information

using Expressions;
using Expressions.Contexts;
using Expressions.Extensions;


var expression = new Constant(2).Add(new Variable("x")).Multiply(new Variable("y"));

var context = ExpressionContext.Build
    .AddVariable("x", 3)
    .AddVariable("y", 3)
    .Build();

var result = expression.Evaluate(context);

Console.WriteLine(result);
