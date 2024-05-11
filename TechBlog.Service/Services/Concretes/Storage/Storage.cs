using TechBlog.Service.Operations;

namespace TechBlog.Service.Services.Concretes.Storage
{
    public class Storage
    {
        protected delegate bool HasFile(string pathOrContainer, string fileName);

        protected async Task<string> FileRenameAsync(string pathOrContainer, string fileName, HasFile hasFileDelegate)
        {
            return await Task.Run(() =>
            {
                string oldName = Path.GetFileNameWithoutExtension(fileName);
                string extension = Path.GetExtension(fileName);
                string newFileName = $"{NameOperation.CharacterRegulatory(oldName)}{extension}";

                int fileIndex = 1;
                while (hasFileDelegate(pathOrContainer, newFileName))
                {
                    fileIndex++;
                    newFileName = $"{NameOperation.CharacterRegulatory(oldName)}-{fileIndex}{extension}";
                }

                return newFileName;
            });
        }
    }
}
