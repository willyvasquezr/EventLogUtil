# EventLogUtil
Create a log and multiple sources in the event viewer

## To configure 
Open the EventLogUtil.exe.config and change this 2 properties:

```XML
<applicationSettings>
    <EventLogUtil.Settings>
      <setting name="LogName" serializeAs="String">
        <value>LogName</value>
      </setting>
      <setting name="SourcesNames" serializeAs="String">
        <value>Source1,Source2</value>
      </setting>
    </EventLogUtil.Settings>
  </applicationSettings>
```

## To run
Open a cmd window as administrator

To install: EventLogUtil /i

To uninstall: EventLogUtil /u

###Thanks to https://github.com/sarayG 
