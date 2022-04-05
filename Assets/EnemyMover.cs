using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;
using UnityEngine.XR.Interaction.Toolkit;
using UnityEngine.SpatialTracking;

public class PlayerManager : MonoBehaviour
{
    public GameObject XRRigParent;
    public GameObject GroundUnitSpawn;
    public GameObject GroundVehicle;

    public GameObject AirUnitSpawn;
    public GameObject AirVehicle;

    public GameObject CICUnitSpawn;
    public GameObject CICVehicle;

    public void SpawnAsGroundUnit()
    {
        AssignSpawnPosition(GroundUnitSpawn, GroundVehicle);
    }

    public void AssignSpawnPosition(GameObject spawnPoint, GameObject vehicle)
    {
        vehicle.SetActive(true);
        XRRigParent.transform.position = spawnPoint.transform.position;
        XRRigParent.transform.rotation = spawnPoint.transform.rotation;
    }

}
