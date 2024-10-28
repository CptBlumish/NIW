using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    // instance fields
    [SerializeField] private GameObject Slime_Enemy;


    // Start is called before the first frame update
    void Start()
    {




    }

    // Update is called once per frame
    void Update()
    {

    }

    IEnumerator EnemySpawn()
    {
        // iteration, repetition, loop
        // while loop
        // boolean loop
        // repeats while test is true
        //while(true) // endless loop

        {
            Instantiate(Slime_Enemy, new Vector3(Random.Range(-8.5f, 8.5f), 6.5f, 0),
            Quaternion.identity);

            yield return new WaitForSeconds(Random.Range(3.0f, 5.0f));

            // f(g(h(x)) composite functions
        }
    }

    public void StartSpawn()
    {
        StartCoroutine(EnemySpawn());

    }

}