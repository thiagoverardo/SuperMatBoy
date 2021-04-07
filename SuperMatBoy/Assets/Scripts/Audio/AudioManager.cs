using UnityEngine;
public class AudioManager : MonoBehaviour
{
    [SerializeField]
    private AudioSource sfxSource;
    [SerializeField]
    private AudioSource ambienceSource;
    [SerializeField]
    private AudioClip music;
    GameManager gm;
    private static AudioManager _instance;
    void Start()
    {
        gm = GameManager.GetInstance();
    }
    void Awake()
    {
        DontDestroyOnLoad(transform.gameObject);
        _instance = this;
        if (music)
        {
            ambienceSource.loop = true;
            ambienceSource.clip = music;
            ambienceSource.Play();
        }
    }

    public static AudioManager GetInstance()
    {
        if (_instance == null)
        {
            _instance = new AudioManager();
        }

        return _instance;
    }

    public static void PlaySFX(AudioClip audioClip)
    {
        _instance.sfxSource.PlayOneShot(audioClip);
    }
    public static void SetAmbience(AudioClip audioClip)
    {
        _instance.ambienceSource.Stop();
        _instance.ambienceSource.clip = audioClip;
        _instance.ambienceSource.Play();
    }
}