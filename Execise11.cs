class Exercise11{
    Dictionary<string, string> activities;
    int activityID;
    public Exercise11(){
        this.activities = new Dictionary<string, string>();
        this.activityID = 1;
    }
    public void manageActivities(){
        Console.WriteLine("Welcome to the Activities Manager");
        getChoiceFromMenu();

    }

    public void getChoiceFromMenu(){
        Console.WriteLine("Menu: "
                            +"\n1 - Add an activity"
                            +"\n2 - Modify and activity"
                            +"\n3 - Remove an activity"
                            +"\n4 - Visualize your activities"
                            );
        Console.WriteLine("Write your choice: ");
        string? choice = Console.ReadLine();
        switch(choice){
            case "1":
                addActivities();
                break;
            case "2":
                modifyActivity();
                break;
            case "3":
                removeActivities();
                break;
            case "4":
                visualizeActivities();
                if(wannaKeepGoing())getChoiceFromMenu();
                break;
            default:
                Console.WriteLine("Invalid choice.");
                break;
        }
    }

    public void addActivities(){
        STARTADDACT:
        Console.WriteLine("Write an activity to add: ");
        string? activity = Console.ReadLine();
        if(string.IsNullOrEmpty(activity)){
             Console.WriteLine("Wrong or incorrect input, retry: ");
             goto STARTADDACT;
        }
        if (!activities.TryAdd(activityID.ToString(), activity))
        {
            Console.WriteLine($"Failed to add activity with ID {activityID}");
        }
        else
        {
            activityID++;
        }
        if(wannaKeepGoing())getChoiceFromMenu();
    }

    public void removeActivities(){
        Console.WriteLine("Below the list of activities: ");
        if(!visualizeActivities()){
            return;
        }
        Console.WriteLine("Which one u want to remove?");
        STARTREM:
        string? activityToBeRemoved = Console.ReadLine();
        if(string.IsNullOrEmpty(activityToBeRemoved)){
             Console.WriteLine("Wrong or incorrect input, retry entering it: ");
             goto STARTREM;
        }
        if(activities.ContainsKey(activityToBeRemoved)){
            activities.Remove(activityToBeRemoved);
            Console.WriteLine("Activity removed succesfully");
            activityID--;
        }
        else{
            Console.WriteLine($"Cannot find activity with id: {activityToBeRemoved}, retry entering it");
            goto STARTREM;
        }
        if(wannaKeepGoing())getChoiceFromMenu();
    }

    public bool visualizeActivities(){
        if(activities.Count == 0){
            Console.WriteLine("No activities found");
            return false;
        }else{
            foreach (KeyValuePair<string, string> item in activities)
            {
                Console.WriteLine($"Key: {item.Key}, Value: {item.Value}");
            }
        }
        return true;
    }

    public void modifyActivity(){
        Console.WriteLine("Below the list of activities: ");
        if(!visualizeActivities()){
            return;
        }
        Console.WriteLine("Which one u want to modify?");
        STARTMOD:
        string? activityToBeModified = Console.ReadLine();
        if(string.IsNullOrEmpty(activityToBeModified)){
             Console.WriteLine("Wrong or incorrect input, retry entering it: ");
             goto STARTMOD;
        }
        if(activities.ContainsKey(activityToBeModified)){
            string existingDescription = activities[activityToBeModified];
            Console.WriteLine($"Current description: {existingDescription}");
            Console.WriteLine("Enter new description:");
            string? newDescription = Console.ReadLine();
            if (!string.IsNullOrEmpty(newDescription))
            {
                activities[activityToBeModified] = newDescription;
                Console.WriteLine("Activity updated successfully.");
            }
            else
            {
                Console.WriteLine("Invalid new description, update failed.");
            }
        }
        else{
            Console.WriteLine($"Cannot find activity with id: {activityToBeModified}, retry entering it");
            goto STARTMOD;
        }
        if(wannaKeepGoing())getChoiceFromMenu();
    }
    public static bool wannaKeepGoing(){
        Console.WriteLine("Do you want to keep managing your activities? y or n");
        string? input = Console.ReadLine();
        return input == "y";
    }
}