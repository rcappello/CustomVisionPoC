namespace CustomVisionPoc.Services
{
    public class MediaService : IMediaService
    {
        private readonly IPermissionService permissionService;

        public MediaService(IPermissionService permissionService)
        {
            this.permissionService = permissionService;
        }

        public async Task<FileResult> TakePhotoAsync()
        {
            var cameraPermissions = await permissionService.CheckPermissions<Permissions.Camera>();
            if (!PermissionService.IsGranted(cameraPermissions)) return null;
            if (!MediaPicker.Default.IsCaptureSupported) return null;

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

        public async Task<FileResult> PickPhotoAsync()
        {
            var photosPermissions = await permissionService.CheckPermissions<Permissions.Photos>();
            var mediaPermission = await permissionService.CheckPermissions<Permissions.Media>();
            if (!PermissionService.IsGranted(photosPermissions) ||
                !PermissionService.IsGranted(mediaPermission))
                return null;

            // Pick a photo from the gallery.
            var file = await MediaPicker.Default.PickPhotoAsync(new MediaPickerOptions
            {
                //PhotoSize = PhotoSize.MaxWidthHeight,
                //MaxWidthHeight = 1920,
                //CompressionQuality = 85
            });

            return file;
        }
    }
}
