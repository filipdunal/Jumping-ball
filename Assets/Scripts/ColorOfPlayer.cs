using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.Rendering.LWRP;

public class ColorOfPlayer : MonoBehaviour
{
    public GameObject player;
    public float speedOfChangingColor = 0.1f;
    int points;
    PlayerControl pc;

    public Color level0;
    public int pointsToLevel0;
    public Color level1;
    public int pointsToLevel1;
    public Color level2;
    public int pointsToLevel2;
    public Color level3;
    public int pointsToLevel3;

    Color desiredColor;
    Light2D li;
    void Start()
    {
        li=GetComponent<Light2D>();
        pc = player.GetComponent<PlayerControl>();
    }
    void Update()
    {
        points = pc.points;
        if(points==pointsToLevel0)
        {
            desiredColor = level0;
            li.color = desiredColor;
        }
        if(points==pointsToLevel1)
        {
            desiredColor = level1;
        }
        if(points==pointsToLevel2)
        {
            desiredColor = level2;
        }
        if(points==pointsToLevel3)
        {
            desiredColor = level3;
        }

        li.color=Color.Lerp(li.color, desiredColor, speedOfChangingColor);
        
    }
}
