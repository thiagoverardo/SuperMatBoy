using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetIndicator : MonoBehaviour
{
    private float hideDistance = 20f;
    GameManager gm;
    void Start()
    {
        gm = GameManager.GetInstance();
    }
    void Update()
    {
        if (!GameObject.FindGameObjectWithTag("Player"))
        {
            gameObject.GetComponentInChildren<Renderer>().enabled = false;
            return;
        }
        if (GameObject.FindGameObjectWithTag("Finish"))
        {
            Transform target = GameObject.FindGameObjectWithTag("Finish").transform;
            var dir = target.position - transform.position;
            if (dir.magnitude < hideDistance)
            {
                gameObject.GetComponentInChildren<Renderer>().enabled = false;
            }
            else
            {
                gameObject.GetComponentInChildren<Renderer>().enabled = true;
                var angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
                transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
            }
        }
    }
}
