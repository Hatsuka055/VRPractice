using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChange : MonoBehaviour {
 public void OnClick() {
		if (SceneManager.GetActiveScene().buildIndex == 0)
		{
			SceneManager.LoadScene(1);//File→BuildSettings→ScenesInBuildでメインステージを設定してください

		}else if (SceneManager.GetActiveScene().buildIndex == 1)
		{
			SceneManager.LoadScene(0);//File→BuildSettings→ScenesInBuildでメインステージを設定してください
		}

 }//OnClick
}//SceneChange
