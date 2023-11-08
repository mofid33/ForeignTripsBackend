using AutoMapper;
using Foreign_Trips.Model;
using Foreign_Trips.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace Foreign_Trips.Controllers
{
    [Route("api/Report")]
    public class ReportController : ControllerBase
    {
        private readonly IReportRepository _reportRepository;
        private readonly IMapper _mapper;

        public ReportController(IReportRepository reportRepository,
                                 IMapper mapper)
        {
            _reportRepository = reportRepository ??
               throw new ArgumentNullException(nameof(reportRepository));

            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }


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
        [Route("GetReportByRequest")]
        public async Task<ActionResult<ReportTbl>> GetReportsExpert(
[FromBody] ReportTbl Model
)
        {

            var req = await _reportRepository.GetReportByRequest(Convert.ToInt32(Model.RequestId));
            if (req == null)
            {
                return BadRequest();
            }
            return Ok(
       req
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



        [HttpPost]
        [Route("UpdateReport")]
        public async Task<ActionResult<ReportTbl>> UpdateReport(
[FromBody] ReportTbl Model
)
        {
            if (!await _reportRepository.ReportExistsAsync(Model.ReportId))
            {
                return NoContent();
            }
            var Rep = await _reportRepository.UpdateReport(Model);
            if (Rep == null)
            {
                return BadRequest();
            }
            return Ok(Rep);
        }



                [HttpPost]
                [Route("RemoveReport")]
                public async Task<ActionResult<ReportTbl>> RemoveReport(
        [FromBody] ReportTbl Model
        )
                {
           
                       
                var Rep = await _reportRepository.RemoveReport(Model.ReportId);
                if (Rep == null)
                {
                    return BadRequest();
                }
                return Ok(Rep);
              
                }

            


           


    }
}
