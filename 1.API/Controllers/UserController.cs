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
   
    public class UserController : ControllerBase
    {
        private IUserData _tuserData;
        private IUserDomain _tUserDomain;
        private IMapper _mapper;
        private IConfiguration _configuration;

        // Constructor to inject necessary services and dependencies
        public UserController(IUserData userData, IUserDomain userDomain, IMapper mapper, IConfiguration configuration)
        {
            _tuserData = userData;
            _tUserDomain = userDomain;
            _mapper = mapper;
            _configuration = configuration;
        }
       
        // POST: api/user/register
        /// <summary>
        /// Registers a new user.
        /// </summary>
        [HttpPost("register")]
        public IActionResult Register([FromBody] UserRegisterRequest request)
        {
            Console.WriteLine(request); // Log the incoming request
            
            if (ModelState.IsValid)
            {
                var user = _mapper.Map<UserRegisterRequest, User>(request);
                
                if (_tUserDomain.Create(user))
                {
                    return Ok("User registered successfully.");
                }
                else
                {
                    return BadRequest("Failed to register the user.");
                }
            }
            else
            {
                // Handle validation errors
                var errors = ModelState.Values
                    .SelectMany(v => v.Errors)
                    .Select(e => e.ErrorMessage)
                    .ToList();
                
                return BadRequest(new { errors });
            }
        }
        
        // POST: api/user/login
        /// <summary>
        /// Authenticates a user.
        /// </summary>
        [HttpPost("login")]
        public IActionResult Login([FromBody] UserLoginRequest request)
        {
            var user = _tUserDomain.Authenticate(request.Username, request.Password, request.UserType);
            
            if (user != null)
            {
                // Generate and return a JWT token
                var jwtToken = GenerateJwtToken(user);
                return Ok(user.Id);
            }
            else
            {
                return Unauthorized("Invalid credentials");
            }
        }
        
        /// <summary>
        /// Generates a JWT token for the authenticated user.
        /// </summary>
        private string GenerateJwtToken(User user)
        {
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:Key"]));
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