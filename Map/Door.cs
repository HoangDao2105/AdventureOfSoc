using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class Door : MonoBehaviour
{
    public int level = 2;
    public gamemaster gm;
    // Start is called before the first frame update
    void Start()
    {
        gm = GameObject.FindGameObjectWithTag("Gamemaster").GetComponent<gamemaster>();
    }

    // Update is called once per frame
    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.CompareTag("Player"))
        {
            savescore();
            gm.PassLevelText.text = ("Press E to Enter"); 
        }
    }
    private void OnTriggerStay2D(Collider2D collider)
    {
        if (collider.CompareTag("Player"))
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                savescore();
                SceneManager.LoadScene(level);
            }
        }
    }
    private void OnTriggerExit2D(Collider2D collider)
    {
        if (collider.CompareTag("Player"))
        {
            gm.PassLevelText.text = ("");   
        }
    }
    public void savescore()
    {
        PlayerPrefs.SetInt("point", gm.point);
    }
}
