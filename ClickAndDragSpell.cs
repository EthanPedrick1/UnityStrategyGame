using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickAndDragSpell : MonoBehaviour
{

    private float startPosX;
    private float startPosY;
    private bool isBeingHeld = false;
    private float heldPosX;
    private float heldPosY;


    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (isBeingHeld == true)     //Moves the card with the mouse
        {
            Vector3 mousePos;
            mousePos = Input.mousePosition;
            mousePos = Camera.main.ScreenToWorldPoint(mousePos);

            this.gameObject.transform.localPosition = new Vector3(mousePos.x - startPosX, mousePos.y - startPosY, 0);
        }
    }

    private void OnMouseDown()  //Starts the card movement
    {
        if (Input.GetMouseButtonDown(0))
        {
            //Lets the card snap back to its last place
            heldPosX = this.transform.localPosition.x;
            heldPosY = this.transform.localPosition.y;
            //Puts the currently held card in front of the other cards
            this.GetComponent<Renderer>().sortingLayerID = SortingLayer.NameToID("Currently Held Card");
            this.GetComponent<Renderer>().sortingOrder = 9;
            this.gameObject.layer = 10;

            //Gets the mouse pos in reference to the screen rather than the exact pos
            Vector3 mousePos;
            mousePos = Input.mousePosition;
            mousePos = Camera.main.ScreenToWorldPoint(mousePos);

            //Makes the card center not snap to the mouse, smoother movement
            startPosX = mousePos.x - this.transform.localPosition.x;
            startPosY = mousePos.y - this.transform.localPosition.y;

            isBeingHeld = true;

        }

    }
    private void OnMouseUp()    //Lets go of the card
    {
        isBeingHeld = false;
        this.GetComponent<Renderer>().sortingLayerID = SortingLayer.NameToID("Cards");
        this.GetComponent<Renderer>().sortingOrder = 0;

        PositionSnapping();
    }

    public float CurrentPositionX;
    public float CurrentPositionY;

    private void PositionSnapping()
    {
    //hit1 gets the card that the spell is being used on
    //It then activates the spell effect or sends it back to its original position if null
        LayerMask CardsLayer = LayerMask.GetMask("Cards");
        Vector3 mousePos;
        mousePos = Input.mousePosition;
        mousePos = Camera.main.ScreenToWorldPoint(mousePos);

        Collider2D hit1 = Physics2D.OverlapPoint(mousePos, CardsLayer);
        if (hit1 != null)
        {
            //deals the spell effect, destroys the card when done
            this.gameObject.GetComponent<SpellStats>().SpellEffects(hit1.gameObject);
            GameObject BattleSc = GameObject.Find("GamePlay");
            GameObject appSc = GameObject.Find("__app");
            //moves active cards around
            BattleSc.GetComponent<BattleScript>().CombatHandler(false);
            //moves held cards around
            appSc.GetComponent<PlayerDeckCondition>().GamePlayGen(false);
        } else
        {
            this.gameObject.transform.position = new Vector3(heldPosX, heldPosY, 0);
        }

    }

}
