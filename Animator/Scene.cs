using System.Collections.Generic;

namespace MyEngineImpl
{
    public class Scene
    {
        public List<GameObject> GameObjects { get; set; }

        public Scene()
        {
            GameObjects = new List<GameObject>();
        }

        public void AddGameObject(GameObject gameObject)
        {
            GameObjects.Add(gameObject);
        }
        public void RemoveGameObject(GameObject gameObject)
        {
            GameObjects.Remove(gameObject);
        }

    }
}
