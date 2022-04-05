using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitTypeManager : MonoBehaviour
{
    public GameObject PlayerXRRig;

    public void AssignAsUnit(GameObject unitType)
    {
        PlayerXRRig.transform.position = unitType.transform.position;
        PlayerXRRig.transform.rotation = unitType.transform.rotation;
    }
}
