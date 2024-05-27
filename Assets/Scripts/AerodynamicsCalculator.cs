using UnityEngine;

public class AerodynamicsCalculator
{
    // Method to calculate aerodynamic coefficients (CL, CD, Cm)
    public void CalculateAerodynamicCoefficients(TelemetryData data)
    {
        // Calculate lift coefficient (CL)
        data.CL = CalculateLiftCoefficient(data.tas_m_s);

        // Calculate drag coefficient (CD)
        data.CD = CalculateDragCoefficient(data.tas_m_s);

        // Calculate moment coefficient (Cm)
        data.Cm = CalculateMomentCoefficient(data.p_rad_s, data.q_rad_s, data.r_rad_s, data.mass_kg, data.tas_m_s, data.alpha_rad);
    }

    // Method to calculate lift coefficient (CL)
    private float CalculateLiftCoefficient(float velocity)
    {
        float airDensity = CalculateAirDensity();
        float liftForce = 0.5f * airDensity * Mathf.Pow(velocity, 2) * ReferenceArea; // Calculate lift force
        float liftCoefficient = liftForce / (airDensity * Mathf.Pow(velocity, 2) * ReferenceArea); // Calculate lift coefficient
        return liftCoefficient;
    }

    // Method to calculate drag coefficient (CD)
    private float CalculateDragCoefficient(float velocity)
    {       
        float dragCoefficient = 0.3f;
        return dragCoefficient;
    }

    // Method to calculate moment coefficient (Cm)
    private float CalculateMomentCoefficient(float p, float q, float r, float mass, float velocity, float alpha)
    {
        // As a simple example, i use a constant Cm coefficient.
        float momentCoefficient = 0.1f * alpha;
        return momentCoefficient;
    }

    private float CalculateAirDensity()
    {        
        // Standard atmosphere model can be used or another method can be applied
        return 1.225f;
    }
    
    private const float ReferenceArea = 0.55f;    
    private const float ReferenceLength = 0.19f;
}
