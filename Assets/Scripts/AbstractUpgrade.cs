using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class AbstractUpgrade
{
    public abstract int moneyImproveAmt { get; }
    public abstract int safetyImproveAmt { get; }
    public abstract int envImproveAmt { get; }
    public abstract int privacyImproveAmt { get; }
    public abstract int cost { get; }
    private bool isActive;
    private bool available;

    public int getMoneyImproveAmt()
    {
        return moneyImproveAmt;
    }

    public int getSafetyImproveAmt()
    {
        return safetyImproveAmt;
    }

    public int getEnvImproveAmt()
    {
        return envImproveAmt;
    }

    public int getPrivacyImproveAmt()
    {
        return privacyImproveAmt;
    }

    public int getCost()
    {
        return cost;
    }

    public bool isActivated()
    {
        return isActive;
    }

    public void setisActive(bool active)
    {
        isActive = active;
    }

    public bool isAvailable()
    {
        return available;
    }

    public void setAvailable(bool isAvailable)
    {
        available = isAvailable;
    }
}
