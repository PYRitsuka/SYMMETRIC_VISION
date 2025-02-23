//——————以下为控制流相关函数——————

WaitForClick(); //点击触发

cmd_block //并行处理
{ 
    at 0, command1();
    at 1.1, command2();
    at 2.1, cmd_block { at 0, command1(); }
    at 4.0, {command4(); command2();}
}

if(variable==true)//条件触发
{ 
    command1();
}

wait(0);//等待0秒





//——————以下为文本类——————

Text.ChangeAlpha //改变文本框透明度
(
    alpha_began = 0,
    alpha_ended = 1,
    time = 0.5,
);

Text.ShowText //显示文本
(
    mode = "narration", // / dialogue / avatar, //对话框的三种模式，当mode值变化时对话框会自动变形
    name = "",
    dialogue = "",
    avater = "", //头像文件名，不填就是没有
    speed = 30, //每秒弹字个数，如果不填就默认等于Text.textspeed
);

Text.TextClear(); //便捷的清空文本框命令，相当于ShowText什么也不填

Text.SetTextSpeed(30); //将默认的弹字速度Text.textspeed设定为30

Text.SetFontSize(32); //将默认字号设定为32





//——————以下为立绘类——————
//所有立绘的图片尺寸都是1024×2048

Tachie.CreateTachie //创建一张新立绘
(
    name = "", //设定新立绘的标记名
    image = "", //新立绘的png名
    scale = 1, //设定初始缩放
    x = 0, //设定初始x坐标
    y = 0, //设定初始y坐标
    angle = 0, //设定默认旋转角
    alpha = 1, //设定初始不透明度
    multiply = "#FFFFFF", //设置正片叠底
);

Tachie.SetTachie //设置立绘参数
(
    name = "", //选中立绘标记名
    image = "", //设置立绘图片
    scale = 1, //设置缩放
    x = 0,
    y = 0, //设置坐标
    angle = 0, //设置旋转角
    alpha = 1, //设置不透明度
    multiply = "#FFFFFF", //设置正片叠底
);

Tachie.ChangeTachie //更改立绘图片
(
    name = "", //选中立绘标记名
    image = "", //新立绘的png名
    time = 0, //渐变所耗时间
);

Tachie.ChangeTachieScale //更改立绘缩放
(
    name = "",
    scale_began = 1, //初始缩放
    scale_ended = 2, //结束缩放
    time = 0, //渐变所耗时间
    curve = "uniform" // / easyin / easyout //运动曲线设定为匀速/缓入/缓出
);

Tachie.ChangeTachiePosition //更改立绘坐标
(
    name = "",
    x_began = 0,
    y_began = 0, //初始坐标
    x_ended = 960,
    y_ended = 540, //结束坐标
    time = 0,
    curve = "uniform" // / easyin / easyout
);

Tachie.ChangeTachieAngle //更改立绘旋转角
(
    name = "",
    angle_began = 0,
    angle_ended = -15, //逆时针旋转15°（以图片中心为转轴）
    time = 0,
    curve = "uniform" // / easyin / easyout
);

Tachie.ChangeTachieAlpha //更改立绘不透明度
(
    name = "",
    alpha_began = 0,
    alpha_ended = 1,
    time = 0,
);

Tachie.TachieMove //同时更改立绘的坐标、缩放、旋转角
(
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
    curve = "uniform" // / easyin / easyout
);

Tachie.TachieShow //先切换立绘图片，然后将立绘的不透明度从0变到1
(
    name = "",
    image = "", //新立绘的png名，不填就是不换图片
    alpha = 1, //目标不透明度，之所以设置这个参数，是因为佐野阳向在幽灵状态下显示立绘是从0变到0.8
    time = 0.5, //透明度变化所耗时间
);

Tachie.TachieHide //先切换立绘图片，然后将立绘的不透明度从现在的值变到0
(
    name = "",
    image = "", //新立绘的png名，不填就是不换图片
    time = 0.5, //透明度变化所耗时间
);

Tachie.TachieSwitch //先对立绘A进行Hide操作，再对立绘B进行Show操作
(
    name_A = "",
    image_A = "",
    time_A = 0.5,
    alpha_A = 1,
    name_B = "",
    image_B = "",
    time_B = 0.5,
);

Tachie.TachieVibrate("TachieName",
 "weak", // / medium / strong
); //立绘振动，分弱中强三档

Tachie.TachieKeepVibrate("TachieName", "weak", // / medium / strong
); //立绘持续振动，直到遇到TachieStopMove();停下，坐标回到原位

Tachie.TachieKeepMove //参数和TachieMove相同，立绘持续移动，直到遇到TachieStopMove();停下，坐标停在当时
(
    name = "",
    x_began = 0,
    y_began = 0,
    x_ended = 960,
    y_ended = 540,
    scale_began = 1,
    scale_ended = 2,
    angle_began = 0,
    angle_ended = -15,
    time = 30, //如果运动时间走完仍没有遇到TachieStopMove();，则停在移动完成后的位置
    curve = "uniform" // / easyin / easyout
);

Tachie.TachieStopMove("TachieName"); //打断立绘的持续运动

Tachie.ReleaseTachie("TachieName"); //释放掉立绘





//——————以下为图片/UI类——————
//图片/UI的所有函数格式和功能完全一样，区别仅在于UI图层位于立绘上方，而图片图层位于立绘下方。

Picture.CreatePicture //创建新图片
(
    name = "", //设定新图片的标记名
    image = "", //新图片的png名
    scale = 1, //设定初始缩放
    x = 0, //设定初始x坐标
    y = 0, //设定初始y坐标
    angle = 0, //设定默认旋转角
    alpha = 1, //设定初始不透明度
);

Picture.CreateMovie //创建新视频
(
    name = "",
    movie = "", //新视频的mp4名
    scale = 1,
    x = 0,
    y = 0,
    angle = 0,
    alpha = 1,
    Loop = true, //是否循环播放，当Loop值为false的时候，本函数自动附加一个长度等于视频长度的wait时间
);

Picture.CreatePage //创建可滚动图片（一般是用来做网页）
(
    name = "",
    image = "",
    scale = 1,
    x = 0,
    y = 0,
    weight = 540, //滚动图片的宽度
    height = 960, //滚动图片的高度
    direction = "horizontal", //滚动方向设置为横向或竖向
    angle = 0,
    alpha = 1,
);

Picture.PlayAnimation //逐帧播放一组图片，1秒30帧，以形成动画效果
(
    name = "",
    image_array = "", //例如填"打斗特效"四个字的话，就从AB包中把"打斗特效(1).png"后面括号带数字的这些图片从1读到最后一个数字
    releas = true, //是否在播放完动画后立即释放掉object，如果填false，则播放完动画后停在最后一帧图片，此后将它视为普通Picture
    scale = 1,
    x = 0,
    y = 0,
    angle = 0,
    alpha = 1,
);

Picture.SetPicture //设置图片参数
(
    name = "", //选中图片标记名
    image = "", //设置图片
    scale = 1, //设置缩放
    x = 0,
    y = 0, //设置坐标
    angle = 0, //设置旋转角
    alpha = 1, //设置不透明度
);

Picture.ChangePicture //更改图片
(
    name = "", //选中图片标记名
    image = "", //新图片的png名
    time = 0, //渐变所耗时间
);

Picture.ChangePictureScale //更改图片缩放
(
    name = "",
    scale_began = 1, //初始缩放
    scale_ended = 2, //结束缩放
    time = 0, //渐变所耗时间
    curve = "uniform" //运动曲线设定为匀速/缓入/缓出
);

Picture.ChangePicturePosition //更改图片坐标
(
    name = "",
    x_began = 0,
    y_began = 0, //初始坐标
    x_ended = 960,
    y_ended = 540, //结束坐标
    time = 0,
    curve = "uniform",
);

Picture.ChangePictureAngle //更改图片旋转角
(
    name = "",
    angle_began = 0,
    angle_ended = 15, //顺时针旋转15°（以图片中心为转轴）
    time = 0,
    curve = "uniform",
);

Picture.ChangePictureAlpha //更改图片不透明度
(
    name = "",
    alpha_began = 0,
    alpha_ended = 1,
    time = 0,
);

Picture.PictureMove //同时更改图片的坐标、缩放、旋转角、不透明度
(
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
    alpha_ended = 1, //透明度的变化为匀速，渐变时间为独立于time的alpha_time，不受速度曲线curve影响
    alpha_time = 0.5,
);

Picture.PictureVibrate("PictureName", "weak",); //图片振动，分弱中强三档

Picture.PictureKeepVibrate("PictureName", "weak",); //图片持续振动，直到遇到PictureStopMove();停下，坐标回到原位

Picture.PictureKeepMove //参数和PictureMove相同，图片持续移动，直到遇到PictureStopMove();停下，坐标停在当时
(
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
);

Picture.PictureStopMove("PictureName"); //打断图片的持续运动

Picture.ExpandIn //图片不透明度改为1，然后播放展开效果
(
    name = "",
    direction = "horizontal", //展开方向设置为横向或竖向
    time = 0.7,
);

Piture.ExpandOut  //播放收起效果，然后图片不透明度改为0
(
    name = "",
    direction = "horizontal",
    time = 0.7,
);

Picture.CoveringIn //遮盖入场效果，用黑色遮罩盖在图片上方，图片不透明度改为1，然后通过移开黑色遮罩实现入场效果
(
    name = "",
    direction = "up", //遮罩移开的方向
    time = 0.5,
);

Picture.CoveringOut //遮盖离场效果，用黑色遮罩盖在图片上方，通过移上黑色遮罩实现离场效果，然后图片不透明度改为0
(
    name = "",
    direction = "up", //遮罩移上的方向
    time = 0.5,
);

Picture.GateIn //用左右两个遮罩实现开门入场效果
(
    name = "",
    time = 0.5,
);

Picture.GateOut //用左右两个遮罩实现关门离场效果
(
    name = "",
    time = 0.5,
);

Picture.ClockIn //时钟入场效果
(
    name = "",
    time = 0.5,
);

Picture.ClockOut //时钟离场效果
(
    name = "",
    time = 0.5,
);

Picture.SpeedLineOn(); //播放速度线动画

Picture.SpeedLineOff(); //关闭速度线动画

Picture.ReleasePicture("PictureName"); //释放掉图片





//——————以下为Frame类——————

Frame.ViewOn //开启VIEW，图层位于立绘层上方、UI层下方，位置缩放固定不可改
(
    image = "", //设定VIEW框体内显示的图片名
    color = "pink", //设置VIEW框体的颜色
    duration = 0.5, //动画播放耗时
);

Frame.ViewChange //更改VIEW内图片
(
    image = "",
    duration = 0.5,
);

Frame.ViewOff(0.5); //关闭VIEW界面

Frame.PictureOn //开启图片框体
(
    image = "",
    color = "pink",
    duration = 0.5,
);

Frame.PictureChange //更改框体内图片
(
    image = "",
    duration = 0.5,
);

Frame.PictureOff(0.5); //关闭图片框体

Frame.RineOn //开启Rine
(
    title = "", //将聊天Title图片居中挂在聊天框顶部
    color = "pink",
);

Frame.RineSpeak //追加聊天发言
(
    image = "", //追加的发言图片名
);

Frame.RineChangeAlpha //更改RINE界面透明度
(
    alpha_began = 1,
    alpha_ended = 0,
    duration = 0.5,
);


Frame.RineOff(); //关闭RINE界面





//——————以下为滤镜类——————
//滤镜图层位于立绘图层上方、UI图层下方

Filter.MemoryOn(); //回忆滤镜

Filter.MemoryOff(); //关闭回忆滤镜

Filter.FlakeOn(); //雪花屏滤镜

Filter.FlakeOff(); //关闭雪花屏滤镜





//——————以下为镜头类——————
//镜头层位于UI图层上方，可以同时控制UI、Frame、立绘、图片四个图层

Camera.SparkingWhite(0.3); //用0.3秒闪至全白

Camera.WhiteRestore(0.3); //用0.3秒从闪白恢复

Camera.OpenEyes(1); //睁眼效果，1秒。

Camera.CloseEyes(1); //闭眼效果，1秒。闭眼后如不睁眼，镜头图层就会一直盖着一层黑色遮罩

Camera.CameraVibrate("weak"); //镜头振动，分弱中强三档

Camera.CameraKeepBumpy(30,0.8); //镜头持续上下颠簸，模拟跑步动作。两个参数30为振幅，0.8为上下颠簸一次的周期。直到遇到CameraStopMove();，镜头才会停止颠簸回归原位。

Camera.CameraStopMove(); //打断镜头运动





//——————以下为BGM类——————

BGM.SetBGM //设定BGM
(
    audio = "", //BGM的mp3名
    volume = 1, //BGM的音量，最低0最高1
    loop = true, //是否循环播放
    loop_begin = 0, //循环开始的秒数，当BGM放完后回到这一秒接上循环
    loop_end = 120, //循环结束的秒数，当BGM放到这一秒后跳回begin接上循环。如果此处填0就代表不需要接循环，BGM直接从头放到尾再从头放起就行。
);

BGM.VolumeChange //音量变化
(
    volume_began = 0,
    volume_ended = 1,
    time = 0.5,
);





//——————以下为SE类——————

SE.SetSE //设定SE
(
    audio = "", //SE的ogg名
    volume = 1, //SE的音量，最低0最高1
    loop = true, //是否循环播放
);

SE.StopSE(); //打断正在播放的所有SE





//——————以下为一些杂七杂八的程序功能——————

Program.Select //选择肢
(
    key = "",
    option1 = "", //最多5个选项，不填就等于没这个选项
    option2 = "", //玩家选择选项2后，剧本内置的变量option值就会变为2。此时剧本写作者就可以通过if(option==2){}来编辑选择选项后的分支剧情
    option3 = "",
    option4 = "",
    option5 = "",
);

SetUIMode(0); //设置UI颜色模式，之后立刻刷新文本框UI
              //0 = 粉色BMI视角
              //1 = 粉色自由视角
              //2 = 蓝色BMI视角
              //3 = 蓝色自由视角
              //4 = 灰色BMI视角
              //5 = 灰色自由视角

SetChapter("01", "边界徘徊的七等星"); //设置章节名，第一个参数为章节号，第二个参数为章节名

StoryBlock(3, true); //更改Global变量StoryBlock[n]，将剧情树内对应方块标记为可显示

StoryArrow(3, true); //更改Global变量StoryArrow[n]，将剧情树内对应箭头标记为可显示

Trigger(3, true); //更改Global变量Trigger[n]，主要用于玩家走过一遍BE后回头能通过if(Trigger[n]==true){};来触发其他剧情分支

CanSkip(true); //是否允许玩家跳过的开关，开关值变化后Skip状态立刻刷新

CanAuto(true); //是否允许玩家自动播放的开关，开关值变化后Auto状态立刻刷新

JumpToScript("sv_01_01.txt"); //跳转到下一个脚本文件

VisionTriggerOn(1, "sv_01_10.txt"); //开启视角转换扳机监听，玩家在监听开启期间按下扳机就可以跳转到下个脚本文件
                                    //第一个参数为1就播放女主转男主视角的动画，为0就播放男主转女主视角的动画

VisionTriggerOff(); //关闭视角转换扳机监听

VisionChange(1, "sv_01_10.txt"); //视角转换，切到下个脚本文件

VisionChangeWithBGM(1, "sv_01_10.txt"); //视角转换且不打断BGM

BackToTitle(); //返回TitleScene