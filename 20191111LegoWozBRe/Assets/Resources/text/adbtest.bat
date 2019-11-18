@echo off
adb push "D:/0_Study/0_LegoUnity/20191025OpencvAndroidBuild/Assets/Resources/text/%1.txt" /sdcard/Android/data/com.Lego.Android/files
adb shell
cd /sdcard/Android/data/com.Lego.Android/files 
mv %1. %1.txt
exit




