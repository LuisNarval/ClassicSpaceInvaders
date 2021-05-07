using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TouchInputSystem : MonoBehaviour
{
    public ShootingSystem shootingSystem;
    
    void Update()
    {

#if UNITY_EDITOR
        EventManager.TriggerEvent("InputMovement", Input.GetAxisRaw("Horizontal"));



#elif UNITY_ANDROID
        Touch touch = Input.GetTouch(0);
        if (Input.touchCount > 0)
        {
            if (touch.position.y > Screen.height / 2)
                shootingSystem.Shoot();
            else
                EventManager.TriggerEvent("InputMovement", touch.position.x > Screen.width / 2f ? 1 : -1);
        }
        else
        {
            EventManager.TriggerEvent("InputMovement", 0);
        }
        
        
        
#endif



    }
}
