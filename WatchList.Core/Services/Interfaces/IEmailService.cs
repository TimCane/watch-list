namespace WatchList.Core.Services.Interfaces
{
    public interface IEmailService
    {
        void SendRegistrationEmail(string emailAddress, string name, Guid id);
        void SendForgottenPasswordEmail(string emailAddress, string name, Guid id);
        void SendEmailAddressConfirmation(string emailAddress, string name, Guid id);
        void SendEmailAddressAlreadyConfirmation(string emailAddress, string name);
    }
}
