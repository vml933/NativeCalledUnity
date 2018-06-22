using UnityEngine;
using UnityEditor.iOS.Xcode;
using UnityEditor;
using UnityEditor.Callbacks;
using System.IO;

public class XCodeBuilderHelper : MonoBehaviour {

	#if UNITY_IOS
	[PostProcessBuild]
	static void OnPostprocessBuild(BuildTarget buildTarget, string path)
	{
		var plistPath = Path.Combine(path, "Info.plist");
		var plist = new PlistDocument();
		plist.ReadFromFile(plistPath);

		PlistElementDict rootDict = plist.root;

		PlistElementDict dic = rootDict.CreateArray("CFBundleURLTypes").AddDict();
		dic.SetString("CFBundleURLName", "com.mark.ThirdApp");
		dic.CreateArray("CFBundleURLSchemes").AddString("thirdapp");

		File.WriteAllText(plistPath, plist.WriteToString());
	}
	#endif

}
