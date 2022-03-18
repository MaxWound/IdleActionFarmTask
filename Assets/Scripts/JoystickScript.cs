using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;


public class JoystickScript : MonoBehaviour ,IPointerDownHandler
// Start is called before the first frame update
{
    public GameObject joystick;
    private void Start()
    {
        joystick.SetActive(false);
    }
    public void OnPointerDown(PointerEventData eventData)
    {
        joystick.transform.position = eventData.position;
        joystick.SetActive(true);
    }
    
}
 

