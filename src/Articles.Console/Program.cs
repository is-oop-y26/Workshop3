// See https://aka.ms/new-console-template for more information

using System.Drawing;
using Articles.Articles;
using Articles.Drawers;
using Articles.ExpressionIntegration;
using Articles.ExpressionIntegration.Extensions;
using Articles.Extensions;
using Articles.Modifiers;
using Articles.Paragraphs;
using Articles.Paragraphs.Factories;
using Articles.Renderables;
using Expressions;
using Expressions.Contexts;
using Expressions.Extensions;

var articleBuilder = new ArticleBuilder();
var paragraphBuilderFactory = new StyledParagraphBuilderFactory(Color.Aqua);

var drawer = new ConsoleDrawer();

var article = CreateArticle(articleBuilder, paragraphBuilderFactory);

drawer.Draw(article);

static IArticle CreateArticle(
    IArticleBuilder articleBuilder,
    IParagraphBuilderFactory paragraphBuilderFactory)
{
    var expression = new Constant(2).Add(new Variable("x")).AddModifier(new ColorModifier(Color.Red)).Multiply(new Variable("y"));

    var context = ExpressionContext.Build
        .AddVariable("x", 3)
        // .AddVariable("y", 3)
        .Build();

    articleBuilder.WithName(new Text("Sample")
        .AddModifier(new UnderlineModifier())
        .AddModifier(new BoldModifier())
        .AddModifier(new ColorModifier(Color.Red)));

    articleBuilder
        .WithAuthor(new ExpressionRenderable(expression, context));

    var endTemplate = new Text("end")
        .AddModifier(new BoldModifier());

    for (var i = 0; i < 5; i++)
    {
        var paragraphBuilder = paragraphBuilderFactory
            .Create()
            .WithTitle(new Text(i.ToString()));

        for (var j = 0; j < i; j++)
        {
            var section = new Text(
                string.Concat(Enumerable.Repeat(i.ToString(), i)));

            paragraphBuilder.AddSection(section);
        }

        var end = i % 2 is 1
            ? endTemplate.WithModifier(new ColorModifier(Color.Brown))
            : endTemplate.WithModifier(new ColorModifier(Color.Green));

        paragraphBuilder.WithFooter(end);

        articleBuilder.AddParagraph(paragraphBuilder.Build());
    }

    return articleBuilder.Build();
}