using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;

public class TelemetryProcessor
{
    public List<TelemetryData> LoadData(string filePath)
    {
        List<TelemetryData> dataList = new List<TelemetryData>();
        using (StreamReader reader = new StreamReader(filePath))
        {

            reader.ReadLine();

            while (!reader.EndOfStream)
            {
                var line = reader.ReadLine();
                var values = line.Split(',');
                try
                {
                    TelemetryData data = new TelemetryData
                    {
                        time_sn = float.Parse(values[0], CultureInfo.InvariantCulture),
                        ctrlong = float.Parse(values[1], CultureInfo.InvariantCulture),
                        ctrlr = float.Parse(values[2], CultureInfo.InvariantCulture),
                        ax_m_s2 = float.Parse(values[3], CultureInfo.InvariantCulture),
                        ay_m_s2 = float.Parse(values[4], CultureInfo.InvariantCulture),
                        az_m_s2 = float.Parse(values[5], CultureInfo.InvariantCulture),
                        p_rad_s = float.Parse(values[6], CultureInfo.InvariantCulture),
                        q_rad_s = float.Parse(values[7], CultureInfo.InvariantCulture),
                        r_rad_s = float.Parse(values[8], CultureInfo.InvariantCulture),
                        quat_e0 = float.Parse(values[9], CultureInfo.InvariantCulture),
                        quat_ex = float.Parse(values[10], CultureInfo.InvariantCulture),
                        quat_ey = float.Parse(values[11], CultureInfo.InvariantCulture),
                        quat_ez = float.Parse(values[12], CultureInfo.InvariantCulture),
                        alpha_rad = float.Parse(values[13], CultureInfo.InvariantCulture),
                        beta_rad = float.Parse(values[14], CultureInfo.InvariantCulture),
                        tas_m_s = float.Parse(values[15], CultureInfo.InvariantCulture),
                        de_rad = float.Parse(values[16], CultureInfo.InvariantCulture),
                        dr_rad = float.Parse(values[17], CultureInfo.InvariantCulture),
                        da_rad = float.Parse(values[18], CultureInfo.InvariantCulture),
                        mass_kg = float.Parse(values[19], CultureInfo.InvariantCulture),
                        thrust_N_1 = float.Parse(values[20], CultureInfo.InvariantCulture),
                        lat_rad = float.Parse(values[21], CultureInfo.InvariantCulture),
                        lon_rad = float.Parse(values[22], CultureInfo.InvariantCulture),
                        alt_m = float.Parse(values[23], CultureInfo.InvariantCulture)
                    };

                    dataList.Add(data);
                }
                catch (Exception)
                {
                    return null;

                }

            }
        }

        return dataList;
    }
}
