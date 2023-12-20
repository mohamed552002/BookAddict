namespace BookAdict.Interfaces
{
    public interface IImageServices
    {
        public string SetImage(IFormFile newImgFile, string OldImgUrl=null);
    }
}
