using static Microsoft.Maui.ApplicationModel.Permissions;

namespace CustomVisionPoc.Services
{
    public class PermissionService : IPermissionService
    {
        private readonly IDialogService dialogService;

        public PermissionService(IDialogService dialogService)
        {
            this.dialogService = dialogService;
        }

        public async Task<PermissionStatus> CheckAsync(BasePermission permissionType, string permissionRequestRationaleMessage = null)
        {
            var status = PermissionStatus.Denied;
            var results = await CheckMultipleAsync(permissionRequestRationaleMessage, permissionType);

            //Best practice to always check that the key exists
            if (results.ContainsKey(permissionType))
            {
                status = results[permissionType];
            }

            return status;
        }

        public Task<Dictionary<BasePermission, PermissionStatus>> CheckMultipleAsync(params BasePermission[] permissions)
            => CheckMultipleAsync(null, permissions);

        public async Task<Dictionary<BasePermission, PermissionStatus>> CheckMultipleAsync(string permissionRequestRationaleMessage, params BasePermission[] permissions)
        {
            var requestPermissions = false;
            var shouldShowRequestPermission = false;
            var results = new Dictionary<BasePermission, PermissionStatus>();

            // Checks the permission status for every permission.
            for (var i = 0; i < permissions.Length; i++)
            {
                var permissionType = permissions[i];
                var status = await permissionType.CheckStatusAsync();
                results[permissionType] = status;

                if (status != PermissionStatus.Granted)
                {
                    requestPermissions = true;
                    shouldShowRequestPermission |= permissionType.ShouldShowRationale();
                }
            }

            if (shouldShowRequestPermission)
            {
                await dialogService.ShowAlertAsync(permissionRequestRationaleMessage ?? "Authorize app permission to continue.", "", "Ok");
            }

            if (requestPermissions)
            {
                for (var i = 0; i < permissions.Length; i++)
                {
                    var permissionType = permissions[i];
                    var result = await permissionType.RequestAsync();
                    results.Add(permissionType, result);
                }
            }

            return results;
        }
    }
}
