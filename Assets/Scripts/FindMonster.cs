using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FindMonster : MonoBehaviour {

	public GameObject character;
	private CharacterBehaviour characterBehaviour;
	private float coolTime;
	private float lastAttackTime;

    void Start() {
		characterBehaviour = character.GetComponent<CharacterBehaviour>();
		coolTime = character.GetComponent<CharacterStat>().coolTime;
    }

	private void OnTriggerStay2D(Collider2D other) {
		if (other.gameObject.tag == "Monster") { // 몬스터를 공격함
			if (Time.time - lastAttackTime > coolTime) {
				int damage = character.GetComponent<CharacterStat>().damage; // Character Stat 에서 damage 를 직접 불러온다.
				characterBehaviour.attack(damage);
				lastAttackTime = Time.time; // 최근에 저장 한 시간을 넣어준다.

			}
		}
	}

	void Update() {
        
    }
}
