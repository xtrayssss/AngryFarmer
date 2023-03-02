using Components;
using UnityEngine;

namespace StaticsHelper
{
    public static class StaticsFunctions
    {
        public static int GetRandomIndexObjectInArray<T>(T[] array) =>
            Random.Range(0, array.Length);

        public static GameObject InstantiateUIObjectUnderParent(string sourceResourcesName, string parentTag)
        {
            GameObject uiObject = Resources.Load(sourceResourcesName) as GameObject;
            
            GameObject.Instantiate(uiObject,
                GameObject.FindGameObjectWithTag(parentTag).transform);

            return uiObject;
        }
    }
}