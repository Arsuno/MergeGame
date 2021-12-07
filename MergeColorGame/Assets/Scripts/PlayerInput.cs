using UnityEngine;
using System.Collections;

public class PlayerInput : MonoBehaviour
{
    [SerializeField] private CubeSpawner _cubeSpawner;
    [SerializeField] private Camera _mainCamera;
    private const int LeftMouseButtonIndex = 0;
    private Cube _cube;


    private void Start()
    {
        _cube = _cubeSpawner.SpawnCube();
    }

    private void Update()
    {
        if (Input.GetMouseButton(LeftMouseButtonIndex))
        {
            Vector3 mousePosition = _mainCamera.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, 10));
            _cube.transform.position = new Vector3(mousePosition.x, _cube.transform.position.y, _cube.transform.position.z);
        }

        if (Input.GetMouseButtonUp(LeftMouseButtonIndex))
        {
            _cube.Fall();
            StartCoroutine(SpawnCube());
        }
    }

    private IEnumerator SpawnCube()
    {
        yield return new WaitForSeconds(2);
        _cube = _cubeSpawner.SpawnCube();
    }
}
