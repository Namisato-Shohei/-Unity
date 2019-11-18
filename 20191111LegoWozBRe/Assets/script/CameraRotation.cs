using UnityEngine;

public class CameraRotation : MonoBehaviour
{
    public GameObject MainCamera;
    private Vector3 lastMousePosition;
    private Vector3 newAngle = new Vector3(0, 0, 0);
    private Vector3 CamPos;
    private int angle=5;

    private Vector3 StartRelativePosition;
    private Vector3 StartRelativeForward;

    // マウスホイールの回転値を格納する変数
    private float scroll;
    // カメラ移動の速度
    public float speed = 1f;

    private void Start()
    {
        StartRelativePosition =MainCamera.transform.position;
        StartRelativeForward = MainCamera.transform.forward;
    }
    private void Update()
    {
        scroll = Input.GetAxis("Mouse ScrollWheel");
        Camera.main.transform.position += transform.forward * scroll * speed;

        CamPos = new Vector3(MainCamera.transform.rotation.x, MainCamera.transform.rotation.y, MainCamera.transform.rotation.z);
        if (Input.GetMouseButtonDown(0))
        {
            // マウスクリック開始(マウスダウン)時にカメラの角度を保持(Z軸には回転させないため).
            newAngle = MainCamera.transform.localEulerAngles;
            lastMousePosition = Input.mousePosition;
        }
        else if (Input.GetMouseButton(0))
        {
            // マウスの移動量分カメラを回転させる.
            newAngle.y += (Input.mousePosition.x - lastMousePosition.x) * 0.1f;
            newAngle.x -= (Input.mousePosition.y - lastMousePosition.y) * 0.1f;
            MainCamera.gameObject.transform.localEulerAngles = newAngle;
            lastMousePosition = Input.mousePosition;
        }       

    }
    public void OnclickUp()
    {
        MainCamera.transform.Rotate(new Vector3(angle,0f,0f));
    }
    public void OnclickDown()
    {
        MainCamera.transform.Rotate(new Vector3(-angle,0f,0f));
    }
    public void OnclickRight()
    {
        MainCamera.transform.Rotate(new Vector3(0f,angle,0f));
    }
    public void OnclickLeft()
    {
        MainCamera.transform.Rotate(new Vector3(0f,-angle,0f));
    }
    public void OnclickReset()
    {
        MainCamera.transform.position = StartRelativePosition;
        MainCamera.transform.forward =StartRelativeForward;
    }
}