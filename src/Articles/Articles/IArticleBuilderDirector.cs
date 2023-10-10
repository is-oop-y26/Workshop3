namespace Articles.Articles;

public interface IArticleBuilderDirector
{
    IArticleBuilder Direct(IArticleBuilder builder);
}