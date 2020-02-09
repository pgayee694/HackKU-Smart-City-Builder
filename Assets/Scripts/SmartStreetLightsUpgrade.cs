using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SmartStreetLightsUpgrade : AbstractUpgrade
{
    public override int moneyImproveAmt => 15;

    public override int safetyImproveAmt => 1;

    public override int envImproveAmt => -1;

    public override int privacyImproveAmt => 0;

    public override int cost => 2000;
}
