using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformScript : MonoBehaviour
{
    public float gap = 2f;
    public bool takenPoint;
    public Transform platformClonesPlace;

    public bool cloned;

    public void cloneMe()
    {
        if(!cloned)
        {
            int posX = (int)Random.Range(-4f, 4f);
            Vector3 pos = new Vector3(posX, transform.position.y + gap);
            Instantiate(this, pos, Quaternion.identity,platformClonesPlace);
            cloned = true;
        }
        
    }
}
