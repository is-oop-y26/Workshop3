namespace Articles.Modifiers;

public class DimModifier : IRenderableModifier
{
    public string Modify(string value)
    {
        return Crayon.Output.Dim(value);
    }
}