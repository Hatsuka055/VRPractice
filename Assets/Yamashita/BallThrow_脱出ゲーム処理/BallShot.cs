using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallShot : MonoBehaviour {
    [SerializeField]
    private GameObject ball;

    [SerializeField]
    private Transform point;

    private Vector3 clickPosition;

    [SerializeField]
    private float parabola;//ボールを投げる角度

    // Update is called once per frame
    void Update() {
        //VR用の操作方法に変更お願いします
        if (Input.GetKeyDown(KeyCode.Space)) {
            clickPosition = Input.mousePosition;
            clickPosition.z = 10f;//位置調整用
            GameObject instance =(GameObject)Instantiate(
                ball,new Vector3(this.transform.position.x,this.transform.position.y,this.transform.position.z+(float)0.5),Quaternion.identity);
            float anglesX;
            if (this.transform.localEulerAngles.x > 180) {
                anglesX = Mathf.Abs(this.transform.localEulerAngles.x - 360);
            } else {
                anglesX = this.transform.localEulerAngles.x;
            }
            instance.GetComponent<Rigidbody>().AddForce(point.position.x*400,(point.position.y-(float)0.6)*400,500);
        }//if
    }//Update
}//BallShot
