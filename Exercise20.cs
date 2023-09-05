using Terminal.Gui;
class Exercise20{
    static ListView? listView;
    static TextField? searchField;
    static List<Book> bookCatalog = new List<Book>
    {
        new Book { Name = "Try", Author = "TheTroller", Summary = "I dont know" },
        new Book { Name = "learning C #", Author = "Saia", Summary = "Roadmap" },
    };

    public void startLibrary()
    {
        Application.Init(); // Terminal GUI
        var top = Application.Top;

        var win = new Window(new Rect(0, 1, top.Frame.Width, top.Frame.Height - 1), "Virtual Library");
        top.Add(win);

        // Creates a menu
        var menu = new MenuBar(new MenuBarItem[] {
            new MenuBarItem("_File", new MenuItem[] {
                new MenuItem("_Quit", "", () => Application.RequestStop())
            }),
        });
        top.Add(menu);

        // Create a ListView for book catalog
        listView = new ListView(new Rect(3, 2, 45, 12), bookCatalog.Select(b => b.Name).ToList());
        win.Add(listView);

        // Create a TextField for book search
        searchField = new TextField(50, 2, 20, "");
        win.Add(searchField);

        // Create a button for search
        var searchBtn = new Button(72, 2, "Search");
        win.Add(searchBtn);

        // Create a label to display selected book details
        var bookDetails = new Label(3, 14, "Book details will appear here.");
        win.Add(bookDetails);

        // Search Button Event Handling
        searchBtn.Clicked += HandleSearchClicked;



        // ListView Event Handling
        listView.OpenSelectedItem += (a) =>
        {
            var selectedBook = bookCatalog.FirstOrDefault(b => b.Name == listView.Source.ToList()[listView.SelectedItem].ToString());
            if (selectedBook != null)
            {
                bookDetails.Text = $"Name: {selectedBook.Name}\nAuthor: {selectedBook.Author}\nSummary: {selectedBook.Summary}";
            }
        };

        Application.Run();
    }

    static void HandleSearchClicked(){
        string? searchText = searchField?.ToString();
        var foundBooks = bookCatalog.Where(b => b.Name.Contains(searchText) || b.Author.Contains(searchText)).Select(b => b.Name).ToList(); // USE OF LINQ TO SEARCH
        listView?.SetSource(foundBooks);
}

}
public class Book
{
    public string? Name { get; set; }
    public string? Author { get; set; }
    public string? Summary { get; set; }
}

