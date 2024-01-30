using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DisplayCard : MonoBehaviour
{
    [Header("Card Info")]
    public int displayId;
    public bool displayBack;

    [Header("Core")]
    public List<Card> displayCard = new();
    public int id;
    public int cardValue;

    public Sprite displaySprite;
    public Sprite cardBackSprite;

    private Image cardRenderer;

    void Start()
    {
        cardRenderer = GetComponent<Image>();
        displayCard[0] = CardDatabase.cardList[displayId];
    }

    void Update()
    {
        id = displayCard[0].id;
        cardValue = displayCard[0].cardValue;
        displaySprite = displayCard[0].displaySprite;
        cardBackSprite = displayCard[0].cardBackSprite;

        if (!displayBack)
            cardRenderer.sprite = displaySprite;
        else
            cardRenderer.sprite = cardBackSprite;
    }
}
