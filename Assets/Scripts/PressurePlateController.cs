using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PressurePlateController : MonoBehaviour
{
    private bool isDepressed = false;
    public GameObject affectedObject;
    private Sprite[] sprites;
    public SpriteRenderer plateRenderer;
    public double plateHeight = 0.2;
    public double affectedObjectHeight = 1.5;
    
    void Start()
    {
        plateRenderer = gameObject.GetComponent<SpriteRenderer>();
        sprites = Resources.LoadAll<Sprite>("pressureplate");
    }

    void OnTriggerStay2D(Collider2D collision)
    { 
        if(collision.tag == "Player" || collision.tag == "grab")
        {
            if(!isDepressed) {
                isDepressed = true;
                plateRenderer.sprite = sprites[1];
                // put the plate down - change the rendered sprite, move it downward
                transform.position += new Vector3(0, -1*(float)plateHeight, 0);
                // call the effect function, which will do something else
                pressurePlateEffect();
            }
        }
    }

    void OnTriggerExit2D(Collider2D collision)
    { 
        if(collision.tag == "Player" || collision.tag == "grab")
        {
            if(isDepressed) {
                isDepressed = false;
                plateRenderer.sprite = sprites[0];
                transform.position += new Vector3(0, (float) plateHeight, 0);
                pressurePlateUndoEffect();
            }
        }
    }

    void pressurePlateEffect() {
        affectedObject.transform.position += new Vector3(0, (float) affectedObjectHeight, 0);
    }

    void pressurePlateUndoEffect() {
        if (affectedObject)
        {
            affectedObject.transform.position += new Vector3(0, (float)-1 * (float)affectedObjectHeight, 0);
        }
    }
}
