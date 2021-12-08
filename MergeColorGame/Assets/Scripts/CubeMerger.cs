using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeMerger : MonoBehaviour
{
    [SerializeField] private Cube _cube;
    [SerializeField] private Cube _cubePrefab;

    //TODO: другая ответсвенность
    private Dictionary<CubeColor, CubeColor> _mergeColors = new Dictionary<CubeColor, CubeColor>
    {
        {CubeColor.Green, CubeColor.Blue },
        {CubeColor.Blue, CubeColor.Yellow },
        {CubeColor.Yellow, CubeColor.Red },
    };

    private bool CanMerge(Cube cube)
    {
        return cube.CubeColor == _cube.CubeColor && cube.CubeColor != CubeColor.Red && _cube.Speed >= cube.Speed;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.TryGetComponent(out Cube cube) == true)
        {
            if (CanMerge(cube) == true)
            {
                Cube spawnedCube = Instantiate(_cubePrefab, cube.transform.position, cube.transform.rotation);
                spawnedCube.Initialize(_mergeColors[_cube.CubeColor]);
                _cube.DestroyBlyad();
                cube.DestroyBlyad();
                spawnedCube.Fall();
            }
        }
    }
}

