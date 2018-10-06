using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Aheng.CloudOpera.Core.Entities;
using Aheng.CloudOpera.Core.Interfaces;
using Aheng.CloudOpera.Core.Interfaces.Repositories;
using Aheng.CloudOpera.Infrastructure.Resources.Users;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;

namespace Aheng.CloudOpera.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserRepository _userRepository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public UserController(
            IUserRepository userRepository,
            IUnitOfWork unitOfWork,
            IMapper mapper)
        {
            _userRepository = userRepository;
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        // GET: api/User
        [HttpGet("{id}", Name = "Get")]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
        public async Task<ActionResult<User>> Get(Guid userId)
        {
            if(userId == Guid.Empty)
            {
                return BadRequest();
            }
            if(!_userRepository.TryGetUserByIdAsync(userId,out var user))
            {
                return NotFound();
            }

            return user;
        }

        // GET: api/Users/[5,6]
        [HttpGet]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
        public async Task<ActionResult<IEnumerable<UserResource>>> Get(IEnumerable<Guid> ids)
        {
            if(ids == null || ids.Count() == 0)
            {
                return BadRequest();
            }

            var users =await _userRepository.GetUsersAsync(ids);

            if(users.Count() != ids.Count())
            {
                return NotFound();
            }

            var usersResource = _mapper.Map<IEnumerable<UserResource>>(users);
            return usersResource.ToList();
        }

        // POST: api/User
        [HttpPost]
        [ProducesResponseType(201)]
        [ProducesResponseType(400)]
        public async Task<IActionResult> Post([FromBody] UserAddOrUpdateResource user)
        {
            if (user == null)
            {
                return BadRequest();
            }

            var userEntity = _mapper.Map<User>(user);
            _userRepository.AddUser(userEntity);

            if(await _unitOfWork.CompleteWorkAsync())
            {
                throw new Exception("Error occurred when adding");
            }

            return CreatedAtAction(nameof(Get), new { userId = userEntity.UserId }, userEntity);
        }

        // PUT: api/User/5
        [HttpPut("{id}")]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
        public async Task<IActionResult> Put(Guid userId, [FromBody] UserAddOrUpdateResource value)
        {
            if (value == null)
            {
                return BadRequest();
            }
            if (!ModelState.IsValid)
            {
                return new UnprocessableEntityObjectResult(ModelState);
            }

            var user = await _userRepository.GetUserByIdAsync(userId);
            if(user == null)
            {
                return NotFound();
            }

            _mapper.Map(value, user);

            if(!await _unitOfWork.CompleteWorkAsync())
            {
                throw new Exception($"Updating user {userId} failed when saving");
            }
            return NoContent();
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
        public async Task<IActionResult> Delete(Guid userId)
        {
            if(userId == Guid.Empty)
            {
                return BadRequest();
            }
            if(!_userRepository.TryGetUserByIdAsync(userId,out var user))
            {
                return NotFound();
            }

            _userRepository.DeleteUser(user);
            if(!await _unitOfWork.CompleteWorkAsync())
            {
                throw new Exception($"Error when deleting user: {userId}");
            }
            return NoContent();
        }
    }
}
