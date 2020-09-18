using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandleBox : MonoBehaviour
{
    [SerializeField] private GameObject HandlePivot = default;
    [SerializeField] private GameObject Hand = default;
    [SerializeField] private GameObject futaPivot = default;

    private void Update()
    {
        if (90 <= handleAngle)
        {
            futaPivot.transform.rotation = Quaternion.Slerp(futaPivot.transform.rotation, Quaternion.Euler(90, 0, 0), 2 * Time.deltaTime);
        }
        else
        {
            futaPivot.transform.rotation = Quaternion.Slerp(futaPivot.transform.rotation, Quaternion.Euler(0, 0, 0), 2 * Time.deltaTime);
        }

    }
    float Zangle;
    float handleAngle;
    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.name == "THE HAND")
        {
            Zangle = Hand.transform.localRotation.eulerAngles.z;
            if (Zangle < 91)
            {
                HandlePivot.transform.localRotation = Quaternion.Euler(0, 0, Mathf.Clamp(Hand.transform.localRotation.eulerAngles.z, 0, 90));
                handleAngle = HandlePivot.transform.localRotation.eulerAngles.z;
            }


        }
    }


}
