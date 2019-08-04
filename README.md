# DefenseGame
DefenseGame with unity

# 소개 

![메인 png](https://user-images.githubusercontent.com/11676387/62414359-2de57a80-b655-11e9-9d26-fb7214cde3bf.jpg)


- 모바일 디펜스 게임 은 유니티 기반 으로 만들어진 안드로이드 모바일 게임 입니다.


# 설명


![image](https://user-images.githubusercontent.com/11676387/62420802-8ce9d480-b6d3-11e9-9dcf-f8260bce5d83.png)
    
   캐릭터 들은 각 타워 의 역할 을 하여 사용자가 맵 주변에 터치 를 하게 되면(빨간 원) OnMouseDown 함수 를 사용하여 사용자의 터치를 감지하여 캐릭터 들을 
   건설 할 수 있도록 합니다.TowerSpot 이 역할 을 수행 할 수 있도록 해줍니다.원 반경 범위 안에 사용자 가 캐릭터를 건설 할 수 있도록 도와줍니   
   다.CreateCharacter.cs 에는 다음 과 같은 소스코드 가 역할 을 수행합니다.


 
![image](https://user-images.githubusercontent.com/11676387/62420842-f833a680-b6d3-11e9-9c8f-24c1fe7736c1.png)

   OnMouseDown 함수는 각 캐릭터 를 선택하게 되면 캐릭터를 지정된 곳에 배치 할 수 있도록 도와 줍니다.
   
![image](https://user-images.githubusercontent.com/11676387/62420875-84de6480-b6d4-11e9-9a3f-b7d86a89c958.png)
    
몬스터는 TowerSpot 과 비슷한 원리인 Respawn Spots 가 있습니다.랜덤 값을 주어서 몬스터 가 정해진 Spots 지역에 Vector 값을 지정 해준뒤 출현 하는 로직입니다.총 4개의 구역에서 몬스터 가 출현하게 됩니다.(GameScene -> Respawn Spots) 를 참고 해보시면 자세히 볼 수 있습니다.)
   
![image](https://user-images.githubusercontent.com/11676387/62420889-c2db8880-b6d4-11e9-933f-14a5cd5e6aea.png)
   
![image](https://user-images.githubusercontent.com/11676387/62420981-e3581280-b6d5-11e9-897c-c226316b609d.png)

CreateMonser.cs 의 소스 내용 에 RespawnSpot 을 제어하는 코드 가 있습니다.
캐릭터 들은 몬스터 들로 부터 성을 지킵니다.캐릭터들은 BoxCollider 2D 를 가지고 있어서 몬스터들의 충돌 을 감지 할 수 있게 만들었습니다.몬스터 도 마찬가지로 BoxCollider 2D를 적용하여 캐릭터 와 충돌시 캐릭터의 Hp 가 감소하도록 구현 하였습니다.(역으로도 성립)충돌 할시 캐릭터,몬스터 는 서로 공격을 하게 됩니다.

![image](https://user-images.githubusercontent.com/11676387/62421006-3cc04180-b6d6-11e9-92c1-106049ab0e67.png)


여기서 캐릭터 같은 경우는 멀리서 오는 몬스터 를 발견 하게 되면 즉시 공격할수 있도록 구현 하였습니다.여기서는 다음 과 같은 기능 을 적용하였습니다.초록색 부분은 Attack Range 입니다.(유니티 에디터에서 캐릭터를 클릭해주시고,확인해주세요.(ex-Prefab->Warriror1-> Hierarchy->Warriror1->Attack Range)몬스터가 반경 범위 안(초록색 박스)에 들어오게 되면 즉시 캐릭터는 공격을 수행하게 됩니다.Find Monster.cs 코드가 그 역할 을 수행할 수 있도록 도와주며 코드의 내용은 다음과 같습니다.


![image](https://user-images.githubusercontent.com/11676387/62420997-2e722580-b6d6-11e9-8296-a1fa9ab41599.png)



OnTriggerStay2D 함수에서 충돌하는 개체 를 감지하고 그 개체 가 몬스터 라면 캐릭터의 데미지 만큼 몬스터에게 영향을 주는 것을 알 수 있습니다.디펜스게임 특성상 특정 지역을 지키는 게임이기 때문에 공격 반경을 일직선(초록색 박스)으로 구현 하였습니다.

캐릭터의 무기 또한 일직선 으로 구현하였고,충돌을 감지 하기 위해 BoxCollider 2D(isTrigger)를 똑같이 적용하게 되었습니다.(Bullet Behaviour.cs,Prefab 을(를) 참고 하여 주세요.)




