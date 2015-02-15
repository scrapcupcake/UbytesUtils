using UnityEngine;
using UnityEditor;
using System.Collections;
using UBytes.Utils;

public class AssetCreateWindow : EditorWindow
{
	public static AssetCreateWindow instance;

	ScriptableObject target;

	[MenuItem("Examples/Create Generic Asset #G")]
	public static void OpenWindow ()
	{
		instance = EditorWindow.GetWindow<AssetCreateWindow> ("Asset Creation Editor");
	}

	public void OnGUI ()
	{
		if (GUILayout.Button ("New Generic Asset")) {
			var newObj = new ScriptableObject ();
			AssetBank.instance.SaveAsset (newObj, "Example.asset");
			target = newObj;
		}

		target = EditorGUILayout.ObjectField (target, typeof(ScriptableObject), false) as ScriptableObject;
	}
}
