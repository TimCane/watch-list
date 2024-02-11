using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WatchList.Core.Services.Interfaces
{
    public interface IEmailService
    {
        void SendRegistrationEmail(string dbUserEmailAddress, string dbUserName, Guid id);
        void SendForgottenPasswordEmail(string dbUserEmailAddress, string dbUserName, Guid id);
    }
}
