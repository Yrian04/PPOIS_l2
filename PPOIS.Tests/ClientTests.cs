namespace PPOIS_l2.Tests
{
    [TestClass()]
    public class ClientTests
    {
        [TestMethod()]
        public void ClientTest()
        {
            new CrutchServer();
            Server.Instance!.CreateClient("Client");
            Client expecped = Server.Instance!.GetClient("Client")!;
            Client? actual = Server.Instance?.GetClient("Client");

            Assert.AreEqual(actual, expecped);
        }
    }
}