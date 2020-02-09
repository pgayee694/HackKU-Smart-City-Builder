using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SmartTrafficLightsUpgrade : AbstractUpgrade
{
    public override int moneyImproveAmt => 10;

    public override int safetyImproveAmt => 1;

    public override int envImproveAmt => -1;

    public override int privacyImproveAmt => 0;

    public override int cost => 3100;
}
