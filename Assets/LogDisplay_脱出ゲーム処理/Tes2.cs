using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tes2 : MonoBehaviour
{
    int testA = 0;
    // Start is called before the first frame update
    void Start() {

    }

    // Update is called once per frame
    void Update() {
        testA++;
        Debug.Log("Log" + testA);
        Debug.LogWarning("LogWarning" + testA);
        Debug.LogError("LogError" + testA);

    }
}
