using System.Reflection.Metadata;

namespace Backend
{
    public class Posts
    {
        private readonly SQLAccess SQLAccess;
        private int? socID;

        public Posts(SQLAccess SQLAccess, int userID)
        {
            this.SQLAccess = SQLAccess;
            socID = null;

            try
            {
                string sql = @"SELECT s.SocietyID FROM SocietyMembers s JOIN Users u ON s.StudentID = u.UserID JOIN Users a ON s.SocietyID = a.UserID WHERE a.UserID = " + userID;
                socID = SQLAccess.readFromDatabase(sql).Cast<int>().ToList()[0];
            }
            catch { }
        }


        public List<int> SocIDs(int userID)
        {
            try
            {
                string sql = @"SELECT s.SocietyID FROM SocietyMembers s JOIN Users u ON s.StudentID = u.UserID JOIN Users a ON s.SocietyID = a.UserID WHERE u.UserID = " + userID + " OR a.UserID = " + userID;
                List<int> socIDs = SQLAccess.readFromDatabase(sql).Cast<int>().ToList();
                return socIDs;
            }
            catch { }
            return null;
        }

        /*public List<int> seSocIDs(int userID)
        {
            try
            {
                string sql = @"SELECT s.SocietyID FROM SocietyMembers s JOIN Users u ON s.SocietyID = u.UserID WHERE u.UserID = " + userID;
                List<int> socIDs = SQLAccess.readFromDatabase(sql).Cast<int>().ToList();
                return socIDs;
            }
            catch { }
            return null;
        }*/

        public List<string> posterName(int userID)
        {
            try
            {
                string sql = @"SELECT u.Name FROM Users u JOIN Posts p ON u.UserID = p.SocietyID WHERE p.SocietyID = " + socID + " ORDER BY p.PostTime";
                List<string> socNames = SQLAccess.readFromDatabase(sql).Cast<string>().ToList();
                return socNames;
            }
            catch
            {
                try
                {
                    string sql = @"SELECT u.Name FROM Users u JOIN Posts p ON u.UserID = p.SocietyID JOIN SocietyMembers s ON p.SocietyID = s.SocietyID WHERE s.StudentID = " + userID + "ORDER BY p.PostTime";
                    List<string> socNames = SQLAccess.readFromDatabase(sql).Cast<string>().ToList();
                    return socNames;
                }
                catch { }
            }
            
            return null;
        }

        public List<string> postTitles(int userID)
        {
            try
            {
                string sql = @"SELECT Title FROM Posts WHERE SocietyID = " + socID + " ORDER BY PostTime";
                List<string> postTitles = SQLAccess.readFromDatabase(sql).Cast<string>().ToList();
                return postTitles;
            }
            catch
            {
                try
                {
                    string sql = @"SELECT p.Title FROM Posts p JOIN SocietyMembers s ON p.SocietyID = s.SocietyID JOIN Users u ON s.StudentID = u.UserID WHERE u.UserID = " + userID + " ORDER BY p.PostTime";
                    List<String> postTitles = SQLAccess.readFromDatabase(sql).Cast<string>().ToList();
                    return postTitles;
                }
                catch { }
            }
            return null;
        }

        public List<string> postText(int userID)
        {
            try
            {
                string sql = @"SELECT Text FROM Posts WHERE SocietyID = " + socID + " ORDER BY PostTime";
                List<String> postText = SQLAccess.readFromDatabase(sql).Cast<string>().ToList();
                return postText;
            }
            catch
            {
                try
                {
                    string sql = @"SELECT p.Text FROM Posts p JOIN SocietyMembers s ON p.SocietyID = s.SocietyID JOIN Users u ON s.StudentID = u.UserID WHERE u.UserID = " + userID + " ORDER BY p.PostTime";
                    List<String> postText = SQLAccess.readFromDatabase(sql).Cast<string>().ToList();
                    return postText;
                }
                catch { }
            }
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

        public bool newPost(int socID, string title, string text)
        {
            DateTime postTime = DateTime.Now;

            string postCount = "SELECT PostID FROM Posts";
            List<int> postIDs = SQLAccess.readFromDatabase(postCount).Cast<int>().ToList();

            string sql = "INSERT INTO Posts VALUES (" + (postIDs.Count + 1) + ", " + socID + ", '" + title + "', '" + text + "', null, '" + postTime.ToString("yyyy-MM-dd HH:mm:ss") + "')";

            try
            {
                SQLAccess.writeToDatabase(sql);
                return true;
            }
            catch { return false; }
        }
    }
}
