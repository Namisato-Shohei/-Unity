@echo off
adb push "text/LegoData.txt" /sdcard/Android/data/com.lego.wozbre/files
adb shell
cd /sdcard/Android/data/com.lego.wozbre/files 
mv LegoData. LegoData.txt
exit
