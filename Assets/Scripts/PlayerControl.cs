using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerControl : MonoBehaviour
{
    public float turningForce;
    public bool activeJumping;

    public int points = 0;
    int bestPoints;

    public Text pointsText;
    public Text bestPointsText;
    public Text speed;
    public Color colorOfPointsWhenNewBest;
    public Color colorOfPointsWhenNewGlobalBest;

    public GameObject platformSystem;
    public GameObject cameraObject;

    Vector3 startPosition;

    Rigidbody2D rb;
    float steeringAxis;

    public BrowserCommunication browserCommunication;
    private void OnGUI()
    {
        pointsText.text = points.ToString();
        if(points>browserCommunication._globalBestPoints)
        {
            pointsText.color = colorOfPointsWhenNewGlobalBest;
        }
        else if (points > bestPoints)
        {
            pointsText.color = colorOfPointsWhenNewBest;
        }
        else
        {
            pointsText.color = Color.white;
        }

        bestPointsText.text = bestPoints.ToString();
        speed.text = System.Math.Round(Time.timeScale,2).ToString();

    }

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        startPosition = transform.position;
    }

    private void FixedUpdate()
    {
        if(Input.GetButtonDown("Jump"))
        {
            rb.bodyType = RigidbodyType2D.Dynamic;
            //rb.constraints = RigidbodyConstraints2D.FreezePositionX | RigidbodyConstraints2D.FreezeRotation;
            rb.constraints =RigidbodyConstraints2D.FreezeRotation;
        }
    }

    private void Update()
    {
        Time.timeScale = 1f + points / 100f;

        steeringAxis = Input.GetAxis("Horizontal");
        if (steeringAxis != 0)
        {
            transform.position += new Vector3(steeringAxis * turningForce * Time.deltaTime, 0f, 0f);
        }
    }

    private void OnBecameInvisible()
    {
        rb.bodyType = RigidbodyType2D.Static;
        Debug.Log("Game over");
        if(platformSystem!=null)
        {
            platformSystem.GetComponent<PlatformSystem>().ResetPlatforms();
        }
        if(points>browserCommunication._globalBestPoints)
        {
            browserCommunication._globalBestPoints = points;
            bestPoints = points;
        }
        else if(points>bestPoints)
        {
            bestPoints = points;
        }
        points = 0;
        transform.position = startPosition;
        cameraObject.GetComponent<CameraScript>().ResetPosition();

        BrowserCommunication.SendData(points);

    }

}
