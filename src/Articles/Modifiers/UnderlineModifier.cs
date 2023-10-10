namespace Articles.Modifiers;

public class UnderlineModifier : IRenderableModifier
{
    public string Modify(string value)
    {
        return Crayon.Output.Underline(value);
    }
}