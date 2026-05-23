using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;

namespace HackathonFoolsJourney.GameRules
{
    public struct Card
    {
        public string name;
        public CardSuit suit;
        public int value;

        public float posX;
        public float posY;

        public Texture2D tex;
    }

    public enum CardSuit
    {
        Arcana,
        Jack,
        Cup,
        Sword,
    }

    public class Deck
    {
        private readonly Assets ass;
        private readonly List<Card> cardList = [];

        private const int DECK_SIZE = 60;
        public readonly Stack<Card> deck = new(DECK_SIZE); // 60 cards in total

        public Deck(Assets ass)
        {
            this.ass = ass;
            fillCardList();
            createDeck();

            //System.Diagnostics.Debug.WriteLine(deck.Pop().name);


            //Add cards to field
            //Gameplay loop
            //
        }

        public bool Empty => deck.Count == 0;

        public Card GetNext()
        {
            return deck.Pop();
        }

        private void createDeck()
        {
            Random rng = new();
            List<Card> cards = [.. cardList];
            for (int i = 0; i < DECK_SIZE; i++)
            {
                Card pickedCard = cards[rng.Next(cards.Count)];
                if (!cards.Remove(pickedCard)) throw new Exception("Failed to remove card.");
                deck.Push(pickedCard);
            }
        }

        private void fillCardList()
        {
            Card card = default;

            //Add major arcana to list

            card.name = "The Magician"; //Magician
            card.suit = CardSuit.Arcana;
            card.value = 1;
            card.tex = ass.Cards[card.value];
            cardList.Add(card);

            card.name = "The Priestess"; //Priestess"
            card.value++;
            card.tex = ass.Cards[card.value];
            cardList.Add(card);

            card.name = "The Empress"; //Empress
            card.value++;
            card.tex = ass.Cards[card.value];
            cardList.Add(card);

            card.name = "The Emperor"; //Emperor
            card.value++;
            card.tex = ass.Cards[card.value];
            cardList.Add(card);

            card.name = "The Hierophant"; //Hierophant, value = 5
            card.value++;
            card.tex = ass.Cards[card.value];
            cardList.Add(card);

            card.name = "The Lovers"; //Lovers
            card.value++;
            card.tex = ass.Cards[card.value];
            cardList.Add(card);

            card.name = "The Chariot"; //Chariot
            card.value++;
            card.tex = ass.Cards[card.value];
            cardList.Add(card);

            card.name = "Justice"; //Strength
            card.value++;
            card.tex = ass.Cards[card.value];
            cardList.Add(card);

            card.name = "The Hermit"; //Hermit
            card.value++;
            card.tex = ass.Cards[card.value];
            cardList.Add(card);

            card.name = "The Wheel of Fortune"; //Wheel of Fortune, value = 10
            card.value++;
            card.tex = ass.Cards[card.value];
            cardList.Add(card);

            card.name = "The Hanged Man"; //Hanged Man
            card.value++;
            card.tex = ass.Cards[card.value];
            cardList.Add(card);

            card.name = "Death"; //Death
            card.value++;
            card.tex = ass.Cards[card.value];
            cardList.Add(card);

            card.name = "Temperance";    //Temperance
            card.value++;
            card.tex = ass.Cards[card.value];
            cardList.Add(card);

            card.name = "The Devil"; //The Devil
            card.value++;
            card.tex = ass.Cards[card.value];
            cardList.Add(card);

            card.name = "The Tower"; //The Tower, 15
            card.value++;
            card.tex = ass.Cards[card.value];
            cardList.Add(card);

            card.name = "The Star"; //The Star
            card.value++;
            card.tex = ass.Cards[card.value];
            cardList.Add(card);

            card.name = "The Moon"; //The Moon 
            card.value++;
            card.tex = ass.Cards[card.value];
            cardList.Add(card);

            card.name = "The Sun";
            card.value++;
            card.tex = ass.Cards[card.value];
            cardList.Add(card);

            card.name = "Judgement";
            card.value++;
            card.tex = ass.Cards[card.value];
            cardList.Add(card);

            card.name = "Za Warudo";
            card.value++;
            card.tex = ass.Cards[card.value];
            cardList.Add(card);

            // Jacks

            card.name = "Ace of Jacks";
            card.value = 1;
            card.suit = CardSuit.Jack;
            card.tex = ass.Jacks[0];
            cardList.Add(card);

            card.name = "2 of Jacks";
            card.value++;
            card.tex = ass.Jacks[1];
            cardList.Add(card);

            card.name = "3 of Jacks";
            card.value++;
            card.tex = ass.Jacks[2];
            cardList.Add(card);

            card.name = "3 of Jacks";
            card.value++;
            card.tex = ass.Jacks[3];
            cardList.Add(card);

            card.name = "4 of Jacks";
            card.value++;
            card.tex = ass.Jacks[4];
            cardList.Add(card);

            card.name = "5 of Jacks";
            card.value++;
            card.tex = ass.Jacks[4];
            cardList.Add(card);

            card.name = "6 of Jacks";
            card.value++;
            card.tex = ass.Jacks[5];
            cardList.Add(card);

            card.name = "7 of Jacks";
            card.value++;
            card.tex = ass.Jacks[6];
            cardList.Add(card);

            card.name = "8 of Jacks";
            card.value++;
            card.tex = ass.Jacks[7];
            cardList.Add(card);

            card.name = "9 of Jacks";
            card.value++;
            card.tex = ass.Jacks[8];
            cardList.Add(card);

            card.name = "10 of Jacks";
            card.value++;
            card.tex = ass.Jacks[9];
            cardList.Add(card);

            card.name = "Jack of Jacks";
            card.value++;
            card.tex = ass.Jacks[10];
            cardList.Add(card);

            card.name = "Queen of Jacks";
            card.value++;
            card.tex = ass.Jacks[12];
            cardList.Add(card);

            card.name = "King of Jacks";
            card.value++;
            card.tex = ass.Jacks[11];
            cardList.Add(card);

            //Cups
            card.name = "Ace of Cups";
            card.suit = CardSuit.Cup;
            card.value = 1;
            card.tex = ass.Cups[0];
            cardList.Add(card);

            card.name = "2 of Cups";
            card.value++;
            card.tex = ass.Cups[1];
            cardList.Add(card);

            card.name = "3 of Cups";
            card.value++;
            card.tex = ass.Cups[2];
            cardList.Add(card);

            card.name = "4 of Cups";
            card.value++;
            card.tex = ass.Cups[3];
            cardList.Add(card);

            card.name = "5 of Cups";
            card.value++;
            card.tex = ass.Cups[4];
            cardList.Add(card);

            card.name = "6 of Cups";
            card.value++;
            card.tex = ass.Cups[5];
            cardList.Add(card);

            card.name = "7 of Cups";
            card.value++;
            card.tex = ass.Cups[6];
            cardList.Add(card);

            card.name = "8 of Cups";
            card.value++;
            card.tex = ass.Cups[7];
            cardList.Add(card);

            card.name = "9 of Cups";
            card.value++;
            card.tex = ass.Cups[8];
            cardList.Add(card);

            card.name = "10 of Cups";
            card.value++;
            card.tex = ass.Cups[9];
            cardList.Add(card);

            card.name = "Jack of Cups";
            card.value++;
            card.tex = ass.Cups[10];
            cardList.Add(card);

            card.name = "Queen of Cups";
            card.value++;
            card.tex = ass.Cups[12];
            cardList.Add(card);

            card.name = "King of Cups";
            card.value++;
            card.tex = ass.Cups[11];
            cardList.Add(card);

            //Swords
            card.name = "Ace of Swords";
            card.suit = CardSuit.Sword;
            card.value = 1;
            card.tex = ass.Swords[0];
            cardList.Add(card);

            card.name = "2 of Swords";
            card.value++;
            card.tex = ass.Swords[1];
            cardList.Add(card);

            card.name = "3 of Swords";
            card.value++;
            card.tex = ass.Swords[2];
            cardList.Add(card);

            card.name = "4 of Swords";
            card.value++;
            card.tex = ass.Swords[3];
            cardList.Add(card);

            card.name = "5 of Swords";
            card.value++;
            card.tex = ass.Swords[4];
            cardList.Add(card);

            card.name = "6 of Swords";
            card.value++;
            card.tex = ass.Swords[5];
            cardList.Add(card);

            card.name = "7 of Swords";
            card.value++;
            card.tex = ass.Swords[6];
            cardList.Add(card);

            card.name = "8 of Swords";
            card.value++;
            card.tex = ass.Swords[7];
            cardList.Add(card);

            card.name = "9 of Swords";
            card.value++;
            card.tex = ass.Swords[8];
            cardList.Add(card);

            card.name = "10 of Swords";
            card.value++;
            card.tex = ass.Swords[9];
            cardList.Add(card);

            card.name = "Jack of Swords";
            card.value++;
            card.tex = ass.Swords[10];
            cardList.Add(card);

            card.name = "Queen of Swords";
            card.value++;
            card.tex = ass.Swords[12];
            cardList.Add(card);

            card.name = "King of Swords";
            card.value++;
            card.tex = ass.Swords[11];
            cardList.Add(card);
        }
    }
}
