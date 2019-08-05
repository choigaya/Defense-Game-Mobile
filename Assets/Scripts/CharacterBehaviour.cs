/*

  캐릭터 정보를 불러옴
  
  * 캐릭터의 각 정보를 초기화 하고 gameManager 를 불러와서 설정 해줌

*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;


public class CharacterBehaviour : MonoBehaviour {

	private CharacterStat characterStat; // 캐릭터의 정보를 불러오기 위해 private 으로 선언 
	private GameManager gameManager; // gameManager 를 사용하기 위해 선언

	public GameObject bullet; // 총알 객체
	private Animator animator; // 애니메이션 객체
	private AudioSource audioSource; // 오디오 객체


    void Start() {
		characterStat = gameObject.GetComponent<CharacterStat>(); // 에디터 에 설정된 캐릭터 정보를 불러옴 
		gameManager = GameObject.Find("Game Manager").GetComponent<GameManager>(); // 컴포넌트 에서 Game Manager 를 가져온다.
		animator = gameObject.GetComponent<Animator>(); // 에디터 에 설정된 애니메이션을 불러옴
		audioSource = gameObject.GetComponent<AudioSource>(); // 에디터 에 설정된 음악 파일 을 불러옴 

    }

	public void attack(int damage) { // 캐릭터 의 공격 관련 함수 
		animator.SetTrigger("Attack"); // 공격 애니메이션을 실행
		audioSource.PlayOneShot(audioSource.clip); // 총알 의 소리 가 남
		GameObject currentBullet = Instantiate(bullet,transform.position,Quaternion.identity); // 자신의 위치에서 총알 object 를 생성한뒤 발사 한다.
		currentBullet.GetComponent<BulletBehaviour>().setDamage(damage); // 캐릭터의 공격 데미지를 총알데미지에 넣어줌

	}

    
    void Update() {
        
    }

	private void OnMouseDown() {
		if (EventSystem.current.IsPointerOverGameObject(-1) == true) { return; }
		if (EventSystem.current.IsPointerOverGameObject(0) == true) { return; }
		if (characterStat.canLevelUp(gameManager.seed)) { // seed 의 값을 가져온뒤 매개변수 로 전달
			characterStat.increaseLevel();
			gameManager.seed -= characterStat.upgradeCost; // 씨앗을 해당 비용만큼 차감
			gameManager.updateText();
		}
	}
}
