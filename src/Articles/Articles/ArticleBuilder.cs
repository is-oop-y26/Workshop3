using Articles.Paragraphs;

namespace Articles.Articles;

public class ArticleBuilder : IArticleBuilder
{
    private readonly List<IParagraph> _paragraphs;
    private IRenderable? _name;
    private IRenderable? _author;

    public ArticleBuilder()
    {
        _paragraphs = new List<IParagraph>();
    }

    public IArticleBuilder WithName(IRenderable renderable)
    {
        _name = renderable;
        return this;
    }

    public IArticleBuilder AddParagraph(IParagraph paragraph)
    {
        _paragraphs.Add(paragraph);
        return this;
    }

    public IArticleBuilder WithAuthor(IRenderable renderable)
    {
        _author = renderable;
        return this;
    }

    public IArticle Build()
    {
        return new Article(
            _name ?? throw new ArgumentNullException(nameof(_name)),
            _author,
            _paragraphs);
    }
}