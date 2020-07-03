using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraScript : MonoBehaviour
{
    public Transform player;
    public Transform background;

    Vector3 startPosition;
    private void Start()
    {
        startPosition = transform.position;
        //Camera.main.aspect = 1.0f;
    }

    private void Update()
    {
        Vector3 newPosition = new Vector3(0f, player.position.y, -10f);
        if(newPosition.y>transform.position.y)
        {
            transform.position = newPosition;
        }

        background.position = new Vector3(transform.position.x,transform.position.y,background.position.z); 
    }

    public void ResetPosition()
    {
        transform.position = startPosition;
    }
}
