using System.Collections;
using UnityEngine;

public class CubeHub : MonoBehaviour
{
    public bool CubeAvailable = true;

    [SerializeField] private Transform _spawnPoint;
    [SerializeField] private EasyModeCubeFactory _cubeFactory; //TODO: должен быть интерфейс
    [SerializeField] private float _respawnTime;

    private Cube _activeCube;

    public void Awake()
    {
        SpawnNewCube();
    }

    public void SetСubePosition(float x)
    {
        Vector3 cubePosition = _activeCube.transform.position;
        cubePosition.x = x;

        _activeCube.transform.position = cubePosition;
    }

    public void FallCube()
    {
        _activeCube.Fall();
        CubeAvailable = false;
        StartCoroutine(OnCubeFall());
    }

    private IEnumerator OnCubeFall()
    {
        yield return new WaitForSeconds(_respawnTime);
        SpawnNewCube();
    }

    private void SpawnNewCube()
    {
        _activeCube = _cubeFactory.CreateCube();
        _activeCube.transform.position = _spawnPoint.position;
        CubeAvailable = true;
    }
}
