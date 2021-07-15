using Business.Abstarct;
using Business.Utilities.Hashing;
using Entity.Concrete;
using Entity.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class AuthManager : IAuthService
    {
        IAdminService _adminService;
        IWriterService _writerService;

        public AuthManager(IAdminService adminService)
        {
            _adminService = adminService;
        }

        public AuthManager(IWriterService writerService)
        {
            _writerService = writerService;
        }

        public AuthManager(IAdminService adminService, IWriterService writerService)
        {
            _adminService = adminService;
            _writerService = writerService;
        }
        public bool AdminLogIn(LoginDto loginDto)
        {
            using (var crypto = new System.Security.Cryptography.HMACSHA512())
            {
                byte[] mailHash = crypto.ComputeHash(Encoding.UTF8.GetBytes(loginDto.AdminMail));
                var admin = _adminService.GetAdmins();
                foreach (var item in admin)
                {
                    if (HashingHelper.AdminVerifyPasswordHash(loginDto.AdminMail, loginDto.AdminPassword, item.AdminMail,
                        item.AdminPasswordHash, item.AdminPasswordSalt))
                    {
                        return true;
                    }
                }
                return false;
            }
        }

        public void AdminRegister(string adminUserName, string adminMail, string password, int adminRole, int status)
        {
            byte[] mailHash, passwordHash, passwordSalt;
            HashingHelper.AdminCreatePasswordHash(adminMail, password, out mailHash, out passwordHash, out passwordSalt);
            var admin = new Admin
            {
                AdminUserName = adminUserName,
                AdminMail = mailHash,
                AdminPasswordHash = passwordHash,
                AdminPasswordSalt = passwordSalt,
                RoleId = adminRole,
                StatusId = status
            };
            _adminService.Add(admin);
        }

        //------------------------- WRITER -----------------------------\\

        public bool WriterLogIn(WriterLoginDto writerLogInDto)
        {
            using (var crypto = new System.Security.Cryptography.HMACSHA512())
            {
                //var mailHash = crypto.ComputeHash(Encoding.UTF8.GetBytes(writerLogInDto.WriterMail));
                var writer = _writerService.GetList();
                foreach (var item in writer)
                {
                    if (HashingHelper.WriterVerifyPasswordHash(writerLogInDto.WriterPassword,
                        item.WriterPasswordHash, item.WriterPasswordSalt))
                    {
                        return true;
                    }
                }
                return false;
            }
        }

        public void WriterRegister(string writerName, string writerSurName, string writerTitle, string writerAbout, string writerImage, string writerUserName, string writerMail, string password, bool WriterStatus)
        {
            byte[] mailHash, passwordHash, passwordSalt;
            HashingHelper.WriterCreatePasswordHash(password, out passwordHash, out passwordSalt);
            var writer = new Writer
            {
                WriterName = writerName,
                WriterSurname = writerSurName,
                WriterTitle = writerTitle,
                WriterAbout = writerAbout,
                WriterImage = writerImage,
                WriterUserName = writerUserName,
                WriterMail = writerMail,
                WriterPasswordHash = passwordHash,
                WriterPasswordSalt = passwordSalt,
                WriterStatus = WriterStatus
            };
            _writerService.Add(writer);
        }

    }
}
