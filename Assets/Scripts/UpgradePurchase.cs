using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class UpgradePurchase : MonoBehaviour
{

    public int purchasePrice;
    public GameObject upgradeController;
    public bool purchased = false;
    public int upgradeId;

    public void purchase(int id)
    {
        purchased = upgradeController.GetComponent<UpgradeController>().purchase((UpgradeController.upgrade) id);
    }

    public void Update()
    {
        if (purchased)
        {
            GetComponent<Image>().color = Color.green;
            GetComponent<Button>().interactable = false;
        }
        else if (upgradeController.GetComponent<UpgradeController>().isPurchaseable((UpgradeController.upgrade) upgradeId))
        {
            GetComponent<Image>().color = Color.white;
        }
        else
        {
            GetComponent<Image>().color = Color.grey;
        }
    }


}
