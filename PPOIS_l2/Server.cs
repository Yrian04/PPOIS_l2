namespace PPOIS_l2
{
    public abstract class Server
    {
        public static Server? Instance { get; private set; }
        public Server()
        {
            if (Instance == null)
                Instance = this;
            Logger.Instance?.LogServerCreated(this);
        }

        public abstract Client? GetClient(string name);
        public abstract void CreateClient(string name);
        public abstract void SendLetter(Letter letter);
        public abstract void ReceiveLetter();
    }
}
