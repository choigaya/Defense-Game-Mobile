using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletBehaviour : MonoBehaviour {

	public float speed = 10.0f;
	public GameObject character;

	private int damage;

	public void setDamage(int input) { // 총알의 데미지 를 설정 해줌
		damage = input;  
	}

    void Start() {
		Destroy(gameObject,3.0f); // 3초 이상 되면 죽게 됨
    }

    void Update() {
		transform.Translate(Vector2.right * speed * Time.deltaTime);
		
    }

	private void OnTriggerEnter2D(Collider2D other) {   
		if (other.gameObject.tag == "Monster") { // 몬스터 를 향해 총알 을 발사한후
			Destroy(gameObject);  // 총알은 사라짐
			other.GetComponent<MonsterStat>().attacked(damage); // 몬스터의 damage 를 불러옴
		}
	}
}
