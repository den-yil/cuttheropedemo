using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Target : MonoBehaviour
{
    public GameObject bravoText;
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.collider.tag == "Candy")
        {
            bravoText.SetActive(true);
            Invoke("NextLevel", 2f);
        }
    }

    public void NextLevel()
    {
        if(SceneManager.GetActiveScene().buildIndex != 5)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
        else
        {
            SceneManager.LoadScene(0);
        }
        
    }
}
