namespace Backend
{
    public class Chat
    {
        private readonly SQLAccess SQLAccess;

        public Chat(SQLAccess SQLAccess)
        {
            this.SQLAccess = SQLAccess;
        }

        public List<string> usersChatNames(int userID)
        {
            try
            {
                string sql = @"SELECT c.ChatName FROM Chats c JOIN ChatMembers m ON c.ChatID = m.ChatID JOIN SocietyMembers s ON m.MembersID = s.MembersID JOIN Users u ON s.StudentID = u.UserID WHERE u.UserID = " + userID + "ORDER BY c.ChatID";
                List<string> chatNames = SQLAccess.readFromDatabase(sql).Cast<string>().ToList();
                //sql = @"SELECT c.ChatID FROM Chats c JOIN ChatMembers m ON c.ChatID = m.ChatID JOIN SocietyMembers s ON m.MembersID = s.MembersID JOIN Users u ON s.StudentID = u.UserID WHERE u.UserID = " + userID + "ORDER BY c.ChatID";
                //List<int> chatIDs = SQLAccess.readFromDatabase(sql).Cast<int>().ToList();
                return chatNames;
            }
            catch { }
            return null;
        }

        public List<int> userChatIDs(int userID)
        {
            try
            {
                string sql = @"SELECT c.ChatID FROM Chats c JOIN ChatMembers m ON c.ChatID = m.ChatID JOIN SocietyMembers s ON m.MembersID = s.MembersID JOIN Users u ON s.StudentID = u.UserID WHERE u.UserID = " + userID + "ORDER BY c.ChatID";
                List<int> chatIDs = SQLAccess.readFromDatabase(sql).Cast<int>().ToList();
                return chatIDs;
            }
            catch { }
            return null;
        }

        public bool getMessages(int chatID)
        {
            try
            {
                //Sender names in order
                string sql = @"SELECT u.Name FROM Users u JOIN Message m on m.SenderID = u.UserID WHERE m.ChatID = " + chatID.ToString() + " ORDER BY m.PostTime";
                List<String> senderNames = SQLAccess.readFromDatabase(sql).Cast<string>().ToList();

                //PostTime from chat in order
                sql = @"SELECT Message.PostTime FROM Message WHERE Message.ChatID = " + chatID.ToString() + " ORDER BY PostTime";
                List<DateTime> dateTimes = SQLAccess.readFromDatabase(sql).Cast<DateTime>().ToList();

                //Text from chat in order
                sql = @"SELECT Message.Text FROM Message WHERE Message.ChatID = " + chatID.ToString() + " ORDER BY PostTime";
                List<string> messages = SQLAccess.readFromDatabase(sql).Cast<string>().ToList();

                //Images from chat in order
                /*sql = @"SELECT Message.Image FROM Message WHERE Message.ChatID = " + chatID.ToString() + " ORDER BY PostTime";
                List<byte[]> images = SQLAccess.readFromDatabase(sql).Cast<byte[]>().ToList();*/

                if ((senderNames.Count == dateTimes.Count) && (senderNames.Count == messages.Count)) //== images.Count))
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch { return false; }
        }

        public List<string> senderName(int chatID)
        {
            try
            {
                string sql = @"SELECT u.Name FROM Users u JOIN Message m on m.SenderID = u.UserID WHERE m.ChatID = " + chatID.ToString() + " ORDER BY m.PostTime";
                List<String> senderNames = SQLAccess.readFromDatabase(sql).Cast<string>().ToList();
                return senderNames;
            }
            catch { }
            return null;
        }

        public List<DateTime> senderTime(int chatID)
        {
            try
            {
                string sql = @"SELECT Message.PostTime FROM Message WHERE Message.ChatID = " + chatID.ToString() + " ORDER BY PostTime";
                List<DateTime> dateTimes = SQLAccess.readFromDatabase(sql).Cast<DateTime>().ToList();
                return dateTimes;
            }
            catch { }
            return null;
        }

        public List<string> chatMessage(int chatID)
        {
            try
            {
                string sql = @"SELECT Message.Text FROM Message WHERE Message.ChatID = " + chatID.ToString() + " ORDER BY PostTime";
                List<string> messages = SQLAccess.readFromDatabase(sql).Cast<string>().ToList();
                return messages;
            }
            catch { }
            return null;
        }

        public bool newMessage(int chatID, int userID, string message)
        {
            DateTime sendTime = DateTime.Now;

            string messageCount = "SELECT MessageID FROM Message";
            List<int> messagesIDs = SQLAccess.readFromDatabase(messageCount).Cast<int>().ToList();


            string sql = "INSERT INTO Message VALUES (" + (messagesIDs.Count + 1) + ", " + chatID + ", " + userID + ", '" + message + "', null, '" + sendTime + "')";

            try
            {
                SQLAccess.writeToDatabase(sql);
                return true;
            }
            catch { return false; }
        }
    }
}
