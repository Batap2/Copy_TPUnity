using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class explosionFrxScript : MonoBehaviour
{
    Light l;
    
    void Start()
    {
        l = gameObject.GetComponent<Light>();

        StartCoroutine(DestroyObjectAfterDelay(gameObject, 2));
    }

    IEnumerator DestroyObjectAfterDelay(Object obj, float delay){

        yield return new WaitForSeconds(delay);
        Destroy(obj);
    }


}
