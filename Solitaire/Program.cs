using Solitaire;

Deck deck = new();

var isPlaying = true;

string lastCommand = "";
while (isPlaying)
{
    Console.WriteLine("""
        This are the commands:

        Q: For close the game
        N: For start a new game
        M: Make a move. Example (move columnFrom columnTo)
        T: Take a card from the deck. For move it to a column, add the column after the command, as t 1 (column 1)
        
        """);
    if (!string.IsNullOrEmpty(lastCommand))
    {
#if !DEBUG
        Console.Clear();
#endif
        Console.WriteLine(lastCommand);
        lastCommand = string.Empty;
    }

    deck.PrintDeck();

    string commandLine = Console.ReadLine().ToLower();
    string[] cin = commandLine.Split(" ");
    try
    {
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
                    //Is -1 because an array start from 0 and the columns from 1
                    int from = int.Parse(cin[1]) - 1;
                    int to = int.Parse(cin[2]) - 1;
                    //Columns from 1 to 7
                    if (from >= 0 && to >= 0 && from <= 6 && to <= 6)
                    {
                        deck.Move(from, to);
                        continue;
                    }
                    lastCommand += "Error: The columns must be from 1 to 7\n";
                }
                break;
            case "t":
            case "take":
                if (cin.Length == 2)
                {
                    //Is -1 because an array start from 0 and the columns from 1
                    int to = int.Parse(cin[1]) - 1;
                    //Columns from 1 to 7
                    if (to >= 0 && to <= 6)
                    {
                        deck.Take(to);
                        break;
                    }
                    lastCommand += "Error: The columns must be from 1 to 7\n";
                }
                deck.Take();
                break;
        }
    }
    catch (Exception ex)
    {
        lastCommand += $"Error: {ex.Message}";
    }
    lastCommand += $"Last command: {commandLine}\n";
}