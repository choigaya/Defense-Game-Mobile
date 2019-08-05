using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HPBar : MonoBehaviour {

	public GameObject image;
	public GameObject character;

	public GameObject parent;
	private CharacterStat characterStat;
	private MonsterStat monsterStat;

	public float max = 100;
	public float current = 100; // HP 가 줄거나 늘어남
	private float scale; // HP 바의 크기를 계산

	private int maxHp = 100;
	private int hp = 100;

	void Start() {
		scale = image.transform.localScale.x;
		characterStat = character.GetComponent<CharacterStat>();
		if (parent.name.Contains("Character")) { // 부모 객체 의 문자열이 Character 가 포함 되어 있을 경우
			characterStat = parent.GetComponent<CharacterStat>(); // 캐릭터의 정보를 불러옴
		}
		else if (parent.name.Contains("Monster")) { // 부모 객체 의 문자열이 Monster 가 포함 되어 있을 경우 
			monsterStat = parent.GetComponent<MonsterStat>(); // 몬스터의 정보를 불러옴
		}
    }

    void Update() {
		if (characterStat != null) { 
			maxHp = characterStat.maxHp;
			hp = characterStat.hp;
		}
		else if (monsterStat != null) {
			maxHp = monsterStat.maxHp;
			hp = monsterStat.hp;
		}

		// HP bar 가 줄어드는 속도 를 지정
		current = (float)hp / (float)maxHp * 100;
		if (current <= 0) { // hp 가 0 이라면

			current = 0; // hp 가 아무것도 없게 함

		}
	    Vector2 temp = image.transform.localScale; // 이미지의 크기를 불러옴
		temp.x = current / max * scale; // HP 바의 게이지가 가로 로 줄어듦
		image.transform.localScale = temp; 		
    }
}
