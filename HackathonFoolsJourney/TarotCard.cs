namespace HackathonFoolsJourney
{
    public enum TarotSuit
    {
        Cups, Batons, Swords, Coins, Trump
    }

    public enum TarotCardType
    {
        Numbered, Ace, Royal, Challenge, Fool
    }

    public class TarotCard
    {
        public string Name { get; }
        public TarotSuit Suit { get; }
        public TarotCardType Type { get; }
        public int Value { get; set; }   // mutable for depletion

        public TarotCard(string name, TarotSuit suit, TarotCardType type, int value)
        {
            Name = name;
            Suit = suit;
            Type = type;
            Value = value;
        }

        public bool IsChallenge() => Type == TarotCardType.Challenge;

        public bool CanGoInSatchel() => Type != TarotCardType.Challenge && Type != TarotCardType.Fool;

        public bool IsHelperFor(TarotCard target)
        {
            return Type == TarotCardType.Royal &&
                   Suit == target.Suit &&
                   target.Type != TarotCardType.Challenge;
        }
    }
}