:: removes obsolete files left from previous versions



:: remove ProjectPath/Assets/Plugins/CodeAssist/Editor/ExternalReferences/Release/netstandard2.0/ directory files
:: with version UCA.v.1.1.9 and newer versions, they are located at ProjectPath/Assets/Plugins/CodeAssist/Editor/ExternalReferences
SET @filepath=%~dp0Editor\ExternalReferences\Release\netstandard2.0\
CALL :DeleteFileAndItsMeta "UnityCodeAssistSynchronizerModel.deps.json"
CALL :DeleteFileAndItsMeta "UnityCodeAssistSynchronizerModel.dll"
CALL :DeleteFileAndItsMeta "UnityCodeAssistSynchronizerModel.pdb"
CALL :DeleteFileAndItsMeta "UnityCodeAssistYamlDotNet.deps.json"
CALL :DeleteFileAndItsMeta "UnityCodeAssistYamlDotNet.dll"
CALL :DeleteFileAndItsMeta "UnityCodeAssistYamlDotNet.pdb"
CALL :DeleteFileAndItsMeta "UnityCodeAssistYamlDotNet.xml"

SET @filepath=%~dp0Editor\ExternalReferences\Release\netstandard2.0
CALL :DeleteFolderAndItsMeta
SET @filepath=%~dp0Editor\ExternalReferences\Release
CALL :DeleteFolderAndItsMeta



:: remove non-customized binary files
:: with version UCA.v.1.1.12, dll files has been customized (ex. AsyncIO.dll is now Meryel.UnityCodeAssist.AsyncIO.dll)
SET @filepath=%~dp0Editor\ExternalReferences\
CALL :DeleteFileAndItsMeta "AsyncIO.dll"
CALL :DeleteFileAndItsMeta "NaCl.dll"
CALL :DeleteFileAndItsMeta "NetMQ.dll"
CALL :DeleteFileAndItsMeta "Serilog.dll"
CALL :DeleteFileAndItsMeta "Serilog.Sinks.PersistentFile.dll"



:: remove system binary files
:: with Unity 2021.2 and newer, they are not needed anymore
SET @filepath=%~dp0Editor\ExternalReferences\
CALL :DeleteFileAndItsMeta "System.Buffers.dll"
CALL :DeleteFileAndItsMeta "System.Memory.dll"
CALL :DeleteFileAndItsMeta "System.Runtime.CompilerServices.Unsafe.dll"
CALL :DeleteFileAndItsMeta "System.Threading.Tasks.Extensions.dll"



EXIT /B 0



:DeleteFileAndItsMeta
::echo Deleting "%@filepath%%~1"
del "%@filepath%%~1" /F
del "%@filepath%%~1.meta" /F
EXIT /B 0



:DeleteFolderAndItsMeta
rd "%@filepath%" /Q
del "%@filepath%.meta" /F
EXIT /B 0
