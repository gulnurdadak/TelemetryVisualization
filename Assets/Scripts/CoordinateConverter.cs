using UnityEngine;

public class CoordinateConverter
{
    // Method to convert latitude, longitude, and altitude to NED coordinates
    public Vector3 ConvertToNED(float latitude, float longitude, float altitude)
    {
        // For simplicity, assuming a flat earth model
        // Convert latitude and longitude to meters (1 degree of latitude/longitude ≈ 111 km)
        float x = latitude * 111000;
        float y = longitude * 111000;
        float z = altitude;

        return new Vector3(x, y, z);
    }
}
