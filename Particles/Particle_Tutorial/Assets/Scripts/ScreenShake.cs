using UnityEngine;


public class ScreenShake : MonoBehaviour
{

    private Transform _transform;
    private Vector3 _originalPos;

    [Range(0, 10f)]
    public float XRange;
    [Range(0, 10f)]
    public float YRange;

    private void Awake()
    {
        _transform = gameObject.GetComponent<Transform>();
        _originalPos = _transform.localPosition;
    }

    private void Update()
    {
        if (Input.GetButton("Shake"))
            Shake(XRange, YRange);
        else
        {
            _transform.SetPositionAndRotation(_originalPos, _transform.rotation);
        }
    }

    private void Shake(float _x, float _y)
    {
        var x = Random.Range(-_x, _x);
        var y = Random.Range(-_y, _y);
        
//        _transform.SetPositionAndRotation(new Vector3(x, y, -10) + _originalPos, _transform.rotation);
        _transform.localPosition = new Vector3(x, y, -10) + _originalPos;
    }
    
}