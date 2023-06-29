namespace CustomVisionPoc.Services
{
    public class PermissionService : IPermissionService
    {
        private readonly IDialogService dialogService;

        public PermissionService(IDialogService dialogService)
        {
            this.dialogService = dialogService;
        }

        public async Task<PermissionStatus> CheckPermissions<TPermission>(string permissionRequestRationaleMessage = null) where TPermission : Permissions.BasePermission, new()
        {
            PermissionStatus status = await Permissions.CheckStatusAsync<TPermission>();

            if (status != PermissionStatus.Granted)
            {
                status = await Permissions.RequestAsync<TPermission>();

                if (Permissions.ShouldShowRationale<TPermission>())
                {
                    await dialogService.ShowAlertAsync(permissionRequestRationaleMessage ?? "Authorize app permission to continue.", "", "Ok");
                }
            }

            return status;
        }

        public static bool IsGranted(PermissionStatus status)
        {
            return status == PermissionStatus.Granted || status == PermissionStatus.Limited;
        }
    }
}
