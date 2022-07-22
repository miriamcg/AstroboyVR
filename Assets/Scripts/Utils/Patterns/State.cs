using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Astroboy.Utils.StateMachine{
    public class State<T>
    {
        public virtual void EnterState(T entity) { }

        public virtual void TickState(T entity) { }

        public virtual void FixedUpdateTick(T entity) { }

        public virtual void ExitState(T entity) { }
    }
}