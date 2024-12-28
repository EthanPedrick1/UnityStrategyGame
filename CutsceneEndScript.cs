using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CutsceneEndButtonScript : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnMouseDown()
    {
        if (Input.GetMouseButtonDown(0))
        {
            GameObject appSc = GameObject.Find("__app");
            appSc.GetComponent<SceneChangeMaster>().Scene5();
        }

    }
}
