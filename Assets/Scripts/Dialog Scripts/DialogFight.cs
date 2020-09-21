using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "App24/Dialog Scripts/Fight", fileName = "Dialog Fight")]
public class DialogFight : DialogScript
{

    public override void OnScript(LivingEntity player)
    {
        GameManager.StartFight(player);
    }

    public override bool EndDialog => true;
}
