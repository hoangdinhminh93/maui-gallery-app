using GalleryApp.Services;

namespace GalleryApp;

public partial class MainPage : ContentPage
{
	int count = 0;

	public MainPage()
	{
		InitializeComponent();
	}

    protected override void OnAppearing()
    {
        base.OnAppearing();
		GetAllGalleryImages();
    }

    private async void GetAllGalleryImages()
	{
        // Request storage permission
        if (await Permissions.CheckStatusAsync<Permissions.StorageRead>() != PermissionStatus.Granted)
        {
            await Permissions.RequestAsync<Permissions.StorageRead>();
        }

        // Get images
        var result = new GalleryService().GetAllImages();
        GalleryCollectionView.ItemsSource = result;
    }
}