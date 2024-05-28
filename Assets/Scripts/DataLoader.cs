using SimpleFileBrowser;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DataLoader : MonoBehaviour
{
    // UI Elements
    public Button loadButton;
    public Text statusText;
    public GameObject airplanePrefab;
    private GameObject airplaneInstance;

    // UI elements for data display
    public Text TimeText;
    public Text LatitudeText;
    public Text LongitudeText;
    public Text AltitudeText;
    public Text RollText;
    public Text PitchText;
    public Text YawText;
    public Text AlphaText;
    public Text BetaText;
    public Text TASText;
    public Text CLText;
    public Text CDText;
    public Text CmText;
    public Text ThrustText;
    public Text MassText;
    public Slider playbackSlider;
    public Slider xAxisSlider;
    public Slider yAxisSlider;
    public Slider zAxisSlider;

    // Processor for telemetry data
    private TelemetryProcessor telemetryProcessor;
    private AerodynamicsCalculator aerodynamicsCalculator;
    private AttitudeConverter attitudeConverter;
    private CoordinateConverter coordinateConverter;
    private AirspeedCalculator airspeedCalculator;

    private List<TelemetryData> telemetryDataList;

    void Start()
    {
        telemetryProcessor = new TelemetryProcessor();
        aerodynamicsCalculator = new AerodynamicsCalculator();
        attitudeConverter = new AttitudeConverter();
        coordinateConverter = new CoordinateConverter();
        airspeedCalculator = new AirspeedCalculator();

        loadButton.onClick.AddListener(OnLoadButtonClicked);
        playbackSlider.onValueChanged.AddListener(OnSliderValueChanged);
        xAxisSlider.onValueChanged.AddListener(OnXAxisValueChanged);
        yAxisSlider.onValueChanged.AddListener(OnYAxisValueChanged);
        zAxisSlider.onValueChanged.AddListener(OnZAxisValueChanged);
    }

    void OnLoadButtonClicked()
    {
        // Set up file browser filters for CSV files
        FileBrowser.SetFilters(true, new FileBrowser.Filter("CSV Files", ".csv"));
        FileBrowser.SetDefaultFilter(".csv");

        FileBrowser.ShowLoadDialog((paths) =>
        {
            if (paths.Length > 0)
            {
                string path = paths[0];
                // Load telemetry data from the selected file
                telemetryDataList = telemetryProcessor.LoadData(path);
                if (telemetryDataList == null)
                {
                    statusText.text = "Invalid Dataset!";
                    return;
                }
                statusText.text = $"Data loaded successfully: {telemetryDataList.Count} records.";

                // Perform necessary calculations
                PerformCalculations(telemetryDataList);

                // Visualize the airplane using the loaded data
                VisualizeAirplane(telemetryDataList);

                // Set slider max value to the number of records
                playbackSlider.maxValue = telemetryDataList.Count - 1;
            }
            else
            {
                statusText.text = "File load canceled.";
            }
        },
        () => { statusText.text = "File load canceled."; },
        FileBrowser.PickMode.Files, false, null, "Select CSV File", "Select");
    }

    void PerformCalculations(List<TelemetryData> telemetryDataList)
    {
        foreach (var telemetryData in telemetryDataList)
        {
            // Calculate aerodynamic coefficients
            aerodynamicsCalculator.CalculateAerodynamicCoefficients(telemetryData);

            // Convert quaternion to Euler angles
            Vector3 eulerAngles = attitudeConverter.ConvertQuaternionToEulerAngles(telemetryData);

            // Convert coordinates to NED frame
            Vector3 nedCoordinates = coordinateConverter.ConvertToNED(telemetryData.lat_rad, telemetryData.lon_rad, telemetryData.alt_m);
            telemetryData.nedCoordinates = nedCoordinates;

            // Calculate airspeed components
            float alpha = telemetryData.alpha_rad;
            float beta = telemetryData.beta_rad;
            Vector3 airspeedComponents = airspeedCalculator.CalculateAirspeedComponents(telemetryData.tas_m_s, alpha, beta);
            telemetryData.airspeedComponents = airspeedComponents;
        }
    }

    void VisualizeAirplane(List<TelemetryData> data)
    {
        if (airplaneInstance != null)
        {
            Debug.Log("Destroying previous instance.");
            Destroy(airplaneInstance);
        }

        airplaneInstance = Instantiate(airplanePrefab);

        if (data.Count > 0)
        {
            // Set the airplane's position to the center of the canvas
            Vector3 centerPosition = new Vector3(704, 250, 0);
            airplaneInstance.transform.localPosition = centerPosition;

            UpdateAirplane(data[0]);
        }
        else
        {
            airplaneInstance.transform.localPosition = Vector3.zero;
        }

        // Set the airplane's scale (adjust as needed)
        airplaneInstance.transform.localScale = new Vector3(10, 16, -7);

        Debug.Log($"New instance created: {airplaneInstance.name}");

        // Ensure the airplane instance is active
        if (!airplaneInstance.activeSelf)
        {
            airplaneInstance.SetActive(true);
        }
    }

    void UpdateAirplane(TelemetryData telemetryData)
    {
        if (airplaneInstance == null)
        {
            Debug.LogError("Airplane instance is null!");
            return;
        }

        // Set the airplane's position to the center of the canvas
        Vector3 centerPosition = new Vector3(704, 250, 0);
        airplaneInstance.transform.localPosition = centerPosition;

        // Update the airplane's rotation using Euler angles
        Vector3 eulerAngles = attitudeConverter.ConvertQuaternionToEulerAngles(telemetryData);
        airplaneInstance.transform.localRotation = Quaternion.Euler(eulerAngles);

        // Log the position and rotation for debugging
        Debug.Log($"Position: {centerPosition}, Rotation: {eulerAngles}");

        // Update the data display
        UpdateDataDisplay(telemetryData);
    }

    void OnSliderValueChanged(float value)
    {
        int index = Mathf.RoundToInt(value);
        if (index >= 0 && index < telemetryDataList.Count)
        {
            // Update airplane with the selected telemetry data
            UpdateAirplane(telemetryDataList[index]);
        }
    }

    void UpdateDataDisplay(TelemetryData telemetryData)
    {
        TimeText.text = $"Time: {telemetryData.time_sn:F3} s";
        LatitudeText.text = $"Lat: {telemetryData.lat_rad:F3} rad";
        LongitudeText.text = $"Lon: {telemetryData.lon_rad:F3} rad";
        AltitudeText.text = $"Alt: {telemetryData.alt_m:F3} m";
        RollText.text = $"Roll: {telemetryData.quat_ex:F3} deg";
        PitchText.text = $"Pitch: {telemetryData.quat_ey:F3} deg";
        YawText.text = $"Yaw: {telemetryData.quat_ez:F3} deg";
        AlphaText.text = $"Alpha: {telemetryData.alpha_rad:F3} rad";
        BetaText.text = $"Beta: {telemetryData.beta_rad:F3} rad";
        TASText.text = $"TAS: {telemetryData.tas_m_s:F3} m/s";
        CLText.text = $"CL: {telemetryData.CL:F3}";
        CDText.text = $"CD: {telemetryData.CD:F3}";
        CmText.text = $"Cm: {telemetryData.Cm:F3}";
        ThrustText.text = $"Thrust: {telemetryData.thrust_N_1:F3} N";
        MassText.text = $"Mass: {telemetryData.mass_kg:F3} kg";
    }

    void OnXAxisValueChanged(float value)
    {
        if (airplaneInstance != null)
        {
            Vector3 rotation = airplaneInstance.transform.localEulerAngles;
            rotation.x = value;
            airplaneInstance.transform.localEulerAngles = rotation;
            Debug.Log($"Updated X Rotation: {rotation.x}");
        }
    }

    void OnYAxisValueChanged(float value)
    {
        if (airplaneInstance != null)
        {
            Vector3 rotation = airplaneInstance.transform.localEulerAngles;
            rotation.y = value;
            airplaneInstance.transform.localEulerAngles = rotation;
            Debug.Log($"Updated Y Rotation: {rotation.y}");
        }
    }

    void OnZAxisValueChanged(float value)
    {
        if (airplaneInstance != null)
        {
            Vector3 rotation = airplaneInstance.transform.localEulerAngles;
            rotation.z = value;
            airplaneInstance.transform.localEulerAngles = rotation;
            Debug.Log($"Updated Z Rotation: {rotation.z}");
        }
    }
}
