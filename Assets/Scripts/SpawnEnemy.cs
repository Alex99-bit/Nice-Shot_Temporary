using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnEnemy : MonoBehaviour
{
    public GameObject enemy;
    public float seg;
    TypeOf spawnType;
    Rigidbody2D rigidSpawn;
    bool cambioLado;
    public float speed;
    int i;

    // Start is called before the first frame update
    void Start()
    {
        i = 0;
        rigidSpawn = GetComponent<Rigidbody2D>();
        cambioLado = false;

        if(spawnType == TypeOf.typeA)
        {
            seg = 4;
        }
        else if(spawnType == TypeOf.typeB)
        {
            seg = 6
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator spawnEnemys()
    {
        while (true)
        {
            yield return new WaitForSeconds(seg);

        }
    }
}

public enum TypeOf
{
    typeA,
    typeB
}
