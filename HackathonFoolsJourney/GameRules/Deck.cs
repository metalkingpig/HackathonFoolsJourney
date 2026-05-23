using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http.Headers;
using HackathonFoolsJourney;
using Microsoft.Xna.Framework.Graphics;

public class Card
{
    public string name;
    public string suit;
    public int value;

    public float posX;
    public float posY;

    public Texture2D tex;

    public void cardDelete()
    {
        name = "   ";
        suit = "   ";
        value = 0;
    }

    public void Draw(Renderer rend)
    {
        rend.DrawScaled(tex, posX, posY, 2);
    }
}


public class Deck
{   
    private Assets ass;

    //Card Info
    string[] suits = {"Arcana", "Swords", "Wands", "Cups"};
    string[] namedCards = {"Ace", "Jack", "Queen", "King"};
    string[] majorArcana = {"The Magician", "The High Priestess", "The Empress", "The Emperor", "The Hierophant", "The Lovers", "The Chariot", "Strength", "The Hermit", "The Wheel of Fortune", "Justice", "The Hanged Man", "Death", "Temperance", "The Devil", "The Tower", "The Star", "The Moon", "The Sun", "Judgement", "The World"};

    Stack<Card> drawPile = new Stack<Card>(77);   //Cards in draw pile
    HashSet<string> inDrawPile = new HashSet<string>();  //Store cards already in stack
    

    public Deck(Assets ass)
    {
        this.ass = ass;
        fillDrawPile();
    }

    //Fill drawPile
    public Card createCard()
    {
        Card temp_card = new Card();
        Random rnd = new Random();  //Random number generator

        int choice = rnd.Next(3);
        temp_card.suit = suits[choice];

        
        
        if (temp_card.suit == "Arcana")
        {
            choice = rnd.Next(20);

            //Fill Card info
            temp_card.name = majorArcana[choice];
            temp_card.value = choice + 1;

            //Debug Stuff
            if (ass == null)
            {
                Console.WriteLine("It doesn't work");
            }

            temp_card.tex = ass.Cards[choice + 1];
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

            temp_card.name = temp_card.name + " of " + temp_card.suit;
            temp_card.value = choice;
        }

        return temp_card;
    }

    public void fillDrawPile()
    {
        Card temp_card;
        
        while (drawPile.Count < 77) //Add 77 cards 
        {
            temp_card = createCard();

            if (inDrawPile.Contains(temp_card.name))
            {
                continue;
            }
            else
            {
                inDrawPile.Add(temp_card.name);
                drawPile.Push(temp_card);
            }
            
        }
    }

    public Card drawCard()
    {
        Card drawnCard = new Card();

        if (drawPile.Count == 0)
        {
            drawnCard.cardDelete();
        }
        else{
        drawnCard = drawPile.Pop(); //Draw Card
        }
        
        return drawnCard;
    }

    public void Shuffle()
    {
        Card temp_card;
        HashSet<string> reAdded = new HashSet<string>();  //Store cards readded
        drawPile.Clear();   //Empty Stack

        //Create cards until all in their
        while (drawPile.Count != inDrawPile.Count)
        {
            temp_card = createCard();

            if (reAdded.Contains(temp_card.name) || (!inDrawPile.Contains(temp_card.name)))
            {
                continue;
            }
            else
            {
                reAdded.Add(temp_card.name);
                drawPile.Push(temp_card);
            }
        }

        
    }

    public void reAddCard(Card toAdd)
    {
        inDrawPile.Add(toAdd.name);
    }
};