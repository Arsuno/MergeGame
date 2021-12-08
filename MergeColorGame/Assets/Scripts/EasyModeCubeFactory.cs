using System;
using UnityEngine;

public class EasyModeCubeFactory : MonoBehaviour, ICubeFactory
{
    [SerializeField] private Cube _cubePrefab;

    public Cube CreateCube()
    {
        Cube cube = Instantiate(_cubePrefab);
        cube.Initialize(GenerateRandomColor());

        return cube;
    }

    private CubeColor GenerateRandomColor()
    {
        Array colors = Enum.GetValues(typeof(CubeColor));
        return (CubeColor)colors.GetValue(UnityEngine.Random.Range(0, colors.Length - 1));
    }
}