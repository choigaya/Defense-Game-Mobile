# DefenseGame
DefenseGame with unity

# 소개 

![메인 png](https://user-images.githubusercontent.com/11676387/62414359-2de57a80-b655-11e9-9d26-fb7214cde3bf.jpg)


- 모바일 디펜스 게임 은 유니티 기반 으로 만들어진 안드로이드 모바일 게임 입니다.


# 메인 설명


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


# 캐릭터 및 몬스터 설명

캐릭터들은 총 4가지 로 구성되어 있으며 유니티 에디터 에서 기본적으로 설정 할 수 있도록  public 으로 선언 되어있습니다.

![image](https://user-images.githubusercontent.com/11676387/62421022-8d379f00-b6d6-11e9-86d5-5ee9336abe43.png)

에디터의 내용은 다음과 같습니다.

*기본 초기 값은 다음과 같으며 에디터 내에서 수정하게 되면 게임에 에디터에서 수정한 값이 소스코드에서 설정한 초기값보다 우선순위 가 높기 때문에 에디터에서 수정한 값이 적용됩니다.



![image](https://user-images.githubusercontent.com/11676387/62421038-b9532000-b6d6-11e9-9d8f-245a6a739a79.png)

<사진 1.여전사 캐릭터 정보>


몬스터도 마찬가지로 public 으로 선언 됩니다.다만 몬스터는 성을  공격하기 위한 목적과 움직이며 캐릭터를 없애는 목적이므로 일직선으로 BoxCollider 를 구현 할 필요가 없어 제외시켰습니다.

![image](https://user-images.githubusercontent.com/11676387/62421048-d25bd100-b6d6-11e9-8e1a-c7e1a6314513.png)


![image](https://user-images.githubusercontent.com/11676387/62421050-db4ca280-b6d6-11e9-8da2-7e0cc1d7288d.png)


<사진 2 Troll Monster 1 >


또한 몬스터 Rigidbody 2D를 적용하였는데 Kinematic 으로 바디타입 을 설정하여 중력의 영향을 주지 않게 설정하였습니다.Object 끼리 밀려나지 않게 하기 위하여 설정 하였습니다.충돌처리 코드는 다음과 같습니다.

![image](https://user-images.githubusercontent.com/11676387/62421060-eacbeb80-b6d6-11e9-94ee-dbd14a03ef7b.png)


<사진 3 Monster 의 정보>



![image](https://user-images.githubusercontent.com/11676387/62421069-f9b29e00-b6d6-11e9-8e59-35cc7f5656af.png)






