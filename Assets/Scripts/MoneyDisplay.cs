using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MoneyDisplay : MonoBehaviour
{
    private int money = 4900;
    public Text moneyText;
    private GameObject gameController;

    private void Update()
    {
        moneyText = gameObject.GetComponent<Text>();
        money = money = gameController.GetComponent<UpgradeController>().getMoney();
        moneyText.text = "Money: " + money;
    }

    private void Start()
    {
        gameController = GameObject.FindWithTag("GameController");
    }

}
