using UnityEngine;
using System.Collections.Generic;
using System.Collections;
using UnityEngine.Networking;

public class LoadAssets : MonoBehaviour
{
    public Dictionary<string, GameObject> prefabDict = new Dictionary<string, GameObject>();


    public void LoadAsset(string prefabName, string filePath)
    {
        StartCoroutine(LoadResourceCorotine(prefabName, filePath));
    }

    IEnumerator LoadResourceCorotine(string prefabName, string filePath)
    {
        UnityWebRequest request = UnityWebRequest.GetAssetBundle(@"http://127.0.0.1/AssetBundles/" + filePath);
        yield return request.SendWebRequest();//从服务器下载完后，继续执行下面的代码
        AssetBundle ab = (request.downloadHandler as DownloadHandlerAssetBundle).assetBundle;
        GameObject gameObject = ab.LoadAsset<GameObject>(prefabName);
        prefabDict.Add(prefabName, gameObject);
    }

    public GameObject GetGameObject(string prefabName)
    {
        return prefabDict[prefabName];
    }

}
