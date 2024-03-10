namespace TechBlog.Web.ResultMessages
{
    public static class Messages
    {
        public static class Article
        {
            public static string Add(string articleTitle)
            {
                return $"Article titled {articleTitle} has been added successfully.";
            }
            public static string Update(string articleTitle)
            {
                return $"Article titled {articleTitle} has been updated successfully.";
            }
            public static string Delete(string articleTitle)
            {
                return $"Article titled {articleTitle} has been deleted successfully.";
            }
        }

        public static class Category
        {
            public static string Add(string categoryName)
            {
                return $"Category titled {categoryName} has been added successfully.";
            }
            public static string Update(string categoryName)
            {
                return $"Category titled {categoryName} has been updated successfully.";
            }
            public static string Delete(string categoryName)
            {
                return $"Category titled {categoryName} has been deleted successfully.";
            }
        }
    }
}
