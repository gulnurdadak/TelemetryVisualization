using System;
using UnityEngine;

[Serializable]
public class TelemetryData
{
    // Aerodynamic coefficients
    public float CL;  // Lift coefficient
    public float CD;  // Drag coefficient
    public float Cm;  // Pitch moment coefficient

    // NED coordinates and airspeed components
    public Vector3 nedCoordinates;  // NED (North-East-Down) frame coordinates
    public Vector3 airspeedComponents;  // Airspeed components in body frame

    // Telemetry data fields
    public float time_sn;  
    public float ctrlong; 
    public float ctrlr;  
    public float ax_m_s2;  
    public float ay_m_s2;  
    public float az_m_s2;  
    public float p_rad_s;  
    public float q_rad_s;  
    public float r_rad_s;  
    public float quat_e0;  
    public float quat_ex;  
    public float quat_ey;  
    public float quat_ez;  
    public float alpha_rad;  
    public float beta_rad;  
    public float tas_m_s;  
    public float de_rad;  
    public float dr_rad;  
    public float da_rad;  
    public float mass_kg;  
    public float thrust_N;  
    public float lat_rad;  
    public float lon_rad;  
    public float alt_m;  
}
