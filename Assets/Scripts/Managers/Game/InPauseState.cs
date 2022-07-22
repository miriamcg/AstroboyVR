using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Astroboy.Utils.StateMachine;

namespace Astroboy.Manager
{

    public class InPauseState : State<GameManager>
    {
        public override void EnterState(GameManager entity)
        {
            Time.timeScale = 0f;

            //entity.PausePanel.SetActive(true);
        }

        public override void TickState(GameManager entity)
        {
            
        }
        public override void ExitState(GameManager entity)
        {
            Time.timeScale = entity.InitialTimeScale;

            //entity.PausePanel.SetActive(false);
        }
    }
}