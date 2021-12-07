using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeMerger : MonoBehaviour
{
    [SerializeField] private Cube _cube;
    [SerializeField] private Cube _cubePrefab;

    private Dictionary<CubeColor, Color> _colors = new Dictionary<CubeColor, Color>
    {
        {CubeColor.Red, Color.red },
        {CubeColor.Green, Color.green },
        {CubeColor.Blue, Color.blue },
        {CubeColor.Yellow, Color.yellow },
    };

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.TryGetComponent(out Cube cube) == true)
        {
            if (_cube.Speed >= cube.Speed)
            {
                Cube spawnedCube = Instantiate(_cubePrefab, _cube.transform.position, Quaternion.identity);
            }
        }
    }


}

