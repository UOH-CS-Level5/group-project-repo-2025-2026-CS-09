namespace Backend
{
    public class Login
    {
        private readonly SQLAccess SQLAccess;


        public Login(SQLAccess SQLAccess)
        {
            this.SQLAccess = SQLAccess;
        }
        public bool passwordCheck(int userID, string password) //Returns true if the password matches the stored password of the userID given. If not a valid ID, returns false
        {
            string sql = @"Select Users.Password FROM Users WHERE Users.UserID = " + userID.ToString();
            List<string> passwordCheck = SQLAccess.readFromDatabase(sql).Cast<string>().ToList();
            if (!(passwordCheck.Count == 0))
            {
                if (passwordCheck[0] == password) { return true; }
                else { return false; }
            }
            else { return false; }
        }
    }
}