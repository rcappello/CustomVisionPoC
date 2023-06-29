namespace CustomVisionPoc.Services
{
    public interface IPermissionService
    {
        Task<PermissionStatus> CheckPermissions<TPermission>(string permissionRequestRationaleMessage = null) where TPermission : Permissions.BasePermission, new();
    }
}
