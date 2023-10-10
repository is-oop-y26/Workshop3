namespace Articles.Extensions;

public static class TextExtensions
{
    public static T WithModifier<T>(
        this T text,
        IRenderableModifier modifier)
        where T : IText<T>
    {
        var clone = text.Clone();
        clone.AddModifier(modifier);

        return clone;
    }
}