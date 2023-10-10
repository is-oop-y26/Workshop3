namespace Articles;

public interface IText<out T> : IRenderable where T : IText<T>
{
    T Clone();

    T AddModifier(IRenderableModifier modifier);
}