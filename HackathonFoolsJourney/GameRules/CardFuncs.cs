using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http.Headers;
using HackathonFoolsJourney;
using Microsoft.Xna.Framework.Graphics;

namespace HackathonFoolsJourney
{
    public struct Player
    {
        public int strength;
        public int wisdom;
        public int health;
        public int coins;

        public Player()
        {
            strength = 0;
            wisdom = 0;
            health = 20;
        }
    }

    public static class CardFuncs
    {
        public static void onCardSelect(char input, Card card, PlayingField field, Player fool, Deck deck)
        {
            if (card.suit == "Arcana")
            {
                Console.WriteLine("Q) Use Strength");
                Console.WriteLine("W) Use Wisdom");
                Console.WriteLine("E) Use Health");
                Console.WriteLine("R) Quit");

                int temp_val = card.value;

                switch (input)
                {
                    case 'Q':
                        //Use Strength
                        card.value -= fool.strength;
                        fool.strength = 0;
                        break;

                    case 'W':
                        //Use Wisdom
                        card.value -= fool.wisdom;
                        fool.wisdom -= temp_val;

                        if (fool.wisdom < 0)    //Wisdom does not go negative
                        {
                            fool.wisdom = 0;
                        }
                        break;

                    case 'E':
                        //Use Health
                        card.value -= fool.health;
                        fool.health -= temp_val;
                        break;
                }
            }
            else
            {
                Console.WriteLine("Q) Use");
                Console.WriteLine("W) Put in Storage");
                Console.WriteLine("E) Discard");
                Console.WriteLine("R) Quit");

                switch (input)
                {
                    case 'Q':
                        //Use Card
                        use(card, fool, field, deck);
                        break;

                    case 'W':
                        //Store
                        storeCard(card, field);
                        break;
                    case 'E':
                        card.cardDelete();
                        break;
                }
            }
        }  

        public static void use(Card card, Player fool, PlayingField field, Deck deck)
        {
            if (card.value == 1)
            {
                for (int i = 0; i < 4; i++)
                {
                    if (field.field[i].name != "   ")
                    {
                        deck.reAddCard(field.field[i]);
                    }
                }

            }
            else if (card.suit == "Cups")
            {
                fool.health += card.value;
            }
            else if (card.suit == "Swords")
            {
                fool.strength += card.value;
            }
            else if (card.suit == "Wands")
            {
                fool.wisdom += card.value;
            }

            card.cardDelete();
        }

        public static void storeCard(Card card, PlayingField field)
        {
            field.addCardBag(card);
            card.cardDelete();
        }
    }
}