using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UIManager : MonoBehaviour
{
    [Header("PREPARING UI ELEMENTS")]
    [SerializeField] GameObject preparingUI;

    [Header("FINISH UI ELEMENTS")]
    public TextMeshProUGUI winnerText;
    public GameObject finishUI;



    private void Update()
    {
        // PREPARING UI 
        if (FindObjectOfType<GameManager>().playerState == GameManager.PlayerState.Preparing) { preparingUI.SetActive(true); } else { preparingUI.SetActive(false); }

        // FINISH UI
        if (FindObjectOfType<GameManager>().playerState == GameManager.PlayerState.Finish) { finishUI.SetActive(true); } else { finishUI.SetActive(false); }
    }  
}
