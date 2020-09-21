using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TalkInteractive : CharacterInteractive
{
    [SerializeField]
    DialogInfo[] dialogInfos;

    int index=0;

    bool interacting;

    Entity playerEntity;
    DialogUIData dialogUIData;

    private void Start() {
        dialogUIData=GameManager.DialogUIData;
    }

    public override void OnEntityEnter(Entity entity)
    {

    }

    public override void OnEntityExit(Entity entity)
    {
        if(EntityIsPlayer(entity)){
            index=0;
            interacting=false;
            dialogUIData.dialogBox.SetActive(interacting);
        }
    }

    public override void OnInteract(Entity entity)
    {
        if(EntityIsPlayer(entity)){
            index=0;
            interacting=!interacting;
            dialogUIData.dialogBox.SetActive(interacting);
            playerEntity=entity;
            UpdateText();
        }
    }

    private void Update() {
        if(interacting){
            if(Input.GetKeyDown(KeyCode.LeftArrow)){
                index--;
                if(index<0)
                    index=0;
                UpdateText();
            }
            if(Input.GetKeyDown(KeyCode.RightArrow)){
                index++;
                if(index>dialogInfos.Length-1)
                    index=dialogInfos.Length-1;
                UpdateText();
            }
        }
    }

    void UpdateText(){
        LivingEntity livingEntity = (LivingEntity) playerEntity;
        if(GameManager.DialogUIData.dialogBox.activeSelf){
            if(dialogInfos.Length>0){
                if(dialogInfos.Length>index){
                    DialogInfo dialogInfo=dialogInfos[index];
                    LivingEntityInfo livingEntityInfo=null;
                    switch(dialogInfo.dialogType){
                        case DialogType.Dominique:
                            livingEntityInfo=GameManager.CharactersInfo.dominiqueInfo;
                            break;
                        case DialogType.Astra:
                            livingEntityInfo=GameManager.CharactersInfo.astraInfo;
                            break;
                        case DialogType.Ophelia:
                            livingEntityInfo=GameManager.CharactersInfo.opheliaInfo;
                            break;
                        case DialogType.Character:
                            livingEntityInfo=characterEntity.livingEntityInfo;
                            break;
                        case DialogType.NewCharacter:
                            livingEntityInfo=dialogInfo.livingEntityInfo;
                            break;
                    }
                    if(livingEntityInfo!=null){
                        dialogUIData.characterImage.sprite=livingEntityInfo.characterImage;
                        dialogUIData.characterName.text=livingEntityInfo.characterName;
                        dialogUIData.speechText.text=TranslateText(dialogInfo.text, livingEntity);
                    }
                    if(dialogInfo.dialogScript!=null){
                        dialogInfo.dialogScript.OnScript(livingEntity);
                        if(dialogInfo.dialogScript.EndDialog){
                            index=0;
                            interacting=false;
                            dialogUIData.dialogBox.SetActive(interacting);
                        }
                    }
                }
            }
        }
    }

    string TranslateText(string text, LivingEntity livingEntity){
        text=text.Replace("%name%", characterEntity.livingEntityInfo.characterName);
        text=text.Replace("%playerName%", livingEntity.livingEntityInfo.characterName);
        return text;
    }
}

[System.Serializable]
public class DialogInfo{
    public DialogType dialogType;

    [ConditionalHide("dialogType", 4)]
    public LivingEntityInfo livingEntityInfo;

    [ConditionalHide("dialogType", 0, 1, 2, 3, 4)]
    public string text;
    public DialogScript dialogScript;
}

[System.Serializable]
public enum DialogType{
    Character,
    Dominique,
    Astra,
    Ophelia,
    NewCharacter,
    Script
}