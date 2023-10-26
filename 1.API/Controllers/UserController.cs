using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using _1.API.Request;
using _1.API.Response;
using _2.Domain;
using _3.Data.Model;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;

namespace _1.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
   
    public class UserController :ControllerBase
    {
        private IUserData _tuserData;
        private IUserDomain _tUserDomain;
        private IMapper _mapper;
        private IConfiguration _configuration;
        public UserController(IUserData userData,IUserDomain userDomain,IMapper mapper,IConfiguration configuration)
        {
            _tuserData = userData;
            _tUserDomain = userDomain;
            _mapper = mapper;
            _configuration = configuration;
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
        // [Authorize]
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
        
        
        // POST: api/register  Acción para registrar usuario
        [HttpPost("register")]
        
        public IActionResult Register([FromBody] UserRegisterRequest request)
        {
            if (ModelState.IsValid)
            {
                var user = _mapper.Map<UserRegisterRequest, User>(request);

                // user.UserType = UserType.Normal; // Configura el tipo de usuario

                if (_tUserDomain.Create(user))
                {
                    // Registro exitoso, devuelve una respuesta 201 Created con la ubicación del nuevo usuario
                    return CreatedAtAction("Get", new { id = user.Id }, user);
                }
                else
                {
                    // El usuario ya existe o hubo un error en el registro, devuelve una respuesta 400 Bad Request
                    return BadRequest("No se pudo registrar el usuario.");
                }
            }
            else
            {
                // Datos de registro no válidos, devuelve una respuesta 400 Bad Request con detalles de validación
                return BadRequest(ModelState);
            }
        }
        // POST: api/login Acción para iniciar sesión y generar un token JWT
        [HttpPost("login")]
       
        public IActionResult Login([FromBody] UserLoginRequest request)
        {
            var user = _tUserDomain.Authenticate(request.Username, request.Password);

            if (user != null)
            {
                var token = GenerateJwtToken(user);
                return Ok(new { Token = token });
            }
            else
            {
                return Unauthorized("Credenciales inválidas");
            }
        }

        private string GenerateJwtToken(User user)
        {
            var securityKey = new SymmetricSecurityKey (Encoding.UTF8.GetBytes(_configuration["Jwt:Key"]));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

            var claims = new[]
            {
                new Claim(ClaimTypes.Name, user.username),
                // Puedes agregar más claims según tus necesidades
            };

            var token = new JwtSecurityToken(
                issuer: _configuration["Jwt:Issuer"],
                audience: _configuration["Jwt:Audience"],
                claims: claims,
                expires: DateTime.Now.AddMinutes(int.Parse(_configuration["Jwt:DurationInMinutes"])),
                signingCredentials: credentials
            );

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
      
        
        
        
        // POST: api/Tutorial
        [HttpPost]
        public IActionResult Post([FromBody] UserRequest request)
        {
            if (ModelState.IsValid)
            {

                var users = _mapper.Map<UserRequest, User>(request);
               
                return Ok( _tUserDomain.Create(users));
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
