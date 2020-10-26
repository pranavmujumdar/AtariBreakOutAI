using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BreakoutArea : MonoBehaviour
{

    public GameObject brick;

    public List<GameObject> brickSpawnPositions;

    public void brickSpawn()
    {
        foreach (GameObject g in brickSpawnPositions)
        {
            //Debug.Log("Here");
            placeBrick(brick,g);
        }
    }

    public void placeBrick(GameObject brick, GameObject gameObject)
    {
        Transform spawnLocation = gameObject.transform;
        Instantiate(brick, spawnLocation);
        //Debug.Log("Brick Spawnd");
    }

    public void clearArea()
    {
        Transform[] allChildren = GetComponentsInChildren<Transform>(true);
        foreach (Transform child in allChildren)
        {
            //Debug.Log(child.tag);
            if (child.CompareTag("Brick")) //child.CompareTag("parking")
            {
                Destroy(child.gameObject);
            }
        }
    }


    public void resetArea()
    {
        clearArea();
        brickSpawn();
    }
    private void Start()
    {
        brickSpawn();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            resetArea();
        }
    }
}
