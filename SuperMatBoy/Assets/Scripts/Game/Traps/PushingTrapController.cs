using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PushingTrapController : MonoBehaviour
{
    private Animator anim;
    void Start()
    {
        anim = GetComponent<Animator>();
    }
    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.CompareTag("Player"))
        {
            GameObject player = GameObject.FindWithTag("Player");
            anim.SetTrigger("push");
        }
    }
}
