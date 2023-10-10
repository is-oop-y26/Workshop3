namespace Articles.Paragraphs.Builders;

public abstract class ParagraphBuilderBase : IParagraphTitleSelector, IParagraphBuilder
{
    private readonly List<IRenderable> _sections;
    private IRenderable? _title;
    private IRenderable? _footer;

    protected ParagraphBuilderBase()
    {
        _sections = new List<IRenderable>();
    }

    public IParagraphBuilder WithTitle(IRenderable renderable)
    {
        _title = renderable;
        return this;
    }

    public IParagraphBuilder AddSection(IRenderable renderable)
    {
        _sections.Add(renderable);
        return this;
    }

    public IParagraphBuilder WithFooter(IRenderable renderable)
    {
        _footer = renderable;
        return this;
    }

    public IParagraph Build()
    {
        return Create(
            _title ?? throw new ArgumentNullException(nameof(_title)),
            _sections,
            _footer);
    }

    protected abstract IParagraph Create(
        IRenderable title,
        IEnumerable<IRenderable> sections,
        IRenderable? footer);
}