using System;
using UnityEngine.SceneManagement;

namespace Ritmo.Core
{
    public static class SceneLoader
    {
        public static event Action<string> OnSceneLoadRequested;

        public static void Load(string sceneName)
        {
            if (string.IsNullOrWhiteSpace(sceneName))
            {
                throw new ArgumentException("O nome da cena não pode ser vazio.", nameof(sceneName));
            }

            OnSceneLoadRequested?.Invoke(sceneName);
            SceneManager.LoadScene(sceneName);
        }
    }
}
