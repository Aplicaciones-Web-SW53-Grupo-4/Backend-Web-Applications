using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using _1.API.Request;
using _2.Domain;
using _3.Data.Model;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace _1.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AutomobileController : ControllerBase
    {
        private IAutomobileData automobileData;
        private IAutomobileDomain automobileDomain;
        private IUserData _userData;
        private IMapper _mapper;

        public AutomobileController(IAutomobileData automobileData, IAutomobileDomain automobileDomain, IMapper mapper
        , IUserData userData)
        {
            this.automobileData = automobileData;
            this.automobileDomain = automobileDomain;
            this._mapper = mapper;
            this._userData = userData;
        }
        // GET: api/Automobile
        [HttpGet("search-car/getAll")]
        public Task<List<Automobile>> Get()
        {
            return automobileData.GetAllAsync();
        }

        // GET: api/Automobile/5
        [HttpGet("{id}", Name = "GetAutomobile")]
        public Automobile Get(int id)
        {
            return automobileData.GetById(id);
        }

        // POST: api/Automobile
        [HttpPost("register")]
        public IActionResult Post([FromBody] AutomobileCreateRequest value)
        {
            var usuario = _userData.GetById(value.UserId);
            var automobile = _mapper.Map<AutomobileCreateRequest,Automobile>(value);
            automobile.IsAvailable = true;
            return Ok(automobileDomain.Create(automobile, value.UserId));
        }
        // [HttpPost("search-car")]
        // public IActionResult SearchCarByFilter([FromBody] AutomobileSearchRequest value)
        // {
        //     var automobile = _mapper.Map<AutomobileSearchRequest,Automobile>(value);
        //     return Ok(automobileData.SearchCarByFilter(automobile));
        // }
        
        // DELETE: api/Automobile/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            return Ok(automobileData.Delete(id));
        }
    }
}
