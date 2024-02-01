namespace Server.Common.Requests.TransportRequest
{
    /// <summary>
    /// Request approval for Transport view model
    /// </summary>
    public class RequestTransportApproval
    {
        /// <summary>
        /// Id of the transport request
        /// </summary>
        public string Id { get; set; } = null!;

        /// <summary>
        /// Is the transport request approved
        /// </summary>
        public bool IsApproved { get; set; }
    }
}
