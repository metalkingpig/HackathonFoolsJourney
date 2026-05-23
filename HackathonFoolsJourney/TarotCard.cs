namespace HackathonFoolsJourney
{
    public enum TarotSuit
    {
        Cups,
        Batons,
        Swords,
        Coins,
        Trump
    }

    public enum TarotCardType
    {
        Numbered,
        Ace,
        Royal,
        Challenge,
        Fool
    }

    public class TarotCard
    {
        public string Name { get; set; }
        public TarotSuit Suit { get; set; }
        public TarotCardType Type { get; set; }
        public int Value { get; set; }

        public TarotCard(string name, TarotSuit suit, TarotCardType type, int value)
        {
            Name = name;
            Suit = suit;
            Type = type;
            Value = value;
        }

        public bool IsChallenge()
        {
            return Type == TarotCardType.Challenge;
        }

        public bool CanGoInSatchel()
        {
            return Type != TarotCardType.Challenge && Type != TarotCardType.Fool;
        }
    }
}