using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Astroboy.Utils.StateMachine;

namespace Astroboy.Manager
{
    public class InWingameState : State<GameManager>
    {
        public override void EnterState(GameManager entity)
        {
            entity.FinishPanel.SetActive(true);
            entity._triggers.SetActive(true);
            Time.timeScale = 0f;
        }

        public override void ExitState(GameManager entity)
        {
            entity.FinishPanel.SetActive(false);
            //entity._triggers.SetActive(false);
        }
    }
}