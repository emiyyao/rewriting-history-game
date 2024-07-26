using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class grabbing : MonoBehaviour
{
    public Transform grabDetect;
    public Transform boxHolder;
    public float rayDist;
    public Animator animator;
    private GameObject grabbedObject = null;

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKey((KeyCode.G)) && (animator.GetBool("playerPushing")||animator.GetBool("playerPulling")))
        {
            grabbedObject.transform.parent = boxHolder;
            grabbedObject.transform.position = boxHolder.position;
            grabbedObject.GetComponent<Rigidbody2D>().isKinematic = true;
        } else {
            RaycastHit2D grabCheck = Physics2D.Raycast(grabDetect.position, Vector2.right * transform.localScale, rayDist);

            if (grabCheck.collider != null && grabCheck.collider.tag == "grab")
            {
                //Debug.Log("Im here");
                if (Input.GetKey((KeyCode.G)))
                {
                    animator.SetBool("playerPushing", true);
                    grabbedObject = grabCheck.collider.gameObject;
                    grabbedObject.transform.parent = boxHolder;
                    grabbedObject.transform.position = boxHolder.position;
                    grabbedObject.GetComponent<Rigidbody2D>().isKinematic = true;
                }
                else
                {
                    {
                        animator.SetBool("playerPushing", false);
                        grabCheck.collider.gameObject.transform.parent = null;
                        //grabCheck.collider.gameObject.GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Dynamic;
                        animator.SetBool("playerPulling", false);
                    }
                }
            }
            else
            {
                animator.SetBool("playerPushing", false);
                animator.SetBool("playerPulling", false);
            }
        }

        
    }
}
