using DependencyInjection.Injectors;
using DependencyInjection.Logging;
using UnityEngine;
using UnityEngine.Pool;

namespace DependencyInjection.Core
{
    [DefaultExecutionOrder(int.MinValue)]
    public sealed class SceneScope : MonoBehaviour
    {
        private void Awake()
        {
            UnityInjector.OnSceneLoaded.Invoke(gameObject.scene, this);
        }

        public void InstallBindings(ContainerBuilder containerBuilder)
        {
            using var pooledObject = ListPool<IInstaller>.Get(out var installers);
            GetComponentsInChildren<IInstaller>(installers);
            
            for (var i = 0; i < installers.Count; i++)
            {
                installers[i].InstallBindings(containerBuilder);
            }

            DependencyInjectionLogger.Log($"SceneScope ({gameObject.scene.name}) Bindings Installed", LogLevel.Info, gameObject);
        }
    }
}