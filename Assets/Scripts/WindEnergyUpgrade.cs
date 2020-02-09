using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WindEnergyUpgrade : AbstractUpgrade
{
    public override int moneyImproveAmt => 15;

    public override int safetyImproveAmt => 0;

    public override int envImproveAmt => 3;

    public override int privacyImproveAmt => 0;

    public override int cost => 4000;
}
