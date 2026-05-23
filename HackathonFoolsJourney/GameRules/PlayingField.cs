using System.Collections.Generic;

namespace HackathonFoolsJourney.GameRules
{
    public class PlayingField
    {
        public const int FIELD_MAX = 4;
        public const int STORAGE_MAX = 3;

        private readonly Deck deck;
        public readonly List<Card> Field;    // 4 Max
        public readonly List<Card> Storage; // 3 Max

        public PlayingField(Deck deck)
        {
            this.deck = deck;
            Field = [];
            Storage = [];

            for (int i = 0; i < FIELD_MAX; i++)
            {
                Field.Add(deck.deck.Pop());
            }
        }

        public bool CanDiscard(Card card)
        {
            return card.suit != CardSuit.Arcana;
        }

        public bool CanStore(Card card)
        {
            return card.suit != CardSuit.Arcana && Storage.Count < STORAGE_MAX;
        }

        public void RemoveCard(int index)
        {
            if (index < FIELD_MAX)
            {
                Field.RemoveAt(index);
                if (!deck.Empty)
                    Field.Add(deck.GetNext());
            }
            else
            {
                Storage.RemoveAt(index - FIELD_MAX);
            }
        }
    }
}
