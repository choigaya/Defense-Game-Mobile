using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class CreateCharacter : MonoBehaviour {

	public GameObject characterPrefab1;
	public GameObject characterPrefab2;

	private GameObject characterPrefab;
	private GameObject character;
	private AudioSource audioSource;
	private GameManager gameManager;
	private CharacterStat characterStat;


    void Start() {
		audioSource = gameObject.GetComponent<AudioSource>();
		gameManager = GameObject.Find("Game Manager").GetComponent<GameManager>();
    }

    
    void Update() {
              
    }

	private void OnMouseDown() { // 마우스 / 터치 를 사용하여 캐릭터를 생성할 수 있도록 한다.
		// TODO: 마우스 일경우: -1,모바일: 0 이상
	    if (EventSystem.current.IsPointerOverGameObject(-1) == true) { return; } // 게임 메뉴를 클릭할때 캐릭터 생성을 무효화 시킴
		if (EventSystem.current.IsPointerOverGameObject(0) == true) { return; }
		if (gameManager.nowSelect == 1) { // 캐릭터 1 이 선택
			characterPrefab = characterPrefab1; // 캐릭터1 에 맞게 초기화
			characterStat = characterPrefab.GetComponent<CharacterStat>();
		}
		else if (gameManager.nowSelect == 2) { // 캐릭터 2가 선택
			characterPrefab = characterPrefab2; // 캐릭터2 에 맞게 초기화
			characterStat = characterPrefab.GetComponent<CharacterStat>();
		}
		if (character == null) { // 캐릭터가 존재하지 않는 경우

			CharacterStat characterStat = characterPrefab.GetComponent<CharacterStat>();
			if (characterStat.canCreate(gameManager.seed)) {
				character = (GameObject)Instantiate(characterPrefab,transform.position,Quaternion.identity); // 타워 위에 캐릭터를 위치 시킨다.
				audioSource.PlayOneShot(audioSource.clip);
				gameManager.seed -= character.GetComponent<CharacterStat>().cost; // 씨앗은 비용 만큼 빼준다.
				gameManager.updateText();

			}
		}
	}
}
