using System;
using System.Collections.Generic;
using UnityEngine;

public class CubeSpawner : MonoBehaviour
{
    [SerializeField] private Cube _cubePrefab;
    [SerializeField] private GameObject _spawnPoint;

    private Cube _spawnedCube;
    private int GeneratedColor;

    private void Update()
    {
        if (Input.GetMouseButtonDown(0) == true)
        {
            _cubePrefab.Initialize(GenerateRandomColor());
            _spawnedCube = Instantiate(_cubePrefab, _spawnPoint.transform.position, Quaternion.identity); 
        }
    }

    private CubeColor GenerateRandomColor()
    {
        Array colors = Enum.GetValues(typeof(CubeColor));
        return (CubeColor)colors.GetValue(UnityEngine.Random.Range(0, colors.Length));
    }

}
