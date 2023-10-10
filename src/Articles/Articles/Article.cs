using System.Text;
using Articles.Paragraphs;

namespace Articles.Articles;

public class Article : IArticle
{
    private readonly IRenderable _name;
    private readonly IRenderable? _author;
    private readonly IReadOnlyList<IParagraph> _paragraphs;

    public Article(
        IRenderable name,
        IRenderable? author,
        IEnumerable<IParagraph> paragraphs)
    {
        _name = name;
        _author = author;
        _paragraphs = paragraphs.ToArray();
    }

    public string Render()
    {
        var builder = new StringBuilder();

        builder.Append(_name.Render());

        if (_author is not null)
        {
            builder.Append('\n');
            builder.Append(_author.Render());
        }

        if (_paragraphs is not [])
        {
            builder.Append("\n\n\n");
            builder.AppendJoin("\n\n", _paragraphs.Select(x => x.Render()));
        }

        return builder.ToString();
    }

    public IArticleBuilder Direct(IArticleBuilder builder)
    {
        builder.WithName(_name);

        if (_author is not null)
            builder.WithAuthor(_author);

        foreach (var paragraph in _paragraphs)
        {
            builder.AddParagraph(paragraph);
        }

        return builder;
    }
}