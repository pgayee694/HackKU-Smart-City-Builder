using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnergyConsumptionTrackerUpgrade : AbstractUpgrade
{
    public override int moneyImproveAmt => 2;

    public override int safetyImproveAmt => 0;

    public override int envImproveAmt => 1;

    public override int privacyImproveAmt => 0;

    public override int cost => 700;
}
