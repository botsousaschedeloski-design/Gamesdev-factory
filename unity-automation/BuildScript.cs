using UnityEngine;
using UnityEditor;
using System;

/// <summary>
/// Script de build automático para Unity
/// Use via linha de comando
/// </summary>
public class BuildScript
{
    /// <summary>
    /// Build para Android via linha de comando
    /// </summary>
    public static void BuildAndroid()
    {
        string[] scenes = GetScenes();
        string outputPath = GetBuildOutputPath();
        
        BuildPlayerOptions buildPlayerOptions = new BuildPlayerOptions
        {
            scenes = scenes,
            locationPathName = outputPath,
            target = BuildTarget.Android,
            options = BuildOptions.None
        };
        
        // Configurar Android settings
        PlayerSettings.SetScriptingBackend(BuildTargetGroup.Android, ScriptingImplementation.IL2CPP);
        PlayerSettings.Android.targetArchitectures = AndroidArchitecture.ARM64;
        PlayerSettings.Android.minSdkVersion = AndroidSdkVersions.AndroidApiLevel26;
        
        BuildReport report = BuildPipeline.BuildPlayer(buildPlayerOptions);
        BuildSummary summary = report.summary;
        
        if (summary.result == BuildResult.Succeeded)
        {
            Debug.Log("✅ Build succeeded!");
        }
        else if (summary.result == BuildResult.Failed)
        {
            Debug.LogError("❌ Build failed!");
        }
    }
    
    /// <summary>
    /// Pega cenas do build
    /// </summary>
    static string[] GetScenes()
    {
        return new string[]
        {
            "Assets/Scenes/MainMenu.unity",
            "Assets/Scenes/Game.unity"
        };
    }
    
    /// <summary>
    /// Pega path de output do argumento de linha de comando
    /// </summary>
    static string GetBuildOutputPath()
    {
        string[] args = Environment.GetCommandLineArgs();
        for (int i = 0; i < args.Length; i++)
        {
            if (args[i] == "-buildOutput" && i + 1 < args.Length)
            {
                return args[i + 1];
            }
        }
        
        // Default
        return $"Builds/{PlayerSettings.productName}.apk";
    }
}
