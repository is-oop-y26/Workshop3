namespace Articles.Modifiers;

public class BoldModifier : IRenderableModifier
{
    public string Modify(string value)
    {
        return Crayon.Output.Bold(value);
    }
}