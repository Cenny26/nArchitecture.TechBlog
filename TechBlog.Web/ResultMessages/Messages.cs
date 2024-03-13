namespace TechBlog.Web.ResultMessages
{
    public static class Messages
    {
        public static class Article
        {
            public static string Add(string articleTitle)
            {
                return $"Article with title: {articleTitle} has been added successfully.";
            }
            public static string Update(string articleTitle)
            {
                return $"Article with title: {articleTitle} has been updated successfully.";
            }
            public static string Delete(string articleTitle)
            {
                return $"Article with title: {articleTitle} has been deleted successfully.";
            }
        }

        public static class Category
        {
            public static string Add(string categoryName)
            {
                return $"Category with title: {categoryName} has been added successfully.";
            }
            public static string Update(string categoryName)
            {
                return $"Category with title: {categoryName} has been updated successfully.";
            }
            public static string Delete(string categoryName)
            {
                return $"Category with title: {categoryName} has been deleted successfully.";
            }
        }

        public static class User
        {
            public static string Add(string userName)
            {
                return $"User with email: {userName} has been added successfully.";
            }
            public static string Update(string userName)
            {
                return $"User with email: {userName} has been updated successfully.";
            }
            public static string Delete(string userName)
            {
                return $"User with email: {userName} has been deleted successfully.";
            }
        }
    }
}
