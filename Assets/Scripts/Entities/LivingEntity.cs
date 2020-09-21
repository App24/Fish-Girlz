using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class LivingEntity : Entity{
    
    [SerializeField]
    protected float maxHealth=10;
    protected float health;
    public bool invincible;

    public EntityStats entityStats;

    public LivingEntityInfo livingEntityInfo;

    private void Start() {
        health=maxHealth;
    }

    public void Damage(float amount){
        if(amount<0)
            Heal(Mathf.Abs(amount));
        if(!invincible){
            health-=amount;
            if(health<=0)
                Death();
        }
    }

    public void Heal(float amount){
        if(amount<0)
            Damage(Mathf.Abs(amount));
        health+=amount;
        if(health>maxHealth)
            health=maxHealth;
    }

    void Death(){

        OnDeath();
    }

    protected abstract void OnDeath();
}

/*[System.Serializable]
public class LivingEntityInfo{

    public string characterName;
    public Sprite characterImage;
}*/

[System.Serializable]
public class EntityStats{
    public int strength;
    public int dexterity;
    public int constitution;
    public int intelligence;
    public int wisdom;
    public int charisma;
    public int aggression;
}