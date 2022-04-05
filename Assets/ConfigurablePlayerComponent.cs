using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;
using UnityEngine.SpatialTracking;
using Photon.Pun;

public class ConfigurablePlayerComponent : MonoBehaviourPun, IPunObservable
{
    [Header("XR Rig Control Components - to Enable on local Player")]
    public XRRig rig;
    public Camera mainCamera;
    public ControllerManager controllerManager;
    public AudioListener listener;
    public XRController[] controllers;
    public XRBaseInteractor[] baseInteractors;
    public GameObject TeleportFloorObject;
    public TrackedPoseDriver poseDriver;

    [Header("Avatar Obejcts - to Disable on local player")]
    public GameObject[] avatarObjects;

    public void OnPhotonSerializeView(PhotonStream stream, PhotonMessageInfo info)
    {
        if (stream.IsWriting)
        {
            //Send info over network to other side to sync positions
            foreach (var avatarObject in avatarObjects)
            {
                stream.SendNext(avatarObject.transform.position);
                stream.SendNext(avatarObject.transform.rotation);
            }
        }
        else //if (stream.IsReading)
        {
            //Get info over network to other side to sync positions
            foreach (var avatarObject in this.avatarObjects)
            {
                avatarObject.transform.position = (Vector3)stream.ReceiveNext();
                avatarObject.transform.rotation = (Quaternion)stream.ReceiveNext();
            }
        }
    }
}
