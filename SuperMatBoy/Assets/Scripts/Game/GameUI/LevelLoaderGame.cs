using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

//https://www.youtube.com/watch?v=CE9VOZivb3I&ab_channel=Brackeys   
public class LevelLoaderGame : MonoBehaviour
{
    public Animator transition;
    public AudioClip sfxPlay;
    public float transitionTime = 4f;
    GameManager gm;
    void Start()
    {
        gm = GameManager.GetInstance();
    }
    void Update()
    {
        if (gm.levelPassed)
        {
            gm.levelPassed = false;
            AudioManager.PlaySFX(sfxPlay);
            Invoke("ReloadGame", 1f);
        }
        if (gm.lifes <= 0)
        {
            Invoke("LoadGameOverScene", 1f);
        }
        if(gm.died)
        {
            Invoke("ReloadGame", 1f);
            gm.died = false;
        }

    }
    void ReloadGame()
    {
        StartCoroutine(LoadLevel(SceneManager.GetActiveScene().buildIndex));
    }

    void LoadGameOverScene()
    {
        StartCoroutine(LoadLevel(SceneManager.GetActiveScene().buildIndex + 1));
    }

    IEnumerator LoadLevel(int levelIndex)
    {
        transition.SetTrigger("Start");

        yield return new WaitForSeconds(transitionTime);

        SceneManager.LoadScene(levelIndex);
    }
}
