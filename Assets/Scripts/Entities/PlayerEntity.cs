using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerEntity : LivingEntity
{
    protected override void OnDeath()
    {
        
    }

    protected new void Update() {
        base.Update();
                
        if(interactiveTarget!=null){
            if(Input.GetKeyDown(KeyCode.E))
            interactiveTarget.GetComponent<Interactive>().OnInteract(this);
        }
    }
}
