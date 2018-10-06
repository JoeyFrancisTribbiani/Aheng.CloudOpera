using Aheng.CloudOpera.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Aheng.CloudOpera.Core.Interfaces.Repositories
{
    public interface IVideoRepository
    {
        Task<Video> GetVideoByIdAsync(Guid videoId);
        bool TryGetVideoById(Guid videoId,out Video video);
        Task<IEnumerable<Video>> GetVideosAsync(IEnumerable<Guid> videoIds);
        Task<IEnumerable<Video>> GetVideosByUserIdAsync(Guid userId);
        Task<bool> VideoExistAsync(Guid videoId);
        void AddVideo(Video video);
        void DeleteVideo(Video video);
        void UpdateVideo(Video video);
    }
}
