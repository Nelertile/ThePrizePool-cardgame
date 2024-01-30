using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[System.Serializable]


public class Card
{
    public int id;
    public int cardValue;

    public Sprite displaySprite;
    public Sprite cardBackSprite;

    public Card()
    {

    }

    public Card(int ID, int CardValue, Sprite[] DisplaySprites, Sprite CardBackSprite)
    {
        id = ID;
        cardValue = CardValue;
        displaySprite = DisplaySprites[id];
        cardBackSprite = CardBackSprite;
    }
}
