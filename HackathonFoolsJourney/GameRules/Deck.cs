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
    
    List<Card> cardList = new List<Card>();
    List<Card> holyList = new List<Card> ();

    public Deck(Assets ass)
    {
        this.ass = ass;
        fillCardList();

        //Copy cardList to holyList
        foreach(Card item in cardList)
        {
            holyList.Add(item);
        }

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
        int index = 0;
        while (holyList.Count != 0) //Repeat until card list empty
        {
            holyList.Remove(cardList[index]);
            index++;
        }
        //Choose random number
        //Use rng as index of card list
        //Add card to draw pile
        //remove index from card list
        
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

    
    public void fillCardList()
    {
        Card tempCard = new Card();

        //Add major arcana to list

        tempCard.name = "The Magician"; //Magician
        tempCard.suit = "Arcana";
        tempCard.value = 1;
        tempCard.tex = ass.Cards[tempCard.value];
        cardList.Add(tempCard);

        tempCard.name = "The Priestess"; //Priestess"
        tempCard.value++;
        tempCard.tex = ass.Cards[tempCard.value];
        cardList.Add(tempCard);

        tempCard.name = "The Empress"; //Empress
        tempCard.value++;
        tempCard.tex = ass.Cards[tempCard.value];
        cardList.Add(tempCard);

        tempCard.name = "The Emperor"; //Emperor
        tempCard.value++;
        tempCard.tex = ass.Cards[tempCard.value];
        cardList.Add(tempCard);

        tempCard.name = "The Hierophant"; //Hierophant, value = 5
        tempCard.value++;
        tempCard.tex = ass.Cards[tempCard.value];
        cardList.Add(tempCard);

        tempCard.name = "The Lovers"; //Lovers
        tempCard.value++;
        tempCard.tex = ass.Cards[tempCard.value];
        cardList.Add(tempCard);

        tempCard.name = "The Chariot"; //Chariot
        tempCard.value++;
        tempCard.tex = ass.Cards[tempCard.value];
        cardList.Add(tempCard);

        tempCard.name = "Justice"; //Strength
        tempCard.value++;
        tempCard.tex = ass.Cards[tempCard.value];
        cardList.Add(tempCard);

        tempCard.name = "The Hermit"; //Hermit
        tempCard.value++;
        tempCard.tex = ass.Cards[tempCard.value];
        cardList.Add(tempCard);

        tempCard.name = "The Wheel of Fortune"; //Wheel of Fortune, value = 10
        tempCard.value++;
        tempCard.tex = ass.Cards[tempCard.value];
        cardList.Add(tempCard);

        tempCard.name = "The Hanged Man"; //Hanged Man
        tempCard.value++;
        tempCard.tex = ass.Cards[tempCard.value];
        cardList.Add(tempCard);

        tempCard.name = "Death"; //Death
        tempCard.value++;
        tempCard.tex = ass.Cards[tempCard.value];
        cardList.Add(tempCard);

        tempCard.name = "Temperance";    //Temperance
        tempCard.value++;
        tempCard.tex = ass.Cards[tempCard.value];
        cardList.Add(tempCard);

        tempCard.name = "The Devil"; //The Devil
        tempCard.value++;
        tempCard.tex = ass.Cards[tempCard.value];
        cardList.Add(tempCard);

        tempCard.name = "The Tower"; //The Tower, 15
        tempCard.value++;
        tempCard.tex = ass.Cards[tempCard.value];
        cardList.Add(tempCard);

        tempCard.name = "The Star"; //The Star
        tempCard.value++;
        tempCard.tex = ass.Cards[tempCard.value];
        cardList.Add(tempCard);

        tempCard.name = "The Moon"; //The Moon 
        tempCard.value++;
        tempCard.tex = ass.Cards[tempCard.value];
        cardList.Add(tempCard);

        tempCard.name = "The Sun"; 
        tempCard.value++;
        tempCard.tex = ass.Cards[tempCard.value];
        cardList.Add(tempCard);

        tempCard.name = "Judgement";
        tempCard.value++;
        tempCard.tex = ass.Cards[tempCard.value];
        cardList.Add(tempCard);

        tempCard.name = "Za Warudo";
        tempCard.value++;
        tempCard.tex = ass.Cards[tempCard.value];
        cardList.Add(tempCard);

        // Jacks

        tempCard.name = "Ace of Jacks";
        tempCard.value = 1;
        tempCard.suit = "Jack";
        tempCard.tex = ass.Jacks[0];
        cardList.Add(tempCard);

        tempCard.name = "2 of Jacks";
        tempCard.value++;
        tempCard.tex = ass.Jacks[1];
        cardList.Add(tempCard);

        tempCard.name = "3 of Jacks";
        tempCard.value++;
        tempCard.tex = ass.Jacks[2];
        cardList.Add(tempCard);

        tempCard.name = "3 of Jacks";
        tempCard.value++;
        tempCard.tex = ass.Jacks[3];
        cardList.Add(tempCard);

        tempCard.name = "4 of Jacks";
        tempCard.value++;
        tempCard.tex = ass.Jacks[4];
        cardList.Add(tempCard);

        tempCard.name = "5 of Jacks";
        tempCard.value++;
        tempCard.tex = ass.Jacks[4];
        cardList.Add(tempCard);

        tempCard.name = "6 of Jacks";
        tempCard.value++;
        tempCard.tex = ass.Jacks[5];
        cardList.Add(tempCard);

        tempCard.name = "7 of Jacks";
        tempCard.value++;
        tempCard.tex = ass.Jacks[6];
        cardList.Add(tempCard);

        tempCard.name = "8 of Jacks";
        tempCard.value++;
        tempCard.tex = ass.Jacks[7];
        cardList.Add(tempCard);

        tempCard.name = "9 of Jacks";
        tempCard.value++;
        tempCard.tex = ass.Jacks[8];
        cardList.Add(tempCard);

        tempCard.name = "10 of Jacks";
        tempCard.value++;
        tempCard.tex = ass.Jacks[9];
        cardList.Add(tempCard);

        tempCard.name = "Jack of Jacks";
        tempCard.value++;
        tempCard.tex = ass.Jacks[10];
        cardList.Add(tempCard);

        tempCard.name = "Queen of Jacks";
        tempCard.value++;
        tempCard.tex = ass.Jacks[12];
        cardList.Add(tempCard);

        tempCard.name = "King of Jacks";
        tempCard.value++;
        tempCard.tex = ass.Jacks[11];
        cardList.Add(tempCard);

        //Cups
        tempCard.name = "Ace of Cups";
        tempCard.suit = "Cups";
        tempCard.value = 1;
        tempCard.tex = ass.Cups[0];
        cardList.Add(tempCard);

        tempCard.name = "2 of Cups";
        tempCard.value++;
        tempCard.tex = ass.Cups[1];
        cardList.Add(tempCard);

        tempCard.name = "3 of Cups";
        tempCard.value++;
        tempCard.tex = ass.Cups[3];
        cardList.Add(tempCard);

        tempCard.name = "4 of Cups";
        tempCard.value++;
        tempCard.tex = ass.Cups[4];
        cardList.Add(tempCard);

        tempCard.name = "5 of Cups";
        tempCard.value++;
        tempCard.tex = ass.Cups[5];
        cardList.Add(tempCard);

        tempCard.name = "6 of Cups";
        tempCard.value++;
        tempCard.tex = ass.Cups[6];
        cardList.Add(tempCard);

        tempCard.name = "7 of Cups";
        tempCard.value++;
        tempCard.tex = ass.Cups[7];
        cardList.Add(tempCard);

        tempCard.name = "8 of Cups";
        tempCard.value++;
        tempCard.tex = ass.Cups[tempCard.value];
        cardList.Add(tempCard);

        tempCard.name = "9 of Cups";
        tempCard.value++;
        tempCard.tex = ass.Cups[8];
        cardList.Add(tempCard);

        tempCard.name = "10 of Cups";
        tempCard.value++;
        tempCard.tex = ass.Cups[9];
        cardList.Add(tempCard);

        tempCard.name = "Jack of Cups";
        tempCard.value++;
        tempCard.tex = ass.Cups[10];
        cardList.Add(tempCard);

        tempCard.name = "Queen of Cups";
        tempCard.value++;
        tempCard.tex = ass.Cups[12];
        cardList.Add(tempCard);

        tempCard.name = "Kinf of Cups";
        tempCard.value++;
        tempCard.tex = ass.Cups[11];
        cardList.Add(tempCard);

        //Swords
        tempCard.name = "Ace of Swords";
        tempCard.suit = "Swords";
        tempCard.value = 1;
        tempCard.tex = ass.Swords[0];
        cardList.Add(tempCard);

        tempCard.name = "2 of Swords";
        tempCard.value++;
        tempCard.tex = ass.Swords[1];
        cardList.Add(tempCard);

        tempCard.name = "3 of Swords";
        tempCard.value++;
        tempCard.tex = ass.Cups[2];
        cardList.Add(tempCard);

        tempCard.name = "4 of Swords";
        tempCard.value++;
        tempCard.tex = ass.Cups[3];
        cardList.Add(tempCard);

        tempCard.name = "5 of Swords";
        tempCard.value++;
        tempCard.tex = ass.Cups[4];
        cardList.Add(tempCard);

        tempCard.name = "6 o fSwords";
        tempCard.value++;
        tempCard.tex = ass.Cups[5];
        cardList.Add(tempCard);

        tempCard.name = "7 of Swords";
        tempCard.value++;
        tempCard.tex = ass.Cups[6];
        cardList.Add(tempCard);

        tempCard.name = "8 of Swords";
        tempCard.value++;
        tempCard.tex = ass.Cups[7];
        cardList.Add(tempCard);

        tempCard.name = "9 of Swords";
        tempCard.value++;
        tempCard.tex = ass.Cups[8];
        cardList.Add(tempCard);

        tempCard.name = "10 of Swords";
        tempCard.value++;
        tempCard.tex = ass.Cups[9];
        cardList.Add(tempCard);

        tempCard.name = "Jack of Swords";
        tempCard.value++;
        tempCard.tex = ass.Cups[10];
        cardList.Add(tempCard);

        tempCard.name = "Queen of Swords";
        tempCard.value++;
        tempCard.tex = ass.Cups[12];
        cardList.Add(tempCard);

        tempCard.name = "King of Swords";
        tempCard.value++;
        tempCard.tex = ass.Cups[11];
        cardList.Add(tempCard);
    }

};