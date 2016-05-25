using UnityEngine;
using System.Collections;

public class PlatformEmitter : MonoBehaviour {
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
  

    // Use this for initialization
    void Start () {
        plats = new GameObject[columnCount, 2];
        platContainer = GameObject.Find("Platforms").transform;
        pickupContainer = GameObject.Find("Pickups").transform;

        platLength = platPrefab.transform.lossyScale.x;
        platWidth = platPrefab.transform.lossyScale.z;

        SpawnFirstRow();
	}
	
	// Update is called once per frame
	void Update () {


        if (currRefPlat.transform.position.x < transform.position.x - platLength - rowSpacing) //Time for new row
        {
            ShiftRowBack();
            int col = 0;
            System.Random rnd = new System.Random();
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
                        TryPickupSpawn(45, slowPickup);

                }
            }
            else {
                int min = (int)Mathf.Clamp(pathPlat.x - 1, 0, columnCount);
                int max = (int)Mathf.Clamp(pathPlat.x + 2, 0, columnCount - 1);
                col = rnd.Next(min, max);

                currRefPlat = Instantiate(platPrefab);
                plats[col, 0] = currRefPlat;
                currRefPlat.transform.SetParent(platContainer, false);
                currRefPlat.transform.position = transform.position;
                int zInterval = (columnCount / 2) - col;
                currRefPlat.transform.Translate(new Vector3(0f, 0f, platWidth * zInterval + (columnSpacing * zInterval)));

                if (!TryPickupSpawn(60, boostPickup))
                    TryPickupSpawn(0, slowPickup);
            }


            pathPlat.x = col;
        }


	}

    //Chance should be 0-100 out of 100
    bool TryPickupSpawn(int chance, GameObject pickup)
    {
        System.Random rnd = new System.Random();
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
            } else if (i == columnCount - 1)
            {
                if (plats[i, 1] != null && pathPlat.x == i &&
                   (plats[i, 0] != null || plats[i - 1, 0] != null))
                {
                    return true;
                }
            } else
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
    }
}
