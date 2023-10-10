namespace Articles.Renderables;

public class Text : IText<Text>
{
    private readonly List<IRenderableModifier> _modifiers;

    public Text(string content)
    {
        Content = content;
        _modifiers = new List<IRenderableModifier>();
    }

    public Text(
        string content,
        IEnumerable<IRenderableModifier> modifiers)
    {
        Content = content;
        _modifiers = modifiers.ToList();
    }

    public string Content { get; set; }

    public string Render()
    {
        return _modifiers.Aggregate(
            Content,
            (c, m) => m.Modify(c));
    }

    public Text Clone()
    {
        return new Text(Content, _modifiers);
    }

    public Text AddModifier(IRenderableModifier modifier)
    {
        _modifiers.Add(modifier);
        return this;
    }
}