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

    bool disabled = false;

    [Header("")]
    public LayerMask floor;

    [Header("Particals")]
    public PSystem leftDrift;
    public PSystem rightDrift;
    public ParticleSystem leftSmoke;
    public ParticleSystem rightSmoke;
    bool particalsPlaying = false;

    [Header("Animations")]
    public GameObject[] Wheels;
    public GameObject[] Shaft;
    public GameObject SteeringWheel;
    public Color[] driftColor;
    public float cameraFOV = 0;
    public Camera cam;

    public bool inMenu = false;

    float driftPower = 0;

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

    //this should be changed to stopping the forces being added rather then the controller!!
    public void Enable() => disabled = false;
    public void Disable() => disabled = true;



    private void FixedUpdate()
    {
        //gravity
        rb.AddForce(Vector3.down * 20, ForceMode.Acceleration);

        if (!inMenu && !disabled)
        {
            //moves the car forward
            rb.AddForce(transform.forward * currentSpeed, ForceMode.Acceleration);
            //rotation
            transform.eulerAngles = Vector3.Lerp(transform.eulerAngles, new Vector3(0, transform.eulerAngles.y + currentRotate, 0), Time.deltaTime * 5f);

            //rotate the car based upon the floor normal
            RaycastHit hit;
            Debug.DrawRay(model.transform.position, Vector3.down, Color.red, 2f);
            Physics.Raycast(model.transform.position, Vector3.down, out hit, 3, floor);

            model.transform.up = Vector3.Lerp(model.transform.up, hit.normal, Time.deltaTime * 8.0f);
            model.transform.Rotate(0, transform.eulerAngles.y, 0);
        }
    }

    private void Update()
    {
        if (controls.CarController.Menu.triggered)
        {
            inMenu = !inMenu;

            if (inMenu)
                FindObjectOfType<GameStart>().ShowMenu();
            else
                FindObjectOfType<GameStart>().HideMenu();
        }


        if (!inMenu)
        {
            speed = currentSpeed * .5f;
            //put the model at the spheres position
            model.transform.position = sphere.position - new Vector3(0f, .92f, 0f);

            //is the car accellerating
            if (controls.CarController.Accelerate.ReadValue<float>() > 0)
                speed = 130f;

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

                driftPower += powerControl * Time.deltaTime * 240;

                SetColor();
            }

            //lerp between the old and new possitions
            currentSpeed = Mathf.SmoothStep(currentSpeed, speed, Time.deltaTime * 12f);
            currentRotate = Mathf.Lerp(currentRotate, rotate, Time.deltaTime * 4f);

            rotate = 0;
            speed = 0;

            if (drifting)
            {
                float value = (driftDir == 1) ? Remap(controls.CarController.Move.ReadValue<float>(), -1, 1, .25f, 1.5f) : Remap(controls.CarController.Move.ReadValue<float>(), -1, 1, 1.5f, .25f);
                kart.transform.localEulerAngles = new Vector3(0, Mathf.LerpAngle(kart.transform.localEulerAngles.y, driftDir * (value * 15f), .2f), 0);
            }
            else
            {
                kart.transform.localEulerAngles = new Vector3(0, Mathf.LerpAngle(kart.transform.localEulerAngles.y, 0, .2f), 0);
            }

            //front wheels
            //left
            Wheels[0].transform.localEulerAngles = new Vector3(0, -90 + (controls.CarController.Move.ReadValue<float>() * 25), Wheels[0].transform.localEulerAngles.z - (rb.velocity.magnitude / 2));
            //right
            Wheels[1].transform.localEulerAngles = new Vector3(0, 90 + (controls.CarController.Move.ReadValue<float>() * 25), Wheels[1].transform.localEulerAngles.z + (rb.velocity.magnitude / 2));
            //back wheels
            Wheels[2].transform.localEulerAngles = new Vector3(0, -90, Wheels[2].transform.localEulerAngles.z - (rb.velocity.magnitude / 2));
            //right
            Wheels[3].transform.localEulerAngles = new Vector3(0, 90, Wheels[3].transform.localEulerAngles.z + (rb.velocity.magnitude / 2));

            SteeringWheel.transform.localEulerAngles = new Vector3(-121.285f, 1.088989f, (-90 + (controls.CarController.Move.ReadValue<float>() * 45)));

            if (rb.velocity.magnitude > 1.5f)
            {
                if (!particalsPlaying)
                {
                    rightSmoke.Play();
                    leftSmoke.Play();
                    particalsPlaying = true;
                }
            }
            else if (particalsPlaying)
            {
                rightSmoke.Stop();
                leftSmoke.Stop();
                particalsPlaying = false;
            }

            cam.fieldOfView = Mathf.Lerp(Camera.main.fieldOfView, 60 + cameraFOV, Time.deltaTime * 4f);
            if (cameraFOV > 0)
                cameraFOV -= Time.deltaTime * 20f;
            if (cameraFOV < 0)
                cameraFOV = 0;

        }
    }

    void Steer(int dir, float amount)
    {
        if (currentSpeed > 7.5f || currentSpeed < -5f)
            rotate = (17f * dir) * amount; //dunno if this movement 30 should be lower
    }

    float Remap(float s, float a1, float a2, float b1, float b2)
    {
        return b1 + (s - a1) * (b2 - b1) / (a2 - a1);
    }

    void SetColor()
    {
        Color c = driftPower > 100 ? (driftPower > 250 ? driftColor[2] : driftColor[1]) : driftColor[0];
        bool b = driftPower > 100 ? true : false;
        if(driftDir == -1)
            leftDrift.SetColor(c,b);
        else
            rightDrift.SetColor(c,b);
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

        float v = driftPower > 250 ? 250 : driftPower;
        v /= 5;

        currentSpeed += v;
        cameraFOV = 30;

        driftDir = 0;
        driftPower = 0;
    }
}
