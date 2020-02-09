using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraUpgrade : AbstractUpgrade
{
    public override int moneyImproveAmt => 10;

    public override int safetyImproveAmt => 2;

    public override int envImproveAmt => 0;

    public override int privacyImproveAmt => -2;

    public override int cost => 3500;
}
