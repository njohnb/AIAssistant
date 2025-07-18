; Script generated by the Inno Setup Script Wizard.
; SEE THE DOCUMENTATION FOR DETAILS ON CREATING INNO SETUP SCRIPT FILES!

#define MyAppName "AIAssistant"
#define MyAppVersion "0.1.1a"
#define MyAppPublisher "VogueRogue"
#define MyAppURL "https://github.com/njohnb"
#define MyAppExeName "AIAssistant.exe"
#define MyAppAssocName MyAppName + " File"
#define MyAppAssocExt ".myp"
#define MyAppAssocKey StringChange(MyAppAssocName, " ", "") + MyAppAssocExt
#define PublishDir "C:\Projects\AiAssistant\AIAssistant\AIAssistant\bin\Release\net9.0-windows\publish"
#define AssetsDir "C:\Projects\AiAssistant\AIAssistant\Assets"
#define InstallerAssetsDir "C:\Projects\AiAssistant\AIAssistant\InstallerAssets"

[Setup]
; NOTE: The value of AppId uniquely identifies this application. Do not use the same AppId value in installers for other applications.
; (To generate a new GUID, click Tools | Generate GUID inside the IDE.)
AppId={{07F26C6C-6B84-42C4-8B46-23CDB34C0670}
AppName={#MyAppName}
AppVersion={#MyAppVersion}
;AppVerName={#MyAppName} {#MyAppVersion}
AppPublisher={#MyAppPublisher}
AppPublisherURL={#MyAppURL}
AppSupportURL={#MyAppURL}
AppUpdatesURL={#MyAppURL}
DefaultDirName={userappdata}\{#MyAppName}
UninstallDisplayIcon={app}\{#MyAppExeName}
; "ArchitecturesAllowed=x64compatible" specifies that Setup cannot run
; on anything but x64 and Windows 11 on Arm.
ArchitecturesAllowed=x64compatible
; "ArchitecturesInstallIn64BitMode=x64compatible" requests that the
; install be done in "64-bit mode" on x64 or Windows 11 on Arm,
; meaning it should use the native 64-bit Program Files directory and
; the 64-bit view of the registry.
ArchitecturesInstallIn64BitMode=x64compatible
ChangesAssociations=yes
DisableProgramGroupPage=yes
; Uncomment the following line to run in non administrative install mode (install for current user only).
PrivilegesRequired=none
PrivilegesRequiredOverridesAllowed=dialog
OutputDir=C:\Projects\AIAssistant\Installers
OutputBaseFilename=AIAssistant_UNTESTED
SetupIconFile=C:\Projects\AiAssistant\AIAssistant\Assets\AIAssistant.ico
SolidCompression=yes
WizardStyle=modern

[Languages]
Name: "english"; MessagesFile: "compiler:Default.isl"

[Tasks]
Name: "desktopicon"; Description: "{cm:CreateDesktopIcon}"; GroupDescription: "{cm:AdditionalIcons}"; Flags: unchecked
Name: "startup"; Description: "Start {#MyAppName} when Windows starts"; GroupDescription: "Startup options"; Flags: checkedonce

[Files]
Source: "{#AssetsDir}\AIAssistant.ico"; DestDir: "{app}"; Flags: ignoreversion
Source: "{#PublishDir}\*"; DestDir: "{app}"; Flags: ignoreversion recursesubdirs createallsubdirs
Source: "{#InstallerAssetsDir}\ServerRegistrationManager.exe"; DestDir: "{app}"; Flags: ignoreversion uninsneveruninstall
Source: "{#PublishDir}\SharpShell.dll"; DestDir: "{app}"; Flags: ignoreversion
Source: "{#PublishDir}\ContextMenu.dll"; DestDir: "{app}"; Flags: ignoreversion
; NOTE: Don't use "Flags: ignoreversion" on any shared system files

[Registry]
Root: HKCU; Subkey: "Software\Classes\{#MyAppAssocExt}\OpenWithProgids"; ValueType: string; ValueName: "{#MyAppAssocKey}"; ValueData: ""; Flags: uninsdeletevalue
Root: HKCU; Subkey: "Software\Classes\{#MyAppAssocKey}"; ValueType: string; ValueName: ""; ValueData: "{#MyAppAssocName}"; Flags: uninsdeletekey
Root: HKCU; Subkey: "Software\Classes\{#MyAppAssocKey}\DefaultIcon"; ValueType: string; ValueName: ""; ValueData: "{app}\{#MyAppExeName},0"
Root: HKCU; Subkey: "Software\Classes\{#MyAppAssocKey}\shell\open\command"; ValueType: string; ValueName: ""; ValueData: """{app}\{#MyAppExeName}"" ""%1"""
Root: HKCU; Subkey: "Software\Microsoft\Windows\CurrentVersion\Run"; ValueType: string; ValueName: "{#MyAppName}"; ValueData: """{app}\{#MyAppExeName}"""; Flags: uninsdeletevalue; Tasks: startup

[Icons]
Name: "{autoprograms}\{#MyAppName}"; Filename: "{app}\{#MyAppExeName}"; IconFilename: "{app}\AIAssistant.ico"
Name: "{autodesktop}\{#MyAppName}"; Filename: "{app}\{#MyAppExeName}"; IconFilename: "{app}\AIAssistant.ico"; Tasks: desktopicon

[Run]
Filename: "{app}\{#MyAppExeName}"; Description: "{cm:LaunchProgram,{#StringChange(MyAppName, '&', '&&')}}"; Flags: nowait postinstall skipifsilent
Filename: "cmd.exe"; Parameters: "/c """"{app}\ServerRegistrationManager.exe"" install ""{app}\ContextMenu.dll"" -codebase -s > ""{app}\reg_log.txt"" 2>&1"""; StatusMsg: "Registering shell extension..."; Flags: runhidden

[UninstallRun]
Filename: "cmd.exe"; Parameters: "/c """"{app}\ServerRegistrationManager.exe"" uninstall ""{app}\ContextMenu.dll"" -s > ""{app}\unregister_log.txt"" 2>&1"""; Flags: runhidden

[UninstallRun]
Filename: "taskkill.exe"; Parameters: "/f /im explorer.exe"; Flags: runhidden

[UninstallRun]
Filename: "cmd.exe"; Parameters: "/c ping 127.0.0.1 -n 3 > nul && start explorer.exe"; Flags: runhidden

[UninstallDelete]
Type: filesandordirs; Name: "{app}"



