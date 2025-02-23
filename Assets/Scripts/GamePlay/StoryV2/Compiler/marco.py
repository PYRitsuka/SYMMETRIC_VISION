from typing import Any
from database import COMMANDS
import copy

KEEP = "KEEP"
NUM_KEEP = -9999


class MARCOS_CLS:
    registry = {}
    is_marco = set()

    def __getattribute__(self, name: str) -> Any:
        if name in MARCOS_CLS.registry:
            return MARCOS_CLS.registry[name]
        else:
            return super().__getattribute__(name)


MARCOS = MARCOS_CLS()


def build_payload(func_name, base):
    def inner(*args, **kwargs):
        base_copy = copy.deepcopy(base)
        keys = list(base.keys())
        set_keys = set()
        for i, v in enumerate(args):
            assert i < len(keys), f"Out of bounds: {func_name} {base} {args}"
            base_copy[keys[i]] = v
            set_keys.add(keys[i])
        for k in kwargs.keys():
            assert k not in set_keys, k
            assert k in base, (func_name, k)
            typea = type(base[k])
            typeb = type(kwargs[k])
            assert typea == typeb or (
                typea in [float, int] and typeb in [float, int]
            ), f"invalid args {base[k]} <- {kwargs[k]}"
        base_copy.update(kwargs)
        return {
            "CommandType": func_name,
            "Identifier": 1,
            "Parameters": base_copy,
        }

    return inner


def init_marcos():
    for k, v in COMMANDS.items():
        MARCOS.registry[k.replace(".", "__")] = build_payload(k, v)


init_marcos()


def _sequential(subcommands):
    subcommands = list([x for x in subcommands if x])
    if len(subcommands) == 1:
        return subcommands[0]
    if subcommands:
        payload = {
            "CommandType": "SequentialCommand",
            "Identifier": 1,
            "Parameters": {"subcommands": subcommands},
        }
    else:
        payload = {"CommandType": "NOOP", "Identifier": 1, "Parameters": {}}
    return payload


def _parallel(subcommands):
    subcommands = list([x for x in subcommands if x])
    payload = {
        "CommandType": "ParallelCommand",
        "Identifier": 1,
        "Parameters": {"subcommands": subcommands},
    }
    return payload


def _delayed(command, delay=0.0):
    payload = {
        "CommandType": "DelayedExecution",
        "Identifier": 1,
        "Parameters": {"duration": delay, "command": command},
    }
    return payload



def __build(fun_name, *args, **kwargs):
    return MARCOS.registry[fun_name.replace(".", "__")](*args, **kwargs)


def register(f):
    name = f.__name__
    assert "___" not in name
    MARCOS.registry[name] = f
    MARCOS.is_marco.add(name)
    return f


@register
def Wait(duration):
    return MARCOS.WaitCommand(
        duration=duration,
    )


@register
def Script__Narration(
    name: object = "",
    dialogue: object = "",
    avater: object = "",
    speed: object = 30,
):
    return __build(
        "Text.ShowText",
        mode="narration",
        name="",
        dialogue=dialogue,
        avater="",
        speed=speed,
    )


@register
def Script__Dialogue(
    name: object = "",
    dialogue: object = "",
    avater: object = "",
    speed: object = 30,
):
    return __build(
        "Text.ShowText",
        mode="dialogue",
        name=name,
        dialogue=dialogue,
        avater="",
        speed=speed,
    )


@register
def Script__Avatar(
    name: object = "",
    dialogue: object = "",
    avater: object = "",
    speed: object = 30,
):
    return __build(
        "Text.ShowText",
        mode="avatar",
        name=name,
        dialogue=dialogue,
        avater=avater,
        speed=speed,
    )


@register
def Script__Text(
        name: object = "",
        dialogue: object = "",
        avater: object = "",
        speed: object = 30,
):
    return __build(
        "Text.ShowText",
        mode="narration" if name=="" else "dialogue" if avater=="" else "avatar",
        name=name,
        dialogue=dialogue,
        avater=avater,
        speed=speed,
    )


@register
def Text__Show(time=0.5):
    return _parallel(
        [
            Text__Clear(),
            __build("Text.ChangeAlpha", alpha_began=0, alpha_ended=1, time=time)
        ]
    )

@register
def Text__Hide(time=0.5):
    return _parallel(
        [
            Text__Clear(),
            __build("Text.ChangeAlpha", alpha_began=1, alpha_ended=0, time=time,)
        ]
    )

@register
def Text__Clear():
    return __build(
        "Text.ShowText", mode="narration", name="", dialogue="", avater="", speed=9999
    )


@register
def Tachie__Create(
    name: object = "",
    image: object = "",
    scale: object = 1,
    x: object = 0,
    y: object = 0,
    angle: object = 0,
    alpha: object = 1,
    multiply: object = "#FFFFFF",
) -> object:
    return _sequential(
        [
            MARCOS.ImageManager__Add("Tachie", name=name, texture=image),
            MARCOS.ImageManager__SetScale("Tachie", name=name, scale=scale),
            MARCOS.ImageManager__SetLocation("Tachie", name=name, x=x, y=y),
            MARCOS.ImageManager__SetRotation("Tachie", name=name, angle=angle),
            MARCOS.ImageManager__SetFade("Tachie", name=name, alpha=alpha),
            MARCOS.ImageManager__SetColor("Tachie", name=name, colorcode=multiply),
        ]
    )


@register
def Tachie__Set(
    name="",
    image=KEEP,
    scale=KEEP,
    x=NUM_KEEP,
    y=NUM_KEEP,
    angle=0,
    alpha=-1,
    multiply=KEEP,
):
    return _sequential(
        [
            (
                __build("ImageManager.SetTexture", "Tachie", name=name, texture=image)
                if image != KEEP
                else None
            ),
            (
                MARCOS.ImageManager__SetScale("Tachie", name=name, scale=scale)
                if scale != KEEP
                else None
            ),
            MARCOS.ImageManager__SetLocation("Tachie", name=name, x=x, y=y),
            MARCOS.ImageManager__SetRotation("Tachie", name=name, angle=angle),
            (
                MARCOS.ImageManager__SetFade("Tachie", name=name, alpha=alpha)
                if alpha >= 0
                else None
            ),
            (
                MARCOS.ImageManager__SetColor("Tachie", name=name, colorcode=multiply)
                if "#" in multiply
                else None
            ),
        ]
    )


@register
def Tachie__Change(
    name="",
    image="",
    time=0,
):
    return _sequential(
        [
            __build(
                "ImageManager.SetTexture",
                "Tachie",
                name=name,
                texture=image,
                duration=time,
            ),
        ]
    )


@register
def Tachie__Scale(
    name="",
    scale_began=KEEP,
    scale_ended=KEEP,
    time=0,
    curve="uniform",
):
    return _sequential(
        [
            (
                __build("ImageManager.SetScale", "Tachie", name, scale_began)
                if scale_began != KEEP
                else None
            ),
            (
                __build(
                    "ImageManager.SetScale", "Tachie", name, scale_ended, time, curve
                )
                if scale_ended != KEEP
                else None
            ),
        ]
    )


@register
def Tachie__Position(
    name="",
    x_began=NUM_KEEP,
    y_began=NUM_KEEP,
    x_ended=NUM_KEEP,
    y_ended=NUM_KEEP,
    time=0,
    curve="uniform",
):
    return _sequential(
        [
            __build("ImageManager.SetLocation", "Tachie", name, x_began, y_began),
            __build(
                "ImageManager.SetLocation",
                "Tachie",
                name,
                x_ended,
                y_ended,
                time,
                curve,
            ),
        ]
    )


@register
def Tachie__Angle(
    name="",
    angle_began=KEEP,
    angle_ended=KEEP,
    time=0,
    curve="uniform",
):
    return _sequential(
        [
            (
                __build("ImageManager.SetRotation", "Tachie", name, angle_began)
                if angle_began != KEEP
                else None
            ),
            (
                __build(
                    "ImageManager.SetRotation", "Tachie", name, angle_ended, time, curve
                )
                if angle_ended != KEEP
                else None
            ),
        ]
    )


@register
def Tachie__Alpha(
    name="",
    alpha_began=0,
    alpha_ended=1,
    time=0,
):
    return _sequential(
        [
            __build("ImageManager.SetFade", "Tachie", name, alpha_began),
            __build("ImageManager.SetFade", "Tachie", name, alpha_ended, time),
        ]
    )


@register
def Tachie__Move(
    name="",
    x_began=NUM_KEEP,
    y_began=NUM_KEEP,
    x_ended=NUM_KEEP,
    y_ended=NUM_KEEP,
    scale_began=KEEP,
    scale_ended=KEEP,
    angle_began=KEEP,
    angle_ended=KEEP,
    time=0,
    curve="uniform",
    alpha_began=KEEP,
    alpha_ended=KEEP,
    alpha_time=0,
):
    return _parallel(
        [
            Tachie__Position(name, x_began, y_began, x_ended, y_ended, time, curve),
            Tachie__Angle(name, angle_began, angle_ended, time, curve),
            Tachie__Scale(name, scale_began, scale_ended, time, curve),
            Picture__Alpha(name, alpha_began, alpha_ended, alpha_time),
        ]
    )


@register
def Tachie__Show(
    name="",
    image=KEEP,
    alpha=1,
    time=0.5,
):
    return _sequential(
        [
            Tachie__Change(name, image, 0) if image != KEEP else None,
            Tachie__Alpha(name, 0, alpha, time),
        ]
    )


@register
def Tachie__Hide(
    name="",
    image=KEEP,
    time=0.5,
):
    return _sequential(
        [
            Tachie__Change(name, image, 0) if image != KEEP else None,
            __build("ImageManager.SetFade", "Tachie", name, 0, time),
        ]
    )


@register
def Tachie__Switch(
    name_A="",
    image_A=KEEP,
    time_A=0.2,
    alpha_B=1,
    name_B="",
    image_B=KEEP,
    time_B=0.2,
):
    return _sequential(
        [
            Tachie__Hide(name_A, image_A, time_A),
            Tachie__Show(name_B, image_B, alpha_B, time_B),
        ]
    )


@register
def Tachie__Vibrate(name, strength):
    return __build("ImageManager.SetShakeState", "Tachie", name, strength)


@register
def Tachie__KeepVibrate(name, strength):
    return __build("ImageManager.SetShakeState", "Tachie", name, strength, loop=True)

@register
def Tachie__CoveringIn(
    name="",
    direction="up",
    time=0.5,
):
    return __build(
        "ImageManager.PlayEffect", "Tachie", name, "CoveringIn", direction, time
    )


@register
def Tachie__CoveringOut(
    name="",
    direction="up",
    time=0.5,
):
    return __build(
        "ImageManager.PlayEffect", "Tachie", name, "CoveringOut", direction, time
    )


@register
def Tachie__KeepMove(
    name="",
    x_began=0,
    y_began=0,
    x_ended=0,
    y_ended=0,
    scale_began=1,
    scale_ended=1,
    angle_began=0,
    angle_ended=0,
    time=0,
    curve="uniform",
):
    return _sequential(
        [
            Tachie__Set(
                name,
                KEEP,
                scale_began,
                x_began,
                y_began,
                angle_began,
                -1,
                multiply=KEEP,
            ),
            __build(
                "ImageManager.SetKeepMove",
                "Tachie",
                name,
                x_ended,
                y_ended,
                angle_ended,
                scale_ended,
                time,
                curve,
            ),
        ]
    )


@register
def Tachie__StopMove(name):
    return __build("ImageManager.StopMove", "Tachie", name)


@register
def Tachie__Release(name):
    return __build("ImageManager.Remove", "Tachie", name)


## Imagees


@register
def Picture__Create(
    name="",
    image="",
    scale=1,
    x=0,
    y=0,
    angle=0,
    alpha=1,
):
    return _sequential(
        [
            MARCOS.ImageManager__Add("Image", name=name, texture=image),
            MARCOS.ImageManager__SetScale("Image", name=name, scale=scale),
            MARCOS.ImageManager__SetLocation("Image", name=name, x=x, y=y),
            MARCOS.ImageManager__SetRotation("Image", name=name, angle=angle),
            MARCOS.ImageManager__SetFade("Image", name=name, alpha=alpha),
        ]
    )


@register
def Picture__CreateMovie(
    name="",
    movie="",
    scale=1,
    x=0,
    y=0,
    angle=0,
    alpha=1,
    Loop=False,
):
    return _sequential(
        [
            MARCOS.ImageManager__Add("Image", name=name, texture=""),
            MARCOS.ImageManager__SetScale("Image", name=name, scale=scale),
            MARCOS.ImageManager__SetLocation("Image", name=name, x=x, y=y),
            MARCOS.ImageManager__SetRotation("Image", name=name, angle=angle),
            MARCOS.ImageManager__SetFade("Image", name=name, alpha=alpha),
            __build("ImageManager.PlayVideo", "Image", name, movie, Loop),
        ]
    )


@register
def Picture__CreatePage(
    name="",
    image="",
    scale=1,
    x=0,
    y=0,
    width=540,
    height=960,
    direction="horizontal",
    angle=0,
    alpha=1,
):
    return _sequential(
        [
            __build(
                "ImageManager.AddKeyScrollView",
                "Image",
                name,
                image,
                direction,
                x,
                y,
                height,
                width,
            ),
            MARCOS.ImageManager__SetScale("Image", name=name, scale=scale),
            MARCOS.ImageManager__SetRotation("Image", name=name, angle=angle),
            MARCOS.ImageManager__SetFade("Image", name=name, alpha=alpha),
        ]
    )


@register
def Picture__PlayAnimation(
    name="",
    image_array="",
    release=True,
    scale=1,
    x=0,
    y=0,
    angle=0,
    alpha=1,
):
    return _sequential(
        [
            MARCOS.ImageManager__Add("Image", name=name, texture=""),
            __build(
                "ImageManager.PlayImageSequence",
                "Image",
                name,
                image_array,
                onComplete="kill" if release else "none",
            ),
            MARCOS.ImageManager__SetLocation("Image", name=name, x=x, y=y),
            MARCOS.ImageManager__SetScale("Image", name=name, scale=scale),
            MARCOS.ImageManager__SetRotation("Image", name=name, angle=angle),
            MARCOS.ImageManager__SetFade("Image", name=name, alpha=alpha),
        ]
    )


@register
def Picture__Set(
    name="",
    image=KEEP,
    scale=KEEP,
    x=NUM_KEEP,
    y=NUM_KEEP,
    angle=KEEP,
    alpha=KEEP,
):
    return _sequential(
        [
            (
                __build("ImageManager.SetTexture", "Image", name=name, texture=image)
                if image != KEEP
                else None
            ),
            (
                MARCOS.ImageManager__SetScale("Image", name=name, scale=scale)
                if scale != KEEP
                else None
            ),
            MARCOS.ImageManager__SetLocation("Image", name=name, x=x, y=y),
            (
                MARCOS.ImageManager__SetRotation("Image", name=name, angle=angle)
                if angle != KEEP
                else None
            ),
            (
                MARCOS.ImageManager__SetFade("Image", name=name, alpha=alpha)
                if alpha != KEEP
                else None
            ),
        ]
    )


@register
def Picture__Change(
    name="",
    image="",
    time=0,
):
    return _sequential(
        [
            __build(
                "ImageManager.SetTexture",
                "Image",
                name=name,
                texture=image,
                duration=time,
            ),
        ]
    )


@register
def Picture__Scale(
    name="",
    scale_began=KEEP,
    scale_ended=KEEP,
    time=0,
    curve="uniform",
):
    return _sequential(
        [
            (
                __build("ImageManager.SetScale", "Image", name, scale_began)
                if scale_began != KEEP
                else None
            ),
            (
                __build(
                    "ImageManager.SetScale", "Image", name, scale_ended, time, curve
                )
                if scale_ended != KEEP
                else None
            ),
        ]
    )


@register
def Picture__Position(
    name="",
    x_began=NUM_KEEP,
    y_began=NUM_KEEP,
    x_ended=NUM_KEEP,
    y_ended=NUM_KEEP,
    time=0,
    curve="uniform",
):
    return _sequential(
        [
            __build("ImageManager.SetLocation", "Image", name, x_began, y_began),
            __build(
                "ImageManager.SetLocation", "Image", name, x_ended, y_ended, time, curve
            ),
        ]
    )


@register
def Picture__Angle(
    name="",
    angle_began=KEEP,
    angle_ended=KEEP,
    time=0,
    curve="uniform",
):
    return _sequential(
        [
            (
                __build("ImageManager.SetRotation", "Image", name, angle_began)
                if angle_began != KEEP
                else None
            ),
            (
                __build(
                    "ImageManager.SetRotation", "Image", name, angle_ended, time, curve
                )
                if angle_ended != KEEP
                else None
            ),
        ]
    )


@register
def Picture__Alpha(
    name="",
    alpha_began=KEEP,
    alpha_ended=KEEP,
    time=0,
):
    return _sequential(
        [
            (
                __build("ImageManager.SetFade", "Image", name, alpha_began)
                if alpha_began != KEEP
                else None
            ),
            (
                __build("ImageManager.SetFade", "Image", name, alpha_ended, time)
                if alpha_ended != KEEP
                else None
            ),
        ]
    )

@register
def Picture__Show(name="" ,time = 0):
    return Picture__Alpha(name,0,1,time)

@register
def Picture__Hide(name="" ,time = 0):
    return Picture__Alpha(name,1,0,time)

@register
def Picture__Move(
    name="",
    x_began=NUM_KEEP,
    y_began=NUM_KEEP,
    x_ended=NUM_KEEP,
    y_ended=NUM_KEEP,
    scale_began=KEEP,
    scale_ended=KEEP,
    angle_began=KEEP,
    angle_ended=KEEP,
    time=0,
    curve="uniform",
    alpha_began=KEEP,
    alpha_ended=KEEP,
    alpha_time=0,
):
    return _parallel(
        [
            Picture__Position(name, x_began, y_began, x_ended, y_ended, time, curve),
            Picture__Angle(name, angle_began, angle_ended, time, curve),
            Picture__Scale(name, scale_began, scale_ended, time, curve),
            Picture__Alpha(name, alpha_began, alpha_ended, alpha_time),
        ]
    )


@register
def Picture__Vibrate(name, strength):
    return __build("ImageManager.SetShakeState", "Image", name, strength)


@register
def Picture__KeepVibrate(name, strength):
    return __build("ImageManager.SetShakeState", "Image", name, strength, loop=True)


@register
def Picture__KeepMove(
    name="",
    x_began=0,
    y_began=0,
    x_ended=0,
    y_ended=0,
    scale_began=1,
    scale_ended=1,
    angle_began=0,
    angle_ended=0,
    time=0,
    curve="uniform",
    alpha_began=1,
    alpha_ended=1,
    alpha_time=0,
):
    return _sequential(
        [
            Picture__Set(
                name, KEEP, scale_began, x_began, y_began, angle_began, alpha_began
            ),
            __build(
                "ImageManager.SetKeepMove",
                "Image",
                name,
                x_ended,
                y_ended,
                angle_ended,
                scale_ended,
                time,
                curve,
                alpha_ended,
                alpha_time,
            ),
        ]
    )


@register
def Picture__StopMove(name):
    return __build("ImageManager.StopMove", "Image", name)


@register
def Picture__ExpandIn(
    name="",
    direction="horizontal",
    time=0.7,
):
    return __build(
        "ImageManager.PlayEffect", "Image", name, "ExpandIn", direction, time
    )


@register
def Picture__ExpandOut(
    name="",
    direction="horizontal",
    time=0.7,
):
    return __build(
        "ImageManager.PlayEffect", "Image", name, "ExpandOut", direction, time
    )


@register
def Picture__CoveringIn(
    name="",
    direction="up",
    time=0.5,
):
    return __build(
        "ImageManager.PlayEffect", "Image", name, "CoveringIn", direction, time
    )


@register
def Picture__CoveringOut(
    name="",
    direction="up",
    time=0.5,
):
    return __build(
        "ImageManager.PlayEffect", "Image", name, "CoveringOut", direction, time
    )


@register
def Picture__GateIn(
    name="",
    time=0.5,
):
    return __build("ImageManager.PlayEffect", "Image", name, "GateIn", "", time)


@register
def Picture__GateOut(
    name="",
    time=0.5,
):
    return __build("ImageManager.PlayEffect", "Image", name, "GateOut", "", time)


@register
def Picture__ClockIn(
    name="",
    time=0.5,
):
    return __build("ImageManager.PlayEffect", "Image", name, "ClockIn", "", time)


@register
def Picture__ClockOut(
    name="",
    time=0.5,
):
    return __build("ImageManager.PlayEffect", "Image", name, "ClockOut", "", time)


@register
def Picture__SpeedLineOn():
    return __build("Camera.PlayFx", "SpeedLineOn", 0)


@register
def Picture__SpeedLineOff():
    return __build("Camera.PlayFx", "SpeedLineOff", 0)


@register
def Picture__Release(name):
    return __build("ImageManager.Remove", "Image", name)

@register
def Picture__Blur(name,radius=0.0,duration=0.0):
    return __build("ImageManager.SetBlur", "Image", name,radius,duration)

#################### UI###############################
@register
def UI__Blur(name,radius=0.0,duration=0.0):
    return __build("ImageManager.SetBlur", "UI", name,radius,duration)


@register
def UI__Create(
    name="",
    image="",
    scale=1,
    x=0,
    y=0,
    angle=0,
    alpha=1,
):
    return _sequential(
        [
            MARCOS.ImageManager__Add("UI", name=name, texture=image),
            MARCOS.ImageManager__SetScale("UI", name=name, scale=scale),
            MARCOS.ImageManager__SetLocation("UI", name=name, x=x, y=y),
            MARCOS.ImageManager__SetRotation("UI", name=name, angle=angle),
            MARCOS.ImageManager__SetFade("UI", name=name, alpha=alpha),
        ]
    )


@register
def UI__CreateMovie(
    name="",
    movie="",
    scale=1,
    x=0,
    y=0,
    angle=0,
    alpha=1,
    Loop=False,
):
    return _sequential(
        [
            MARCOS.ImageManager__Add("UI", name=name, texture=""),
            MARCOS.ImageManager__SetScale("UI", name=name, scale=scale),
            MARCOS.ImageManager__SetLocation("UI", name=name, x=x, y=y),
            MARCOS.ImageManager__SetRotation("UI", name=name, angle=angle),
            MARCOS.ImageManager__SetFade("UI", name=name, alpha=alpha),
            __build("ImageManager.PlayVideo", "UI", name, movie, Loop),
        ]
    )


@register
def UI__CreatePage(
    name="",
    image="",
    scale=1,
    x=0,
    y=0,
    width=540,
    height=960,
    direction="horizontal",
    angle=0,
    alpha=1,
):
    return _sequential(
        [
            __build(
                "ImageManager.AddKeyScrollView",
                "UI",
                name,
                image,
                direction,
                x,
                y,
                height,
                width,
            ),
            MARCOS.ImageManager__SetScale("UI", name=name, scale=scale),
            MARCOS.ImageManager__SetRotation("UI", name=name, angle=angle),
            MARCOS.ImageManager__SetFade("UI", name=name, alpha=alpha),
        ]
    )


@register
def UI__PlayAnimation(
    name="",
    image_array="",
    release=True,
    scale=1,
    x=0,
    y=0,
    angle=0,
    alpha=1,
):
    return _sequential(
        [
            MARCOS.ImageManager__Add("UI", name=name, texture=""),
            __build(
                "ImageManager.PlayImageSequence",
                "UI",
                name,
                image_array,
                onComplete="kill" if release else "none",
            ),
            MARCOS.ImageManager__SetLocation("UI", name=name, x=x, y=y),
            MARCOS.ImageManager__SetScale("UI", name=name, scale=scale),
            MARCOS.ImageManager__SetRotation("UI", name=name, angle=angle),
            MARCOS.ImageManager__SetFade("UI", name=name, alpha=alpha),
        ]
    )


@register
def UI__Set(
    name="",
    image=KEEP,
    scale=KEEP,
    x=NUM_KEEP,
    y=NUM_KEEP,
    angle=KEEP,
    alpha=KEEP,
):
    return _sequential(
        [
            (
                __build("ImageManager.SetTexture", "UI", name=name, texture=image)
                if image != KEEP
                else None
            ),
            (
                MARCOS.ImageManager__SetScale("UI", name=name, scale=scale)
                if scale != KEEP
                else None
            ),
            MARCOS.ImageManager__SetLocation("UI", name=name, x=x, y=y),
            (
                MARCOS.ImageManager__SetRotation("UI", name=name, angle=angle)
                if angle != KEEP
                else None
            ),
            (
                MARCOS.ImageManager__SetFade("UI", name=name, alpha=alpha)
                if alpha != KEEP
                else None
            ),
        ]
    )


@register
def UI__Change(
    name="",
    image="",
    time=0,
):
    return _sequential(
        [
            __build(
                "ImageManager.SetTexture",
                "UI",
                name=name,
                texture=image,
                duration=time,
            ),
        ]
    )


@register
def UI__Scale(
    name="",
    scale_began=KEEP,
    scale_ended=KEEP,
    time=0,
    curve="uniform",
):
    return _sequential(
        [
            (
                __build("ImageManager.SetScale", "UI", name, scale_began)
                if scale_began != KEEP
                else None
            ),
            (
                __build("ImageManager.SetScale", "UI", name, scale_ended, time, curve)
                if scale_ended != KEEP
                else None
            ),
        ]
    )


@register
def UI__Position(
    name="",
    x_began=NUM_KEEP,
    y_began=NUM_KEEP,
    x_ended=NUM_KEEP,
    y_ended=NUM_KEEP,
    time=0,
    curve="uniform",
):
    return _sequential(
        [
            __build("ImageManager.SetLocation", "UI", name, x_began, y_began),
            __build(
                "ImageManager.SetLocation", "UI", name, x_ended, y_ended, time, curve
            ),
        ]
    )


@register
def UI__Angle(
    name="",
    angle_began=KEEP,
    angle_ended=KEEP,
    time=0,
    curve="uniform",
):
    return _sequential(
        [
            (
                __build("ImageManager.SetRotation", "UI", name, angle_began)
                if angle_began != KEEP
                else None
            ),
            (
                __build(
                    "ImageManager.SetRotation", "UI", name, angle_ended, time, curve
                )
                if angle_ended != KEEP
                else None
            ),
        ]
    )


@register
def UI__Alpha(
    name="",
    alpha_began=KEEP,
    alpha_ended=KEEP,
    time=0,
):
    return _sequential(
        [
            (
                __build("ImageManager.SetFade", "UI", name, alpha_began)
                if alpha_began != KEEP
                else None
            ),
            (
                __build("ImageManager.SetFade", "UI", name, alpha_ended, time)
                if alpha_ended != KEEP
                else None
            ),
        ]
    )

@register
def UI__Show(name="" ,time = 0):
    return UI__Alpha(name,0,1,time)

@register
def UI__Hide(name="" ,time = 0):
    return UI__Alpha(name,1,0,time)


@register
def UI__Move(
    name="",
    x_began=NUM_KEEP,
    y_began=NUM_KEEP,
    x_ended=NUM_KEEP,
    y_ended=NUM_KEEP,
    scale_began=KEEP,
    scale_ended=KEEP,
    angle_began=KEEP,
    angle_ended=KEEP,
    time=0,
    curve="uniform",
    alpha_began=KEEP,
    alpha_ended=KEEP,
    alpha_time=0,
):
    return _parallel(
        [
            UI__Position(name, x_began, y_began, x_ended, y_ended, time, curve),
            UI__Angle(name, angle_began, angle_ended, time, curve),
            UI__Scale(name, scale_began, scale_ended, time, curve),
            UI__Alpha(name, alpha_began, alpha_ended, alpha_time),
        ]
    )


@register
def UI__Vibrate(name, strength):
    return __build("ImageManager.SetShakeState", "UI", name, strength)


@register
def UI__KeepVibrate(name, strength):
    return __build("ImageManager.SetShakeState", "UI", name, strength, loop=True)


@register
def UI__KeepMove(
    name="",
    x_began=0,
    y_began=0,
    x_ended=0,
    y_ended=0,
    scale_began=1,
    scale_ended=1,
    angle_began=0,
    angle_ended=0,
    time=0,
    curve="uniform",
    alpha_began=1,
    alpha_ended=1,
    alpha_time=0,
):
    return _sequential(
        [
            UI__Set(
                name, KEEP, scale_began, x_began, y_began, angle_began, alpha_began
            ),
            __build(
                "ImageManager.SetKeepMove",
                "UI",
                name,
                x_ended,
                y_ended,
                angle_ended,
                scale_ended,
                time,
                curve,
                alpha_ended,
                alpha_time,
            ),
        ]
    )


@register
def UI__StopMove(name):
    return __build("ImageManager.StopMove", "UI", name)


@register
def UI__ExpandIn(
    name="",
    direction="horizontal",
    time=0.7,
):
    return __build("ImageManager.PlayEffect", "UI", name, "ExpandIn", direction, time)


@register
def UI__ExpandOut(
    name="",
    direction="horizontal",
    time=0.7,
):
    return __build("ImageManager.PlayEffect", "UI", name, "ExpandOut", direction, time)


@register
def UI__CoveringIn(
    name="",
    direction="up",
    time=0.5,
):
    return __build("ImageManager.PlayEffect", "UI", name, "CoveringIn", direction, time)


@register
def UI__CoveringOut(
    name="",
    direction="up",
    time=0.5,
):
    return __build(
        "ImageManager.PlayEffect", "UI", name, "CoveringOut", direction, time
    )


@register
def UI__GateIn(
    name="",
    time=0.5,
):
    return __build("ImageManager.PlayEffect", "UI", name, "GateIn", "", time)


@register
def UI__GateOut(
    name="",
    time=0.5,
):
    return __build("ImageManager.PlayEffect", "UI", name, "GateOut", "", time)


@register
def UI__ClockIn(
    name="",
    time=0.5,
):
    return __build("ImageManager.PlayEffect", "UI", name, "ClockIn", "", time)


@register
def UI__ClockOut(
    name="",
    time=0.5,
):
    return __build("ImageManager.PlayEffect", "UI", name, "ClockOut", "", time)


@register
def UI__SpeedLineOn():
    return __build("Camera.PlayFx", "SpeedLineOn", 0)


@register
def UI__SpeedLineOff():
    return __build("Camera.PlayFx", "SpeedLineOff", 0)


@register
def UI__Release(name):
    return __build("ImageManager.Remove", "UI", name)


############################################## End UI ###############################
####################### Frames are Natively in C#
# @register
# def Frame__ViewOn(
#     image = "",
#     color = "pink",
#     time = 0.5,
# ):

# @register
# def Frame__ViewChange(
#     image = "",
#     time = 0.5,
# ):

# @register
# def Frame__ViewOff(0.5)

# @register
# def Frame__PictureOn(
#     image = "",
#     color = "pink",
#     time = 0.5,
# ):

# @register
# def Frame__PictureChange(
#     image = "",
#     time = 0.5,
# ):

# @register
# def Frame__PictureOff(0.5)

# @register
# def Frame__RineOn(
#     title = "",
#     color = "pink",
# ):

# @register
# def Frame__RineSpeak(
#     image = "",
# ):

# @register
# def Frame__RineChangeAlpha(
#     alpha_began = 1,
#     alpha_ended = 0,
#     time = 0.5,
# ):
####################### End Frame
####################### TODO: Not Implemented Rine
# @register
# def Frame__RineOff()


@register
def Filter__MemoryOn():
    return UI__Create(name="Filter",image="//滤镜/回忆滤镜.png",scale=1,x=0,y=0,angle=0,alpha=0.1)
    #return __build("Filter.SetFilter", "memory", True)

@register
def Filter__MemoryOff():
    return UI__Release("Filter")
    #return __build("Filter.SetFilter", "memory", False)


@register
def Filter__FlakeOn():
    return __build("Filter.SetFilter", "flake", True)


@register
def Filter__FlakeOff():
    return __build("Filter.SetFilter", "flake", False)


@register
def Camera__SparkingWhite(duration):
    return __build("Camera.PlayFx", "SparkingWhite", duration)


@register
def Camera__WhiteRestore(duration):
    return __build("Camera.PlayFx", "WhiteRestore", duration)


@register
def Camera__OpenEyes(duration):
    return __build("Camera.PlayFx", "OpenEyes", duration)


@register
def Camera__CloseEyes(duration):
    return __build("Camera.PlayFx", "CloseEyes", duration)


@register
def Camera__Vibrate(strength):
    assert strength in ["weak", "medium", "strong"]
    return __build("Camera.PlayFx", f"Shake_{strength}", 0.0)


#@register
#def Camera__KeepBumpy(strength, duration):
#    return __build("Camera.KeepBumpy", strength, duration)


@register
def Camera__StopMove():
    return __build("Camera.StopAction")


@register
def BGM__Set(
    audio="",
    volume=1,
    loop=True,
    loop_begin=0,
    loop_end=0,
):
    return __build("AudioManager.SetBGM", audio, volume, loop, loop_begin, loop_end)


@register
def BGM__Volume(
    volume_began=1,
    volume_ended=0,
    time=0,
):
    return __build("AudioManager.VolumeChange", time, volume_began, volume_ended)

@register
def BGM__Stop():
    return BGM__Set("//BGM/A01_Pulse_PVver.mp3", 0, False, 0,0)

@register
def SE__Play(
    audio="",
    volume=1,
    loop=False,
):
    return __build("AudioManager.SetSE", audio, volume, loop)


@register
def SE__Stop():
    return __build("AudioManager.StopSE")


@register
def Program__Select(
    key="",
    option1="",
    option2="",
    option3="",
    option4="",
    option5="",
):
    return __build("Engine.Select", key, option1, option2, option3, option4, option5)


@register
def SetUIMode(mode):
    return __build("Engine.SetUIMode", mode)


@register
def SetChapter(id, name):
    return __build("Engine.SetChapter", id, name)


def internal_set_flag(key, value):
    return __build("SetFlag", key, value)


def internal_set_sys_flag(key, value):
    key = "SYSTEM__" + key
    return internal_set_flag(key, value)


@register
def StoryBlock(id, value=True):
    return internal_set_sys_flag(f"StoryBlock_{id}", value)


@register
def StoryArrow(id, value=True):
    return internal_set_sys_flag(f"StoryArrow_{id}", value)


@register
def Trigger(id, value=True):
    return internal_set_sys_flag(f"Trigger_{id}", value)


@register
def CanSkip(value):
    return internal_set_flag(f"CanSkip", value)


@register
def CanAuto(value):
    return internal_set_flag(f"CanAuto", value)


## Native Implementation
@register
def JumpToScript(script):
    return __build("Engine.JumpToScript", script)


@register
def VisionTriggerOn(id, script):
    return __build("Engine.SetVisionTrigger", id, script)


@register
def VisionTriggerOff():
    return __build("Engine.DisableVisionTrigger")


@register
def VisionChange(id, script):
    return __build("Engine.VisionChange", id, script, True)


@register
def VisionChangeWithBGM(id, script):
    return __build("Engine.VisionChange", id, script, False)


@register
def BackToTitle():
    return __build("Engine.BackToTitle")


@register
def ClearScene():
    return __build("Engine.ClearScene")


# test()


def hex_to_rgb(hex_color):
    hex_color = hex_color.lstrip("#")
    return tuple(int(hex_color[i : i + 2], 16) for i in (0, 2, 4))


def rgb_to_hex(rgb_color):
    return "#{:02x}{:02x}{:02x}".format(*rgb_color)


@register
def Tachie__Multiply(name, color=KEEP, factor=1.0):
    if color == KEEP:
        return MARCOS.ImageManager__SetColorByFactor("Tachie", name=name, factor=factor)
    assert color.startswith("#") and len(color) == 7, f"Invalid Color {color}"
    r, g, b = hex_to_rgb(color)
    r = int(r * factor)
    g = int(g * factor)
    b = int(b * factor)
    for i in (r, g, b):
        assert i >= 0 and i < 255, "Invalid Color after multiplication"

    hex = rgb_to_hex((r, g, b))
    return MARCOS.ImageManager__SetColor("Tachie", name=name, colorcode=hex)


@register
def Tachie__BackandForce(name="",ox=0,oy=0,x=0,y=0,time=0,curve="",):
    return _sequential(
        [
            Tachie__Position(name=name,x_began=ox,y_began=oy,x_ended=(ox-x),y_ended=(oy+y),time=(time/2),curve=curve),
            Tachie__Position(name=name,x_began=(ox-x),y_began=(oy+y),x_ended=ox,y_ended=oy,time=(time/2),curve=curve),
        ]
    )


@register
def Tachie__SetCall(name="", enabled=False):
    return MARCOS.ImageManager__SetCall("Tachie", name, enabled)


@register
def Script__Expression(
    name="",
    image=KEEP,
    textmode="dialogue",
    textname="",
    dialogue="",
    speed=30,
):
    return _parallel(
        [
            Tachie__Change(name, image, 0.2) if image != KEEP else None,
            __build(
                "Text.ShowText",
                mode=textmode if textname != "" else "narration",
                name=textname,
                dialogue=dialogue,
                avater="",
                speed=speed,
            )
        ]
    )


@register
def Script__Speaker(
    nameA="",
    nameB="",
    imageA=KEEP,
    textmode="dialogue",
    textname="",
    dialogue="",
    speed=30,
):
    return _parallel(
        [
            Tachie__Multiply(name=nameA, factor=2.5) if nameA != "" else None,
            Tachie__Multiply(name=nameB, factor=0.4) if nameB != "" else None,
            Tachie__Change(nameA, imageA, 0.2) if imageA != KEEP else None,
            __build(
                "Text.ShowText",
                mode=textmode if textname != "" else "narration",
                name=textname,
                dialogue=dialogue,
                avater="",
                speed=speed,
            )
        ]
    )

@register
def Script__SpeakerShow(
        nameA="",
        imageA=KEEP,
        alphaA=1,
        nameB="",
        imageB=KEEP,
        alphaB=1,
        time=0.5,
        textmode="dialogue",
        textname="",
        dialogue="",
        speed=30,
):
    return _parallel(
        [
            Tachie__Show(
                name=nameA,
                image=imageA,
                alpha=alphaA,
                time=0.5,
            ),
            Tachie__Show(
                name=nameB,
                image=imageB,
                alpha=alphaB,
                time=0.5,
            ),
            _delayed(Tachie__Multiply(name=nameB, factor=0.4),delay=time if time!=0.2 else 0),
            _delayed(__build(
                "Text.ShowText",
                mode=textmode if textname != "" else "narration",
                name=textname,
                dialogue=dialogue,
                avater="",
                speed=speed,
            ),delay=time),
        ]
    )

@register
def Script__SpeakerHide(
        nameA="",
        nameB="",
        time=0.5,
        textmode="dialogue",
        textname="",
        dialogue="",
        speed=30,
):
    return _parallel(
        [
            Tachie__Hide(
                name=nameA,
                image=KEEP,
                time=time,
            ),
            Tachie__Hide(
                name=nameB,
                image=KEEP,
                time=time,
            ),
            _delayed(Tachie__Multiply(name=nameA, factor=2.5),delay=time),
            _delayed(__build(
                "Text.ShowText",
                mode=textmode if textname != "" else "narration",
                name=textname,
                dialogue=dialogue,
                avater="",
                speed=speed,
            ),delay=time),
        ]
    )


@register
def Script__Character(
    nameA="",
    nameB="",
    imageB=KEEP,
    alphaB=1,
    textmode="dialogue",
    textname="",
    dialogue="",
    speed=30,
):
    return _parallel(
        [
            Tachie__Switch(
                name_A=nameA,
                time_A=0.2,
                name_B=nameB,
                image_B=imageB,
                time_B=0.2,
                alpha_B=alphaB,
            ),
            _delayed(__build(
                "Text.ShowText",
                mode=textmode if textname != "" else "narration",
                name=textname,
                dialogue=dialogue,
                avater="",
                speed=speed,
            ),0.2)
        ]
    )


@register
def Script__CharacterShow(
        name="",
        image=KEEP,
        alpha=1,
        time=0.5,
        textmode="dialogue",
        textname="",
        dialogue="",
        speed=30,
):
    return _parallel(
        [
            Tachie__Show(
                name=name,
                image=image,
                alpha=alpha,
                time=time,
            ),
            __build(
                "Text.ShowText",
                mode=textmode if textname != "" else "narration",
                name=textname,
                dialogue=dialogue,
                avater="",
                speed=speed,
            )
        ]
    )


@register
def Script__CharacterHide(
        name="",
        time=0.5,
        textmode="dialogue",
        textname="",
        dialogue="",
        speed=30,
):
    return _parallel(
        [
            Tachie__Hide(
                name=name,
                image=KEEP,
                time=time,
            ),
            __build(
                "Text.ShowText",
                mode=textmode if textname != "" else "narration",
                name=textname,
                dialogue=dialogue,
                avater="",
                speed=speed,
            )
        ]
    )


@register
def Script__KeepMoveShow(
        bg="",
        tc="",
        tcimage=KEEP,
        bgx=0,
        bgy=0,
        tcx=0,
        tcy=0,
        direction="",
        keeptime=60,
        time=0.5,
):
    return _parallel(
        [
            Picture__KeepMove(
                name=bg,
                x_began=bgx,
                y_began=bgy,
                x_ended=bgx+300 if direction=="right" else bgx-300 if direction=="left" else bgx,
                y_ended=bgy+150 if direction=="down" else bgy-150 if direction=="up" else bgy,
                scale_began=1.5,
                scale_ended=1.5,
                angle_began=0,
                angle_ended=0,
                time=keeptime,
                curve="uniform",
                alpha_began=0,
                alpha_ended=1,
                alpha_time=time,),
            Tachie__KeepMove(
                name=tc,
                x_began=tcx,
                y_began=tcy,
                x_ended=tcx-150 if direction=="right" else tcx+150 if direction=="left" else tcx,
                y_ended=tcy-75 if direction=="down" else tcy+75 if direction=="up" else tcy,
                scale_began=1.5,
                scale_ended=1.5,
                angle_began=0,
                angle_ended=0,
                time=keeptime,
                curve="uniform",),
            Tachie__Show(
                name=tc,
                image=tcimage,
                alpha=1,
                time=time,
            ),
        ]
    )


@register
def Script__KeepMoveHide(
        bg="",
        tc="",
        time=0.5,
):
    return _parallel(
        [
            Picture__Alpha(
                name=bg,
                alpha_began=1,
                alpha_ended=0,
                time=time,),
            Tachie__Hide(
                name=tc,
                time=time,
            ),
            _delayed(Picture__StopMove(bg),delay=time),
            _delayed(Tachie__StopMove(tc),delay=time)
        ]
    )


@register
def Script__KeepMoveAbove(
        bgh="",
        tch="",
        bg="",
        tc="",
        tcimage=KEEP,
        bgx=0,
        bgy=0,
        tcx=0,
        tcy=0,
        direction="",
        keeptime=60,
        time=0.5,
):
    return _parallel(
        [
            Picture__KeepMove(
                name=bg,
                x_began=bgx,
                y_began=bgy,
                x_ended=bgx+300 if direction=="right" else bgx-300 if direction=="left" else bgx,
                y_ended=bgy+150 if direction=="down" else bgy-150 if direction=="up" else bgy,
                scale_began=1.5,
                scale_ended=1.5,
                angle_began=0,
                angle_ended=0,
                time=keeptime,
                curve="uniform",
                alpha_began=0,
                alpha_ended=1,
                alpha_time=time,),
            Tachie__KeepMove(
                name=tc,
                x_began=tcx,
                y_began=tcy,
                x_ended=tcx-150 if direction=="right" else tcx+150 if direction=="left" else tcx,
                y_ended=tcy-75 if direction=="down" else tcy+75 if direction=="up" else tcy,
                scale_began=1.5,
                scale_ended=1.5,
                angle_began=0,
                angle_ended=0,
                time=keeptime,
                curve="uniform",),
            Tachie__Show(
                name=tc,
                image=tcimage,
                alpha=1,
                time=time,
            ),
            Tachie__Hide(
                name=tch,
                time=time,
            ),
            _delayed(Picture__StopMove(bgh),delay=time),
            _delayed(Tachie__StopMove(tch),delay=time)
        ]
    )


@register
def Script__KeepMoveBelow(
        bgh="",
        tch="",
        bg="",
        tc="",
        tcimage=KEEP,
        bgx=0,
        bgy=0,
        tcx=0,
        tcy=0,
        direction="",
        keeptime=60,
        time=0.5,
):
    return _parallel(
        [
            Picture__KeepMove(
                name=bg,
                x_began=bgx,
                y_began=bgy,
                x_ended=bgx+300 if direction=="right" else bgx-300 if direction=="left" else bgx,
                y_ended=bgy+150 if direction=="down" else bgy-150 if direction=="up" else bgy,
                scale_began=1.5,
                scale_ended=1.5,
                angle_began=0,
                angle_ended=0,
                time=keeptime,
                curve="uniform",
                alpha_began=1,
                alpha_ended=1,
                alpha_time=0,),
            Tachie__KeepMove(
                name=tc,
                x_began=tcx,
                y_began=tcy,
                x_ended=tcx-150 if direction=="right" else tcx+150 if direction=="left" else tcx,
                y_ended=tcy-75 if direction=="down" else tcy+75 if direction=="up" else tcy,
                scale_began=1.5,
                scale_ended=1.5,
                angle_began=0,
                angle_ended=0,
                time=keeptime,
                curve="uniform",),
            Tachie__Show(
                name=tc,
                image=tcimage,
                alpha=1,
                time=time,),
            Tachie__Hide(
                name=tch,
                time=time,),
            Picture__Alpha(
                name=bgh,
                alpha_began=1,
                alpha_ended=0,
                time=time,),
            _delayed(Picture__StopMove(bgh),delay=time),
            _delayed(Tachie__StopMove(tch),delay=time)
        ]
    )