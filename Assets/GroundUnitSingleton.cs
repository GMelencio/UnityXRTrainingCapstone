using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundUnitSingleton : MonoBehaviour
{
    #region Singleton

    public static GroundUnitSingleton instance;

    #endregion

    //public GameObject vehicle;

    void Awake()
    {
        instance = this;
    }
}
