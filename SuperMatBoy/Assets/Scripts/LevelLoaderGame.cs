using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

//https://www.youtube.com/watch?v=CE9VOZivb3I&ab_channel=Brackeys   
public class LevelLoaderGame : MonoBehaviour
{
    public Animator transition;
    public float transitionTime = 4f;
    void Update()
    {
        // quando chegar no final ou morrer 
        // reinicia a cena... pensar como fazer aqui
        // if (Input.anyKeyDown)
        // {
        // Invoke("LoadScene", 2f);
        // }
    }
    void LoadScene()
    {
        StartCoroutine(LoadLevel(SceneManager.GetActiveScene().buildIndex));
    }

    IEnumerator LoadLevel(int levelIndex)
    {
        transition.SetTrigger("Start");

        yield return new WaitForSeconds(transitionTime);

        SceneManager.LoadScene(levelIndex);
    }
}
