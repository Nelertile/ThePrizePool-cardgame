using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;

public class DragCard : NetworkBehaviour
{

    public GameObject Canvas;
    public PlayerManager PlayerManager;

    private bool isDragging = false;
    private bool isDraggable = true;
    private GameObject startParent;
    private GameObject dropZone;
    private GameObject tradeZone;
    private GameObject discardZone;
    private bool isOverDropZone;

    void Start()
    {
        Canvas = GameObject.Find("Canvas");
        tradeZone = GameObject.Find("PlayerOfferPanel");
        discardZone = GameObject.Find("CardHolder");
        if (!isOwned)
        {
            isDraggable = false;
        }
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        isOverDropZone = true;
        dropZone = collision.gameObject;
    }
    void OnTriggerExit2D(Collider2D collision)
    {
        isOverDropZone = false;
        dropZone = null;
    }
    public void StartDrag()
    {
        if (!isDraggable) return;
        isDragging = true;
        startParent = transform.parent.gameObject;
    }

    public void EndDrag()
    {
        if (!isDraggable) return;
        isDragging = false;
        if (isOverDropZone)
        {
            transform.SetParent(dropZone.transform);
            isDraggable = false;
            NetworkIdentity networkIdentity = NetworkClient.connection.identity;
            PlayerManager = networkIdentity.GetComponent<PlayerManager>();
            if (dropZone == tradeZone)
            {
                Debug.Log("trade");
                // trade
            }
            else if (dropZone == discardZone)
            {
                Debug.Log("discard");
                PlayerManager.PlayCardToDiscard(gameObject);
            }
        }
        else
        {
            transform.SetParent(startParent.transform);
        }
    }

    void Update()
    {
        if (isDragging)
        {
            transform.SetParent(Canvas.transform, true);
            transform.position = new Vector2(Input.mousePosition.x, Input.mousePosition.y);
        }
    }

}
