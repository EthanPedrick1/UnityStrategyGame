using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDeckCondition : MonoBehaviour
{
    public Sprite[] CardSprites;
    public Sprite[] SpellCardSprites;
    public Sprite[] EnemySprites;

    public GameObject BaseCardMeleePrefab;
    public GameObject BaseCardRangedPrefab;
    public GameObject BaseEnemyMeleePrefab;
    public GameObject BaseEnemyRangedPrefab;

    public string[] PlayerUnitDeck = new string[48];
    public string[] PlayerSpellDeckAr = new string[48];

    public string[] ItemArray = new string[50];
    public string[] SkillArray = new string[50];

    private string[] spellNumArray = new string[14];
    //Spell_type#DefChng#AtkChng#Stun#Blind#Hidden#Heal#Shield#RngDMG#MeleeDMG#FireDMG#IceDMG#ElecDMG#Poison
    private string[] unitNumArray = new string[22];
    //Card_type#HP#Mana#mDMG#rDMG#FireDMG#IceDMG#ElecDMG#item#Skill#(resistances)Stun#Blind#Hidden#RngDMG#MeleeDMG#FireDMG#IceDMG#ElecDMG#Poison#Shield#AttackMult#DefenseMult
    //item is [8]       skill is [9]

    public GameObject[] HeldCards = new GameObject[10]; //For the held cards
    public Vector3[] BattleCardHandVectors = new Vector3[10];
    public GameObject[] CardHandHolders = new GameObject[10];

    public GameObject[] HeldUnits = new GameObject[5];
    public GameObject[] HeldSpells = new GameObject[5];

    public int[,] MapArray = new int[20, 4];

    public int[] EnemyPresets = { 0, 1, 2, 3 };

    public int playerCurrency;
    public int currencyFromEnemies;

    // Start is called before the first frame update
    void Start()
    {
        MapGenerator();
        ItemSkillArraySetups();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Vector3 mousePos;
            mousePos = Input.mousePosition;
            mousePos = Camera.main.ScreenToWorldPoint(mousePos);

            LayerMask StartingDeckDrawButton = LayerMask.GetMask("StartingDeckDrawButton");

            Collider2D hit0 = Physics2D.OverlapPoint(mousePos, StartingDeckDrawButton);
            if (hit0 != null)
            {
                //Debug.Log("Y");
                StartingDeckDisplay();
            }
        }
    }
    //Stun#Blind#Hidden#RngDMG#MeleeDMG#FireDMG#IceDMG#ElecDMG#Poison
    public void StartingDeckDisplay()
    {
        for (int i = 0; i < 12; i++)
        {
            int RandomVal = Random.Range(1, 101);
            if (RandomVal >= 1 && RandomVal < 13) //12
            {
                //no skills or items currently given by default
                Debug.Log("2");
                PlayerUnitDeck[i] = "2#10#0#6#0#0#0#0#1#2#1#1#1#1#1#1#1#1#1#0#0#0";
            } if (RandomVal >= 13 && RandomVal < 25){ //12
                Debug.Log("3");     //2 - 4 NEED CHANGED BACK TO 0
                PlayerUnitDeck[i] = "3#14#0#7#0#0#0#0#1#2#1#1#1#1#1#1#1#1#1#1#0#0";
            } if (RandomVal >= 25 && RandomVal < 37){ //12
                Debug.Log("4");
                PlayerUnitDeck[i] = "4#12#4#0#8#0#0#0#1#2#1#1#1#1#1#1#1#1#1#0#0#0";
            } if (RandomVal >= 37 && RandomVal < 47){ //10
                Debug.Log("5");
                PlayerUnitDeck[i] = "5#15#0#8#0#0#0#0#0#0#1#1#1#1#1#1#1#1#1#0#0#0";
            } if (RandomVal >= 47 && RandomVal < 57){ //10
                Debug.Log("6");
                PlayerUnitDeck[i] = "6#15#0#8#0#0#0#0#0#0#1#1#1#1#1#1#1#1#1#0#0#0";
            } if (RandomVal >= 57 && RandomVal < 67){ //10
                Debug.Log("7");
                PlayerUnitDeck[i] = "7#18#0#13#0#0#0#0#0#0#1#1#1#1#1#1#1#1#1#0#0#0";
            } if (RandomVal >= 67 && RandomVal < 75){ //8
                Debug.Log("8");
                PlayerUnitDeck[i] = "8#16#8#2#0#0#0#0#0#0#1#1#1#1#1#1#1#1#1#0#0#0";
            } if (RandomVal >= 75 && RandomVal < 83){ //8
                Debug.Log("9");
                PlayerUnitDeck[i] = "9#12#10#0#10#0#0#0#0#0#1#1#1#1#1#1#1#1#1#0#0#0";
            } if (RandomVal >= 83 && RandomVal < 90){ //7
                Debug.Log("Jack");
                PlayerUnitDeck[i] = "10#18#10#0#12#0#0#0#0#0#1#1#1#1#1#1#1#1#1#0#0#0";
            } if (RandomVal >= 90 && RandomVal < 95){ //5
                Debug.Log("Queen");
                PlayerUnitDeck[i] = "11#20#6#10#0#0#0#0#0#0#1#1#1#1#1#1#1#1#1#1#0#0";
            } if (RandomVal >= 95 && RandomVal < 100){ //5
                Debug.Log("King");
                PlayerUnitDeck[i] = "12#18#8#10#0#0#0#0#0#0#1#1#1#1#1#1#1#1#1#0#0#0";
            }
        }
//--------------------------Spell Deck------------------------------------------
        for (int i = 0; i < 12; i++)
        {
            int RandomVal = Random.Range(1, 101);
            if (RandomVal >= 1 && RandomVal < 13) //12
            {
                //Debug.Log("2");
                PlayerSpellDeckAr[i] = "0#0#0#0#0#0#0#0#0#0#4#0#0#0";//Fireball
            }
            if (RandomVal >= 13 && RandomVal < 25)
            { //12
                //Debug.Log("3");
                PlayerSpellDeckAr[i] = "1#0#0#0#0#0#0#0#0#0#4#0#0#0";//Fireball
            }
            if (RandomVal >= 25 && RandomVal < 37)
            { //12
                //Debug.Log("4");
                PlayerSpellDeckAr[i] = "0#0#0#0#0#0#0#0#0#0#4#0#0#0";//Fireball
            }
            if (RandomVal >= 37 && RandomVal < 47)
            { //10
                //Debug.Log("5");
                PlayerSpellDeckAr[i] = "1#0#0#0#0#0#0#0#0#0#4#0#0#0";//Fireball
            }
            if (RandomVal >= 47 && RandomVal < 57)
            { //10
                //Debug.Log("6");
                PlayerSpellDeckAr[i] = "0#0#0#0#0#0#0#0#0#0#4#0#0#0";//Fireball
            }
            if (RandomVal >= 57 && RandomVal < 67)
            { //10
                //Debug.Log("7");
                PlayerSpellDeckAr[i] = "1#0#0#0#0#0#0#0#0#0#4#0#0#0";//Fireball
            }
            if (RandomVal >= 67 && RandomVal < 75)
            { //8
                //Debug.Log("8");
                PlayerSpellDeckAr[i] = "0#0#0#0#0#0#0#0#0#0#4#0#0#0";//Fireball
            }
            if (RandomVal >= 75 && RandomVal < 83)
            { //8
                //Debug.Log("9");
                PlayerSpellDeckAr[i] = "1#0#0#0#0#0#0#0#0#0#4#0#0#0";//Fireball
            }
            if (RandomVal >= 83 && RandomVal < 90)
            { //7
                //Debug.Log("Jack");
                PlayerSpellDeckAr[i] = "0#0#0#0#0#0#0#0#0#0#4#0#0#0";//Fireball
            }
            if (RandomVal >= 90 && RandomVal < 95)
            { //5
                //Debug.Log("Queen");
                PlayerSpellDeckAr[i] = "1#0#0#0#0#0#0#0#0#0#4#0#0#0";//Fireball
            }
            if (RandomVal >= 95 && RandomVal < 100)
            { //5
                //Debug.Log("King");
                PlayerSpellDeckAr[i] = "0#0#0#0#0#0#0#0#0#0#4#0#0#0";//Fireball
            }
        }
        CardGenerator();
    }


//--------------------------------------------------------------------------------------
    public void CardGenerator()//THIS IS FOR THE STARTING DECK SCENE
    {
        GameObject PlH0 = GameObject.Find("Card Holder (0)");
        Transform PLH0T = PlH0.transform;
        Vector3 positionPlH0 = PLH0T.position;

        GameObject PlH1 = GameObject.Find("Card Holder (1)");
        Transform PLH1T = PlH1.transform;
        Vector3 positionPlH1 = PLH1T.position;

        GameObject PlH2 = GameObject.Find("Card Holder (2)");
        Transform PLH2T = PlH2.transform;
        Vector3 positionPlH2 = PLH2T.position;

        GameObject PlH3 = GameObject.Find("Card Holder (3)");
        Transform PLH3T = PlH3.transform;
        Vector3 positionPlH3 = PLH3T.position;

        GameObject PlH4 = GameObject.Find("Card Holder (4)");
        Transform PLH4T = PlH4.transform;
        Vector3 positionPlH4 = PLH4T.position;

        GameObject PlH5 = GameObject.Find("Card Holder (5)");
        Transform PLH5T = PlH5.transform;
        Vector3 positionPlH5 = PLH5T.position;

        GameObject PlH6 = GameObject.Find("Card Holder (6)");
        Transform PLH6T = PlH6.transform;
        Vector3 positionPlH6 = PLH6T.position;

        GameObject PlH7 = GameObject.Find("Card Holder (7)");
        Transform PLH7T = PlH7.transform;
        Vector3 positionPlH7 = PLH7T.position;

        GameObject PlH8 = GameObject.Find("Card Holder (8)");
        Transform PLH8T = PlH8.transform;
        Vector3 positionPlH8 = PLH8T.position;

        GameObject PlH9 = GameObject.Find("Card Holder (9)");
        Transform PLH9T = PlH9.transform;
        Vector3 positionPlH9 = PLH9T.position;

        GameObject PlH10 = GameObject.Find("Card Holder (10)");
        Transform PLH10T = PlH10.transform;
        Vector3 positionPlH10 = PLH10T.position;

        GameObject PlH11 = GameObject.Find("Card Holder (11)");
        Transform PLH11T = PlH11.transform;
        Vector3 positionPlH11 = PLH11T.position;
        //create a gameObject
        //Assign it a sprite based on which card its supposed to be
        //Assign its position to the correct holder based on its place in the deck

        for (int i=0; i<12; i++)
        {
            Vector3 CardPositioning;
            CardPositioning = new Vector3(0, 0, 0);
            if (i == 0)
            {
                CardPositioning = positionPlH0;
            } 
            else if (i == 1)
            {
                CardPositioning = positionPlH1;
            }
            else if (i == 2)
            {
                CardPositioning = positionPlH2;
            }
            else if (i == 3)
            {
                CardPositioning = positionPlH3;
            }
            else if (i == 4)
            {
                CardPositioning = positionPlH4;
            }
            else if (i == 5)
            {
                CardPositioning = positionPlH5;
            }
            else if (i == 6)
            {
                CardPositioning = positionPlH6;
            }
            else if (i == 7)
            {
                CardPositioning = positionPlH7;
            }
            else if (i == 8)
            {
                CardPositioning = positionPlH8;
            }
            else if (i == 9)
            {
                CardPositioning = positionPlH9;
            }
            else if (i == 10)
            {
                CardPositioning = positionPlH10;
            }
            else if (i == 11)
            {
                CardPositioning = positionPlH11;
            }

            //-----------------------------------------------------------------------//
            if (!string.IsNullOrEmpty(PlayerUnitDeck[i]))
            {
                unitNumArray = PlayerUnitDeck[i].Split('#');
            }
            if (unitNumArray[0].Equals("2"))
            {
                GameObject PCard2 = new GameObject();
                PCard2.name = "PCard2";
                PCard2.AddComponent<BoxCollider2D>();
                PCard2.GetComponent<BoxCollider2D>().size = new Vector2(6, 8);

                PCard2.layer = 9;

                PCard2.AddComponent<SpriteRenderer>();
                PCard2.GetComponent<SpriteRenderer>().sprite = CardSprites[0];
                PCard2.GetComponent<Renderer>().sortingLayerID = SortingLayer.NameToID("Cards");

                PCard2.transform.localScale = new Vector3(0.264272f, 0.264272f, 1f);
                PCard2.transform.position = CardPositioning;
            } else if (unitNumArray[0].Equals("3"))
            {
                GameObject PCard3 = new GameObject();
                PCard3.name = "PCard3";
                PCard3.AddComponent<BoxCollider2D>();
                PCard3.GetComponent<BoxCollider2D>().size = new Vector2(6, 8);

                PCard3.layer = 9;
                PCard3.transform.localScale = new Vector3(0.264272f, 0.264272f, 1f);
                PCard3.transform.position = CardPositioning;

                PCard3.AddComponent<SpriteRenderer>();
                PCard3.GetComponent<SpriteRenderer>().sprite = CardSprites[1];
                PCard3.GetComponent<Renderer>().sortingLayerID = SortingLayer.NameToID("Cards");
            } else if (unitNumArray[0].Equals("4"))
            {
                GameObject PCard4 = new GameObject();
                PCard4.name = "PCard4";
                PCard4.AddComponent<BoxCollider2D>();
                PCard4.GetComponent<BoxCollider2D>().size = new Vector2(6, 8);

                PCard4.layer = 9;
                PCard4.transform.localScale = new Vector3(0.264272f, 0.264272f, 1f);
                PCard4.transform.position = CardPositioning;

                PCard4.AddComponent<SpriteRenderer>();
                PCard4.GetComponent<SpriteRenderer>().sprite = CardSprites[2];
                PCard4.GetComponent<Renderer>().sortingLayerID = SortingLayer.NameToID("Cards");
            } else if (unitNumArray[0].Equals("5"))
            {
                GameObject PCard5 = new GameObject();
                PCard5.name = "PCard5";
                PCard5.AddComponent<BoxCollider2D>();
                PCard5.GetComponent<BoxCollider2D>().size = new Vector2(6, 8);

                PCard5.layer = 9;
                PCard5.transform.localScale = new Vector3(0.264272f, 0.264272f, 1f);
                PCard5.transform.position = CardPositioning;

                PCard5.AddComponent<SpriteRenderer>();
                PCard5.GetComponent<SpriteRenderer>().sprite = CardSprites[3];
                PCard5.GetComponent<Renderer>().sortingLayerID = SortingLayer.NameToID("Cards");
            } else if (unitNumArray[0].Equals("6"))
            {
                GameObject PCard6 = new GameObject();
                PCard6.name = "PCard6";
                PCard6.AddComponent<BoxCollider2D>();
                PCard6.GetComponent<BoxCollider2D>().size = new Vector2(6, 8);

                PCard6.layer = 9;
                PCard6.transform.localScale = new Vector3(0.264272f, 0.264272f, 1f);
                PCard6.transform.position = CardPositioning;

                PCard6.AddComponent<SpriteRenderer>();
                PCard6.GetComponent<SpriteRenderer>().sprite = CardSprites[4];
                PCard6.GetComponent<Renderer>().sortingLayerID = SortingLayer.NameToID("Cards");
            } else if (unitNumArray[0].Equals("7"))
            {
                GameObject PCard7 = new GameObject();
                PCard7.name = "PCard7";
                PCard7.AddComponent<BoxCollider2D>();
                PCard7.GetComponent<BoxCollider2D>().size = new Vector2(6, 8);

                PCard7.layer = 9;
                PCard7.transform.localScale = new Vector3(0.264272f, 0.264272f, 1f);
                PCard7.transform.position = CardPositioning;

                PCard7.AddComponent<SpriteRenderer>();
                PCard7.GetComponent<SpriteRenderer>().sprite = CardSprites[5];
                PCard7.GetComponent<Renderer>().sortingLayerID = SortingLayer.NameToID("Cards");
            } else if (unitNumArray[0].Equals("8"))
            {
                GameObject PCard8 = new GameObject();
                PCard8.name = "PCard8";
                PCard8.AddComponent<BoxCollider2D>();
                PCard8.GetComponent<BoxCollider2D>().size = new Vector2(6, 8);

                PCard8.layer = 9;
                PCard8.transform.localScale = new Vector3(0.264272f, 0.264272f, 1f);
                PCard8.transform.position = CardPositioning;

                PCard8.AddComponent<SpriteRenderer>();
                PCard8.GetComponent<SpriteRenderer>().sprite = CardSprites[6];
                PCard8.GetComponent<Renderer>().sortingLayerID = SortingLayer.NameToID("Cards");
            } else if (unitNumArray[0].Equals("9"))
            {
                GameObject PCard9 = new GameObject();
                PCard9.name = "PCard9";
                PCard9.AddComponent<BoxCollider2D>();
                PCard9.GetComponent<BoxCollider2D>().size = new Vector2(6, 8);

                PCard9.layer = 9;
                PCard9.transform.localScale = new Vector3(0.264272f, 0.264272f, 1f);
                PCard9.transform.position = CardPositioning;

                PCard9.AddComponent<SpriteRenderer>();
                PCard9.GetComponent<SpriteRenderer>().sprite = CardSprites[7];
                PCard9.GetComponent<Renderer>().sortingLayerID = SortingLayer.NameToID("Cards");
            } else if (unitNumArray[0].Equals("10"))
            {
                GameObject PCard10 = new GameObject();
                PCard10.name = "PCard10";
                PCard10.AddComponent<BoxCollider2D>();
                PCard10.GetComponent<BoxCollider2D>().size = new Vector2(6, 8);

                PCard10.layer = 9;
                PCard10.transform.localScale = new Vector3(0.264272f, 0.264272f, 1f);
                PCard10.transform.position = CardPositioning;

                PCard10.AddComponent<SpriteRenderer>();
                PCard10.GetComponent<SpriteRenderer>().sprite = CardSprites[8];
                PCard10.GetComponent<Renderer>().sortingLayerID = SortingLayer.NameToID("Cards");
            } else if (unitNumArray[0].Equals("11"))
            {
                GameObject PCard11 = new GameObject();
                PCard11.name = "PCard11";
                PCard11.AddComponent<BoxCollider2D>();
                PCard11.GetComponent<BoxCollider2D>().size = new Vector2(6, 8);

                PCard11.layer = 9;
                PCard11.transform.localScale = new Vector3(0.264272f, 0.264272f, 1f);
                PCard11.transform.position = CardPositioning;

                PCard11.AddComponent<SpriteRenderer>();
                PCard11.GetComponent<SpriteRenderer>().sprite = CardSprites[9];
                PCard11.GetComponent<Renderer>().sortingLayerID = SortingLayer.NameToID("Cards");
            } else if (unitNumArray[0].Equals("12"))
            {
                GameObject PCard12 = new GameObject();
                PCard12.name = "PCard12";
                PCard12.AddComponent<BoxCollider2D>();
                PCard12.GetComponent<BoxCollider2D>().size = new Vector2(6, 8);

                PCard12.layer = 9;
                PCard12.transform.localScale = new Vector3(0.264272f, 0.264272f, 1f);
                PCard12.transform.position = CardPositioning;

                PCard12.AddComponent<SpriteRenderer>();
                PCard12.GetComponent<SpriteRenderer>().sprite = CardSprites[10];
                PCard12.GetComponent<Renderer>().sortingLayerID = SortingLayer.NameToID("Cards");
            } else
            {
                //Debug.Log("N");
            }

        }
    }

//--------------------------------------------------------------------------------------
//THIS IS FOR STANDARD COMBAT
    int UnitDeckIndex = 0;
    int SpellDeckIndex = 0;
    //TurnCounter is used to get the position within the card deck array
    public void GamePlayGen(bool spawning)
    {
        //This is the holders for the held cards
        //and needs to be put in a separate function so its not called every turn
        GameObject PlH0 = GameObject.Find("Start Holder (0)");
        Transform PLH0T = PlH0.transform;
        Vector3 positionPlH0 = PLH0T.position;
        BattleCardHandVectors[0] = positionPlH0;
        CardHandHolders[0] = PlH0;

        GameObject PlH1 = GameObject.Find("Start Holder (1)");
        Transform PLH1T = PlH1.transform;
        Vector3 positionPlH1 = PLH1T.position;
        BattleCardHandVectors[1] = positionPlH1;
        CardHandHolders[1] = PlH1;

        GameObject PlH2 = GameObject.Find("Start Holder (2)");
        Transform PLH2T = PlH2.transform;
        Vector3 positionPlH2 = PLH2T.position;
        BattleCardHandVectors[2] = positionPlH2;
        CardHandHolders[2] = PlH2;

        GameObject PlH3 = GameObject.Find("Start Holder (3)");
        Transform PLH3T = PlH3.transform;
        Vector3 positionPlH3 = PLH3T.position;
        BattleCardHandVectors[3] = positionPlH3;
        CardHandHolders[3] = PlH3;

        GameObject PlH4 = GameObject.Find("Start Holder (4)");
        Transform PLH4T = PlH4.transform;
        Vector3 positionPlH4 = PLH4T.position;
        BattleCardHandVectors[4] = positionPlH4;
        CardHandHolders[4] = PlH4;

        GameObject PlH5 = GameObject.Find("Start Holder (5)");
        Transform PLH5T = PlH5.transform;
        Vector3 positionPlH5 = PLH5T.position;
        BattleCardHandVectors[5] = positionPlH5;
        CardHandHolders[5] = PlH5;

        GameObject PlH6 = GameObject.Find("Start Holder (6)");
        Transform PLH6T = PlH6.transform;
        Vector3 positionPlH6 = PLH6T.position;
        BattleCardHandVectors[6] = positionPlH6;
        CardHandHolders[6] = PlH6;

        GameObject PlH7 = GameObject.Find("Start Holder (7)");
        Transform PLH7T = PlH7.transform;
        Vector3 positionPlH7 = PLH7T.position;
        BattleCardHandVectors[7] = positionPlH7;
        CardHandHolders[7] = PlH7;

        GameObject PlH8 = GameObject.Find("Start Holder (8)");
        Transform PLH8T = PlH8.transform;
        Vector3 positionPlH8 = PLH8T.position;
        BattleCardHandVectors[8] = positionPlH8;
        CardHandHolders[8] = PlH8;

        GameObject PlH9 = GameObject.Find("Start Holder (9)");
        Transform PLH9T = PlH9.transform;
        Vector3 positionPlH9 = PLH9T.position;
        BattleCardHandVectors[9] = positionPlH9;
        CardHandHolders[9] = PlH9;

        /*GameObject PlH10 = GameObject.Find("Start Holder (10)");
        Transform PLH10T = PlH10.transform;
        Vector3 positionPlH10 = PLH10T.position;
        BattleCardHandVectors[10] = positionPlH10;*/

        if (UnitDeckIndex == 0)
        {
            //spawn the 1st 2 cards of each type
            UnitCardGen(3);
            SpellCardGen(5);
        } else if(UnitDeckIndex == 1)
        {
            UnitCardGen(4);
            SpellCardGen(6);
        } else
        {
            HandChecker(spawning);
        }
        
    }
    //Check the number of currently held cards
    public void HandChecker(bool spawning)
    {
        LayerMask Cards = LayerMask.GetMask("Cards");
        Collider2D hit0 = Physics2D.OverlapPoint(BattleCardHandVectors[0], Cards);
        if (hit0 != null)   //hit returns the card in that holder
        {
            HeldCards[0] = hit0.gameObject;
            //Tells which card was put in the holder
        }
        else { HeldCards[0] = null; }

        Collider2D hit1 = Physics2D.OverlapPoint(BattleCardHandVectors[1], Cards);
        if (hit1 != null){HeldCards[1] = hit1.gameObject;}
        else { HeldCards[0] = null; }

        Collider2D hit2 = Physics2D.OverlapPoint(BattleCardHandVectors[2], Cards);
        if (hit2 != null) { HeldCards[2] = hit2.gameObject; }
        else { HeldCards[2] = null; }

        Collider2D hit3 = Physics2D.OverlapPoint(BattleCardHandVectors[3], Cards);
        if (hit3 != null) { HeldCards[3] = hit3.gameObject; }
        else { HeldCards[3] = null; }

        Collider2D hit4 = Physics2D.OverlapPoint(BattleCardHandVectors[4], Cards);
        if (hit4 != null) { HeldCards[4] = hit4.gameObject; }
        else { HeldCards[4] = null; }

        Collider2D hit5 = Physics2D.OverlapPoint(BattleCardHandVectors[5], Cards);
        if (hit5 != null) { HeldCards[5] = hit5.gameObject; }
        else { HeldCards[5] = null; }

        Collider2D hit6 = Physics2D.OverlapPoint(BattleCardHandVectors[6], Cards);
        if (hit6 != null) { HeldCards[6] = hit6.gameObject; }
        else { HeldCards[6] = null; }

        Collider2D hit7 = Physics2D.OverlapPoint(BattleCardHandVectors[7], Cards);
        if (hit7 != null) { HeldCards[7] = hit7.gameObject; }
        else { HeldCards[7] = null; }

        Collider2D hit8 = Physics2D.OverlapPoint(BattleCardHandVectors[8], Cards);
        if (hit8 != null) { HeldCards[8] = hit8.gameObject; }
        else { HeldCards[8] = null; }

        Collider2D hit9 = Physics2D.OverlapPoint(BattleCardHandVectors[9], Cards);
        if (hit9 != null) { HeldCards[9] = hit9.gameObject; }
        else { HeldCards[9] = null; }

        /*Collider2D hit10 = Physics2D.OverlapPoint(BattleCardHandVectors[10], Cards);
        if (hit10 != null) { HeldCards[10] = hit10.gameObject; }
        else { HeldCards[10] = null; }*/

        HeldUnits[0] = HeldCards[0];
        HeldUnits[1] = HeldCards[1];
        HeldUnits[2] = HeldCards[2];
        HeldUnits[3] = HeldCards[3];
        HeldUnits[4] = HeldCards[4];

        HeldSpells[0] = HeldCards[5];
        HeldSpells[1] = HeldCards[6];
        HeldSpells[2] = HeldCards[7];
        HeldSpells[3] = HeldCards[8];
        HeldSpells[4] = HeldCards[9];
        HeldCardsOrdering(spawning);
    }

    public void HeldCardsOrdering(bool spawning)
    {
        bool unitMoved = true;
        bool spellMoved = true;

        while (unitMoved == true)
        {
            unitMoved = false;
            for (int i = 0; i < HeldUnits.Length; i++)
            {
                if (HeldUnits[i] != null)
                {//Checks if current spot has a unit
                    if (i + 1 <= 4 && HeldUnits[i + 1] == null)
                    {//Checks if next spot is empty
                        HeldUnits[i + 1] = HeldUnits[i];
                        HeldUnits[i] = null;
                        unitMoved = true;
                    }
                }
            }
        }

        while (spellMoved == true)
        {
            spellMoved = false;
            for (int i = 4; i >= 0; i--)
            {
                if (HeldSpells[i] != null)
                {//Checks if current spot has a unit
                    if (i - 1 >= 0 && HeldSpells[i - 1] == null)
                    {//Checks if next spot is empty
                        HeldSpells[i - 1] = HeldSpells[i];
                        HeldSpells[i] = null;
                        spellMoved = true;
                    }
                }
            }
        }
        //Send new data to HeldCards array
        HeldCards[0] = HeldUnits[0];
        HeldCards[1] = HeldUnits[1];
        HeldCards[2] = HeldUnits[2];
        HeldCards[3] = HeldUnits[3];
        HeldCards[4] = HeldUnits[4];

        HeldCards[5] = HeldSpells[0];
        HeldCards[6] = HeldSpells[1];
        HeldCards[7] = HeldSpells[2];
        HeldCards[8] = HeldSpells[3];
        HeldCards[9] = HeldSpells[4];

        //Move the actual card objects
        for (int i = 0; i < HeldCards.Length; i++)
        {
            if (HeldCards[i] != null)
            {
                HeldCards[i].transform.position = BattleCardHandVectors[i];
            }
        }
        //needs to be told what position to spawn things
        if (spawning == true)
        {
            //loop through HeldUnits (4-0) to see what opening is closest to 4
            for (int i=4; i >= 0; i--)
            {
                if (HeldUnits[i] == null)
                {
                    //spawn the unit at the first open position and then break out of the loop
                    UnitCardGen(i);
                    break;
                }
            }

            //loop through HeldSpells (0-4) to see what opening is closest to 0
            for (int i = 0; i <= 4; i++)
            {
                if (HeldSpells[i] == null)
                {
                    //spawn the spell at the first open position and then break out of the loop
                    int loc = i + 5;
                    SpellCardGen(loc);
                    break;
                }
            }
        }
    }

    
    //Spell cards can be given their own function or be added to this one
    public void UnitCardGen(int cardSpawnLocation)
    {//Card_type#HP#Mana#mDMG#rDMG#item#ability
        int[] unitIntArray = new int[22];
        int[] unitSpecialStatArray = new int[9];
        int[] unitBuffStatsArray = new int[3];
        //unitIntArray holds all stats
        //unitSpecialStatArray holds stat resistances
        if (!string.IsNullOrEmpty(PlayerUnitDeck[UnitDeckIndex]))
        {
            unitNumArray = PlayerUnitDeck[UnitDeckIndex].Split('#');
            for (int j=0; j<unitNumArray.Length; j++)
            {
                if (int.TryParse(unitNumArray[j], out int value))
                {
                    unitIntArray[j] = value;
                } else { Debug.Log("Thats pretty bad"); }
            }
            unitSpecialStatArray[0] = unitIntArray[10];
            unitSpecialStatArray[1] = unitIntArray[11];
            unitSpecialStatArray[2] = unitIntArray[12];
            unitSpecialStatArray[3] = unitIntArray[13];
            unitSpecialStatArray[4] = unitIntArray[14];
            unitSpecialStatArray[5] = unitIntArray[15];
            unitSpecialStatArray[6] = unitIntArray[16];
            unitSpecialStatArray[7] = unitIntArray[17];
            unitSpecialStatArray[8] = unitIntArray[18];

            unitBuffStatsArray[0] = unitIntArray[19];
            unitBuffStatsArray[1] = unitIntArray[20];
            unitBuffStatsArray[2] = unitIntArray[21];
        }

        //The spawning
        //check if its ranged or melee, then create the prefab
        //prefab has: sprite, size, collider, clickandDrag, and statsScript(needs setup)
        GameObject PCard2;
        int[] ItemIntArray = ItemArrayGet(unitIntArray[8]);
        int[] SkillIntArray = SkillArrayGet(unitIntArray[9]);
        if (unitIntArray[2] == 0) //melee unit
        {
            PCard2 = Instantiate(BaseCardMeleePrefab);
            PCard2.transform.position = BattleCardHandVectors[cardSpawnLocation];
            PCard2.name = "PCard2";
            PCard2.GetComponent<CardStats>().CardStatSetup(unitIntArray[1], unitIntArray[2], unitIntArray[3], unitIntArray[4], unitIntArray[5], unitIntArray[6], unitIntArray[7], ItemIntArray, SkillIntArray, unitSpecialStatArray, unitBuffStatsArray);
        } else //ranged unit
        {
            PCard2 = Instantiate(BaseCardRangedPrefab);
            PCard2.transform.position = BattleCardHandVectors[cardSpawnLocation];
            PCard2.name = "PCard2";
            PCard2.GetComponent<CardStats>().CardStatSetup(unitIntArray[1], unitIntArray[2], unitIntArray[3], unitIntArray[4], unitIntArray[5], unitIntArray[6], unitIntArray[7], ItemIntArray, SkillIntArray, unitSpecialStatArray, unitBuffStatsArray);
        }
        //will need to attach unit photo prefab later once they are made
        //can be done the same way that the status effects are done
        /*int cardSprite = unitIntArray[0] - 2;
        * PCard2.GetComponent<SpriteRenderer>().sprite = CardSprites[cardSprite];
        * ^^was how i did the old sprites
        */

        UnitDeckIndex++;
    }

    public void SpellCardGen(int cardSpawnLocation)
    {
        int[] spellIntArray = new int[14];
        if (!string.IsNullOrEmpty(PlayerSpellDeckAr[SpellDeckIndex]))
        {
            spellNumArray = PlayerSpellDeckAr[SpellDeckIndex].Split('#');
            for (int j = 0; j < spellNumArray.Length; j++)
            {
                if (int.TryParse(spellNumArray[j], out int value))
                {
                    spellIntArray[j] = value;
                }
                else { Debug.Log("Thats pretty bad"); }
            }
        }
        //The spawning
        GameObject PSpell2 = new GameObject();
        PSpell2.name = "PSpell2";
        PSpell2.AddComponent<BoxCollider2D>();
        PSpell2.GetComponent<BoxCollider2D>().size = new Vector2(6, 8);

        PSpell2.AddComponent<SpellStats>();
        PSpell2.GetComponent<SpellStats>().SpellStatsSetup(spellIntArray[1], spellIntArray[2], spellIntArray[3], spellIntArray[4], spellIntArray[5], spellIntArray[6], spellIntArray[7], spellIntArray[8], spellIntArray[9], spellIntArray[10], spellIntArray[11], spellIntArray[12], spellIntArray[13]);

        PSpell2.AddComponent<ClickAndDragSpell>();
        PSpell2.layer = 9;

        PSpell2.AddComponent<SpriteRenderer>();
        PSpell2.GetComponent<SpriteRenderer>().sprite = SpellCardSprites[spellIntArray[0]];
        PSpell2.GetComponent<Renderer>().sortingLayerID = SortingLayer.NameToID("Cards");

        PSpell2.transform.localScale = new Vector3(0.264272f, 0.264272f, 1f);
        PSpell2.transform.position = BattleCardHandVectors[cardSpawnLocation];

        SpellDeckIndex++;
    }

    //int EnemySpawnCounter = 0;
    public void EnemyPresetSetup()
    {
        //Will pass along a random preset once those are made
        EnemyGen(EnemyPresets[0]);
    }

    public void EnemyGen(int EPresetT)
    {
        int EPreset = EPresetT;
        //Debug.Log("Working");
        GameObject EH0 = GameObject.Find("Card Holder (E0)");
        Transform EH0T = EH0.transform;
        Vector3 positionEH0 = EH0T.position;

        GameObject EH1 = GameObject.Find("Card Holder (E1)");
        Transform EH1T = EH1.transform;
        Vector3 positionEH1 = EH1T.position;

        GameObject EH2 = GameObject.Find("Card Holder (E2)");
        Transform EH2T = EH2.transform;
        Vector3 positionEH2 = EH2T.position;

        GameObject EH3 = GameObject.Find("Card Holder (E3)");
        Transform EH3T = EH3.transform;
        Vector3 positionEH3 = EH3T.position;

        GameObject EH4 = GameObject.Find("Card Holder (E4)");
        Transform EH4T = EH4.transform;
        Vector3 positionEH4 = EH4T.position;

        GameObject EH5 = GameObject.Find("Card Holder (E5)");
        Transform EH5T = EH5.transform;
        Vector3 positionEH5 = EH5T.position;

        GameObject EH6 = GameObject.Find("Card Holder (E6)");
        Transform EH6T = EH6.transform;
        Vector3 positionEH6 = EH6T.position;

        GameObject EH7 = GameObject.Find("Card Holder (E7)");
        Transform EH7T = EH7.transform;
        Vector3 positionEH7 = EH7T.position;

        GameObject EH8 = GameObject.Find("Card Holder (E8)");
        Transform EH8T = EH8.transform;
        Vector3 positionEH8 = EH8T.position;

        GameObject EH9 = GameObject.Find("Card Holder (E9)");
        Transform EH9T = EH9.transform;
        Vector3 positionEH9 = EH9T.position;

        //-------------------------------------------------------------------//
        GameObject battleSc = GameObject.Find("GamePlay");
        //health, mana, mDMG, rDMG. fire, ice, elec, []special, []buffs
        GameObject ECard2;
        int[] ItemIntArray = new int[13];
        int[] SkillIntArray = new int[13];
        if (EPreset == 0)
        {
            currencyFromEnemies = 6;

            ECard2 = Instantiate(BaseEnemyMeleePrefab);
            ECard2.transform.position = positionEH0;
            ECard2.name = "ECard2";
            ECard2.GetComponent<CardStats>().CardStatSetup(10, 0, 4, 0, 0, 0, 0, ItemArrayGet(0), SkillArrayGet(0), new int[] { 0, 0, 0, 1, 1, 1, 1, 1, 1 }, new int[] { 0, 0 });

            //------------------------------------//
            ECard2 = Instantiate(BaseEnemyRangedPrefab);
            ECard2.transform.position = positionEH1;
            ECard2.name = "ECard2";
            ECard2.GetComponent<CardStats>().CardStatSetup(12, 0, 6, 0, 0, 0, 0, ItemArrayGet(0), SkillArrayGet(0), new int[] { 0, 0, 0, 1, 1, 1, 1, 1, 1 }, new int[] { 0, 0 });

            //------------------------------------//
            ECard2 = Instantiate(BaseEnemyRangedPrefab);
            ECard2.transform.position = positionEH5;
            ECard2.name = "ECard2";
            ECard2.GetComponent<CardStats>().CardStatSetup(8, 0, 2, 0, 0, 0, 0, ItemArrayGet(0), SkillArrayGet(0), new int[] { 0, 0, 0, 1, 1, 1, 1, 1, 1 }, new int[] { 0, 0 });
            battleSc.GetComponent<BattleScript>().InPlayEnemies[0] = ECard2;



            /*GameObject ECard2 = new GameObject();
            ECard2.name = "ECard2";
            ECard2.AddComponent<BoxCollider2D>();
            ECard2.GetComponent<BoxCollider2D>().size = new Vector2(6, 8);

            ECard2.AddComponent<CardStats>();  
            ECard2.GetComponent<CardStats>().CardStatSetup(10, 0, 4, 0, 0, 0, 0, new int[] { 0, 0, 0, 1, 1, 1, 1, 1, 1 }, new int[] { 0, 0 });
            ECard2.layer = 9;

            ECard2.AddComponent<SpriteRenderer>();
            ECard2.GetComponent<SpriteRenderer>().sprite = EnemySprites[0];
            ECard2.GetComponent<Renderer>().sortingLayerID = SortingLayer.NameToID("Cards");

            ECard2.transform.localScale = new Vector3(0.264272f, 0.264272f, 1f);
            ECard2.transform.position = positionEH0;
            battleSc.GetComponent<BattleScript>().InPlayEnemies[0] = ECard2;

            //------------------------------------//
            GameObject ECard3 = new GameObject();
            ECard3.name = "ECard3";
            ECard3.AddComponent<BoxCollider2D>();
            ECard3.GetComponent<BoxCollider2D>().size = new Vector2(6, 8);

            ECard3.AddComponent<CardStats>();  
            ECard3.GetComponent<CardStats>().CardStatSetup(10, 0, 4, 0, 0, 0, 0, new int[] { 0, 0, 0, 1, 1, 1, 1, 1, 1 }, new int[] { 0, 0 });
            ECard3.layer = 9;
        
            ECard3.AddComponent<SpriteRenderer>();
            ECard3.GetComponent<SpriteRenderer>().sprite = EnemySprites[0];
            ECard3.GetComponent<Renderer>().sortingLayerID = SortingLayer.NameToID("Cards");

            ECard3.transform.localScale = new Vector3(0.264272f, 0.264272f, 1f);
            ECard3.transform.position = positionEH1;
            battleSc.GetComponent<BattleScript>().InPlayEnemies[1] = ECard3;

            //------------------------------------//
            GameObject ECard4 = new GameObject();
            ECard4.name = "ECard4";
            ECard4.AddComponent<BoxCollider2D>();
            ECard4.GetComponent<BoxCollider2D>().size = new Vector2(6, 8);

            ECard4.AddComponent<CardStats>();  
            ECard4.GetComponent<CardStats>().CardStatSetup(10, 0, 4, 0, 0, 0, 0, new int[] { 0, 0, 0, 1, 1, 1, 1, 1, 1 }, new int[] { 0, 0 });
            ECard4.layer = 9;

            ECard4.AddComponent<SpriteRenderer>();
            ECard4.GetComponent<SpriteRenderer>().sprite = EnemySprites[0];
            ECard4.GetComponent<Renderer>().sortingLayerID = SortingLayer.NameToID("Cards");

            ECard4.transform.localScale = new Vector3(0.264272f, 0.264272f, 1f);
            ECard4.transform.position = positionEH5;
            battleSc.GetComponent<BattleScript>().InPlayEnemies[5] = ECard4;*/
        }
        battleSc.GetComponent<BattleScript>().EnemyCurrencyPreset(currencyFromEnemies);
    }
//----------------------------------------------------------------------------------------------------
    public void PlayerCurrencyChange(int change)
    {
        playerCurrency = playerCurrency + change;
        Debug.Log("Current player currency is: " + playerCurrency);
    }

//----------------------------------------------------------------------------------------------------
    void MapGenerator()
    {
        int itemsPerColumn = 0;
        for (int columnCounter = 0; columnCounter < 20; columnCounter++)
        {
            itemsPerColumn = Random.Range(1, 5);//returns 1,2,3, or 4 for column size
            for (int i=0; i<itemsPerColumn; i++)
            {
                int mapIcon = Random.Range(1, 5);//returns 1,2,3 or 4 for item in spot
                MapArray[columnCounter, i] = mapIcon;
            }
        }
    }
    public int currentRound = 0;
    public void RoundIncrease()
    {
        currentRound++;
    }
    public int RoundGet()
    {
        return currentRound;
    }
    /*Map Generation:
     * 20 columns
     * determine how many items will be in the column
     * loop throuh each item spot in the column
     * give the spot a random item
     */
        public int[,] MapArrayReturner()
    {
        return MapArray;
    }

//----------------------------------------------------------------------------------------
    public void ItemSkillArraySetups()
    {//This is all of the item and ability stats
     //Types: 0(passive), 1(effects self), 2(effects any selected unit), 3(effects any random ally), 4(effects any random enemy)
     //Type#DefChng#AtkChng#Stun#Blind#Hidden#Heal#Shield#RngDMG#MeleeDMG#FireDMG#IceDMG#ElecDMG#Poison
        SkillArray[0] = "0#0#0#0#0#0#0#0#0#0#0#0#0#0";//Nothing
        SkillArray[1] = "2#0#0#0#0#0#0#0#0#0#4#0#0#0";//Fireball
        SkillArray[2] = "2#0#0#0#0#0#0#0#4#0#0#0#0#0";//Arrow Volley

        ItemArray[0] = "0#0#0#0#0#0#0#0#0#0#0#0#0#0";//nothing
        ItemArray[1] = "2#0#0#0#0#0#0#0#0#0#4#0#0#0";//Fireball scroll
    }
    public int[] ItemArrayGet(int i)
    {
        int[] ItemIntArray = new int[14];
        string[] ItemParseArray = new string[14];
        if (!string.IsNullOrEmpty(ItemArray[i]))
        {
            ItemParseArray = ItemArray[i].Split('#');
            for (int j = 0; j < ItemParseArray.Length; j++)
            {
                if (int.TryParse(ItemParseArray[j], out int value))
                {
                    ItemIntArray[j] = value;
                }
                else { Debug.Log("Thats pretty bad"); }
            }
        }
        return ItemIntArray;
    }
    public int[] SkillArrayGet(int s)
    {
        int[] SkillIntArray = new int[14];
        string[] SkillParseArray = new string[14];
        if (!string.IsNullOrEmpty(SkillArray[s]))
        {
            SkillParseArray = SkillArray[s].Split('#');
            for (int j = 0; j < SkillParseArray.Length; j++)
            {
                if (int.TryParse(SkillParseArray[j], out int value))
                {
                    SkillIntArray[j] = value;
                }
                else { Debug.Log("Thats pretty bad"); }
            }
        }
        return SkillIntArray;
    }

}