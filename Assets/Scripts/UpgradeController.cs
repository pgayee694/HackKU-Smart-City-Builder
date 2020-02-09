using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpgradeController : MonoBehaviour
{
    public AbstractUpgrade[] upgrades = {
        new SmartHomeUpgrade(),
        new SmartWatchUpgrade(),
        new EnergyConsumptionTrackerUpgrade(),
        new SolarPowerUpgrade(),
        new SmartWasteRecycleUpgrade(),
        new CameraUpgrade(),
        new SmartStreetLightsUpgrade(),
        new SmartCrimeDetectionUpgrade(),
        new WindEnergyUpgrade(),
        new ParkingIndicatorUpgrade(),
        new SmartTrafficLightsUpgrade(),
        new NuclearEnergyUpgrade(),
        new SelfDrivingCarsUpgrade(),
        new FlyingCarsUpgrade()
    };
    public GameObject SmartHomeDialogue;
    public GameObject SmartWatchDialogue;
    public GameObject EnergyConsumptionTrackerDialogue;
    public GameObject SolarPowerDialogue;
    public GameObject SmartWasteDialogue;
    public GameObject CameraDialogue;
    public GameObject StreetLightDialogue;
    public GameObject CrimeDetectDialogue;
    public GameObject WindEnergyDialogue;
    public GameObject ParkingDialogue;
    public GameObject TrafficLightDialogue;
    public GameObject NuclearDialogue;
    public GameObject SelfDrivingDialogue;
    public GameObject FlyingCarDialogue;
    public int money;
    private int moneyImproveAmt;
    private int safetyScore;
    private int envScore;
    private int privacyScore;
    

    public enum upgrade
    {
        SmartHomeUpgrade = 0,
        SmartWatchUpgrade = 1,
        EnergyConsumptionTrackerUpgrade = 2,
        SolarPowerUpgrade = 3,
        SmartWasteRecycleUpgrade = 4,
        CameraUpgrade = 5,
        SmartStreetLightsUpgrade = 6,
        SmartCrimeDetectionUpgrade = 7,
        WindEnergyUpgrade = 8,
        ParkingIndicatorUpgrade = 9,
        SmartTrafficLightsUpgrade = 10,
        NuclearEnergyUpgrade = 11,
        SelfDrivingCarsUpgrade = 12,
        FlyingCarsUpgrade = 13
    }

    // Start is called before the first frame update
    void Start()
    {
        upgrades[(int) upgrade.SmartHomeUpgrade].setAvailable(true);
        moneyImproveAmt = 10;
        money = 1900;
        InvokeRepeating("updateMoney", 0, 1.0f);
    }

    // Update is called once per frame
    void Update()
    {
        moneyImproveAmt = 10;
        safetyScore = 0;
        envScore = 0;
        privacyScore = 0;
        for(int i = 0; i < upgrades.Length; i++)
        {
            if (upgrades[i].isActivated())
            {
                moneyImproveAmt += upgrades[i].getMoneyImproveAmt();
                safetyScore += upgrades[i].getSafetyImproveAmt();
                envScore += upgrades[i].getEnvImproveAmt();
                privacyScore += upgrades[i].getPrivacyImproveAmt();
            }
        }
    }

    // runs every second to update the amount of money the player has
    private void updateMoney()
    {
        money += moneyImproveAmt;
    }

    public int getMoneyImproveAmt()
    {
        return moneyImproveAmt;
    }

    public int getMoney()
    {
        return money;
    }

    public int getSafetyScore()
    {
        return safetyScore;
    }

    public int getEnvScore()
    {
        return envScore;
    }

    public int getPrivacyScore()
    {
        return privacyScore;
    }

    public void activate(int id)
    {
        upgrades[id].setisActive(true);
    }

    public bool isAvailable(int id)
    {
        return upgrades[id].isAvailable();
    }

    public bool isPurchaseable(upgrade id)
    {
        return upgrades[(int) id].isAvailable() && money >= upgrades[(int) id].cost && !upgrades[(int) id].isActivated();
    }

    public bool purchase(upgrade id)
    {
        if (isPurchaseable(id))
        {
            upgrades[(int)id].setisActive(true);
            money -= upgrades[(int)id].cost;
            updateAvailabilities(id);
            displayDialogue(id);

            return true;
        }

        return false;
    }

    public void updateAvailabilities(upgrade id)
    {
        if (id == upgrade.SmartHomeUpgrade)
        {
            upgrades[(int) upgrade.SmartWatchUpgrade].setAvailable(true);
            upgrades[(int) upgrade.EnergyConsumptionTrackerUpgrade].setAvailable(true);
            upgrades[(int) upgrade.CameraUpgrade].setAvailable(true);
        }

        if (id == upgrade.EnergyConsumptionTrackerUpgrade)
        {
            upgrades[(int) upgrade.SolarPowerUpgrade].setAvailable(true);
            upgrades[(int) upgrade.SmartWasteRecycleUpgrade].setAvailable(true);
        }

        if (id == upgrade.SolarPowerUpgrade)
        {
            upgrades[(int) upgrade.SmartStreetLightsUpgrade].setAvailable(true);
            upgrades[(int)upgrade.WindEnergyUpgrade].setAvailable(true);
        }

        if (id == upgrade.SmartStreetLightsUpgrade)
        {
            if (upgrades[(int) upgrade.CameraUpgrade].isActivated())
            {
                upgrades[(int) upgrade.SmartCrimeDetectionUpgrade].setAvailable(true);
            }
        }

        if (id == upgrade.CameraUpgrade)
        {
            if (upgrades[(int) upgrade.SmartStreetLightsUpgrade].isActivated())
            {
                upgrades[(int)upgrade.SmartCrimeDetectionUpgrade].setAvailable(true);
            }
        }

        if (id == upgrade.SmartStreetLightsUpgrade)
        {
            upgrades[(int) upgrade.ParkingIndicatorUpgrade].setAvailable(true);
            upgrades[(int) upgrade.SmartTrafficLightsUpgrade].setAvailable(true);
        }

        if (id == upgrade.WindEnergyUpgrade)
        {
            upgrades[(int)upgrade.NuclearEnergyUpgrade].setAvailable(true);
        }

        if (id == upgrade.ParkingIndicatorUpgrade)
        {
            if (upgrades[(int) upgrade.SmartTrafficLightsUpgrade].isActivated())
            {
                upgrades[(int)upgrade.SelfDrivingCarsUpgrade].setAvailable(true);
            }
        }

        if (id == upgrade.SmartTrafficLightsUpgrade)
        {
            if (upgrades[(int) upgrade.ParkingIndicatorUpgrade].isActivated())
            {
                upgrades[(int)upgrade.SelfDrivingCarsUpgrade].setAvailable(true);
            }
        }

        if (id == upgrade.SelfDrivingCarsUpgrade)
        {
            upgrades[(int)upgrade.FlyingCarsUpgrade].setAvailable(true);
        }
    }

    public void displayDialogue(upgrade id)
    {

        if(id == upgrade.SmartHomeUpgrade)
        {
            SmartHomeDialogue.SetActive(true);
        }
        else if(id == upgrade.SmartWatchUpgrade)
        {
            SmartWatchDialogue.SetActive(true);
        }
        else if(id == upgrade.EnergyConsumptionTrackerUpgrade)
        {
            EnergyConsumptionTrackerDialogue.SetActive(true);
        }
        else if(id == upgrade.SolarPowerUpgrade)
        {
            SolarPowerDialogue.SetActive(true);
        }
        else if(id == upgrade.SmartWasteRecycleUpgrade)
        {
            SmartWasteDialogue.SetActive(true);
        }
        else if(id == upgrade.CameraUpgrade)
        {
            CameraDialogue.SetActive(true);
        }
        else if(id == upgrade.SmartStreetLightsUpgrade)
        {
            StreetLightDialogue.SetActive(true);
        }
        else if(id == upgrade.SmartCrimeDetectionUpgrade)
        {
            CrimeDetectDialogue.SetActive(true);
        }
        else if(id == upgrade.WindEnergyUpgrade)
        {
            WindEnergyDialogue.SetActive(true);
        }
        else if(id == upgrade.ParkingIndicatorUpgrade)
        {
            ParkingDialogue.SetActive(true);
        }
        else if(id == upgrade.SmartTrafficLightsUpgrade)
        {
            TrafficLightDialogue.SetActive(true);
        }
        else if(id == upgrade.NuclearEnergyUpgrade)
        {
            NuclearDialogue.SetActive(true);
        }
        else if(id == upgrade.SelfDrivingCarsUpgrade)
        {
            SelfDrivingDialogue.SetActive(true);
        }
        else
        {
            FlyingCarDialogue.SetActive(true);
        }
    }

    public List<upgrade> getActiveUpgrades()
    {
        List<upgrade> active = new List<upgrade>();
        foreach (upgrade i in upgrade.GetValues(typeof(upgrade)))
        {
            if(upgrades[(int) i].isActivated()) {
                active.Add(i);
            }
        }

        return active;
    }
}
