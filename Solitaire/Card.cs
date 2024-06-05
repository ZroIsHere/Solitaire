using Solitaire.Enums;

namespace Solitaire
{
    public class Card
    {
        public Card(string _value, string _suit, bool _isVisible = false)
        {
            Value = _value;
            Suit = _suit;
            IsVisible = _isVisible;
            Color = Suit == "R" || Suit == "C" ? ColorType.Red : Suit == "P" || Suit == "T" ? ColorType.Black : ColorType.None;
        }

        public string Value { get; set; }
        public string Suit { get; set; }
        public bool IsVisible { get; set; }
        public ColorType Color { get; set; }

        public override string ToString()
        {
            return IsVisible || Value == " " ? $"{Value}{Suit}\t" : "**\t";
        }
    }
}
