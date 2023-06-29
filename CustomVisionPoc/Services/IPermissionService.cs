using static Microsoft.Maui.ApplicationModel.Permissions;

namespace CustomVisionPoc.Services
{
    public interface IPermissionService
    {
        Task<PermissionStatus> CheckAsync(BasePermission permissions, string permissionRequestRationaleMessage = null);

        Task<Dictionary<BasePermission, PermissionStatus>> CheckMultipleAsync(string permissionRequestRationaleMessage, params BasePermission[] permissions);

        Task<Dictionary<BasePermission, PermissionStatus>> CheckMultipleAsync(params BasePermission[] permissions);
    }
}
