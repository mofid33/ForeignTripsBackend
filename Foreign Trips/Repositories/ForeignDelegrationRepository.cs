using Azure.Core;
using Foreign_Trips.DbContexts;
using Foreign_Trips.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.FileSystemGlobbing;
using Microsoft.Extensions.Logging;

namespace Foreign_Trips.Repositories
{
    public class ForeignDelegrationRepository : IForeignDelegrationRepository
    {
        private readonly AgentDbContext _context;

        public ForeignDelegrationRepository(AgentDbContext context)

        {
            _context = context ?? throw new ArgumentException(nameof(context));
        }
        public async Task<bool> ForeginDelegrationExistsAsync(int foregindelegrationId)
        {
            return await _context.ForeginDelegrationTbl.AnyAsync(f => f.ForeignDelegationId == foregindelegrationId);
            
        }

        public async Task<IEnumerable<ForeignDelegrationTbl?>> GetForeginDelegration()
        {
            try
            {
                return await _context.ForeginDelegrationTbl.ToListAsync();
            }
            catch (System.Exception ex)
            {
                return null;
            }
        }

        public async Task<ForeignDelegrationTbl?> GetForeginDelegrationAsync(int ForeginDelegrationId)
        {
            return await _context.ForeginDelegrationTbl.Where(c => c.ForeignDelegationId == ForeginDelegrationId).FirstOrDefaultAsync();
        }

        public async Task<ForeignDelegrationTbl?> InsertForeginDelegration(ForeignDelegrationTbl foregindelegration)
        {
            try
            {
                ForeignDelegrationTbl data = new ForeignDelegrationTbl();
                data.CityId = foregindelegration.CityId;
                data.Sex = foregindelegration.Sex;
                data.Name = foregindelegration.Name;
                data.SurName = foregindelegration.SurName;
                data.FatherSName = foregindelegration.FatherSName;
                data.DateOfBirth = foregindelegration.DateOfBirth;
                data.PlaceOfBirth = foregindelegration.PlaceOfBirth;
                data.Nationality = foregindelegration.Nationality;
                data.PassportNo = foregindelegration.PassportNo;
                data.TypeOfPassport = foregindelegration.TypeOfPassport;
                data.DateOfIssue = foregindelegration.DateOfIssue;
                data.PlaceOfIssue = foregindelegration.PlaceOfIssue;
                data.ExpiryDate = foregindelegration.ExpiryDate;
                data.Occupation = foregindelegration.Occupation;
                data.Organization = foregindelegration.Organization;
                data.PlaceVisaToBeIssued = foregindelegration.PlaceVisaToBeIssued;
                data.DurationOfStayInIran = foregindelegration.DurationOfStayInIran;
                data.ThePreviouseDateOfEntryToIran = foregindelegration.ThePreviouseDateOfEntryToIran;
                data.EmailAddress = foregindelegration.EmailAddress;
                data.LandlineNumber = foregindelegration.LandlineNumber;
                data.MobileNumber = foregindelegration.MobileNumber;
                data.HostName = foregindelegration.HostName;
                data.HostLandlineNumber = foregindelegration.HostLandlineNumber;
                data.HostMobileNumber = foregindelegration.HostMobileNumber;

                await _context.SaveChangesAsync();
                return foregindelegration;

            }

            catch (System.Exception ex)
            {
                return null;

            }
        }

        public async Task RemoveForeginDelegrationAsync(int ForeginDelegrationId)
        {
            var data = _context.ForeginDelegrationTbl.Find(ForeginDelegrationId);
            _context.ForeginDelegrationTbl.Remove(data);

            await _context.SaveChangesAsync();
        }

        public async Task<ForeignDelegrationTbl?> UpdateForeginDelegration(ForeignDelegrationTbl foregindelegration)
        {
            try
            {
                var data = await _context.ForeginDelegrationTbl.FindAsync(foregindelegration.ForeignDelegationId);
                data.CityId = foregindelegration.CityId;
                data.Sex = foregindelegration.Sex;
                data.Name = foregindelegration.Name;
                data.SurName = foregindelegration.SurName;
                data.FatherSName = foregindelegration.FatherSName;
                data.DateOfBirth = foregindelegration.DateOfBirth;
                data.PlaceOfBirth = foregindelegration.PlaceOfBirth;
                data.Nationality = foregindelegration.Nationality;
                data.PassportNo = foregindelegration.PassportNo;
                data.TypeOfPassport = foregindelegration.TypeOfPassport;
                data.DateOfIssue = foregindelegration.DateOfIssue;
                data.PlaceOfIssue = foregindelegration.PlaceOfIssue;
                data.ExpiryDate = foregindelegration.ExpiryDate;
                data.Occupation = foregindelegration.Occupation;
                data.Organization = foregindelegration.Organization;
                data.PlaceVisaToBeIssued = foregindelegration.PlaceVisaToBeIssued;
                data.DurationOfStayInIran = foregindelegration.DurationOfStayInIran;
                data.ThePreviouseDateOfEntryToIran = foregindelegration.ThePreviouseDateOfEntryToIran;
                data.EmailAddress = foregindelegration.EmailAddress;
                data.LandlineNumber = foregindelegration.LandlineNumber;
                data.MobileNumber = foregindelegration.MobileNumber;
                data.HostName = foregindelegration.HostName;
                data.HostLandlineNumber = foregindelegration.HostLandlineNumber;
                data.HostMobileNumber = foregindelegration.HostMobileNumber;

                await _context.SaveChangesAsync();
                return foregindelegration;

            }

            catch (System.Exception ex)
            {
                return null;

            }
        }
    }
}
