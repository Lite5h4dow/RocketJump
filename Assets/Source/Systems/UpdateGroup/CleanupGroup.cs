using UnityEngine;
using Unity.Entities;
using Unity.Collections;

namespace RocketJump {
  [UpdateAfter(typeof(UnityEngine.Experimental.PlayerLoop.PreLateUpdate))]
  public class CleanupGroup {
  }
}