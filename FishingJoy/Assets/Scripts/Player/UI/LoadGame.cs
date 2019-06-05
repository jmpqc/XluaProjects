using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


using UnityEngine.Networking;
using System.IO;



public class LoadGame : MonoBehaviour
{

    public Slider processView;

    // Use this for initialization
    void Start()
    {
        LoadGameMethod();

    }

    // Update is called once per frame
    void Update()
    {


    }
    public void LoadGameMethod()
    {
        StartCoroutine(LoadLuaCodeCorotine());
        StartCoroutine(StartLoading_4(2));
    }

    private IEnumerator StartLoading_4(int scene)
    {
        int displayProgress = 0;
        int toProgress = 0;
        AsyncOperation op = SceneManager.LoadSceneAsync(scene);
        op.allowSceneActivation = false;
        while (op.progress < 0.9f)
        {
            toProgress = (int)op.progress * 100;
            while (displayProgress < toProgress)
            {
                ++displayProgress;
                SetLoadingPercentage(displayProgress);
                yield return new WaitForEndOfFrame();
            }
        }

        toProgress = 100;
        while (displayProgress < toProgress)
        {
            ++displayProgress;
            SetLoadingPercentage(displayProgress);
            yield return new WaitForEndOfFrame();
        }
        op.allowSceneActivation = true;
    }


    private IEnumerator LoadLuaCodeCorotine()
    {
        //fish.lua.txt
        UnityWebRequest req = UnityWebRequest.Get(@"http://127.0.0.1/fish.lua.txt");//注意服务器上的路径
        yield return req.SendWebRequest(); //等待下载完成
        string str = req.downloadHandler.text; //获得Lua脚本的内容
        string disFilePath = null;
#if UNITY_EDITOR
        disFilePath = @"C:\Users\dream\Desktop\XLuaActualCombat\XluaProjects\PlayerGamePackage\fish.lua.txt";
#else
        disFilePath = System.AppDomain.CurrentDomain.SetupInformation.ApplicationBase; //X:\xxx\xxx\ (.exe文件所在的目录+"\")
        disFilePath += @"Lua\" + "fish.lua.txt";
#endif
        File.WriteAllText(disFilePath, str); //将服务器上的Lua脚本文件写入本地Lua文件


        //fishdispose.lua.txt
        UnityWebRequest req1 = UnityWebRequest.Get(@"http://127.0.0.1/fishdispose.lua.txt");
        yield return req1.SendWebRequest();
        string str1 = req1.downloadHandler.text;
        string disFilePath1 = null;
#if UNITY_EDITOR
        disFilePath1 = @"C:\Users\dream\Desktop\XLuaActualCombat\XluaProjects\PlayerGamePackage\fishdispose.lua.txt";
#else
        disFilePath1 = System.AppDomain.CurrentDomain.SetupInformation.ApplicationBase; //X:\xxx\xxx\ (.exe文件所在的目录+"\")
        disFilePath1 += @"Lua\" + "fishdispose.lua.txt";
#endif
        File.WriteAllText(disFilePath1, str1);



    }

    private void SetLoadingPercentage(float v)
    {
        processView.value = v / 100;
    }


}
