using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class CarScript : MonoBehaviour
{

    [Header("Movement Settings")]
    [Tooltip("Top speed when moving")]
    public float topSpeed;

    [Tooltip("How fast the vehicle accelerates")]
    public float acceleration;

    [Min(0.001f), Tooltip("Top speed attainable when moving backward.")]
    public float reversingSpeed;

    [Tooltip("How quickly the vehicle starts accelerating from 0. A higher number means faster acceleration scaling")]
    public float accelerationCurve;

    [Tooltip("How quickly the vehicle will slow down when braking")]
    public float braking;

    [Tooltip("How quickly the vehicle will reach a full stop when left with no input")]
    public float coastingSlow;

    [Range(0.0f, 1.0f)]
    [Tooltip("The amount of side-to-side friction")]
    public float grip;

    [Tooltip("How tightly the kart can turn left or right")]
    public float steer;

    [Tooltip("Additional gravity for when the vehicle is airborne")]
    public float addedGrav;

    public Rigidbody rb;

    public float airPercent;

    public float groundPercent;

    [Header("Vehicle Physics")]
    [Tooltip("The transform for determinging the vehicles mass")]
    public Transform centreOfMass;

    [Range(0.0f, 20.0f), Tooltip("Coefficient used to reorient the vehicle in the air. The higher the number, the faster the vehicle will readjust itself along the horizontal plane")]
    public float airborneReorientationCoefficents = 3.0f;

    [Header("Drifting")]
    [Range(0.01f, 1.0f), Tooltip("The grip value when drifting")]
    public float driftGrip = 0.4f;
    [Range(0.0f, 10.0f), Tooltip("Additional steer when the vehicle is drifting.")]
    public float driftAdditionalSteer = 5.0f;
    [Range(1.0f, 30.0f), Tooltip("The higher the angle, the easier it is to regain full grip.")]
    public float minAngleToFinishDrift = 10.0f;
    [Range(0.01f, 0.99f), Tooltip("Minimum speed percentage to switch back to full grip")]
    public float minSpeedPerecentToFinishDrift = 0.5f;
    [Range(1.0f, 20.0f), Tooltip("The higher the value, the easier it is to control the drift steering.")]
    public float DriftControl = 10.0f;
    [Range(0.0f, 20.0f), Tooltip("The lower the value, the longer the drift will last without trying to control it by steering.")]
    public float driftDampening = 10.0f;

    [Header("VFX")]
    [Tooltip("VFX that will be placed on the wheels when drifting")]
    public GameObject driftTrailPrefab;

    //Put a value in the VFX header just to avoid leaving it empty

    [Header("GroundLayer")]
    public LayerMask groundLayers = Physics.DefaultRaycastLayers;

    const float k_NullInput = 0.01f;
    const float k_NullSpeed = 0.01f;
    Vector3 m_VerticalReference = Vector3.up; // Would like to avoid using this if I can


    public bool WantsToDrift = false;

    public bool IsDrifting = false;

    float m_CurrentGrip = 1.0f;
    float m_DriftTurningPower = 0.0f;
    float m_PreviousGroundPercent = 1.0f;


    bool canMove = true;

    Quaternion m_LastValidRotation;
    Vector3 m_LastValidPosition;
    Vector3 m_LastCollisionNormal;

    bool m_HasCollision;
    bool m_InAir = false;

    public void SetCanMove(bool move) => canMove = move;

    public float GetMaxSpeed() => Mathf.Max(topSpeed, reversingSpeed);

    //private void ActivateDriftVFX(bool active)

    void Awake()
    {
        rb = GetComponent<Rigidbody>();

        m_CurrentGrip = grip;



    }

    private void FixedUpdate()
    {
        
        



    }

}
