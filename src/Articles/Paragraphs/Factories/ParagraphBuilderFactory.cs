using Articles.Paragraphs.Builders;

namespace Articles.Paragraphs.Factories;

public class ParagraphBuilderFactory : IParagraphBuilderFactory
{
    public IParagraphTitleSelector Create()
    {
        return new ParagraphBuilder();
    }
}