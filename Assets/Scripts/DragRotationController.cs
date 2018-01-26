using UnityEngine;

public class DragRotationController : MonoBehaviour 
{
    private float _sensitivity;
    private Vector3 _mouseReference;
    private Vector3 _mouseOffset;
    private Vector3 _rotation;
    private bool _isRotating;

    [SerializeField]
    private float sensitivity = 0.3f;

    void Start()
    {
        _rotation = Vector3.zero;
    }

    void Update()
    {
        if (_isRotating)
        {
            // offset
            _mouseOffset = (Input.mousePosition - _mouseReference);

            // apply rotation
            _rotation.y = -(_mouseOffset.x) * sensitivity;
            _rotation.x = +(_mouseOffset.y) * sensitivity;

            // rotate
            transform.Rotate(_rotation,Space.World);

            // store mouse
            _mouseReference = Input.mousePosition;
        }
    }

    void OnMouseDown()
    {
        // rotating flag
        _isRotating = true;

        // store mouse
        _mouseReference = Input.mousePosition;
    }

    void OnMouseUp()
    {
        // rotating flag
        _isRotating = false;
    }
}
