using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpgradeVisualizer : MonoBehaviour
{
    public GameObject upgradeManager;
    public GameObject streetLightContainer;
    public GameObject trafficLightContainer;
    public GameObject upgradedTrafficLightContainer;
    public GameObject crosswalkContainer;
    public GameObject suburbanContainer;
    public GameObject midtownContainer;
    public GameObject downtownContainer;
    public GameObject industrialContainer;
    public GameObject powerPlantsContainer;

    public GameObject personPrefab;
    public GameObject upgradedStreetLight;

    public Sprite smartwatchSprite;
    public Sprite smarthomeSprite;
    public Sprite energyConsumptionSprite;
    public ParticleSystem smarthomeParticles;
    public ParticleSystem energyConsumptionTrackerParticles;

    private readonly Vector3 SMARTWATCH_POSITION = new Vector3(0.019f, 1.2f, 0.019f);
    private readonly Vector3 SMARTWATCH_ROTATION = new Vector3(90f, 0f, 180f);
    private readonly Vector3 SMARTWATCH_SCALE    = new Vector3(0.1f, 0.1f, 0.1f);

    private readonly Vector3 SMARTHOME_POSITION  = new Vector3(0f, 10f, 0f);
    private readonly Vector3 SMARTHOME_ROTATION  = new Vector3(90f, 0f, 0f);
    private readonly Vector3 SMARTHOME_SCALE     = new Vector3(0.1f, 0.1f, 0.1f);

    private UpgradeController upgradeScript;
    private HashSet<UpgradeController.upgrade> upgradesVisualized;
    private System.Random rand;
    private float smartwatchChance;

    // Start is called before the first frame update
    void Start()
    {
        upgradeScript = upgradeManager.GetComponent<UpgradeController>();
        upgradesVisualized = new HashSet<UpgradeController.upgrade>();
        rand                = new System.Random();
        smartwatchChance    = 0f;
    }

    // Update is called once per frame
    void Update()
    {
        var currentUpgrades = upgradeScript.getActiveUpgrades();
        foreach(var upgrade in currentUpgrades)
        {
            if(!upgradesVisualized.Contains(upgrade))
            {
                VisualizeUpgrade(upgrade);
                upgradesVisualized.Add(upgrade);
            }
        }
    }

    public GameObject GetPerson(Transform tr)
    {
        var person = Instantiate(personPrefab, tr.position, tr.rotation);
        if(rand.NextDouble() <= smartwatchChance)
        {
            var spriteObject = new GameObject();
            spriteObject.transform.parent = person.transform;
            spriteObject.AddComponent<SpriteRenderer>().sprite = smartwatchSprite;
            spriteObject.transform.position = person.transform.position + SMARTWATCH_POSITION;
            spriteObject.transform.Rotate(SMARTWATCH_ROTATION);
            spriteObject.transform.localScale = SMARTWATCH_SCALE;
        }

        return person;
    }

    void VisualizeUpgrade(UpgradeController.upgrade upgrade)
    {
        switch(upgrade)
        {
            case UpgradeController.upgrade.SmartHomeUpgrade:
                    foreach(Transform child in suburbanContainer.transform)
                    {
                        var smarthomeObject = new GameObject();
                        smarthomeObject.transform.parent = child.transform;
                        smarthomeObject.transform.position = child.transform.position + SMARTHOME_POSITION;
                        smarthomeObject.AddComponent<SpriteRenderer>().sprite = smarthomeSprite;
                        smarthomeObject.transform.Rotate(SMARTHOME_ROTATION);
                        smarthomeObject.transform.localScale = SMARTHOME_SCALE;
                        var particles = Instantiate(smarthomeParticles);
                        particles.transform.parent = child.transform;
                        particles.transform.position = child.transform.position + SMARTHOME_POSITION;
                        particles.transform.localScale = new Vector3(0.5f, 0.5f, 0.5f);
                    }
                break;
            case UpgradeController.upgrade.SmartWatchUpgrade:
                   smartwatchChance = 0.5f;
                break;
            case UpgradeController.upgrade.EnergyConsumptionTrackerUpgrade:
                   foreach(Transform child in powerPlantsContainer.transform)
                    {
                        var energyTracker = new GameObject();
                        energyTracker.transform.parent = child.transform;
                        energyTracker.transform.position = child.transform.position + SMARTHOME_POSITION;
                        energyTracker.AddComponent<SpriteRenderer>().sprite = energyConsumptionSprite;
                        energyTracker.transform.Rotate(SMARTHOME_ROTATION);
                        energyTracker.transform.localScale = SMARTHOME_SCALE;
                        var particles = Instantiate(energyConsumptionTrackerParticles);
                        particles.transform.parent = child.transform;
                        particles.transform.position = child.transform.position + SMARTHOME_POSITION;
                        particles.transform.localScale = new Vector3(0.5f, 0.5f, 0.5f);
                    }
                break;
            case UpgradeController.upgrade.SmartStreetLightsUpgrade:
                    var newStreetContainer = new GameObject();
                    newStreetContainer.transform.position = streetLightContainer.transform.position;

                   foreach(Transform streetLight in streetLightContainer.transform.GetComponentsInChildren<Transform>())
                    {
                        var newLight = Instantiate(upgradedStreetLight, streetLight.transform.position, Quaternion.identity, newStreetContainer.transform);
                        newLight.transform.Rotate(streetLight.rotation.eulerAngles);
                        Destroy(streetLight.gameObject);
                    }
                break;
            case UpgradeController.upgrade.SmartTrafficLightsUpgrade:
                Destroy(trafficLightContainer);
                upgradedTrafficLightContainer.SetActive(true);
                break;
        }
    }
}
