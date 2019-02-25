using System;
using UnityEngine;
using Unity.Entities;
using Unity.Mathematics;

namespace RocketJump {
  [Serializable]
  public struct GameMode : IComponentData {
  }

  public class GameModeComponent : ComponentDataProxy<GameMode> {
  }
}
