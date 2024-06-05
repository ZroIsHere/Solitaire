using Solitaire;

Deck deck = new();

var isPlaying = true;

string lastCommand = "";
while (isPlaying)
{
#if !DEBUG
    Console.Clear();
#endif

    if (!string.IsNullOrEmpty(lastCommand))
    {
        Console.WriteLine($"Last command: {lastCommand}\n");
    }

    deck.PrintDeck();

    string commandLine = Console.ReadLine().ToLower();
    string[] cin = commandLine.Split(" ");
    switch (cin[0])
    {
        case "quit":
        case "q":
        case "exit":
        case "e":
            Environment.Exit(0);
            break;
        case "new":
        case "n":
            deck = new();
            break;
        case "move":
        case "m":
            if (cin.Length == 3)
            {
                try
                {
                    int from = int.Parse(cin[1]) - 1;
                    int to = int.Parse(cin[2]) - 1;
                    deck.Move(from, to);
                }
                catch (Exception ex)
                {
                    Console.Error.WriteLine(ex.Message);
                    Thread.Sleep(3 * 1000);
                }
            }
            break;
    }
    lastCommand = commandLine;
}