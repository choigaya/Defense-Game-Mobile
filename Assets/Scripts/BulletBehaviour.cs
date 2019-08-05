/*
   총알 관련 정보를 설정함

*/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletBehaviour : MonoBehaviour {

	public float speed = 10.0f; // 무기의 스피드를 초기화
	public GameObject character; // 무기의 개체정보를 캐릭터에 담기 위해 오브젝트 선언

	private int damage; // 데미지는 정수 값으로 선언

	public void setDamage(int input) { // 총알의 데미지 를 설정 해줌
		damage = input;    // 전달 받은 값을 총알의 데미지로 설정 됨
	}

    void Start() {
		Destroy(gameObject,3.0f); // 3초 이상 되면 죽게 됨
    }

    void Update() {
		transform.Translate(Vector2.right * speed * Time.deltaTime); // 몬스터 가 오른쪽으로 오기 때문에 Vector 를 오른 쪽 으로 설정
		
    }

	private void OnTriggerEnter2D(Collider2D other) {   
		if (other.gameObject.tag == "Monster") { // 몬스터 를 발견하게 되면 
			Destroy(gameObject);  // 총알은 사라짐
			other.GetComponent<MonsterStat>().attacked(damage); // 몬스터의 damage 를 불러옴
		}
	}
}
