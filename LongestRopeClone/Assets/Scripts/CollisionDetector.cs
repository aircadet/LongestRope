using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Obi;

public class CollisionDetector : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (transform.tag == other.tag) 
        {
            CharacterController.instance.ExtendTheRope();
            StickCreater.instance.TriggerAfterCollect(this.transform.position);
            Destroy(this.gameObject);
        }

        // FOR FINISH //

        if (transform.tag == "Finish") 
        {
            Debug.Log(other.tag + "Kazandı Ustaaa");
            FindObjectOfType<GameManager>().playerState = GameManager.PlayerState.Finish;
            FindObjectOfType<UIManager>().winnerText.text = (other.tag + " is Winner!!");
        }
    }
}
