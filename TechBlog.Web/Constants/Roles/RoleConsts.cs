namespace TechBlog.Web.Constants.Roles
{
    public static class RoleConsts
    {
        public const string User = "User";
        public const string Admin = "Admin";
        public const string Superadmin = "Superadmin";
        private const string FullAccess = $"{Superadmin}, {Admin}, {User}";
    }
}
