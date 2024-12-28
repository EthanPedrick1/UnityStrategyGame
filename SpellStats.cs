using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpellStats : MonoBehaviour
{
    public int[] SpellEffectArray = new int[13];

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void SpellStatsSetup(int def, int atk, int stun, int blind, int hidden, int heal, int shield, int rng, int melee, int fire, int ice, int elec, int poi)
    {
        SpellEffectArray[0] = def;
        SpellEffectArray[1] = atk;
        SpellEffectArray[2] = stun;
        SpellEffectArray[3] = blind;
        SpellEffectArray[4] = hidden;
        SpellEffectArray[5] = heal;
        SpellEffectArray[6] = shield;
        SpellEffectArray[7] = rng;
        SpellEffectArray[8] = melee;
        SpellEffectArray[9] = fire;
        SpellEffectArray[10] = ice;
        SpellEffectArray[11] = elec;
        SpellEffectArray[12] = poi;
    }

    public void SpellEffects(GameObject target)
    {
        target.GetComponent<CardStats>().DamageCalculator(SpellEffectArray);
        /*if (target.name.StartsWith("PCard"))
        {
            target.GetComponent<CardStats>().DamageCalculator(SpellEffectArray);
        }
        else if (target.name.StartsWith("ECard"))
        {
            target.GetComponent<CardStats>().DamageCalculator(SpellEffectArray);
        }*/
        Destroy(gameObject);
    }
}
