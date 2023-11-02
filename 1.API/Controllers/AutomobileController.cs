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
    /// Controller for managing automobile data.
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class AutomobileController : ControllerBase
    {
        private IAutomobileData automobileData;
        private IAutomobileDomain automobileDomain;
        private IUserData _userData;
        private IMapper _mapper;

        /// <summary>
        /// Constructor for the AutomobileController class.
        /// </summary>
        public AutomobileController(IAutomobileData automobileData, IAutomobileDomain automobileDomain, IMapper mapper, IUserData userData)
        {
            this.automobileData = automobileData;
            this.automobileDomain = automobileDomain;
            this._mapper = mapper;
            this._userData = userData;
        }
        
        /// <summary>
        /// Retrieves all automobiles.
        /// </summary>
        [HttpGet("search-car/getAll")]
        public Task<List<Automobile>> Get()
        {
            // Code to retrieve all automobiles
            return automobileData.GetAllAsync();
        }
        
        /// <summary>
        /// Retrieves automobiles based on search filters.
        /// </summary>
        [HttpGet("search-car/getfilter")]
        public IActionResult Get(string Brand, string Model)
        {
            // Code to retrieve automobiles based on search filters
            Task<List<Automobile>> automobile = automobileData.GetBySearch(Brand, Model);
            if (automobile == null)
            {
                return NotFound(); 
            }
            Task<List<SearchAutomovilFilterResponse>> searchAutomovilFilterResponse =
                _mapper.Map<Task<List<Automobile>>, Task<List<SearchAutomovilFilterResponse>>>(automobile);
            return Ok(searchAutomovilFilterResponse);
        }

        /// <summary>
        /// Registers a new automobile.
        /// </summary>
        [HttpPost("register")]
        public IActionResult Post([FromBody] AutomobileCreateRequest value)
        {
            // Code to register a new automobile
            var usuario = _userData.GetById(value.UserId);
            var automobile = _mapper.Map<AutomobileCreateRequest, Automobile>(value);
            automobile.IsAvailable = true;
            return Ok(automobileDomain.Create(automobile, value.UserId));
        }

        /// <summary>
        /// Deletes an automobile by ID.
        /// </summary>
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            // Code to delete an automobile by ID
            return Ok(automobileData.Delete(id));
        }
    }
}

