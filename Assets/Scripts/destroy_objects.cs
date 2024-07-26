using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class destroy_objects : MonoBehaviour
{
    public int lifeTime = 1;

    public void Start()
    {
        StartCoroutine(WaitThenDie());
    }

    IEnumerator WaitThenDie()
    {
        yield return new WaitForSeconds(lifeTime);
        Destroy(gameObject);
    }
}
