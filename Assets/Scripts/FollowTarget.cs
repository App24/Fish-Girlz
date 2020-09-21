using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowTarget : MonoBehaviour
{
    public Transform target;

    Camera cam;

    float moveX=5, moveY=4;

    private void Start() {
        cam=GetComponent<Camera>();
    }

    void Update()
    {
        if(target!=null){
            Vector3 WorldToScreen=cam.WorldToScreenPoint(target.position);
            if(WorldToScreen.x>float.MinValue && WorldToScreen.x<Screen.width/moveX){
                //Left part of the screen
                transform.Translate(new Vector3(WorldToScreen.x-(Screen.width/moveX),0,0)/(Screen.width*2f));
            }else
            if(WorldToScreen.x<float.MaxValue&&WorldToScreen.x>Screen.width-Screen.width/moveX){
                //Right part of the screen
                transform.Translate(new Vector3(WorldToScreen.x-(Screen.width-Screen.width/moveX),0,0)/(Screen.width*2f));
            }
            if(WorldToScreen.y>float.MinValue && WorldToScreen.y<Screen.height/moveY){
                //Bottom part of the screen
                transform.Translate(new Vector3(0, WorldToScreen.y-(Screen.height/moveY),0)/(Screen.height*2f));
            }else
            if(WorldToScreen.y<float.MaxValue&&WorldToScreen.y>Screen.height-Screen.height/moveY){
                //Top part of the screen
                transform.Translate(new Vector3(0, WorldToScreen.y-(Screen.height-Screen.height/moveY),0)/(Screen.height*2f));
            }
        }
    }
}
