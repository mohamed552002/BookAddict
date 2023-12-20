using BookAdict.Interfaces;

namespace BookAdict.Services
{
    public class ImageService : IImageServices
    {
        private const string NoImagePath = "\\Images\\No_Image.png";
        private const string ImageFolderPath = "\\Images\\";
        private readonly IWebHostEnvironment _env;

        public ImageService(IWebHostEnvironment env)
        {
            _env = env;
        }

        public string SetImage(IFormFile newImgFile, string OldImgUrl=null)
        {

            if (newImgFile == null && OldImgUrl == null)
            {
                return NoImagePath;
            }
            else
            {
                if (OldImgUrl != null)
                    DeleteImage(OldImgUrl ?? null);
                var imgGuid = Guid.NewGuid();
                string imgExtension = Path.GetExtension(newImgFile.FileName);
                string newImgName = imgGuid + imgExtension;
                string newImgUrl = ImageFolderPath + newImgName;
                string newImgPath = _env.WebRootPath + newImgUrl;
                using var imgStream = new FileStream(newImgPath, FileMode.Create);
                newImgFile.CopyTo(imgStream);
                return newImgUrl;
            }

        }
        public void DeleteImage(string OldImgUrl)
        {
            if(!string.IsNullOrEmpty(OldImgUrl) || OldImgUrl != NoImagePath)
            {
                var OldImagePath = _env.WebRootPath + OldImgUrl;
                if(File.Exists(OldImagePath))
                {
                    File.Delete(OldImagePath);
                }
            }
        }
    }
}
