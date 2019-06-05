using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using XLua;
using System.IO;

public class HotFixScript : MonoBehaviour {
    private LuaEnv luaenv = new LuaEnv();

    private void Awake()
    {
        luaenv.AddLoader(MyLoader);
        luaenv.DoString("require 'fish'");        
    }

    // Use this for initialization
    private void Start () {

	}
	
	// Update is called once per frame
	private void Update () {
		
	}

    private byte[] MyLoader(ref string filePath)
    {
        string absPath = null;
#if UNITY_EDITOR
        absPath = @"C:\Users\dream\Desktop\XLuaActualCombat\XluaProjects\PlayerGamePackage\" + filePath + ".lua.txt";
#else
        absPath = System.AppDomain.CurrentDomain.SetupInformation.ApplicationBase; //X:\xxx\xxx\ (.exe文件所在的目录+"\")
        absPath += @"Lua\" + filePath + ".lua.txt";
#endif
        return System.Text.Encoding.UTF8.GetBytes(File.ReadAllText(absPath));
    }

    private void OnDisable()
    {
        luaenv.DoString("require 'fishdispose'");
    }

    private void OnDestroy()
    {
        //luaenv.DoString("require 'findref'");//找到被C#引用着的lua函数，不知道该怎么用！！！
        luaenv.Dispose();
    }
}
