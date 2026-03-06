using Backend;
using Microsoft.Extensions.Logging;

SQLAccess SQLAccess = new SQLAccess();

Login login = new Login(SQLAccess);
bool test = login.passwordCheck(1, "socpass1");
if (test)
{
    Console.WriteLine("Correct Password, read from database");
}

Chat chat = new Chat(SQLAccess);
test = chat.getMessages(1);
if (test)
{
    Console.WriteLine("Chat info loaded, record quantity consistent");
}