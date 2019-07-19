using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class CharacterBehaviour : MonoBehaviour {

	private CharacterStat characterStat;
	private GameManager gameManager;

	public GameObject bullet;
	private Animator animator;
	private AudioSource audioSource;


    void Start() {
		characterStat = gameObject.GetComponent<CharacterStat>(); 
		gameManager = GameObject.Find("Game Manager").GetComponent<GameManager>(); // 컴포넌트 에서 Game Manager 를 가져온다.
		animator = gameObject.GetComponent<Animator>();
		audioSource = gameObject.GetComponent<AudioSource>();

    }

	public void attack(int damage) {
		animator.SetTrigger("Attack");
		audioSource.PlayOneShot(audioSource.clip);
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
