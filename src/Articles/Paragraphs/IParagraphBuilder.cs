namespace Articles.Paragraphs;

public interface IParagraphTitleSelector
{
    IParagraphBuilder WithTitle(IRenderable renderable);
}

public interface IParagraphBuilder
{
    IParagraphBuilder AddSection(IRenderable renderable);

    IParagraphBuilder WithFooter(IRenderable renderable);

    IParagraph Build();
}