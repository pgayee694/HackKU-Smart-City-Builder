using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParkingIndicatorUpgrade : AbstractUpgrade
{
    public override int moneyImproveAmt => 5;

    public override int safetyImproveAmt => 1;

    public override int envImproveAmt => 0;

    public override int privacyImproveAmt => 0;

    public override int cost => 2500;
}
