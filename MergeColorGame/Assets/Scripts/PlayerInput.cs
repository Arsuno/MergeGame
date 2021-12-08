using UnityEngine;
using System.Collections;

public class PlayerInput : MonoBehaviour
{
    [SerializeField] private CubeHub _cubeHub;
    [SerializeField] private Camera _mainCamera;
    private const int LeftMouseButtonIndex = 0;

    private void Update()
    {
        if (Input.GetMouseButton(LeftMouseButtonIndex) == true && _cubeHub.CubeAvailable == true)
            UpdateCubePosition();

        if (Input.GetMouseButtonUp(LeftMouseButtonIndex) == true)
        {
            if (_cubeHub.CubeAvailable == true)
                FallCube();
        }
    }

    private void UpdateCubePosition()
    {
        Vector3 mousePosition = _mainCamera.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, 10));
        _cubeHub.Set—ubePosition(mousePosition.x);
    }

    private void FallCube()
    {
        _cubeHub.FallCube();
    }
}
