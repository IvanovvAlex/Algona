namespace Server.Domain.Interfaces
{
    using Common.Requests.ContactRequests;

    public interface ISharedService
    {
        Task EmailSender(CreateContactRequest request);
        Task SendResetPasswordEmail(string toEmail, string resetToken);
        Task SendStatusRequestEmail(string toEmail, string requestForTransportOrSpedition, string status, string name);
    }
}
