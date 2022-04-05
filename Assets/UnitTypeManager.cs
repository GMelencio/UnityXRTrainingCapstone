using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitTypeManager : MonoBehaviour
{
    public Transform GroundUnitSpawn;
    public GameObject PlayerXRRig;

    public void AssignAsGroundUnit()
    {
        PlayerXRRig.transform.position = GroundUnitSpawn.position;
        PlayerXRRig.transform.rotation = GroundUnitSpawn.rotation;
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
