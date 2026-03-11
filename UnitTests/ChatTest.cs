using Backend;

namespace UnitTests
{
    [TestClass]
    public sealed class ChatTest
    {
        private SQLAccess SQLAccess;
        private Chat chat;
        
        [TestInitialize]
        public void SetUp()
        {
            SQLAccess = new SQLAccess();
            chat = new Chat(SQLAccess);
        }
        
        [TestMethod]
        public void newChatClass()
        {
            chat = new Chat(SQLAccess);
        }

        [TestMethod]
        public void userChatNames()
        {
            List<string> names = chat.usersChatNames(3);
            Assert.AreEqual("General CS Chat", names[0]);
        }

        [TestMethod]
        public void userChatID()
        {
            List<int> ids = chat.userChatIDs(3);
            Assert.AreEqual(1, ids[0]);
        }

        /*[TestMethod]
        public void getMessages()
        {
            bool test = chat.getMessages(1);
        }*/
    }
}
