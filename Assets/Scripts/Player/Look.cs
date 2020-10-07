using UnityEngine;

public class Look : MonoBehaviour
{
    private Vector2 _lookInput;
    private float _lookAngle;
    private Camera _camera;
    private LookCalculator _lookCalculator;
    
    public float lookSpeed;
    private void Awake()
    {
        _lookAngle = 0.0f;
        _camera = Camera.main;
        _lookCalculator = new LookCalculator();
    }
    private void Update()
    {
        Turn();
        UpDown();
    }
    public void SetLookInput(Vector2 input)
    {
        _lookInput = input;
    }
    private void UpDown()
    {
        if (!_lookCalculator.HasLookInput(_lookInput)) return;

        _lookAngle = _lookCalculator.GetNewLookAngle(_lookInput.y, _lookAngle, lookSpeed, Time.deltaTime);

        _camera.transform.localEulerAngles = _lookCalculator.GetNewLookRotation(_lookAngle);
    } 
    private void Turn()
    {
        if (!_lookCalculator.HasTurnInput(_lookInput)) return;
        
        transform.Rotate(Vector3.up * (_lookInput.x * Time.deltaTime * lookSpeed));
    }
}
