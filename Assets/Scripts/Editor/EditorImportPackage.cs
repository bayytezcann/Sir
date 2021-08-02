using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class EditorImportPackage : EditorWindow
{
    [MenuItem("Prototype/Helper/Camera Follow")]
    public static void ImportCameraFollowController()
    {
        if (ShowDisplayDialog())
        {
            ImportPackage("CameraFollow");
        }
    }
    
    [MenuItem("Prototype/Helper/Parabola")]
    public static void ImportParabolaController()
    {
        if (ShowDisplayDialog())
        {
            ImportPackage("Parabola");
        }
    }
    
    [MenuItem("Prototype/Helper/Swipe Runner")]
    public static void ImportSwipeRunnerController()
    {
        if (ShowDisplayDialog())
        {
            ImportPackage("SwipeRunner");
        }
    }
    
    [MenuItem("Prototype/Helper/Swipe Object")]
    public static void ImportSwipeObjectController()
    {
        if (ShowDisplayDialog())
        {
            ImportPackage("SwipeObject");
        }
    }
    
    [MenuItem("Prototype/Helper/Swipe Object Direction")]
    public static void ImportSwipeObjectDirectionController()
    {
        if (ShowDisplayDialog())
        {
            ImportPackage("SwipeObjectDirection");
        }
    }

    private static void ImportPackage(string packageName)
    {
        var texturePackageNames = new[] {"Assets/Resources/Unitypackage/"+ packageName +".unitypackage"};
        foreach (var package in texturePackageNames)
        {
            AssetDatabase.ImportPackage(package, false);
        }
    }

    private static bool ShowDisplayDialog()
    {
        return EditorUtility.DisplayDialog("İşlem Onayı", "Dosyayı içeri aktarmak istiyor musun ?", "İçeri aktar", "İptal et");
    }
}