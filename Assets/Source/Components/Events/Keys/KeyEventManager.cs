using System;
using Unity.Entities;
using UnityEngine;
using UnityEngine.EventSystems;

namespace RocketJump {
  public class KeyEventManager : MonoBehaviour {
    Entity entity;
    EntityManager em;

    void OnEnable () {
      entity = gameObject.GetComponent<GameObjectEntity>().Entity;
      em = World.Active.GetExistingManager<EntityManager>();
    }

    void Update () {
      GetJumpKey();
      GetBoostKey();
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

    void GetBoostKey () {
      if (Input.GetButtonDown("Boost")) {
        em.AddComponent(entity, typeof(BoostKeyDown));
      } else if (Input.GetButton("Boost")) {
        em.AddComponent(entity, typeof(BoostKeyHeld));
      } else if (Input.GetButtonUp("Boost")) {
        em.AddComponent(entity, typeof(BoostKeyUp));
      }
    }
  }
}