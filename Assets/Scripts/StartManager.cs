using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartManager : MonoBehaviour { 

	public void GameStart() { // 게임 시작
		SceneManager.LoadScene("GameScene");
		Time.timeScale = 1; // 무조건 게임이 실행되어야 하기 때문에 1로 설정
	}

	public void gameHelp() { // 게임 도움말
		SceneManager.LoadScene("GameHelp");

	}

	public void closeBtn() { // close 버튼 을 눌렀을때
		SceneManager.LoadScene("StartScene"); // 메인 으로 넘어감
	}

	public void nextBtn() { // next 버튼 을 눌렀을때
		SceneManager.LoadScene("GameNext"); // 다음 도움 말로 넘어감
	}

	public void prevBtn() { // prev 버튼 을 눌렀을때
		SceneManager.LoadScene("GameHelp"); // 이전 도움 말로 넘어감
	}

	public void gameOne() {
		SceneManager.LoadScene("GameOne");
	}

	public void gameNext() {
		SceneManager.LoadScene("GameNext");
	}

	public void gameExit() {
		Application.Quit(); // 안드로이드 앱 이나 모바일 어플리케이션을 이용했을 경우에만 정상 작동 함
	}

    void Start() {
		Screen.SetResolution(1920,1200,true); // 게임 을 시작할때 모바일 해상도를 맞춰줌
    }

    void Update() {
        
    }
}
