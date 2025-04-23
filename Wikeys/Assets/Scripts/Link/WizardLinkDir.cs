using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class WizardLinkDir : EditorWindow {

    public string projectFolder = "\\[Themes]\\OneDrive";
    
    [Space (10), Header("Leave blank")]
    public string targetDir = "";
    public string localDir = "";


    [Space (10), TextArea(1, 3)]
    public string commandToCopyToTerminal = "";

    [Space (10), TextArea(1, 10)]
    public string INFOS = "";

    [MenuItem("Tools/Sym Link Directory", false, -80)]
    private static void ShowWindow() {
        var window = GetWindow<WizardLinkDir>();
        window.titleContent = new GUIContent("Sym Link Directory");
        window.Show();
    }
    
    void OnWizardOtherButton() {
        targetDir = EditorUtility.OpenFolderPanel("Onedrive Unity folder", targetDir, "").Replace('/', '\\');
        localDir = Application.dataPath.Replace('/', '\\')+projectFolder;
        commandToCopyToTerminal = "mklink /d \""+localDir+"\" \""+targetDir+"\"";
        INFOS = "After \"Pick Folder\" done: \nwin+R, type \"cmd\", press OK; \npaste and enter the command.";
        
        if(System.IO.Directory.Exists(localDir)) {
            // System.IO.Directory.CreateDirectory(localDir);
            INFOS = "!!! The local directory already exists !!!";
        }

        EditorGUIUtility.systemCopyBuffer = commandToCopyToTerminal;
    }

    private void OnGUI() {
    
        projectFolder = EditorGUILayout.TextField("Project Folder", projectFolder);

        if(GUILayout.Button("Pick Sources Folder")) {
            targetDir = EditorUtility.OpenFolderPanel("Onedrive (sync outside) folder", targetDir, "").Replace('/', '\\');
            localDir = Application.dataPath.Replace('/', '\\')+projectFolder;
            
            commandToCopyToTerminal = "mklink /d \""+localDir+"\" \""+targetDir+"\"";
            EditorGUIUtility.systemCopyBuffer = commandToCopyToTerminal;
        }
        
        commandToCopyToTerminal = "mklink /d \""+localDir+"\" \""+targetDir+"\"";
        commandToCopyToTerminal = EditorGUILayout.TextField("Terminal command", commandToCopyToTerminal);
        
        if(GUILayout.Button("Copy Again")) {
            EditorGUIUtility.systemCopyBuffer = commandToCopyToTerminal;
        }
        
        // if(GUILayout.Button("Create Batch File")) {
            // string batchFile = Application.dataPath.Replace('/', '\\') + "\\..\\link.bat";
            // System.IO.File.WriteAllText(batchFile, commandToCopyToTerminal);
            // INFOS = "Batch file created at: \n"+batchFile;
        // }
    }
}