using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Photon.Pun;
using Photon.Realtime;
using UnityEngine.XR.Interaction.Toolkit;
using UnityEngine.SpatialTracking;

public class XRNetworkManager : MonoBehaviourPunCallbacks
{
    public GameObject XRRigPrefab;
    public Vector3 XRRigSpawnPosition;
    public Canvas UI;

    // Start is called before the first frame update
    void Start()
    {
        PhotonNetwork.ConnectUsingSettings();
    }

    public override void OnConnectedToMaster()
    {
        PhotonNetwork.JoinRoom("defaultRoom");
    }

    public override void OnJoinedRoom()
    {
        Debug.Log("I got to join the room!");
        var myRig = PhotonNetwork.Instantiate(XRRigPrefab.name, XRRigSpawnPosition, Quaternion.identity);
        //UI.worldCamera = myRig.GetComponentInChildren<Camera>();

        ConfigurablePlayerComponent myComponents = myRig.GetComponent<ConfigurablePlayerComponent>();
        myComponents.mainCamera.enabled = true;
        myComponents.rig.enabled = true;
        myComponents.listener.enabled = true;
        myComponents.controllerManager.enabled = true;
        myComponents.TeleportFloorObject.SetActive(true);
        myComponents.poseDriver.enabled = true;

        foreach (XRController controller in myComponents.controllers)
        {
            controller.enabled = true;
        }

        foreach (XRBaseInteractor interactor in myComponents.baseInteractors)
        {
            interactor.enabled = true;
        }

        foreach (GameObject avatarObject in myComponents.avatarObjects)
        {
            avatarObject.SetActive(false);
        }
    }

    public override void OnJoinRoomFailed(short returnCode, string message)
    {
        PhotonNetwork.CreateRoom("defaultRoom", new RoomOptions { MaxPlayers = 4 });
    }
}
