namespace BookAdict.Interfaces
{
    public interface IImageServices
    {
        public string SetImage(IFormFile newImgFile);
        public string EditImage(IFormFile newImgFile, string OldImgUrl);

        public string HandleGetImgUrl(string normalImgUrl);
        public void DeleteImage(string OldImgUrl);
    }
}
