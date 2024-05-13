using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using TechBlog.Service.Services.Abstractions.Storage.Local;

namespace TechBlog.Service.Services.Concretes.Storage.Local
{
    public class LocalStorage : Storage, ILocalStorage
    {
        private readonly IWebHostEnvironment _webHostEnvironment;
        public LocalStorage(IWebHostEnvironment webHostEnvironment)
        {
            _webHostEnvironment = webHostEnvironment;
        }

        public async Task DeleteAsync(string path, string fileName)
            => await Task.Run(() =>
            {
                File.Delete($"{path}\\{fileName}");
            });

        public List<string> GetFiles(string path)
        {
            DirectoryInfo directory = new DirectoryInfo(path);
            return directory.GetFiles().Select(f => f.Name).ToList();
        }

        public bool HasFile(string path, string fileName)
            => File.Exists($"{path}\\{fileName}");

        public async Task<List<(string fileName, string pathOrContainerName)>> UploadAsync(string path, IFormFileCollection files)
        {
            // example path: wwwroot\\images\\article-images
            string uploadPath = Path.Combine(_webHostEnvironment.WebRootPath, path);
            if (!Directory.Exists(uploadPath))
                Directory.CreateDirectory(uploadPath);

            List<(string fileName, string path)> datas = new List<(string fileName, string path)>();
            foreach (IFormFile file in files)
            {
                string newFileName = await FileRenameAsync(uploadPath, file.FileName, HasFile);

                await CopyFileAsync($"{uploadPath}\\{newFileName}", file);
                datas.Add((newFileName, $"{path}\\{newFileName}"));
            }

            // todo : if the above if is not valid, a warning exception must be created and thrown stating that an error is received while loading as files as a result!
            return datas;
        }

        private async Task<bool> CopyFileAsync(string path, IFormFile file)
        {
            try
            {
                await using FileStream fileStream = new FileStream(path, FileMode.Create, FileAccess.Write, FileShare.None, 1024 * 1024, useAsync: false);
                await file.CopyToAsync(fileStream);
                await fileStream.FlushAsync();

                return true;
            }
            catch (Exception exc)
            {
                // todo: needing any log structure!
                throw exc;
            }
        }
    }
}
