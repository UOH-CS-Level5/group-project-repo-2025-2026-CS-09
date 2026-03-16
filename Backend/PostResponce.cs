namespace Backend
{
    public class PostResponce
    {
        private readonly SQLAccess SQLAccess;

        public PostResponce(SQLAccess SQLAccess)
        {
            this.SQLAccess = SQLAccess;
        }

        public List<string> studentNames(int postID)
        {
            try
            {
                string sql = "SELECT u.Name FROM Users u JOIN PostResponce p ON u.UserID = p.StudentID WHERE p.PostID = " + postID;
                List<string> studentNames = SQLAccess.readFromDatabase(sql).Cast<string>().ToList();
                return studentNames;
            }
            catch { }
            return null;
        }

        public List<int> responceType(int postID)
        {
            try
            {
                string sql = "SELECT ResponceType FROM PostResponce WHERE postID = " + postID;
                List<int> responce = SQLAccess.readFromDatabase(sql).Cast<int>().ToList();
                return responce;
            }
            catch { }
            return null;
        }

        public List<string> responceText(int postID)
        {
            try
            {
                string sql = "SELECT Text FROM PostResponce WHERE PostID = " + postID;
                List<string> text = SQLAccess.readFromDatabase(sql).Cast<string>().ToList();
                return text;
            }
            catch { }
            return null;
        }
    }
}
