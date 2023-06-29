namespace CustomVisionPoc.Services
{
    public interface IMediaService
    {
        Task<FileResult> TakePhotoAsync();

        Task<FileResult> PickPhotoAsync();
    }
}
