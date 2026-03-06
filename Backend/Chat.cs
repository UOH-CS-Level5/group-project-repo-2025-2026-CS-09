namespace Backend
{
    public class Chat
    {
        private readonly SQLAccess SQLAccess;

        public Chat(SQLAccess SQLAccess)
        {
            this.SQLAccess = SQLAccess;
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
            catch (Exception ex)
            {
                return false;
            }
        }
    }
}
