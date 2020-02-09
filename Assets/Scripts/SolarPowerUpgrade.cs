using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SolarPowerUpgrade : AbstractUpgrade
{
    public override int moneyImproveAmt => 12;

    public override int safetyImproveAmt => 0;

    public override int envImproveAmt => 2;
    public override int privacyImproveAmt => 0;

    public override int cost => 3000;
}
