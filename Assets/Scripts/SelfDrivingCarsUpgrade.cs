using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelfDrivingCarsUpgrade : AbstractUpgrade
{
    public override int moneyImproveAmt => 12;

    public override int safetyImproveAmt => 2;

    public override int envImproveAmt => 0;

    public override int privacyImproveAmt => 0;

    public override int cost => 4000;
}
