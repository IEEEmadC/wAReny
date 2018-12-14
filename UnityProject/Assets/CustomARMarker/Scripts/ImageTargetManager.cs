using UnityEngine;
using System.Collections.Generic;
using System.Linq;
using EasyAR;

namespace Sample
{
    public class ImageTargetManager : MonoBehaviour
    {
        private Dictionary<string, DynamicImageTagetBehaviour> imageTargetDic = new Dictionary<string, DynamicImageTagetBehaviour>();
        private FilesManager pathManager;

        void Start()
        {
            if (!pathManager)
                pathManager = FindObjectOfType<FilesManager>();
        }

        void Update()
        {
            var imageTargetName_FileDic = pathManager.GetDirectoryName_FileDic();
            foreach (var obj in imageTargetName_FileDic.Where(obj => !imageTargetDic.ContainsKey(obj.Key)))
            {
                GameObject imageTarget = new GameObject(obj.Key);
                imageTarget.AddComponent<PersistenceMarker>();
                var behaviour = imageTarget.AddComponent<DynamicImageTagetBehaviour>();
                behaviour.Name = obj.Key;
                behaviour.Path = obj.Value.Replace(@"\", "/");
                behaviour.Storage = StorageType.Absolute;
                behaviour.Bind(ARBuilder.Instance.ImageTrackerBehaviours[0]);
                imageTargetDic.Add(obj.Key, behaviour);
            }
        }

        public void ClearAllTarget()
        {
            foreach (var obj in imageTargetDic)
                Destroy(obj.Value.gameObject);
            imageTargetDic = new Dictionary<string, DynamicImageTagetBehaviour>();
        }
    }
}
