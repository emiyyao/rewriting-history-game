using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CatControllerScript : MonoBehaviour
{
    public bool moving;
    // [SerializeField] public Rigidbody2D rb;
    public float catSpeed = 2.0f;
    [SerializeField] public Animator animator;

    // Start is called before the first frame update
    void Start()
    {
        moving = false;
    }

    // Update is called once per frame
    void Update()
    {
        if(moving) {
            // rb.velocity = new Vector2(catSpeed, rb.velocity.y);
            transform.Translate(Vector2.right * Time.deltaTime);
            animator.SetBool("moving", true);
        } else {
            // rb.velocity = new Vector2(0, 0);
            animator.SetBool("moving", false);
        }
    }
}
