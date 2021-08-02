using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;
using Random = UnityEngine.Random;

public class GemController : MonoBehaviour
{
    public static GemController Instance;
    
    [SerializeField] private GameObject gemPrefab;
    [SerializeField] private Vector3 center;
    [SerializeField] private Vector3 size;
    [SerializeField] private List<Transform> gemList;
    
    private int _gemTotalCount = 5;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
    }

    private void Start()
    {
        StartFillGem();
    }

    private void StartFillGem()
    {
        for (int i = 0; i < _gemTotalCount; i++)
        {
            SpawnGem();
        }
    }
    
    public void CalculateGem()
    {
        if (gemList.Count <= _gemTotalCount)
        {
            SpawnGem();
        }
    }

    public void RemoveGem(Transform removeTransform)
    {
        gemList.Remove(removeTransform);
    }

    private void SpawnGem()
    {
        GameObject cloneGem = Instantiate(gemPrefab);
        gemList.Add(cloneGem.transform);
        cloneGem.transform.DOScale(Vector3.one, 0.2f);
        cloneGem.transform.SetParent(transform);
        cloneGem.transform.localPosition = CalculateRandomPoint();
    }

    private Vector3 CalculateRandomPoint()
    {
        return center + new Vector3(Random.Range(-size.x / 2, size.x / 2), 0.1f, Random.Range(-size.z / 2, size.z / 2));
    }
    
    private void OnDrawGizmos()
    {
        Gizmos.color = new Color(255, 255, 0, 0.5f);
        Gizmos.DrawCube(center, size);
    }
}
