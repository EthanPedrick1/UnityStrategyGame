using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickAndDrag : MonoBehaviour
{

    private float startPosX;
    private float startPosY;
    private bool isBeingHeld = false;
    private float heldPosX;
    private float heldPosY;

    bool goodHit = true;
    GameObject[] PlHintC = new GameObject[10];

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(isBeingHeld == true)     //Moves the card with the mouse
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
        LayerMask Holders = LayerMask.GetMask("Card Holders");
        //Grabs the mouse pos in reference to the screen
        Vector3 mousePos;
        mousePos = Input.mousePosition;
        mousePos = Camera.main.ScreenToWorldPoint(mousePos);

        //Checks if the mouse is over a holder
        Collider2D hit1 = Physics2D.OverlapPoint(mousePos, Holders);
        
        //puts the card into the holder or back to its previous spot
        if (hit1 != null)
        {
            //Need to ensure that the selected holder is empty
            GameObject BattleSc = GameObject.Find("GamePlay");
            var BScript = BattleSc.GetComponent<BattleScript>();
            GameObject appScCopy = GameObject.Find("__app");

            GameObject[] InPlayCardsCopy = BScript.getInPlayCards(); //Card array
            GameObject[] PlHintC = BScript.getPlHNum();

            if (hit1.name.StartsWith("Start")){
                goodHit = false;
            }

            if (hit1.name.StartsWith("Card"))
            {
                string hit1Name = hit1.name;
                hit1Name = hit1Name.Remove(hit1Name.Length - 1);
                hit1Name = hit1Name.Remove(0, 13);
                int holderInt = int.Parse(hit1Name);
                if (InPlayCardsCopy[holderInt] == null)
                {
                    goodHit = true;
                } else { goodHit = false; }
            }

            this.gameObject.layer = 9;

            if (goodHit == true)
            {
                //Snaps to holder
                this.gameObject.transform.position = hit1.transform.position;
                CurrentPositionX = this.transform.localPosition.x;
                CurrentPositionY = this.transform.localPosition.y;
                GameObject appSc = GameObject.Find("__app");
                //moves active cards around
                BattleSc.GetComponent<BattleScript>().CombatHandler(false);
                //moves held cards around
                appSc.GetComponent<PlayerDeckCondition>().GamePlayGen(false);
            }
            else
            {
                //Snaps back to starting position
                this.gameObject.transform.position = new Vector3(heldPosX, heldPosY, 0);
            }
            
        }
        else
        {
            //Snaps back to starting position
            this.gameObject.transform.position = new Vector3(heldPosX, heldPosY, 0);
        }

    }

}
