using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SmartWasteRecycleUpgrade : AbstractUpgrade
{
    public override int moneyImproveAmt => 1;

    public override int safetyImproveAmt => 0;
    
    public override int envImproveAmt => 1;

    public override int privacyImproveAmt => 0;

    public override int cost => 800;
}
