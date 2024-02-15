using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Net.Mime;
using System.Text;
using System.Threading.Tasks;
using WatchList.Core.Models;
using WatchList.Core.Services.Interfaces;

namespace WatchList.Core.Services
{
    public class EmailService : IEmailService
    {
        private readonly SmtpSettings _smtpSettings;

        public EmailService(IOptions<SmtpSettings> smtpSettings)
        {
            _smtpSettings = smtpSettings.Value;
        }
        
        public void SendRegistrationEmail(string emailAddress, string name, Guid emailVerificationId)
        {
            SendEmail(emailAddress, "REGISTRATION EMAIL", $"Hi {name}, {Environment.NewLine} Verify your email using the following code: {emailVerificationId}");
        }

        public void SendForgottenPasswordEmail(string emailAddress, string name, Guid forgottenPasswordId)
        {
            SendEmail(emailAddress, "FORGOTTEN PASSWORD EMAIL", $"Hi {name}, {Environment.NewLine} Reset your password using the following code: {forgottenPasswordId}");
        }

        public void SendEmailAddressConfirmation(string emailAddress, string name, Guid emailVerificationId)
        {
            SendEmail(emailAddress, "EMAIL CONFIRMATION CODE", $"Hi {name}, {Environment.NewLine} Verify your email using the following code: {emailVerificationId}");
        }

        public void SendEmailAddressAlreadyConfirmation(string emailAddress, string name)
        {
            SendEmail(emailAddress, "Your email is already verified", $"Hi {name}, {Environment.NewLine} Your email has already been verified");
        }

        private void SendEmail(string emailAddress, string subject, string body)
        {
            try
            {
                var newMail = new MailMessage
                {
                    Body = body,
                    From = new MailAddress(_smtpSettings.SmtpSender, "Watch List"),
                    IsBodyHtml = false,
                    Priority = MailPriority.Normal,
                    Subject = subject,
                    To = { emailAddress }
                };

                if (_smtpSettings.SmtpUsePickupDirectory)
                {
                    SendEmailToSpecifiedPickupDirectory(newMail);
                }
                else
                {
                    SendEmailToNetwork(newMail);
                }

            }
            catch (Exception ex)
            {
                Console.WriteLine("Error -" + ex);
            }
        }

        private void SendEmailToNetwork(MailMessage mailMessage)
        {
            //TODO: IMPLEMENT NETWORK MAIL.
        }

        private void SendEmailToSpecifiedPickupDirectory(MailMessage mailMessage)
        {
            var client = new SmtpClient
            {
                DeliveryMethod = SmtpDeliveryMethod.SpecifiedPickupDirectory,
                PickupDirectoryLocation = _smtpSettings.SmtpPickupDirectory,
            };

            client.Send(mailMessage);
        }
    }
}
