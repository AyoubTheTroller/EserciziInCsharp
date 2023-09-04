class User
{
    public string? Username { get; set; }
}

class Message
{
    public string? Sender { get; set; }
    public string? Content { get; set; }
    public DateTime Timestamp { get; set; }
}

class ChatRoom
{
    public List<Message> Messages { get; set; }

    public ChatRoom()
    {
        Messages = new List<Message>();
    }
    
    public void AddMessage(Message message)
    {
        Messages.Add(message);
    }
    
    public void DisplayMessages()
    {
        foreach (var message in Messages)
        {
            Console.WriteLine($"{message.Timestamp} - {message.Sender}: {message.Content}");
        }
    }
}

class Exercise19
{
    public static ChatRoom? chatRoom;
    public void initializeSession()
    {
        while(true){
            manageUserSession(logUser());
            if (!wannaKeepGoing())
            {
                break;
            }
        }
    }

    public Exercise19(){
        chatRoom = new ChatRoom();
    }

    public User logUser(){
        Console.Write("Enter your username: ");
        string? username;
        while(true){
            username = Console.ReadLine();
            if(string.IsNullOrEmpty(username)){
                Console.WriteLine("Wrong input, retry!");
            }
            else{
                break;
            }
        }
        return new User { Username = username };
    }

    public void manageUserSession(User user){
        Console.Clear();
        chatRoom?.DisplayMessages();
        printChatRules();
        manageUserMessages(user);
    }

    public void manageUserMessages(User user){
        string? content;
        while(true){
            content = Console.ReadLine();
            if(string.IsNullOrEmpty(content)){
                Console.WriteLine("Wrong input, retry!");
            }
            else{
                if(content.StartsWith("msg/")){
                    Console.WriteLine(content.Substring(4));
                    Message message = new Message { Sender = user.Username, Content = content.Substring(4), Timestamp = DateTime.Now };
                    chatRoom?.AddMessage(message);
                }
                else if(content.Equals("exit")){
                    Console.WriteLine("Logging out...");
                    break;
                }
                else{
                    Console.WriteLine("Input not recognized. Refer to the Rules.");
                }
            }
        }
    }

    public void printChatRules(){
        Console.Write("Rules\n"
                         +"Entering a message: msg/yourMessage\n"
                         +"Exit ChatRoom: exit\n");
    }

    public static bool wannaKeepGoing(){
        Console.WriteLine("Do you want to log in? y or n");
        string? input = Console.ReadLine();
        return input == "y";
    }
}
