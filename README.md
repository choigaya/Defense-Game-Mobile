# 소개 

![메인 png](https://user-images.githubusercontent.com/11676387/62414359-2de57a80-b655-11e9-9d26-fb7214cde3bf.jpg)


- 모바일 디펜스 게임 은 유니티 기반 으로 만들어진 안드로이드 모바일 게임 입니다.

# 제작기간

- 6주 

# 버전

- Unity 2018.3

# 메인 설명


![설명(1)](https://user-images.githubusercontent.com/11676387/62472727-4f23a380-b7da-11e9-91aa-c372de7ac33e.png)

캐릭터들은 성벽을 지키는 타워 의 역할 을 수행하게 됩니다.사용자 가 맵 주변을 터치하게 되면 감지하게되어 캐릭터를 배치하게 하여 몬스터로부터 성벽을 지킬수 있게 됩니다. TowerSpot 오브젝트는 사용자가 타워를건설 할 수있도록해줍니다. TowerSpot 오브젝트는 CreateCharacter.cs 에서 제어 합니다.마우스 터치 를 할 수있는 OnMouseDown 을 사용하여 위에서 서술 했듯이 감지할 수있게 만들었습니다. 

![image](https://user-images.githubusercontent.com/11676387/62420842-f833a680-b6d3-11e9-9c8f-24c1fe7736c1.png)

   
![image](https://user-images.githubusercontent.com/11676387/62420875-84de6480-b6d4-11e9-9a3f-b7d86a89c958.png)
    
몬스터는  Respawn Spots 에서 생성됩니다.총 4개의 방향에서 랜덤으로 맵의 오른쪽 으로 출현하게됩니다.CreateMonster.cs 를 참고 하시면 TowerSpot 과 비슷 하다는 것을 알 수 있습니다.캐릭터는 몬스터 가 출현 하게 되는 방향 에 배치 시켜 성벽으로 부터 지키게 됩니다.즉,오른쪽으로 출현하는 몬스터를 성벽 주변에 캐릭터 를 배치시켜 지키는 게임입니다.다시말해 캐릭터가 몬스터를 사전에 감지 하여 제압합니다.아래의 Bullet 오브젝트 와 캐릭터 설명 을 참고해주십시오.

   
![respawn(1)](https://user-images.githubusercontent.com/11676387/62472049-e2f47000-b7d8-11e9-8662-37510714a239.png)

![respawn(2)](https://user-images.githubusercontent.com/11676387/62472029-db34cb80-b7d8-11e9-8d04-fd346c46557b.png)

![respawn(3)](https://user-images.githubusercontent.com/11676387/62472032-dcfe8f00-b7d8-11e9-90c8-1fbe4327916e.png)

![respawn(4)](https://user-images.githubusercontent.com/11676387/62472036-de2fbc00-b7d8-11e9-975e-ac0690663b37.png)


# 충돌 처리   


# 플랫폼
  
  - 안드로이드(8.0.0+)
  - PC & Linux win7 + 
 
 
# 출처 및 저작권

  - https://craftpix.net/file-licenses/
  
  - http://dig.ccmixter.org/licenses
  
  
# 개발자 정보

 - woosung827@gmail.com
 
 - https://woosungchoi.github.io/portfolio/woosung_portfolio/

 
 
 
 


