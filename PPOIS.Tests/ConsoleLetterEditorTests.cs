namespace PPOIS_l2.Tests
{
    [TestClass()]
    public class ConsoleLetterEditorTests
    {
        [TestMethod()]
        public void CreateTest()
        {
            //arrange
            new CrutchServer();
            Server.Instance!.CreateClient("Sender");
            Server.Instance!.CreateClient("Receiver");

            Client sender = Server.Instance!.GetClient("Sender")!;
            Client receiver = Server.Instance!.GetClient("Receiver")!;

            Letter expected = new(sender, receiver, "Header", "Body");

            ILetterEditor letterEditor = new ConsoleLetterEditor();

            StringWriter out_ = new();
            string s = "Header\nBody\n";
            StringReader in_ = new(s);
            Console.SetOut(out_);
            Console.SetIn(in_);

            //act
            Letter actual = letterEditor.Create(sender, receiver);

            //assert
            Assert.AreEqual(expected, actual);

        }

        [TestMethod()]
        public void EditTest()
        {
            //arrange
            new CrutchServer();
            Server.Instance!.CreateClient("Sender");
            Server.Instance!.CreateClient("Receiver");

            Client sender = Server.Instance!.GetClient("Sender")!;
            Client receiver = Server.Instance!.GetClient("Receiver")!;

            Letter actual = new(sender, receiver, "Header", "Body");
            Letter expected = actual with { Header = "Header1", Body = "Body1" };

            ILetterEditor letterEditor = new ConsoleLetterEditor();

            new ConsoleLogger();
            StringWriter out_ = new();
            string s = "Header1\nBody1\n";
            StringReader in_ = new(s);
            Console.SetOut(out_);
            Console.SetIn(in_);

            //act
            letterEditor.Edit(ref actual);

            //assert
            Assert.AreEqual(expected, actual);
        }
    }
}