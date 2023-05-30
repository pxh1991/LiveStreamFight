using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using UnityEditor;
using UnityEngine;

public class ExportMenu : Editor
{
    private static readonly string protoExePath = $"{Application.dataPath}/../Tools/protoc/bin/protoc.exe";
    private static readonly string sourceProtoFilePath = $"{Application.dataPath}/Scripts/Network/ProtoFiles";
    private static readonly string targetCsPath = $"{Application.dataPath}/Scripts/Network/ProtoCode";
    
    [MenuItem("Tools/Export Proto")]
    public static void ExportProtoCs()
    {
        var allFile = new DirectoryInfo(sourceProtoFilePath).GetFiles("*.proto");
        var cmd = $"-I={sourceProtoFilePath} --csharp_out={targetCsPath}";
        foreach (var perFile in allFile)
        {
            Process.Start(protoExePath, $"{cmd} {perFile.Name}");
        }

    }
}
