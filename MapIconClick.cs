using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapIconClick : MonoBehaviour
{
    //0 is battle, 1 is loot, 2 is shop, 3 is town
    int IconType;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void IconTypeSet(int iconType)
    {
        IconType = iconType;
    }


    private void OnMouseDown()
    {
        if (Input.GetMouseButtonDown(0))
        {
            //Change the scene for the corresponding icon type
        }
    }
}
