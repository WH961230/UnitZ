using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FPSFlyCamera : MonoBehaviour {

    public float Speed = 10;
    public float sensitivityX = 15;
    public float sensitivityY = 15;
    public float minimumX = -360;
    public float maximumX = 360;
    public float minimumY = -60;
    public float maximumY = 60;
    private float rotationX = 0;
    private float rotationY = 0;

    void Start () {
    }

    float speedmult = 1;
    void Update()
    {
        this.transform.position += this.transform.forward * Input.GetAxis("Vertical") * Speed * speedmult * Time.deltaTime;
        this.transform.position += this.transform.right * Input.GetAxis("Horizontal") * Speed * speedmult * Time.deltaTime;
        rotationX += Input.GetAxis("Mouse X") * sensitivityX;
        rotationY += Input.GetAxis("Mouse Y") * sensitivityY;
        if (Input.GetKey(KeyCode.LeftShift))
        {
            speedmult = 2;
        }
        else
        {
            speedmult = 1;
        }
        if (rotationX >= 360)
        {
            rotationX = 0;
        }
        if (rotationX <= -360)
        {
            rotationX = 0;
        }
        rotationX = ClampAngle(rotationX, minimumX, maximumX);
        rotationY = ClampAngle(rotationY, minimumY, maximumY);
        Quaternion xQuaternion = Quaternion.AngleAxis(rotationX, Vector3.up);
        Quaternion yQuaternion = Quaternion.AngleAxis(rotationY, Vector3.left);
        this.transform.localRotation = xQuaternion * yQuaternion;
    }

    static float ClampAngle(float angle, float min, float max)
    {
        // just clamp angle function
        if (angle < -360.0f)
            angle += 360.0f;

        if (angle > 360.0f)
            angle -= 360.0f;

        return Mathf.Clamp(angle, min, max);
    }
}
