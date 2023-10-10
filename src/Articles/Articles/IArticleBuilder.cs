using Articles.Paragraphs;

namespace Articles.Articles;

public interface IArticleBuilder
{
    IArticleBuilder WithName(IRenderable renderable);

    IArticleBuilder AddParagraph(IParagraph paragraph);

    IArticleBuilder WithAuthor(IRenderable renderable);

    IArticle Build();
}