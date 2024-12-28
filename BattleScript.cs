using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleScript : MonoBehaviour
{
    public int[] HeldCards = new int[11];   //For the in-hand cards
    public GameObject[] InPlayCards = new GameObject[10]; //For the in-play cards
    GameObject[] topPlayer = new GameObject[5];
    GameObject[] bottomPlayer = new GameObject[5];
    GameObject[] topEnemy = new GameObject[5];
    GameObject[] bottomEnemy = new GameObject[5];

    //The "location" of the card holders
    public Vector3 positionPlH0;
    public Vector3 positionPlH1;
    public Vector3 positionPlH2;
    public Vector3 positionPlH3;
    public Vector3 positionPlH4;
    public Vector3 positionPlH5;
    public Vector3 positionPlH6;
    public Vector3 positionPlH7;
    public Vector3 positionPlH8;
    public Vector3 positionPlH9;
    public Vector3[] positionPlH = new Vector3[10];
    public Vector3[] positionEH = new Vector3[10];

    //These are the active card holders, not held card holders
    public GameObject[] PlHNum = new GameObject[10];
    public GameObject[] EHNum = new GameObject[10];

    public int activePlayerCards = 0;
    public int activeEnemyCards = 0;

    public GameObject[] InPlayEnemies = new GameObject[10];

    int currencyFromEnemyPreset;

    // Start is called before the first frame update
    void Start()
    {
        GameObject appSc = GameObject.Find("__app");
        appSc.GetComponent<PlayerDeckCondition>().GamePlayGen(true);
        appSc.GetComponent<PlayerDeckCondition>().EnemyPresetSetup();
        HolderPositionCheck();
        //CardPositionChecking();
    }
    // Update is called once per frame
    void Update()
    {
        //CardPositionChecking();
        //ActiveCardPusher();
    }
    public void HolderPositionCheck()
    {
        //Setup for player card position checking  -------------------------------//
        PlHNum[0] = GameObject.Find("Card Holder (0)");
        Transform PLH0T = PlHNum[0].transform;
        positionPlH[0] = PLH0T.position; //Used to reference the position of a card holder

        PlHNum[1] = GameObject.Find("Card Holder (1)");
        Transform PLH1T = PlHNum[1].transform;
        positionPlH[1] = PLH1T.position;

        PlHNum[2] = GameObject.Find("Card Holder (2)");
        Transform PLH2T = PlHNum[2].transform;
        positionPlH[2] = PLH2T.position;

        PlHNum[3] = GameObject.Find("Card Holder (3)");
        Transform PLH3T = PlHNum[3].transform;
        positionPlH[3] = PLH3T.position;

        PlHNum[4] = GameObject.Find("Card Holder (4)");
        Transform PLH4T = PlHNum[4].transform;
        positionPlH[4] = PLH4T.position;

        PlHNum[5] = GameObject.Find("Card Holder (5)");
        Transform PLH5T = PlHNum[5].transform;
        positionPlH[5] = PLH5T.position;

        PlHNum[6] = GameObject.Find("Card Holder (6)");
        Transform PLH6T = PlHNum[6].transform;
        positionPlH[6] = PLH6T.position;

        PlHNum[7] = GameObject.Find("Card Holder (7)");
        Transform PLH7T = PlHNum[7].transform;
        positionPlH[7] = PLH7T.position;

        PlHNum[8] = GameObject.Find("Card Holder (8)");
        Transform PLH8T = PlHNum[8].transform;
        positionPlH[8] = PLH8T.position;

        PlHNum[9] = GameObject.Find("Card Holder (9)");
        Transform PLH9T = PlHNum[9].transform;
        positionPlH[9] = PLH9T.position;
        //-----------------------------------------------------------------------
        EHNum[0] = GameObject.Find("Card Holder (E4)");
        Transform EH0T = EHNum[0].transform;
        positionEH[0] = EH0T.position;
        EHNum[1] = GameObject.Find("Card Holder (E3)");
        Transform EH1T = EHNum[1].transform;
        positionEH[1] = EH1T.position;
        EHNum[2] = GameObject.Find("Card Holder (E2)");
        Transform EH2T = EHNum[2].transform;
        positionEH[2] = EH2T.position;
        EHNum[3] = GameObject.Find("Card Holder (E1)");
        Transform EH3T = EHNum[3].transform;
        positionEH[3] = EH3T.position;
        EHNum[4] = GameObject.Find("Card Holder (E0)");
        Transform EH4T = EHNum[4].transform;
        positionEH[4] = EH4T.position;

        EHNum[5] = GameObject.Find("Card Holder (E9)");
        Transform EH5T = EHNum[5].transform;
        positionEH[5] = EH5T.position;
        EHNum[6] = GameObject.Find("Card Holder (E8)");
        Transform EH6T = EHNum[6].transform;
        positionEH[6] = EH6T.position;
        EHNum[7] = GameObject.Find("Card Holder (E7)");
        Transform EH7T = EHNum[7].transform;
        positionEH[7] = EH7T.position;
        EHNum[8] = GameObject.Find("Card Holder (E6)");
        Transform EH8T = EHNum[8].transform;
        positionEH[8] = EH8T.position;
        EHNum[9] = GameObject.Find("Card Holder (E5)");
        Transform EH9T = EHNum[9].transform;
        positionEH[9] = EH9T.position;
    }
    /*public void CardPositionChecking()
    {
        LayerMask Cards = LayerMask.GetMask("Cards");
        for (int i=0; i<positionPlH.Length; i++)
        {
            Collider2D hit0 = Physics2D.OverlapPoint(positionPlH[i], Cards);
            if (hit0. != null)
            {
                InPlayCards[i] = hit0.gameObject;
            } else { InPlayCards = null; }
        }

    }*/
    public GameObject[] getInPlayCards()
    {
        return InPlayCards;//ignore this function
    }
    public GameObject[] getPlHNum()
    {
        return PlHNum;
    }
    public GameObject[] getInPlayEnemies()
    {
        return InPlayEnemies;
    }
    //New Combat Function:
    //create 4 arrays, 2 for each side so that the top and bottom rows are separated
    //on the player side, the arrays go in order 0-4
    //on the enemy side, the arrays go  in order4-0
    //this is so the '4's for each side are next to each other
    //fill out the arrays for both sides by checking each position for a card
    //move player and enemy cards as far forward as possible
    //IF there is an opposing card at the front of the top row:
    //then perform ranged attacks with the top row
    //repeat that IF statement for the bottom row
    //check the frontmost holder to see IF cards need moved forwards again
    //IF there is an opposing card at the front of the top row:
    //then perform melee attacks with the top row
    //repeat that IF statement for the bottom row
    //player attacks will happen first for ranged and melee 
    public void CombatHandler(bool attacking)
    {//This fills the arrays for both rows of both sides
        LayerMask Cards = LayerMask.GetMask("Cards");
        for (int i = 0; i < 5; i++)
        {
            Collider2D hit0 = Physics2D.OverlapPoint(positionPlH[i], Cards);
            if (hit0 != null)
            {
                topPlayer[i] = hit0.gameObject;
            }
            else { topPlayer[i] = null; }
        }
        for (int i = 5; i < 10; i++)
        {
            Collider2D hit0 = Physics2D.OverlapPoint(positionPlH[i], Cards);
            if (hit0 != null)
            {
                bottomPlayer[i-5] = hit0.gameObject;
            }
            else { bottomPlayer[i-5] = null; }
        }

        for (int i = 0; i < 5; i++)
        {
            Collider2D hit0 = Physics2D.OverlapPoint(positionEH[i], Cards);
            if (hit0 != null)
            {
                topEnemy[i] = hit0.gameObject;
                //Debug.Log("Top enemy found: " + topEnemy[i].name);
                //Debug.Log(topEnemy[i]);
            }
            else { topEnemy[i] = null; }

        }
        for (int i = 5; i < 10; i++)
        {
            Collider2D hit0 = Physics2D.OverlapPoint(positionEH[i], Cards);
            if (hit0 != null)
            {
                bottomEnemy[i-5] = hit0.gameObject;
            }
            else { bottomEnemy[i-5] = null; }
        }

        ActiveCardPusher();
        if (attacking == true)
        {
            AttackHits();
        }
    }
    public void ActiveCardPusher()
    {//This pushes the cards forwards
        bool changed = true;
        bool changed2 = true;
        bool changed3 = true;
        bool changed4 = true;
        while (changed == true)
        {
            changed = false;
            for (int i=0; i<topPlayer.Length; i++)
            {
                if (topPlayer[i] != null)
                {
                    if (i+1 < 5 && topPlayer[i+1] == null)
                    {
                        topPlayer[i + 1] = topPlayer[i];
                        topPlayer[i] = null;
                        changed = true;
                    }
                }
            }
        }
        while (changed2 == true)
        {
            changed2 = false;
            for (int i = 0; i < bottomPlayer.Length; i++)
            {
                if (bottomPlayer[i] != null)
                {
                    if (i + 1 < 5 && bottomPlayer[i + 1] == null)
                    {
                        bottomPlayer[i + 1] = bottomPlayer[i];
                        bottomPlayer[i] = null;
                        changed2 = true;
                    }
                }
            }
        }
        while (changed3 == true)
        {
            changed3 = false;
            for (int i = 0; i < topEnemy.Length; i++)
            {
                if (topEnemy[i] != null)
                {
                    if (i + 1 < 5 && topEnemy[i + 1] == null)
                    {
                        topEnemy[i + 1] = topEnemy[i];
                        topEnemy[i] = null;
                        changed3 = true;
                    }
                }
            }
        }
        while (changed4 == true)
        {
            changed4 = false;
            for (int i = 0; i < bottomEnemy.Length; i++)
            {
                if (bottomEnemy[i] != null)
                {
                    if (i + 1 < 5 && bottomEnemy[i + 1] == null)
                    {
                        bottomEnemy[i + 1] = bottomEnemy[i];
                        bottomEnemy[i] = null;
                        changed4 = true;
                    }
                }
            }
        }

        for (int h=0; h<topPlayer.Length; h++)
        {
            if (topPlayer[h] != null)
            {
                topPlayer[h].transform.position = positionPlH[h];
            }
        }
        for (int h = 0; h < bottomPlayer.Length; h++)
        {
            if (bottomPlayer[h] != null)
            {
                bottomPlayer[h].transform.position = positionPlH[h+5];
            }
        }
        for (int h = 0; h < topEnemy.Length; h++)
        {
            if (topEnemy[h] != null)
            {
                topEnemy[h].transform.position = positionEH[h];
            }
        }
        for (int h = 0; h < bottomEnemy.Length; h++)
        {
            if (bottomEnemy[h] != null)
            {
                bottomEnemy[h].transform.position = positionEH[h+5];
            }
        }
    }
    //Need to do the actual attacking now:
    public void AttackHits()
    {
        bool enemyExists1 = true;
        bool enemyExists2 = true;
        for (int i=0; i<topEnemy.Length; i++)
        {
            if (topEnemy[i] != null)
            {
                enemyExists1 = true;
                break;
            } else { enemyExists1 = false; }
        }
        for (int i = 0; i < bottomEnemy.Length; i++)
        {
            if (bottomEnemy[i] != null)
            {
                enemyExists2 = true;
                break;
            }
            else { enemyExists2 = false; }
        }
        if (enemyExists1 == false && enemyExists2 == false)
        {
            Debug.Log("No enemies alive");
            return;
        }
        //----------------- RANGED ATTACK ----------------------------------------------
        for (int i=0; i<topPlayer.Length; i++)
        {
            if (topPlayer[i] != null)
            {
                //Debug.Log("topPlayer[i]: " + topPlayer[i]);
                GameObject playerUnit = topPlayer[i];
                int[] damageTotal = playerUnit.GetComponent<CardStats>().GetStandardAttack();
                if (damageTotal[7] != 0)//7 is the ranged attack stat
                {
                    //Debug.Log("topPlayer ranged damage: " + damageTotal[7]);
                    //attack the closest opponent
                    for (int j=4; j >=0; j--)
                    {//have to loop from 4 to 0 for the correct order
                        //Debug.Log("ranged j loop: "  + j);
                        if (topEnemy[j] != null)
                        {
                            //Debug.Log("Attacking this enemy: " + topEnemy[j]);
                            GameObject enemyUnit = topEnemy[i];
                            enemyUnit.GetComponent<CardStats>().DamageCalculator(damageTotal);
                            break;//so it only hits the first one found
                        }
                    }
                }
            }
        }
        for (int i = 0; i < bottomPlayer.Length; i++)
        {
            if (bottomPlayer[i] != null)
            {
                GameObject playerUnit = bottomPlayer[i];
                int[] damageTotal = playerUnit.GetComponent<CardStats>().GetStandardAttack();
                if (damageTotal[7] != 0)
                {
                    //attack the closest opponent
                    for (int j = 4; j >= 0; j--)
                    {//have to loop from 4 to 0 for the correct order
                        if (bottomEnemy[j] != null)
                        {
                            GameObject enemyUnit = bottomEnemy[i];
                            enemyUnit.GetComponent<CardStats>().DamageCalculator(damageTotal);
                            break;//so it only hits the first one found
                        }
                    }
                }
            }
        }
        for (int i = 0; i < topEnemy.Length; i++)
        {
            if (topEnemy[i] != null)
            {
                //Debug.Log("topEnemy[i]: " + topEnemy[i]);
                int[] damageTotal = topEnemy[i].GetComponent<CardStats>().GetStandardAttack();
                if (damageTotal[7] != 0)
                {
                    //attack the closest opponent
                    for (int j = 4; j >= 0; j--)
                    {//have to loop from 4 to 0 for the correct order
                        if (topPlayer[j] != null)
                        {
                            topPlayer[j].GetComponent<CardStats>().DamageCalculator(damageTotal);
                            break;//so it only hits the first one found
                        }
                    }
                }
            }
        }
        for (int i = 0; i < bottomEnemy.Length; i++)
        {
            if (bottomEnemy[i] != null)
            {
                int[] damageTotal = bottomEnemy[i].GetComponent<CardStats>().GetStandardAttack();
                if (damageTotal[7] != 0)
                {
                    //attack the closest opponent
                    for (int j = 4; j >= 0; j--)
                    {//have to loop from 4 to 0 for the correct order
                        if (bottomPlayer[j] != null)
                        {
                            bottomPlayer[j].GetComponent<CardStats>().DamageCalculator(damageTotal);
                            break;//so it only hits the first one found
                        }
                    }
                }
            }
        }
        //----------------- MELEE ATTACK ----------------------------------------------
        for (int i = 0; i < topPlayer.Length; i++)
        {
            if (topPlayer[i] != null)
            {
                //Debug.Log("(melee) topPlayer[i]: " + topPlayer[i]);
                int[] damageTotal = topPlayer[i].GetComponent<CardStats>().GetStandardAttack();
                if (damageTotal[8] != 0)//8 is the melee attack stat
                {
                    //Debug.Log("topPlayer melee damage: " + damageTotal[8]);
                    for (int g=4; g >= 0; g--)
                    {
                        //Debug.Log("melee j loop: " + g);
                        if (topEnemy[g] != null)
                        {
                            topEnemy[g].GetComponent<CardStats>().DamageCalculator(damageTotal);
                            break;
                        }
                    }
                }
            }
        }
        for (int i = 0; i < bottomPlayer.Length; i++)
        {
            if (bottomPlayer[i] != null)
            {
                int[] damageTotal = bottomPlayer[i].GetComponent<CardStats>().GetStandardAttack();
                if (damageTotal[8] != 0)
                {
                    //attack the closest opponent
                    for (int j = 4; j >= 0; j--)
                    {//have to loop from 4 to 0 for the correct order
                        if (bottomEnemy[j] != null)
                        {
                            bottomEnemy[j].GetComponent<CardStats>().DamageCalculator(damageTotal);
                            break;//so it only hits the first one found
                        }
                    }
                }
            }
        }
        for (int i = 0; i < topEnemy.Length; i++)
        {
            if (topEnemy[i] != null)
            {
                int[] damageTotal = topEnemy[i].GetComponent<CardStats>().GetStandardAttack();
                if (damageTotal[8] != 0)
                {
                    //attack the closest opponent
                    for (int j = 4; j >= 0; j--)
                    {//have to loop from 4 to 0 for the correct order
                        if (topPlayer[j] != null)
                        {
                            topPlayer[j].GetComponent<CardStats>().DamageCalculator(damageTotal);
                            break;//so it only hits the first one found
                        }
                    }
                }
            }
        }
        for (int i = 0; i < bottomEnemy.Length; i++)
        {
            if (bottomEnemy[i] != null)
            {
                int[] damageTotal = bottomEnemy[i].GetComponent<CardStats>().GetStandardAttack();
                if (damageTotal[8] != 0)
                {
                    //attack the closest opponent
                    for (int j = 4; j >= 0; j--)
                    {//have to loop from 4 to 0 for the correct order
                        if (bottomPlayer[j] != null)
                        {
                            bottomPlayer[j].GetComponent<CardStats>().DamageCalculator(damageTotal);
                            break;//so it only hits the first one found
                        }
                    }
                }
            }
        }
        for (int i=0; i < topPlayer.Length; i++)
        {
            if (topPlayer[i] != null)
            {
                topPlayer[i].GetComponent<CardStats>().StatusDecrement();
            }
        }
        for (int i = 0; i < bottomPlayer.Length; i++)
        {
            if (bottomPlayer[i] != null)
            {
                bottomPlayer[i].GetComponent<CardStats>().StatusDecrement();
            }
        }
        for (int i = 0; i < topEnemy.Length; i++)
        {
            if (topEnemy[i] != null)
            {
                topEnemy[i].GetComponent<CardStats>().StatusDecrement();
            }
        }
        for (int i = 0; i < bottomEnemy.Length; i++)
        {
            if (bottomEnemy[i] != null)
            {
                bottomEnemy[i].GetComponent<CardStats>().StatusDecrement();
            }
        }
        CombatHandler(false);
        fightEnder();
    }

    public void fightEnder()
    {
        activePlayerCards = 0;
        activeEnemyCards = 0;
        GameObject appSc = GameObject.Find("__app");
        for (int i=0; i < topPlayer.Length; i++)
        {
            if (topPlayer[i] != null)
            {
                activePlayerCards++;
            }
        }
        for (int i = 0; i < bottomPlayer.Length; i++)
        {
            if (bottomPlayer[i] != null)
            {
                activePlayerCards++;
            }
        }
        for (int i = 0; i < topEnemy.Length; i++)
        {
            if (topEnemy[i] != null)
            {
                activeEnemyCards++;
            }
        }
        for (int i = 0; i < bottomEnemy.Length; i++)
        {
            if (bottomEnemy[i] != null)
            {
                activeEnemyCards++;
            }
        }

        if (activePlayerCards <= 0)
        {
            //lose
            appSc.GetComponent<SceneChangeMaster>().Scene6();
        } else if(activeEnemyCards <= 0)
        {
            //win
            appSc.GetComponent<PlayerDeckCondition>().PlayerCurrencyChange(currencyFromEnemyPreset);
            appSc.GetComponent<PlayerDeckCondition>().RoundIncrease();
            appSc.GetComponent<SceneChangeMaster>().Scene6();
        }
    }

    public void EnemyCurrencyPreset(int currency)
    {
        currencyFromEnemyPreset = currency;
    }
}


//GameObject EActive = InPlayEnemies[i];
//int Damage = EActive.GetComponent<CardStats>().MeleeDamage;


//int Damage = PT4.GetComponent<CardStats>().MeleeDamage;