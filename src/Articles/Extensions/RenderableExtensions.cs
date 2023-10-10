using Articles.Renderables;

namespace Articles.Extensions;

public static class RenderableExtensions
{
    public static IRenderable WithModifier(
        this IRenderable renderable,
        IRenderableModifier modifier)
    {
        return new ModifierRenderable(renderable, modifier);
    }
}