# 소개 

![메인 png](https://user-images.githubusercontent.com/11676387/62414359-2de57a80-b655-11e9-9d26-fb7214cde3bf.jpg)


- 모바일 디펜스 게임 은 유니티 기반 으로 만들어진 안드로이드 모바일 게임 입니다.캐릭터를 원하는 위치에 배치 시켜서 성벽을 지키는 게임입니다.


# 제작 기간

- 5월 ~ 7월 (2개월)

# 사용 언어

- C#,Unity 

# 버전

- Unity 2018.3

# 메인 설명


![설명(1)](https://user-images.githubusercontent.com/11676387/62472727-4f23a380-b7da-11e9-91aa-c372de7ac33e.png)

캐릭터들은 성벽을 지키는 타워의 역할 을 수행하게 됩니다. 사용자 가 맵 주변을 터치하게 되면 감지하게 되어 캐릭터를 배치하게 하여 몬스터로부터 성벽을 지킬 수 있게 됩니다. Tower Spot 오브젝트는 사용자가 타워를 건설 할 수 있도록 하여 줍니다. Tower Spot 오브젝트는 CreateCharacter.cs에서 제어합니다.터치를 할 수 있는 OnMouseDown 을 사용하여 위에서 서술했듯이 감지할 수 있게 만들었습니다.

![image](https://user-images.githubusercontent.com/11676387/62420842-f833a680-b6d3-11e9-9c8f-24c1fe7736c1.png)

   
![image](https://user-images.githubusercontent.com/11676387/62420875-84de6480-b6d4-11e9-9a3f-b7d86a89c958.png)
    
몬스터는 Respawn Spots에서 생성됩니다. 총 4개의 방향에서 랜덤으로 맵의 오른쪽으로 출현하게됩니다.CreateMonster.cs를 참고하시면 Tower Spot 과 비슷하다는 것을 알 수 있습니다. 캐릭터는 몬스터가 출현하게 되는 방향에 배치 해 성벽으로부터 지키게 됩니다. 즉, 오른쪽으로 출현하는 몬스터를 성벽 주변에 캐릭터를 배치해 지키는 게임입니다. 다시말해 캐릭터가 몬스터를 사전에 감지하여 제압합니다. 아래의 Bullet 오브젝트와 캐릭터 설명을 참고해주십시오.

   
![1_1_respawn(1)](https://user-images.githubusercontent.com/11676387/62481145-93b83a80-b7ec-11e9-9272-aa003bf052f4.png)
![1_respawn(2)](https://user-images.githubusercontent.com/11676387/62480969-2ad0c280-b7ec-11e9-8956-0b0c297b015b.png)
![1_respawn(3)](https://user-images.githubusercontent.com/11676387/62480970-2b695900-b7ec-11e9-9665-4954f4539e82.png)
![1_respawn(4)](https://user-images.githubusercontent.com/11676387/62480971-2b695900-b7ec-11e9-8503-cff12b1dd2b6.png)


# 충돌 처리   


![충돌처리](https://user-images.githubusercontent.com/11676387/62475842-df64e700-b7e0-11e9-8548-c0a54ac2425c.png)



디펜스 게임은 캐릭터는 움직이지 않고 성벽 주변에 배치되어 몬스터로부터 지키는 게임입니다. 결국 서로 충돌이 일어날 수 밖에 없습니다. 따라서 캐릭터와 몬스터들은 Box Collider 2D 방식을 사용합니다. 몬스터가 오른쪽으로 출현하여 캐릭터를 감지하였을 때 공격을 시도합니다. 그 때 충돌이 일어나고, 충돌시 밀려나거나 튕기지 않게 하기 위해 캐릭터, 몬스터 에게 is Trigger 를 설정, 몬스터는 걸어 온 뒤 캐릭터를 감지하여 충돌하므로, Rigidbody 를 사용하여 중력의 영향을 주지 않게 하였습니다. 성벽 오브젝트(Fence) 또한 Box Collider 2D로 설정, 몬스터가 충돌하는 것을 감지합니다.


![몬스터정보(1)](https://user-images.githubusercontent.com/11676387/62474944-f60a3e80-b7de-11e9-96f3-43dfaff04485.png)

<몬스터 정보>

![캐릭터정보(1)](https://user-images.githubusercontent.com/11676387/62475136-6913b500-b7df-11e9-8903-cefbe2321612.png)

<캐릭터 정보>


# 공격 처리

![캐릭터 충돌처리(2)](https://user-images.githubusercontent.com/11676387/62476630-5cdd2700-b7e2-11e9-8d09-8402ac6004a6.png)

앞서 언급 드린 것 과같이 캐릭터는 성벽 주변을 지키는 타워 역할입니다. 몬스터는 오른쪽에서 왼쪽으로 캐릭터를 향할 걸어 온 뒤 공격하게 됩니다. 성벽으로 부터 일정 거리를 두고 캐릭터가 사전에 몬스터를 감지할 필요가 있습니다. 그 때 처리 해주는 것이 Attack Range 오브젝트입니다. 캐릭터에 장착되어있으며 사정거리 범위에 몬스터를 감지하여 사전에 공격하여 성벽을 방어하게 됩니다. Box Collider 2D를 이용해 감지하게 됩니다.FindMonster.cs를 참고해 주십시오.


![몬스터 공격 처리](https://user-images.githubusercontent.com/11676387/62477002-0b816780-b7e3-11e9-981f-1e0d71358d29.png)


다음은 몬스터 처리입니다. 사실 몬스터는 성벽을 향해 걸어간 뒤 앞에 캐릭터가 보이면 공격하는 구조 이기 때문에 캐릭터처럼 Attack Range 오브젝트가 필요 없습니다. 캐릭터를 Collider으로 감지하여 공격하는 것이 전부입니다. 몬스터는 항상 오른쪽에서 왼쪽으로 출현합니다.



# 애니메이션 처리


캐릭터의 애니메이션 처리는 Attack, Idle, Die 로 구성, 몬스터를 감지하지 않을 때는 Idle, 공격은 Attack, 죽는 것은 Die로 처리했습니다.


![캐릭터애니메이션](https://user-images.githubusercontent.com/11676387/62477728-84cd8a00-b7e4-11e9-8b29-6052da4521ef.png)

<캐릭터 애니메이션>


![몬스터애니메이션](https://user-images.githubusercontent.com/11676387/62477815-bd6d6380-b7e4-11e9-9378-fb58b1ac9e7c.png)

<몬스터 애니메이션>


# 플랫폼
  
  - 안드로이드(8.0.0+)
  - PC & Linux win7 + 
 
 
# 출처 및 저작권

  - https://craftpix.net/file-licenses/
  
  - http://dig.ccmixter.org/licenses
  
  
# 샘플 파일 

- 안드로이드 apk 파일 

- https://drive.google.com/drive/u/1/folders/1HxuuZsnomRSpCnNNLplYDg39gI7mfyaF

  
  


 
 
 
 


