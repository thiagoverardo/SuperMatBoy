
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    public AudioClip sfxPlay;
    void Update()
    {
        if (Input.anyKeyDown)
        {
            AudioManager.PlaySFX(sfxPlay);
            Invoke("LoadScene", 0.5f);
        }
    }
    void LoadScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}

