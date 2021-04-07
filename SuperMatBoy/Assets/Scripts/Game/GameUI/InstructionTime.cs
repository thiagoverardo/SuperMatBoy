using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class InstructionTime : MonoBehaviour
{
    GameManager gm;
    TMP_Text text;
    

    void Start()
    {
        gm = GameManager.GetInstance();
    }

    void Update()
    {
        text = GetComponent<TMP_Text>();

        if(gm.timeElapsed > 8){
            Destroy(text);
        }
    }
}
