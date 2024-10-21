using Media_API_project.Dtos;
using Media_API_project.Entities;
using Media_API_project.Repository.Interface;
using Media_API_project.Service.Interface;

namespace Media_API_project.Service.Implementation
{
    public class MediaService : IMediaService
    {
        private readonly IMediaRepository _mediaRepository;
        private readonly IWebHostEnvironment _environment;

        public MediaService(IMediaRepository mediaRepository, IWebHostEnvironment environment)
        {
            _mediaRepository = mediaRepository;
            _environment = environment;
        }


        public async Task<MediaResponseDto> UploadMediaAsync(IFormFile file)
        {
            
            var mediaFolderPath = Path.Combine(_environment.WebRootPath, "media");

            
            if (!Directory.Exists(mediaFolderPath))
            {
                Directory.CreateDirectory(mediaFolderPath);
            }

            
            var filePath = Path.Combine(mediaFolderPath, file.FileName);

            using (var stream = new FileStream(filePath, FileMode.Create))
            {
                await file.CopyToAsync(stream);
            }

            var media = new Media
            {
                Id = Guid.NewGuid(),
                FilePath = filePath,
                FileType = Path.GetExtension(file.FileName).ToLower(),
                UploadedAt = DateTime.UtcNow,
            };

            
            await _mediaRepository.AddMediaAsync(media);
            await _mediaRepository.SaveChangesAsync();

            
            return new MediaResponseDto
            {
                Id = media.Id,
                FilePath = media.FilePath,
                FileType = media.FileType,
                UploadedAt = media.UploadedAt
            };
        }

        /* public async Task<MediaResponseDto> UploadMediaAsync(IFormFile file)
         {
             var filePath = Path.Combine(_environment.WebRootPath, "media", file.FileName);
             using (var stream = new FileStream(filePath, FileMode.Create))
             {
                 await file.CopyToAsync(stream);
             }

             var media = new Media
             {
                 Id = Guid.NewGuid(),
                 FilePath = filePath,
                 FileType = Path.GetExtension(file.FileName).ToLower(),
                 UploadedAt = DateTime.UtcNow,
             };

             await _mediaRepository.AddMediaAsync(media);
             await _mediaRepository.SaveChangesAsync();

             return new MediaResponseDto
             {
                 Id = media.Id,
                 FilePath = media.FilePath,
                 FileType = media.FileType,
                 UploadedAt = media.UploadedAt
             };
         }*/

        public async Task<MediaResponseDto> DownloadMediaAsync(Guid id)
        {
            var media = await _mediaRepository.GetMediaByIdAsync(id);
            if (media == null)
            {
                throw new FileNotFoundException("Media not found");
            }

            return new MediaResponseDto
            {
                Id = media.Id,
                FilePath = media.FilePath,
                FileType = media.FileType,
                UploadedAt = media.UploadedAt
            };
        }

        public async Task<IEnumerable<MediaResponseDto>> GetAllMediaAsync()
        {
            var mediaList = await _mediaRepository.GetAllMediaAsync();
            return mediaList.Select(media => new MediaResponseDto
            {
                Id = media.Id,
                FilePath = media.FilePath,
                FileType = media.FileType,
                UploadedAt = media.UploadedAt
            }).ToList();
        }

        public async Task DeleteMediaAsync(Guid id)
        {
            await _mediaRepository.DeleteMediaAsync(id);
            await _mediaRepository.SaveChangesAsync();
        }
    }
}
