using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Target : MonoBehaviour {
    [SerializeField]
    private GameObject rod;

    private void OnCollisionEnter(Collision col) {
        if (col.gameObject.tag == "Ball") {
            //棒に重力を反映させる
            rod.GetComponent<Rigidbody>().useGravity = true;
            rod.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.None;
        }//if
    }//OnCollisionEnter

}//Target
