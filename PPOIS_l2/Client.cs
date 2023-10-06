namespace PPOIS_l2
{
    public class Client
    {
        public string Name { get; init; }
        internal Mailbox Mailbox { get; init; }

        internal Client(string name)
        {
            Name = name;
            Mailbox = new Mailbox();
            Logger.Instance?.LogClientCreated(this);
        }

        public void ShowAllClientLetters(ILetterViewer viewer) => viewer.ViewLetters(Mailbox.GetAllLetters());

        public void ShowClientLetter(ILetterViewer viewer, int index)
        {
            Letter? letter = Mailbox.GetLetter(index);
            if (letter is not null)
                viewer.ViewLetters(letter);
        }

        public virtual void CreateClientLetter(ILetterEditor editor)
        {
            Client receiver = RequestReceiver();
            Letter letter = editor.Create(this, receiver);
            Mailbox.AddLetter(letter);
        }

        public void SendClientLetters(int index)
        {
            Letter? letter = Mailbox.GetLetter(index);
            if (letter is null)
            {
                Console.WriteLine("Letter not exist");
                return;
            }
            Server.Instance?.SendLetter(letter);
            Mailbox.RemoveLetter(index);
        }

        private Client RequestReceiver()
        {
            Client? receiver;
            string? name;
            do
            {
                do
                {
                    Console.WriteLine("Type name of receiver: ");
                    name = Console.ReadLine();
                } 
                while (name is null);
                receiver = Server.Instance?.GetClient(name);
            } 
            while (receiver is null);

            return receiver;
        }

        public override string ToString() => $"Client {Name}";
    }
}
