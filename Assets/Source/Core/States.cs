using UnityEngine;
using Unity.Mathematics;

namespace State {
  public enum Overlap {
    Enter,
    Stay,
    Exit
  }

  public enum MouseClick {
    Up,
    Down,
    Over
  }

  public enum Key {
    Up,
    Down,
    Hold
  }
}