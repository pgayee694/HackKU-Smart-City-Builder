using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SafetyDisplay : MonoBehaviour
{
    private int safetyScore = 0;
    public Text safetyText;
    private GameObject gameController;

    private void Update()
    {
        safetyText = gameObject.GetComponent<Text>();
        safetyScore = gameController.GetComponent<UpgradeController>().getSafetyScore();
        safetyText.text = "Safety: " + safetyScore;
    }

    private void Start()
    {
        gameController = GameObject.FindWithTag("GameController");
    }
}
