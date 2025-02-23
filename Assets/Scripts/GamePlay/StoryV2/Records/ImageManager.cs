using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using Utils;
using System.Linq;
using GamePlay.StoryV2.RecordsResolver;
using GamePlay.StoryV2.Record;
using System.Text.RegularExpressions;
namespace GamePlay.StoryV2.Record.ImageManager

{

    public abstract class ImageManagerBase : Base
    {
        public string target = "Tachie";
        public ImageManagerBase(string target)
        {
            this.target = target;
        }

        public ImageLayerResolverV2 GetLayerManager(ScriptResolverV2 environment)
        {
            switch (target)
            {
                case "Tachie":
                    return environment.tachieResolver;
                case "Image":
                    return environment.imageResolver;
                case "UI":
                    return environment.uIResolver;
                default:
                    return null;
            }
        }

    }
    public class Add : ImageManagerBase
    {
        public string name = "";
        public string texture;

        public Add(string target, string name, string texture) : base(target)
        {
            this.name = name;
            this.texture = texture;
        }

        public override void Start(ScriptResolverV2 environment)
        {
            var manager = GetLayerManager(environment);
            manager.AddKey(name, texture);
            SetComplete();
        }

    }

    public class Remove : ImageManagerBase
    {
        public string name = "";

        public Remove(string target, string name) : base(target)
        {
            this.name = name;
        }

        public override void Start(ScriptResolverV2 environment)
        {
            var manager = GetLayerManager(environment);
            manager.RemoveKey(name);
            SetComplete();
        }

    }

    public class SetTexture : ImageManagerBase
    {
        public string name = "";
        string texture;
        float duration;
        public SetTexture(string target, string name, string texture, float duration) : base(target)
        {
            this.name = name;
            this.texture = texture;
            this.duration = duration;
        }

        public override void Start(ScriptResolverV2 environment)
        {
            var manager = GetLayerManager(environment);
            var animation = manager.SetTexture(name, texture, duration);
            HandleAnimationDefault(animation, environment);

        }

    }

    public class SetLocation : ImageManagerBase
    {
        public string name = "";
        int x;
        int y;
        float duration;

        string curve;
        public SetLocation(string target, string name, int x, int y, float duration, string curve = "constant") : base(target)
        {
            this.name = name;
            this.x = x;
            this.y = y;
            this.duration = duration;
            this.curve = curve;
        }

        public override void Start(ScriptResolverV2 environment)
        {
            var manager = GetLayerManager(environment);
            var animation = manager.SetLocation(name, x, y, duration, curve);
            HandleAnimationDefault(animation, environment);

        }

    }

    public class SetScale : ImageManagerBase
    {
        public string name = "";
        float scale;
        float duration;

        string curve;

        public SetScale(string target, string name, float scale, float duration, string curve) : base(target)
        {
            this.name = name;
            this.scale = scale;
            this.duration = duration;
            this.curve = curve;
        }



        public override void Start(ScriptResolverV2 environment)
        {
            var manager = GetLayerManager(environment);
            var animation = manager.SetScale(name, scale, duration, curve);
            HandleAnimationDefault(animation, environment);
        }

    }

    public class SetRotation : ImageManagerBase
    {
        public string name = "";

        float angle;
        float duration;

        string curve;

        public SetRotation(string target, string name, float angle, float duration, string curve) : base(target)
        {
            this.name = name;
            this.angle = angle;
            this.duration = duration;
            this.curve = curve;
        }



        public override void Start(ScriptResolverV2 environment)
        {
            var manager = GetLayerManager(environment);
            var animation = manager.SetRotation(name, angle, duration, curve);
            HandleAnimationDefault(animation, environment);
        }

    }

    public class SetFade : ImageManagerBase
    {
        public string name = "";

        float alpha;
        float duration;


        public SetFade(string target, string name, float alpha, float duration) : base(target)
        {
            this.name = name;
            this.alpha = alpha;
            this.duration = duration;
        }



        public override void Start(ScriptResolverV2 environment)
        {
            var manager = GetLayerManager(environment);
            var animation = manager.SetFade(name, alpha, duration);
            HandleAnimationDefault(animation, environment);
        }

    }

    
    public class SetBlur : ImageManagerBase
    {
        public string name = "";

        float radius;
        float duration;


        public SetBlur(string target, string name, float radius, float duration) : base(target)
        {
            this.name = name;
            this.radius = radius;
            this.duration = duration;
        }



        public override void Start(ScriptResolverV2 environment)
        {
            var manager = GetLayerManager(environment);
            var animation = manager.SetBlur(name, radius, duration);
            HandleAnimationDefault(animation, environment);
        }

    }

    public class SetCall : ImageManagerBase
    {
        public string name = "";

        bool enabled;


        public SetCall(string target,string name, bool enabled) : base(target)
        {
            this.name = name;
            this.enabled = enabled;
        }

        public override void Start(ScriptResolverV2 environment)
        {
            var manager = GetLayerManager(environment);
            manager.SetCall(name, enabled);
            SetComplete();
        }

    }

    public class SetColor : ImageManagerBase
    {
        public Color color;
        string name;


        public SetColor(string target, string name, string colorcode) : base(target)
        {
            this.name = name;
            color = Colors.FromHex(colorcode);

        }



        public override void Start(ScriptResolverV2 environment)
        {
            var manager = GetLayerManager(environment);
            manager.SetColor(name, color.r, color.g, color.b);
            SetComplete();
        }

    }

    public class SetColorByFactor : ImageManagerBase
    {
        float factor;
        string name;


        public SetColorByFactor(string target, string name,float factor) : base(target)
        {
            this.factor = factor;
            this.name = name;
        }



        public override void Start(ScriptResolverV2 environment)
        {
            var manager = GetLayerManager(environment);
            manager.SetColorByFactor(name,factor);
            SetComplete();
        }

    }


    public class SetShakeState : ImageManagerBase
    {
        public Color color;
        string name;

        string state;

        bool loop;


        public SetShakeState(string target, string name, string state, bool loop) : base(target)
        {
            this.name = name;
            this.state = state;
            this.loop = loop;

        }



        public override void Start(ScriptResolverV2 environment)
        {
            var manager = GetLayerManager(environment);
            if (environment.isSkipping && !loop && state != "none") {
                SetComplete();
                return;
            }
            manager.SetShakeState(name, state, loop);
            SetComplete();
        }

    }

    public class SetKeepMove : ImageManagerBase
    {
        string name;
        int x, y;
        float angle, scale, duration,alpha,alphaTime;
        string curve;

        public SetKeepMove(string target, string name, int x, int y, float angle, float scale, float duration, string curve,float alpha,float alphaTime) : base(target)
        {
            this.name = name;
            this.x = x;
            this.y = y;
            this.angle = angle;
            this.scale = scale;
            this.duration = duration;
            this.curve = curve;
            this.alpha = alpha;
            this.alphaTime = alphaTime;
        }

        public override void Start(ScriptResolverV2 environment)
        {
            var manager = GetLayerManager(environment);
            if (environment.isSkipping){
                duration = 0;
                alphaTime = 0;
            }
            manager.SetKeepMove(name, x, y, scale, angle, duration, curve,alpha,alphaTime);
            SetComplete();
        }

    }

    public class StopMove : ImageManagerBase
    {
        string name;


        public StopMove(string target, string name) : base(target)
        {
            this.name = name;
        }

        public override void Start(ScriptResolverV2 environment)
        {
            var manager = GetLayerManager(environment);
            manager.StopMove(name);
            SetComplete();
        }

    }

    public class PlayVideo : ImageManagerBase
    {
        string name;
        string video;
        bool loop;
        float volume;


        public PlayVideo(string target, string name,string video,bool loop,float volume) : base(target)
        {
            this.name = name;
            this.video = video;
            this.loop = loop;
            this.volume = volume;
        }

        public override void Start(ScriptResolverV2 environment)
        {
            var manager = GetLayerManager(environment);
            var animation = manager.PlayVideo(name,video,loop,volume);
            HandleAnimationDefault(animation,environment);
        }

    }

    public class PlayImageSequence : ImageManagerBase
    {
        string name;
        string framePatterns;
        int start;
        int end;
        string onComplete;
        float speed;

        static (string, int, int)? ProcessString(string input)
        {
            Regex regex = new Regex(@"{(\d+)-(\d+)}");

        // Match the pattern in the text
            Match match = regex.Match(input);
            if (match.Success)
            {
                // Extract the integers from the matched groups
                int start = int.Parse(match.Groups[1].Value);
                int end = int.Parse(match.Groups[2].Value);

                // Replace the matched substring with "{}" to get the desired format
                string formattedText = regex.Replace(input, "{}");
                return (formattedText,start,end);
            }
            else
            {
               return null;
            }
        }


        public PlayImageSequence(string target,string name, string framePatterns, string onComplete, float speed)  : base(target)
        {
            this.name = name;
            var parse = ProcessString(framePatterns);
            if (parse == null ){
                 throw new ArgumentException($"Unknown format for image sequence: {framePatterns}");
            }
            this.framePatterns = parse.Value.Item1;
            this.start = parse.Value.Item2;
            this.end = parse.Value.Item3;
            this.onComplete = onComplete;
            this.speed = speed;
        }
        

        public override void Start(ScriptResolverV2 environment)
        {
            var manager = GetLayerManager(environment);
            var animation = manager.PlayImageSequence(name,framePatterns,start,end,onComplete,speed);
            HandleAnimationDefault(animation,environment);
        }

    }

    
    public class PlayEffect : ImageManagerBase
    {
        string name;
        string type;
        float duration;


        public PlayEffect(string target, string name,string type,string direction,float duration) : base(target)
        {
            if (!string.IsNullOrEmpty(direction)){
                type = $"{type}_{direction}";
            }
            this.name = name;
            this.type = type;
            this.duration = duration;
        }



        public override void Start(ScriptResolverV2 environment)
        {
            var manager = GetLayerManager(environment);
            var animation = manager.PlayEffect(name,type,duration);
            HandleAnimationDefault(animation,environment);
        }

    }

    public class AddKeyScrollView : ImageManagerBase
    {
        string name;
        string texture;
        string direction;

        int x = 0;
        int y = 0;
        int height = 300;
        int width = 300;
        
        public AddKeyScrollView(string target,string name, string texture, string direction, int x, int y, int height, int width): base(target)
        {
            this.name = name;
            this.texture = texture;
            this.direction = direction;
            this.x = x;
            this.y = y;
            this.height = height;
            this.width = width;
        }

        public override void Start(ScriptResolverV2 environment)
        {
            var manager = GetLayerManager(environment);
            manager.AddKeyScrollView(name,texture,direction,x,y,height,width);
            SetComplete();
        }

    }

}
