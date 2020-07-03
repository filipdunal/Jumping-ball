using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Runtime.InteropServices;

public class BrowserCommunication : MonoBehaviour
{
    [DllImport("__Internal")]
    public static extern void SendData(float x);
    public float _globalBestPoints;
    public void ReceiveData(float globalBestPoints)
    {
        if(globalBestPoints>_globalBestPoints)
            _globalBestPoints = globalBestPoints;
    }
}
