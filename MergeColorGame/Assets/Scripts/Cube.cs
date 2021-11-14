using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum CubeColor
{
    Red,
    Green,
    Blue,
    Yellow
}

public class Cube : MonoBehaviour
{
    public CubeColor _cubeColor;

    [SerializeField] private Material _objectMaterial;

    public void Initialize(CubeColor cubeColor)
    {
        _cubeColor = cubeColor;
        SetMaterialColor(_cubeColor);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.TryGetComponent(out Cube cube) == true)
        {
            if (_objectMaterial.color == cube._objectMaterial.color)
            {
                Destroy(gameObject);
            }
        }
    }

    private uint SetMaterialColor(CubeColor color)
    {
        switch (color)
        {
            case CubeColor.Red: _objectMaterial.color = Color.red; break;
            case CubeColor.Green: _objectMaterial.color = Color.green; break;
            case CubeColor.Blue: _objectMaterial.color = Color.blue; break;
            case CubeColor.Yellow: _objectMaterial.color = Color.yellow; break;
        }
        return 0;
    }

    






}
