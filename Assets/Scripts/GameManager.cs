using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour { // 유니티 엔진내의 모든 것을 담당

	public Text seedText; 
	public Text roundText;
	public Text roundStartText;
	public int round = 0;
	public int seed = 1000;

	public int roundReadyTime = 5; // 라운드 대기 시간을 지정
	public int totalRound = 3; // 총 라운드 를 지정
	public int reward = 500; // 라운드 가 끝날때 마다 500씨앗씩 얻음
	public float spawnTime = 2.5f;
	public int spawnNumber = 5; // 한 라운드에서 몇마리 의 몬스터 가 출몰할지 결정
	
	private AudioSource audioSource;

	public int nowSelect;
	public Image select1; // 캐릭터 1
	public Image select2; // 캐릭터 2
	public Image select3; // 캐릭터 3
	public Image select4; // 캐릭터 4

	
	public Text clearText;
	public Text lifeText;

	public int life = 10; // 게임 메인 의 목숨 값
	public Text loseText; // 패배 한 메세지 값

	public GameObject respawnSpots; // 몬스터 출몰 변수

	public int decreaseLife() { //목숨이 감소 하는 함수
		if (life >= 1) { // 몬스터 가 울타리 에 닿았을때
			life = life - 1; // 게임 메인 목숨 감소
			lifeText.text = ":" + life;
			if (life == 0) { // 패배할경우
				loseText.enabled = true; // 패배문자 출력
				respawnSpots.GetComponent<CreateMonster>().enabled = false; // 몬스터 가 출몰 하지 않도록 설정

			}
		}
		return life;
	}
	public void gameClear() { // 게임을 승리하였을 경우
		clearText.enabled = true; // 승리했다는 엔진 상에 표시 해준다.
	}

	public void select(int number) { // 버튼을 선택 한 경우
		if (number == 1) { // 캐릭터 1을 선택
			nowSelect = 1;
			select1.GetComponent<Image>().color = Color.gray;
			select2.GetComponent<Image>().color = Color.white;
			select3.GetComponent<Image>().color = Color.white;
			select4.GetComponent<Image>().color = Color.white;

		}
		else if (number == 2) { // 캐릭터 2를 선택
			nowSelect = 2;
			select1.GetComponent<Image>().color = Color.white;
			select2.GetComponent<Image>().color = Color.gray;
			select3.GetComponent<Image>().color = Color.white;
			select4.GetComponent<Image>().color = Color.white;
		}
		else if (number == 3) {
			nowSelect = 3;
			select1.GetComponent<Image>().color = Color.white;
			select2.GetComponent<Image>().color = Color.white;
			select3.GetComponent<Image>().color = Color.gray;
		    select4.GetComponent<Image>().color = Color.white;
		}
		else if (number == 4) {
			nowSelect = 4;
			select1.GetComponent<Image>().color = Color.white;
			select2.GetComponent<Image>().color = Color.white;
			select3.GetComponent<Image>().color = Color.white;
			select4.GetComponent<Image>().color = Color.gray;
		}
	}
	public void clearRound() {
		if (round < totalRound) { // 최종 라운드 가 현재 라운드 보다 클경우 다음 라운드 로 넘어간다.
			nextRound();
			seed += reward;
			updateText();
			spawnTime -= 0.2f; // 출몰되는 시간을 단축 한다.
			spawnNumber += 3; //  시간이 지나면서 몬스터가 3마리씩 출몰한다.
			reward += 150; // 게임의 보상이 150씩 늘어난다.
		}
	}
	
	public void nextRound() { 
	     
		round = round + 1;
		if (round == 1) { // 처음 시작할 때에 다음 과 같이 보여줌
			roundText.text = "ROUND 0" + round;
			roundStartText.text = "ROUND 0" + round;
		}
		else if (round < 10) {
			roundText.text = "ROUND 0" + round;
			roundStartText.text = "ROUND 0" + round;
			roundStartText.GetComponent<Animator>().SetTrigger("Round Start");
		}
		else { // round 가 10 이상 일 경우 두 자리 로 표시 해줌
			roundText.text = "ROUND " + round;
			roundStartText.text = "ROUND " + round;
			roundStartText.GetComponent<Animator>().SetTrigger("Round Start");
		}
		audioSource.PlayOneShot(audioSource.clip);
	}

	public void updateText() {
		seedText.text = "씨앗: " + seed; 
	}

    void Start() {
		Screen.SetResolution(1920,1200,true);
		// 게임시작시에 메세지는 해제함
		clearText.enabled = false;
		loseText.enabled = false;
		audioSource = roundStartText.GetComponent<AudioSource>();
		updateText(); // 현재 남아 있는 씨앗을 실행 할 때 마다 초기화
		nextRound();
		select(1);
		lifeText.text = life.ToString(); // 목숨 값 을 정수형 에서 문자형으로 변환
    }

    void Update() {
        
    }
}
