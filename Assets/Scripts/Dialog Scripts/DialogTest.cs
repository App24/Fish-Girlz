using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "App24/Dialog Scripts/Test", fileName = "Dialog Test")]
public class DialogTest : DialogScript
{

    public override void OnScript(LivingEntity player)
    {
        Debug.Log("test");
    }

    public override bool EndDialog=>true;
}
