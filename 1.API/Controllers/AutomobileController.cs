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
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace _1.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AutomobileController : ControllerBase
    {
        private IAutomobileData _automobileData;
        private IAutomobileDomain _automobileDomain;
        private IUserData _userData;
        private IMapper _mapper;

        public AutomobileController(IAutomobileData automobileData, IAutomobileDomain automobileDomain, IMapper mapper,IUserData userData)
        {
            _automobileData = automobileData;
            _automobileDomain = automobileDomain;
            _mapper = mapper;
            _userData = userData;
        }
        
        // GET: api/search-car/getAll
        [HttpGet("search-car/getAll")]
        public Task<List<Automobile>> Get()
        {
            return _automobileData.GetAllAsync();
        }
        
        // GET: api/Automobile/search-car/getfilter
        [HttpGet(  "search-car/getfilter")]
        public IActionResult Get(string Brand,string Model)
        {
            Task<List<Automobile>> automobile = _automobileData.GetBySearch(Brand,Model);
            if (automobile == null)
            {
                return NotFound(); 
            }
            Task<List<SearchAutomovilFilterResponse>> searchAutomovilFilterResponse = _mapper.Map< Task<List<Automobile>> , Task<List<SearchAutomovilFilterResponse>>>(automobile);
            return Ok(searchAutomovilFilterResponse);
        }

        
        // POST: api/Automobile/register
        [HttpPost("register")]
        public IActionResult Post([FromBody] AutomobileCreateRequest value)
        {
            var usuario = _userData.GetById(value.UserId);
            var automobile = _mapper.Map<AutomobileCreateRequest,Automobile>(value);
            automobile.IsAvailable = true;
            return Ok(_automobileDomain.Create(automobile, value.UserId));
        }
        
        // DELETE: api/Automobile/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            return Ok(_automobileData.Delete(id));
        }
    }
}
