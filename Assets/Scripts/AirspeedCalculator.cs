using UnityEngine;

public class AirspeedCalculator
{
    // Method to calculate airspeed components (u, v, w) from true airspeed and angles
    public Vector3 CalculateAirspeedComponents(float trueAirspeed, float alpha, float beta)
    {
        // Convert angles to radians
        float alphaRad = Mathf.Deg2Rad * alpha;
        float betaRad = Mathf.Deg2Rad * beta;

        // Calculate airspeed components
        float u = trueAirspeed * Mathf.Cos(alphaRad) * Mathf.Cos(betaRad);
        float v = trueAirspeed * Mathf.Sin(betaRad);
        float w = trueAirspeed * Mathf.Sin(alphaRad) * Mathf.Cos(betaRad);

        return new Vector3(u, v, w);
    }
}
