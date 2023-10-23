using _1.API.Request;
using _1.API.Response;
using _2.Domain;
using _3.Data.Model;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;

namespace _1.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController :ControllerBase
    {
        private IUserData _tuserData;
        private IUserDomain _tUserDomain;
        private IMapper _mapper;
        public UserController(IUserData userData,IUserDomain userDomain,IMapper mapper)
        {
            _tuserData = userData;
            _tUserDomain = userDomain;
            _mapper = mapper;
        }
        // GET: api/Tutorial
        [HttpGet]
        public async Task<List<UserResponse>> GetAsync()
        {
            var tUsers= await _tuserData.GetAllAsync();
             
            var response = _mapper.Map<List<User>, List<UserResponse>>(tUsers);

            return response;
        }
        // GET: api/Tutorial/5
        [HttpGet("{id}", Name = "Get")]
        public  IActionResult Get(int id)
        {
            // todo esto devuelve la respuesata de userresponse
            
            User user = _tuserData.GetById(id);

            if (user == null)
            {
                return NotFound(); // Retorna un 404 si el usuario no se encuentra
            }

            UserResponse userResponse = _mapper.Map<UserResponse>(user);

            return Ok(userResponse); // Retorna un 200 (OK) con el objeto UserResponse
            
            // return _tuserData.GetById(id);
        }
        
        // POST: api/Tutorial
        [HttpPost]
        public IActionResult Post([FromBody] UserRequest request)
        {
            if (ModelState.IsValid)
            {

                var tutorial = _mapper.Map<UserRequest, User>(request);
               
                return Ok( _tUserDomain.Create(tutorial));
            }
            else
            {
                return BadRequest();
            }
           
        }
        // PUT: api/Tutorial/5
        [HttpPut("{id}")]
        public bool Put(int id, [FromBody] UserRequest request)
        {
            User users = new User()
            {
                Name = request.Name,
                Lastname = request.Lastname,
                Country = request.Country,
                phone = request.phone,
            };
           
           
            return _tUserDomain.Update(users,id);
        }
        // DELETE: api/Tutorial/5
        [HttpDelete("{id}")]
        public bool Delete(int id)
        {
            return _tUserDomain.Delete(id);
        }

    
    }
}
