using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Alert : MonoBehaviour
{
    [SerializeField] private GameObject playerObject =default;
    [SerializeField] private GameObject alertObject = default;
    [SerializeField] private float displayDistance = default;
    Camera playerCam;
    void Start()
    {
        playerCam = playerObject.GetComponent<Camera>();
        alertObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (displayDistance < Vector3.Distance(transform.position, playerObject.transform.position))
        {
            alertObject.SetActive(true);
        }
    }
}
