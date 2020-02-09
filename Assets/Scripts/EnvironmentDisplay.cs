using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnvironmentDisplay : MonoBehaviour
{
    private int envScore = 0;
    public Text envText;
    private GameObject gameController;

    private void Update()
    {
        envText = gameObject.GetComponent<Text>();
        envScore = gameController.GetComponent<UpgradeController>().getEnvScore();
        envText.text = "Environment: " + envScore;
    }

    private void Start()
    {
        gameController = GameObject.FindWithTag("GameController");
    }
}
