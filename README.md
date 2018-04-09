# Csharp-HMI-WaterTower
HMI Water Tower

Human Machine Interface built for a model of a water tower.  
Program written in C#/.NET for Windows

## Tags
HMI, C#, .NET, event, OOP, geii-lab-ars4

## Project description

### Purpose
This project is intended for Object Oriented Programming learning, especially event programming languages, like Java or C# are.

For this project, we have an industrial PLC (Programmable Logic Controller) from Schneider Electric which is able to control a model of a water tower.

Here an image showing the real model:  
![Water tower model](/images/WaterTowerModel.jpg)

The goal is to build a C#/.NET Windows application to control this machine and have a feedback on the overall operation of the machine. This principle is called supervision.  

### Main features
The basic things about supervision is to act on actuators and view the state of all the sensors, all of that completely remotely. But with a lot of devices, the user interface can become easily very confused and difficult to use. That why a user interface has to be well structured and also visual, with schemes and colors about the real machine.

This application, with a graphical user interface (GUI), is built on MVC model, for Model-View-Controller. This model is commonly used where a controller update a user interface (as View) with some data from a model. Here is our example.

### Overview of the process
Here is an overview of the process about how the user interface can get and set data to the machine. Note that this can only happen when the OPC proxy is connected to the OFS server, and the PLC is connected to the network.  
![Overview of the process](/images/ProcessOverview.png)

### Technologies and models used
1. **Model**: the machine is composed of a pump (with its speed variator from Telemecanique) and a PLC from Schneider. The PLC, coded with a Grafcet or Ladder language, can control the hardware of the machine. So, our application will be able to communicate with the PLC through an OFS server thanks to a COM object (here SAOFSGRPXLib), working with .NET framework

2. **View**: this is my graphical user interface, so what the user see and where he can act

3. **Controller**: this is the main part of the application, because this is the interface between the interface and the hardware controller. Here it's called the OPC Proxy. When a variable is updated from the sensor, the PLC send it to the OFS server, then the OPC Proxy get this value and send it to the UI where finally the user can see it, as a number, a light, a color, a text, a sound, etc.

And the same in the other side. When the user want to act on some actuator, the controller receiver this order, control if it is possible to do it or not (active security), then transfer to the PLC which finally decide to apply this action or not (passive security).

By the way, with such a structure, the same OPC Proxy can be done for different user interfaces, always keeping the installation safe.

### Screenshots
Here a screenshot of the main interface, currently connected to the server:  
![Main interface](/images/MainUI_connected2.png)

Here the connection page:  
![Connection page](/images/ConnectionManager.png)

> See other images in `/images/`.

When a error occurred, if it's not coming from the user interface, that means there is a problem about the connection between the OPC Proxy and the OFS server. So for security reasons, I programmed the controller to automatically disconnect the server and ask the user to connect again after solving the problem.

## Progress (for longer works)

### What works
Nowadays, end of March 2017, the application is able to run safely. My OPC Proxy API is working well, and prevent UI update failure by disconnecting the server.

Also if the library is not found, the program won't crash but display a message that it's impossible to create the proxy.

### Known issues
Today, there are no critical issues in this program, but some elements are not working in the interface.

- [ ] For example, the refresh button, but this is useless because the controller automatically update the UI.

- [ ] Another thing, more annoying, is the automatic mode. When we enable this mode from the user interface, the slider for the automatic order is enabled but the machine doesn't do the correct thing and keep the pump at the maximum value.
All the other functions are working well, especially in manual mode. Sensors are also correctly updated on the scheme (right part of the UI)

### Improvements
Some improvements can be done on this application.

* **On user interface (view):**  

1. Make the connection page more user friendly

2. Make the automatic mode working (see with the PLC program how to do it)

* **On OPC Proxy (controller):**

1. Put all the variables in a table or a collection, instead of creating a lot one line for each in the write() and getValue() methods.

## How to use this repo?
This project was done for a specific machine in my university. You can run the program, it will work but it won't be able to control anything because you need the machine and its virtual environment.
So to be able to test all the features of my program, open it in IUT Annecy (French university), in GEII department.

### As final user
1. Download the latest release from Github as .zip file

2. Extract it on a computer connected to the network where the machine is

3. Run the virtual machine where the drivers and frameworks are (still in Windows XP, because drivers are old and not available for Windows NT 6.0 or later)

4. Create the OFS server and the PLC link by importing the `/ofs-config-file/OFSConfigurationTool.xml` to the OFS server configuration tool

5. Check that the PLC program `pontc163ars4.stu` (`/ofs-config-file/` in my repo) is correctly found in the configuration page

6. Save the configuration

7. Open my program `/app-bin-real/HmiWaterTower.exe`

8. Connect the server and the PLC, and enjoy :)

### As developer
1. Download the repo

2. Use *Windows XP* and *.NET framework v3.5*

3. Put all media files from `/media/*` into `/src/Resources`.  
**All resource files must be in this directory before opening the project, DO NOT MAKE SUBFOLDERS INTO THIS BEFORE OPENING FOR THE FIRST TIME.**

> **Note:** All pictograms I created are included in this software, and are provided for free.  
> If you want to use them with your own software, please respect the license (you can find it near to the image files) and name the original copyright.  
> Also, you do not have the right to sell them, you have to provide them for free only.  
> Thank you for your understanding.  

4. Open `HmiWaterTower.sln` (in `/src-csharp/`) in *Microsoft Visual Studio*. If you are not using this IDE, you can import all ".cs" files and "Resources" directory in a new "C#/.NET with GUI" project.

5. Import the library "SAOFSGRPXLib.dll" to your COM reference library in your IDE, like Visual Studio

6. Add the "SAOFSGRPXLib.dll" as a reference in your project

7. If you want to test the application without the library, rename:  
    * `COPCProxy.cs` into `COPCProxy.cs.BAK`  
    * `COPCProxy.cs.SIMULATION"` into `COPCProxy.cs`  

## Credits
This work was done as part of a university project.

Done by **Maxime Marmont**, 2nd-year student in a 2-year university degree in Electrical Engineering and Computer Science (DUT GEII, Génie Electrique et Informatique Industrielle) in IUT Annecy, France.

Thanks to the teachers, Eric BENOIT and Stephane BERTRAND for their help.

March 2017

## Copyright/license
MIT License  
Copyright © 2017 Maxime MARMONT
