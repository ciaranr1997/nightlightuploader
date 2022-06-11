# nightlightuploader
An automatic uploader for screenshots in nightlight.gg
Listens for any new files created in a specified directory.
If built manually needs an App.config file in the same directory as the exe with:
````
<?xml version="1.0"?>
<configuration>
  <appSettings>
    <add key="api_key" value="API Key from the website" />
    <add key="default_location" value="Location of the screenshots folder"/>
  </appSettings>
</configuration>
````