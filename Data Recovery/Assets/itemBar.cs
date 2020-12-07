using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class itemBar : MonoBehaviour {

    

    float speed = 1;
    bool mouseTime = false;
    public bool mouseLow = false;
    public dragScript dragScript;
    public GameObject item;
    void Start () {

        transform.position = new Vector3(0.0f, -5.35f, 0f);
        
    }

    //  private void OnMouseOver()
    // {
    //     if (transform.position.y <= -4.5f)
    //     {
    //         transform.Translate(Vector3.up * Time.deltaTime * 4, Space.World);
    //         mouseTime = true;
    //     } 
    //     
    // }
    // private void OnMouseExit()
    // {
    //      mouseTime = false;
    // }
    //-4.2752
    // .07248
    void Update()
    {
        if (Input.mousePosition.y <= Screen.height * .1)
        {
            mouseLow = true;
            if (transform.position.y <= -4.5f)
            {
                transform.Translate(Vector3.up * Time.deltaTime * 4, Space.World);
            }
        }
        else if (transform.position.y > -5.35f)
        {
            transform.Translate(Vector3.down * Time.deltaTime * 4, Space.World);
            
        }
        if (Input.mousePosition.y > Screen.height*.1)
        {
            mouseLow = false;
        }
        
    }
    void OnTriggerStay2D(Collider2D collision)
    {
        
        if (collision.gameObject.tag == "Item" && mouseLow)
        {
            
            dragScript = collision.gameObject.GetComponent<dragScript>();
            dragScript.tiny = true;
        }
    }
    void OnTriggerExit2D(Collider2D collision2)
    {
       if (collision2.gameObject.tag == "Item")
        {
            dragScript = collision2.gameObject.GetComponent<dragScript>();
            dragScript.exit = true;
                // dragScript.tiny = false;
        }
    }

}
