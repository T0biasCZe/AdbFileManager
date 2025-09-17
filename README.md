# AdbFileManager    
Alternative for the MTP which is very slow. It uses adb protocol to copy files which is lot faster         
In my testing, the program copies files at speed of approximately 41.6MiB/s (332Mib/s) over USB 2.0, compared to MTP that copies at around 10Mb/s
![image](https://github.com/user-attachments/assets/c2571d20-c27c-4aa7-b450-5809223589ef)

Buy me a coffee: https://ko-fi.com/T0biasCZe 

**To use this app, you must have enabled USB Debugging in android developer settings.**        
After enabling it, just go to the directory from where you want to copy from/where to copy, select the file(s) and hit the arrow to the correct copy direction       

Note2: Its made in C# and Windows Forms. To put it on Linux/Mac I would completely have to rewrite it, so no Linux/Mac version

# This app requires .NET 8 Runtime to function   
64 bit: https://dotnet.microsoft.com/en-us/download/dotnet/thank-you/runtime-desktop-8.0.20-windows-x64-installer   
32 bit: https://dotnet.microsoft.com/en-us/download/dotnet/thank-you/runtime-desktop-8.0.20-windows-x86-installer    
ARM: https://dotnet.microsoft.com/en-us/download/dotnet/thank-you/runtime-desktop-8.0.20-windows-arm64-installer    

# basic controls:    
 * To enter a folder:
   * double click the folder with a left mouse button
   * or press enter on the gameboard
 * to go up a directory:
   * press backspace on the keyboard
   * or double click the header of the file list   
 ![This is the header](https://github.com/user-attachments/assets/ed947c01-e4a0-4374-8359-16f603f63601)
 * to copy files:
   * select the file(s) in you want to copy on the android side or the windows size, and then click the arrow button with the wanted direction



# Video tutorial:
[![Tutorial](https://i3.ytimg.com/vi/3_mgQWvYvE4/hqdefault.jpg)](https://youtu.be/3_mgQWvYvE4)

# Known bugs:
* Sometimes a folder is not shown

# Settings:  
***Keep file modified date***     
This keeps the file modification date of the file thats being copied, instead of changing it to the time when it was copied    
***Preview files on double click***  
When double clicking media file (video or photo), it will temporarily copy it to the PC and show it. When the program is closed, it will automatically delete the temporary file from PC.      
***Compatibility fix***        
This fixes files being shown on very old Android versions, which dont support the ls -l flag     


# FAQ:    
**Q**: I open the program but it instantly closes    
***A***: Make sure you are opening AdbFileManager.exe, and not adb.exe      
**Q**: Files are not showing
***A***: If you have phone with older android, enable compatibility mode
**Q**: What does Unwrap folder do?     
***A***: Instead of copying whole folder as 1 item, it loads the contents of that folder and copies each file in it separately, allowing for smoother progress bar. Disadvantage is that its almost 2x slower (still lot faster than MTP though)     
![UnwrapOnvsOff](https://github.com/user-attachments/assets/84847882-8283-4219-848b-e504edacc7df)

# Windows 7 compatibility
* The program works on Windows 7, but you need to install .NET 8 using VxKEX NEXT kernel extension.
* However, dark mode doesnt work, and it breaks the embeded Windows Explorer. Do not use!

## Star History

[![Star History Chart](https://api.star-history.com/svg?repos=T0biasCZe/AdbFileManager&type=Date)](https://star-history.com/#T0biasCZe/AdbFileManager&Date)
