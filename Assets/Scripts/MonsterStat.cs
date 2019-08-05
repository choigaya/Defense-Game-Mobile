using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterStat : MonoBehaviour {
    
    // 초기값을 설정, 에디터에서 수정 할 수있도록 public 으로 선언
	public float speed = 1.0f;
	public int damage;
	public float coolTime = 2.0f; // 몬스터의 공격속도를 처리 할 수 있도록 함
	public int hp = 20;
	public int maxHp = 20;

	public Animator animator;

    void Start() {
		animator = gameObject.GetComponent<Animator>();         
    }

	public int attacked(int damage) { // 캐릭터에게 공격을 받음
		hp = hp - damage; // 공격을 받은 만큼 hp 가 감소함 
		if (hp <= 0) { // 체력이 전부 소진 할 때
			animator.SetTrigger("Die"); // hp 가 0이 되면 죽는 애니메이션 작동
			Destroy(gameObject,1.0f);   // 해당 object를 제거 
			gameObject.GetComponent<MonsterBehaviour>().died = true; // 몬스터 가 죽었음 을 처리

		}
		return hp;
	}
	

    void Update() {
        
    }
}
