using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using UnityEngine;
using UnityEngine.UI;

//必要なコンポーネントを定義
[RequireComponent(typeof(Text))]
public class LogDisplay : MonoBehaviour {
    private Text text;
    private StringBuilder builder = new StringBuilder();

    private enum TextType {
        log,
        logWarning,
        logError
    }

    [SerializeField]
    private TextType textType;

    public bool IsLogOutput { get; set; }
    public bool IsLogWarningOutput { get; set;}
    public bool IsLogErrorOutput { get; set; }

    void Awake() {
        text = this.GetComponent<Text>();
        text.verticalOverflow = VerticalWrapMode.Truncate;//範囲外のテキストを切り捨て
        text.supportRichText = true;
        text.text = string.Empty;
        IsLogOutput = true;
        IsLogWarningOutput = true;
        IsLogErrorOutput = true;
    }

    private void OnEnable() {
        Application.logMessageReceived += HandleLog;//ログをプログラム取得
        builder = new StringBuilder();
    }

    private void OnDisable() {
        Application.logMessageReceived -= HandleLog;//ログをプログラム取得しない
    }

    /// <summary>
    /// ログ情報の取得
    /// </summary>
    private void HandleLog(string logTex,string stackTrace,LogType logType) {
        builder.Clear();
        switch (textType) {//テキストの色分けを行う
            case TextType.log://通常のログの場合
                if (logType == LogType.Log) {
                    logTex = GetColoredString(logTex, "white");
                    text.text += builder.Append(logTex).Append(Environment.NewLine).ToString();//テキストの追加
                }
                break;
            case TextType.logWarning://警告ログの場合
                if (logType == LogType.Warning) {
                    logTex = GetColoredString(logTex, "yellow");
                    text.text += builder.Append(logTex).Append(Environment.NewLine).ToString();//テキストの追加
                }
                break;
            case TextType.logError://エラー型の場合
                if (logType == LogType.Error) {
                    logTex = GetColoredString(logTex, "red");
                    text.text += builder.Append(logTex).Append(Environment.NewLine).ToString();//テキストの追加
                }
                break;
            default:
                break;
        }//switch

        AdjustText(text);//テキストを表示範囲に収める
    }//HandleLog

    /// <summary>
    /// 文字列に色を付ける
    /// </summary>
    private string GetColoredString(string src,string color) {
        return string.Format("<color={0}>{1}</color>", color, src);
    }

    /// <summary>
    /// Textの範囲内に文字列を収める
    /// </summary>
    private void AdjustText(Text text) {
        var textstr = text.text;
        var settings = text.GetGenerationSettings(text.rectTransform.rect.size);//フォント、サイズの情報
        //見切れていないかのチェック
        TextGenerator generator = text.cachedTextGenerator;
        generator.Populate(textstr, settings);

        int countVisible = generator.characterCountVisible;
        if (countVisible == 0 || textstr.Length <= countVisible)
            return;
        int truncatedCount = textstr.Length - countVisible;
        var lines = textstr.Split('\n');

        foreach(string line in lines) {
            text.text = textstr.Remove(0, line.Length + 1);
            truncatedCount -= (line.Length + 1);
            if(truncatedCount <= 0) {
                break;
            }//if
        }//foreach

    }//AdjustText

}//LogDisplay
