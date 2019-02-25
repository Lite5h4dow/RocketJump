using System;
using UnityEngine;
using UnityEngine.EventSystems;
using Unity.Entities;

namespace RocketJump {
  public class KeyEventManager : MonoBehaviour {
    Entity entity;
    EntityManager em;

    void OnEnable () {
      entity = gameObject.GetComponent<GameObjectEntity>().Entity;
      em = World.Active.GetExistingManager<EntityManager>();
    }

    void Update () {
      // GetPauseKey();
      GetJumpKey();
    }

    void GetJumpKey () {
      if (Input.GetButtonDown("Jump")) {
        em.AddComponent(entity, typeof(JumpKeyDown));
      } else if (Input.GetButton("Jump")) {
        em.AddComponent(entity, typeof(JumpKeyHeld));
      } else if (Input.GetButtonUp("Jump")) {
        em.AddComponent(entity, typeof(JumpKeyUp));
      }
    }
  }
}