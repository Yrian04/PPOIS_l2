using System.Reflection.PortableExecutable;
using System.Reflection;

namespace PPOIS_l2
{
    public record Letter
    {
        public Client Sender { get; init; }
        public Client Receiver { get; init; }
        public string Header { get; set; }
        public string Body { get; set; }

        public Letter(Client sender, Client receiver, string header, string body)
        {
            Sender = sender;
            Receiver = receiver;
            Header = header;
            Body = body;

            Logger.Instance?.LogLetterCreated(this);
        }
        public override string ToString() => $"Header: {Header}\n\tFrom {Sender} to {Receiver}";
    }
}