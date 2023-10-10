using System.Drawing;
using Articles.Paragraphs.Builders;

namespace Articles.Paragraphs.Factories;

public class StyledParagraphBuilderFactory : IParagraphBuilderFactory
{
    private readonly Color _titleColor;

    public StyledParagraphBuilderFactory(Color titleColor)
    {
        _titleColor = titleColor;
    }

    public IParagraphTitleSelector Create()
    {
        return new StyledParagraphBuilder(_titleColor);
    }
}