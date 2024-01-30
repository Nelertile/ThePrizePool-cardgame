using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;
using System;
using System.Linq;

public class PlayerManager : NetworkBehaviour
{
    public GameObject CardManager;
    public int maxCards = 4;
    public int playerCards;
    public GameObject Card;
    public GameObject PlayerArea;
    public GameObject OpponentArea;
    public GameObject TradeZone;
    public GameObject OpponentTradeZone;

    public GameObject DiscardPile;
    private bool requireDiscard;

    private List<Card> deck;
    private List<Card> discardDeck;

    void Update()
    {
        if (playerCards <= 4)
            DiscardPile.GetComponent<BoxCollider2D>().enabled = false;
        else
            DiscardPile.GetComponent<BoxCollider2D>().enabled = true;
    }
    public override void OnStartClient()
    {
        base.OnStartClient();

        DiscardPile = GameObject.Find("CardHolder");
        PlayerArea = GameObject.Find("PlayerCardContainer");
        OpponentArea = GameObject.Find("OpponentCardContainer");
        TradeZone = GameObject.Find("PlayerOfferPanel");
        OpponentTradeZone = GameObject.Find("OpponentOfferPanel");
    }

    [Server]
    public override void OnStartServer()
    {
        CardManager = GameObject.Find("CardManager");
        deck = CardManager.GetComponent<CardManager>().deck;
        discardDeck = CardManager.GetComponent<CardManager>().discardDeck;
    }

    [Command]
    public void CmdDealCard()
    {
        deck = CardManager.GetComponent<CardManager>().deck;

        if (playerCards == maxCards)
        {
            requireDiscard = true;
        }

        if (playerCards > maxCards)
        {
            return;
        }

        if (deck.Count <= 0)
        {
            throw new Exception("No more cards left to draw");
        }

        GameObject card = Instantiate(Card, new Vector2(0, 0), Quaternion.identity);
        NetworkServer.Spawn(card, connectionToClient);
        card.GetComponent<DisplayCard>().displayId = deck[0].id;
        RpcShowCard(card, "Dealt", deck[0].id);
        //error workaround
        List<Card> temp = new(CardManager.GetComponent<CardManager>().deck);
        temp.RemoveAt(0);
        if (temp.Count == 0)
            CardManager.GetComponent<CardManager>().deck.RemoveAll(item => item.id <= 100);
        else
            CardManager.GetComponent<CardManager>().deck = new(temp);
        playerCards++;
    }

    public void PlayCardToDiscard(GameObject card)
    {
        CmdPlayCardToDiscard(card);
    }

    [Command]
    void CmdPlayCardToDiscard(GameObject card)
    {
        RpcShowCard(card, "Discard", 0);
    }

    [Command]
    public void CmdDiscardCard(GameObject discardCard)
    {
        deck = CardManager.GetComponent<CardManager>().deck;
        discardDeck = CardManager.GetComponent<CardManager>().discardDeck;
        // check if has discard immunity

        Card card = discardCard.GetComponent<DisplayCard>().displayCard[0];

        discardDeck.Add(card);

        Destroy(discardCard);
        --playerCards;
        if (deck.Count == 0)
        {
            CardManager.GetComponent<CardManager>().requireReshuffle = true;
        }
    }

    [ClientRpc]
    void RpcShowCard(GameObject card, string type, int id)
    {
        if (type == "Dealt")
        {
            card.GetComponent<DisplayCard>().displayId = id;
            if (isOwned)
                card.transform.SetParent(PlayerArea.transform);
            else
            {
                card.GetComponent<DisplayCard>().displayBack = true;
                card.transform.SetParent(OpponentArea.transform);
            }
        }
        else if (type == "Played")
        {
            if (isOwned)
                card.transform.SetParent(TradeZone.transform);
            else
                card.transform.SetParent(OpponentTradeZone.transform);
        }
        else if (type == "Discard")
        {
            card.transform.SetParent(DiscardPile.transform);
        }
    }

}
