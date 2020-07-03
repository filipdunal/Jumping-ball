using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformSystem : MonoBehaviour
{
    public Transform staticPlatforms;
    public void ResetPlatforms()
    {
        foreach (Transform child in transform)
        {
            if(transform.childCount>0)
            {
                if (child != null)
                    Destroy(child.gameObject);
            }
            
        }
        foreach(Transform child in staticPlatforms)
        {
            if(transform.childCount>0)
            {
                if(child!=null)
                {
                    child.GetComponent<PlatformScript>().takenPoint = false;
                    child.GetComponent<PlatformScript>().cloned = false;
                }
            }  
        }
    }
}
