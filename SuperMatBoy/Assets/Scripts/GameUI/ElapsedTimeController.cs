using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ElapsedTimeController : MonoBehaviour
{
    private string currentTime;
    GameManager gm;
    TMP_Text text;

    void Start()
    {
        gm = GameManager.GetInstance();
    }

    void Update()
    {
        text = GetComponent<TMP_Text>();
        gm.timeElapsed += Time.deltaTime;

        string minutes = Mathf.Floor(gm.timeElapsed / 60).ToString("00");
        string seconds = (gm.timeElapsed % 60).ToString("00");

        text.text = string.Format("{0}:{1}", minutes, seconds);
    }
}
