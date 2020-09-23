using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using UnityEngine;
using UnityEngine.UI;

public class LogButton : MonoBehaviour {
    public Text log_LogButton;
    private Text logText;
    private void Start() {
        logText = log_LogButton.GetComponent<Text>();
    }
    public void OnClick() {
        if (this.logText.enabled)
            this.logText.enabled = false;
        else
            this.logText.enabled = true;
    }

    private void OnTriggerEnter(Collider other) {
        if (this.logText.enabled)
            this.logText.enabled = false;
        else
            this.logText.enabled = true;
    }
}