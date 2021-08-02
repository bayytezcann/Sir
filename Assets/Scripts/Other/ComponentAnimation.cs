using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class ComponentAnimation : MonoBehaviour
{
    public float scaleSize;
    public float scaleTime;
    
    void Start()
    {
        Vector3 scaleVector = new Vector3(scaleSize, scaleSize, scaleSize);
        transform.DOScale(scaleVector, scaleTime).SetLoops(-1, LoopType.Yoyo);
    }
}

