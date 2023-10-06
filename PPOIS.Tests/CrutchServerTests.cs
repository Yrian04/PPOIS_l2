using Microsoft.VisualStudio.TestTools.UnitTesting;
using PPOIS_l2;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PPOIS_l2.Tests
{
    [TestClass()]
    public class CrutchServerTests
    {
        [TestMethod()]
        public void ReceiveLetterTest()
        {
            //arrange
            new CrutchServer();

            Server.Instance!.CreateClient("Sender");
            Server.Instance!.CreateClient("Receiver");

            Client sender = Server.Instance!.GetClient("Sender")!;
            Client receiver = Server.Instance!.GetClient("Receiver")!;

            Letter expected = new Letter(sender, receiver, "Header", "Body");
            (Server.Instance! as CrutchServer)!.ReceivedLetter = expected;

            //act
            Server.Instance.ReceiveLetter();

            //assert
            Letter? actual = receiver.Mailbox.GetLetter(0);
            Assert.AreEqual(expected, actual);
        }
    }
}