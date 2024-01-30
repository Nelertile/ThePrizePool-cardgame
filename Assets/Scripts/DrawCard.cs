using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using Mirror;
public class DrawCard : NetworkBehaviour
{

    public PlayerManager PlayerManager;

    public void drawCard()
    {

        NetworkIdentity networkIdentity = NetworkClient.connection.identity;
        PlayerManager = networkIdentity.GetComponent<PlayerManager>();
        PlayerManager.CmdDealCard();
    }
}
