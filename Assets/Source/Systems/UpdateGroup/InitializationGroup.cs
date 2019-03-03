using UnityEngine;
using Unity.Entities;
using Unity.Collections;

namespace RocketJump {
  [UpdateAfter(typeof(UnityEngine.Experimental.PlayerLoop.Initialization))]
  public class InitializationGroup {
  }
}