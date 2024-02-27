using Android.Provider;

namespace GalleryApp.Services
{
    public partial class GalleryService
    {
        public partial List<string> GetAllImages()
        {
            List<string> imageDatas = new List<string>();
            string[] projections = { MediaStore.IMediaColumns.Data, MediaStore.Images.IImageColumns.BucketDisplayName };
            var imagecursor = Android.App.Application.Context.ContentResolver.Query(MediaStore.Images.Media.ExternalContentUri, projections, null, null, null);
            if (imagecursor == null || imagecursor.Count <= 0) return imageDatas;

            while (imagecursor.MoveToNext())
            {
                string data = imagecursor.GetString(imagecursor.GetColumnIndex(MediaStore.Images.ImageColumns.Data));
                imageDatas.Add(data);
            }
            imagecursor.Close();

            return imageDatas;
        }
    }
}