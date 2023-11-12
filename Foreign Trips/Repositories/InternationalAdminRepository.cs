using Foreign_Trips.DbContexts;
using Foreign_Trips.Entities;
using Foreign_Trips.Model;
using Foreign_Trips.Utility;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using NPOI.SS.UserModel;
using NPOI.XSSF.UserModel;
using Serilog;
using System.Collections.Generic;
using System.Runtime.Intrinsics.Arm;

namespace Foreign_Trips.Repositories
{
    public class InternationalAdminRepository : IInternationalAdminRepository
    {
        private readonly AgentDbContext _context;
        private readonly IAgentRepository _agentRepository;
        private readonly Microsoft.AspNetCore.Hosting.IHostingEnvironment _hostingEnvironment;

        public InternationalAdminRepository(AgentDbContext context, IAgentRepository agentRepository, Microsoft.AspNetCore.Hosting.IHostingEnvironment hostingEnvironment)

        {
            _context = context ?? throw new ArgumentException(nameof(context));
            _agentRepository = agentRepository ?? throw new ArgumentNullException(nameof(agentRepository));
            _hostingEnvironment = hostingEnvironment ?? throw new ArgumentNullException(nameof(hostingEnvironment));
        }

        public async Task<bool> AdminExistsAsync(int adminId)
        {
            return await _context.InternationalAdminTbl.AnyAsync(f => f.AdminId == adminId);
        }

        public async Task<IEnumerable<InternationalAdminTbl>> GetAdmins()
        {
            try
            {

                return await _context.InternationalAdminTbl.ToListAsync();
            }
            catch (System.Exception ex)
            {
                return null;
            }
        }

        public async Task<AdminPageDto> GetAdmin(int page, int pagesize, string search)
        {
            try
            {
                var admin = await _context.InternationalAdminTbl
                .Where(t => (search != "" && search != null) ? (t.AdminName.Contains(search) || t.AdminUsername.Contains(search)) : t.AdminName != null)


                    .ToListAsync();

                var ss = await PaginatedList<InternationalAdminTbl>.CreateAsync(admin, page, pagesize);
                return new AdminPageDto
                {
                    Count = admin.Count(),
                    Data = ss

                };
            }
            catch (System.Exception ex)
            {
                return null;
            }
        }

        public static void CreatePasswordHash(string password, out byte[] passwordHash, out byte[] passwordSalt)
        {
            using (var hmac = new System.Security.Cryptography.HMACSHA512())
            {
                passwordSalt = hmac.Key;
                passwordHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
            }
        }


        public async Task<InternationalAdminTbl> InsertAdmin(InternationalAdminTbl admin)
        {
            try
            {
                    byte[] passwordHash, passwordSalt;
                    CreatePasswordHash(admin.Password.ToString(), out passwordHash, out passwordSalt);
                    InternationalAdminTbl adm = new InternationalAdminTbl();
                    adm.AdminName = admin.AdminName;
                    adm.AdminUsername = admin.AdminUsername;
                    adm.Password = passwordHash;
                    adm.PasswordSalt = passwordSalt;



                    await _context.InternationalAdminTbl.AddAsync(adm);
                    await _context.SaveChangesAsync();

                    return admin;
                }

                catch (System.Exception ex)
                {
                    return null;

                }
            }

        public async Task<string> RemoveAdmin(int adminId)
        {
            try
            {
                var data = _context.InternationalAdminTbl.Find(adminId);
                _context.InternationalAdminTbl.Remove(data);

                await _context.SaveChangesAsync();

                return "Ok";
            }
            catch (System.Exception ex)
            {
                return null;

            }

        }

        public async Task<InternationalAdminTbl?> UpdateAdmin(InternationalAdminTbl admin)
        {
            try
            {
                byte[] passwordHash, passwordSalt;
                CreatePasswordHash(admin.Password.ToString(), out passwordHash, out passwordSalt);
                var adm = await _context.InternationalAdminTbl.FindAsync(admin.AdminId);
                adm.AdminName = admin.AdminName;
                adm.AdminUsername = admin.AdminUsername;
                adm.Password = passwordHash;
                adm.PasswordSalt = passwordSalt;
                DateTime dt = new DateTime();
                PersianDateTime persianDateTime = new PersianDateTime(DateTime.Now);
                string date = persianDateTime.ToString().Substring(0, 10);

                adm.RegisterTime = DateTime.Now.ToShortTimeString();
                adm.RegisterDate = date;

                await _context.SaveChangesAsync();
                return admin;

            }

            catch (System.Exception ex)
            {
                return null;

            }
        }
        public async Task<string> GetExcelAgent()
        {
            try
            {
                var adm = await _context.AgentTbl
                    .Include(x => x.SubCategory).Include(v => v.AgentStatus).Include(c => c.City).Include(c => c.Position).Include(c => c.TypeOfEmployment)
                    .ToListAsync();

                var uploads = Path.Combine(_hostingEnvironment.WebRootPath, "uploads");
                var filePath = Path.Combine(uploads, "Agents.xlsx");

                FileInfo file = new FileInfo(filePath);
                var memory = new MemoryStream();
                using (var fs = new FileStream(Path.Combine(filePath), FileMode.Create, FileAccess.Write))
                {
                    NPOI.SS.UserModel.IWorkbook workbook;
                    workbook = new XSSFWorkbook();
                    ISheet excelSheet = workbook.CreateSheet("سفرهای خارجی");
                    IRow row = excelSheet.CreateRow(0);
                    row.CreateCell(0).SetCellValue("ردیف");
                    row.CreateCell(1).SetCellValue("کدملی");
                    row.CreateCell(2).SetCellValue("تاریخ تولد");
                    row.CreateCell(3).SetCellValue("نام مامور");
                    row.CreateCell(4).SetCellValue("نام خانوادگی مامور");
                    row.CreateCell(5).SetCellValue("موبایل");
                    row.CreateCell(6).SetCellValue("شماره تلفن");
                    row.CreateCell(7).SetCellValue("ایمیل");
                    row.CreateCell(8).SetCellValue("کدپستی");
                    row.CreateCell(9).SetCellValue("آدرس");
                    row.CreateCell(10).SetCellValue(" دسته بندی مجموعه");
                    row.CreateCell(11).SetCellValue("زیرمجموعه");
                    row.CreateCell(12).SetCellValue("نوع رابط استخدامی");
                    row.CreateCell(13).SetCellValue("سمت");
                    row.CreateCell(14).SetCellValue("زمان ثبت");
                    row.CreateCell(15).SetCellValue("تاریخ ثبت");
                    row.CreateCell(16).SetCellValue("شهر");


                    int counter = 0;

                    foreach (var item in adm)
                    {
                        counter += 1;
                        row = excelSheet.CreateRow(counter);
                        row.CreateCell(0).SetCellValue(counter);
                        row.CreateCell(1).SetCellValue(item.NationalCode);
                        row.CreateCell(2).SetCellValue(item.DateOfBirth);
                        row.CreateCell(3).SetCellValue(item.AgentName);
                        row.CreateCell(4).SetCellValue(item.AgentFamily);
                        row.CreateCell(5).SetCellValue(item.Mobile);
                        row.CreateCell(6).SetCellValue(item.Phone);
                        row.CreateCell(7).SetCellValue(item.Email);
                        row.CreateCell(8).SetCellValue(item.PostalCode);
                        row.CreateCell(9).SetCellValue(item.Address);
                        row.CreateCell(10).SetCellValue(item.SubCategory?.SubCategoryType);
                        row.CreateCell(11).SetCellValue(item.Subset);
                        row.CreateCell(12).SetCellValue(item.TypeOfEmployment?.TypeOfEmploymentTitle);
                        row.CreateCell(13).SetCellValue(item.Position?.PositionType);
                        row.CreateCell(14).SetCellValue(item.RegisterTime);
                        row.CreateCell(15).SetCellValue(item.RegisterDate);
                        row.CreateCell(16).SetCellValue(item.City?.CityName);

                    }


                    workbook.Write(fs);
                }

                using (var stream = new FileStream(filePath, FileMode.Open))
                {
                    await stream.CopyToAsync(memory);
                }
                memory.Position = 0;


                return filePath;



            }

            catch (System.Exception ex)
            {
                return null;

            }
        }
        //public async Task<string> GetExcelLogin(LoginTbl admin)
        //{
        //    try
        //    {
        //        var adm = await _context.LoginTbl.ToListAsync();
        //        if (admin.OrganizationId != 0)
        //        {
        //            adm = adm.Where(t => t.OrganizationId == admin.OrganizationId).ToList();
        //        }
        //        else
        //        {
        //            adm = adm.Where(t => t.ExpertId == admin.ExpertId).ToList();
        //        }


        //        var uploads = Path.Combine(_hostingEnvironment.WebRootPath, "uploads");
        //        var filePath = Path.Combine(uploads, "Log.xlsx");

        //        FileInfo file = new FileInfo(filePath);
        //        //FileInfo file = new FileInfo("uploads/LogAll.xlsx");
        //        var memory = new MemoryStream();
        //        using (var fs = new FileStream(Path.Combine(filePath), FileMode.Create, FileAccess.Write))
        //        {
        //            NPOI.SS.UserModel.IWorkbook workbook;
        //            workbook = new XSSFWorkbook();
        //            ISheet excelSheet = workbook.CreateSheet("تشکل");
        //            IRow row = excelSheet.CreateRow(0);
        //            row.CreateCell(0).SetCellValue("ردیف");
        //            row.CreateCell(1).SetCellValue("تاریخ");
        //            row.CreateCell(2).SetCellValue("زمان");



        //            int counter = 0;

        //            foreach (var item in adm)
        //            {
        //                counter += 1;
        //                row = excelSheet.CreateRow(counter);
        //                row.CreateCell(0).SetCellValue(counter);
        //                row.CreateCell(1).SetCellValue(item.Date);
        //                row.CreateCell(2).SetCellValue(item.Time);
        //            }




        //            //workbook.Write(fs);




        //            workbook.Write(fs);
        //        }

        //        //using (var fs = new FileStream(Path.Combine(filePath), FileMode.Create, FileAccess.Write))
        //        //{

        //        //}

        //        using (var stream = new FileStream(filePath, FileMode.Open))
        //        {
        //            await stream.CopyToAsync(memory);
        //        }
        //        memory.Position = 0;


        //        return filePath;



        //    }

        //    catch (System.Exception ex)
        //    {
        //        return null;

        //    }
        //}

        //public async Task<string> GetExcelRequest()
        //{
        //    try
        //    {
        //        var adm = await _context.RequestTbl
        //            .Include(x => x.Agent).Include(c => c.City)
        //            .ToListAsync();

        //        var uploads = Path.Combine(_hostingEnvironment.WebRootPath, "uploads");
        //        var filePath = Path.Combine(uploads, "Requests.xlsx");

        //        FileInfo file = new FileInfo(filePath);
        //        var memory = new MemoryStream();
        //        using (var fs = new FileStream(Path.Combine(filePath), FileMode.Create, FileAccess.Write))
        //        {
        //            NPOI.SS.UserModel.IWorkbook workbook;
        //            workbook = new XSSFWorkbook();
        //            ISheet excelSheet = workbook.CreateSheet("سفرهای خارجی");
        //            IRow row = excelSheet.CreateRow(0);
        //            row.CreateCell(0).SetCellValue("ردیف");
        //            row.CreateCell(1).SetCellValue("نام دستگاه اجرایی");
        //            row.CreateCell(2).SetCellValue("آدرس اینترنتی دستگاه اجرایی");
        //            row.CreateCell(3).SetCellValue("کشورمقصد");
        //            row.CreateCell(4).SetCellValue("شهر مقصد");
        //            row.CreateCell(5).SetCellValue("مسیرپروازی");
        //            row.CreateCell(6).SetCellValue("تاریخ سفر");
        //            row.CreateCell(7).SetCellValue("مدت زمان سفر");
        //            row.CreateCell(8).SetCellValue("موشوع سفر");
        //            row.CreateCell(9).SetCellValue("اهداف سفر");
        //            row.CreateCell(10).SetCellValue("اهداف شغلی");
        //            row.CreateCell(11).SetCellValue("نام دستگاه");
        //            row.CreateCell(12).SetCellValue("نوع گذرنامه");
        //            row.CreateCell(13).SetCellValue("آیا نیاز به یاداشت وزارت امور خارجه برای اخذ ویزا دارید؟");
        //            row.CreateCell(14).SetCellValue("آیا سفر مشترک بین چند دستگاه اجرایی است؟");
        //            row.CreateCell(15).SetCellValue("شماره تاریخ نامه و مقام پیشنهاد دهنده داخلی دستگاه");
        //            //row.CreateCell(15).SetCellValue("شهر");


        //            int counter = 0;

        //            foreach (var item in adm)
        //            {
        //                counter += 1;
        //                row = excelSheet.CreateRow(counter);
        //                row.CreateCell(0).SetCellValue(counter);
        //                row.CreateCell(1).SetCellValue(item.ExecutiveDeviceName);
        //                row.CreateCell(2).SetCellValue(item.InternetAddressOfTheExecutiveDevice);
        //                row.CreateCell(3).SetCellValue(item.Agent?.City?.CountryName);
        //                row.CreateCell(4).SetCellValue(item.Agent?.CityName);
        //                row.CreateCell(5).SetCellValue(item.FlightPath);
        //                row.CreateCell(6).SetCellValue(item.TravelDateStart);
        //                row.CreateCell(7).SetCellValue(item.TravelTime);
        //                row.CreateCell(8).SetCellValue(item.TravelTopic);
        //                row.CreateCell(9).SetCellValue(item.TravelGoalID);
        //                row.CreateCell(10).SetCellValue(item.JobGoalID);
        //                row.CreateCell(11).SetCellValue(item.TypeOfEmployment?.TypeOfEmploymentTitle);
        //                row.CreateCell(12).SetCellValue(item.Position?.PositionType);
        //                row.CreateCell(13).SetCellValue(item.RegisterTime);
        //                row.CreateCell(14).SetCellValue(item.RegisterDate);
        //                row.CreateCell(15).SetCellValue(item.City?.CityName);

        //            }


        //            workbook.Write(fs);
        //        }

        //        using (var stream = new FileStream(filePath, FileMode.Open))
        //        {
        //            await stream.CopyToAsync(memory);
        //        }
        //        memory.Position = 0;


        //        return filePath;



        //    }

        //    catch (System.Exception ex)
        //    {
        //        return null;

        //    }
        //}
    }
}
