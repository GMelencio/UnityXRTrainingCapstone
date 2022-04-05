using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMarkerManager : MonoBehaviour
{
    //private GameObject AssociatedEnemy;

    public GameObject AssociatedEnemy { get; private set; }

    public void SetAssociatedEnemy(GameObject enemy)
    {
        this.AssociatedEnemy = enemy;
        //this.transform.position = enemy.transform.position;
        //this.transform.rotation = enemy.transform.rotation;
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
