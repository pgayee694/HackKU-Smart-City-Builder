using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NuclearEnergyUpgrade : AbstractUpgrade
{
    public override int moneyImproveAmt => 20;

    public override int safetyImproveAmt => 0;

    public override int envImproveAmt => 4;

    public override int privacyImproveAmt => 0;

    public override int cost => 5000;
}
