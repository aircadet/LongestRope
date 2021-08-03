using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Obi;

public class StickCreater : MonoBehaviour
{
    [SerializeField] List<GameObject> prefabs;

    [Header("Map Infos")]
    [SerializeField] int xCount;
    [SerializeField] int zCount;
    [SerializeField] List<Vector3> antiPositions;

    // SPAWNING VARIABLES //
    Vector3 startPos = new Vector3(-4.17f, -0.876f, -7.444f);
    Vector3 startPos2 = new Vector3(-4.17f, -0.876f, -7.444f);
    [Header("DISTANCE BETWEEN TWO STICK")]
    [SerializeField] Vector3 xPlusPos = new Vector3(1.2f, 0, 0);
    [SerializeField] Vector3 zPlusPos = new Vector3(0, 0, 1.15f);

    ///////////////////////////////////////////////
    public static StickCreater instance;

    private void Awake()
    {
        if (instance == null) { instance = this; }
    }



    private void Start()
    {
        StartingSpawn();
    }
    

    void StartingSpawn() 
    {
        for (int z = 0; z < zCount; z++) 
        {
            for (int x = 0; x < xCount; x++) 
            {
                foreach (Vector3 antiPos in antiPositions) 
                {
                    if (antiPos == startPos2) { startPos2 += xPlusPos; }
                }
                int randomNum = Random.Range(0, prefabs.Count);

                Instantiate(prefabs[randomNum], startPos2, Quaternion.identity, GameObject.Find("Stick Holder").transform);

                startPos2 += xPlusPos;
            }

            startPos2 = startPos;
            startPos2 += (zPlusPos * (z+1));
        }
    }

    public void TriggerAfterCollect(Vector3 pos) 
    {
        StartCoroutine(AfterCollectSpawn(pos));
    }
   IEnumerator AfterCollectSpawn(Vector3 pos) 
   {
        yield return new WaitForSeconds(1);
        int randomNum = Random.Range(0, 4);
        Instantiate(prefabs[randomNum], pos, Quaternion.identity, GameObject.Find("Stick Holder").transform);

    }
}
