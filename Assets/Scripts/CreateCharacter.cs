/*
     캐릭터 를 생성하는 소스

   * TowerSpot 으로 제어,오브젝트에 적용된 곳에 타워(캐릭터)를 배치시킬수 있음.
   
<<<<<<< 627e825001672a527a6810afe0055227223a32ab
*/

=======
*/

>>>>>>> final
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

// 캐릭터 생성
public class CreateCharacter : MonoBehaviour {
    
    // 캐릭터 의 각 Prefab 을 선언 해준다.
	public GameObject characterPrefab1;
	public GameObject characterPrefab2;
	public GameObject characterPrefab3;
	public GameObject characterPrefab4;

	private GameObject characterPrefab;
	private GameObject character;
	private AudioSource audioSource;
	private GameManager gameManager;
	private CharacterStat characterStat;


    void Start() {
		audioSource = gameObject.GetComponent<AudioSource>(); // 사용자가 캐릭터(타워)를 건설 할때 마다 음악 이 재생
		gameManager = GameObject.Find("Game Manager").GetComponent<GameManager>(); // 전체 객체 내에서 컴포넌트 안에 있는 GameManager 를 불러옴
    }

    
    void Update() {
              
    }

	private void OnMouseDown() { // 마우스 / 터치 를 사용하여 캐릭터를 생성할 수 있도록 한다.
		// TODO: 마우스 일경우: -1,모바일: 0 이상
	    if (EventSystem.current.IsPointerOverGameObject(-1) == true) { return; } // 게임 메뉴를 클릭할때 캐릭터 생성을 무효화 시킴
		if (EventSystem.current.IsPointerOverGameObject(0) == true) { return; }
<<<<<<< 627e825001672a527a6810afe0055227223a32ab
		if (gameManager.nowSelect == 1) { // warrior 1 이 선택
			characterPrefab = characterPrefab1; // warrior 1 에 맞게 초기화
			characterStat = characterPrefab.GetComponent<CharacterStat>();
		} else if (gameManager.nowSelect == 2) { // warriror 2가 선택
			characterPrefab = characterPrefab2; // warrior 2 에 맞게 초기화
			characterStat = characterPrefab.GetComponent<CharacterStat>();
		} else if (gameManager.nowSelect == 3) { // wizzard 1이 선택
			characterPrefab = characterPrefab3; // wizzard1 에 맞게 초기화
			characterStat = characterPrefab.GetComponent<CharacterStat>();
		} else if (gameManager.nowSelect == 4) { // wizzard 2가 선택
			characterPrefab = characterPrefab4; // wizzard2 에 맞게 초기화
=======
		if (gameManager.nowSelect == 1) { // warrior 1 이 선택
			characterPrefab = characterPrefab1; // warrior 1 에 맞게 초기화
			characterStat = characterPrefab.GetComponent<CharacterStat>();
		} else if (gameManager.nowSelect == 2) { // warriror 2가 선택
			characterPrefab = characterPrefab2; // warrior 2 에 맞게 초기화
			characterStat = characterPrefab.GetComponent<CharacterStat>();
		} else if (gameManager.nowSelect == 3) { // wizzard 1이 선택
			characterPrefab = characterPrefab3; // wizzard1 에 맞게 초기화
			characterStat = characterPrefab.GetComponent<CharacterStat>();
		} else if (gameManager.nowSelect == 4) { // wizzard 2가 선택
			characterPrefab = characterPrefab4; // wizzard2 에 맞게 초기화
>>>>>>> final
			characterStat = characterPrefab.GetComponent<CharacterStat>();
		}

		if (character == null) { // 캐릭터가 존재하지 않는 경우
		    // 다음 과 같이 초기화 하게 된다.
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
