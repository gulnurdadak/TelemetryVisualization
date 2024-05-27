using UnityEngine;

public class AttitudeConverter
{
    // Method to convert quaternion to Euler angles
    public Vector3 ConvertQuaternionToEulerAngles(TelemetryData data)
    {
        float e0 = data.quat_e0;
        float ex = data.quat_ex;
        float ey = data.quat_ey;
        float ez = data.quat_ez;

        // Convert quaternion to Euler angles
        float roll = Mathf.Atan2(2 * (e0 * ex + ey * ez), 1 - 2 * (ex * ex + ey * ey)) * Mathf.Rad2Deg;
        float pitch = Mathf.Asin(2 * (e0 * ey - ez * ex)) * Mathf.Rad2Deg;
        float yaw = Mathf.Atan2(2 * (e0 * ez + ex * ey), 1 - 2 * (ey * ey + ez * ez)) * Mathf.Rad2Deg;

        return new Vector3(roll, pitch, yaw);
    }
}
