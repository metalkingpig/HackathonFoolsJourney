using System;
using System.Collections.Generic;
using System.Net.Http.Headers;

struct Card
{
    public string name;
    public string suit;
    public int value;
}


public class Deck
{   
    //Card Info
    string[] suits = {"Arcana", "Coins", "Swords", "Wands", "Cups"};
    string[] namedCards = {"Ace", "Page", "Knights", "Queen", "King"};
    string[] majorArcana = {"The Magician", "The High Priestess", "The Empress", "The Emperor", "The Hierophant", "The Lovers", "The Chariot", "Strength", "The Hermit", "The Wheel of Fortune", "Justice", "The Hanged Man", "Death", "Temperance", "The Devil", "The Tower", "The Star", "The Moon", "The Sun", "Judgement", "The World"};
 
    HashSet<string> inDrawPile = new HashSet<string>();  //Store cards already in stack

    Stack<Card> drawPile = new Stack<Card>();   //Cards in draw pile

    

    //Fill drawPile
    public void fillDrawPile()
    {
        Card temp_card = new Card();
        Random rnd = new Random();  //Random number generator

        int choice = rnd.Next(4);
        temp_card.suit = suits[choice];

        
        
        if (temp_card.suit == "Arcana")
        {
            choice = rnd.Next(20);

            //Fill Card info
            temp_card.name = majorArcana[choice];
            temp_card.value = choice + 1;
        }

        else    //Regular Card
        {
            choice = rnd.Next(1, 14);

            switch (choice)
            {
                case 1:
                    temp_card.name = "Ace";
                    break;
                
                case 11:
                    temp_card.name = "Page";
                    break;
                
                case 12:
                    temp_card.name = "Knight";
                    break;
                
                case 13:
                    temp_card.name = "Queen";
                    break;

                case 14:
                    temp_card.name = "King";
                    break;
                
                default:
                    temp_card.name = choice.ToString();
                    break;
            }

            temp_card.name = temp_card.name + temp_card.suit;
        }

        Console.WriteLine(temp_card.name);
        Console.WriteLine(temp_card.value);
        Console.WriteLine(temp_card.suit);
    }
};