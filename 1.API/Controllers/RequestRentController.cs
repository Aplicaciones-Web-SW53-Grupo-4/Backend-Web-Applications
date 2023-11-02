using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using _1.API.Request;
using _1.API.Response;
using _2.Domain;
using _3.Data;
using _3.Data.Model;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace _1.API.Controllers
{
    /// <summary>
    /// Controller for managing rental requests.
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class RequestRentController : ControllerBase
    {
        private IRequestRentData _tRequestsData;
        private IRequestRentDomain _tRequestsDomain;
        private IMapper _mapper;

        public RequestRentController(IRequestRentData tRequestsData, IRequestRentDomain tRequestsDomain, IMapper mapper)
        {
            _tRequestsData = tRequestsData;
            _tRequestsDomain = tRequestsDomain;
            _mapper = mapper;
        }

        // Summary: Retrieves all rental requests by owner ID.
        /// <summary>
        /// Retrieves all rental requests by owner ID.
        /// </summary>
        [HttpGet("owner/{id}")]
        public ICollection<RequestRentOwnerResponse> GetAllRequestRentByIdForOwner(int id)
        {
            List<RequestRentOwnerResponse> requestRentOwnerResponses = _mapper.Map<List<RequestRentOwnerResponse>>(_tRequestsDomain.GetAllRequestRentByIdForOwner(id).Result);
            return requestRentOwnerResponses;
        }

        // Summary: Retrieves all rental requests by tenant ID.
        /// <summary>
        /// Retrieves all rental requests by tenant ID.
        /// </summary>
        [HttpGet("tenant/{id}")]
        public List<RequestRent> GetAllRequestRentByIdForTenant(int id)
        {
            List<RequestRent> requestRentOwnerResponses = _tRequestsDomain.GetAllRequestRentByIdForTenant(id).Result;
            //TODO: Map the results
            return requestRentOwnerResponses;
        }

        // Summary: Creates a new rental request.
        /// <summary>
        /// Creates a new rental request.
        /// </summary>
        [HttpPost]
        public bool Post([FromBody] RentRequest value)
        {
            RequestRent requestRent = _mapper.Map<RequestRent>(value);
            return _tRequestsDomain.CreateRequestRent(requestRent);
        }

        // Summary: Updates a rental request by ID.
        /// <summary>
        /// Updates a rental request by ID.
        /// </summary>
        [HttpPut("{id}")]
        public bool Put(int id, [FromBody] RequestRent value)
        {
            return _tRequestsDomain.UpdateRequestRent(value, id);
        }
    }
}
