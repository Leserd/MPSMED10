using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RocketExplostion : MonoBehaviour {
    public GameObject Subrocket;

    public delegate void Explosion(Vector3 posCenter);
    public static event Explosion Explode ;
    private Rigidbody Rigid;
    public Vector3 Velocity;

    public Transform RocketHead, RocketStick, CenterofGravity ,ThrustPoint;

    public float DragCoffiecient = 0.295f, DensityFluid = 1.225f, MassRocket = 3f,Fuel = 2f, MassStick = 1f;
    public float ThrustRocket = 80f,StickDist = 0.5f, RocketDist = 3f;
    public Vector3 CenterOfGravity;

	// Use this for initialization
	void Awake () {
        Rigid = GetComponent<Rigidbody>();
	}
	
	// Update is called once per frame
	void FixedUpdate () {

        if (Input.GetKeyDown(KeyCode.Return))
        {
            for (int i = 0; i < 10; i++)
            {
                Instantiate(Subrocket, transform.position + new Vector3(Random.Range(-.25f, 0.25f), Random.Range(-0.25f, 0.25f), Random.Range(-0.25f, 0.25f)), Quaternion.identity);
            }
            if (Explode != null)
            {
                Explode(transform.position);
            }
        }

        Velocity = Velocity  +Thrust;
        transform.position = transform.position + Velocity * Time.fixedDeltaTime;

        CenterofGravity.localPosition = CalcCenterOfGravity;


	}

    Vector3 Thrust
    {
        get
        {
            var acceleration = ThrustRocket * Mathf.Pow(MassRocket + MassStick, -1) ;
            var distVector = CalcCenterOfGravity - ThrustPoint.localPosition;
            var temp = acceleration * Time.fixedDeltaTime * distVector * Time.fixedDeltaTime;
            Debug.Log(Vector3.Project(temp, transform.up));
            return Vector3.Project(temp, transform.up);

        }
    }

    Vector3 CalcCenterOfGravity
    {
        get
        {
            // MassRocket = (MassRocket > 2.25f) ? MassRocket* 0.997f : MassRocket;
            var CenterRocketHead = new Vector3();
            CenterRocketHead.y = 1 - RocketHead.localScale.y * 0.5f;
            CenterRocketHead.z = RocketHead.localScale.z * 0.5f;
            CenterRocketHead.z += RocketStick.localScale.z;
            CenterOfGravity = (RocketStick.localPosition * MassStick + CenterRocketHead * MassRocket) / (MassStick + MassRocket);
            return CenterOfGravity;
        }
    }

    Vector3 ApplyGravity
    {
        get
        {
            /// force of gravity affecting the rocket in a downwards position
            var forceDown = CalcGravitationForce * Vector3.up;
            var acceleration = Mathf.Pow(MassRocket + MassStick, -1) * forceDown;
            return acceleration * Time.fixedDeltaTime; //  Terminal velocity?? Mathf.Sqrt(2*(MassRocket+MassStick)/DragCoffiecient*DensityFluid*)   
 
        }

    }

    private float CalcGravitationForce
    {
        get {
            float gravitationalConstant = Mathf.Pow(10f, -11f) * 6.67f;
            var totalMassRocket = MassStick + MassRocket;
            float massEarth = Mathf.Pow(10f, 24f) * 5.972f; // in kilos
            float positionEarth = -(Mathf.Pow(10f, 6f) * 6.371f);// in meters
            float positionRocket = CenterofGravity.position.y;
            //formula for force on a particle1 (rocket) on another particle2 (earth)
            //Force(gravity) = G*mass(particle1)*mass(particle2)*   (pos2 - pos 1) /
            //   where G is gravitational constant6.67*10^-11        |pos2-pos1|^3

            //positions substracted from each other
            var distanceBetween = positionEarth - positionRocket;
            // Debug.Log(distanceBetween + " test value " +distanceBetween/ Mathf.Pow(Mathf.Abs(distanceBetween), 3));



            var ForceGravity = gravitationalConstant * totalMassRocket * massEarth * (distanceBetween / Mathf.Pow(Mathf.Abs(distanceBetween), 3));
            return ForceGravity;
        }

    }
}
