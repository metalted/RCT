using UnityEngine;

namespace RCT
{
    public static class Utils
    {
        public static void RemoveUnwantedComponents(GameObject target)
        {
            // Array of types to keep
            System.Type[] typesToKeep = { typeof(Transform), typeof(MeshFilter), typeof(MeshRenderer) };

            // Get all components in target and its children
            foreach (Transform child in target.GetComponentsInChildren<Transform>(true))
            {
                // Get all components attached to this GameObject
                Component[] components = child.GetComponents<Component>();

                foreach (Component component in components)
                {
                    // Check if the component is not in the typesToKeep array
                    bool shouldKeep = false;
                    foreach (var type in typesToKeep)
                    {
                        if (component.GetType() == type)
                        {
                            shouldKeep = true;
                            break;
                        }
                    }

                    // If the component should not be kept, destroy it
                    if (!shouldKeep)
                    {
                        GameObject.DestroyImmediate(component);
                    }
                }
            }
        }
    }
}
