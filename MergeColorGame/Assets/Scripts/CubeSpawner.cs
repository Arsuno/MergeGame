using System;
using System.Collections.Generic;
using UnityEngine;

public class CubeSpawner : MonoBehaviour
{
    [SerializeField] private Cube _cubePrefab;
    [SerializeField] private GameObject _spawnPoint;

    private void Update()
    {
        if (Input.GetMouseButtonDown(0) == true)
        {
            Cube cube = Instantiate(_cubePrefab, _spawnPoint.transform.position, Quaternion.identity); 
            cube.Initialize(GenerateRandomColor());
        }
    }

    private CubeColor GenerateRandomColor()
    {
        Array colors = Enum.GetValues(typeof(CubeColor));
        return (CubeColor)colors.GetValue(UnityEngine.Random.Range(0, colors.Length));
    }

}
