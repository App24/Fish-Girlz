using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Interactive : MonoBehaviour
{
    public abstract void OnEntityEnter(Entity entity);

    public abstract void OnEntityExit(Entity entity);

    public abstract void OnInteract(Entity entity);

    protected bool EntityIsPlayer(Entity entity){
        return entity.GetType()==typeof(PlayerEntity);
    }

}
