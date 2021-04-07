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
    public AudioClip music;
    void Start()
    {
        gm = GameManager.GetInstance();
        AudioManager.SetAmbience(music);
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
        if(gm.flagsCaptured >=  1)
        {
            Invoke("LoadFinalBoss", 1f);
            gm.bossTime = true;
            gm.flagsCaptured = 0;
        }
        if(gm.win){
            Invoke("LoadGameOverScene", 1f);
        }

    }
    void ReloadGame()
    {
        StartCoroutine(LoadLevel(SceneManager.GetActiveScene().buildIndex));
    }

    void LoadGameOverScene()
    {
        StartCoroutine(LoadLevel(2));
    }

    void LoadFinalBoss()
    {
        StartCoroutine(LoadLevel(3));
    }

    IEnumerator LoadLevel(int levelIndex)
    {
        transition.SetTrigger("Start");

        yield return new WaitForSeconds(transitionTime);

        SceneManager.LoadScene(levelIndex);
    }
}
