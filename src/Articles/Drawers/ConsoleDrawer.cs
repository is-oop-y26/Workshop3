namespace Articles.Drawers;

public class ConsoleDrawer : IDrawer
{
    public void Draw(IRenderable renderable)
    {
        var value = renderable.Render();
        Console.WriteLine(value);
    }
}