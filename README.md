# RunMultiApps

## 📝 Introduction
MultiFileRunner is a WinForms application that helps you run multiple executable files (.exe, .bat) simultaneously with a simple drag-and-drop interface.

## 🚀 Main Features
- Add files to the list and run them simultaneously.
- Drag and drop support to add or reorder files.
- Minimize to Taskbar and run in the background via Tray Icon.
- Saves the last run file list for convenience.
- Automatically closes running applications before clearing the list.
- Move the window by holding the title bar area.

## 🛠 Installation & Usage

### 1️⃣ Installation
#### Method 1: Run the .exe file directly
- Download `MultiFileRunner.exe` and run it directly.

#### Method 2: Build from source
Requirements: .NET 6.0 or higher
```sh
# Clone the repository
git clone https://github.com/your-repo/MultiFileRunner.git
cd MultiFileRunner

# Build the application
 dotnet publish -r win-x64 -c Release /p:PublishSingleFile=true /p:IncludeNativeLibrariesForSelfExtract=true
```
The single `.exe` file will be located in:
```
bin\Release\net6.0\win-x64\publish\MultiFileRunner.exe
```

### 2️⃣ Usage
1. Drag and drop `.exe` or `.bat` files into the list.
2. Click **Run** to execute all files.
3. Click **Clear** to remove files from the list (also closes running apps).
4. To **minimize** to the taskbar, click minimize or close the window, and the app will run in the Tray Icon.

## 📜 License
This project is licensed under the MIT License. Feel free to modify and use it as needed.

---

✨ Enjoy using MultiFileRunner! ✨

