using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CardStats : MonoBehaviour
{
    private int Health = 10;
    private int Mana = 10;
    public int MeleeDamage = 4;
    private int RangeDamage = 5;
    private int FireDMG = 0;
    private int IceDMG = 0;
    private int ElecDMG = 0;

    private int Shield = 0;         
    private int stunnedTurns = 0;
    private int blindTurns = 0;
    private int hiddenTurns = 0;
    private int poisonStatus = 0;

    private int[] SpecialStats = new int[9];//these are resistances
    //Stun#Blind#Hidden#RngDMG#MeleeDMG#FireDMG#IceDMG#ElecDMG#Poison
    private int attackChng = 0;     //needs setup
    private int damageTaken = 0;

    private int itemCooldownTimer = 0;
    private int[] Item = new int[14];
    private int skillCooldownTimer = 0;
    private int[] Skill = new int[14];

    private bool statusFlag = false;
    private int[] activeStatusArray = new int[4];
    private float statusIconPosition = 0;

    public GameObject shieldIconPrefab;
    public GameObject atkUpPrefab;
    public GameObject atkDwnPrefab;
    public GameObject healthUIPrefab;

    public GameObject blindStatusPrefab;
    public GameObject poisonStatusPrefab;
    public GameObject stunStatusPrefab;
    public GameObject hiddenStatusPrefab;

    //-------------------------------------------
    private GameObject shieldIconInstance;
    private GameObject atkUpInstance;
    private GameObject atkDwnInstance;
    private GameObject healthUIInstance;

    private GameObject blindStatusInstance;
    private GameObject poisonStatusInstance;
    private GameObject stunStatusInstance;
    private GameObject hiddenStatusInstance;

    private Text healthText;    //reference to the text component
    private Text shieldText;
    private Text atkText;
    private Text blindText;
    private Text poisonText;
    private Text stunText;
    private Text hiddenText;



    GameObject appSc;
    // Start is called before the first frame update
    void Start()
    {
        appSc = GameObject.Find("__app");
    }

    // Update is called once per frame
    void Update()
    {

    }
    //health, mana, mDMG, rDMG. fire, ice, elec, []special, []buffs
    public void CardStatSetup(int health, int mana, int mDMG, int rDMG, int fire, int ice, int elec, int[] item, int[] skill, int[] special, int[] buffs)
    {
        Health = health;
        Mana = mana;
        MeleeDamage = mDMG;
        RangeDamage = rDMG;
        FireDMG = fire;
        IceDMG = ice;
        ElecDMG = elec;
        for (int i = 0; i < SpecialStats.Length; i++)
        {
            SpecialStats[i] = special[i];
        }
        setShield(buffs[0]);
        attackChng = buffs[1];
        //defenseMult = buffs[2];//removes shield by amount
        healthUIInstance = Instantiate(healthUIPrefab, this.transform);
        healthUIInstance.transform.localPosition = new Vector3(-1.42f, 3.58f, 0f);
        healthText = healthUIInstance.GetComponentInChildren<Text>();
        HealthChange(0);
        Item = item;
        Skill = skill;
    }

    //DamageCalculator is called each time a card is hit
    public void DamageCalculator(int[] DamageStats)
    {
        //#DefChng#AtkChng#Stun#Blind#Hidden#Heal#Shield#RngDMG#MeleeDMG#FireDMG#IceDMG#ElecDMG#Poison
        //defenseMult = defenseMult + DamageStats[0];
        attackChng = attackChng + DamageStats[1];
        setAtkChng(attackChng);
        //if attackChng > 1
        stunnedTurns = DamageStats[2] - SpecialStats[0];
        if (stunnedTurns < 0) { stunnedTurns = 0; }
        if (stunnedTurns > 0) { statusFlag = true; }
        //if stunnedTurns > 0, set flag for needing a function call
        blindTurns = DamageStats[3] - SpecialStats[1];
        if (blindTurns < 0) { blindTurns = 0; }
        if (blindTurns > 0) { statusFlag = true; }
        //if blindTurns > 0, set flag for needing a function call
        hiddenTurns = DamageStats[4] - SpecialStats[2];
        if (hiddenTurns < 0) { hiddenTurns = 0; }
        if (hiddenTurns > 0) { statusFlag = true; }
        //if hiddenTurns > 0, set flag for needing a function call
        if (DamageStats[5] > 0) { HealthChange(DamageStats[5]); }
        Shield = Shield - DamageStats[6];
        setShield(Shield);
        //RngDMG + MeleeDMG + FireDMG + IceDMG + ElecDMG
        damageTaken = ((DamageStats[7] * SpecialStats[3]) + (DamageStats[8] * SpecialStats[4]) + (DamageStats[9] * SpecialStats[5]) + (DamageStats[10] * SpecialStats[6]) + (DamageStats[11] * SpecialStats[7]));
        damageTaken = damageTaken - Shield;
        damageTaken = damageTaken * -1;
        HealthChange(damageTaken);
        poisonStatus = poisonStatus + (DamageStats[12] * SpecialStats[8]);
        if (poisonStatus > 0) { poisonStatus = poisonStatus * -1; HealthChange(poisonStatus); statusFlag = true; }
        if (statusFlag == true) { setStatus(); }
        statusFlag = false;
        //if poisonStatus > 0, set flag for needing a function call
    }
    public void HealthChange(int change)
    {
        Health = Health + change;
        if (Health > 0)
        {
            Debug.Log("Unit Health is now at: " + Health);
            healthText.text = Health.ToString();
            //healthUIInstance change the text
        }
        else
        {
            Destroy(gameObject);
        }

    }
    //localScale for cards and card icon
    //PCard2.transform.localScale = new Vector3(0.264272f, 0.264272f, 1f);

    //setShield
    private void setShield(int shieldVal)
    {
        Shield = shieldVal;
        //destroy prefab
        if (shieldIconInstance != null)
        {
            Destroy(shieldIconInstance);
        }
        if (shieldVal > 0)
        {
            //create prefab
            shieldIconInstance = Instantiate(shieldIconPrefab, this.transform);
            shieldIconInstance.transform.localPosition = new Vector3(-2.28f, 2.7f, 0f);
            shieldText = shieldIconInstance.GetComponentInChildren<Text>();
            shieldText.text = Shield.ToString();
        }
    }

    //setAtkMult
    private void setAtkChng(int atkVal)
    {
        attackChng = atkVal;
        if (atkDwnInstance != null)
        {
            Destroy(atkDwnInstance);
        }
        if (atkUpInstance != null)
        {
            Destroy(atkUpInstance);
        }

        if (attackChng < 0)
        {//lowered
            atkDwnInstance = Instantiate(atkDwnPrefab, this.transform);
            atkDwnInstance.transform.localPosition = new Vector3(1.7f, -2.8f, 0);
            atkText = atkDwnInstance.GetComponentInChildren<Text>();
            atkText.text = attackChng.ToString();
        } else if (attackChng > 0)
        {//raised
            atkUpInstance = Instantiate(atkUpPrefab, this.transform);
            atkUpInstance.transform.localPosition = new Vector3(1.7f, -2.8f, 0);
            atkText = atkUpInstance.GetComponentInChildren<Text>();
            atkText.text = attackChng.ToString();
        }
    }

    //setStatus
    private void setStatus()
    {
        if (blindStatusInstance != null)
        {
            Destroy(blindStatusInstance);
        }
        if (poisonStatusInstance != null)
        {
            Destroy(poisonStatusInstance);
        }
        if (stunStatusInstance != null)
        {
            Destroy(stunStatusInstance);
        }
        if (hiddenStatusInstance != null)
        {
            Destroy(hiddenStatusInstance);
        }
        //sets the visual status indicators
        if (blindTurns > 0)
        {
            //create instance
            //use text component of child to set the value
            blindStatusInstance = Instantiate(blindStatusPrefab, this.transform);
            blindStatusInstance.transform.localPosition = new Vector3(-0.6f + statusIconPosition, -0.23f, 0);
            blindText = blindStatusInstance.GetComponentInChildren<Text>();
            blindText.text = blindTurns.ToString();
            statusIconPosition += 0.2f;
        } else if (poisonStatus > 0)
        {
            poisonStatusInstance = Instantiate(poisonStatusPrefab, this.transform);
            poisonStatusInstance.transform.localPosition = new Vector3(-0.6f + statusIconPosition, -0.223f, 0);
            poisonText = poisonStatusInstance.GetComponentInChildren<Text>();
            poisonText.text = poisonStatus.ToString();
            statusIconPosition += 0.2f;
        } else if (stunnedTurns > 0)
        {
            stunStatusInstance = Instantiate(stunStatusPrefab, this.transform);
            stunStatusInstance.transform.localPosition = new Vector3(-0.6f + statusIconPosition, -0.23f, 0);
            stunText = stunStatusInstance.GetComponentInChildren<Text>();
            stunText.text = stunnedTurns.ToString();
            statusIconPosition += 0.2f;
        } else if (hiddenTurns > 0)
        {
            hiddenStatusInstance = Instantiate(hiddenStatusPrefab, this.transform);
            hiddenStatusInstance.transform.localPosition = new Vector3(-0.6f + statusIconPosition, -0.23f, 0);
            hiddenText = hiddenStatusInstance.GetComponentInChildren<Text>();
            hiddenText.text = hiddenTurns.ToString();
            statusIconPosition += 0.2f;
        }
        statusIconPosition = 0;
    }

    public void StatusDecrement()//will be called once per turn change
    {
        //decrease all status effects by 1
        stunnedTurns--;
        blindTurns--;
        hiddenTurns--;
        poisonStatus--;
        setStatus();
    }

    //getStatus
    public int[] getStatus()
    {
        //returns the value associated with all 4 status effects as an array
        //Blind, poison, stun, hidden
        activeStatusArray[0] = blindTurns;
        activeStatusArray[1] = poisonStatus;
        activeStatusArray[2] = stunnedTurns;
        activeStatusArray[3] = hiddenTurns;
        return activeStatusArray;
    }

    public int[] GetItem()
    {
        return Item;
    }
    public int[] GetSkill()
    {
        return Skill;
    }
    //passives will need a special check at start
    bool skillActive = false;//for when its clicked
    bool itemActive = false;
    public void SkillActivity()
    {
        if (skillActive == false)
        {//skill is now active
            skillActive = true;
        } else
        {//skill has been unclicked (inactive)
            skillActive = false;
        }
    }
    public void ItemActivity()
    {
        if (itemActive == false)
        {//item is now active
            itemActive = true;
        }
        else
        {//item has been unclicked (inactive)
            itemActive = false;
        }
    }
    /*Skill and Item usage:
     * [0] is for skill/item type
     * 0(passive), 1(effects self), 2(effects any selected unit), 
     * 3(effects any random ally), 4(effects any random enemy)
     * swap bool anytime the function is called
     */

    public void CoolDownChange()//not been implemented yet
    {
        itemCooldownTimer--;
        if (itemCooldownTimer < 0)
        {
            itemCooldownTimer = 0;
        }
        skillCooldownTimer--;
        if (skillCooldownTimer < 0)
        {
            skillCooldownTimer = 0;
        }
    }

    //Units will reduce their cooldowns whenever they perform their standard attack
    public int[] GetStandardAttack()
    {//This is used to obtain attack values to hit an opponent
        //Units can use elemental damage: fire, ice, and elec
        int[] totalAttack = new int[13];
        //Stats that units don't have for attacking
        totalAttack[0] = 0;//defenseMult
        totalAttack[1] = 0;//attackChng
        totalAttack[2] = 0;//stun
        totalAttack[3] = 0;//blind
        totalAttack[4] = 0;//hide
        totalAttack[5] = 0;//heal
        totalAttack[6] = 0;//shield
        totalAttack[12] = 0;//poison
        //Stats that units do have
        totalAttack[7] = RangeDamage + attackChng;
        totalAttack[8] = MeleeDamage + attackChng;
        totalAttack[9] = FireDMG + attackChng;
        totalAttack[10] = IceDMG + attackChng;
        totalAttack[11] = ElecDMG + attackChng;
        return totalAttack;
    }
}
