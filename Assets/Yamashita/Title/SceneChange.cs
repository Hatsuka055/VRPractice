using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChange : MonoBehaviour {
 public void OnClick() {
  SceneManager.LoadScene(1);//File→BuildSettings→ScenesInBuildでメインステージを設定してください
 }//OnClick
}//SceneChange
