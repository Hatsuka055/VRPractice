using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NumericPanel : MonoBehaviour {

    private int correctAnswer;//正解のパスワード ここの変数は数値をランダムで生成する処理と入れ替えて使用する
    private float moveX;
    private float positionX;
    [SerializeField]
    private Text text;
    public string Password { get; set; }

    void Start() {
        correctAnswer = 123;//仮パスワード
        Password = "";
        moveX = this.transform.position.x - (float)1.8;
    }

    // Update is called once per frame
    void Update() {
        if (Password.Length != 3)
            return;
        if (int.Parse(Password) == correctAnswer) {//パスワードが正解だった場合
            //合っていた場合の処理を記述する
            if(this.transform.position.x > moveX) {
                this.transform.position = new Vector3(this.transform.position.x - (float)0.0025, this.transform.position.y, this.transform.position.z);
                text.enabled = true;
            }
        } else {//パスワードが違っていた場合
            Password = "";
            //違っていた場合の処理を記述する
        }
    }
}
