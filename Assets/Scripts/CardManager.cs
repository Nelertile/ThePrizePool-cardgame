using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CardManager : MonoBehaviour
{

    public List<Card> deck = new();
    public List<Card> discardDeck = new();

    public GameObject prizePoolDeck;

    public Sprite cardBackSprite;
    public Sprite cardEmptySprite;

    public bool requireReshuffle;

    void Start()
    {
        // Create Initial Deck
        for (int i = 0; i < 52; i++)
        {
            deck.Add(CardDatabase.cardList[i + 1]);
        }
        // for (int i = 0; i < deck.Count; i++)
        // {
        //     Debug.Log(deck[i].id);
        // }
        Shuffle(deck);

    }
    static public void Shuffle(List<Card> deck)
    {
        for (int i = deck.Count - 1; i > 0; --i)
        {
            int x = Random.Range(1, deck.Count);
            Card temp = deck[i];
            deck[i] = deck[x];
            deck[x] = temp;
        }
        Debug.Log("SHUFFLED");
        // for (int i = 0; i < deck.Count; i++)
        // {
        //     Debug.Log(deck[i].id);
        // }
    }

    void Update()
    {
        if (discardDeck.Count >= 1)
        {
            prizePoolDeck.GetComponent<Image>().sprite = cardBackSprite;
            var tempColor = prizePoolDeck.GetComponent<Image>().color;
            tempColor.a = 1f;
            prizePoolDeck.GetComponent<Image>().color = tempColor;
        }
        else
        {
            prizePoolDeck.GetComponent<Image>().sprite = cardEmptySprite;
            var tempColor = prizePoolDeck.GetComponent<Image>().color;
            tempColor.a = .05f;
            prizePoolDeck.GetComponent<Image>().color = tempColor;

        }

        if (requireReshuffle)
        {
            deck = new(discardDeck);
            discardDeck = new();
            Shuffle(deck);
            requireReshuffle = false;
        }
    }
}
