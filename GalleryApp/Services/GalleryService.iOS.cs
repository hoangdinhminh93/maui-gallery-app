using AssetsLibrary;
using Foundation;
using Photos;
using UIKit;

namespace GalleryApp.Services
{
    public partial class GalleryService
    {
        public partial List<string> GetAllImages()
        {
            List<string> imageDatas = new List<string>();

            PHImageRequestOptions options = new PHImageRequestOptions();
            options.ResizeMode = PHImageRequestOptionsResizeMode.Fast;
            options.DeliveryMode = PHImageRequestOptionsDeliveryMode.FastFormat;
            options.Synchronous = true;

            var assets = PHAsset.FetchAssets(PHAssetMediaType.Image, null);
            PHImageManager manager = new PHImageManager();

            List<UIImage> images = new List<UIImage>();
            foreach (PHAsset asset in assets)
            {
                manager.RequestImageForAsset(asset, PHImageManager.MaximumSize, PHImageContentMode.Default, options,
                                            (image, info) =>
                                            {
                                                images.Add(image);
                                            });
            }

            return imageDatas;
        }
    }
}