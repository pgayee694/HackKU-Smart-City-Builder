using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SmartCrimeDetectionUpgrade : AbstractUpgrade
{
    public override int moneyImproveAmt => 12;

    public override int safetyImproveAmt => 3;

    public override int envImproveAmt => 0;

    public override int privacyImproveAmt => -2;

    public override int cost => 3500;
}
