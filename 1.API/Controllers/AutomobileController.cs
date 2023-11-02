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
    /// <summary>
    /// Controller for managing automobile data.
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class AutomobileController : ControllerBase
    {
        private IAutomobileData _automobileData;
        private IAutomobileDomain _automobileDomain;
        private IUserData _userData;
        private IMapper _mapper;

        public AutomobileController(IAutomobileData automobileData, IAutomobileDomain automobileDomain, IMapper mapper, IUserData userData)
        {
            _automobileData = automobileData;
            _automobileDomain = automobileDomain;
            _mapper = mapper;
            _userData = userData;
        }
        
        // GET: api/search-car/getAll
        /// <summary>
        /// Retrieves all automobiles.
        /// </summary>
        [HttpGet("search-car/getAll")]
        [Produces("application/json")]
        public Task<List<Automobile>> Get()
        {
            return _automobileData.GetAllAsync();
        }
        
        // GET: api/Automobile/search-car/getfilter
        /// <summary>
        /// Retrieves automobiles based on search filters.
        /// </summary>
        [HttpGet("search-car/getfilter")]
        [Produces("application/json")]
        public IActionResult Get(string Brand, string Model)
        {
            // Check if there are any automobiles matching the provided search filters
            Task<List<Automobile>> automobile = _automobileData.GetBySearch(Brand, Model);
            if (automobile == null)
            {
                return NotFound(); 
            }
            // Map the search results to the response model
            Task<List<SearchAutomovilFilterResponse>> searchAutomovilFilterResponse = _mapper.Map<Task<List<Automobile>>, Task<List<SearchAutomovilFilterResponse>>>(automobile);
            return Ok(searchAutomovilFilterResponse);
        }

        
        // POST: api/Automobile/register
        /// <summary>
        /// Registers a new automobile.
        /// </summary>
        /// <response code="201">Return the newly created  Automobile</response>
        /// <response code="400">If the Automobile null</response>
        
        [HttpPost("register")]
        public IActionResult Post([FromBody] AutomobileCreateRequest value)
        {
            // Obtain the user data associated with the request
            var usuario = _userData.GetById(value.UserId);
            // Map the request data to the Automobile model
            var automobile = _mapper.Map<AutomobileCreateRequest, Automobile>(value);
            automobile.IsAvailable = true;
            // Create the new automobile and return the result
            return Ok(_automobileDomain.Create(automobile, value.UserId));
        }
        
        // DELETE: api/Automobile/5
        /// <summary>
        /// Deletes an automobile by ID.
        /// </summary>
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            // Delete the automobile with the specified ID
            return Ok(_automobileData.Delete(id));
        }
    }
}
