using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class TilemapRepositioner : MonoBehaviour
{
		
    void OnTriggerExit2D(Collider2D collision) {
        // is trigger가 체크되어있는 콜라이더에서 나갔을 때 발생하는 이벤트
        
        // Area랑 충돌해서 벗어났을 때 ! 에만 로직이 동작하게 해야함
        if (!collision.CompareTag("Area"))
            return;
        
        // 어느 축으로 거리가 멀어진 건지 판단해야함
        Vector3 myPos = transform.position;
        Vector3 playerPos = GameManager.instance.player.transform.position;
        float diffX = math.abs(playerPos.x - myPos.x);
        float diffY = math.abs(playerPos.y - myPos.y);			
        
        // normalized가 있을 때만 아래 로직 작성 (플레이어가 보는 방향 판단)
        Vector3 playerDir = GameManager.instance.player.getInputVec();
        float dirX = playerDir.x < 0 ? -1 : 1;
        float dirY = playerDir.y < 0 ? -1 : 1;
        
        switch (transform.tag) {
            case "Ground":
                if (diffX > diffY) {
                    // 지정된 값 만큼 현재 위치에서 이동 (방향 * 크기)
                    transform.Translate(Vector3.right * dirX * 40);
                } else if (diffX < diffY) {
                    transform.Translate(Vector3.up * dirY * 40);
                }
                break;
            case "Enemy":
                break;
        }
    }
    
    void Update()
    {
    }
}