using Aheng.CloudOpera.Core.Entities;
using Aheng.CloudOpera.Core.Interfaces.Repositories;
using Aheng.CloudOpera.Infrastructrue.DataBase;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aheng.CloudOpera.Infrastructrue.Repositories
{
    public class VideoRepository : IVideoRepository
    {
        private readonly OperaContext _operaContext;
        public VideoRepository(OperaContext operaContext)
        {
            _operaContext = operaContext;
        }

        public void AddVideo(Video video)
        {
            _operaContext.Videos.Add(video);
        }

        public void DeleteVideo(Video video)
        {
            _operaContext.Videos.Remove(video);
        }

        public Task<Video> GetVideoByIdAsync(Guid videoId)
        {
            return _operaContext.Videos.FindAsync(videoId);
        }

        public Task<IEnumerable<Video>> GetVideosAsync(string jsonCondition)
        {
            //todo
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<Video>> GetVideosAsync(IEnumerable<Guid> videoIds)
        {
            return await _operaContext.Videos.Where(v => videoIds.Contains(v.VideoId)).ToListAsync();
        }

        public async Task<IEnumerable<Video>> GetVideosByUserIdAsync(Guid userId)
        {
            return await _operaContext.Videos.Where(v => v.OwnerId == userId).ToListAsync();
        }

        public bool TryGetVideoById(Guid videoId, out Video video)
        {
            throw new NotImplementedException();
        }

        public bool TryGetVideoByIdAsync(Guid videoId, out Video video)
        {
            video =_operaContext.Videos.Find(videoId);
            return video == null;
        }

        public void UpdateVideo(Video video)
        {
            _operaContext.Videos.Update(video);
        }

        public void VideoExist(Video video)
        {
            _operaContext.Videos.Remove(video);
        }

        public async Task<bool> VideoExistAsync(Guid videoId)
        {
            return await _operaContext.Videos.AnyAsync(v => v.VideoId == videoId);
        }

    }
}
