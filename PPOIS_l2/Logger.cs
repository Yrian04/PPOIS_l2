namespace PPOIS_l2
{
    public abstract class Logger
    {
        public static Logger? Instance { get; private set; } = null;

        public Logger()
        {
            if (Instance == null)
            {
                Instance = this;
            }
        }

        abstract public void LogLetterCreated(Letter letter);
        abstract public void LogLetterEdited(Letter letter);
        abstract public void LogLetterSent(Letter letter);
        abstract public void LogLetterReceived(Letter? letter);
        abstract public void LogServerCreated(Server server);
        abstract internal void LogClientCreated(Client client);
    }
}
