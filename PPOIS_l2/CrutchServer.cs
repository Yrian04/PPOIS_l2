namespace PPOIS_l2
{
    public class CrutchServer : Server
    {
        private ClientBase clientBase = new ClientBase();
        public Letter? ReceivedLetter { get; set; }

        public CrutchServer() : base() { ReceivedLetter = null; }

        public override void CreateClient(string name) => clientBase.CreateClient(name);

        public override Client? GetClient(string name) => clientBase.GetClient(name);

        public override void ReceiveLetter()
        {
            ReceivedLetter?.Receiver.Mailbox.AddLetter(ReceivedLetter);
            Logger.Instance?.LogLetterReceived(ReceivedLetter);

            ReceivedLetter = null;
        }

        public override void SendLetter(Letter letter) => Logger.Instance?.LogLetterSent(letter);

    }
}
