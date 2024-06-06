using Solitaire.Enums;

namespace Solitaire.Helpers
{
    public static class CardsHelper
    {
        public static List<string> CardValues = new() { "A", "2", "3", "4", "5", "6", "7", "8", "9", "10", "J", "Q", "K" };
        public static string[] CardSuits = { "C", "P", "T", "R" };

        //Check if a card can be moved with the same rules as the original solitaire
        public static bool CanMoveCard(Card from, Card to) => to.Color != ColorType.None && from.Color != ColorType.None && (to.Color != from.Color) && (CardValues.IndexOf(from.Value) == (CardValues.IndexOf(to.Value) - 1));
    }
}
