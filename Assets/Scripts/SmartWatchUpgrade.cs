using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SmartWatchUpgrade : AbstractUpgrade
{
    public override int moneyImproveAmt => 7;

    public override int safetyImproveAmt => 1;

    public override int envImproveAmt => 0;

    public override int privacyImproveAmt => -1;

    public override int cost => 1000;
}
