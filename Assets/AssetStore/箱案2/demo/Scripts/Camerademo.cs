using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camerademo : MonoBehaviour
{
    GameObject cubot;
    // Start is called before the first frame update
    void Start()
    {
        cubot = GameObject.Find("CubeRobot");
    }

    // Update is called once per frame
    void Update()
    {
        transform.LookAt(cubot.transform.position);
        if (Vector3.Distance(cubot.transform.position,transform.position) > 6f)
        {
            transform.Translate(0, 0, 0.04f);
        }
    }


}
