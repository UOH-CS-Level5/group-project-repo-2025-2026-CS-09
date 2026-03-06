using Backend;

namespace UnitTests
{
    [TestClass]
    public sealed class LoginTests
    {
        private SQLAccess SQLAccess;
        private Login login;
        
        [TestInitialize]
        public void SetUp()
        {
            SQLAccess = new SQLAccess();
            login = new Login(SQLAccess);
        }
        
        [TestMethod]
        public void newLogin()
        {
            login = new Login(SQLAccess);
        }
        [TestMethod]
        public void passwordCheck()
        {
            //login = new Login(SQLAccess);
            bool test = login.passwordCheck(1, "socpass1");
        }
    }
}