using System.Reflection.Metadata;

namespace Backend
{
    public class Posts
    {
        private readonly SQLAccess SQLAccess;

        public Posts(SQLAccess SQLAccess)
        {
            this.SQLAccess = SQLAccess;
        }


        public List<int> usersSocIDs(int userID)
        {
            try
            {
                string sql = @"SELECT s.SocietyID FROM SocietyMembers s JOIN Users u ON s.StudentID = u.UserID WHERE u.UserID = " + userID;
                List<int> socIDs = SQLAccess.readFromDatabase(sql).Cast<int>().ToList();
                return socIDs;
            }
            catch { }
            return null;
        }


    }
}
