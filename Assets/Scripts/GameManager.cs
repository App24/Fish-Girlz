using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public DialogUIData dialogUIData;

    public FightSystemUIData fightSystemUIData;

    public CharactersInfo charactersInfo;

    static GameManager instance;

    static Transform playerTransform;

    static Vector3 cameraPosition, playerPosition;

    private void Awake() {
        instance=this;
    }

    public static DialogUIData DialogUIData => instance.dialogUIData;

    public static FightSystemUIData FightSystemUIData => instance.fightSystemUIData;

    public static CharactersInfo CharactersInfo => instance.charactersInfo;

    public static void StartFight(LivingEntity player){
        Camera cam=Camera.main;
        Vector3 fightSystemPosition=FightSystemUIData.fightSystemData.fightSystemTransform.position;
        cameraPosition=cam.transform.position;
        cam.transform.position=new Vector3(fightSystemPosition.x, fightSystemPosition.y, -10);
        cam.GetComponent<FollowTarget>().target=null;
        playerTransform=player.transform;
        playerPosition=player.transform.position;
        player.transform.position=FightSystemUIData.fightSystemData.charactersPos.pos1.position;
        player.GetComponent<PlayerMovement>().enabled=false;
    }

    public static void EndFight(){
        Camera cam=Camera.main;
        cam.transform.position=cameraPosition;
        cam.GetComponent<FollowTarget>().target=playerTransform;
        playerTransform.position=playerPosition;
        playerTransform.GetComponent<PlayerMovement>().enabled=true;
    }
}

[System.Serializable]
public class DialogUIData{

    public GameObject dialogBox;
    public Image characterImage;
    public Text characterName;
    public Text speechText;
}

[System.Serializable]
public class CharactersInfo{
    public LivingEntityInfo dominiqueInfo, astraInfo, opheliaInfo;
}

[System.Serializable]
public class FightSystemUIData{
    public GameObject fightSystemBox;
    public FightSystemData fightSystemData;
}

[System.Serializable]
public class FightSystemData{

    public Transform fightSystemTransform;
    public EntityPos charactersPos;
    public EntityPos enemyPos;
}

[System.Serializable]
public class EntityPos{
    public Transform pos1, pos2, pos3;
}