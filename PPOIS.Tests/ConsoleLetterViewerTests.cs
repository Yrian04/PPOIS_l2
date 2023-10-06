namespace PPOIS_l2.Tests
{
    [TestClass()]
    public class ConsoleLetterViewerTests
    {
        [TestMethod()]
        public void ViewLetterTest()
        {
            //arrange
            new CrutchServer();

            Server.Instance!.CreateClient("Sender");
            Server.Instance!.CreateClient("Receiver");

            Client sender = Server.Instance!.GetClient("Sender")!;
            Client receiver = Server.Instance!.GetClient("Receiver")!;

            Letter letter = new(sender, receiver, "Header", "Body");

            ConsoleLetterViewer viewer = new ConsoleLetterViewer();

            StringWriter stringWriter = new StringWriter();
            Console.SetOut(stringWriter);

            //act
            viewer.ViewLetters(letter);
            //assert
            string[] expected =
            {
                "============== 1 ==============",
                "\tHeader",
                "Body",
                "\tFrom: Sender",
                "\tTo: Receiver"
            };
            string[] actual = stringWriter.ToString().Split(Environment.NewLine, StringSplitOptions.RemoveEmptyEntries);

            CollectionAssert.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void ViewLetterWithoutLettersTest()
        {
            //arrange
            ConsoleLetterViewer viewer = new ConsoleLetterViewer();

            StringWriter stringWriter = new StringWriter();
            Console.SetOut(stringWriter);

            //act
            viewer.ViewLetters();

            //assert
            string expected = "There are no letters(\r\n";
            string actual = stringWriter.ToString();

            Assert.AreEqual(expected, actual);
        }
    }
}