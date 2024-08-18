using System.Collections;
using System.Collections.Generic;
using UnityEngine;

    [CreateAssetMenu(fileName = "GearSet", menuName = "ScriptableObjects/VehicleGear", order = 1)]
    public class VehicalGear : ScriptableObject
{
    public float x_Speed = 5f;
    
    public float y_Speed = 5f;

    public float speed_Limit = 45f;

    public float drag = 0.98f;

    public float traction = 1f;

    public float driftAccelRate = 15f;

    public float scale = 1f;

    public float gearCutoff = 30f;

}



