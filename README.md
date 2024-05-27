Telemetry Visualization Project
---------------------------------
Table of Contents

-Introduction
-Features
-Requirements
-Installation
-Usage
-Project Structure
-Contributing
-License

----------------------------------
Introduction


The Telemetry Visualization Project is a Unity-based application designed to visualize flight telemetry data from CSV files. 
The project includes features such as aerodynamic coefficient calculations, attitude conversion, coordinate conversion, and airspeed calculations. 
It also allows users to visualize and playback the telemetry data interactively.


----------------------------------
Features

-Load and visualize telemetry data from CSV files.
-Calculate aerodynamic coefficients (CL, CD, Cm) based on telemetry data.
-Convert quaternion data to Euler angles for easier interpretation.
-Transform geographic coordinates to the NED (North-East-Down) frame.
-Visualize the airplane's position, orientation, and other flight parameters.
-Interactively playback telemetry data using a slider.

--------------------------------------

Requirements


-Unity 2021.1 or later
-SimpleFileBrowser for Unity
-CSV file containing flight telemetry data
-C# programming knowledge (for understanding and modifying the source code)

-------------------------------------

Installation


-Clone the repository to your local machine:
git clone https://github.com/gulnurdadak/TelemetryVisualization.git

-Open the project in Unity.
-Import the SimpleFileBrowser asset into your project (available from the Unity Asset Store).

---------------------------------------

Usage


-Loading Telemetry Data:

Click the "Load" button to open the file browser.
Select a CSV file containing the telemetry data.
The application will load and process the data, displaying a message with the number of records loaded.


-Visualizing the Bomber:

The application will instantiate an Bomber model based on the loaded data.
The Bomber's position, orientation, and scale will be set according to the telemetry data.
The camera will automatically move to focus on the Bomber's position.


-Data Playback:

Use the playback slider to interactively view different records from the telemetry data.
The Bomber's state will update according to the selected record.

------------------------------------------


Project Structure


--Assets/Scripts: Contains all the C# scripts for data processing, visualization, and UI interaction.
-AerodynamicsCalculator.cs: Calculates aerodynamic coefficients (CL, CD, Cm).
-DataLoader.cs: Handles loading and processing of telemetry data from CSV files.
-TelemetryProcessor.cs: Parses the telemetry data from the CSV file.
-AttitudeConverter.cs: Converts quaternion data to Euler angles.
-CoordinateConverter.cs: Converts geographic coordinates to the NED frame.
-AirspeedCalculator.cs: Calculates airspeed components.
-Assets/Hessburg-Stealth Bomber: Contains the Bomber prefab used for visualization.
-Assets/Plugins/SimpleFileBrowser: Contains the FileBrowser for loading data and displaying telemetry information.

---------------------------------------

License
This project is licensed under the MIT License. See the LICENSE file for details.

