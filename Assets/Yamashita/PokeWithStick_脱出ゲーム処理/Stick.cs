using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stick : MonoBehaviour{
    [SerializeField]
    private readonly float MOVING_PLACE_TIME = (float)0.5;//棒を上に上げる時間


    private float movingPlaceTimer;//棒を移動させる場所の変数
    [SerializeField]
    private float moveX = (float)0.01;
    [SerializeField]
    private float moveY = (float)0.01;
    [SerializeField]
    private float moveZ = (float)0.01;

    // Start is called before the first frame update
    void Start() {
        movingPlaceTimer = 99;//初期値
    }//Start

    // Update is called once per frame
    void Update() {
        //VR操作用に変更してください
        if (Input.GetKeyDown(KeyCode.Space) && movingPlaceTimer > MOVING_PLACE_TIME * 2) {
            movingPlaceTimer = 0;
            this.GetComponent<BoxCollider>().isTrigger = false;
        }//if

        if (movingPlaceTimer < MOVING_PLACE_TIME) {//棒を上に上げる処理
            this.transform.localPosition = new Vector3(
                this.transform.localPosition.x - moveX,
                this.transform.localPosition.y + moveY,
                this.transform.localPosition.z + moveZ);
        } else if (movingPlaceTimer < MOVING_PLACE_TIME * 2) {//棒を下に下げる処理
            this.transform.localPosition = new Vector3(
                this.transform.localPosition.x + moveX,
                this.transform.localPosition.y - moveY,
                this.transform.localPosition.z - moveZ);
        } else {
            this.GetComponent<BoxCollider>().isTrigger = true;
        }//if
        movingPlaceTimer += Time.deltaTime;
    }//Update

    private void OnCollisionEnter(Collision col) {
        if (col.gameObject.tag == "Key") {
            col.gameObject.GetComponent<Rigidbody>().useGravity = true;
        }//if
    }//OnCollisionEnter
}
