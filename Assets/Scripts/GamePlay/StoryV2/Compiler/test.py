from marco import MARCOS
def test():
    MARCOS.Wait(0)
    MARCOS.Text__ChangeAlpha(
        alpha_began = 0,
        alpha_ended = 1,
        time = 0.5,
    )
    MARCOS.Text__ShowText(
        mode = "narration",
        name = "",
        dialogue = "",
        avater = "",
        speed = -1,
    )
    MARCOS.Text__TextClear() 
    MARCOS.Text__SetTextSpeed(30) 
    MARCOS.Text__SetFontSize(32) 
    MARCOS.Tachie__CreateTachie(
        name = "",
        image = "",
        scale = 1,
        x = 0,
        y = 0,
        angle = 0,
        alpha = 1,
        multiply = "#FFFFFF",
    )

    MARCOS.Tachie__SetTachie(
        name = "",
        image = "",
        scale = 1,
        x = 0,
        y = 0,
        angle = 0,
        alpha = 1,
        multiply = "#FFFFFF",
    )

    MARCOS.Tachie__ChangeTachie(
        name = "",
        image = "",
        time = 0,
    )

    MARCOS.Tachie__ChangeTachieScale(
        name = "",
        scale_began = 1,
        scale_ended = 2,
        time = 0,
        curve = "uniform",
    )

    MARCOS.Tachie__ChangeTachiePosition(
        name = "",
        x_began = 0,
        y_began = 0,
        x_ended = 960,
        y_ended = 540,
        time = 0,
        curve = "uniform",
    )

    MARCOS.Tachie__ChangeTachieAngle(
        name = "",
        angle_began = 0,
        angle_ended = -15,
        time = 0,
        curve = "uniform",
    )

    MARCOS.Tachie__ChangeTachieAlpha(
        name = "",
        alpha_began = 0,
        alpha_ended = 1,
        time = 0,
    )

    MARCOS.Tachie__TachieMove(
        name = "",
        x_began = 0,
        y_began = 0,
        x_ended = 960,
        y_ended = 540,
        scale_began = 1,
        scale_ended = 2,
        angle_began = 0,
        angle_ended = -15,
        time = 0,
        curve = "uniform",
    )

    MARCOS.Tachie__TachieShow(
        name = "",
        image = "",
        alpha = 1,
        time = 0.5,
    )

    MARCOS.Tachie__TachieHide(
        name = "",
        image = "",
        time = 0.5,
    )

    MARCOS.Tachie__TachieSwitch(
        name_A = "",
        image_A = "",
        time_A = 0.5,
        alpha_B = 1,
        name_B = "",
        image_B = "",
        time_B = 0.5,
    )

    MARCOS.Tachie__TachieVibrate("TachieName", "weak")

    MARCOS.Tachie__TachieKeepVibrate("TachieName", "weak")

    MARCOS.Tachie__TachieKeepMove(
        name = "",
        x_began = 0,
        y_began = 0,
        x_ended = 960,
        y_ended = 540,
        scale_began = 1,
        scale_ended = 2,
        angle_began = 0,
        angle_ended = -15,
        time = 30,
        curve = "uniform",
    )

    MARCOS.Tachie__TachieStopMove("TachieName")

    MARCOS.Tachie__ReleaseTachie("TachieName")



    MARCOS.Picture__CreatePicture(
        name = "",
        image = "",
        scale = 1,
        x = 0,
        y = 0,
        angle = 0,
        alpha = 1,
    )

    MARCOS.Picture__CreateMovie(
        name = "",
        movie = "",
        scale = 1,
        x = 0,
        y = 0,
        angle = 0,
        alpha = 1,
        Loop = True,
    )

    MARCOS.Picture__CreatePage(
        name = "",
        image = "",
        scale = 1,
        x = 0,
        y = 0,
        width = 540,
        height = 960,
        direction = "horizontal",
        angle = 0,
        alpha = 1,
    )

    MARCOS.Picture__PlayAnimation(
        name = "",
        image_array = "",
        release = True,
        scale = 1,
        x = 0,
        y = 0,
        angle = 0,
        alpha = 1,
    )

    MARCOS.Picture__SetPicture(
        name = "",
        image = "",
        scale = 1,
        x = 0,
        y = 0,
        angle = 0,
        alpha = 1,
    )

    MARCOS.Picture__ChangePicture(
        name = "",
        image = "",
        time = 0,
    )

    MARCOS.Picture__ChangePictureScale(
        name = "",
        scale_began = 1,
        scale_ended = 2,
        time = 0,
        curve = "uniform",
    )

    MARCOS.Picture__ChangePicturePosition(
        name = "",
        x_began = 0,
        y_began = 0,
        x_ended = 960,
        y_ended = 540,
        time = 0,
        curve = "uniform",
    )

    MARCOS.Picture__ChangePictureAngle(
        name = "",
        angle_began = 0,
        angle_ended = 15,
        time = 0,
        curve = "uniform",
    )

    MARCOS.Picture__ChangePictureAlpha(
        name = "",
        alpha_began = 0,
        alpha_ended = 1,
        time = 0,
    )

    MARCOS.Picture__PictureMove(
        name = "",
        x_began = 0,
        y_began = 0,
        x_ended = 960,
        y_ended = 540,
        scale_began = 1,
        scale_ended = 2,
        angle_began = 0,
        angle_ended = 15,
        time = 0,
        curve = "uniform",
        alpha_began = 0,
        alpha_ended = 1,
        alpha_time = 0.5,
    )

    MARCOS.Picture__PictureVibrate("PictureName", "weak")

    MARCOS.Picture__PictureKeepVibrate("PictureName", "weak")

    MARCOS.Picture__PictureKeepMove(
        name = "",
        x_began = 0,
        y_began = 0,
        x_ended = 960,
        y_ended = 540,
        scale_began = 1,
        scale_ended = 2,
        angle_began = 0,
        angle_ended = 15,
        time = 0,
        curve = "uniform",
        alpha_began = 0,
        alpha_ended = 1,
        alpha_time = 0.5,
    )

    MARCOS.Picture__PictureStopMove("PictureName")

    MARCOS.Picture__ExpandIn(
        name = "",
        direction = "horizontal",
        time = 0.7,
    )

    MARCOS.Picture__ExpandOut(
        name = "",
        direction = "horizontal",
        time = 0.7,
    )

    MARCOS.Picture__CoveringIn(
        name = "",
        direction = "up",
        time = 0.5,
    )

    MARCOS.Picture__CoveringOut(
        name = "",
        direction = "up",
        time = 0.5,
    )

    MARCOS.Picture__GateIn(
        name = "",
        time = 0.5,
    )

    MARCOS.Picture__GateOut(
        name = "",
        time = 0.5,
    )

    MARCOS.Picture__ClockIn(
        name = "",
        time = 0.5,
    )

    MARCOS.Picture__ClockOut(
        name = "",
        time = 0.5,
    )

    MARCOS.Picture__SpeedLineOn()

    MARCOS.Picture__SpeedLineOff()

    MARCOS.Picture__ReleasePicture("PictureName")



    MARCOS.Frame__ViewOn(
        image = "",
        color = "pink",
        duration = 0.5,
    )

    MARCOS.Frame__ViewChange(
        image = "",
        duration = 0.5,
    )

    MARCOS.Frame__ViewOff(0.5)

    MARCOS.Frame__PictureOn(
        image = "",
        color = "pink",
        duration = 0.5,
    )

    MARCOS.Frame__PictureChange(
        image = "",
        duration = 0.5,
    )

    MARCOS.Frame__PictureOff(0.5)

    # MARCOS.Frame__RineOn(
    #     title = "",
    #     color = "pink",
    # )

    # MARCOS.Frame__RineSpeak(
    #     image = "",
    # )

    # MARCOS.Frame__RineChangeAlpha(
    #     alpha_began = 1,
    #     alpha_ended = 0,
    #     time = 0.5,
    # )

    # MARCOS.Frame__RineOff()



    MARCOS.Filter__MemoryOn()

    MARCOS.Filter__MemoryOff()

    MARCOS.Filter__FlakeOn()

    MARCOS.Filter__FlakeOff()



    MARCOS.Camera__SparkingWhite(0.3)

    MARCOS.Camera__WhiteRestore(0.3)

    MARCOS.Camera__OpenEyes(1)

    MARCOS.Camera__CloseEyes(1)

    MARCOS.Camera__CameraVibrate("weak")

    MARCOS.Camera__CameraKeepBumpy(30,0.8)

    MARCOS.Camera__CameraStopMove()



    MARCOS.BGM__SetBGM(
        audio = "",
        volume = 1,
        loop = True,
        loop_begin = 0,
        loop_end = 120,
    )

    MARCOS.BGM__VolumeChange(
        volume_began = 0,
        volume_ended = 1,
        time = 0.5,
    )



    MARCOS.SE__SetSE(
        audio = "",
        volume = 1,
        loop = True,
    )

    MARCOS.SE__StopSE()



    MARCOS.Program__Select(
        key="",
        option1 = "",
        option2 = "",
        option3 = "",
        option4 = "",
        option5 = "",
    )

    MARCOS.SetUIMode(0)

    MARCOS.SetChapter("01", "边界徘徊的七等星")

    MARCOS.StoryBlock(3, True)

    MARCOS.StoryArrow(3, True)

    MARCOS.Trigger(3, True)

    MARCOS.CanSkip(True)

    MARCOS.CanAuto(True)

    MARCOS.JumpToScript("sv.01.01__txt")

    MARCOS.VisionTriggerOn(1, "sv.01.10__txt")

    MARCOS.VisionTriggerOff()

    MARCOS.VisionChange(1, "sv.01.10__txt")

    MARCOS.VisionChangeWithBGM(1, "sv.01.10__txt")

    MARCOS.BackToTitle()

test()