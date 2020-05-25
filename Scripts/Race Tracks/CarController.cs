using UnityEngine;

public class CarController : MonoBehaviour
{
    public Rigidbody rb;
    private Controlls controls = null;
    public GameObject model;
    public Transform sphere;

    float currentSpeed = 0;
    float currentRotate, rotate = 0;

    public bool drifting = false;
    int driftDir = 0;


    private void OnEnable()
    {
        controls = new Controlls();
        controls.CarController.Enable();
        controls.CarController.Drift.canceled += ctx => { drifting = false; driftDir = 0; };
        controls.CarController.Drift.started += ctx => { drifting = true; driftDir = controls.CarController.Move.ReadValue<float>() > 0 ? 1 : -1; };
        //rb.maxAngularVelocity = 30f;
    }

    private void FixedUpdate()
    {
        //moves the car forward
        rb.AddForce(model.transform.forward * currentSpeed, ForceMode.Acceleration);


        rb.AddForce(Vector3.down * 10, ForceMode.Acceleration);
        //rotation
        model.transform.eulerAngles = Vector3.Lerp(model.transform.eulerAngles, new Vector3(0, model.transform.eulerAngles.y + currentRotate, 0), Time.deltaTime * 5f);
    }

    private void Update()
    {
        float speed = 0;
        //put the model at the spheres position
        model.transform.position = sphere.position - new Vector3(0f, .8f, 0f);

        //is the car accellerating
        if (controls.CarController.Accelerate.ReadValue<float>() > 0)
            speed = 80f;

        if(controls.CarController.Move.ReadValue<float>() != 0)
        {
            float value = controls.CarController.Move.ReadValue<float>();
            int dir = value > 0 ? 1 : -1;
            float amount = Mathf.Abs(value);

            Steer(dir, amount);
        }

        if (drifting)
        {
            float control = (driftDir == 1) ? Remap(controls.CarController.Move.ReadValue<float>(), -1, 1, 0, 2) : Remap(controls.CarController.Move.ReadValue<float>(), -1, 1, 2, 0);
            float powerControl = (driftDir == 1) ? Remap(controls.CarController.Move.ReadValue<float>(), -1, 1, .2f, 1) : Remap(controls.CarController.Move.ReadValue<float>(), -1, 1, 1, .2f);
            Steer(driftDir, control);
        }

        currentSpeed = Mathf.SmoothStep(currentSpeed, speed, Time.deltaTime * 12f);
        currentRotate = Mathf.Lerp(currentRotate, rotate, Time.deltaTime * 4f);
        rotate = 0;
    }

    void Steer(int dir, float amount)
    {
        rotate = (30f * dir) * amount;
    }

    float Remap(float s, float a1, float a2, float b1, float b2)
    {
        return b1 + (s - a1) * (b2 - b1) / (a2 - a1);
    }
}
