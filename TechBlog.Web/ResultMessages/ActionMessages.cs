namespace TechBlog.Web.ResultMessages
{
    public static class ActionMessages
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
            public static string UndoDelete(string articleTitle)
            {
                return $"Article with title: {articleTitle} has been successfully undo from deleted articles.";
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
            public static string UndoDelete(string categoryName)
            {
                return $"Category with title: {categoryName} has been successfully undo from deleted categories.";
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

        public static class UserProfile
        {
            public static string SuccessfullyUpdate()
            {
                return "The profile update process has been completed successfully.";
            }
            public static string UnsuccessfullyUpdate()
            {
                return "An error occurred while updating the profile.";
            }
        }

        public static class GeneralHomePageData
        {
            public static string FruitlessSearch()
            {
                return "No articles were found as a result of your search! You can continue searching on the home page.";
            }
        }
    }
}
