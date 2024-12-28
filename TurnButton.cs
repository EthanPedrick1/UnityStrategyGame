using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurnButton : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        GameObject appSc = GameObject.Find("__app");
        appSc.GetComponent<PlayerDeckCondition>().GamePlayGen(true);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnMouseDown()
    {
        if (Input.GetMouseButtonDown(0))
        {
            GameObject battleSc = GameObject.Find("GamePlay");
            //battleSc.GetComponent<BattleScript>().CombatTurn();
            battleSc.GetComponent<BattleScript>().CombatHandler(true);

            //Spawns the next card each time its clicked
            GameObject appSc = GameObject.Find("__app");
            appSc.GetComponent<PlayerDeckCondition>().GamePlayGen(true);

        }
    }
}