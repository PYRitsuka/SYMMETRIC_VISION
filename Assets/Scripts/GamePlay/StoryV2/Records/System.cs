using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using Utils;
using System.Linq;
using GamePlay.StoryV2.RecordsResolver;
using GamePlay.StoryV2.Record;
using Utils.StoryScriptFunctions;

namespace GamePlay.StoryV2.Record
{


    public class ParallelCommand : Base
    {
        private List<Base> subCommands;

        public ParallelCommand(List<Base> commands)
        {
            subCommands = commands;
        }

        public override void Start(ScriptResolverV2 environment)
        {
            foreach (var command in subCommands)
            {
                command.Start(environment);
            }
            // No need to set isComplete here; it will be determined in IsComplete()
        }

        public override bool IsComplete()
        {
            // Check if all subcommands are complete
            bool allComplete = true;
            foreach(var command in subCommands) {
                var thisComplete = command.IsComplete();
                allComplete = thisComplete  && allComplete; // avoid short circuiting!!!!
            }
            isComplete = allComplete;
            return isComplete;
        }
    }

    public class SequentialCommand : Base
    {
        private List<Base> subCommands;
        private int currentCommandIndex = 0;

        public SequentialCommand(List<Base> commands)
        {
            subCommands = commands;
        }

        public override void Start(ScriptResolverV2 environment)
        {
            // Start the first command if there are any commands
            if (subCommands.Count > 0)
            {
                subCommands[currentCommandIndex].Start(environment);
                IsComplete();
            } else {
                isComplete = true; // do nothing
            }
            
        }

        public override bool IsComplete() // Be carefull, this has sideEffects
        {
            if (isComplete)
                return true;

            //Debug.Log($"Sequential Command Check: {currentCommandIndex}, {subCommands[currentCommandIndex].IsComplete()} ");

            while (subCommands[currentCommandIndex].IsComplete())
            {
                currentCommandIndex++; // Move to the next command
                if (currentCommandIndex < subCommands.Count)
                {
                    // Start the next command
                    subCommands[currentCommandIndex].Start(ScriptResolverV2.Instance);
                }
                else
                {
                    // All commands have been completed
                    isComplete = true;
                    break;
                }
            }

            return isComplete;
        }
    }

    public class ConditionalExecution : Base {

        Base subCommand;
        string key;
        bool value;

        public ConditionalExecution(Base subCommand, string key, bool value)
        {
            this.subCommand = subCommand;
            this.key = key;
            this.value = value;
            if (subCommand == null) {
                throw new ArgumentException($"If condition cannot have empty block!");
            }
        }

        public override void Start(ScriptResolverV2 environment) {
            if (environment.HasFlag(key) == value) {
                subCommand.Start(environment);
            } else {
                isComplete = true;
            }
        }

        public override bool IsComplete() // Be carefull, this has sideEffects
        {
            if (isComplete)
                return true;
            else {
                return subCommand.IsComplete();
            }

        }


    }

    public class SetFlag : Base {

        string key;
        bool value;

        public SetFlag(string key, bool value)
        {
            this.key = key;
            this.value = value;

        }

        public override void Start(ScriptResolverV2 environment) {
            environment.SetFlag(key,value);
            SetComplete();
        }

    }
    public class WaitClickCommand : Base
    {
        private ScriptResolverV2 environment; // To store the environment reference

        public override void Start(ScriptResolverV2 env)
        {
            environment = env; // Store the environment reference
            if (env.isSkipping || env.IsFastForwarding() ) {
                isComplete = true;
                return;
            } else if (env.isAutoPlay) {
                DOVirtual.DelayedCall(1f,SetComplete);
                 return;
            } else {
                environment.OnUserClick.SubscribeStopPropagate(HandleUserClick); // Subscribe to click event
                env.onAutoStart.AddListener(SetComplete);
            }
           
        }

        private void HandleUserClick()
        {
            Debug.Log("Callback");
            isComplete = true;
            // Unsubscribe to prevent multiple triggerings
            // if (environment != null)
            // {
            //     environment.OnUserClick -= HandleUserClick;
            // }
            // new manage default remove
        }

    }

    public class PrintCommand : Base
    {
        // Debug Purposes
        string _message;

        public PrintCommand(string message)
        {
            _message = message;
            isComplete = true;
        }

        public override void Start(ScriptResolverV2 environment)
        {
            Debug.Log($"Print Command:{_message}");
        }
    }

    public class NoOpCommand : Base
    {
        // Debug Purposes

        public NoOpCommand()
        {
            isComplete = true;
        }

        public override void Start(ScriptResolverV2 environment)
        {
            Debug.Log($"NoOP Command:");
        }
        public override bool IsComplete()
        {
            return isComplete;
        }
    }
    public class WaitCommand : Base
    {
        private float duration;

        public WaitCommand(float durationInSeconds)
        {
            duration = durationInSeconds;
        }

        public override void Start(ScriptResolverV2 environment)
        {
            // Start a delayed tween that completes after 'duration' seconds
            Debug.Log($"Delay Command {duration}");
            if (environment.isSkipping) {
                duration = 0.1f;
            } else if ( environment.IsFastForwarding()) {
                isComplete = true;
                return;
            }
            var animation = DOVirtual.DelayedCall(duration, ()=>{
                    Debug.Log($"Delay Command Finished{duration}");

            });
            HandleAnimationDefault(animation,environment);
        }

        // private void MarkComplete()
        // {

        //     isComplete = true;
        //     Debug.Log($"Delay Command callback {duration} {IsComplete()}");
        // }

        public override bool IsComplete()
        {
            return isComplete;
        }
    }


}