using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Entity : MonoBehaviour
{

    protected List<GameObject> interactives=new List<GameObject>();
    protected GameObject interactiveTarget=null;

    protected void Update() {
        if(interactives.Count>0){
            Vector2 shortestDistance=new Vector2(float.MaxValue, float.MaxValue);

            foreach(GameObject go in interactives){
                Vector2 distance=transform.position - go.transform.position;

                if(distance.magnitude<shortestDistance.magnitude){
                    shortestDistance=distance;
                    interactiveTarget=go;
                }
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D other) {
        if(other.GetComponent<Interactive>()!=null){
            interactives.Add(other.gameObject);
            other.GetComponent<Interactive>().OnEntityEnter(this);
        }
    }

    private void OnTriggerExit2D(Collider2D other) {
        if(other.GetComponent<Interactive>()!=null){
            interactives.Remove(other.gameObject);
            other.GetComponent<Interactive>().OnEntityExit(this);
        }
    }

}
