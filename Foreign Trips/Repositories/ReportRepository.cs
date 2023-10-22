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

        public async Task<IEnumerable<ReportTbl?>> GetReport()
        {
            try
            {
                return await _context.ReportTbl
                    .Include(c => c.Request.Agent)
                    .Include(x => x.Request)
                    .ToListAsync();
            }
            catch (System.Exception ex)
            {
                return null;
            }
        }

        public async Task<ReportTbl?> GetReportAsync(int reportId)
        {
            try
            {
                return await _context.ReportTbl
                 .Include(c => c.Request.Agent)
                 .Include(x => x.Request)



                 .Where(c => c.ReportId == reportId).FirstOrDefaultAsync();
            }
            catch (System.Exception ex)
            {
                return null;
            }

        }
        public async Task<ReportTbl?> GetReportByRequest(int requestId)
        {
            try
            {
                return await _context.ReportTbl
                 .Include(c => c.Request.Agent)
                 .Include(x => x.Request)



                 .Where(c => c.RequestId == requestId).OrderBy(t => t.ReportId).LastOrDefaultAsync();
            }
            catch (System.Exception ex)
            {
                return null;
            }

        }


        public async Task<ReportTbl?> InsertReport(ReportTbl report)
        {
            try
            {
                ReportTbl data = new ReportTbl();
                data.RequestId = report.RequestId;
                //data.ReportStatusId = report.ReportStatusId;
                //data.RequestDateNumber = report.RequestDateNumber;
                //data.LicenseNumber = report.LicenseNumber;
                //data.LicenseDate = report.LicenseDate;
                //data.Period = report.Period;    
                //data.EmailExternalDevice = report.EmailExternalDevice;
                //data.EmailInternalDevice = report.EmailInternalDevice;
                //data.InternalDevice = report.InternalDevice;
                //data.ExternalDevice = report.ExternalDevice;
                //data.LatestUpdate = report.LatestUpdate;
                data.ReportAchievement = report.ReportAchievement;



                await _context.ReportTbl.AddAsync(data);


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
            var data = _context.ReportTbl.Find(reportId);
            _context.ReportTbl.Remove(data);

            await _context.SaveChangesAsync();
        }


        public async Task<bool> ReportExistsAsync(int reportId)
        {

            return await _context.ReportTbl.AnyAsync(f => f.ReportId == reportId);
        }


        public async Task<ReportTbl?> UpdateReport(ReportTbl report)
        {
            try
            {
                var data = await _context.ReportTbl.FindAsync(report.ReportId);
                data.RequestDateNumber = report.RequestDateNumber;
                data.LicenseNumber = report.LicenseNumber;
                data.LicenseDate = report.LicenseDate;
                data.Period = report.Period;
                data.EmailExternalDevice = report.EmailExternalDevice;
                data.EmailInternalDevice = report.EmailInternalDevice;
                data.InternalDevice = report.InternalDevice;
                data.ExternalDevice = report.ExternalDevice;
                data.Request.CityId = report.Request.CityId;
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
