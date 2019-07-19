using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour {

	bool pause = false; // 게임 정지 유무

	public GameObject menuCanvas;

    void Start() {
		menuCanvas.SetActive(false); // 게임이 시작되면 메뉴 가 비활성화 된다.        
    }

    void Update() {
        
    }

	public void GameReset() {
		SceneManager.LoadScene("GameScene");
		Time.timeScale = 1; // 게임을 다시 시작할 수 있도록 1로 설정
	}

	public void pauseSwitch() {
		if (pause) { // 메뉴 비활성화
			pause = false;
			Time.timeScale = 1; // 게임이 원래 대로 흘러가도록 설정 (1 이면 시간이 흐르고,0 이면 정지)
			menuCanvas.SetActive(false); // 메뉴작동 을 중단시킴 
		}
		else { // 메뉴 활성화
			pause = true; 
			Time.timeScale = 0; // 게임이 정지 상태가 되도록 설정
			menuCanvas.SetActive(true);
		}
	}

	public void startMenu() {
		SceneManager.LoadScene("StartScene"); // 게임이 시작되면 시작 씬이 실행
	}
}
