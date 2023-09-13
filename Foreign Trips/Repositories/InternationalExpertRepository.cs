using Foreign_Trips.DbContexts;
using Foreign_Trips.Entities;
using Foreign_Trips.Model;
using Microsoft.EntityFrameworkCore;

namespace Foreign_Trips.Repositories
{
    public class InternationalExpertRepository : IInternationalExpertRepository
    {
        private readonly AgentDbContext _context;
        private readonly Microsoft.AspNetCore.Hosting.IHostingEnvironment _hostingEnvironment;

        public InternationalExpertRepository(AgentDbContext context, IAgentRepository agentRepository, Microsoft.AspNetCore.Hosting.IHostingEnvironment hostingEnvironment)

        {
            _context = context ?? throw new ArgumentException(nameof(context));
            _hostingEnvironment = hostingEnvironment ??
             throw new ArgumentNullException(nameof(hostingEnvironment));
        }
        public async Task<IEnumerable<InternationalExpertTbl?>> GetInternationalExpert()
        {
            try
            {
                return await _context.InternationalExpertTbl.ToListAsync();
            }
            catch (System.Exception ex)
            {
                return null;
            }
        }



        public async Task<InternationalExpertTbl?> GetInternationalExpertAsync(int internationalExpertId)
        {
            return await _context.InternationalExpertTbl.Where(c => c.InternationalExpertId == internationalExpertId).FirstOrDefaultAsync();
        }


        public static void CreatePasswordHash(string password, out byte[] passwordHash, out byte[] passwordSalt)
        {
            using (var hmac = new System.Security.Cryptography.HMACSHA512())
            {
                passwordSalt = hmac.Key;
                passwordHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
            }
        }

        public async Task<InternationalExpertDto> InsertInternationalExpert(InternationalExpertDto internationalexpert)
        {
            try
            {
                byte[] passwordHash, passwordSalt;
                CreatePasswordHash(internationalexpert.Password.ToString(), out passwordHash, out passwordSalt);
                InternationalExpertTbl Intexpert = new InternationalExpertTbl();
                Intexpert.InternationalExpertName = internationalexpert.InternationalExpertName;
                Intexpert.InternationalExpertFamily = internationalexpert.InternationalExpertFamily;
                Intexpert.InternationalExpertUserName = internationalexpert.InternationalExpertUserName;
                Intexpert.Password = passwordHash;
                Intexpert.PasswordSalt = passwordSalt;



                await _context.InternationalExpertTbl.AddAsync(Intexpert);
                await _context.SaveChangesAsync();

                return internationalexpert;
            }

            catch (System.Exception ex)
            {
                return null;

            }
        }
    

        public async Task<bool> InternationalExpertExistsAsync(int internationalexpertId)
        {

            return await _context.InternationalExpertTbl.AnyAsync(f => f.InternationalExpertId == internationalexpertId);
        }

        public async Task RemoveInternationalExpert(int internationalexpertId)
        {
            var data = _context.InternationalExpertTbl.Find(internationalexpertId);
            _context.InternationalExpertTbl.Remove(data);

            await _context.SaveChangesAsync();
        }

        public async Task<InternationalExpertTbl?> UpdateInternationalExpert(InternationalExpertTbl internationalexpert)
        {
            try
            {
                var Intexpert = await GetInternationalExpertAsync(internationalexpert.InternationalExpertId);
                Intexpert.InternationalExpertName = internationalexpert.InternationalExpertName;
                Intexpert.InternationalExpertFamily = internationalexpert.InternationalExpertFamily;
                Intexpert.InternationalExpertUserName = internationalexpert.InternationalExpertUserName;
                Intexpert.Password = internationalexpert.Password;


                await _context.SaveChangesAsync();
                return Intexpert;

            }
            catch (System.Exception e)
            {
                return null;
            }
        }

        #region File


        public async Task PostFileAsync(FileUploadModel fileData)
        //public async Task PostFileAsync(IFormFile fileData)
        {
            try
            {
                var fileDetails = new FileDetails()
                {
                    FileId = 0,
                    FileName = fileData.FileDetails.FileName,
                };
                var uniqueFileName = GetUniqueFileName(fileData.FileDetails.FileName);
                //var uploads = Path.Combine(environment.WebRootPath, "users", "posts", postRequest.UserId.ToString());
                var uploads = Path.Combine(_hostingEnvironment.WebRootPath, "uploads");

                var filePath = Path.Combine(uploads, uniqueFileName);

                //using (var stream = System.IO.File.Create(filePath))
                using (var stream = new FileStream(filePath, FileMode.Create))
                {
                    fileData.FileDetails.CopyTo(new FileStream(filePath, FileMode.Create));
                    //fileDetails.FileData = stream.ToArray();
                }
                PersianDateTime persianDateTime = new PersianDateTime(DateTime.Now);

                string date = persianDateTime.ToString().Substring(0, 10);
                //fileDetails.Date = date;

                var result = _context.FileDetails.Add(fileDetails);
                await _context.SaveChangesAsync();
            }
            catch (Exception)
            {
                throw;
            }
        }
        public static string GetUniqueFileName(string fileName)


        {


            fileName = Path.GetFileName(fileName);


            return string.Concat(Path.GetFileNameWithoutExtension(fileName)


                                , "_"


                                , Guid.NewGuid().ToString().AsSpan(0, 4)


                                , Path.GetExtension(fileName));


        }
        public async Task PostMultiFileAsync(List<FileUploadModel> fileData)
        {
            try
            {
                foreach (FileUploadModel file in fileData)
                {
                    var fileDetails = new FileDetails()
                    {
                        FileId = 0,
                        FileName = file.FileDetails.FileName,
                    };

                    using (var stream = new MemoryStream())
                    {
                        file.FileDetails.CopyTo(stream);
                        //fileDetails.FileData = stream.ToArray();
                    }

                    var result = _context.FileDetails.Add(fileDetails);
                }
                await _context.SaveChangesAsync();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task DownloadFileById(int Id)
        {
            try
            {
                var file = _context.FileDetails.Where(x => x.FileId == Id).FirstOrDefaultAsync();

                //var content = new System.IO.MemoryStream(file.Result.FileData);
                var path = Path.Combine(
                   Directory.GetCurrentDirectory(), "FileDownloaded",
                   file.Result.FileName);

                //await CopyStream(content, path);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task CopyStream(Stream stream, string downloadPath)
        {
            using (var fileStream = new FileStream(downloadPath, FileMode.Create, FileAccess.Write))
            {
                await stream.CopyToAsync(fileStream);
            }
        }
        #endregion

    }

}
