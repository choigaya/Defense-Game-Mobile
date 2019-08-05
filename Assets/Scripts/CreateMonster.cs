/*
   몬스터를 생성하는 코드

   * RespawnSpot 으로 제어 총 4개의 방향으로 몬스터가 출현 하도록 구현
   
*/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateMonster : MonoBehaviour {

	private GameManager gameManager;
	// 몬스터는 총 4개의 구역에 출현 하므로 respawnSpot 을 4개 선언
	public GameObject respawnSpot1;
	public GameObject respawnSpot2;
	public GameObject respawnSpot3;
	public GameObject respawnSpot4;

	// 몬스터는 총 5마리 로 구성됨
	public GameObject monster1Prefab;
	public GameObject monster2Prefab;
	public GameObject monster3Prefab;
	public GameObject monster4Prefab;
	public GameObject monster5Prefab;

	private GameObject monsterPrefab;

	private float lastSpawnTime; // 몬스터 들이 나오는 시간
	private int spawnCount = 0;

    
	void Start() {
		gameManager = GameObject.Find("Game Manager").GetComponent<GameManager>();
		monsterPrefab = monster1Prefab; // 초기에는 TrollMonster 1 이 출현
		lastSpawnTime = Time.time;

    }

    void Update() {
		if (gameManager.round <= gameManager.totalRound) { // 게임 이 완료 되기 전까지
			float timeGap = Time.time - lastSpawnTime;
			if (( ( spawnCount == 0 && timeGap > gameManager.roundReadyTime ) // 새 라운드가 시작 
				 || timeGap > gameManager.spawnTime ) 
				 && spawnCount < gameManager.spawnNumber) {

				lastSpawnTime = Time.time;
				int respawnSpotNumber = Random.Range(1,5); // (1 ~ n - 1) 까지 의 숫자를 랜덤으로 숫자 를 돌린다.

				GameObject respawnSpot = null;

				// 몬스터 가 출현 되는 구역 에 관한 로직
				// 총 4개의 방향에서 출현함.
				if (respawnSpotNumber == 1) {
					respawnSpot = respawnSpot1;
				}
				if (respawnSpotNumber == 2) {
					respawnSpot = respawnSpot2;
				}
				if (respawnSpotNumber == 3) {
					respawnSpot = respawnSpot3;
				}
				if (respawnSpotNumber == 4) {
					respawnSpot = respawnSpot4;
				}
				Instantiate(monsterPrefab,respawnSpot.transform.position,Quaternion.identity); // 랜덤으로 숫자를 돌린곳에 몬스터를 배치 시킴
				spawnCount += 1;
			}
			if (spawnCount == gameManager.spawnNumber &&
				GameObject.FindGameObjectWithTag("Monster") == null) { // 몬스터의 태그를 가지고 온 뒤 몬스터 가 남아있지 않는 경우

				if (gameManager.totalRound == gameManager.round) { // 게임 라운드 를 모두 마쳤을경우
					gameManager.gameClear(); // 승리의 문구 를 출력
					gameManager.round += 1;
					return;
				}
				gameManager.clearRound();
				spawnCount = 0;
				lastSpawnTime = Time.time; // 나오는 시간 을 현재시간 으로 불러옴


				// 라운드 별로 캐릭터 들의 정보 가 다름.(에디터에서 수정 할 수있음)
				if (gameManager.round == 4) {
					monsterPrefab = monster2Prefab;
					gameManager.spawnTime = 2.0f;
					gameManager.spawnNumber = 10;
				}
				else if (gameManager.round == 6) {
					monsterPrefab = monster3Prefab;
					gameManager.spawnTime = 2.0f;
					gameManager.spawnNumber = 10;
				}
				else if (gameManager.round == 8) {
					monsterPrefab = monster4Prefab;
					gameManager.spawnTime = 2.0f;
					gameManager.spawnNumber = 10;
				}
				else if (gameManager.round == 10) {
					monsterPrefab = monster5Prefab;
					gameManager.spawnTime = 2.0f;
					gameManager.spawnNumber = 10;
				}
			}
		}         
    }
}
