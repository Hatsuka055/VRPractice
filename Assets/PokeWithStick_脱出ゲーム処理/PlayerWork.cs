using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerWork : MonoBehaviour {

    [SerializeField]
    private GameObject camera;

    // Update is called once per frame
    void Update() {
        Work();
        Vector3 angle = new Vector3(Input.GetAxis("Mouse X") * 2, Input.GetAxis("Mouse Y") * 2, 0);
        camera.transform.RotateAround(this.transform.position, Vector3.up, angle.x);
        camera.transform.RotateAround(this.transform.position, Vector3.right, angle.y);
        camera.transform.localPosition = new Vector3(0, 1, 0);
        camera.transform.localRotation = Quaternion.Euler(camera.transform.localEulerAngles.x, camera.transform.localEulerAngles.y, 0);
    }//Update

    private void Work() {
        float x = Input.GetAxis("Horizontal") * 10;
        float y = Input.GetAxis("Vertical") * 10;
        this.GetComponent<Rigidbody>().AddForce(x, 0, y);
    }//Work

}//PlayerWork
