using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlyingCarsUpgrade : AbstractUpgrade
{
    public override int moneyImproveAmt => 17;

    public override int safetyImproveAmt => 3;

    public override int envImproveAmt => 0;

    public override int privacyImproveAmt => 0;

    public override int cost => 7500;
}
