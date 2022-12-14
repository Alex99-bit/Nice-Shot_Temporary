using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyBullet : MonoBehaviour
{
    public float destroySeg;

    // Start is called before the first frame update
    void Start()
    {
        if (destroySeg == 0)
            destroySeg = 2.5f;

        Destroy(gameObject, destroySeg);
    }
}
