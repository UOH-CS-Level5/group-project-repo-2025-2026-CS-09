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

        public List<string> posterName(int userID)
        {
            try
            {
                string sql = @"SELECT u.Name FROM Users u JOIN Posts p ON u.UserID = p.SocietyID JOIN SocietyMembers s ON p.SocietyID = s.SocietyID WHERE s.StudentID = " + userID + " ORDER BY p.PostTime";
                List<string> socNames = SQLAccess.readFromDatabase(sql).Cast<string>().ToList();
                return socNames;
            }
            catch { }
            return null;
        }

        public List<string> postTitles(int userID)
        {
            try
            {
                string sql = @"SELECT p.Title FROM Posts p JOIN SocietyMembers s ON p.SocietyID = s.SocietyID JOIN Users u ON s.StudentID = u.UserID WHERE u.UserID = " + userID + " ORDER BY p.PostTime";
                List<String> postTitles = SQLAccess.readFromDatabase(sql).Cast<string>().ToList();
                return postTitles;
            }
            catch { }
            return null;
        }

        public List<string> postText(int userID)
        {
            try
            {
                string sql = @"SELECT p.Text FROM Posts p JOIN SocietyMembers s ON p.SocietyID = s.SocietyID JOIN Users u ON s.StudentID = u.UserID WHERE u.UserID = " + userID + " ORDER BY p.PostTime";
                List<String> postTitles = SQLAccess.readFromDatabase(sql).Cast<string>().ToList();
                return postTitles;
            }
            catch { }
            return null;
        }

        public List<DateTime> postTime(int userID)
        {
            try
            {
                string sql = @"SELECT p.PostTime FROM Posts p JOIN SocietyMembers s ON p.SocietyID = s.SocietyID JOIN Users u ON s.StudentID = u.UserID WHERE u.UserID = " + userID + " ORDER BY P.PostTime";
                List<DateTime> postTime = SQLAccess.readFromDatabase(sql).Cast<DateTime>().ToList();
                return postTime;
            }
            catch { }
            return null;
        }
    }
}
