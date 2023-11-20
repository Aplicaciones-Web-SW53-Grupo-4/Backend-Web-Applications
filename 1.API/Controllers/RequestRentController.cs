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
    [Route("api/[controller]")]
    [ApiController]
    public class RequestRentController : ControllerBase
    {
        private IRequestRentData _tRequestsData;
        private IRequestRentDomain _tRequestsDomain;
        private IMapper _mapper;

        // Constructor injection of necessary services and dependencies
        public RequestRentController(IRequestRentData tRequestsData, IRequestRentDomain tRequestsDomain, IMapper mapper)
        {
            _tRequestsData = tRequestsData;
            _tRequestsDomain = tRequestsDomain;
            _mapper = mapper;
        }

        // GET: api/RequestRent/owner/id
        /// <summary>
        /// Retrieves all request rents by owner ID.
        /// </summary>
        [HttpGet("owner/{id}")]
        [Produces("application/json")]
        public List<RequestRentOwnerResponse> GetAllRequestRentByIdForOwner(string id)
        {
            List<RequestRentOwnerResponse> requestRentOwnerResponses =
                _mapper.Map<List<RequestRentOwnerResponse>>(_tRequestsDomain.GetAllRequestRentByIdForOwner(id).Result);
            return requestRentOwnerResponses;
        }

        // GET: api/RequestRent/tenant/id
        /// <summary>
        /// Retrieves all request rents by tenant ID.
        /// </summary>
        [HttpGet("tenant/{id}")]
        [Produces("application/json")]
        public List<RequestRentTenantResponse> GetAllRequestRentByIdForTenant(string id)
        {
            List<RequestRent> requestsTenant = _tRequestsDomain.GetAllRequestRentByIdForTenant(id).Result;
            List<RequestRentTenantResponse> requestRentTenantResponses =
                _mapper.Map<List<RequestRentTenantResponse>>(requestsTenant);
            return requestRentTenantResponses;
        }
    

    // POST: api/RequestRent
        /// <summary>
        /// Creates a new request rent.
        /// </summary>
        /// <response code="201">Return the newly created  Rent</response>
        /// <response code="400">If the Automobile null</response>
        [HttpPost]
        public bool Post([FromBody] RentRequest value)
        {
            RequestRent requestRent = _mapper.Map<RentRequest,RequestRent>(value);
            return _tRequestsDomain.CreateRequestRent(requestRent);
        }

        // PUT: api/RequestRent/5
        /// <summary>
        /// Updates an existing request rent by ID.
        /// </summary>
        [HttpPut("{id}")]
        public bool Put(string id, [FromBody] UpdateRequestRentRequest value)
        {
            RequestRent requestRent = _mapper.Map<UpdateRequestRentRequest,RequestRent>(value);
            return _tRequestsDomain.UpdateRequestRent(requestRent, id);
        }

    }
}
