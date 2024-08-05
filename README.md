# AdbFileManager
Alternative for the MTP which is slow AF. It uses adb protocol to copy files which is lot faster
![image](https://github.com/T0biasCZe/AdbFileManager/assets/44525446/2a8f39f7-c377-4c90-b094-fb9e4d3808b1)

To use this app, you must have enabled USB Debugging in android developer settings.     
After enabling it, just go to the directory from where you want to copy from/where to copy, select the file(s) and hit the arrow to the correct copy direction       
Note: to go up a directory, double click the file header!

Note2: Its made in C# and Windows Forms. To put it on Linux/Mac I would completely have to rewrite it, so no Linux/Mac version

# This app requires .NET 8 Runtime to function   
64 bit: https://dotnet.microsoft.com/en-us/download/dotnet/thank-you/runtime-desktop-8.0.7-windows-x64-installer    
32 bit: https://dotnet.microsoft.com/en-us/download/dotnet/thank-you/runtime-desktop-8.0.7-windows-x86-installer    
ARM: https://dotnet.microsoft.com/en-us/download/dotnet/thank-you/runtime-desktop-8.0.7-windows-arm64-installer    

# controls:    
 double click folder to go in it    
 double click header to go back a directory    
 click the arrow buttons between the two file explorers to copy file in that direction    
 
 press up/down cursor keys to change selected file/directory in list    
 press enter to go to currently selected directory    
 press backspace to go up a directory

## Star History

[![Star History Chart](https://api.star-history.com/svg?repos=T0biasCZe/AdbFileManager&type=Date)](https://star-history.com/#T0biasCZe/AdbFileManager&Date)

# FAQ:    
**Q**: I open the program but it instantly closes    
***A***: Make sure you are opening AdbFileManager.exe, and not adb.exe      
**Q**: What does Unwrap folder do?     
***A***: Instead of copying whole folder as 1 item, it loads the contents of that folder and copies each file in it separately, allowing for smoother progress bar. Disadvantage is that its almost 2x slower (still lot faster than MTP though)     
![UnwrapOnvsOff](https://github.com/user-attachments/assets/84847882-8283-4219-848b-e504edacc7df)
