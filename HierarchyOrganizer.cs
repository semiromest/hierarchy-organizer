using UnityEditor;
using UnityEngine;
using System.Collections.Generic;

public class HierarchyOrganizer : EditorWindow
{
    private GameObject[] targetObjects;
    private string searchString = "SearchString";
    private List<GameObject> selectedObjects = new List<GameObject>();
    private Vector2 scrollPosition = Vector2.zero;

    [MenuItem("Tools/Hierarchy Organizer")]
    public static void ShowWindow()
    {
        GetWindow<HierarchyOrganizer>("HierarchyOrganizer");
    }

    private void OnGUI()
    {
        EditorGUILayout.HelpBox("Select target objects and enter the search string.", MessageType.Info);
        EditorGUILayout.Space();

        EditorGUILayout.LabelField("Search String", EditorStyles.boldLabel);
        searchString = EditorGUILayout.TextField("Search String", searchString);

        if (GUILayout.Button("Organize"))
        {
            Organize();
        }

        if (GUILayout.Button("Clear List")) // Clear List düðmesi eklendi
        {
            selectedObjects.Clear();
        }

        EditorGUI.BeginChangeCheck();
        GameObject[] newSelection = Selection.gameObjects;
        EditorGUI.EndChangeCheck();

        foreach (var obj in newSelection)
        {
            if (!selectedObjects.Contains(obj))
            {
                selectedObjects.Add(obj);
            }
        }
        scrollPosition = EditorGUILayout.BeginScrollView(scrollPosition);
        EditorGUILayout.Space();
        foreach (var obj in selectedObjects)
        {
            EditorGUILayout.ObjectField(obj, typeof(GameObject), true);
        }
        EditorGUILayout.EndScrollView();
    }

    private void Organize()
    {
        GameObject emptyObject = null;
        foreach (GameObject obj in selectedObjects)
        {
            if (obj != null)
            {
                Transform[] children = obj.GetComponentsInChildren<Transform>(true);
                foreach (Transform child in children)
                {
                    if (child.name.Contains(searchString))
                    {
                        if (emptyObject == null)
                        {
                            emptyObject = new GameObject(searchString);
                            emptyObject.transform.SetParent(obj.transform.parent);
                            emptyObject.transform.localPosition = Vector3.zero;
                            emptyObject.transform.localRotation = Quaternion.identity;
                            emptyObject.transform.localScale = Vector3.one;
                        }

                        child.SetParent(emptyObject.transform);
                    }
                }
            }
        }

        Debug.Log("Organized successfully.");
    }
}
