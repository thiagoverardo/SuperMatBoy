using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using TMPro;

public class BlinkingText : MonoBehaviour
{
    private float fadeSpeed = 2f;
    TMP_Text text;
    private float count = 0f;
    void Start()
    {
        text = GetComponent<TMP_Text>();
    }
    void Update()
    {
        count += fadeSpeed * Time.deltaTime;
        text.color = new Color(text.color.r, text.color.g, text.color.b, Mathf.Sin(count) * 0.5f);
    }
}