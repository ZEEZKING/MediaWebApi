using Media_API_project.Entities;
using Media_API_project.Entities.ApplicationDBContext;
using Media_API_project.Repository.Interface;
using Microsoft.EntityFrameworkCore;
using System;

namespace Media_API_project.Repository.Implementation
{
    public class MediaRepository : IMediaRepository
    {
        private readonly ApplicationDbContext _context;

        public MediaRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task AddMediaAsync(Media media)
        {
            await _context.Media.AddAsync(media);
        }

        public async Task DeleteMediaAsync(Guid id)
        {
            var media = await _context.Media.FindAsync(id);
            if (media != null)
            {
                _context.Media.Remove(media);
            }
        }

        public async Task<IEnumerable<Media>> GetAllMediaAsync()
        {
          return await _context.Media.ToListAsync();
        }

        public async Task<Media> GetMediaByIdAsync(Guid id)
        {
            return await _context.Media.FindAsync(id);
        }

        public async Task SaveChangesAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}
