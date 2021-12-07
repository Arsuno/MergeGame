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
    public CubeColor CubeColor { get; private set; }
    public float Speed => _rigidBody.velocity.magnitude;

    [SerializeField] private Rigidbody _rigidBody;
    [SerializeField] private Renderer _renderer;
    [SerializeField] private CubeSpawner _cubeSpawner;


    private void Awake()
    {
        _rigidBody.isKinematic = true;
        _cubeSpawner = GameObject.Find("Spawner").GetComponent<CubeSpawner>();
    }

    private Dictionary<CubeColor, Color> _colors = new Dictionary<CubeColor, Color>
    {
        {CubeColor.Red, Color.red },
        {CubeColor.Green, Color.green },
        {CubeColor.Blue, Color.blue },
        {CubeColor.Yellow, Color.yellow },
    };

    public void Initialize(CubeColor cubeColor)
    {
        CubeColor = cubeColor;
        SetMaterialColor(CubeColor);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.TryGetComponent(out Cube cube) == true)
        {
            if (CubeColor == cube.CubeColor)
            {
                _cubeSpawner.SpawnCube();
                Destroy(gameObject);
            }
        }
    }

    private void SetMaterialColor(CubeColor color)
    {
        _renderer.material.color = _colors[color];
    }

    public void Fall()
    {
        _rigidBody.isKinematic = false;
    }


}
