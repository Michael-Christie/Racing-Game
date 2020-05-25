using UnityEngine;

public class CarController : MonoBehaviour
{
    public Rigidbody rb;
    private Controlls controls = null;
    public GameObject model;
    public Transform sphere;

    float currentSpeed = 0;
    float currentRotate, rotate = 0;

    private void OnEnable()
    {
        controls = new Controlls();
        controls.CarController.Enable();
    }

    private void FixedUpdate()
    {
        //moves the car forward
        rb.AddForce(model.transform.forward * currentSpeed, ForceMode.Acceleration);
        //rotation
        model.transform.eulerAngles = Vector3.Lerp(model.transform.eulerAngles, new Vector3(0, model.transform.eulerAngles.y + currentRotate, 0), Time.deltaTime * 5f);
    }

    private void Update()
    {
        float speed = 0;
        //put the model at the spheres position
        model.transform.position = sphere.position - new Vector3(0f, 1f, 0f);

        //is the car accellerating
        if (controls.CarController.Accelerate.ReadValue<float>() > 0)
            speed = 30;

        if(controls.CarController.Move.ReadValue<float>() != 0)
        {
            float value = controls.CarController.Move.ReadValue<float>();
            int dir = value > 0 ? 1 : -1;
            float amount = Mathf.Abs(value);

            Steer(dir, amount);
        }

        currentSpeed = Mathf.SmoothStep(currentSpeed, speed, Time.deltaTime * .4f);
        currentRotate = Mathf.Lerp(currentRotate, rotate, Time.deltaTime * .4f);
        rotate = 0;
        speed = 0;
    }

    void Steer(int dir, float amount)
    {
        rotate = (80f * dir) * amount;
    }
}
