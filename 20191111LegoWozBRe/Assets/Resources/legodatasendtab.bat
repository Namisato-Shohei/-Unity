@echo off
adb push "text/LegoData.txt" /sdcard/Android/data/com.lego.lego/files
adb shell
cd /sdcard/Android/data/com.lego.lego/files 
mv LegoData. LegoData.txt
exit
