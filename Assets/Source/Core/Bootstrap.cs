using System;
using System.Collections.Generic;
using Unity.Entities;
using UnityEngine;
using Unity.Mathematics;
using UnityEngine.SceneManagement;
using Unity.Transforms;

namespace RocketJump {
  public sealed class Bootstrap {
    public static DeveloperSettings DeveloperSettings;

    public static void NewGame () {
      // NOTE: bootstrap new game
    }

    [RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.AfterSceneLoad)]
    public static void InitializeAfterSceneLoad () {
      var DeveloperSettingsGO = GameObject.Find("DeveloperSettings");
      SceneManager.sceneLoaded += OnSceneLoaded;

      InitializeWithScene();
    }

    public static void OnSceneLoaded (Scene arg0, LoadSceneMode arg1) {
      InitializeWithScene();
    }

    public static void InitializeWithScene () {
      var em = World.Active.GetOrCreateManager<EntityManager>();

      var DeveloperSettingsGO = GameObject.Find("DeveloperSettings");
      if (!DeveloperSettingsGO) {
        throw new Exception("You must create Gameobject called 'DeveloperSettings' and attach DeveloperSettings component");
      }

      DeveloperSettings = DeveloperSettingsGO.GetComponent<DeveloperSettings>();

      NewGame();
    }
  }
}