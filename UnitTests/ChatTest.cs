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
        public void newChat()
        {
            chat = new Chat(SQLAccess);
        }
        [TestMethod]
        public void getMessages()
        {
            bool test = chat.getMessages(1);
        }
    }
}
