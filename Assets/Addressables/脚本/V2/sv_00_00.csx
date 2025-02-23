//C:\Users\10533\Desktop\SYMMETRIC_VISION\Assets\Scripts\GamePlay\StoryV2\Compiler\hook.py --force
//C:\Users\10533\Desktop\SYMMETRIC_VISION\Assets\Scripts\GamePlay\StoryV2\Compiler\preload.py --force


//————————————————————
//——————开场字幕阶段————————
//————————————————————

CanAuto( false);
CanSkip( false);
VisionTrigger( false);
SetChapter( "00","序幕");
SetUIMode( 5);
StoryBlock( 1,true);
BGM.Volume( volume_began = 0, volume_ended = 0, time = 0,); //BGM静音

Text.ChangeAlpha //设定文本框透明
( 
    alpha_began = 0,
    alpha_ended = 0,
    time = 0,
);
Text.SetTextSpeed( 1000); //设定默认弹字速度

Text.ShowText( mode = "dialogue", name = "栗原 瑛斗", dialogue = "视线从天而降。",);
Picture.CreateMovie( name = "p1", movie = "B_第一章_视频/02A_开场字幕.mp4", alpha = 1, Loop = false,);
Picture.Create( name = "p2", image = "B_第一章/02A_开场字幕.png", alpha = 1,);

WaitForClick(); //··
Picture.Release("p2");
Picture.CreateMovie( name = "p1", movie = "B_第一章_视频/02B_开场字幕.mp4", alpha = 1, Loop = false,);
Picture.Create( name = "p2", image = "B_第一章/02B_开场字幕.png", alpha = 1,);
Text.ShowText(mode = "dialogue", name = "栗原 瑛斗", dialogue = "那视线穿过大气、刺透云层和雨雾，直射向我。",);

WaitForClick(); //··
Picture.Release("p2");
Picture.CreateMovie( name = "p1", movie = "B_第一章_视频/02C_开场字幕.mp4", alpha = 1, Loop = false,);
Picture.Create( name = "p2", image = "B_第一章/02C_开场字幕.png", alpha = 1,);
Text.ShowText(mode = "dialogue", name = "栗原 瑛斗", dialogue = "朦胧的意识中，我本能地渴望着这道视线继续注视着我。",);

WaitForClick(); //··
Picture.Release("p2");
Picture.CreateMovie( name = "p1", movie = "B_第一章_视频/02D_开场字幕.mp4", alpha = 1, Loop = false,);
Picture.Create( name = "p2", image = "B_第一章/02D_开场字幕.png", alpha = 1,);
Text.ShowText(mode = "dialogue", name = "栗原 瑛斗", dialogue = "似乎只要不这么做，我细若游丝的存在就会立刻烟消云散。",);

WaitForClick(); //··
Picture.Release("p2");
Picture.CreateMovie( name = "p1", movie = "B_第一章_视频/02E_开场字幕.mp4", alpha = 1, Loop = false,);
Picture.Create( name = "p2", image = "B_第一章/02E_开场字幕.png", alpha = 1,);
Text.ShowText(mode = "dialogue", name = "栗原 瑛斗", dialogue = "…………",);

WaitForClick(); //··
Picture.Release("p2");
Picture.CreateMovie( name = "p1", movie = "B_第一章_视频/02F_开场字幕.mp4", alpha = 1, Loop = false,);
Picture.Create( name = "p2", image = "B_第一章/02F_开场字幕.png", alpha = 1,);
Text.ShowText(mode = "dialogue", name = "栗原 瑛斗", dialogue = "人们把肉眼可见的星体亮度，分为了六个视星等。",);

WaitForClick(); //··
Picture.Release("p2");
Picture.CreateMovie( name = "p1", movie = "B_第一章_视频/02G_开场字幕.mp4", alpha = 1, Loop = false,);
Picture.Create( name = "p2", image = "B_第一章/02G_开场字幕.png", alpha = 1,);
Text.ShowText(mode = "dialogue", name = "栗原 瑛斗", dialogue = "在他们的视野中，不断跳动、明灭交替的“我”，",);

WaitForClick(); //··
Picture.Release("p2");
Picture.CreateMovie( name = "p1", movie = "B_第一章_视频/02H_开场字幕.mp4", alpha = 1, Loop = false,);
Picture.Create( name = "p2", image = "B_第一章/02H_开场字幕.png", alpha = 1,);
Text.ShowText(mode = "dialogue", name = "栗原 瑛斗", dialogue = "是否只允许被测算出七等星的黯淡光亮呢？",);

WaitForClick(); //··
Picture.Release("p2");
Picture.CreateMovie( name = "p1", movie = "B_第一章_视频/02I_开场字幕.mp4", alpha = 1, Loop = false,);

WaitCommand(2);
Picture.CreateMovie( name = "vd1", movie = "B_第一章_视频/03A_世界线变动率.mp4", alpha = 1, Loop = false,);

CanSkip( true);
CanAuto( true);


//————————————————————
//——————废墟中的对话————————
//————————————————————


SE.Play( audio = "//SE/A_系统音效/01_回路启动.ogg", volume = 0.5, loop = false,);//播放SE
SetUIMode( 5);
Text.Clear(); //清空文本框
Text.ChangeAlpha(alpha_began = 0, alpha_ended = 1, time = 0.5,);
Text.SetTextSpeed( 30);
Text.ShowText( mode = "dialogue", name = "Prober", dialogue = "空气中二氧化硫含量极高，方圆十公里内没有检测到任何动植物生命活动，只能看到零零散散的机器人在街上游荡。",);

WaitForClick(); //··
Text.ShowText( mode = "dialogue", name = "Prober", dialogue = "真奇怪啊，明明人都已经死光了，那些机器人还能自动运行下去。",);

WaitForClick(); //··
Text.ShowText( mode = "dialogue", name = "？？？", dialogue = "总有一天会电量耗尽的吧。",);

BGM.Set( audio = "//BGM/K03-劫后余生.mp3", volume = 0.8, loop = true, loop_begin = 0, loop_end = 0,);//设定BGM

WaitForClick(); //··
Text.Clear();
Text.Hide();
Picture.CreateMovie( name = "bg1", movie = "//背景/B_第一章/01A_废墟东京.mp4", alpha = 0, Loop = true,); //视频背景
Picture.KeepMove(name = "bg1", x_began = 0, y_began = 250, x_ended = 0, y_ended = 0, scale_began = 1.75, scale_ended = 1, time = 20, curve = "uniform", alpha_began = 0, alpha_ended = 1, alpha_time = 3,);
WaitCommand(2.5);
Text.Show();
Text.ShowText( mode = "dialogue", name = "Prober", dialogue = "…………", speed = 5,);

WaitForClick(); //··
Text.ShowText( mode = "dialogue", name = "Prober", dialogue = "",);
WaitCommand( 0.5); //等待
Text.ShowText( mode = "dialogue", name = "Prober", dialogue = "第三次……世界大战。", speed = 5,);

WaitForClick(); //··
Text.ShowText( mode = "dialogue", name = "？？？", dialogue = "您看出来了啊，这座城市所经历的惨剧。",);

WaitForClick(); //··
Text.ShowText( mode = "dialogue", name = "Prober", dialogue = "西北方向有卫星武器造成的冲击坑，那应该是战争留下的创痕。",);

WaitForClick(); //··
SE.Play( audio = "//SE/A_系统音效/07_提示弹出.ogg", volume = 1, loop = false,);
if (PLATFORM__IsMobile == true)//移动端情况下
{
    UI.Create(name = "tip1", image = "B_第一章/01_Tips提示.png", x = 1222, y = 350, alpha = 1,); //右上角提示
}
if (PLATFORM__IsMobile == false)//PC端情况下
{
    UI.Create(name = "tip1", image = "B_第一章/01_Tips提示_PC.png", x = 1222, y = 350, alpha = 1,); //右上角提示
}
cmd_block //并行处理
{
    at 0, Text.ShowText( mode = "dialogue", name = "？？？", dialogue = "2036年2月6日，位于东京上空的的<link=001><color=#ff6000>SA4D-147号机</color></link>对丰岛园发动了攻击，摧毁了半径6km内的所有建筑。",);
    at 0, UI.Position( name = "tip1", x_began = 1222, x_ended = 698, y_began = 350, y_ended = 350, time = 1, curve = "uniform"); //提示弹出
}

WaitForClick(); //··
Text.ShowText( mode = "dialogue", name = "？？？", dialogue = "这次攻击十分突然、毫无征兆，造成了多达26万人的伤亡，但事后却没有任何国家或组织宣称对此负责。",);

WaitForClick(); //··
Text.ShowText( mode = "dialogue", name = "？？？", dialogue = "只能认为，它是计算机故障所引发的意外。",);

WaitForClick(); //··
Text.ShowText( mode = "dialogue", name = "？？？", dialogue = "但这起事件却暴露了各大国之间的核威慑平衡已被打破的事实，因此成为了第三次世界大战的导火索。",);

WaitForClick(); //··
Text.ShowText(mode = "dialogue", name = "Prober", dialogue = "真少见啊，居然是在2036年之后才开始爆发的三战。",);

WaitForClick(); //··
Text.ShowText( mode = "dialogue", name = "？？？", dialogue = "奇怪的是，直到一年前，我们的预警系统都没有发出任何警报，说明这条世界线本来是不会爆发三战的。",);

WaitForClick(); //··
cmd_block //并行处理
{
    at 0, Text.ShowText( mode = "dialogue", name = "？？？", dialogue = "有人，引发了世界线变动。",);
    at 0, UI.Position( name = "tip1", x_began = 698, x_ended = 1222, y_began = 350, y_ended = 350, time = 1, curve = "uniform"); //提示收起
}
UI.Release("tip1"); //释放UI

WaitForClick(); //··
Text.ShowText( mode = "dialogue", name = "Prober", dialogue = "…………",);

WaitForClick(); //··
Text.ShowText( mode = "dialogue", name = "Prober", dialogue = "接下来，请你连入一下这个接口。",);

WaitForClick(); //··
SE.Play( audio = "//SE/A_系统音效/01_回路启动.ogg", volume = 0.5, loop = false,);
Picture.CreateMovie( name = "bg2", movie = "//背景/B_第一章/01B_废墟东京.mp4", alpha = 0, Loop = true,);
Picture.Alpha( name = "bg2", alpha_began = 0, alpha_ended = 1, time = 1,); //切换背景
Picture.Release("bg1");
Text.ShowText( mode = "dialogue", name = "Prober", dialogue = "这是什么？",);

WaitForClick(); //··
Text.ShowText( mode = "dialogue", name = "？？？", dialogue = "我们在废墟中找到的一台仍在接受供电的量子计算机，其内部运行着一个模拟现实的程序世界。",);

WaitForClick(); //··
Text.ShowText( mode = "dialogue", name = "Prober", dialogue = "什么意思？你是说有人造出了可以预测未来的地球模拟器，所以改变了历史走向——",);

WaitForClick(); //··
Text.Clear();
Text.ChangeAlpha( alpha_began = 1, alpha_ended = 0, time = 0.5,); //文本框淡出


//————————————————————
//——————都市上的对话————————
//————————————————————


Picture.Create(name = "bg3", image = "//背景/B_第一章/01C_繁荣东京.png", scale = 1.4, y = 0, alpha = 0,);
cmd_block //并行处理
{
    at 0, Picture.CreateMovie(name = "bg4", movie = "//背景/B_第一章/01D_畸变转场.mp4", scale = 1, x = 0, y = 0, angle = 0, alpha = 1, Loop = false, );
    at 1, Picture.Alpha(name = "bg3", alpha_began = 0, alpha_ended = 1, time = 0,); //切换背景
    at 1, Picture.Release("bg2");
}
Picture.Release("bg4");
Picture.KeepMove(name = "bg3", x_began = 0, y_began = 0, x_ended = 0, y_ended = 0, scale_began = 1.4, scale_ended = 1, time = 10, curve = "uniform", alpha_began = 1, alpha_ended = 1, alpha_time = 0,);
Text.ChangeAlpha( alpha_began = 0, alpha_ended = 1, time = 0.5,); //文本框淡入
Text.ShowText( mode = "dialogue", name = "Prober", dialogue = "这是……？", speed = 10,);

WaitForClick(); //··
Text.ShowText( mode = "dialogue", name = "？？？", dialogue = "这就是那个程序世界内部的景象，显然它不是用于预测未来的。",);

WaitForClick(); //··
Text.ShowText(mode = "dialogue", name = "Prober", dialogue = "你确定这是模拟现实的程序世界？不是什么战时避难所？",);

WaitForClick(); //··
Text.ShowText( mode = "dialogue", name = "？？？", dialogue = "我的判断不会有错，这个模拟世界的信息量有有<link=002><color=#ff6000>100ZB</color></link>，和现实世界是同一数量级的。",);

WaitForClick(); //··
Text.ShowText( mode = "dialogue", name = "？？？", dialogue = "你现在到街上去随便问一个行人，他都会回答你现在是2037年，没有人会觉得自己正身处在程序世界之中。",);

WaitForClick(); //··
Text.ShowText( mode = "dialogue", name = "Prober", dialogue = "这不可能。基于战乱年代模拟的世界，不可能表现出如此高度的和平与繁荣。",);

WaitForClick(); //··
Text.ShowText( mode = "dialogue", name = "？？？", dialogue = "是的，这也正是我感到费解的地方。",);

WaitForClick(); //··
Text.ShowText( mode = "dialogue", name = "？？？", dialogue = "不过，听说上面的大人物提出了一个猜想。",);

WaitForClick(); //··
Text.ShowText( mode = "dialogue", name = "？？？", dialogue = "——会不会，有人<b>将现实世界和模拟世界进行了调换</b>？",);

WaitForClick(); //··
Text.ShowText( mode = "dialogue", name = "Prober", dialogue = "<size=42>……！</size>",);

WaitForClick(); //··
Text.ShowText( mode = "dialogue", name = "？？？", dialogue = "将计算机内模拟的战乱世界覆盖进了现实、又将本应和平的现实世界转移进了计算机。这样，就神不知鬼不觉地完成了一次世界线变动。",);

WaitForClick(); //··
Text.ShowText( mode = "dialogue", name = "Prober", dialogue = "怎么会有这种荒唐的事情……",);

WaitForClick(); //··
Text.ShowText( mode = "dialogue", name = "？？？", dialogue = "很难想象幕后黑手在策划怎样的阴谋。无论如何，我们都必须想办法介入调查，阻止这个世界走向更不可预料的未来。",);

WaitForClick(); //··
Text.ShowText( mode = "dialogue", name = "Prober", dialogue = "你刚才说，这个模拟世界的信息量有100ZB，其中应该包含了从公元前3500年到现在的所有历史数据吧？",);

WaitForClick(); //··
Text.ShowText( mode = "dialogue", name = "？？？", dialogue = "没错。",);

WaitForClick(); //··
Text.ShowText( mode = "dialogue", name = "Prober", dialogue = "它和现实世界的历史有重合吗？",);

WaitForClick(); //··
Text.ShowText( mode = "dialogue", name = "？？？", dialogue = "有，直到2035年为止，都是一致的。",);

WaitForClick(); //··
Text.ShowText( mode = "dialogue", name = "Prober", dialogue = "那分歧点在？",);

WaitForClick(); //··
Text.ShowText( mode = "dialogue", name = "？？？", dialogue = "2035年2月6日，东京市练马区。",);

WaitForClick(); //··
Text.ShowText( mode = "dialogue", name = "Prober", dialogue = "两年前啊。",);

WaitForClick(); //··
Text.ShowText( mode = "dialogue", name = "？？？", dialogue = "这是世界线最初产生偏移的时间点，想要查明SA4D故障的真相，可能还要往后观察一年。",);

WaitForClick(); //··
Text.ShowText( mode = "dialogue", name = "Prober", dialogue = "明白了，这次的任务我接下了。",);

WaitForClick(); //··
Text.ShowText(mode = "dialogue", name = "？？？", dialogue = "你将以『调查员』的身份潜入2035年。这是必须避开委员会监视的秘密任务，我们仅有这唯一的一次机会。",);

WaitForClick(); //··
Text.ShowText(mode = "dialogue", name = "？？？", dialogue = "我无法越过规则为你提供物质援助，但我会留作为『观察员』留在这里稳定你的存在。",);

WaitForClick(); //··
Text.Clear();
cmd_block //并行处理
{
    at 0, Text.ChangeAlpha( alpha_began = 1, alpha_ended = 0, time = 0.5,); //文本框淡出
    at 0, Picture.Alpha( name = "bg3", alpha_began = 1, alpha_ended = 0, time = 2,); //背景淡出
}
Picture.Release("bg3");
SE.Play( audio = "//SE/A_系统音效/02_回路关闭.ogg", volume = 0.5, loop = false,);
WaitCommand( 1.5);
Text.ChangeAlpha( alpha_began = 0, alpha_ended = 1, time = 0.5,);
Text.ShowText( mode = "dialogue", name = "Prober", dialogue = "对了，还没问怎么称呼你。你有代号吗？",);

WaitForClick(); //··
Text.ShowText( mode = "dialogue", name = "？？？", dialogue = "…………",);

WaitForClick(); //··
Text.ShowText( mode = "dialogue", name = "？？？", dialogue = "就叫我……", speed = 10,);

WaitForClick(); //··
Text.ShowText( mode = "dialogue", name = "？？？", dialogue = "<b>Vision</b>吧。",);

WaitForClick(); //··
Text.Clear();
cmd_block //文本框与BGM一起淡出
{
    at 0, Text.ChangeAlpha( alpha_began = 1, alpha_ended = 0, time = 0.5,);
    at 0, BGM.Volume( volume_began = 0.8, volume_ended = 0, time = 2,);//BGM淡出
}

CanAuto( false);
WaitCommand( 1.5); 
JumpToScript( "脚本/V2/sv_01_01.json");