using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SmartHomeUpgrade : AbstractUpgrade
{
    public override int moneyImproveAmt => 10;

    public override int safetyImproveAmt => 0;

    public override int envImproveAmt => 0;

    public override int privacyImproveAmt => -1;

    public override int cost => 2000;
}
