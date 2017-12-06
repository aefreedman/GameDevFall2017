using UnityEngine;


public class InterpolatePosition : MonoBehaviour
{
    private Transform _transform;
    private Vector3 _originalPos;

    private void Awake()
    {
        _transform = GetComponent<Transform>();
        _originalPos = _transform.position;
    }

    private void Update()
    {
        var pos = _originalPos.x + (5 - _originalPos.x) * 0.1f;
        _transform.position = new Vector3(pos, 0, 0);
    }
}