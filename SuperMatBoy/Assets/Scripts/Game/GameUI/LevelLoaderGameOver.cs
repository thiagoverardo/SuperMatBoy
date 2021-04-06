using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

//https://www.youtube.com/watch?v=CE9VOZivb3I&ab_channel=Brackeys   
public class LevelLoaderGameOver : MonoBehaviour
{
    public Animator transition;
    public float transitionTime = 4f;
    GameManager gm;
    void Start()
    {
        gm = GameManager.GetInstance();
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            gm.Reset();
            Invoke("LoadGame", 1f);
        }
        else if (Input.anyKeyDown)
        {
            gm.Reset();
            Invoke("LoadMenu", 1f);
        }
    }
    void LoadMenu()
    {
        StartCoroutine(LoadLevel(0));
    }

    void LoadGame()
    {
        StartCoroutine(LoadLevel(SceneManager.GetActiveScene().buildIndex - 1));
    }

    IEnumerator LoadLevel(int levelIndex)
    {
        transition.SetTrigger("Start");

        yield return new WaitForSeconds(transitionTime);

        SceneManager.LoadScene(levelIndex);
    }
}
