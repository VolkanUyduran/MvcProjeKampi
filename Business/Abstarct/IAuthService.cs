using Entity.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstarct
{
   public interface IAuthService
    {
        void AdminRegister(string adminUserName, string adminMail, string password, int adminRole, int status);
        bool AdminLogIn(LoginDto LoginDto);

        void WriterRegister(string writerName, string writerSurName, string writerTitle, string writerAbout, string writerImage, string writerUserName, string writerMail, string password, bool WriterStatus);
        bool WriterLogIn(WriterLoginDto writerLogInDto);
    }
}
