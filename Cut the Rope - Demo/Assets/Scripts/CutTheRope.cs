using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CutTheRope : MonoBehaviour
{
    public Camera cam;
    public GameObject candy, goUI;

    void Start()
    {
        cam = GameObject.Find("Main Camera").GetComponent<Camera>();
    }
    void Update()
    {
        //ekran dışına çıkmama
        float x = Mathf.Clamp(candy.transform.position.x, (float)-2.6, (float)2.6);
        candy.transform.position = new Vector3(x, candy.transform.position.y, candy.transform.position.z);

        if (Input.GetMouseButton(0))
        {
            //mouse poziyonuna ulaşma
            RaycastHit2D raycastHit = Physics2D.Raycast(cam.ScreenToWorldPoint(Input.mousePosition),Vector2.zero);
            
            //ipi yok etme
            if (raycastHit.collider != null)
            {
                if(raycastHit.collider.tag == "Rope")
                {
                    Destroy(raycastHit.collider.gameObject);
                }
            }
        }

        //ipe dokunarak yok olmasını sağlama
        if(Input.touchCount > 0)
        {
            Touch finger = Input.GetTouch(0);
            RaycastHit2D rope = Physics2D.Raycast(cam.WorldToScreenPoint(finger.position), Vector2.zero);

            if(rope.collider != null)
            {
                if(rope.collider.tag == "Rope")
                {
                    Destroy(rope.collider.gameObject);
                }
            }
        }

        if(candy.transform.position.y < -4)
        {            
            Invoke("Again", 1f);
        }
    }

    public void Again()
    {
        goUI.SetActive(true);
    }
}
