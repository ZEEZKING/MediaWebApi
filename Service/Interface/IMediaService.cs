using Media_API_project.Dtos;

namespace Media_API_project.Service.Interface
{
    public interface IMediaService
    {
        Task<MediaResponseDto> UploadMediaAsync(IFormFile file);
        Task<MediaResponseDto> DownloadMediaAsync(Guid id);
        Task<IEnumerable<MediaResponseDto>> GetAllMediaAsync();
        Task DeleteMediaAsync(Guid id);

    }
}
