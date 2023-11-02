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
       
        
        // POST: api/user/register
        [HttpPost("register")]
        
        public IActionResult Register([FromBody] UserRegisterRequest request)
        {
            Console.WriteLine(request);
            if (ModelState.IsValid)
            {
                var user = _mapper.Map<UserRegisterRequest, User>(request);
                if (_tUserDomain.Create(user))
                {
                    // Successful registration, returns a 201 Created response with the location of the new user
                    return Ok("El usuario se registró correctamente.");
                }
                else
                {
                    // The user already exists or there was an error in the registration, returns a 400 Bad Request response
                    return BadRequest("No se pudo registrar el usuario.");
                }
            }
            else
            {
                // Invalid registration data, returns a 400 Bad Request response with validation details
                var errors = ModelState.Values.SelectMany(v => v.Errors)
                    .Select(e => e.ErrorMessage).ToList();
            
                return BadRequest(new { errors });
            }
        }
        
        
        // POST: api/user/login
        [HttpPost("login")]
        public IActionResult Login([FromBody] UserLoginRequest request)
        {
            var user = _tUserDomain.Authenticate(request.Username, request.Password);
            
            if (user != null)
            {
                //var token = GenerateJwtToken(user);
                return Ok(user.Id);
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
                // You can add more claims as needed
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


    
    }
}
