using Azure.Core;
using Foreign_Trips.DbContexts;
using Foreign_Trips.Entities;
using Foreign_Trips.Model;
using Microsoft.EntityFrameworkCore;
using System.Net.Sockets;

namespace Foreign_Trips.Repositories
{
    public class ReportRepository : IReportRepository
    {
        private readonly AgentDbContext _context;

        public ReportRepository(AgentDbContext context)

        {
            _context = context ?? throw new ArgumentException(nameof(context));
        }

        public async Task<IEnumerable<Report?>> GetReport()
        {
            return await _context.Report
                .Include(c => c.Request.Agent)
                .Include(x => x.Request)
                .ToListAsync();
        }

        public async Task<Report?> GetReportAsync(int reportId)
        {
            return await _context.Report
             .Include(c => c.Request.Agent)
             .Include(x => x.Request)
             


             .Where(c => c.ReportId == reportId).FirstOrDefaultAsync();

        }

        public async Task<Report?> InsertReport(Report report)
        {
            try
            {
                Report data = new Report();
                data.Request.Agent.AgentName = report.Request.Agent.AgentName;
                data.Request.Agent.AgentFamily = report.Request.Agent.AgentFamily;
                data.RequestDateNumber = report.RequestDateNumber;
                data.LicenseNumber = report.LicenseNumber;
                data.LicenseDate = report.LicenseDate;
                data.Period = report.Period;    
                data.EmailExternalDevice = report.EmailExternalDevice;
                data.EmailInternalDevice = report.EmailInternalDevice;
                data.InternalDevice = report.InternalDevice;
                data.ExternalDevice = report.ExternalDevice;
                data.Request.DestinationCountry = report.Request.DestinationCountry;
                data.Request.DestinationCity = report.Request.DestinationCity;
                data.Request.MissionAchievementRecords = data.Request.MissionAchievementRecords;



                await _context.Report.AddAsync(data);


                await _context.SaveChangesAsync();
                return report;

            }

            catch (System.Exception ex)
            {
                return null;

            }
        }


        public async Task RemoveReport(int reportId)
        {
            var data = _context.Report.Find(reportId);
            _context.Report.Remove(data);

            await _context.SaveChangesAsync();
        }


        public async Task<bool> ReportExistsAsync(int reportId)
        {
            return await _context.Report.AnyAsync(f => f.ReportId == reportId);
        }


        public async Task<Report?> UpdateReport(Report report)
        {
            try
            {
                var data = await _context.Report.FindAsync(report.ReportId);
                data.RequestDateNumber = report.RequestDateNumber;
                data.LicenseNumber = report.LicenseNumber;
                data.LicenseDate = report.LicenseDate;
                data.Period = report.Period;
                data.EmailExternalDevice = report.EmailExternalDevice;
                data.EmailInternalDevice = report.EmailInternalDevice;
                data.InternalDevice = report.InternalDevice;
                data.ExternalDevice = report.ExternalDevice;
                data.Request.DestinationCountry = report.Request.DestinationCountry;
                data.Request.DestinationCity = report.Request.DestinationCity;
                data.Request.MissionAchievementRecords = data.Request.MissionAchievementRecords;





                await _context.SaveChangesAsync();
                return report;
            }

            catch (System.Exception ex)
            {
                return null;

            }

        }

        //public Task DownloadFileById(int fileName)
        //{
        //    throw new NotImplementedException();
        //}

        //public async Task PostFileAsync(FileUploadModel fileData)
        //{

        //    try
        //    {
        //        var fileDetails = new FileDetails()
        //        {
        //            ID = 0,
        //            FileName = fileData.FileDetails.FileName,
        //        };
        //        var uniqueFileName = GetUniqueFileName(fileData.FileDetails.FileName);
        //        //var uploads = Path.Combine(environment.WebRootPath, "users", "posts", postRequest.UserId.ToString());
        //        var uploads = Path.Combine(_hostingEnvironment.WebRootPath, "uploads");

        //        var filePath = Path.Combine(uploads, uniqueFileName);

        //        //using (var stream = System.IO.File.Create(filePath))
        //        using (var stream = new FileStream(filePath, FileMode.Create))
        //        {
        //            fileData.FileDetails.CopyTo(new FileStream(filePath, FileMode.Create));
        //            //fileDetails.FileData = stream.ToArray();
        //        }
        //        PersianDateTime persianDateTime = new PersianDateTime(DateTime.Now);

        //        string date = persianDateTime.ToString().Substring(0, 10);
        //        //fileDetails.Date = date;

        //        var result = _context.FileDetails.Add(fileDetails);
        //        await _context.SaveChangesAsync();
        //    }
        //    catch (Exception)
        //    {
        //        throw;
        //    }
        //}

        //public Task PostMultiFileAsync(List<FileUploadModel> fileData)
        //{
        //    throw new NotImplementedException();
        //}


    }
}
