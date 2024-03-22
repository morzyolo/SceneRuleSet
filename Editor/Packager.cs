using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using UnityEditor;
using UnityEngine;

public static class Packager
{
    private const string s_root = "SceneRuleSet/SceneRuleSet";

    private static readonly HashSet<string> s_fileExtensions = new(){
            ".cs",
            ".meta",
            ".asmdef",
            ".json",
            ".uss",
            ".uxml",
            ".txt",
        };

    public static void Export()
    {
        string path = Path.Combine(Application.dataPath, s_root);
        var assets = Directory
            .EnumerateFiles(path, "*", SearchOption.AllDirectories)
            .Where(x => HasRequiredExtension(x))
            .Select(x => "Assets" + x.Replace(Application.dataPath, "").Replace(@"\", "/"))
            .ToArray();

        Debug.Log("Export below files" + Environment.NewLine + string.Join(Environment.NewLine, assets));

        string version = GetVersion(s_root);
        string fileName = GetFileName(version);
        string exportPath = "./" + fileName;
        AssetDatabase.ExportPackage(assets, exportPath, ExportPackageOptions.Default);

        Debug.Log("Export complete: " + Path.GetFullPath(exportPath));
    }

    private static string GetVersion(string path)
    {
        string version = Environment.GetEnvironmentVariable("UNITY_PACKAGE_VERSION");
        string versionJson = Path.Combine(Application.dataPath, path, "package.json");

        if (!File.Exists(versionJson))
            return version;

        VersionJson versionObject = JsonUtility.FromJson<VersionJson>(File.ReadAllText(versionJson));

        if (!string.IsNullOrEmpty(version) && (versionObject.version != version))
        {
            var message = $"package.json and environment version are mismatched. UNITY_PACKAGE_VERSION:{version}, package.json:{versionObject.version}";

            if (Application.isBatchMode)
            {
                Console.WriteLine(message);
                Application.Quit(1);
            }

            throw new Exception(message);
        }

        version = versionObject.version;

        return version;
    }

    private static string GetFileName(string version)
    {
        return string.IsNullOrEmpty(version) ?
            "SceneRuleSet.unitypackage"
            : $"SceneRuleSet.{version}.unitypackage";
    }

    private static bool HasRequiredExtension(string path)
    {
        return s_fileExtensions.Contains(Path.GetExtension(path));
    }

    public class VersionJson
    {
        public string version;
    }
}
