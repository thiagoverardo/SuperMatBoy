using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyObject : MonoBehaviour
{

    // Update is called once per frame
    public void destroyThis()
    {
        Destroy(gameObject, 2f);
    }
}
