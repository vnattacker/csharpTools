# RunMultiApps

## 📝 Giới thiệu
MultiFileRunner là một ứng dụng WinForms giúp bạn chạy nhiều tệp thực thi cùng lúc (.exe, .bat) với giao diện kéo thả đơn giản.

## 🚀 Tính năng chính
- Thêm tệp vào danh sách và chạy đồng thời.
- Hỗ trợ kéo thả để thêm hoặc sắp xếp thứ tự tệp.
- Thu nhỏ xuống thanh Taskbar và chạy ngầm dưới Tray Icon.
- Lưu lại danh sách các tệp đã chạy lần cuối cùng.
- Tự động đóng ứng dụng đang chạy trước khi xóa danh sách.
- Di chuyển cửa sổ bằng cách giữ vào khu vực tiêu đề.

## 🛠 Cài đặt và sử dụng

### 1️⃣ Cài đặt
#### Cách 1: Chạy file .exe trực tiếp
- Tải xuống file `MultiFileRunner.exe` và chạy trực tiếp.

#### Cách 2: Build từ source
Yêu cầu: .NET 6.0 trở lên
```sh
# Clone repo về máy
git clone https://github.com/your-repo/MultiFileRunner.git
cd MultiFileRunner

# Build ứng dụng
 dotnet publish -r win-x64 -c Release /p:PublishSingleFile=true /p:IncludeNativeLibrariesForSelfExtract=true
```
File `.exe` duy nhất sẽ nằm trong thư mục:
```
bin\Release\net6.0\win-x64\publish\MultiFileRunner.exe
```

### 2️⃣ Cách sử dụng
1. Kéo thả tệp `.exe` hoặc `.bat` vào danh sách.
2. Nhấn nút **Run** để chạy tất cả.
3. Nhấn **Clear** để xóa danh sách (cũng đóng các app đang chạy).
4. Để **thu nhỏ** xuống thanh taskbar, nhấn nút minimize hoặc đóng cửa sổ, app sẽ chạy trong Tray Icon.

## 📜 Giấy phép
Dự án này sử dụng giấy phép MIT License. Bạn có thể chỉnh sửa và sử dụng tùy ý.

---

✨ Chúc bạn sử dụng vui vẻ! ✨

---

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

