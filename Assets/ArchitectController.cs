using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArchitectController : MonoBehaviour
{
    public CatControllerScript catController;
    public levelTwoInteractions interactions;
    [SerializeField] public SpriteRenderer sr;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "cat")
        {
            catController.moving = false;
            sr.flipX = true;
            interactions.architectTurned = true;
        }
    }
}
