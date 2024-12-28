using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IconItem : MonoBehaviour
{
    private CardStats ParentCardStats;
    // Start is called before the first frame update
    void Start()
    {
        ParentCardStats = GetComponentInParent<CardStats>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnMouseDown()
    {
        if (Input.GetMouseButtonDown(0))
        {
            ParentCardStats.ItemActivity();
        }
    }
}
