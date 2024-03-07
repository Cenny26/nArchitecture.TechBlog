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
    }
}
