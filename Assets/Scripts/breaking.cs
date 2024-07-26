using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class breaking : MonoBehaviour
{
    public Transform grabDetect;
    public Transform boxHolder;
    public float rayDist;
    public Animator animator;
    public GameObject breakableObject1;
    public GameObject breakableObject2;
    public GameObject hiddenObject1;
    public GameObject hiddenObject2;
    private Dictionary<GameObject, GameObject> hiddenObjectMap = new Dictionary<GameObject, GameObject>(); // Map breakable objects to their hidden objects

    private void Start()
    {
        // Example of setting up the dictionary programmatically
        // Add key-value pairs as needed
        hiddenObjectMap.Add(breakableObject1, hiddenObject1);
        hiddenObjectMap.Add(breakableObject2, hiddenObject2);
        // Add more pairs if required
    }

    IEnumerator StopAnimation()
    {
        yield return new WaitForSeconds(0.35F);
        animator.SetBool("playerBreaking", false);
    }

    // Update is called once per frame
    void Update()
    {
        RaycastHit2D grabCheck = Physics2D.Raycast(grabDetect.position, Vector2.right * transform.localScale, rayDist);
        if (Input.GetKey((KeyCode.R)))
            {
            animator.SetBool("playerBreaking", true);
            StartCoroutine("StopAnimation");
            if (grabCheck.collider != null && grabCheck.collider.tag == "break")
            {
                GameObject breakableObject = grabCheck.collider.gameObject;

                // Destroy the breakable object
                Destroy(breakableObject);
                // Check if there's a corresponding hidden object for this breakable object
                if (hiddenObjectMap.ContainsKey(breakableObject))
                {
                    // Get the hidden object associated with the breakable object
                    GameObject hiddenObject = hiddenObjectMap[breakableObject];

                    // Activate the hidden object
                    if (hiddenObject != null)
                    {
                        hiddenObject.SetActive(true);
                    }
                }
            }
            }
    }
}
