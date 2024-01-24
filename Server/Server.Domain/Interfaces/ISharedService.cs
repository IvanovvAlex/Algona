namespace Server.Domain.Interfaces
{
    using Common.Requests.ContactRequests;

    public interface ISharedService
    {
        Task EmailSender(CreateContactRequest request);
    }
}
