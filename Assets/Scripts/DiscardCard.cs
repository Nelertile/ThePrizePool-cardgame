using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;

public class DiscardCard : MonoBehaviour
{
    public PlayerManager PlayerManager;
    public GameObject discardCardButton;

    void Update()
    {
        if (transform.childCount > 0)
        {
            discardCardButton.SetActive(true);
        }
        else
        {
            discardCardButton.SetActive(false);
        }
    }

    public void discardCard()
    {
        NetworkIdentity networkIdentity = NetworkClient.connection.identity;
        PlayerManager = networkIdentity.GetComponent<PlayerManager>();
        GameObject discardCard = transform.GetChild(0).gameObject;
        PlayerManager.CmdDiscardCard(discardCard);
    }
}
