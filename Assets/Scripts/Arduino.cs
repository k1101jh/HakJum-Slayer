using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//using System.IO.Ports;

    /*
public class Arduino : MonoBehaviour
{

    public GameObject pen;

    //SerialPort sp = new SerialPort("COM5", 9600);
    Vector3 arduinoPosition;

    int[] val = new int[7];
    // Use this for initialization
    void Start()
    {
        sp.Open();
        sp.ReadTimeout = 1;
    }

    // Update is called once per frame
    void Update()
    {
        if (sp.IsOpen)
        {
            try
            {
                /*
                for (int i = 0; i < 7; i++)
                {
                    val[i] = sp.ReadByte();
                    val[i] = Mathf.Abs(128 - val[i]);
                    Debug.Log(val[i]);
                }
                //pen.transform.position = new Vector2(val[4], val[5]);
                if (val[4] > 128)
                    pen.transform.Translate(Vector3.back * Time.deltaTime * val[4]);
                else
                    pen.transform.Translate(Vector3.forward * Time.deltaTime * val[4]);
                if (val[5] > 128)
                    pen.transform.Translate(Vector3.left * Time.deltaTime * val[5]);
                else
                    pen.transform.Translate(Vector3.right * Time.deltaTime * val[5]);
                Debug.Log(val[4] + "  " + val[5]);
                
                Debug.Log(sp.ReadByte());
            }
            catch (System.Exception) { }
        }
    }
}*/