namespace Articles.Paragraphs.Builders;

public class ParagraphBuilder : ParagraphBuilderBase
{
    protected override IParagraph Create(
        IRenderable title,
        IEnumerable<IRenderable> sections,
        IRenderable? footer)
    {
        return new Paragraph(title, sections, footer);
    }
}