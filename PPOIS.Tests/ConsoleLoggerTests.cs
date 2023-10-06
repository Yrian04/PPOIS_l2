namespace PPOIS_l2.Tests
{
    [TestClass()]
    public class ConsoleLoggerTests
    {
        [TestMethod()]
        public void LogLetterEditedTest()
        {
            //arrange
            new CrutchServer();

            Server.Instance!.CreateClient("Sender");
            Server.Instance!.CreateClient("Receiver");

            Client sender = Server.Instance!.GetClient("Sender")!;
            Client receiver = Server.Instance!.GetClient("Receiver")!;

            ILetterEditor letterEditor = new ConsoleLetterEditor();

            StringReader stringReader = new("Header\r\nBody\r\nHeader1\r\nBody1\r\n");
            Console.SetIn(stringReader);

            Letter letter = letterEditor.Create(sender, receiver);

            new ConsoleLogger();

            StringWriter stringWriter = new();
            Console.SetOut(stringWriter);
            string[] expected =
            {
                "Old header: Header",
                "Type new: ",
                "Old body: Body",
                "Type new: ",
                $"Letter Header: Header1\n\tFrom Client Sender to Client Receiver has edited at {DateTime.Now}"
            };

            //act
            letterEditor.Edit(ref letter);

            //assert
            string[] actual = stringWriter.ToString().Split(Environment.NewLine, StringSplitOptions.RemoveEmptyEntries);
            CollectionAssert.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void LogLetterCreatedTest()
        {
            //arrange
            new CrutchServer();

            Server.Instance!.CreateClient("Sender");
            Server.Instance!.CreateClient("Receiver");

            Client sender = Server.Instance!.GetClient("Sender")!;
            Client receiver = Server.Instance!.GetClient("Receiver")!;

            ILetterEditor letterEditor = new ConsoleLetterEditor();

            StringReader stringReader = new("Header\r\nBody\r\nHeader1\r\nBody1\r\n");
            Console.SetIn(stringReader);

            new ConsoleLogger();

            StringWriter stringWriter = new();
            Console.SetOut(stringWriter);

            //act
            Letter letter = letterEditor.Create(sender, receiver);

            //assert
            string[] expected =
            {
                "Type letter header: ",
                "Type letter body: ",
                $"Letter from Sender to Receiver has created at {DateTime.Now}"
            };

            string[] actual = stringWriter.ToString().Split(Environment.NewLine, StringSplitOptions.RemoveEmptyEntries);
            CollectionAssert.AreEqual(expected, actual, stringWriter.ToString());

        }

        [TestMethod()]
        public void LogLetterReceivedTest()
        {
            //arrange
            new CrutchServer();

            Server.Instance!.CreateClient("Sender");
            Server.Instance!.CreateClient("Receiver");

            Client sender = Server.Instance!.GetClient("Sender")!;
            Client receiver = Server.Instance!.GetClient("Receiver")!;

            StringReader stringReader = new("Header\r\nBody\r\nReceiver\r\n");
            Console.SetIn(stringReader);

            (Server.Instance! as CrutchServer)!.ReceivedLetter = new Letter(sender, receiver, "Header", "Body");

            new ConsoleLogger();

            StringWriter stringWriter = new();
            Console.SetOut(stringWriter);

            //act
            Server.Instance!.ReceiveLetter();

            //assert
            string expected = $"Letter Header has received to Receiver at {DateTime.Now}\r\n";
            string actual = stringWriter.ToString();

            Assert.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void LogLetterReceivedNullTest()
        {
            //arrange
            new CrutchServer();

            new ConsoleLogger();

            StringWriter stringWriter = new();
            Console.SetOut(stringWriter);

            //act
            Server.Instance!.ReceiveLetter();

            //assert
            string expected = "No one letter has received\r\n";
            string actual = stringWriter.ToString();

            Assert.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void LogLetterSentTest()
        {
            //arrange
            new CrutchServer();

            Server.Instance!.CreateClient("Sender");
            Server.Instance!.CreateClient("Receiver");

            Client sender = Server.Instance!.GetClient("Sender")!;

            StringReader stringReader = new("Receiver\r\nHeader\r\nBody\r\n");
            Console.SetIn(stringReader);

            sender.CreateClientLetter(new ConsoleLetterEditor());

            new ConsoleLogger();

            StringWriter stringWriter = new();
            Console.SetOut(stringWriter);

            //act
            sender.SendClientLetters(0);

            //assert
            string expected = $"Letter Header has sent at {DateTime.Now}\r\n";
            string actual = stringWriter.ToString();

            Assert.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void LogServerCreatedTest()
        {
            //arrange
            new ConsoleLogger();

            StringWriter stringWriter = new();
            Console.SetOut(stringWriter);

            //act
            new CrutchServer();

            //assert
            string expected = $"Server has created at {DateTime.Now}\r\n";
            string actual = stringWriter.ToString();

            Assert.AreEqual(expected, actual);
        }
    }
}