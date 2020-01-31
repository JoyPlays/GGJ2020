using UnityEngine;

namespace Ugitty.Components
{
    public class GameObjectReplace : MonoBehaviour
    {
        public GameObject initialObject;
        public GameObject replaceObject;

        private bool hasReplaced = false;

        public void Replace()
        {
            if (hasReplaced) return;

            // Remove old object
            Destroy(initialObject);

            // Add new object
            Instantiate(replaceObject, initialObject.transform.position, initialObject.transform.rotation);

            hasReplaced = true;
        }
    }
}