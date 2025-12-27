using UnityEngine;

namespace ProjectNyx
{
    public abstract class State<T> where T : MonoBehaviour
    {
        protected T owner;
        protected StateMachine<T> stateMachine;

        // Pass both Owner and Machine so the State can switch itself
        public virtual void Enter(T owner, StateMachine<T> stateMachine)
        {
            this.owner = owner;
            this.stateMachine = stateMachine;
        }

        public virtual void Execute() { }
        public virtual void Exit() { }
    }

    public class StateMachine<T> : MonoBehaviour where T : MonoBehaviour
    {
        private State<T> currentState;
        private T owner; // Store reference to the actual unit (Sentinel)

        public void Initialize(T owner)
        {
            this.owner = owner;
        }

        public void ChangeState(State<T> newState)
        {
            if (currentState != null)
                currentState.Exit();

            currentState = newState;

            if (currentState != null)
                currentState.Enter(owner, this); // FIX: Pass the Owner, not 'this'
        }

        public void Update()
        {
            if (currentState != null)
                currentState.Execute();
        }
    }
}