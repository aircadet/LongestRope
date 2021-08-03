using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Obi;
using UnityEngine.AI;

public class EnemyController : MonoBehaviour
{
    [Header("STICKS")]
    [SerializeField] Transform stakeStick;
    [SerializeField] List<GameObject> sticks;
    [SerializeField] List<GameObject> reachableSticks;

    [Header("ROPE LENGTH ")]
    public float ropeLength;
    public float changeLength;
    [SerializeField] ObiRopeCursor cursor;

    [Header("POSSIBILITY RATE")]
    [SerializeField] int possibility;

    NavMeshAgent agent;
    public static EnemyController _instance;

    private void Awake()
    {
        if (_instance == null) { _instance = this; }
        agent = GetComponent<NavMeshAgent>();
        
    }

    private void Start()
    {
        InvokeRepeating("SendEnemyToPos", 0, 3f);
    }
    private void Update()
    {
        StartCoroutine(CheckStics(5));
        cursor.ChangeLength(ropeLength);
    }
    IEnumerator CheckStics(float wait) 
    {
        // CLEAR LIST //
        sticks.Clear();

        for (int i = 0; i < GameObject.Find("Stick Holder").transform.childCount; i++) 
        {
            sticks.Add(GameObject.Find("Stick Holder").transform.GetChild(i).gameObject);
        }

        CheckReachableSticks();
        yield return new WaitForSeconds(wait);

    }

    void CheckReachableSticks() 
    {
        reachableSticks.Clear();
        foreach (GameObject go in sticks)
        {
            if (Vector3.Distance(stakeStick.position, go.transform.position) <= ropeLength + .1f || Vector3.Distance(stakeStick.GetComponent<MeshRenderer>().bounds.min, go.transform.position) <= ropeLength + .1f || Vector3.Distance(stakeStick.GetComponent<MeshRenderer>().bounds.max, go.transform.position) <= ropeLength + .1f)
            {
                reachableSticks.Add(go);
            }
        }
    }

    void SendEnemyToPos() 
    {
        // CHECK IF CAN FINISH //

        if (ropeLength + 1f> Vector3.Distance(stakeStick.position, GameObject.Find("Finish").transform.position))
        {
            agent.SetDestination(GameObject.Find("Finish").transform.position);
        }
        else 
        {
            int randomNum = Random.Range(0, 11);
           
            if (transform.tag == "Red")
            {
                if (randomNum <= possibility)
                {
                    foreach (GameObject go in reachableSticks)
                    {
                        if (go.name == "Red Stick(Clone)")
                        {
                            agent.SetDestination(go.transform.position);
                            break;
                        }
                    }
                }
                else
                {
                    agent.SetDestination(reachableSticks[Random.Range(0, reachableSticks.Count-1)].transform.position);
                }
            }
            else if (transform.tag == "Yellow")
            {
                if (randomNum <= possibility)
                {
                    foreach (GameObject go in reachableSticks)
                    {
                        if (go.name == "Yellow Stick(Clone)")
                        {
                            agent.SetDestination(go.transform.position);
                            break;
                        }
                    }
                }
                else
                {
                    agent.SetDestination(reachableSticks[Random.Range(0, reachableSticks.Count-1)].transform.position);
                }
            }
        }
    }
}
