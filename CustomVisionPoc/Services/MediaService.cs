namespace CustomVisionPoc.Services
{
    public class MediaService : IMediaService
    {
        private readonly IPermissionService permissionService;

        public MediaService(IPermissionService permissionService)
        {
            //media = CrossMedia.Current;
            this.permissionService = permissionService;
        }

        public async Task<FileResult> TakePhotoAsync()
        {
            var cameraPermissions = await permissionService.CheckPermissions<Permissions.Camera>();
            var storagePermission = await permissionService.CheckPermissions<Permissions.StorageWrite>();
            if (PermissionService.IsGranted(cameraPermissions) && PermissionService.IsGranted(storagePermission))
            {
                if (MediaPicker.Default.IsCaptureSupported)
                {
                    // Take a photo using the camera.
                    var file = await MediaPicker.Default.CapturePhotoAsync(new MediaPickerOptions
                    {
                        //SaveToAlbum = false,
                        //PhotoSize = PhotoSize.MaxWidthHeight,
                        //AllowCropping = false,
                        //MaxWidthHeight = 1920,
                        //CompressionQuality = 85
                    });

                    return file;
                }
            }

            return null;
        }

        public async Task<FileResult> PickPhotoAsync()
        {
            var photosPermissions = await permissionService.CheckPermissions<Permissions.Photos>();
            var storagePermission = await permissionService.CheckPermissions<Permissions.StorageRead>();
            if (PermissionService.IsGranted(photosPermissions) && PermissionService.IsGranted(storagePermission))
            {
                // Pick a photo from the gallery.
                var file = await MediaPicker.Default.PickPhotoAsync(new MediaPickerOptions
                {
                    //PhotoSize = PhotoSize.MaxWidthHeight,
                    //MaxWidthHeight = 1920,
                    //CompressionQuality = 85
                });

                return file;
            }

            return null;
        }
    }
}
