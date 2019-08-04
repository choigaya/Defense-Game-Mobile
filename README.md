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

