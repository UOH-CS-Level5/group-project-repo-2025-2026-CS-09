/*using Backend;
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

chat.usersChatNames(3);*/


using Backend;

SQLAccess SQLAccess = new SQLAccess();

int userID = 3;

/*Chat chat = new Chat(SQLAccess);

List<string> chatNames = chat.usersChatNames(userID);
List<int> chatIDs = chat.userChatIDs(userID);

int i = 1;
if (chatIDs.Count == chatNames.Count)
{
    for (i = i; i <= chatIDs.Count; i++)
    {
        Console.WriteLine((i) + ". " + chatNames[i-1]);
    }
}
Console.WriteLine("Select option:");
int input = Convert.ToInt32(Console.ReadLine());

List<string> senders = null;
List<DateTime> sendersDate = null;
List<string> messages = null;
if (input <= i && input >= 0)
{
    senders = chat.senderName(chatIDs[input - 1]);
    sendersDate = chat.senderTime(chatIDs[input-1]);
    messages = chat.chatMessage(chatIDs[input-1]);
}

for (int a = 0; a < senders.Count; a++)
{
    Console.WriteLine(senders[a] + " : " + sendersDate[a] + " : " + messages[a]);
}

Console.WriteLine("\nWrite a new message:");
string message = Console.ReadLine();
bool success = chat.newMessage((chatIDs[input-1]), userID, message);*/

Posts posts = new Posts(SQLAccess);

List<int> postIDS = posts.usersSocIDs(userID);
Console.ReadLine();