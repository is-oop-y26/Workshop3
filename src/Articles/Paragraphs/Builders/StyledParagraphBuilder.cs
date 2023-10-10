using System.Drawing;
using Articles.Extensions;
using Articles.Modifiers;

namespace Articles.Paragraphs.Builders;

public class StyledParagraphBuilder : ParagraphBuilderBase
{
    private readonly Color _titleColor;

    public StyledParagraphBuilder(Color titleColor)
    {
        _titleColor = titleColor;
    }

    protected override IParagraph Create(
        IRenderable title,
        IEnumerable<IRenderable> sections,
        IRenderable? footer)
    {
        return new Paragraph(
            title.WithModifier(new ColorModifier(_titleColor)),
            sections,
            footer);
    }
}