using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapHandler : MonoBehaviour
{
    int[,] MapArrayCopy;
    int ColumnLoopCounter = 0;

    public Sprite[] MapIconSprites;
    public Sprite[] MapPathSprites;

    int currentItemCount = 0;
    int pastItemCount = 0;
    float xPositionofPaths = -8;

//------------ THIS SCRIPT RESETS EVERY TIME THE MAP IS LEFT ---------------------------

    // Start is called before the first frame update
    void Start()
    {
        GameObject appSc = GameObject.Find("__app");
        MapArrayCopy = appSc.GetComponent<PlayerDeckCondition>().MapArrayReturner();
        MapCreator();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    int i = 0;
    int j = 0;
    void MapCreator()
    {
        for (i=0; i<MapArrayCopy.GetLength(0); i++)
        {
            for (j=0; j<MapArrayCopy.GetLength(1); j++)
            {
                if (MapArrayCopy[i,j] != 0)
                {
                    currentItemCount++;//The amount of items in the current column
                }
            }
            ColumnPather(pastItemCount, currentItemCount, i);//i is the column being worked on
            pastItemCount = currentItemCount;//sets up past item count
            currentItemCount = 0;//resets the current item count
            xPositionofPaths = xPositionofPaths + 2.3f;
        }
    }

    void ItemPlacer(int currentItemCount, int currentCol, int IconType)
    {
        //use currentCol to determine the x position
        //use currentItemCount to determine how many and the y positions
        //multiply currentCol by 2.3 each time
        //items should be at 0.25 scale for x and y
        float xPosition = -7;
        float xPositionChange = currentCol * 2.3f;
        xPosition = xPosition + xPositionChange;
        switch(currentItemCount)
        {
            //0 is battle, 1 is loot, 2 is shop, 3 is town
            case 1:
                //y=0
                GameObject MapIcon1 = new GameObject();
                MapIcon1.name = "MapIcon1";
                MapIcon1.layer = 7;

                MapIcon1.AddComponent<BoxCollider2D>();
                MapIcon1.GetComponent<BoxCollider2D>().size = new Vector2(2, 2);
                MapIcon1.AddComponent<MapIconClick>();
                //Pass IconType to the script as a function so that it knows what it is
                MapIcon1.GetComponent<MapIconClick>().IconTypeSet(IconType);

                MapIcon1.AddComponent<SpriteRenderer>();
                MapIcon1.GetComponent<SpriteRenderer>().sprite = MapIconSprites[IconType];
                MapIcon1.GetComponent<Renderer>().sortingLayerID = SortingLayer.NameToID("UI Buttons");

                MapIcon1.transform.localScale = new Vector3(0.25f, 0.25f, 1f);
                MapIcon1.transform.position = new Vector3(xPosition, 0f, 0f);
                break;
            case 2:
                //y=1.2, -1.2
                GameObject MapIcon2 = new GameObject();//y=1.6
                MapIcon2.name = "MapIcon2";
                MapIcon2.layer = 7;

                MapIcon2.AddComponent<BoxCollider2D>();
                MapIcon2.GetComponent<BoxCollider2D>().size = new Vector2(2, 2);
                MapIcon2.AddComponent<MapIconClick>();
                //Pass IconType to the script as a function so that it knows what it is
                MapIcon2.GetComponent<MapIconClick>().IconTypeSet(IconType);

                MapIcon2.AddComponent<SpriteRenderer>();
                MapIcon2.GetComponent<SpriteRenderer>().sprite = MapIconSprites[IconType];
                MapIcon2.GetComponent<Renderer>().sortingLayerID = SortingLayer.NameToID("UI Buttons");

                MapIcon2.transform.localScale = new Vector3(0.25f, 0.25f, 1f);
                MapIcon2.transform.position = new Vector3(xPosition, 1.2f, 0f);
                //--------------------------------------------------------------
                GameObject MapIcon3 = new GameObject();//y=-0.9
                MapIcon3.name = "MapIcon3";
                MapIcon3.layer = 7;

                MapIcon3.AddComponent<BoxCollider2D>();
                MapIcon3.GetComponent<BoxCollider2D>().size = new Vector2(2, 2);
                MapIcon3.AddComponent<MapIconClick>();
                //Pass IconType to the script as a function so that it knows what it is
                MapIcon3.GetComponent<MapIconClick>().IconTypeSet(IconType);

                MapIcon3.AddComponent<SpriteRenderer>();
                MapIcon3.GetComponent<SpriteRenderer>().sprite = MapIconSprites[IconType];
                MapIcon3.GetComponent<Renderer>().sortingLayerID = SortingLayer.NameToID("UI Buttons");

                MapIcon3.transform.localScale = new Vector3(0.25f, 0.25f, 1f);
                MapIcon3.transform.position = new Vector3(xPosition, -1.2f, 0f);
                break;
            case 3:
                //y=2.4, 0, -2.4
                GameObject MapIcon4 = new GameObject();//y=2.4
                MapIcon4.name = "MapIcon4";
                MapIcon4.layer = 7;

                MapIcon4.AddComponent<BoxCollider2D>();
                MapIcon4.GetComponent<BoxCollider2D>().size = new Vector2(2, 2);
                MapIcon4.AddComponent<MapIconClick>();
                //Pass IconType to the script as a function so that it knows what it is
                MapIcon4.GetComponent<MapIconClick>().IconTypeSet(IconType);

                MapIcon4.AddComponent<SpriteRenderer>();
                MapIcon4.GetComponent<SpriteRenderer>().sprite = MapIconSprites[IconType];
                MapIcon4.GetComponent<Renderer>().sortingLayerID = SortingLayer.NameToID("UI Buttons");

                MapIcon4.transform.localScale = new Vector3(0.25f, 0.25f, 1f);
                MapIcon4.transform.position = new Vector3(xPosition, 2.4f, 0f);
                //--------------------------------------------------------------
                GameObject MapIcon5 = new GameObject();//y=0
                MapIcon5.name = "MapIcon5";
                MapIcon5.layer = 7;

                MapIcon5.AddComponent<BoxCollider2D>();
                MapIcon5.GetComponent<BoxCollider2D>().size = new Vector2(2, 2);
                MapIcon5.AddComponent<MapIconClick>();
                //Pass IconType to the script as a function so that it knows what it is
                MapIcon5.GetComponent<MapIconClick>().IconTypeSet(IconType);

                MapIcon5.AddComponent<SpriteRenderer>();
                MapIcon5.GetComponent<SpriteRenderer>().sprite = MapIconSprites[IconType];
                MapIcon5.GetComponent<Renderer>().sortingLayerID = SortingLayer.NameToID("UI Buttons");

                MapIcon5.transform.localScale = new Vector3(0.25f, 0.25f, 1f);
                MapIcon5.transform.position = new Vector3(xPosition, 0f, 0f);
                //------------------------------------------------------------
                GameObject MapIcon6 = new GameObject();//y=-2.4
                MapIcon6.name = "MapIcon6";
                MapIcon6.layer = 7;

                MapIcon6.AddComponent<BoxCollider2D>();
                MapIcon6.GetComponent<BoxCollider2D>().size = new Vector2(2, 2);
                MapIcon6.AddComponent<MapIconClick>();
                //Pass IconType to the script as a function so that it knows what it is
                MapIcon6.GetComponent<MapIconClick>().IconTypeSet(IconType);

                MapIcon6.AddComponent<SpriteRenderer>();
                MapIcon6.GetComponent<SpriteRenderer>().sprite = MapIconSprites[IconType];
                MapIcon6.GetComponent<Renderer>().sortingLayerID = SortingLayer.NameToID("UI Buttons");

                MapIcon6.transform.localScale = new Vector3(0.25f, 0.25f, 1f);
                MapIcon6.transform.position = new Vector3(xPosition, -2.4f, 0f);
                break;
            case 4:
                //y=4.3, 1.2, -1.2, -4.3
                GameObject MapIcon7 = new GameObject();//y=4.3
                MapIcon7.name = "MapIcon7";
                MapIcon7.layer = 7;

                MapIcon7.AddComponent<BoxCollider2D>();
                MapIcon7.GetComponent<BoxCollider2D>().size = new Vector2(2, 2);
                MapIcon7.AddComponent<MapIconClick>();
                //Pass IconType to the script as a function so that it knows what it is
                MapIcon7.GetComponent<MapIconClick>().IconTypeSet(IconType);

                MapIcon7.AddComponent<SpriteRenderer>();
                MapIcon7.GetComponent<SpriteRenderer>().sprite = MapIconSprites[IconType];
                MapIcon7.GetComponent<Renderer>().sortingLayerID = SortingLayer.NameToID("UI Buttons");

                MapIcon7.transform.localScale = new Vector3(0.25f, 0.25f, 1f);
                MapIcon7.transform.position = new Vector3(xPosition, 4.3f, 0f);
                //--------------------------------------------------------------
                GameObject MapIcon8 = new GameObject();//y=1.2
                MapIcon8.name = "MapIcon8";
                MapIcon8.layer = 7;

                MapIcon8.AddComponent<BoxCollider2D>();
                MapIcon8.GetComponent<BoxCollider2D>().size = new Vector2(2, 2);
                MapIcon8.AddComponent<MapIconClick>();
                //Pass IconType to the script as a function so that it knows what it is
                MapIcon8.GetComponent<MapIconClick>().IconTypeSet(IconType);

                MapIcon8.AddComponent<SpriteRenderer>();
                MapIcon8.GetComponent<SpriteRenderer>().sprite = MapIconSprites[IconType];
                MapIcon8.GetComponent<Renderer>().sortingLayerID = SortingLayer.NameToID("UI Buttons");

                MapIcon8.transform.localScale = new Vector3(0.25f, 0.25f, 1f);
                MapIcon8.transform.position = new Vector3(xPosition, 1.2f, 0f);
                //--------------------------------------------------------------
                GameObject MapIcon9 = new GameObject();//y=-1.2
                MapIcon9.name = "MapIcon9";
                MapIcon9.layer = 7;

                MapIcon9.AddComponent<BoxCollider2D>();
                MapIcon9.GetComponent<BoxCollider2D>().size = new Vector2(2, 2);
                MapIcon9.AddComponent<MapIconClick>();
                //Pass IconType to the script as a function so that it knows what it is
                MapIcon9.GetComponent<MapIconClick>().IconTypeSet(IconType);

                MapIcon9.AddComponent<SpriteRenderer>();
                MapIcon9.GetComponent<SpriteRenderer>().sprite = MapIconSprites[IconType];
                MapIcon9.GetComponent<Renderer>().sortingLayerID = SortingLayer.NameToID("UI Buttons");

                MapIcon9.transform.localScale = new Vector3(0.25f, 0.25f, 1f);
                MapIcon9.transform.position = new Vector3(xPosition, -1.2f, 0f);
                //---------------------------------------------------------------
                GameObject MapIcon10 = new GameObject();//y=-4.3
                MapIcon10.name = "MapIcon10";
                MapIcon10.layer = 7;

                MapIcon10.AddComponent<BoxCollider2D>();
                MapIcon10.GetComponent<BoxCollider2D>().size = new Vector2(2, 2);
                MapIcon10.AddComponent<MapIconClick>();
                //Pass IconType to the script as a function so that it knows what it is
                MapIcon10.GetComponent<MapIconClick>().IconTypeSet(IconType);

                MapIcon10.AddComponent<SpriteRenderer>();
                MapIcon10.GetComponent<SpriteRenderer>().sprite = MapIconSprites[IconType];
                MapIcon10.GetComponent<Renderer>().sortingLayerID = SortingLayer.NameToID("UI Buttons");

                MapIcon10.transform.localScale = new Vector3(0.25f, 0.25f, 1f);
                MapIcon10.transform.position = new Vector3(xPosition, -4.3f, 0f);
                break;
            default:
                Debug.Log("Error when placing items");
                break;
        }
    }

    void ColumnPather(int priorItemCount, int currentItemCount, int currentCol)
    {
        if (ColumnLoopCounter == 0)
        {
            //Create the first item setup without bothering with lines
            /*Use currentItemCount to know how many items (how many loops)
             * Use currentCol to know where your at in the 20 columns (does this even matter?)
             * 
             * Use item count to pick which path sprite to use
             * Then use currentCol to determine the "i" in [i,j]
             * Loop through the column to apply the proper sprite to the item
             */
            for (int i=0; i<currentItemCount; i++)
            {
                int currItem = MapArrayCopy[currentCol, i];
                switch (currItem)
                {
                    case 1:
                        //Battle
                        ItemPlacer(currentItemCount, currentCol, 0);
                        break;
                    case 2:
                        //Loot
                        ItemPlacer(currentItemCount, currentCol, 1);
                        break;
                    case 3:
                        //Shop
                        ItemPlacer(currentItemCount, currentCol, 2);
                        break;
                    case 4:
                        //Town
                        ItemPlacer(currentItemCount, currentCol, 3);
                        break;
                    default:
                        Debug.Log("Error when picking item sprite");
                        break;
                }
            }
            ColumnLoopCounter++;
        }
        else
        {
            //Create the item setup with respect to the prior items
            /*Use both item counts to pick the right path sprite to use
             * Use currentCol to find the "i" in [i,j]
             * Loop through the column to appply the proper sprite to the item
             */

            /* This section is used to pick and spawn the path sprite
             * Each path will be a set distance of pixels away from the next
             * Save the prior path's position and then add an x distance from it
             */
            switch (priorItemCount)//used to pick the path sprite
            {
                case 1:
                    //1
                    switch (currentItemCount)
                    {
                        case 1:
                            //1-1
                            GameObject Path11 = new GameObject();
                            Path11.name = "Path11";
                            Path11.layer = 6;
                            Path11.AddComponent<SpriteRenderer>();
                            Path11.GetComponent<SpriteRenderer>().sprite = MapPathSprites[0];
                            Path11.GetComponent<Renderer>().sortingLayerID = SortingLayer.NameToID("UI Background");

                            Path11.transform.localScale = new Vector3(0.25f, 0.5f, 1f);
                            Path11.transform.position = new Vector3(xPositionofPaths, -0.37f, 0f);
                            break;
                        case 2:
                            //1-2
                            GameObject Path12 = new GameObject();
                            Path12.name = "Path12";
                            Path12.layer = 6;
                            Path12.AddComponent<SpriteRenderer>();
                            Path12.GetComponent<SpriteRenderer>().sprite = MapPathSprites[1];
                            Path12.GetComponent<Renderer>().sortingLayerID = SortingLayer.NameToID("UI Background");

                            Path12.transform.localScale = new Vector3(0.25f, 0.5f, 1f);
                            Path12.transform.position = new Vector3(xPositionofPaths, 0f, 0f);
                            break;
                        case 3:
                            //1-3
                            GameObject Path13 = new GameObject();
                            Path13.name = "Path13";
                            Path13.layer = 6;
                            Path13.AddComponent<SpriteRenderer>();
                            Path13.GetComponent<SpriteRenderer>().sprite = MapPathSprites[2];
                            Path13.GetComponent<Renderer>().sortingLayerID = SortingLayer.NameToID("UI Background");

                            Path13.transform.localScale = new Vector3(0.25f, 0.5f, 1f);
                            Path13.transform.position = new Vector3(xPositionofPaths, 0f, 0f);
                            break;
                        case 4:
                            //1-4
                            GameObject Path14 = new GameObject();
                            Path14.name = "Path14";
                            Path14.layer = 6;
                            Path14.AddComponent<SpriteRenderer>();
                            Path14.GetComponent<SpriteRenderer>().sprite = MapPathSprites[3];
                            Path14.GetComponent<Renderer>().sortingLayerID = SortingLayer.NameToID("UI Background");

                            Path14.transform.localScale = new Vector3(0.25f, 0.5f, 1f);
                            Path14.transform.position = new Vector3(xPositionofPaths, 0f, 0f);
                            break;
                        default:
                            Debug.Log("Error when picking item set on: " + ColumnLoopCounter);
                            break;
                    }
                    break;
                case 2:
                    //2
                    switch (currentItemCount)
                    {
                        case 1:
                            //2-1: inverted 1-2
                            GameObject Path21 = new GameObject();
                            Path21.name = "Path21";
                            Path21.layer = 6;
                            Path21.AddComponent<SpriteRenderer>();
                            Path21.GetComponent<SpriteRenderer>().sprite = MapPathSprites[1];
                            Path21.GetComponent<Renderer>().sortingLayerID = SortingLayer.NameToID("UI Background");

                            Path21.transform.localScale = new Vector3(-0.25f, 0.5f, 1f);
                            Path21.transform.position = new Vector3(xPositionofPaths, 0f, 0f);
                            break;
                        case 2:
                            //2-2
                            GameObject Path22 = new GameObject();
                            Path22.name = "Path22";
                            Path22.layer = 6;
                            Path22.AddComponent<SpriteRenderer>();
                            Path22.GetComponent<SpriteRenderer>().sprite = MapPathSprites[4];
                            Path22.GetComponent<Renderer>().sortingLayerID = SortingLayer.NameToID("UI Background");

                            Path22.transform.localScale = new Vector3(0.25f, 0.5f, 1f);
                            Path22.transform.position = new Vector3(xPositionofPaths, -0.37f, 0f);
                            break;
                        case 3:
                            //2-3
                            GameObject Path23 = new GameObject();
                            Path23.name = "Path23";
                            Path23.layer = 6;
                            Path23.AddComponent<SpriteRenderer>();
                            Path23.GetComponent<SpriteRenderer>().sprite = MapPathSprites[5];
                            Path23.GetComponent<Renderer>().sortingLayerID = SortingLayer.NameToID("UI Background");

                            Path23.transform.localScale = new Vector3(0.25f, 0.5f, 1f);
                            Path23.transform.position = new Vector3(xPositionofPaths, 0f, 0f);
                            break;
                        case 4:
                            //2-4
                            GameObject Path24 = new GameObject();
                            Path24.name = "Path24";
                            Path24.layer = 6;
                            Path24.AddComponent<SpriteRenderer>();
                            Path24.GetComponent<SpriteRenderer>().sprite = MapPathSprites[6];
                            Path24.GetComponent<Renderer>().sortingLayerID = SortingLayer.NameToID("UI Background");

                            Path24.transform.localScale = new Vector3(0.25f, 0.5f, 1f);
                            Path24.transform.position = new Vector3(xPositionofPaths, 0f, 0f);
                            break;
                        default:
                            Debug.Log("Error when picking item set on: " + ColumnLoopCounter);
                            break;
                    }
                    break;
                case 3:
                    //3
                    switch (currentItemCount)
                    {
                        case 1:
                            //3-1: inverted 1-3
                            GameObject Path31 = new GameObject();
                            Path31.name = "Path31";
                            Path31.layer = 6;
                            Path31.AddComponent<SpriteRenderer>();
                            Path31.GetComponent<SpriteRenderer>().sprite = MapPathSprites[2];
                            Path31.GetComponent<Renderer>().sortingLayerID = SortingLayer.NameToID("UI Background");

                            Path31.transform.localScale = new Vector3(-0.25f, 0.5f, 1f);
                            Path31.transform.position = new Vector3(xPositionofPaths, 0f, 0f);
                            break;
                        case 2:
                            //3-2: inverted 2-3
                            GameObject Path32 = new GameObject();
                            Path32.name = "Path32";
                            Path32.layer = 6;
                            Path32.AddComponent<SpriteRenderer>();
                            Path32.GetComponent<SpriteRenderer>().sprite = MapPathSprites[5];
                            Path32.GetComponent<Renderer>().sortingLayerID = SortingLayer.NameToID("UI Background");

                            Path32.transform.localScale = new Vector3(-0.25f, 0.5f, 1f);
                            Path32.transform.position = new Vector3(xPositionofPaths, 0f, 0f);
                            break;
                        case 3:
                            //3-3
                            GameObject Path33 = new GameObject();
                            Path33.name = "Path33";
                            Path33.layer = 6;
                            Path33.AddComponent<SpriteRenderer>();
                            Path33.GetComponent<SpriteRenderer>().sprite = MapPathSprites[7];
                            Path33.GetComponent<Renderer>().sortingLayerID = SortingLayer.NameToID("UI Background");

                            Path33.transform.localScale = new Vector3(0.25f, 0.5f, 1f);
                            Path33.transform.position = new Vector3(xPositionofPaths, 0f, 0f);
                            break;
                        case 4:
                            //3-4
                            GameObject Path34 = new GameObject();
                            Path34.name = "Path34";
                            Path34.layer = 6;
                            Path34.AddComponent<SpriteRenderer>();
                            Path34.GetComponent<SpriteRenderer>().sprite = MapPathSprites[8];
                            Path34.GetComponent<Renderer>().sortingLayerID = SortingLayer.NameToID("UI Background");

                            Path34.transform.localScale = new Vector3(0.25f, 0.5f, 1f);
                            Path34.transform.position = new Vector3(xPositionofPaths, 0f, 0f);
                            break;
                        default:
                            Debug.Log("Error when picking item set on: " + ColumnLoopCounter);
                            break;
                    }
                    break;
                case 4:
                    //4
                    switch (currentItemCount)
                    {
                        case 1:
                            //4-1: inverted 1-4
                            GameObject Path41 = new GameObject();
                            Path41.name = "Path41";
                            Path41.layer = 6;
                            Path41.AddComponent<SpriteRenderer>();
                            Path41.GetComponent<SpriteRenderer>().sprite = MapPathSprites[3];
                            Path41.GetComponent<Renderer>().sortingLayerID = SortingLayer.NameToID("UI Background");

                            Path41.transform.localScale = new Vector3(-0.25f, 0.5f, 1f);
                            Path41.transform.position = new Vector3(xPositionofPaths, 0f, 0f);
                            break;
                        case 2:
                            //4-2: inverted 2-4
                            GameObject Path42 = new GameObject();
                            Path42.name = "Path42";
                            Path42.layer = 6;
                            Path42.AddComponent<SpriteRenderer>();
                            Path42.GetComponent<SpriteRenderer>().sprite = MapPathSprites[6];
                            Path42.GetComponent<Renderer>().sortingLayerID = SortingLayer.NameToID("UI Background");

                            Path42.transform.localScale = new Vector3(-0.25f, 0.5f, 1f);
                            Path42.transform.position = new Vector3(xPositionofPaths, 0f, 0f);
                            break;
                        case 3:
                            //4-3: inverted 3-4
                            GameObject Path43 = new GameObject();
                            Path43.name = "Path43";
                            Path43.layer = 6;
                            Path43.AddComponent<SpriteRenderer>();
                            Path43.GetComponent<SpriteRenderer>().sprite = MapPathSprites[8];
                            Path43.GetComponent<Renderer>().sortingLayerID = SortingLayer.NameToID("UI Background");

                            Path43.transform.localScale = new Vector3(-0.25f, 0.5f, 1f);
                            Path43.transform.position = new Vector3(xPositionofPaths, 0f, 0f);
                            break;
                        case 4:
                            //4-4
                            GameObject Path44 = new GameObject();
                            Path44.name = "Path44";
                            Path44.layer = 6;
                            Path44.AddComponent<SpriteRenderer>();
                            Path44.GetComponent<SpriteRenderer>().sprite = MapPathSprites[9];
                            Path44.GetComponent<Renderer>().sortingLayerID = SortingLayer.NameToID("UI Background");

                            Path44.transform.localScale = new Vector3(0.25f, 0.5f, 1f);
                            Path44.transform.position = new Vector3(xPositionofPaths, 0f, 0f);
                            break;
                        default:
                            Debug.Log("Error when picking item set on: " + ColumnLoopCounter);
                            break;
                    }
                    break;
                default:
                    Debug.Log("Error when picking item set on: " + ColumnLoopCounter);
                    break;
            }

            for (int i = 0; i < currentItemCount; i++)
            {
                int currItem = MapArrayCopy[currentCol, i];
                switch (currItem)
                {
                    case 1:
                        //Battle
                        ItemPlacer(currentItemCount, currentCol, 0);
                        break;
                    case 2:
                        //Loot
                        ItemPlacer(currentItemCount, currentCol, 1);
                        break;
                    case 3:
                        //Shop
                        ItemPlacer(currentItemCount, currentCol, 2);
                        break;
                    case 4:
                        //Town
                        ItemPlacer(currentItemCount, currentCol, 3);
                        break;
                    default:
                        Debug.Log("Error when picking item sprite");
                        break;
                }
            }
            ColumnLoopCounter++;
        }
    }
}

/* Need to do the following:
 * Generate the full list of missions at the start of the game
 * 
 * The missions should be like this:
 * 1-4 missions per column with 5 columns per screen
 * camera should be on the current (last played) column
 */

// Move the columns to match the camera rather than the camera to the columns
//Might be easier to just move the camera