using Media_API_project.Entities;

namespace Media_API_project.Repository.Interface
{
    public interface IMediaRepository
    {
        Task<Media> GetMediaByIdAsync(Guid id);
        Task<IEnumerable<Media>> GetAllMediaAsync();
        Task AddMediaAsync(Media media);
        Task DeleteMediaAsync(Guid id);
        Task SaveChangesAsync();
    }
}
