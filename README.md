# Virtual Machine Simulator (WPF - C#)

A simple simulation of an industrial machine control panel with both **manual** and **timer-based** operation modes. Built using **C# and WPF**, this project demonstrates logic handling, UI interaction, and real-world industrial automation concepts — even without hardware.

## 🚀 Features

- 🟢 **Manual Start Mode**  
  Start the machine and track the elapsed runtime.

- ⏱️ **Timer Mode**  
  Set a duration and simulate a countdown-based machine operation.

- 📊 **Session Summary**  
  After stopping the machine (in either mode), the last session time is shown on the main screen.

- ⛔ **Force Stop**  
  User can stop the machine manually at any time, even in timer mode.

## 🖼️ Screenshots

![image](https://github.com/user-attachments/assets/43a71c9d-0311-4479-a118-0294f2da2a0b)
![image](https://github.com/user-attachments/assets/0773e076-218e-41b9-9f23-ecfd4666f350)
![image](https://github.com/user-attachments/assets/04970581-110e-43a6-a06b-606c0f521458)



| Main Window              | Machine Running (Manual)     | Machine Running (Timer)      |
|--------------------------|------------------------------|-------------------------------|
| `Start Machine (Manual Mode` or `Set Timer)`   | Shows elapsed time           | Shows countdown timer         |
| Shows last session time  |                              |                               |

## 🛠️ Technologies

- C#
- WPF (Windows Presentation Foundation)
- .NET (Framework or Core)
- XAML for UI design

## 🧑‍💻 How to Run

1. **Clone the repository**
   ```bash
   git clone https://github.com/yourusername/virtual-machine-simulator.git

2. **Open In Visual Studio Code**

    - Use Visual Studio (not VS Code for WPF).
   
    - Open the .sln file.

4. **Build and Run**

    Press F5 to build and run the application.

## 📂 Project Structure

VirtualMachineSimulator/
│

├── MainWindow.xaml            # Main menu with mode selection

├── MachinePage.xaml           # Machine operation page

├── MachineState.cs            # Static state management (last session duration)

├── App.xaml.cs                # Entry point

└── README.md


## 💡 Possible Improvements

- Store session logs to a .txt file.
- Add visual indicators (like LED lights or icons).
- Add simulation of hardware input/output (sensors, actuators).
- Export session data to CSV.
