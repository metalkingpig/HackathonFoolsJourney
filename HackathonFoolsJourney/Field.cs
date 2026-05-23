using System;
using System.Collections.Generic;

public class PlayingField
{
    Card[] field = new Card[4]; //Field

    public int findEmpty()
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

    public void addCard()
    {
        int insertIndex = findEmpty();

        if (insertIndex == -1)
        {
            
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

    

}