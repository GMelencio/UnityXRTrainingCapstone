using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Photon.Pun;
using Photon.Realtime;

public class NetworkManagerExample : MonoBehaviourPunCallbacks
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

    }

    public override void OnJoinRoomFailed(short returnCode, string message)
    {
        PhotonNetwork.CreateRoom("defaultRoom", new RoomOptions { MaxPlayers = 4 });
    }
}
