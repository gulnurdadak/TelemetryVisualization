Telemetry Visualization Project
---------------------------------
##Table of Contents

-Description

-Features

-Requirements

-Installation

-Usage

-Project Structure

-----------------------------------------------------------------

##Description

The Airplane Visualization Tool is a Unity-based application designed for visualizing airplane telemetry data from a CSV file.
This tool allows users to load a CSV file containing telemetry data and visualize the movement and orientation of an airplane model based on the provided data. 
The application features interactive controls, including time, x, y, and z sliders, to manipulate the airplane's movement and orientation in real-time.


-----------------------------------------------------------------

##Features

-Load and visualize telemetry data from CSV files.

-Calculate aerodynamic coefficients (CL, CD, Cm) based on telemetry data.

-Convert quaternion data to Euler angles for easier interpretation.

-Transform geographic coordinates to the NED (North-East-Down) frame.

-Visualize the airplane's position, orientation, and other flight parameters.

-Interactively playback telemetry data using a slider.

-----------------------------------------------------------------

##Requirements


-Unity 2022 or higher(This project was created by Unity version 2022.3)

-CSV file containing valid telemetry data

-SimpleFileBrowser for Unity

-CSV file containing flight telemetry data

-C# programming knowledge (for understanding and modifying the source code)

-----------------------------------------------------------------

##Installation


-Clone the repository to your local machine:

--> git clone https://github.com/gulnurdadak/TelemetryVisualization.git

-Open the project in Unity.

-Import the SimpleFileBrowser asset into your project (available from the Unity Asset Store).

-----------------------------------------------------------------

##How to Use


-Load Data:

Upon launching the application, you will see a button labeled "LOAD DATA."
Click on this button to open a file browser and select a CSV file containing telemetry data.
If the file is valid, the airplane model will be instantiated and visualized based on the data.
If the file is invalid, an error message "Dataset invalid!" will be displayed, and the sliders will be disabled.


-Time Slider:

Use the time slider to move through the telemetry data from the start (time 0) to the end.
As you move the slider, the airplane model will update its position and orientation based on the corresponding time data from the CSV file.
In the bottom left corner of the screen, you will see a visualization of various telemetry parameters updating in real-time as the time slider is moved.


-X, Y, Z Sliders:

The x, y, and z sliders allow you to adjust the airplane's position on the respective axes within a range of 0 to 1.
Moving these sliders will dynamically update the airplane's position on the screen, allowing for a more detailed examination of its orientation and movement.


-Handling Invalid Data:

If an invalid CSV file is loaded, a "Dataset invalid" error message will appear.
All sliders (time, x, y, z) will be disabled to prevent further interaction.
To continue, load a valid CSV file using the "LOAD DATA" button. Once a valid file is loaded, the sliders will be re-enabled, and the visualization will resume.

-----------------------------------------------------------------


##Project Structure


-Assets/Scripts: Contains all the C# scripts for data processing, visualization, and UI interaction.


-AerodynamicsCalculator.cs: Calculates aerodynamic coefficients (CL, CD, Cm).

-DataLoader.cs: Handles loading and processing of telemetry data from CSV files.

-TelemetryProcessor.cs: Parses the telemetry data from the CSV file.

-AttitudeConverter.cs: Converts quaternion data to Euler angles.

-CoordinateConverter.cs: Converts geographic coordinates to the NED frame.

-AirspeedCalculator.cs: Calculates airspeed components.

-Assets/Hessburg-Stealth Bomber: Contains the Bomber prefab used for visualization.

-Assets/Plugins/SimpleFileBrowser: Contains the FileBrowser for loading data and displaying telemetry information.




