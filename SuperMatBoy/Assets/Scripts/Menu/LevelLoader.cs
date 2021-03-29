using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

//https://www.youtube.com/watch?v=CE9VOZivb3I&ab_channel=Brackeys   
public class LevelLoader : MonoBehaviour
{

    public AudioClip sfxPlay;
    public Animator transition;
    public float transitionTime = 4f;
    void Update()
    {
        if (Input.anyKeyDown)
        {
            AudioManager.PlaySFX(sfxPlay);
            Invoke("LoadScene", 2f);
        }
    }
    void LoadScene()
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
