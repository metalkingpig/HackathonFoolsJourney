using System;
using System.Collections.Generic;

namespace HackathonFoolsJourney
{
    public class JourneyState
    {
        public FoolState Fool { get; private set; } = new();

        public List<TarotCard> Deck { get; private set; } = new();
        public List<TarotCard> AdventureField { get; private set; } = new();
        public List<TarotCard> DiscardPile { get; private set; } = new();

        private Random random = new();

        public void StartGame()
        {
            Deck.Clear();
            AdventureField.Clear();
            DiscardPile.Clear();

            BuildDeck();
            ShuffleDeck();
            DealStartingAdventure();
        }

        private void BuildDeck()
        {
            Deck.Add(new TarotCard("The Magician", TarotSuit.Trump, TarotCardType.Challenge, 1));
            Deck.Add(new TarotCard("The High Priestess", TarotSuit.Trump, TarotCardType.Challenge, 2));
            Deck.Add(new TarotCard("The Empress", TarotSuit.Trump, TarotCardType.Challenge, 3));
            Deck.Add(new TarotCard("The Emperor", TarotSuit.Trump, TarotCardType.Challenge, 4));
            Deck.Add(new TarotCard("The Hierophant", TarotSuit.Trump, TarotCardType.Challenge, 5));
            Deck.Add(new TarotCard("The Lovers", TarotSuit.Trump, TarotCardType.Challenge, 6));
            Deck.Add(new TarotCard("The Chariot", TarotSuit.Trump, TarotCardType.Challenge, 7));
            Deck.Add(new TarotCard("Strength", TarotSuit.Trump, TarotCardType.Challenge, 8));
            Deck.Add(new TarotCard("The Hermit", TarotSuit.Trump, TarotCardType.Challenge, 9));
            Deck.Add(new TarotCard("Wheel of Fortune", TarotSuit.Trump, TarotCardType.Challenge, 10));
            Deck.Add(new TarotCard("Justice", TarotSuit.Trump, TarotCardType.Challenge, 11));
            Deck.Add(new TarotCard("The Hanged Man", TarotSuit.Trump, TarotCardType.Challenge, 12));
            Deck.Add(new TarotCard("Death", TarotSuit.Trump, TarotCardType.Challenge, 13));
            Deck.Add(new TarotCard("Temperance", TarotSuit.Trump, TarotCardType.Challenge, 14));
            Deck.Add(new TarotCard("The Devil", TarotSuit.Trump, TarotCardType.Challenge, 15));
            Deck.Add(new TarotCard("The Tower", TarotSuit.Trump, TarotCardType.Challenge, 16));
            Deck.Add(new TarotCard("The Star", TarotSuit.Trump, TarotCardType.Challenge, 17));
            Deck.Add(new TarotCard("The Moon", TarotSuit.Trump, TarotCardType.Challenge, 18));
            Deck.Add(new TarotCard("The Sun", TarotSuit.Trump, TarotCardType.Challenge, 19));
            Deck.Add(new TarotCard("Judgement", TarotSuit.Trump, TarotCardType.Challenge, 20));
            Deck.Add(new TarotCard("The World", TarotSuit.Trump, TarotCardType.Challenge, 21));

            AddSuit(TarotSuit.Cups);
            AddSuit(TarotSuit.Batons);
            AddSuit(TarotSuit.Swords);
            AddSuit(TarotSuit.Coins);
        }

        private void AddSuit(TarotSuit suit)
        {
            Deck.Add(new TarotCard($"Ace of {suit}", suit, TarotCardType.Ace, 1));

            for (int i = 2; i <= 10; i++)
                Deck.Add(new TarotCard($"{i} of {suit}", suit, TarotCardType.Numbered, i));

            Deck.Add(new TarotCard($"Page of {suit}", suit, TarotCardType.Royal, 1));
            Deck.Add(new TarotCard($"Knight of {suit}", suit, TarotCardType.Royal, 1));
            Deck.Add(new TarotCard($"Queen of {suit}", suit, TarotCardType.Royal, 1));
            Deck.Add(new TarotCard($"King of {suit}", suit, TarotCardType.Royal, 1));
        }

        private void ShuffleDeck()
        {
            for (int i = Deck.Count - 1; i > 0; i--)
            {
                int j = random.Next(i + 1);
                TarotCard temp = Deck[i];
                Deck[i] = Deck[j];
                Deck[j] = temp;
            }
        }

        public void DealStartingAdventure()
        {
            DealCards(4);
        }

        public void DealNextAdventure()
        {
            if (AdventureField.Count == 1)
                DealCards(3);
        }

        private void DealCards(int amount)
        {
            for (int i = 0; i < amount && Deck.Count > 0; i++)
            {
                AdventureField.Add(Deck[0]);
                Deck.RemoveAt(0);
            }
        }
    }
}