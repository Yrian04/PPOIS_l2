namespace PPOIS_l2.Tests
{
    [TestClass()]
    public class MailboxTests
    {
        [TestMethod]
        public void GetLetterTest()
        {
            new CrutchServer();
            Server.Instance!.CreateClient("Sender");
            Server.Instance!.CreateClient("Receiver");

            Client sender = Server.Instance!.GetClient("Sender")!;
            Client receiver = Server.Instance!.GetClient("Receiver")!;
            Letter actual = new Letter(sender, receiver, "Header", "Body");
            Mailbox mailbox = new Mailbox(actual);

            Letter? expected = mailbox.GetLetter(0);

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void GetLetterEmptyMailboxTest()
        {
            Mailbox mailbox = new Mailbox();

            Letter? value = mailbox.GetLetter(0);

            Assert.IsNull(value);  
        }

        [TestMethod, ExpectedException(typeof(ArgumentOutOfRangeException))]
        [DataRow(-1)]
        [DataRow(1)]
        public void GetLetterInvalidIndexTest(int value)
        {
            new CrutchServer();
            Server.Instance!.CreateClient("Sender");
            Server.Instance!.CreateClient("Receiver");

            Client sender = Server.Instance!.GetClient("Sender")!;
            Client receiver = Server.Instance!.GetClient("Receiver")!;
            Letter letter = new Letter(sender, receiver, "Header", "Body");
            Mailbox mailbox = new Mailbox(letter);

            mailbox.GetLetter(value);
        }

        [TestMethod]
        public void GetLetterRangeTest()
        {
            new CrutchServer();
            Server.Instance!.CreateClient("Sender");
            Server.Instance!.CreateClient("Receiver");

            Client sender = Server.Instance!.GetClient("Sender")!;
            Client receiver = Server.Instance!.GetClient("Receiver")!;

            Letter letter = new Letter(sender, receiver, "Header", "Body");
            Letter letter1 = new Letter(sender, receiver, "Header1", "Body");
            Letter letter2 = new Letter(sender, receiver, "Header2", "Body");
            Letter[] expected = new[] { letter, letter1, letter2 };

            Mailbox mailbox = new Mailbox(expected);

            Letter[] actual = mailbox.GetLetter(0, 2);

            CollectionAssert.AreEquivalent(expected, actual);  
        }

        [TestMethod, ExpectedException(typeof(IndexOutOfRangeException))]
        [DataRow(-1, 0)]
        [DataRow(1, 62)]
        public void GetLetterRangeInvalidIndex(int s, int e)
        {
            new CrutchServer();
            Server.Instance!.CreateClient("Sender");
            Server.Instance!.CreateClient("Receiver");

            Client sender = Server.Instance!.GetClient("Sender")!;
            Client receiver = Server.Instance!.GetClient("Receiver")!;

            Letter letter = new Letter(sender, receiver, "Header", "Body");
            Letter letter1 = new Letter(sender, receiver, "Header1", "Body");
            Letter letter2 = new Letter(sender, receiver, "Header2", "Body");
            Letter[] letters = new[] { letter, letter1, letter2 };

            Mailbox mailbox = new Mailbox(letters);

            mailbox.GetLetter(s, e);
        }

        [TestMethod, ExpectedException(typeof(Exception))]
        [DataRow(2, 0)]
        [DataRow(1, -4)]
        public void GetLetterRangeEndLessThenStart(int s, int e)
        {
            new CrutchServer();
            Server.Instance!.CreateClient("Sender");
            Server.Instance!.CreateClient("Receiver");

            Client sender = Server.Instance!.GetClient("Sender")!;
            Client receiver = Server.Instance!.GetClient("Receiver")!;

            Letter letter = new Letter(sender, receiver, "Header", "Body");
            Letter letter1 = new Letter(sender, receiver, "Header1", "Body");
            Letter letter2 = new Letter(sender, receiver, "Header2", "Body");
            Letter[] letters = new[] { letter, letter1, letter2 };

            Mailbox mailbox = new Mailbox(letters);

            mailbox.GetLetter(s, e);
        }
    }
}
