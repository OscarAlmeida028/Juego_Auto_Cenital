using UnityEditor;
using UnityEngine;

public class UnpackPrefabUtility
{
    [MenuItem("GameObject/My Custom Unpack/Unpack Prefab Instance", false, 19)]
    public static void UnpackPrefabInstance()
    {
        GameObject selectedGameObject = Selection.activeGameObject;
        if (selectedGameObject != null && PrefabUtility.IsPartOfPrefabInstance(selectedGameObject))
        {
            PrefabUtility.UnpackPrefabInstance(selectedGameObject, PrefabUnpackMode.OutermostRoot, InteractionMode.UserAction);
        }
    }
}
