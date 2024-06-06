namespace Solitaire.Extensions
{
    public static class ListExtensions
    {
        public static List<Card> Shuffle(this List<Card> cards)
        {
            Random rng = new Random();
            int n = cards.Count;
            while (n > 1)
            {
                n--;
                int k = rng.Next(n + 1);
                Card value = cards[k];
                cards[k] = cards[n];
                cards[n] = value;
            }
            return cards;
        }
    }
}
