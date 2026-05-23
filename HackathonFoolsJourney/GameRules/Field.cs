using System;
using System.Collections.Generic;

public class PlayingField
{
    public Card[] field = new Card[7]; //Field

    public PlayingField(Deck deck)
    {
        refillField(deck);    
    }

    public int countEmptyField()
    {
        int count = 0;

        for (int i = 0; i < 4; i++)
        {
            if (field[i].name == "   ")
            {
                count++;
            }
        }
        return count;
    }

    public int findEmptyField()
    {
        for (int i = 0; i < 4; i++)
        {
            if (field[i].name == "   ")
            {
                return i;
            }
        }    
        return -1;
    }

    public int findEmptyBag()
    {
        for (int i = 4; i < 7; i++)
        {
            if (field[i].name == "   ")
            {
                return i;
            }
        }    
        return -1;
    }

    public void addCardField(Card add)
    {
        int insertIndex = findEmptyField();

        if (insertIndex == -1)
        {
            Console.WriteLine("No Empty Spot");
            Console.WriteLine();
        }
        else
        {
            field[insertIndex] = add;
        }
    }

    public void addCardBag(Card add)
    {
        int insertIndex = findEmptyBag();

        if (insertIndex == -1)
        {
            Console.WriteLine("No Empty Spot");
            Console.WriteLine();
        }
        else
        {
            field[insertIndex] = add;
        }
    }

    public void deleteCard(int index)
        {
            field[index].name = "   ";
            field[index].suit = "   ";
            field[index].value = 0;
        }

    public void clearField()
    {
        for (int i = 0; i < 4; i++)
        {
            deleteCard(i);
        }
    }

    public void refillField(Deck deck)
    {
        if (countEmptyField() >= 3)
        {
            while (countEmptyField() > 0)
            {
                addCardField(deck.drawCard());
            }
        }
        while (countEmptyField() < 3)
        {
            
        }
        
    }

    public void displayCards()
    {
        Console.WriteLine("Field: ");

        for (int i = 0; i < 4; i++)
        {
            Console.WriteLine(field[i].name);
        }
        
        Console.WriteLine();
        Console.WriteLine("Bag: ");

        for (int i = 0; i < 4; i++)
        {
            Console.WriteLine(field[i].name);
        }

    }
}