using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
public class FPSCounter : MonoBehaviour
{
    /// <summary>
    /// Written　Saito Takahiro
    /// </summary>

    [SerializeField] private float updateInterval = 0.5f;
    private int frameCount;
    private float prevTime;
    private float fps;

    TextMeshProUGUI TMP;
    private void Start()
    {
        TMP = GetComponent<TextMeshProUGUI>();
    }
    private void Update()
    {
        frameCount++;//フレームが書き出された回数
        float time = Time.realtimeSinceStartup - prevTime;

        if (time >= updateInterval)
        {
            fps = frameCount / time;//1秒に何回フレームが書き出されたか
            frameCount = 0;//フレームカウントリセット
            prevTime = Time.realtimeSinceStartup;//ゲームをスタートしてから経過した時間
        }
        TMP.text = "FPS: " + fps.ToString("f2");
    }
}

