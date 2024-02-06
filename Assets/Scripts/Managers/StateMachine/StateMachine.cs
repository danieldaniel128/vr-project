﻿using System;
using System.Collections.Generic;

public class StateMachine {
    StateNode current;
    Dictionary<Type, StateNode> nodes = new();
    HashSet<Transition> anyTransitions = new();

    public void Update() {
        var transition = GetTransition();
        if (transition != null) 
            ChangeState(transition.To);
            
        current.State?.Update();
    }
        
    public void FixedUpdate() {
        current.State?.FixedUpdate();
    }

    public void SetState(IState state) {
        current = nodes[state.GetType()];
        current.State?.OnEnter();
    }

    void ChangeState(IState state) {
        if (state == current.State) return;
            
        var previousState = current.State;
        var nextState = nodes[state.GetType()].State;
            
        previousState?.OnExit();
        nextState?.OnEnter();
        current = nodes[state.GetType()];
    }

    Transition GetTransition()
    {
        foreach (var transition in anyTransitions)
            if (transition.Condition())
                return transition;

        foreach (var transition in current.Transitions)
            if (transition.Condition())
                return transition;

        return null;
    }

    public void AddTransition(IState from, IState to, Func<bool> condition) {
        GetOrAddNode(from).AddTransition(GetOrAddNode(to).State, condition);
    }
        
    public void AddAnyTransition(IState to, Func<bool> condition) {
        anyTransitions.Add(new Transition(GetOrAddNode(to).State, condition));
    }

    StateNode GetOrAddNode(IState state) {
        var node = nodes.GetValueOrDefault(state.GetType());
            
        if (node == null) {
            node = new StateNode(state);
            nodes.Add(state.GetType(), node);
        }
            
        return node;
    }




    class StateNode 
    {
        public IState State { get; }
        public HashSet<Transition> Transitions { get; }
            
        public StateNode(IState state) {
            State = state;
            Transitions = new HashSet<Transition>();
        }
            
        public void AddTransition(IState to, Func<bool> condition) {
            Transitions.Add(new Transition(to, condition));
        }
    }
    public class Transition
    {
        public IState To { get; }//the state to transition to
        public Func<bool> Condition;//the condition to transition
        public Transition(IState to, Func<bool> condition)
        {
            To = to;
            Condition = condition;
        }
    }
}
