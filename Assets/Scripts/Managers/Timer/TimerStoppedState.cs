using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Astroboy.Utils.StateMachine;

namespace Astroboy.Utils.StateMachine
{
    public class TimerStoppedState : State<Timer>
    {
        public override void EnterState(Timer entity)
        {
            //entity.gameManager.WinGame();
        }
    }
}