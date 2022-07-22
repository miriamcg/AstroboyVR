using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Astroboy.Utils.StateMachine;

namespace Astroboy.Manager
{
    public class InGameState : State<GameManager>
    {
        public override void EnterState(GameManager entity)
        {
            
        }

        public override void ExitState(GameManager entity)
        {
            
        }

        public override void TickState(GameManager entity)
        {
            /**if (Input.GetButtonDown("Pause") && entity.CanPause)
            {
                entity.GameManagerMachine.SetState(entity.InPauseState);
            }**/
        }
    }
}