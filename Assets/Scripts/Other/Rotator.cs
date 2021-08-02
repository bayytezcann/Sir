using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotator : MonoBehaviour
{
    #region Variables
    
    // <Public Variables> //
    [Range(-1.0f, 1.0f)]
    public float xForceDirection = 0.0f;                    //X ekseni ayarı
    [Range(-1.0f, 1.0f)]
    public float yForceDirection = 0.0f;                    //Y ekseni ayarı
    [Range(-1.0f, 1.0f)]
    public float zForceDirection = 0.0f;                    //Z ekseni ayarı
    public float speedMultiplier = 1;                       //Hızı
    public bool worldPivot = false;

    // <Private Variables> //
    private Space _spacePivot = Space.Self;
    #endregion
    
    void Start()
    {
        if (worldPivot) _spacePivot = Space.World;
    }
 
    void Update()
    {
        transform.Rotate(xForceDirection * speedMultiplier
            , yForceDirection * speedMultiplier
            , zForceDirection * speedMultiplier
            , _spacePivot);
    }
}