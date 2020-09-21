using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class DialogScript : ScriptableObject
{
    public abstract void OnScript(LivingEntity player);

    public virtual bool EndDialog => false;
}
