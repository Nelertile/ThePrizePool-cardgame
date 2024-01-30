using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardDatabase : MonoBehaviour
{
    public static List<Card> cardList = new();

    public Sprite cardBack;
    public Sprite[] cardSprites;

    void Awake()
    {
        cardList.Add(new Card(0, 0, cardSprites, cardBack));
        cardList.Add(new Card(1, 1, cardSprites, cardBack));
        cardList.Add(new Card(2, 1, cardSprites, cardBack));
        cardList.Add(new Card(3, 1, cardSprites, cardBack));
        cardList.Add(new Card(4, 1, cardSprites, cardBack));
        cardList.Add(new Card(5, 2, cardSprites, cardBack));
        cardList.Add(new Card(6, 2, cardSprites, cardBack));
        cardList.Add(new Card(7, 2, cardSprites, cardBack));
        cardList.Add(new Card(8, 2, cardSprites, cardBack));
        cardList.Add(new Card(9, 3, cardSprites, cardBack));
        cardList.Add(new Card(10, 3, cardSprites, cardBack));
        cardList.Add(new Card(11, 3, cardSprites, cardBack));
        cardList.Add(new Card(12, 3, cardSprites, cardBack));
        cardList.Add(new Card(13, 4, cardSprites, cardBack));
        cardList.Add(new Card(14, 4, cardSprites, cardBack));
        cardList.Add(new Card(15, 4, cardSprites, cardBack));
        cardList.Add(new Card(16, 4, cardSprites, cardBack));
        cardList.Add(new Card(17, 5, cardSprites, cardBack));
        cardList.Add(new Card(18, 5, cardSprites, cardBack));
        cardList.Add(new Card(19, 5, cardSprites, cardBack));
        cardList.Add(new Card(20, 5, cardSprites, cardBack));
        cardList.Add(new Card(21, 6, cardSprites, cardBack));
        cardList.Add(new Card(22, 6, cardSprites, cardBack));
        cardList.Add(new Card(23, 6, cardSprites, cardBack));
        cardList.Add(new Card(24, 6, cardSprites, cardBack));
        cardList.Add(new Card(25, 7, cardSprites, cardBack));
        cardList.Add(new Card(26, 7, cardSprites, cardBack));
        cardList.Add(new Card(27, 7, cardSprites, cardBack));
        cardList.Add(new Card(28, 7, cardSprites, cardBack));
        cardList.Add(new Card(29, 8, cardSprites, cardBack));
        cardList.Add(new Card(30, 8, cardSprites, cardBack));
        cardList.Add(new Card(31, 8, cardSprites, cardBack));
        cardList.Add(new Card(32, 8, cardSprites, cardBack));
        cardList.Add(new Card(33, 9, cardSprites, cardBack));
        cardList.Add(new Card(34, 9, cardSprites, cardBack));
        cardList.Add(new Card(35, 9, cardSprites, cardBack));
        cardList.Add(new Card(36, 9, cardSprites, cardBack));
        cardList.Add(new Card(37, 1, cardSprites, cardBack));
        cardList.Add(new Card(38, 1, cardSprites, cardBack));
        cardList.Add(new Card(39, 1, cardSprites, cardBack));
        cardList.Add(new Card(40, 1, cardSprites, cardBack));
        cardList.Add(new Card(41, 1, cardSprites, cardBack));
        cardList.Add(new Card(42, 1, cardSprites, cardBack));
        cardList.Add(new Card(43, 1, cardSprites, cardBack));
        cardList.Add(new Card(44, 1, cardSprites, cardBack));
        cardList.Add(new Card(45, 1, cardSprites, cardBack));
        cardList.Add(new Card(46, 1, cardSprites, cardBack));
        cardList.Add(new Card(47, 1, cardSprites, cardBack));
        cardList.Add(new Card(48, 1, cardSprites, cardBack));
        cardList.Add(new Card(49, 1, cardSprites, cardBack));
        cardList.Add(new Card(50, 1, cardSprites, cardBack));
        cardList.Add(new Card(51, 1, cardSprites, cardBack));
        cardList.Add(new Card(52, 1, cardSprites, cardBack));
    }
}
