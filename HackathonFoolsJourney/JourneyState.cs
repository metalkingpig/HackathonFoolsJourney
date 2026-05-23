using System;
using System.Collections.Generic;

namespace HackathonFoolsJourney
{
    public class JourneyState
    {
        public FoolState Fool { get; private set; } = new();

        public TarotCard FoolCard { get; private set; } =
            new TarotCard("The Fool", TarotSuit.Trump, TarotCardType.Fool, 0);

        public List<TarotCard> Deck { get; private set; } = new();
        public List<TarotCard> AdventureField { get; private set; } = new();
        public List<TarotCard> DiscardPile { get; private set; } = new();

        private Random random = new Random();

        public void StartGame()
        {
            Deck.Clear();
            AdventureField.Clear();
            DiscardPile.Clear();
            Fool.Reset();

            BuildDeck();
            ShuffleDeck();
            DealStartingAdventure();
        }

        private void BuildDeck()
        {
            // Major Arcana (Challenges)
            for (int i = 1; i <= 21; i++)
            {
                string name = i switch
                {
                    1 => "The Magician",
                    2 => "The High Priestess",
                    3 => "The Empress",
                    4 => "The Emperor",
                    5 => "The Hierophant",
                    6 => "The Lovers",
                    7 => "The Chariot",
                    8 => "Strength",
                    9 => "The Hermit",
                    10 => "Wheel of Fortune",
                    11 => "Justice",
                    12 => "The Hanged Man",
                    13 => "Death",
                    14 => "Temperance",
                    15 => "The Devil",
                    16 => "The Tower",
                    17 => "The Star",
                    18 => "The Moon",
                    19 => "The Sun",
                    20 => "Judgement",
                    21 => "The World",
                    _ => $"Trump {i}"
                };
                Deck.Add(new TarotCard(name, TarotSuit.Trump, TarotCardType.Challenge, i));
            }

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

            // Royals = Helpers
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

        public void DealStartingAdventure() => DealCards(4);

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

        // ====================== PDF ACTIONS ======================

        public bool StoreCardInSatchel(int index)
        {
            if (index < 0 || index >= AdventureField.Count) return false;
            if (Fool.Satchel.Count >= 3) return false;

            var card = AdventureField[index];
            if (!card.CanGoInSatchel()) return false;

            Fool.Satchel.Add(card);
            AdventureField.RemoveAt(index);
            return true;
        }

        public bool DiscardAdventureCard(int index)
        {
            if (index < 0 || index >= AdventureField.Count) return false;
            var card = AdventureField[index];
            if (card.IsChallenge()) return false;

            DiscardPile.Add(card);
            AdventureField.RemoveAt(index);
            return true;
        }

        public bool UseCupForVitality(int index)
        {
            if (index < 0 || index >= AdventureField.Count) return false;
            var card = AdventureField[index];
            if (card.Suit != TarotSuit.Cups || card.Type != TarotCardType.Numbered) return false;

            Fool.GainVitality(card.Value);
            DiscardPile.Add(card);
            AdventureField.RemoveAt(index);
            return true;
        }

        public bool TakeChance(int index)
        {
            if (index < 0 || index >= AdventureField.Count) return false;
            var card = AdventureField[index];
            if (card.Type != TarotCardType.Ace) return false;

            DiscardPile.Add(card);
            AdventureField.RemoveAt(index);

            foreach (var c in AdventureField) Deck.Add(c);
            AdventureField.Clear();
            ShuffleDeck();

            DealStartingAdventure();
            return true;
        }

        public bool EquipWisdom(int index)
        {
            if (index < 0 || index >= AdventureField.Count) return false;
            var card = AdventureField[index];
            if (card.Suit != TarotSuit.Coins || card.Type != TarotCardType.Numbered) return false;
            if (Fool.Wisdom.Count >= 3) return false;

            Fool.Wisdom.Add(card);
            AdventureField.RemoveAt(index);
            return true;
        }

        public bool EquipStrength(int index)
        {
            if (index < 0 || index >= AdventureField.Count) return false;
            var card = AdventureField[index];
            if (card.Suit != TarotSuit.Batons || card.Type != TarotCardType.Numbered) return false;
            if (Fool.Strength != null) return false;

            Fool.Strength = card;
            AdventureField.RemoveAt(index);
            return true;
        }

        public bool EquipVolition(int index)
        {
            if (index < 0 || index >= AdventureField.Count) return false;
            var card = AdventureField[index];
            if (card.Suit != TarotSuit.Swords || card.Type != TarotCardType.Numbered) return false;
            if (Fool.Volition != null) return false;

            Fool.Volition = card;
            AdventureField.RemoveAt(index);
            return true;
        }

        public bool DeployHelper(int helperIndex, int targetIndex)
        {
            if (helperIndex < 0 || helperIndex >= AdventureField.Count) return false;
            if (targetIndex < 0 || targetIndex >= AdventureField.Count) return false;

            var helper = AdventureField[helperIndex];
            var target = AdventureField[targetIndex];

            if (helper.Type != TarotCardType.Royal || Fool.Wisdom.Count == 0) return false;
            if (!helper.IsHelperFor(target)) return false;

            Fool.Wisdom.RemoveAt(0); // spend 1 Wisdom
            DiscardPile.Add(helper);
            AdventureField.RemoveAt(helperIndex);
            return true;
        }

        public bool ResolveChallenge(int index)
        {
            if (index < 0 || index >= AdventureField.Count) return false;
            var challenge = AdventureField[index];
            if (!challenge.IsChallenge()) return false;

            // Prefer Volition first
            if (Fool.Volition != null)
            {
                int volValue = Fool.Volition.Value;
                if (volValue >= challenge.Value)
                {
                    // Fully overcome
                    DiscardPile.Add(Fool.Volition);
                    DiscardPile.Add(challenge);
                    Fool.Volition = null;
                }
                else
                {
                    // Partial depletion
                    challenge.Value -= volValue;
                    DiscardPile.Add(Fool.Volition);
                    Fool.Volition = null;
                    return true;
                }
            }
            else if (Fool.Strength != null)
            {
                // Endure with Strength
                int damage = challenge.Value - Fool.Strength.Value;
                if (damage > 0) Fool.LoseVitality(damage);

                DiscardPile.Add(Fool.Strength);
                DiscardPile.Add(challenge);
                Fool.Strength = null;
            }
            else
            {
                // Direct damage
                Fool.LoseVitality(challenge.Value);
                DiscardPile.Add(challenge);
            }

            AdventureField.RemoveAt(index);
            return true;
        }

        public bool IsGameOver() => Fool.IsDead();
    }
}