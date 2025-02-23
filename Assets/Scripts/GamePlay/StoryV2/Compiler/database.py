COMMANDS = {
    "WaitCommand": {
        "duration":1.0,
    },
    "PrintCommand":{
        "message":"",
    },
    "Text.ChangeAlpha": {
        "alpha_began": 0.0,
        "alpha_ended":1.0,
        "time":0.5,
    },
    "Text.ShowText": dict(
        mode="narration",
        name="",
        dialogue="",
        avater="",
        speed = -1
    ),
    "Text.SetTextSpeed": dict(speed=30),
    "Text.SetFontSize": dict(size=32),
    "ImageManager.Add": {
        "target": "",
        "name": "",
        "texture": "",
    },
    "ImageManager.Remove": {
        "target": "",
        "name": "",
    },
    "ImageManager.SetTexture": {
        "target": "",
        "name": "",
        "texture": "",
        "duration": 0.0, # not used
    },
    "ImageManager.SetLocation": {
        "target": "",
        "name": "",
        "x": 0,
        "y": 0,
        "duration": 0.0,
        "curve": "constant",
    },
    "ImageManager.SetScale": {
        "target": "",
        "name": "",
        "scale": 0.0,
        "duration": 0.0,
        "curve": "constant",
    },
    "ImageManager.SetRotation": {
        "target": "",
        "name": "",
        "angle": 0.0,
        "duration": 0.0,
        "curve": "constant",
    },
    "ImageManager.SetFade": {
        "target": "",
        "name": "",
        "alpha": 0.0,
        "duration": 0.0,
    },
    "ImageManager.SetBlur": {
        "target": "",
        "name": "",
        "radius": 0.0,
        "duration": 0.0,
    },
    "ImageManager.SetColor": {
        "target": "",
        "name": "",
        "colorcode": "",
    },
    "ImageManager.SetColorByFactor": {
        "target": "",
        "name": "",
        "factor": 1.0,
    },
    "ImageManager.SetShakeState": {
        "target": "",
        "name": "",
        "state": "",
        "loop": False,
    },
    "ImageManager.SetKeepMove": {
        "target": "",
        "name": "",
        "x": 0,
        "y": 0,
        "angle": 0.0,
        "scale": 0.0,
        "duration": 0.0,
        "curve": "constant",
        "alpha":-1,
        "alphaTime":0,
    },
    "ImageManager.StopMove": {
        "target": "",
        "name": "",
    },
    "ImageManager.PlayVideo": {
        "target": "",
        "name": "",
        "video": "",
        "loop": False,
        "volume": 1.0,
    },
    "ImageManager.PlayImageSequence": {
        "target": "",
        "name": "",
        "framePatterns": "",
        "onComplete": "kill",
        "speed": 1.0,
    },
    "ImageManager.PlayEffect": {
        "target": "",
        "name": "",
        "type": "",
        "direction": "",
        "duration": 0.0,
    },
    "ImageManager.AddKeyScrollView": {
        "target": "",
        "name": "",
        "texture": "",
        "direction": "",
        "x": 0,
        "y": 0,
        "height": 0,
        "width": 0,
    },
    "ImageManager.SetCall": {
        "target": "",
        "name": "",
        "enabled": False,
    },
        "AudioManager.SetBGM": {
        "audio": "",
        "volume": 1.0,
        "loop": False,
        "begin": 0.0,
        "end": 0.0,
    },
    "AudioManager.VolumeChange": {
        "duration": 0.0,
        "begin": 0.0,
        "end": 0.0,
    },
    "AudioManager.SetSE": {
        "audio": "",
        "volume": 1.0,
        "loop": False,
    },
    "AudioManager.StopSE": {},
    "Frame.ViewOn": {
        "image": "",
        "color": "",
        "duration": 0.0,
    },
    "Frame.ViewChange": {
        "image": "",
        "duration": 0.0,
    },
    "Frame.ViewOff": {

        "duration": 0.0,
    },
    "Frame.PictureOn": {
        "image": "",
        "color": "",
        "duration": 0.0,
    },
    "Frame.PictureChange": {
        "image": "",
        "duration": 0.0,
    },
    "Frame.PictureOff": {

        "duration": 0.0,
    },
    "Filter.SetFilter":{
        "name":"",
        "enabled": True,
    },
    "Camera.PlayFx": {
        "name": "",
        "duration": 0.0,
    },
    "Camera.KeepBumpy": {
        "strength": 0.0,
        "duration": 0.0,
    },
    "Camera.StopAction": {
        "action": "",
    },
    "SetFlag":{
        "key":"",
        "value": True,
    },
    "Engine.SetUIMode": {
        "mode": 0,
    },
    "Engine.SetChapter": {
        "id": "",
        "title": "",
    },
    "Engine.JumpToScript": {
        "script": "",
    },
    "Engine.SetVisionTrigger": {
        "animationId": 0,
        "script": "",
    },
    "Engine.DisableVisionTrigger": {},
    "Engine.VisionChange": {
        "animationId": 0,
        "script": "",
        "stopBGM": False,
    },
    "Engine.ClearScene":{

    },
    "Engine.BackToTitle": {},
    "Engine.Select": {
        "key": "",
        "opt1": "",
        "opt2": "",
        "opt3": "",
        "opt4": "",
        "opt5": "",
    },
    "Frame.RineOn": {
        "title": "",
    },
    "Frame.RineOff": {},
    "Frame.RineSpeak": {
        "image": "",
    },
    "Frame.RineChangeAlpha": {
        "alpha_began": 0.0,
        "alpha_ended": 0.0,
        "duration": 0.0,
    },
    "Frame.ViewOn": {
        "color": "blue",
        "duration": 1.0,
    },
    "Frame.ViewOff": {
        "color": "blue",
        "duration": 1.0,
    },
}