using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterBehaviour : MonoBehaviour {

	private MonsterStat monsterStat;
	private Animator animator;
	private bool attacking = false; 

	private float lastAttackTime;
	private CharacterStat targetStat;
	private GameManager gameManager;

	public bool died = false; // 몬스터가 죽었는 지에 대한 여부 확인

	void Start() {
		AudioSource audioSource = gameObject.GetComponent<AudioSource>();
		audioSource.PlayOneShot(audioSource.clip);
		animator = gameObject.GetComponent<Animator>();
		monsterStat = gameObject.GetComponent<MonsterStat>();
		gameManager = GameObject.Find("Game Manager").GetComponent<GameManager>();
	}

	void Update() {
		if (died) { // 죽어있는 상태 라면
			attacking = false; // 현재 공격을 중단
			gameObject.GetComponent<BoxCollider2D>().enabled = false;
		}
		else {
			transform.Translate(Vector2.left * monsterStat.speed * Time.deltaTime); // 1초에 1.0f 의 속도 로 왼쪽으로 움직인다.
			if (attacking) {
				transform.Translate(Vector2.right * monsterStat.speed * Time.deltaTime); // 몬스터 가 제자리 에 멈춰서 공격 할 수 있음
			}
			if (targetStat != null && targetStat.hp <= 0) { // 캐릭터 가 없거나 죽은 경우
				targetStat = null; // 타겟 팅 하는 캐릭터 가 없다고 설정
				attacking = false; // 공격을 중단
				animator.SetTrigger("Walk"); // 걸어가는 상황으로 설정
			}
		}
	}

	private void OnTriggerEnter2D(Collider2D other) {
		if (other.gameObject.name == "Fence") { // 충돌한 객체 가 Fence 일 경우 
			Destroy(gameObject);
			gameManager.decreaseLife();
		}
		else if (other.gameObject.tag == "Character") { // 충돌한 객체 가 Character 일 경우
			attacking = true;
			lastAttackTime = Time.time;
			animator.SetTrigger("Attack");
			targetStat = other.gameObject.GetComponent<CharacterStat>();
		}
	}

	private void OnTriggerStay2D(Collider2D other) { // 충돌이 반복적으로 발생할 경우
		if (other.gameObject.tag == "Character") {
			if (Time.time - lastAttackTime > monsterStat.coolTime) { // 가장 최근에 공격한 시간 이 정해놓은 coolTime 보다 길 경우 
			
				int hp = other.gameObject.GetComponent<CharacterStat>().attacked(monsterStat.damage); // 스크립트 내에 있는 attacked 를 호출
				if (hp <= 0) {
					attacking = false; // 캐릭터를 죽인후 앞으로 갈 수 있도록 설정
					animator.SetTrigger("Walk");
				}
				lastAttackTime = Time.time;
			}  
		}

	}
}
