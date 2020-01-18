using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class PlaybackSlider : MonoBehaviour
{
    public bool drag;

    GraphicRaycaster gR;

    Vector2 mPos;

    // Start is called before the first frame update
    void Start()
    {
        gR = GetComponent<GraphicRaycaster>();
    }

    // Update is called once per frame
    void Update()
    {

        if (EventSystem.current.IsPointerOverGameObject() == this.gameObject)
        {
            if (Input.GetMouseButtonDown(0))
            {
                drag = true;
            }

        }

        if(drag == true)
        {

            transform.position = new Vector2(Input.mousePosition.x, transform.position.y);

        }

        if (Input.GetMouseButtonUp(0))
        {
            drag = false;
        }



    }
    void OnMouseDrag()
    {
        
       
    }
}
