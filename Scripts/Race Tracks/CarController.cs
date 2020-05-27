using UnityEngine;

public class CarController : MonoBehaviour
{
    [Header("Car Set Up")]
    public Rigidbody rb;
    private Controlls controls = null;
    public GameObject model;
    public GameObject kart;
    public Transform sphere;

    float currentSpeed = 0, speed = 0;
    float currentRotate = 0, rotate = 0;
    public bool drifting = false;
    int driftDir = 0;

    [Header("")]
    public LayerMask floor;

    [Header("Particals")]
    public PSystem leftDrift;
    public PSystem rightDrift;

    [Header("Animations")]
    public GameObject[] Wheels;
    public GameObject[] Shaft;
    public GameObject SteeringWheel;

    private void OnEnable()
    {
        //sets up the car controller
        if (controls == null)
        {
            controls = new Controlls();
            //sets up the drifting controlls
            controls.CarController.Drift.canceled += ctx => { StopDrifting(); };
            controls.CarController.Drift.started += ctx => { StartDrifting(); };
        }
        controls.CarController.Enable();
    }

    //disable the controller
    private void OnDisable()
    {
        controls.CarController.Disable();
    }

    private void FixedUpdate()
    {
        //moves the car forward
        rb.AddForce(transform.forward * currentSpeed, ForceMode.Acceleration);
        //gravity
        rb.AddForce(Vector3.down * 20, ForceMode.Acceleration);
        //rotation
        transform.eulerAngles = Vector3.Lerp(transform.eulerAngles, new Vector3(0, transform.eulerAngles.y + currentRotate, 0), Time.deltaTime * 5f);

        //rotate the car based upon the floor normal
        RaycastHit hit;
        Debug.DrawRay(model.transform.position, Vector3.down, Color.red, 2f);
        Physics.Raycast(model.transform.position, Vector3.down, out hit, 3, floor);

        //model.transform.up = Vector3.Lerp(model.transform.up, hit.normal, Time.deltaTime * 8.0f);
        //model.transform.Rotate(0, transform.eulerAngles.y, 0);
    }

    private void Update()
    {
        //put the model at the spheres position
        model.transform.position = sphere.position - new Vector3(0f, .92f, 0f);

        //is the car accellerating
        if (controls.CarController.Accelerate.ReadValue<float>() > 0)
            speed = 80f;

        //if the car is reversing
        if (controls.CarController.Reverse.ReadValue<float>() > 0)
            speed = 0;

        //if the player is moving
        if (controls.CarController.Move.ReadValue<float>() != 0)
        {
            //find the direction and steer amount
            float value = controls.CarController.Move.ReadValue<float>();
            int dir = value > 0 ? 1 : -1;
            float amount = Mathf.Abs(value);

            Steer(dir, amount);
        }

        //if drifting
        if (drifting)
        {
            //remap the input to be weighted more for tighter drifts
            float control = (driftDir == 1) ? Remap(controls.CarController.Move.ReadValue<float>(), -1, 1, 0, 1.5f) : Remap(controls.CarController.Move.ReadValue<float>(), -1, 1, 1.5f, 0);
            float powerControl = (driftDir == 1) ? Remap(controls.CarController.Move.ReadValue<float>(), -1, 1, .2f, 1) : Remap(controls.CarController.Move.ReadValue<float>(), -1, 1, 1, .2f);
            Steer(driftDir, control);
        }

        //lerp between the old and new possitions
        currentSpeed = Mathf.SmoothStep(currentSpeed, speed, Time.deltaTime * 12f);
        currentRotate = Mathf.Lerp(currentRotate, rotate, Time.deltaTime * 4f);

        rotate = 0;
        speed = 0;

        if (drifting)
        {
            float value = (driftDir == 1) ? Remap(controls.CarController.Move.ReadValue<float>(), -1, 1, .25f, 1.5f) : Remap(controls.CarController.Move.ReadValue<float>(), -1, 1, 1.5f, .25f);
            kart.transform.localEulerAngles = new Vector3(-90, Mathf.LerpAngle(kart.transform.localEulerAngles.y, driftDir * (value * 15f), .2f), 0);
        }
        else
        {
            kart.transform.localEulerAngles = new Vector3(-90, Mathf.LerpAngle(kart.transform.localEulerAngles.y, 0, .2f), 0);
        }

        foreach (GameObject w in Wheels)
        {
            w.transform.localEulerAngles = new Vector3(w.transform.localEulerAngles.x, 0, (controls.CarController.Move.ReadValue<float>() * 25));
        }

        SteeringWheel.transform.localEulerAngles = new Vector3(-35, ((controls.CarController.Move.ReadValue<float>() * 45)), 0);
        //frontWheels.localEulerAngles += new Vector3(0, 0, sphere.velocity.magnitude / 2);
        //backWheels.localEulerAngles += new Vector3(0, 0, sphere.velocity.magnitude / 2);
    }

    void Steer(int dir, float amount)
    {
        if (currentSpeed > 7.5f || currentSpeed < -5f)
            rotate = (30f * dir) * amount; //dunno if this movement 30 should be lower
    }

    float Remap(float s, float a1, float a2, float b1, float b2)
    {
        return b1 + (s - a1) * (b2 - b1) / (a2 - a1);
    }

    void StartDrifting()
    {
        drifting = true;
        driftDir = controls.CarController.Move.ReadValue<float>() > 0 ? 1 : -1;

        if (driftDir == -1)
            leftDrift.PlayParticals();
        else
            rightDrift.PlayParticals();
    }

    void StopDrifting()
    {
        drifting = false;
        if (driftDir == -1)
            leftDrift.StopParticals();
        else
            rightDrift.StopParticals();

        driftDir = 0;
    }
}
