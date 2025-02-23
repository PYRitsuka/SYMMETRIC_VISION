using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using GamePlay.Story.Record;

namespace GamePlay.StoryV2.Record.Factory
{




    public static class CommandFactory
    {
        static void LogDictionary(Dictionary<string, object> dict)
        {
            foreach (var pair in dict)
            {
                Debug.Log($"Key: {pair.Key}, Value: {pair.Value}");
            }
        }

        public static Base CreateCommand(Dictionary<string, object> obj)
        {
            return CreateCommand(
                                Convert.ToString(obj["CommandType"]),
                                obj.ContainsKey("Parameters") ? (Dictionary<string, object>)obj["Parameters"] : new(),
                                Convert.ToString(obj["Identifier"])
            );
        }
        public static Base CreateCameraCommand(string type, Dictionary<string, object> parameters, string identifier)
        {
            switch (type)
            {
                // Other cases...

                case "Camera.PlayFx":
                    return new Camera.PlayFx(
                        name: Convert.ToString(parameters["name"]),
                        duration: Convert.ToSingle(parameters["duration"])
                    );

                case "Camera.KeepBumpy":
                    return new Camera.KeepBumpy(
                        strength: Convert.ToSingle(parameters["strength"]),
                        duration: Convert.ToSingle(parameters["duration"])
                    );

                case "Camera.StopAction":
                    return new Camera.StopAction(
                        action: Convert.ToString(parameters["action"])
                    );
                default:
                    Debug.LogWarning($"ScriptResolver: Unknown command type {type}");
                    return new NoOpCommand();
            }
        }
        public static Base CreateTextCommand(string type, Dictionary<string, object> parameters, string identifier)
        {
            switch (type)
            {
                case "Text.ChangeAlpha":
                    return new TextCommand.ChangeAlpha(
                        alphaBegin: Convert.ToSingle(parameters["alpha_began"]),
                        alphaEnd: Convert.ToSingle(parameters["alpha_ended"]),
                        time: Convert.ToSingle(parameters["time"])
                    );
                case "Text.ShowText":
                    return new TextCommand.ShowText(
                        Convert.ToString(parameters["mode"]),
                        Convert.ToString(parameters["name"]),
                        Convert.ToString(parameters["dialogue"]),
                        Convert.ToString(parameters["avater"]),
                        Convert.ToSingle(parameters["speed"])
                    );
                case "Text.TextClear":
                    return new TextCommand.ShowText();
                case "Text.SetTextSpeed":
                    return new TextCommand.SetTextSpeed(
                         Convert.ToSingle(parameters["speed"])
                    );
                case "Text.SetFontSize":
                    return new TextCommand.SetFontSize(
                        Convert.ToInt32(parameters["size"])
                    );
                default:
                    Debug.LogWarning($"ScriptResolver: Unknown command type {type}");
                    return new NoOpCommand();
            }
        }
        public static Base CreateEngineCommand(string type, Dictionary<string, object> parameters, string identifier)
        {
            switch (type)
            {
                case "Engine.SetUIMode":
                    return new Engine.SetUIMode(
                        mode: Convert.ToInt32(parameters["mode"])
                    );

                case "Engine.SetChapter":
                    return new Engine.SetChapter(
                        id: Convert.ToString(parameters["id"]),
                        title: Convert.ToString(parameters["title"])
                    );

                case "Engine.JumpToScript":
                    return new Engine.JumpToScript(
                        script: Convert.ToString(parameters["script"])
                    );
                case "Engine.SetVisionTrigger":
                    return new Engine.SetVisionTrigger(
                        animationId: Convert.ToInt32(parameters["animationId"]),
                        script: Convert.ToString(parameters["script"])
                    );

                case "Engine.DisableVisionTrigger":
                    return new Engine.DisableVisionTrigger();

                case "Engine.VisionChange":
                    return new Engine.VisionChange(
                        animationId: Convert.ToInt32(parameters["animationId"]),
                        script: Convert.ToString(parameters["script"]),
                        stopBGM: Convert.ToBoolean(parameters["stopBGM"])
                    );

                case "Engine.BackToTitle":
                    return new Engine.BackToTitle();
                case "Engine.Select":
                    return new Engine.Select(
                        key: Convert.ToString(parameters["key"]),
                        opt1: Convert.ToString(parameters["opt1"]),
                        opt2: Convert.ToString(parameters["opt2"]),
                        opt3: Convert.ToString(parameters["opt3"]),
                        opt4: Convert.ToString(parameters["opt4"]),
                        opt5: Convert.ToString(parameters["opt5"])
                    );
                case "Engine.ClearScene":
                    return new Engine.ClearScene();
                default:
                    Debug.LogWarning($"ScriptResolver: Unknown command type {type}");
                    return new NoOpCommand();
            }
        }
        public static Base CreateFrameCommand(string type, Dictionary<string, object> parameters, string identifier)
        {
            switch (type)
            {
                // Other cases...

                case "Frame.ViewOn":
                    return new Frame.ViewOn(
                        image: Convert.ToString(parameters["image"]),
                        color: Convert.ToString(parameters["color"]),
                        duration: Convert.ToSingle(parameters["duration"])
                    );

                case "Frame.ViewChange":
                    return new Frame.ViewChange(
                        image: Convert.ToString(parameters["image"]),
                        duration: Convert.ToSingle(parameters["duration"])
                    );

                case "Frame.ViewOff":
                    return new Frame.ViewOff(
                      
                        duration: Convert.ToSingle(parameters["duration"])
                    );

                case "Frame.PictureOn":
                    return new Frame.PictureOn(
                        image: Convert.ToString(parameters["image"]),
                        color: Convert.ToString(parameters["color"]),
                        duration: Convert.ToSingle(parameters["duration"])
                    );

                case "Frame.PictureChange":
                    return new Frame.PictureChange(
                        image: Convert.ToString(parameters["image"]),
                        duration: Convert.ToSingle(parameters["duration"])
                    );

                case "Frame.PictureOff":
                    return new Frame.PictureOff(
                      
                        duration: Convert.ToSingle(parameters["duration"])
                    );
                    case "Frame.RineOn":
                        return new Frame.RineOn(
                            title: Convert.ToString(parameters["title"])
                        );

                    case "Frame.RineOff":
                        return new Frame.RineOff();

                    case "Frame.RineSpeak":
                        return new Frame.RineSpeak(
                            image: Convert.ToString(parameters["image"])
                        );

                    case "Frame.RineChangeAlpha":
                        return new Frame.RineChangeAlpha(
                            alpha_began: Convert.ToSingle(parameters["alpha_began"]),
                            alpha_ended: Convert.ToSingle(parameters["alpha_ended"]),
                            duration: Convert.ToSingle(parameters["duration"])
                        );
                    case "Frame.BMIOn":
                    return new Frame.BMIOn(
                        color: Convert.ToString(parameters["color"]),
                        duration: Convert.ToSingle(parameters["duration"])
                    );
                    case "Frame.BMIOff":
                    return new Frame.BMIOff(
                        color: Convert.ToString(parameters["color"]),
                        duration: Convert.ToSingle(parameters["duration"])
                    );
                default:
                    Debug.LogWarning($"ScriptResolver: Unknown command type {type}");
                    return new NoOpCommand();
                    // Other cases...
            }
        }

        public static Base CreateAudioManagerCommand(string type, Dictionary<string, object> parameters, string identifier)
        {
            switch (type)
            {
                // Other cases...

                case "AudioManager.SetBGM":
                    return new AudioManager.SetBGM(
                        audio: Convert.ToString(parameters["audio"]),
                        volume: Convert.ToSingle(parameters["volume"]),
                        loop: Convert.ToBoolean(parameters["loop"]),
                        begin: Convert.ToSingle(parameters["begin"]),
                        end: Convert.ToSingle(parameters["end"])
                    );

                case "AudioManager.VolumeChange":
                    return new AudioManager.VolumeChange(
                        duration: Convert.ToSingle(parameters["duration"]),
                        begin: Convert.ToSingle(parameters["begin"]),
                        end: Convert.ToSingle(parameters["end"])
                    );

                case "AudioManager.SetSE":
                    return new AudioManager.SetSE(
                        audio: Convert.ToString(parameters["audio"]),
                        volume: Convert.ToSingle(parameters["volume"]),
                        loop: Convert.ToBoolean(parameters["loop"])
                    );

                case "AudioManager.StopSE":
                    return new AudioManager.StopSE();

                default:
                    Debug.LogWarning($"ScriptResolver: Unknown command type {type}");
                    return new NoOpCommand();
            }
        }
        public static Base CreateFilterCommand(string type, Dictionary<string, object> parameters, string identifier)
        {
            switch (type)
            {
                case "Filter.SetFilter":
                    return new Filter.SetFilter(
                        name: Convert.ToString(parameters["name"]),
                        enabled: Convert.ToBoolean(parameters["enabled"])
                    );
                default:
                    throw new ArgumentException($"Unknown type: {type}");
            }

        }
        public static Base CreateImageManagerCommand(string type, Dictionary<string, object> parameters, string identifier)
        {
            switch (type)
            {
                case "ImageManager.Add":
                case "ImageManager.Create":
                    return new ImageManager.Add(
                        target: Convert.ToString(parameters["target"]),
                        name: Convert.ToString(parameters["name"]),
                        texture: Convert.ToString(parameters["texture"])
                    );

                case "ImageManager.Remove":
                case "ImageManager.Delete":
                    return new ImageManager.Remove(
                        target: Convert.ToString(parameters["target"]),
                        name: Convert.ToString(parameters["name"])
                    );

                case "ImageManager.SetTexture":
                    return new ImageManager.SetTexture(
                        target: Convert.ToString(parameters["target"]),
                        name: Convert.ToString(parameters["name"]),
                        texture: Convert.ToString(parameters["texture"]),
                        duration: Convert.ToSingle(parameters["duration"])
                    );

                case "ImageManager.SetLocation":
                    return new ImageManager.SetLocation(
                        target: Convert.ToString(parameters["target"]),
                        name: Convert.ToString(parameters["name"]),
                        x: Convert.ToInt32(parameters["x"]),
                        y: Convert.ToInt32(parameters["y"]),
                        duration: Convert.ToSingle(parameters["duration"]),
                        curve: Convert.ToString(parameters["curve"])
                    );

                case "ImageManager.SetScale":
                    return new ImageManager.SetScale(
                        target: Convert.ToString(parameters["target"]),
                        name: Convert.ToString(parameters["name"]),
                        scale: Convert.ToSingle(parameters["scale"]),
                        duration: Convert.ToSingle(parameters["duration"]),
                        curve: Convert.ToString(parameters["curve"])
                    );

                case "ImageManager.SetRotation":
                    return new ImageManager.SetRotation(
                        target: Convert.ToString(parameters["target"]),
                        name: Convert.ToString(parameters["name"]),
                        angle: Convert.ToSingle(parameters["angle"]),
                        duration: Convert.ToSingle(parameters["duration"]),
                        curve: Convert.ToString(parameters["curve"])
                    );

                case "ImageManager.SetFade":
                    return new ImageManager.SetFade(
                        target: Convert.ToString(parameters["target"]),
                        name: Convert.ToString(parameters["name"]),
                        alpha: Convert.ToSingle(parameters["alpha"]),
                        duration: Convert.ToSingle(parameters["duration"])
                    );

                case "ImageManager.SetBlur":
                    return new ImageManager.SetBlur(
                        target: Convert.ToString(parameters["target"]),
                        name: Convert.ToString(parameters["name"]),
                        radius: Convert.ToSingle(parameters["radius"]),
                        duration: Convert.ToSingle(parameters["duration"])
                    );

                case "ImageManager.SetColor":
                    return new ImageManager.SetColor(
                        target: Convert.ToString(parameters["target"]),
                        name: Convert.ToString(parameters["name"]),
                        colorcode: Convert.ToString(parameters["colorcode"])
                    );
                case "ImageManager.SetColorByFactor":
                    return new ImageManager.SetColorByFactor(
                        target: Convert.ToString(parameters["target"]),
                        name: Convert.ToString(parameters["name"]),
                        factor: Convert.ToSingle(parameters["factor"])
                    );

                case "ImageManager.SetShakeState":
                    return new ImageManager.SetShakeState(
                        target: Convert.ToString(parameters["target"]),
                        name: Convert.ToString(parameters["name"]),
                        state: Convert.ToString(parameters["state"]),
                        loop: Convert.ToBoolean(parameters["loop"])
                    );

                case "ImageManager.SetKeepMove":
                    return new ImageManager.SetKeepMove(
                        target: Convert.ToString(parameters["target"]),
                        name: Convert.ToString(parameters["name"]),
                        x: Convert.ToInt32(parameters["x"]),
                        y: Convert.ToInt32(parameters["y"]),
                        angle: Convert.ToSingle(parameters["angle"]),
                        scale: Convert.ToSingle(parameters["scale"]),
                        duration: Convert.ToSingle(parameters["duration"]),
                        curve: Convert.ToString(parameters["curve"]),
                         alpha:Convert.ToSingle(parameters["alpha"]),
                        alphaTime:Convert.ToSingle(parameters["alphaTime"])

 
                    );
                case "ImageManager.StopMove":
                    return new ImageManager.StopMove(
                        target: Convert.ToString(parameters["target"]),
                        name: Convert.ToString(parameters["name"])
                    );
                case "ImageManager.PlayVideo":
                    return new ImageManager.PlayVideo(
                        target: Convert.ToString(parameters["target"]),
                        name: Convert.ToString(parameters["name"]),
                        video: Convert.ToString(parameters["video"]),
                        loop: Convert.ToBoolean(parameters["loop"]),
                        volume: Convert.ToSingle(parameters["volume"])
                    );
                case "ImageManager.PlayImageSequence":
                    return new ImageManager.PlayImageSequence(
                        target: Convert.ToString(parameters["target"]),
                        name: Convert.ToString(parameters["name"]),
                        framePatterns: Convert.ToString(parameters["framePatterns"]),
                        onComplete: Convert.ToString(parameters["onComplete"]),
                        speed: Convert.ToSingle(parameters["speed"])
                    );
                case "ImageManager.PlayEffect":
                    return new ImageManager.PlayEffect(
                        target: Convert.ToString(parameters["target"]),
                        name: Convert.ToString(parameters["name"]),
                        type: Convert.ToString(parameters["type"]),
                        direction: Convert.ToString(parameters["direction"]),
                        duration: Convert.ToSingle(parameters["duration"])
                    );
                case "ImageManager.AddKeyScrollView":
                    return new ImageManager.AddKeyScrollView(
                        target: Convert.ToString(parameters["target"]),
                        name: Convert.ToString(parameters["name"]),
                        texture: Convert.ToString(parameters["texture"]),
                        direction: Convert.ToString(parameters["direction"]),
                        x: Convert.ToInt32(parameters["x"]),
                        y: Convert.ToInt32(parameters["y"]),
                        height: Convert.ToInt32(parameters["height"]),
                        width: Convert.ToInt32(parameters["width"])
                    );
                case "ImageManager.SetCall":
                    return new ImageManager.SetCall(
                        target: Convert.ToString(parameters["target"]),
                        name: Convert.ToString(parameters["name"]),
                        enabled:Convert.ToBoolean(parameters["enabled"])
                    );
                default:
                    throw new ArgumentException($"Unknown type: {type}");
            }

        }

        public static Base CreateCommand(string type, Dictionary<string, object> parameters, string identifier)
        {
            switch (type)
            {
                case "WaitCommand":
                    Debug.Log($"Dict:{parameters} {parameters == null}");
                    LogDictionary(parameters);
                    return new WaitCommand(Convert.ToSingle(parameters["duration"]));
                case "PrintCommand":
                    return new PrintCommand(Convert.ToString(parameters["message"]));
                case "ParallelCommand":
                case "SequentialCommand":
                    Debug.Log($"Dict:{parameters} {parameters == null}");
                    List<Base> subCommands = new List<Base>();
                    if (parameters["subcommands"] is List<object> subCommandList)
                    {
                        foreach (Dictionary<string, object> subCommandDict in subCommandList)
                        {
                            subCommands.Add(CreateCommand(subCommandDict));
                        }
                    }
                    else
                    {
                        throw new ArgumentException($"Sub commands of {identifier} failed, pleasee recompile the script.");
                    }
                    return type == "ParallelCommand" ? new ParallelCommand(subCommands) : new SequentialCommand(subCommands);
                case "DelayedExecution":
                    var waitCommand = new WaitCommand(Convert.ToSingle(parameters["duration"]));
                    var command = CreateCommand((Dictionary<string, object>)parameters["command"]);
                    List<Base> subCommandsImpl = new List<Base>
                    {
                        waitCommand,
                        command
                    };
                    return new SequentialCommand(subCommandsImpl);
                case "ConditionalExecution":
                    var subcommand = CreateCommand((Dictionary<string, object>)parameters["command"]);
                    return new ConditionalExecution(subCommand: subcommand,
                    key: Convert.ToString(parameters["key"]), value: Convert.ToBoolean(parameters["value"])
                    );
                case "WaitForClick":
                    return new WaitClickCommand();
                case "SetFlag":
                    return new SetFlag(
                         key: Convert.ToString(parameters["key"]), value: Convert.ToBoolean(parameters["value"])
                    );
                case { } when type.StartsWith("Text."):
                    return CreateTextCommand(type, parameters, identifier);
                case { } when type.StartsWith("ImageManager."):
                    return CreateImageManagerCommand(type, parameters, identifier);
                case { } when type.StartsWith("AudioManager."):
                    return CreateAudioManagerCommand(type, parameters, identifier);
                case { } when type.StartsWith("Frame."):
                    return CreateFrameCommand(type, parameters, identifier);
                case { } when type.StartsWith("Filter."):
                    return CreateFilterCommand(type, parameters, identifier);
                case { } when type.StartsWith("Camera."):
                    return CreateCameraCommand(type, parameters, identifier);
                case { } when type.StartsWith("Engine."):
                    return CreateEngineCommand(type, parameters, identifier);
                default:
                    Debug.LogWarning($"ScriptResolver: Unknown command type {type}");
                    return new NoOpCommand();
            }
        }

    }
}