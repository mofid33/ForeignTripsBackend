using AutoMapper;
using Foreign_Trips.Entities;
using Foreign_Trips.Model;
using Foreign_Trips.Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using NPOI.SS.Formula.Functions;
using ShenaseMeliBac.Profiles;

namespace Foreign_Trips.Controllers
{
    [Route("api/Agents")]
    public class AgentController : ControllerBase
    {
        private readonly IAgentRepository _agentRepository;
        private readonly IAuthRepository _authRepository;
        private readonly IRequestRepository _requestRepository;
        private readonly IReportRepository _reportRepository;
        private readonly IMapper _mapper;

        public AgentController(IAgentRepository agentRepository, IAuthRepository authRepository, IReportRepository reportRepository,  IRequestRepository requestRepository, IMapper mapper)
        {
            _agentRepository = agentRepository ??
                throw new ArgumentNullException(nameof(agentRepository));
            _authRepository = authRepository ??
                throw new ArgumentNullException(nameof(authRepository));
            _requestRepository = requestRepository ??
                throw new ArgumentNullException(nameof(requestRepository));
            _reportRepository = reportRepository ??
                throw new ArgumentNullException(nameof(reportRepository));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }


        [HttpGet]
        [Route("GetAgents")]

        public async Task<ActionResult<IEnumerable<AgentTbl>>> GetAgents([FromQuery(Name = "page")] int page, [FromQuery(Name = "pageSize")]int pageSize,string search)

        {
            var Agents = await _agentRepository.GetAgent(page==0?1:page , pageSize == 0 ? 10 : pageSize , search);
            if (Agents == null)
            {
                return BadRequest();
            }
            return Ok(
                //_mapper.Map<IEnumerable<AgentTbl>>(Agents)
                Agents
                );
        }

        [HttpGet]
        [Route("GetSubCategories")]
        public async Task<ActionResult<IEnumerable<SubCategoryTbl>>> GetSubCategory()
        {
            var Agents = await _agentRepository.GetSubCategory();
            if (Agents == null)
            {
                return BadRequest();
            }

            return Ok(
                Agents
                );
        }

        [HttpGet]
        [Route("GetPositions")]
        public async Task<ActionResult<IEnumerable<PositionTypeTbl>>> GetPosition()
        {
            var Agents = await _agentRepository.GetPosition();
            if (Agents == null)
            {
                return BadRequest();
            }

            return Ok(
                Agents
                );
        }
        [HttpGet]
        [Route("GetTypeEmployments")]
        public async Task<ActionResult<IEnumerable<PositionTypeTbl>>> GetTypeEmployment()
        {
            var Agents = await _agentRepository.GetTypeEmployment();
            if (Agents == null)
            {
                return BadRequest();
            }

            return Ok(
                Agents
                );
        }
        [HttpGet]
        [Route("GetAgent")]
        public async Task<ActionResult<AgentDto>> GetAgent()
        {
            string authHeader = HttpContext.Request.Headers["Authorization"].ToString().Replace("Bearer ", string.Empty);

            var AgentID = _authRepository.GetIDFromToken(authHeader);
            if (!await _agentRepository.AgentExistsAsync(AgentID))
            {
                return NotFound();
            }
            var Agent = await _agentRepository.GetAgentAsync(AgentID);
            if (Agent == null)
            {
                return BadRequest();
            }

            return Ok(
         _mapper.Map<AgentTbl>(Agent)
         );

        }

        //[HttpGet]
        //[Route("GetAgentStatus")]
        //public async Task<ActionResult<IEnumerable<AgentStatusTbl>>> GetAgentStatus()
        //{
        //    var agnets = await _agentRepository.GetAgentStatusAsync();

        //    return Ok(
        //        _mapper.Map<IEnumerable<AgentStatusTbl>>(agnets)
        //        );

        //}



        [HttpPost]
        [Route("InsertAgent")]
        public async Task<ActionResult<AgentDto>> InsertAgnet(
        [FromBody] AgentDto Model
        )
        {

            var Eagent = await _agentRepository.InsertAgentAsync(Model);
            if (Eagent == null)
            {
                return BadRequest();
            }

            return Ok(Eagent);

        }

        [HttpPost]
        [Route("UpdateAgnet")]
        public async Task<ActionResult<AgentTbl>> UpdateAgentAsync(
[FromBody] AgentTbl Model
)
        {
            if (!await _agentRepository.AgentExistsAsync(Model.AgentId))
            {
                return NoContent();
            }

            var Eagent = await _agentRepository.UpdateAgentAsync(Model);
            if (Eagent == null)
            {
                return BadRequest();
            }

            return Ok(Eagent);
           
        
        }

        //[HttpPost]
        //[Route("DeleteAgent")]
        //public async Task<ActionResult<AgentTbl>> DeleteAgentAsync(
        //[FromBody] AgentTbl Model
        //)
        //{
        //    if (!await _agentRepository.AgentExistsAsync(Model.AgentId))
        //    {
        //        return NotFound();
        //    }
        //    _agentRepository.DeleteAgent(Model.AgentId);

        //    return Ok();

        //}


        #region Request

        [HttpGet]
        [Route("GetRequests")]
        public async Task<ActionResult<IEnumerable<RequestTbl>>> GetRequest([FromQuery(Name = "page")] int page, [FromQuery(Name = "pageSize")] int pageSize, string search)
        {
            var Requests = await _requestRepository.GetRequest(page == 0 ? 1 : page, pageSize == 0 ? 10 : pageSize, search);
            if (Requests == null)
            {
                return BadRequest();
            }
            return Ok(
                Requests
                );
        }


        [HttpPost]
        [Route("GetRequest")]
        public async Task<ActionResult<RequestTbl>> GetRequest(
     [FromBody] RequestTbl Model
     )
        {

            var req = await _requestRepository.GetRequestAsync(Model.RequestId);
            if (req == null)
            {
                return BadRequest();
            }

            return Ok(
         _mapper.Map<RequestTbl>(req)
         );

        }

        [HttpPost]
        [Route("GetRequestsExpert")]
        public async Task<ActionResult<RequestTbl>> GetRequestExpert(
   [FromBody] RequestTbl Model
   )
        {

            var req = await _requestRepository.GetRequestsExpert(Convert.ToInt32(Model.InternationalExpertId));
            if (req == null)
            {
                return BadRequest();
            }


            return Ok(
       req
         );

        }


        [HttpPost]
        [Route("GetRequestEmployee")]
        public async Task<ActionResult<RequestEmployeeTbl>> GetRequestEmployee(
     [FromBody] RequestEmployeeTbl Model
     )
        {

            var req = await _requestRepository.GetRequestEmployeeAsync(Model.RequestId);
            if (req == null)
            {
                return BadRequest();
            }
            return Ok(req);


        }


        [HttpPost]
        [Route("GetnewRequest")]
        public async Task<ActionResult<RequestTbl>> GetNewRequest(
    [FromBody] RequestTbl Model
    )
        {

            var req = await _requestRepository.GetNewRequest(Model.RequestId);
            if (req == null)
            {
                return BadRequest();
            }

            return Ok(
         _mapper.Map<RequestTbl>(req)
         );

        }



        [HttpPost]
        [Route("InsertRequest")]
        public async Task<ActionResult<RequestTbl>> InsertRequest(
[FromBody] RequestTbl Model
            )

        {

            var Req = await _requestRepository.InsertRequestAsync(Model);
            if (Req == null)
            {
                return BadRequest();
            }
            return Ok(Req);

        }

        [HttpPost]
        [Route("InsertRequestEmployee")]
        public async Task<ActionResult<RequestEmployeeTbl>> InsertRequestEmployeeAsync(
[FromBody] RequestEmployeeTbl Model
)
        {

            if (!await _requestRepository.RequestExistsAsync(Model.RequestId))
            {
                return NotFound();
            }

            var request = await _requestRepository.InsertRequestEmployeeAsync(Model);
            if (request == null)
            {
                return BadRequest();
            }

            return Ok(request);

        }

        [HttpPost]
        [Route("UpdateRequest3")]
        public async Task<ActionResult<RequestTbl>> UpdateRequest3Async(
[FromBody] RequestTbl Model
)
        {
            if (!await _requestRepository.RequestExistsAsync(Model.RequestId))
            {
                return NoContent();
            }

            var request = await _requestRepository.UpdateRequest3Async(Model);
            if (request == null)
            {
                return BadRequest();
            }

            return Ok(request);

        }

        [HttpPost]
        [Route("UpdateRequest4")]
        public async Task<ActionResult<RequestTbl>> UpdateRequest4Async(
[FromBody] RequestTbl Model
)
        {
            if (!await _requestRepository.RequestExistsAsync(Model.RequestId))
            {
                return NoContent();
            }

            var request = await _requestRepository.UpdateRequest4Async(Model);
            if (request == null)
            {
                return BadRequest();
            }

            return Ok(request);

        }



        [HttpPost]
        [Route("UpdateRequest5")]
        public async Task<ActionResult<RequestTbl>> UpdateRequest5Async(
[FromBody] RequestTbl Model
)
        {

            if (!await _requestRepository.RequestExistsAsync(Model.RequestId))
            {
                return NoContent();
            }


            var request = await _requestRepository.UpdateRequest5Async(Model);
            if (request == null)
            {
                return BadRequest();
            }

            return Ok(request);

        }

        #endregion

        #region Report
        [HttpGet]
        [Route("GetReports")]
        public async Task<ActionResult<IEnumerable<ReportTbl>>> GetReport()
        {
            var reports = await _reportRepository.GetReport();
            if (reports == null)
            {
                return BadRequest();
            }

            return Ok(
                reports
                );
        }

        [HttpPost]
        [Route("GetReport")]
        public async Task<ActionResult<ReportTbl>> GetReport(
    [FromBody] ReportTbl Model
    )
        {

            var rep = await _reportRepository.GetReportAsync(Model.ReportId);
            if (rep == null)
            {
                return BadRequest();
            }
            return Ok(
         rep
         );

        }


        [HttpPost]
        [Route("InsertReport")]
        public async Task<ActionResult<ReportTbl>> InsertReport(
   [FromBody] ReportTbl Model
   )
        {

            var Rep = await _reportRepository.InsertReport(Model);
            if (Rep == null)
            {
                return BadRequest();
            }
            return Ok(Rep);

        }
        #endregion

        #region Country
        [HttpGet]
        [Route("GetCountries")]
        public async Task<ActionResult<IEnumerable<CountryTbl>>> GetCountry()
        {
            var countries = await _agentRepository.GetCountriesAcync();
            if (countries == null)
            {
                return BadRequest();
            }


            return Ok(
               countries
                );

        }

        [HttpPost]
        [Route("GetCities")]
        public async Task<ActionResult<CityTbl>> GetCities(
        [FromBody] CityTbl Model
)
        {


            var Cities = await _agentRepository.GetCitiesAcync(Model.CountryId);
            if (Cities == null)
            {
                return BadRequest();
            }

            return Ok(
         //_mapper.Map<CityTbl>(Cities)
         Cities
         );

        }
        #endregion

        #region photo

        [HttpPost("PostPhoto")]
        public async Task<ActionResult> PostPhoto([FromForm] PhotoUploadModel photoData)
        {
            var res = await _agentRepository.PhotoAsync(photoData);

            if (res == null)
            {
                return BadRequest();
            }

            else
            {
                return Ok();
            }
        }

        #endregion

    }
}
