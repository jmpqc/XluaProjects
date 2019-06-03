using UnityEngine;
using System.Collections.Generic;

public static class LoadAssets {
    public static Dictionary<string, GameObject> prefabDict = new Dictionary<string, GameObject>();
    public static void LoadAsset(string prefabName, string filePath)
    {
        AssetBundle ab = AssetBundle.LoadFromFile(@"C:\Users\dream\Desktop\XLuaActualCombat\XluaProjects\FishingJoy\AssetBundles\" + filePath);
        GameObject gameObject = ab.LoadAsset<GameObject>(prefabName);
        prefabDict.Add(prefabName, gameObject);
    }

    public static GameObject GetGameObject(string prefabName)
    {
        return prefabDict[prefabName];
    }
}
