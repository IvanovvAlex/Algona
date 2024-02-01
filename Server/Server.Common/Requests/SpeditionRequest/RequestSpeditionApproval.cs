namespace Server.Common.Requests.SpeditionRequest
{
    /// <summary>
    /// Request approval for Transport view model
    /// </summary>
    public class RequestSpeditionApproval
    {
        /// <summary>
        /// Id of the spedition request
        /// </summary>
        public string Id { get; set; } = null!;

        /// <summary>
        /// Is the spedition request approved
        /// </summary>
        public bool IsApproved { get; set; }
    }
}
