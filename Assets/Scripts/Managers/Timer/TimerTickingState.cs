using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Astroboy.Utils.StateMachine;

namespace Astroboy.Utils.StateMachine
{
    public class TimerTickingState : State<Timer>
    {
        public override void TickState(Timer entity)
        {
            entity.ActualSeconds -= 3 * Time.deltaTime;

            //When the timer ends, it invokes the event.
            if(entity.ActualSeconds <= 0)
            {
                entity.OnTimerEnds.Invoke();

                CheckIfShouldRepeat(entity);
            }
        }

        private void CheckIfShouldRepeat(Timer entity)
        {
            //If should reset then restart the timer. If not, set the timer to it's stopped state.
            if (entity.ShouldReset)
                entity.RestartTimer();
            else
                entity.TimerMachine.SetState(entity.StoppedState);
        }
    }
}