using UnityEngine;

namespace RTSSkill
{
    public interface IGameObjectCreator
    {
        public GameObject CreateGameObject(string name, GameObject gameObject, Vector3 position, Quaternion rotation);
    }
}