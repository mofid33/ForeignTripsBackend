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
        public async Task<ActionResult<IEnumerable<Report>>> GetReport()
        {
            var reports = await _reportRepository.GetReport();

            return Ok(
                reports
                );
        }



        [HttpPost]
        [Route("InsertReport")]
        public async Task<ActionResult<Report>> InsertReport(
    [FromBody] Report Model
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
        public async Task<ActionResult<Report>> UpdateReport(
[FromBody] Report Model
)
        {
            if (!await _reportRepository.ReportExistsAsync(Model.ReportId))
            {
                return NotFound();
            }
            var Rep = await _reportRepository.UpdateReport(Model);
            if (Rep == null)
            {
                return BadRequest();
            }
            return Ok();
        }



                [HttpPost]
                [Route("RemoveReport")]
                public async Task<ActionResult<Report>> RemoveReport(
        [FromBody] Report Model
        )
                {
                    try
                    {
                        if (!await _reportRepository.ReportExistsAsync(Model.ReportId))
                        {
                            return NoContent();
                        }
                        _reportRepository.RemoveReport(Model.ReportId);

                        return Ok();
                    }

                    catch (System.Exception ex)
                    {
                        return null;

                    }
                }


           


    }
}
