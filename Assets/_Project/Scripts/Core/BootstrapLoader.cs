using System;
using UnityEngine;

namespace Ritmo.Core
{
    public sealed class BootstrapLoader : MonoBehaviour
    {
        public static Action<string> LoadAction = SceneLoader.Load;

        private void Start()
        {
            LoadAction?.Invoke(SceneNames.Profile);
        }
    }
}
