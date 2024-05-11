namespace TechBlog.Service.Operations
{
    public static class NameOperation
    {
        // todo: it is necessary to guarantee that the names of the file(s) received by the client contain letters of the private alphabet.
        public static string CharacterRegulatory(string name)
        => name.Replace("\"", "")
                .Replace("/", "")
                .Replace(@"\", "")
                .Replace("!", "")
                .Replace("'", "")
                .Replace("^", "")
                .Replace("+", "")
                .Replace("%", "")
                .Replace("&", "")
                .Replace("#", "")
                .Replace("$", "")
                .Replace("*", "")
                .Replace("æ", "")
                .Replace("ß", "")
                .Replace("(", "")
                .Replace(")", "")
                .Replace("½", "")
                .Replace("{", "")
                .Replace("[", "")
                .Replace("]", "")
                .Replace("}", "")
                .Replace("=", "")
                .Replace("?", "")
                .Replace("_", "")
                .Replace(" ", "-")
                .Replace("@", "")
                .Replace("€", "")
                .Replace("¨", "")
                .Replace("~", "")
                .Replace(",", "")
                .Replace(";", "")
                .Replace(":", "")
                .Replace(".", "")
                .Replace("<", "")
                .Replace(">", "")
                .Replace("|", "");
    }
}
