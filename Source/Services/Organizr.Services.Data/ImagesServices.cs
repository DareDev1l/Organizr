namespace MvcTemplate.Services.Data
{
    using Organizr.Data.Common;
    using Organizr.Data.Models;

    public class ImagesServices : IImagesServices
    {
        private IDbRepository<Image> images;

        public ImagesServices(IDbRepository<Image> images)
        {
            this.images = images;
        }

        public void Create(Image image)
        {
            this.images.Add(image);
            this.images.Save();
        }
    }
}
