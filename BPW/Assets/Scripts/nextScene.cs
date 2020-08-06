using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class nextScene : MonoBehaviour
{
    private int nextSceneToLoad;
    public GameObject winScreen;

    public static int playerreach;

    void Start()
    {
        playerreach = 0;
        nextSceneToLoad = SceneManager.GetActiveScene().buildIndex + 1; 
    }

    private void Update()
    {
        Debug.Log(playerreach);
        if(playerreach == 2)
        {
            playerreach = 0;
            StartCoroutine(WaitForNextLevel());
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player1")
        {
            playerreach = playerreach + 1;
        }

        if(other.gameObject.tag == "Player2")
        {
            playerreach = playerreach + 1; 
        }
    }

    IEnumerator WaitForNextLevel()
    {
        winScreen.SetActive(true);
        yield return new WaitForSeconds(1.5f);
        SceneManager.LoadScene(nextSceneToLoad);
    }
}
