namespace PPOIS_l2.Tests
{
    [TestClass()]
    public class ClientBaseTests
    {
        [TestMethod()]
        public void CreateClientTest()
        {
            //arrange
            ClientBase _base = new();

            //act
            _base.CreateClient("Client");

            //assert
            Assert.IsTrue(_base.IsClientExists("Client"));
        }
    }
}