using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WatchList.Core.Services.Interfaces
{
    public interface IEmailService
    {
        void SendRegistrationEmail(string emailAddress, string userName, Guid id);
        void SendForgottenPasswordEmail(string emailAddress, string userName, Guid id);
        void SendEmailAddressConfirmation(string emailAddress, string userName, Guid id);
    }
}
