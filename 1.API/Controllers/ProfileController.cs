using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using _1.API.Request;
using _1.API.Response;
using _2.Domain;
using _3.Data.Model;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace _1.API.Controllers
{
    /// <summary>
    /// Controller for managing user profiles.
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class ProfileController : ControllerBase
    {
        private IUserData _tuserData;
        private IUserDomain _tUserDomain;
        private IMapper _mapper;

        public ProfileController(IUserData userData, IUserDomain userDomain, IMapper mapper)
        {
            _tuserData = userData;
            _tUserDomain = userDomain;
            _mapper = mapper;
        }
        
        // Summary: Retrieves a user profile by ID.
        /// <summary>
        /// Retrieves a user profile by ID.
        /// </summary>
        [HttpGet("{id}", Name = "Get")]
        public IActionResult Get(int id)
        {
            User user = _tuserData.GetById(id);
                
            if (user == null)
            {
                return NotFound(); 
            }

            if (user.UserType == UserType.Arrendatario)
            {
                // TODO: Change the name of the class
                ProfileResponseOwner profileResponseOwner = _mapper.Map<ProfileResponseOwner>(user);
                return Ok(profileResponseOwner);
            }
            else
            {
                ProfileResponseOwner profileResponseOwner = _mapper.Map<ProfileResponseOwner>(user);
                return Ok(profileResponseOwner);
            }
            
        }

        // Summary: Updates a user profile by ID.
        /// <summary>
        /// Updates a user profile by ID.
        /// </summary>
        [HttpPut("{id}")]
        public bool Put(int id, [FromBody] ProfileUpdateRequest request)
        {
            var users = _mapper.Map<ProfileUpdateRequest, User>(request);
           
            return _tUserDomain.Update(users, id);
        }
        
    }
}