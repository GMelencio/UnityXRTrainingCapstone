using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class RotorInitializer : MonoBehaviour
{
    // Start is called before the first frame update
    void Awake()
    {
        /*
        var rotors = GameObject.FindGameObjectsWithTag("DroneRotor");
        foreach (var i in rotors)
        {
            Debug.Log("Setting power for rotor # " + i.name);
            i.GetComponent<rotor>().setPower(20f);
        }
        */
    }

    public float rotationSpeed = 1400f;

    private void Update()
    {
        var rotors = GameObject.FindGameObjectsWithTag("DroneRotor");
        foreach (var i in rotors)
        {
            i.transform.Rotate(0, 0, rotationSpeed * Time.deltaTime);
        }
    }
}
