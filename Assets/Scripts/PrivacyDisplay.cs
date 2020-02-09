using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PrivacyDisplay : MonoBehaviour
{
    private int privacyScore = 0;
    public Text privacyText;
    private GameObject gameController;

    private void Update()
    {
        privacyText = gameObject.GetComponent<Text>();
        privacyScore = gameController.GetComponent<UpgradeController>().getPrivacyScore();
        privacyText.text = "Privacy: " + privacyScore;
    }

    private void Start()
    {
        gameController = GameObject.FindWithTag("GameController");
    }
}
