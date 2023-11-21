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
    [Route("api/[controller]")]
    [ApiController]
    public class ProfileController : ControllerBase
    {
        private IUserData _tuserData;
        private IUserDomain _tUserDomain;
        private IMapper _mapper;

        // Constructor injection of necessary services and dependencies
        public ProfileController(IUserData userData, IUserDomain userDomain, IMapper mapper)
        {
            _tuserData = userData;
            _tUserDomain = userDomain;
            _mapper = mapper;
        }
        
        // GET: api/profile/id
        /// <summary>
        /// Retrieves a user profile by ID.
        /// </summary>
        [HttpGet("{id}", Name = "Get")]
        [Produces("application/json")]
        public IActionResult Get(string id)
        {
            // Retrieve user data based on the provided ID
            User user = _tuserData.GetById(id);
                
            // Check if the user exists
            if (user == null)
            {
                return NotFound(); 
            }
            // Map the user to a specific profile response based on the user type
            if(user.UserType == UserType.Arrendatario)
            {
                ProfileOwnerResponse profileOwnerResponse = _mapper.Map< ProfileOwnerResponse>(user);
                return Ok(profileOwnerResponse);
            }
            else
            {
                ProfileOwnerResponse profileOwnerResponse= _mapper.Map< ProfileOwnerResponse>(user);
                return Ok(profileOwnerResponse);
            }
        }

        // PUT: api/profile/id
        /// <summary>
        /// Updates a user profile by ID.
        /// </summary>
        [HttpPut("{id}")]
        public bool Put(string id, [FromBody] ProfileUpdateRequest request)
        {
            // Map the update request data to the User model
            var users = _mapper.Map<ProfileUpdateRequest, User>(request);
           
            // Update the user profile with the new data
            return _tUserDomain.Update(users, id);
        }
        
    }
}