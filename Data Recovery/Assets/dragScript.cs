using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class dragScript : MonoBehaviour {
    private Vector3 screenPoint;
    private Vector3 offset;

    Animator anim;
    bool frontSide = true;
    float clickCounter = 0;
    bool counting = false;
    public bool tiny;
    public bool exit;
    bool wasTiny = false;
    
    void Start()
    {
        anim = GetComponent<Animator>();
    }
    
    void OnMouseDown()
    {
        offset = gameObject.transform.position - Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, screenPoint.z));
    }
  
   
    void OnMouseDrag()
    {
        clickCounter += Time.deltaTime;
        Vector3 curScreenPoint = new Vector3(Input.mousePosition.x, Input.mousePosition.y, screenPoint.z);
        Vector3 curPosition = Camera.main.ScreenToWorldPoint(curScreenPoint) + offset;
        if (tiny)
        {
            transform.position = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, screenPoint.z + 10));
            wasTiny = true;
        } else if (wasTiny)
        {
            transform.position = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, screenPoint.z + 10));
        }
        else
        {
            transform.position = curPosition;
        }
        
        
    }
    void OnMouseUp()
    {
        wasTiny = false;
        if (clickCounter <= .12f)
        {
            if (frontSide)
            {
                frontSide = false;
            }
            else
            {
                frontSide = true;
            }
        }
        clickCounter = 0;
    }
    private void Update()
    {
        anim.SetBool("Front", frontSide);
        anim.SetBool("Tiny", tiny);

        Vector2 S = gameObject.GetComponent<SpriteRenderer>().sprite.bounds.size;
        gameObject.GetComponent<BoxCollider2D>().size = S;

        if (Input.mousePosition.y > Screen.height * .1 && exit)
        {
            tiny = false;
            exit = false;
        }
    }
    
}
