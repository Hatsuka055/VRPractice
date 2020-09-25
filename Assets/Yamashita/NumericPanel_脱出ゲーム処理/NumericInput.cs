using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NumericInput : MonoBehaviour {
    private NumericPanel numericPanel;
    private int numeric;

    // Start is called before the first frame update
    void Start() {
        //gameObjectの名前を切り抜いて取得している
        //例)Number(1)→1
        numeric = int.Parse(name.Substring(name.Length - 2, 1));
        numericPanel = transform.parent.gameObject.GetComponent<NumericPanel>();
    }

    // Update is called once per frame
    void Update() {

    }
    private void OnCollisionEnter(Collision col) {
        if(col.gameObject.tag == "Player") {
            
        }
        numericPanel.Password += numeric;
        Debug.LogError(numericPanel.Password);
        Destroy(col.gameObject);
    }
}
