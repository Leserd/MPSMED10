using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ThrustForce : MonoBehaviour {

    public enum ThrustState
    {
        Off, On
    }

    public float fuelAmount;
    public float fuelConsumption = 1.0f;
    float thrust;
    public float maxThrust;

    Vector3 thrustDirection = Vector3.zero;

    Rigidbody rb;
    public ParticleSystem fireParticle;

    public Image thrustAmount;


    public ThrustState currentThrustState = ThrustState.Off;

    public Transform centerOfThrust;


    public float maxGimbalAngle = 45.0f;



	// Use this for initialization
	void Start () {
        rb = GetComponentInParent<Rigidbody>();

        fuelAmount = rb.mass * 0.6f;
        //fireParticle = GetComponentInChildren<ParticleSystem>();
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            
            if (currentThrustState == ThrustState.On)
            {
                fireParticle.Stop();

                currentThrustState = ThrustState.Off;
            }
            else if(currentThrustState == ThrustState.Off)
            {
                fireParticle.Play();

                currentThrustState = ThrustState.On;
            }
        }

        if(Input.GetKey(KeyCode.UpArrow))
        {
            thrust += ((maxThrust/100)*30)*Time.deltaTime;
        }
        if(Input.GetKey(KeyCode.DownArrow))
        {
            thrust -= ((maxThrust/100)*30)*Time.deltaTime;
        }

        thrust = Mathf.Clamp(thrust, 0f, maxThrust);

        thrustAmount.color = Color.Lerp(Color.blue, Color.red, thrust / maxThrust);
        thrustAmount.fillAmount = thrust / maxThrust;

	}

    void GimbalThruster()
    {
        Vector3 rotationAxis = Vector3.Cross(transform.parent.up,Vector3.up);

        float rotationAngle = Mathf.Clamp(Vector3.Angle(transform.parent.up, Vector3.up), -maxGimbalAngle, maxGimbalAngle);

        //print(rotationAngle);

        if (rotationAngle >= 1.0f)
        {
            //transform.Rotate(rotationAxis, Mathf.LerpAngle(0, rotationAngle, Time.deltaTime));
            transform.eulerAngles = Vector3.Lerp(Vector3.zero, rotationAxis*rotationAngle, Time.deltaTime);
        }

        //
    }
        

    void FixedUpdate()
    {
        
        switch (currentThrustState)
        {
            case ThrustState.Off:


                break;
            case ThrustState.On:
                if (fuelAmount > 0.0f)
                {

                    float usedFuel = fuelConsumption * Time.fixedDeltaTime * thrust / maxThrust;

                    fuelAmount -= usedFuel;
                    rb.mass -= usedFuel;
                    
                    thrustDirection = transform.up  * thrust;
                    //Debug.DrawRay(transform.position, thrustDirection, Color.green);

                    rb.AddForceAtPosition(thrustDirection, centerOfThrust.position, ForceMode.Force);

                    //GimbalThruster();
                
                }
                else
                {
                    fireParticle.Stop();
                    currentThrustState = ThrustState.Off;
                }


                break;
        }


    }
}
