using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartManager : MonoBehaviour { 

	public void GameStart() {
		SceneManager.LoadScene("GameScene");
		Time.timeScale = 1; // 무조건 게임이 실행되어야 하기 때문에 1로 설정
	}

	public void gameHelp() { 
		SceneManager.LoadScene("GameHelp");

	}

	public void closeBtn() {
		SceneManager.LoadScene("StartScene");
	}

	public void nextBtn() {
		SceneManager.LoadScene("GameNext");
	}

	public void prevBtn() {
		SceneManager.LoadScene("GameHelp");
	}

	public void gameExit() {
		Application.Quit(); // 안드로이드 앱 이나 모바일 어플리케이션을 이용했을 경우에만 정상 작동 함
	}

    void Start() {
		Screen.SetResolution(1920,1200,true);
    }

    void Update() {
        
    }
}
