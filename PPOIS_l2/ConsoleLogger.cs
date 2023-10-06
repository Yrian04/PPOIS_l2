namespace PPOIS_l2
{
    public class ConsoleLogger : Logger
    {
        public ConsoleLogger() : base() { }
        internal override void LogClientCreated(Client client) => Console.WriteLine($"Client {client.Name} has created at {DateTime.Now}");
        public override void LogLetterEdited(Letter letter) => Console.WriteLine($"Letter {letter} has edited at {DateTime.Now}");

        public override void LogLetterCreated(Letter letter) => Console.WriteLine($"Letter from {letter.Sender.Name} to {letter.Receiver.Name} has created at {DateTime.Now}");

        public override void LogLetterReceived(Letter? letter)
        {
            if (letter == null) 
                Console.WriteLine("No one letter has received");
            else 
                Console.WriteLine($"Letter {letter!.Header} has received to {letter!.Receiver.Name} at {DateTime.Now}");
        }

        public override void LogLetterSent(Letter letter) => Console.WriteLine($"Letter {letter.Header} has sent at {DateTime.Now}");

        public override void LogServerCreated(Server server) => Console.WriteLine($"Server has created at {DateTime.Now}");
    }
}
