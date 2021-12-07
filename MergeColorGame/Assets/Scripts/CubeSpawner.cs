using System;
using UnityEngine;

public class CubeSpawner : MonoBehaviour
{
    [SerializeField] private Cube _cubePrefab;
    [SerializeField] private Transform _spawnPoint;

    public Cube SpawnCube()
    {
        Cube cube = Instantiate(_cubePrefab, _spawnPoint.position, Quaternion.identity);
        cube.Initialize(GenerateRandomColor());

        return cube;
    }

    private CubeColor GenerateRandomColor()
    {
        Array colors = Enum.GetValues(typeof(CubeColor));
        return (CubeColor)colors.GetValue(UnityEngine.Random.Range(0, colors.Length - 1));
    }
}
