# ESPMultiOTA


Makes it easy to flash multiple ESPs via OTA Update at once.

Searches for any arduino OTA device which is ready and broadcast mdns.


## Arduino IDE Setup

- Put **ESPMultiOTA.exe** and **.dlls**  to AppData\Local\Arduino15\packages\esp8266\hardware\esp8266\3.0.2\tools 
- Change this parameter in `platform.txt` (*AppData\Local\Arduino15\packages\esp8266\hardware\esp8266\3.0.2*)
- Restart IDE
- Select any remote port
- Hit upload

```
tools.esptool.upload.network_pattern="{runtime.platform.path}/tools/ESPMultiOTA.exe" "{build.path}/{build.project_name}.bin"
```
