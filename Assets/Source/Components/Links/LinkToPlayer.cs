using UnityEngine;
using Unity.Entities;

namespace RocketJump {
  public struct LinkToPlayer : IComponentData {
    public Entity Entity;
  }

  public class LinktoPlayerComponent : ComponentDataProxy<LinkToPlayer> {
  }
}