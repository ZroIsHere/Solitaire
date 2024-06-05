using Solitaire.Enums;
using Solitaire.Extensions;

namespace Solitaire
{
    public class Deck
    {
        List<string> values = new() { "A", "2", "3", "4", "5", "6", "7", "8", "9", "10", "J", "Q", "K" };
        string[] suits = { "C", "P", "T", "R" };

        List<Card> cards = new();
        List<List<Card>> inTheTable = new(); // Fila columna

        public Deck()
        {
            foreach (var suit in suits)
            {
                foreach (var value in values)
                {
                    cards.Add(new Card(value, suit));
                }
            }
            cards = cards.Shuffle();
            MakeTable();
        }

        private void MakeTable()
        {
            for (int i = 0; i < 7; i++)
            {
                List<Card> crs = new();
                for (int j = 0; j < i; j++)
                {
                    crs.Add(new Card(" ", " ", true));
                }

                bool firstIsVisible = false;
                for (int j = 0; j < (7 - i); j++)
                {
                    Card crd = cards.First();
                    cards.Remove(crd);
                    if (!firstIsVisible)
                    {
                        firstIsVisible = true;
                        crd.IsVisible = true;
                    }
                    crs.Add(crd);
                }
                inTheTable.Add(crs);
            }
        }

        public void PrintDeck()
        {
            Console.WriteLine("C1\tC2\tC3\tC4\tC5\tC6\tC7");
            int i = 0;
            foreach (var crs in inTheTable)
            {
                i++;
                string ret = "";
                foreach (var card in crs)
                {
                    ret += card.ToString();
                }
                Console.WriteLine($"{ret}f{i}");
            }
        }

        public void Move(int from, int to)
        {
            bool addInNext = false;
            Card fromCard = null;
            int makeVisibleCard = -1;
            foreach (var cds in inTheTable)
            {
                if (!cds[from].Value.Equals(" ") && cds[from].IsVisible)
                {
                    makeVisibleCard = inTheTable.IndexOf(cds);
                    fromCard = cds[from];
                }
                if (fromCard != null)
                {
                    foreach (var cds2 in inTheTable)
                    {
                        Card toCard = null;
                        if (!cds2[to].Value.Equals(" ") && cds2[to].IsVisible)
                        {
                            toCard = cds2[to];
                        }
                        int indexfrom = values.IndexOf(fromCard.Value);
                        if (toCard != null)
                        {
                            int indexto = values.IndexOf(toCard.Value) - 1;
                        }
                        //Validate the movement, remove the "fromCard" and make it possible
                        if (toCard != null && toCard.Color != ColorType.None && fromCard.Color != ColorType.None && (toCard.Color != fromCard.Color) && (values.IndexOf(fromCard.Value) == (values.IndexOf(toCard.Value) - 1)))
                        {
                            addInNext = true;
                            int clsindex = cds.IndexOf(fromCard);
                            cds.Remove(fromCard);
                            cds.Insert(clsindex, new(" ", " ", true));
                            break;
                        }
                    }
                    break;
                }
            }
            if (addInNext)
            {
                //Insert the "fromCard" into the "to" column
                foreach (var cds in inTheTable)
                {
                    Card toCard = cds[to];
                    if (toCard.Value.Equals(" "))
                    {
                        cds.RemoveAt(to);
                        cds.Insert(to, fromCard);
                        addInNext = false;
                        break;
                    }
                }
                //Make visible the new card on the "from" column
                if (makeVisibleCard != 0)
                {
                    foreach (var cds in inTheTable)
                    {
                        if (inTheTable.IndexOf(cds) == makeVisibleCard - 1)
                        {
                            Card crd = cds[from];
                            crd.IsVisible = true;
                            cds.RemoveAt(from);
                            cds.Insert(from, crd);
                            break;
                        }
                    }
                }
                //Create a new row if not exist and insert the card
                if (addInNext)
                {
                    List<Card> cdsList = new();
                    for (int i = 0; i < 6; i++)
                    {
                        cdsList.Add(new(" ", " ", true));
                        if (i + 1 == to)
                        {
                            cdsList.Add(fromCard);
                        }
                    }
                    inTheTable.Add(cdsList);
                    addInNext = false;
                }
            }
            //Make before card in the from index visible
        }
    }
}
