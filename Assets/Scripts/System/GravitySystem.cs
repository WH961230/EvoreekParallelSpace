using System.Collections.Generic;
using UnityEngine;

public class GravitySystem : SystemBase
{
    public bool openGravitySystem = true;
    public List<CharacterController> controllers;
    public override void OnInit(GameEngine gameEngine) {
        base.OnInit(gameEngine);
    }

    public void RegisterTarget() {
    }

    public override void OnUpdate() {
        base.OnUpdate();
    }

    public void OnFixedUpdate() {
        base.OnFixedUpdate();
        if (openGravitySystem) {
            
        }
    }

    public override void OnClear() {
        base.OnClear();
    }
}