using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Obi;

public class CollisionDetector : MonoBehaviour
{
    [SerializeField] EnemyController red;
    EnemyController yellow;

    private void Start()
    {
        red = GameObject.Find("EnemyRed").GetComponent<EnemyController>();
        yellow = GameObject.Find("EnemyYellow").GetComponent<EnemyController>();
    }
    private void OnTriggerEnter(Collider other)
    {
        // IF PLAYER COLLECT STICK //
        if (transform.tag == "Green" && other.tag == "Green") 
        {
            CharacterController.instance.ExtendTheRope();
            StickCreater.instance.TriggerAfterCollect(this.transform.position);
            
            Destroy(this.gameObject);
        }

        // IF RED-AI COLLECT STICK // 
        if (transform.tag == "Red" && other.tag == "Red")
        {
            red.ropeLength += red.changeLength;
            StickCreater.instance.TriggerAfterCollect(this.transform.position);
            Destroy(this.gameObject);

        }

        //IF Yellow-AI COLLECT STICK // 
        if (transform.tag == "Yellow" && other.tag == "Yellow")
        {
            yellow.ropeLength += yellow.changeLength;
            StickCreater.instance.TriggerAfterCollect(this.transform.position);
            Destroy(this.gameObject);
        }
        // FOR FINISH //

        if (transform.tag == "Finish") 
        {
            FindObjectOfType<GameManager>().playerState = GameManager.PlayerState.Finish;
            FindObjectOfType<UIManager>().winnerText.text = (other.tag + " is Winner!!");
        }
    }
}
