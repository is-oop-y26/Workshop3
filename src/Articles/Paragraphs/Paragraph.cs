using System.Text;

namespace Articles.Paragraphs;

public class Paragraph : IParagraph
{
    private readonly IRenderable _title;
    private readonly IReadOnlyList<IRenderable> _sections;
    private readonly IRenderable? _footer;

    public Paragraph(
        IRenderable title,
        IEnumerable<IRenderable> sections,
        IRenderable? footer)
    {
        _title = title;
        _sections = sections.ToArray();
        _footer = footer;
    }

    public string Render()
    {
        var builder = new StringBuilder();

        builder.Append(_title.Render());

        if (_sections is not [])
        {
            builder.Append('\n');
            builder.AppendJoin('\n', _sections.Select(x => x.Render()));
        }

        if (_footer is not null)
        {
            builder.Append('\n');
            builder.Append(_footer.Render());
        }

        return builder.ToString();
    }
}