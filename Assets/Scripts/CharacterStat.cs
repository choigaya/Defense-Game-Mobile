using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterStat : MonoBehaviour {

	public int level = 1; // 캐릭터의 레벨
	public int hp = 30; // 현재 체력 값
	public int maxHp = 30; // 최대 체력
	public int damage = 5; // 캐릭터의 공격력
	public int cost = 130; // 캐릭터 설치 비용
	public int upgradeCost = 200; // 캐릭터 업그레이드 비용
	public float coolTime = 2.0f; // 2초에 한번 씩 공격할 수 있도록 설정



	private Animator animator;

	public int attacked(int damage) {
		hp = hp - damage;
		if (hp <= 0) {
			animator.SetTrigger("Die");
			Destroy(gameObject,1.5f); // 1.5 초 뒤에 자신의 오브젝트를 삭제한다.
			gameObject.GetComponent<BoxCollider2D>().enabled = false; // 충돌 처리 를 삭제한다.몬스터 가 캐릭터를 밟고 지나간다.
		}

		return hp;
	}

	public bool canCreate(int seed) { // seed 값 에 따라 타워를 건설할 수 있을지 확인 한다.
		if (cost <= seed) {
			return true;
		}
		return false;
	}

	public bool canLevelUp(int seed) { // 레벨 업 가능 여부 를 확인
		if (level < 3) {
			if (upgradeCost <= seed) {
				return true;
			}
			return false;
		}
		else {
			return false;   
		}

	}

	public void increaseLevel() { // 레벨 업을 수행 하는 함수
		if (level == 1) {
			level = 2;
			maxHp += 25; // 체력을 채워줌
			hp = maxHp;
			damage += 5; // 공격력을 높여줌
			transform.localScale += new Vector3(0.01f,0.01f,0); // 위치를 지정해줌
		}
		else if (level == 2) {
			level = 3;
			maxHp += 50; 
			hp = maxHp;
			damage += 5; 
			transform.localScale += new Vector3(0.01f,0.01f,0);
		}
	}


    void Start() {
		animator = gameObject.GetComponent<Animator>(); // start 함수를 실행시킨뒤 컴포넌트 에서 animator 를 가져옴
	}


    void Update() {
        
    }
}
