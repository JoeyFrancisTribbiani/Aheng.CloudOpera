using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Aheng.CloudOpera.Core.Entities;
using Aheng.CloudOpera.Core.Interfaces;
using Aheng.CloudOpera.Core.Interfaces.Repositories;
using Aheng.CloudOpera.Infrastructure.Resources.Videos;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.Internal;
using Microsoft.AspNetCore.Mvc;

namespace Aheng.CloudOpera.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VideoController : ControllerBase
    {
        private readonly IUserRepository _userRepository;
        private readonly IVideoRepository _videoRepository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly IVedioFileServer _vedioFileServer;

        public VideoController(
            IUserRepository userRepository,
            IVideoRepository videoRepository,
            IUnitOfWork unitOfWork,
            IMapper mapper,
            IVedioFileServer vedioFileServer)
        {
            _userRepository = userRepository;
            _videoRepository = videoRepository;
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _vedioFileServer = vedioFileServer;
        }
        // GET: api/Video
        [HttpGet("{id}", Name = "Get")]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
        public ActionResult<Video> Get(Guid videoId)
        {
            if(videoId == Guid.Empty)
            {
                return BadRequest();
            }
            if(!_videoRepository.TryGetVideoById(videoId,out var video))
            {
                return NotFound();
            }

            return video;
        }

        // GET: api/Videos/[5,6]
        [HttpGet]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
        public async Task<ActionResult<IEnumerable<VideoResource>>> Get(IEnumerable<Guid> ids)
        {
            if(ids == null || ids.Count() == 0)
            {
                return BadRequest();
            }

            var videos =await _videoRepository.GetVideosAsync(ids);

            if(videos.Count() != ids.Count())
            {
                return NotFound();
            }

            var videosResource = _mapper.Map<IEnumerable<VideoResource>>(videos);
            return videosResource.ToList();
        }

        // POST: api/Video
        [HttpPost]
        [ProducesResponseType(201)]
        [ProducesResponseType(400)]
        public async Task<IActionResult> Post([FromBody] VideoAddOrUpdateResource video)
        {
            if (video == null)
            {
                return BadRequest();
            }

            var videoEntity = _mapper.Map<Video>(video);
            _videoRepository.AddVideo(videoEntity);

            if(await _unitOfWork.CompleteWorkAsync())
            {
                throw new Exception("Error occurred when adding");
            }

            return CreatedAtAction(nameof(Get), new { videoId = videoEntity.VideoId }, videoEntity);
        }

        // PUT: api/Video/5
        [HttpPut("{id}")]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
        public async Task<IActionResult> Put(Guid videoId, [FromBody] VideoAddOrUpdateResource value)
        {
            if (value == null)
            {
                return BadRequest();
            }
            if (!ModelState.IsValid)
            {
                return new UnprocessableEntityObjectResult(ModelState);
            }

            if(!_videoRepository.TryGetVideoById(videoId,out var video))
            {
                return NotFound();
            }

            _mapper.Map(value, video);

            if(!await _unitOfWork.CompleteWorkAsync())
            {
                throw new Exception($"Updating video {videoId} failed when saving");
            }
            return NoContent();
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
        public async Task<IActionResult> Delete(Guid videoId)
        {
            if(videoId == Guid.Empty)
            {
                return BadRequest();
            }
            if(!_videoRepository.TryGetVideoById(videoId,out var video))
            {
                return NotFound();
            }

            _videoRepository.DeleteVideo(video);
            if(!await _unitOfWork.CompleteWorkAsync())
            {
                throw new Exception($"Error when deleting video: {videoId}");
            }
            return NoContent();
        }

        public async Task<IActionResult> Upload(Guid userId,FormFile file)
        {
            if(file == null)
            {
                return BadRequest("文件未上传");
            }
            User user;
            if(!_userRepository.TryGetUserById(userId,out user))
            {
                return NotFound();
            }

            var path = await _vedioFileServer.Upload(user.UserId, file);
            if (string.IsNullOrEmpty(path))
            {
                HttpContext.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
                return null;
            }

            return Ok(path);
        }
    }
}
