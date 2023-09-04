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
    static void initializeSession(string[] args)
    {
        while(true){
            logUser();
        }
    }

    public Exercise19(){
        chatRoom = new ChatRoom();
    }

    public static void logUser(){
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
        User user = new User { Username = username };
    }

    public string manageUserMessages(User user){
        while (true)
        {
            Console.Clear();
            chatRoom?.DisplayMessages();

            Console.Write("Entering a message: msg/yourMessage\nExit ChatRoom: exit");
            string? content;
            
            while(true){
                content = Console.ReadLine();
                if(string.IsNullOrEmpty(content)){
                    Console.WriteLine("Wrong input, retry!");
                }
                else{
                    switch(content){
                        case "exit":
                            Console.WriteLine("U decided to quit the chatroom... logging out");
                            break;
                    };
                }
            }
            
            Message message = new Message { Sender = user.Username, Content = content, Timestamp = DateTime.Now };
            chatRoom.AddMessage(message);
        }
    }
}
