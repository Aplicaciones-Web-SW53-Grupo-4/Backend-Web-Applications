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
        public ProfileController(IUserData userData,IUserDomain userDomain,IMapper mapper)
        {
            _tuserData = userData;
            _tUserDomain = userDomain;
            _mapper = mapper;
        }
        
        // GET: api/profile/id
        [HttpGet("{id}", Name = "Get")]
        public IActionResult Get(int id)
        {
            User user = _tuserData.GetById(id);
                
            if (user == null)
            {
                return NotFound(); 
            }
            if(user.UserType== UserType.Arrendatario)
            {
                ProfileResponseOwner profileResponseOwner = _mapper.Map<ProfileResponseOwner>(user);
                return Ok(profileResponseOwner);
            }
            else
            {
                ProfileResponseOwner profileResponseOwner = _mapper.Map<ProfileResponseOwner>(user);
                return Ok(profileResponseOwner);
            }
            
        }

        // PUT: api/profile/id
        [HttpPut("{id}")]
        public bool Put(int id, [FromBody] ProfileUpdateRequest request)
        {
            var users = _mapper.Map<ProfileUpdateRequest, User>(request);
           
            return _tUserDomain.Update(users,id);
        }
        
    }
}
