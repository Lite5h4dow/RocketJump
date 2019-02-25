using System;
using UnityEngine;
using Unity.Entities;
using Unity.Mathematics;

namespace RocketJump {
  [Serializable]
  public struct SurvivalMode : IComponentData {
  }

  public class SurvivalModeComponent : ComponentDataProxy<SurvivalMode> {
  }
}
