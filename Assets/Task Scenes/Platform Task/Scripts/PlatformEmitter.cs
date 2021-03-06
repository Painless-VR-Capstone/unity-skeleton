﻿using UnityEngine;
using System.Collections;

public class PlatformEmitter : MonoBehaviour
{
    //plat = platform
    public GameObject platPrefab;
    public GameObject slowPickup;
    public GameObject boostPickup;


    Transform platContainer;
    Transform pickupContainer;
    public GameObject[,] plats;
    Vector2 pathPlat;

    public int columnCount;
    public float columnSpacing, rowSpacing, platLength, platWidth;
    public bool multiplePaths;

    GameObject currRefPlat; //Reference to plat in last created row

    float startY;

    // Use this for initialization
    void Start()
    {
        plats = new GameObject[columnCount, 2];
        platContainer = GameObject.Find("Platforms").transform;
        pickupContainer = GameObject.Find("Pickups").transform;

        platLength = platPrefab.transform.lossyScale.x;
        platWidth = platPrefab.transform.lossyScale.z;

        SpawnFirstRow();
    }

    System.Random rnd = new System.Random();
    // Update is called once per frame
    void Update()
    {


        if (currRefPlat.transform.position.x < transform.position.x - platLength - rowSpacing) //Time for new row
        {
            ShiftRowBack();
            int col = 0;
            if (multiplePaths)
            {
                while (!CheckRowContinuity())
                {
                    col = rnd.Next(0, columnCount);
                    currRefPlat = Instantiate(platPrefab);
                    plats[col, 0] = currRefPlat;
                    currRefPlat.transform.SetParent(platContainer, false);
                    currRefPlat.transform.position = transform.position;
                    int zInterval = (columnCount / 2) - col;
                    currRefPlat.transform.Translate(new Vector3(0f, 0f, platWidth * zInterval + (columnSpacing * zInterval)));

                    if (!TryPickupSpawn(30, boostPickup))
                    {
                        TryPickupSpawn(20, slowPickup);
                    }



                }
                currRefPlat.transform.Translate(new Vector3(0f, plats[col, 1].transform.position.y + 10f));

            }
            else {
                int min = (int)Mathf.Clamp(pathPlat.x - 1, 0, columnCount);
                int max = (int)Mathf.Clamp(pathPlat.x + 2, 0, columnCount - 1);
                col = rnd.Next(min, max);

                float oldPlatY = currRefPlat.transform.position.y;
                currRefPlat = Instantiate(platPrefab);
                plats[col, 0] = currRefPlat;
                currRefPlat.transform.SetParent(platContainer, false);
                currRefPlat.transform.position = transform.position;
                int zInterval = (columnCount / 2) - col;
                currRefPlat.transform.Translate(new Vector3(0f, 0f, platWidth * zInterval + (columnSpacing * zInterval)));
                //currRefPlat.transform.Translate(new Vector3(0f, ChooseVert(oldPlatY)));

                if (!TryPickupSpawn(25, boostPickup))
                    TryPickupSpawn(35, slowPickup);
            }


            pathPlat.x = col;
        }


    }

    float ChooseVert(float oldY)
    {
        float y = oldY;
        int result = rnd.Next(0, 101);
        if (result < 25)
        {
            Debug.Log("Stuff");
            int upDown = rnd.Next(0, 101);
            if (upDown > 50)
                oldY -= 20;
            else
                oldY -= 1;
        }

        return y;
    }

    //Chance should be 0-100 out of 100
    bool TryPickupSpawn(int chance, GameObject pickup)
    {
        int result = rnd.Next(0, 101);
        if (chance > result)
        {
            GameObject newPickup = Instantiate(pickup);
            newPickup.transform.SetParent(pickupContainer, false);
            newPickup.transform.position = currRefPlat.transform.position;
            newPickup.transform.Translate(new Vector3(0f, 1.5f, 0f));
            return true;
        }
        return false;
    }

    bool CheckRowContinuity()
    {
        for (int i = 0; i < columnCount; i++)
        {
            if (i == 0)
            {
                if (plats[i, 1] != null && pathPlat.x == i &&
                    (plats[0, 0] != null || plats[1, 0] != null))
                {

                    return true;
                }
            }
            else if (i == columnCount - 1)
            {
                if (plats[i, 1] != null && pathPlat.x == i &&
                   (plats[i, 0] != null || plats[i - 1, 0] != null))
                {
                    return true;
                }
            }
            else
            {
                if (plats[i, 1] != null && pathPlat.x == i &&
                   (plats[i, 0] != null || plats[i - 1, 0] != null || plats[i + 1, 0] != null))
                {
                    return true;
                }
            }


        }
        return false;
    }

    void ShiftRowBack()
    {
        for (int i = 0; i < columnCount; i++)
        {
            plats[i, 1] = plats[i, 0];
            plats[i, 0] = null;
        }
    }

    //Makes the first row with ONE plat in the middle column
    void SpawnFirstRow()
    {
        currRefPlat = Instantiate(platPrefab);

        currRefPlat.transform.SetParent(platContainer, false);
        currRefPlat.transform.position = transform.position;

        pathPlat = new Vector2(columnCount / 2, 0);
        plats[columnCount / 2, 0] = currRefPlat; //Assigns plat to mid position in array

        startY = currRefPlat.transform.position.y;
    }
}
