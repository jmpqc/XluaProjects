using UnityEditor;
using System.IO;
public class CreateAssetBundle {

    [MenuItem("Assets/Build AssetBundles")]
    public static void BuildAllAssetBundle()
    {
        string dir = "AssetBundles";
        if(!Directory.Exists(dir))
        {
            Directory.CreateDirectory(dir);
        }
        BuildPipeline.BuildAssetBundles(dir, BuildAssetBundleOptions.None, BuildTarget.StandaloneWindows64);
    }

}
