using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class CameraController : MonoBehaviour
{
///******************************
// THIS SCRIPT IS NOT USED , I USED CINAMACHINE INSTEAD
//*******************************
    [SerializeField] Transform heroPos;
    Vector3 newPos, offset, currentAngle;
    const float increaseAmount = 5f;
    const float increaseXRotationAmount = 20f;
    Camera main;
    float lerpTime = .5f;
    // Start is called before the first frame update
    void Start()
    {
        main = GetComponent<Camera>();
        offset = transform.position - heroPos.position;
    }
    // Update is called once per frame
    void LateUpdate()
    {
        CamSmoothFollow();
    }
    private void CamSmoothFollow()
    {
        newPos = Vector3.Lerp(transform.position, heroPos.transform.position + offset, Time.deltaTime);
        transform.position = newPos;
    }
    public void UpdateCameraSettings()
    {
        main.fieldOfView = Mathf.Lerp(main.fieldOfView, main.fieldOfView + increaseAmount, 1);
        currentAngle = new Vector3(
            Mathf.LerpAngle(transform.eulerAngles.x, transform.eulerAngles.x + increaseXRotationAmount, 0.5f),
            transform.eulerAngles.y,
            transform.eulerAngles.z);
        main.transform.eulerAngles = currentAngle;
    }
}
