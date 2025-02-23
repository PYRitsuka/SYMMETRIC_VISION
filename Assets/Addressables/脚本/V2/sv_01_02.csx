//C:\Users\10533\Desktop\SYMMETRIC_VISION\makeScript.bat


//————————————————————
//———————章节标题—————————
//————————————————————

StoryBlock(2, true);
CanSkip(false);
VisionTrigger(false);
SetChapter("01", "边界徘徊的七等星");
BGM.Set(audio = "//BGM/A01_Pulse_PVver.mp3", volume = 0, loop = true, loop_begin = 0, loop_end = 0,);
SetUIMode(3);
CanSkip(true);
CanAuto(true);
WaitCommand(1);



//————————————————————
//———————发现尸体—————————
//————————————————————



//文本框显现
Text.ChangeAlpha(alpha_began = 0, alpha_ended = 1, time = 0.5,);
//旁白
Script.Narration(dialogue = "…………",);

WaitForClick(); //··
//旁白
Script.Narration(dialogue = "漆黑……",);

WaitForClick(); //··
//旁白
Script.Narration(dialogue = "一片漆黑……",);

WaitForClick(); //··
//台词，变速
Script.Dialogue(name = "我", dialogue = "…………", speed = 5);

WaitForClick(); //··
//旁白
Script.Narration(dialogue = "周遭的世界，充斥着空洞的色彩与嘈杂的回音。",);

WaitForClick(); //··
//旁白
Script.Narration(dialogue = "知觉茫然若失，宛如身处昏暗的水底，被窒息感压得喘不过气。",);

WaitForClick(); //··
//台词，变速
Script.Dialogue(name = "我", dialogue = "……………………", speed = 10);

WaitForClick(); //··
//旁白
Script.Narration(dialogue = "意识缓缓上浮。",);

WaitForClick(); //··
//旁白
Script.Narration(dialogue = "一点一点，迎着黯淡的星光，向水面浮去。",);

WaitForClick(); //··
//台词，变速
Script.Dialogue(name = "我", dialogue = "………………………………", speed = 15);

WaitForClick(); //··
//旁白
Script.Narration(dialogue = "在接触到空气的瞬间，梦，醒了。",);

WaitForClick(); //··
//文本框清空
Text.Clear();
//文本框隐藏
Text.ChangeAlpha(alpha_began = 1, alpha_ended = 0, time = 0.5,);
//创建背景
Picture.Create(name = "bg1", image = "//背景/B_第一章/08I_鸦巢公寓303室_天花板.png", alpha = 0,);
cmd_block
{
    //睁眼入场
    at 0, Camera.OpenEyes(1.5);
    //更改图片不透明度
    at 0, Picture.Alpha(name = "bg1", alpha_began = 0, alpha_ended = 1, time = 0.5,);
}
//等待
WaitCommand(0.5);
//设定BGM（loop_end=0时不循环）
BGM.Set(audio = "//BGM/E04-虚影之弦.mp3", volume = 0.4, loop = true, loop_begin = 0, loop_end = 0,);
//文本框显现
Text.ChangeAlpha(alpha_began = 0, alpha_ended = 1, time = 0.5,);
//旁白
Script.Narration(dialogue = "视野逐渐恢复。",);

WaitForClick(); //··
//旁白
Script.Narration(dialogue = "但是……好暗。",);

WaitForClick(); //··
//旁白
Script.Narration(dialogue = "明明已经醒了，眼前的光线却并不比梦中明亮多少。",);

WaitForClick(); //··
//旁白
Script.Narration(dialogue = "我翻了个身，任凭昏昏沉沉的意识再一次将我向睡梦中拖去。",);

WaitForClick(); //··
//旁白
Script.Narration(dialogue = "然而……",);

WaitForClick(); //··
//台词
Script.Dialogue(name = "我", dialogue = "嘶……",);

WaitForClick(); //··
//旁白
Script.Narration(dialogue = "好冷……！",);

WaitForClick(); //··
//旁白
Script.Narration(dialogue = "一阵凉意袭上了我的脊背。",);

WaitForClick(); //··
//旁白
Script.Narration(dialogue = "定睛一看，我才注意到自己躺的地方是一块地板。",);

WaitForClick(); //··
//背景遮罩向上离场
Picture.CoveringOut(name = "bg1", direction = "up", time = 0.25,);
//更换背景
Picture.Change(name = "bg1", image = "//背景/B_第一章/08G_鸦巢公寓303室_屋内深夜黑灯.png", time = 0, );
//播放音效
SE.Play(audio = "//SE/C_布料声/03_蹲下身.ogg", volume = 0.6, loop = false, );
//背景遮罩向上入场
Picture.CoveringIn(name = "bg1", direction = "down", time = 0.25,);
//台词
Script.Dialogue(name = "我", dialogue = "怎么回事……？",);

WaitForClick(); //··
//旁白
Script.Narration(dialogue = "挺身坐起，一股违和感在我脑内悄然浮现。",);

WaitForClick(); //··
//旁白
Script.Narration(dialogue = "总觉得心里空落落的，就好像缺了些什么。",);

WaitForClick(); //··
//旁白
Script.Narration(dialogue = "我睡在了地板上？不……不对，这是哪里，我怎么好像从来没见过这个房间？",);

WaitForClick(); //··
//旁白
Script.Narration(dialogue = "…………",);

WaitForClick(); //··
//旁白
Script.Narration(dialogue = "等一等，在思考这个问题之前，我……是谁来着？",);

WaitForClick(); //··
//播放音效
SE.Play(audio = "//SE/G_氛围音/04_尖锐的滑音.ogg", volume = 0.3, loop = false, );
//台词
Script.Dialogue(name = "我", dialogue = "<size=36>呃……！</size>",);
//BGM音量调节
BGM.Volume(volume_began = 0.4, volume_ended = 0.1, time = 0.5,);

WaitForClick(); //··
//创建上下黑边
Picture.Create(name = "blackcover", image = "//背景/上下黑边.png", alpha = 1,);
cmd_block
{ 
    //黑边进入
    at 0, Picture.Scale(name = "blackcover", scale_began = 1, scale_ended = 0.8, time = 1, curve = "uniform");
    //旁白
    at 0, Script.Narration(dialogue = "我痛苦地捂住了额头。",);
}

WaitForClick(); //··
//旁白
Script.Narration(dialogue = "并不是刚睡醒时的大脑不清醒，我是真的记不起来自己是谁了。",);
//BGM音量调节
BGM.Volume(volume_began = 0.1, volume_ended = 0.4, time = 0.5,);

WaitForClick(); //··
//旁白
Script.Narration(dialogue = "我努力地想回想起些什么，但只要尝试这么做，就会使头越来越痛。",);

WaitForClick(); //··
//旁白
Script.Narration(dialogue = "不仅是名字，现在是什么时候、我为什么睡在这里、我是什么人、我要去做什么……这些通通想不起来了。",);

WaitForClick(); //··
//旁白
Script.Narration(dialogue = "头好痛！不行，不能再回想下去了！",);

WaitForClick(); //··
cmd_block
{
    //黑边退出
    at 0, Picture.Scale(name = "blackcover", scale_began = 0.8, scale_ended = 1, time = 1, curve = "uniform");
    //播放音效
    at 0, SE.Play(audio = "//SE/C_布料声/03_蹲下身.ogg", volume = 0.6, loop = false, );
    //图片振动，分弱中强三档
    at 0, Picture.Vibrate("bg1", "medium");
    //旁白
    at 0, Script.Dialogue(name = "我", dialogue = "<size=36>呃……啊！</size>",);
}
//删除图片
Picture.Release("blackcover");

WaitForClick(); //··
//旁白
Script.Narration(dialogue = "回过神来，我发现自己的额头上已经满是冷汗。",);

WaitForClick(); //··
//旁白
Script.Narration(dialogue = "这就是，失忆吗……",);

WaitForClick(); //··
//旁白
Script.Narration(dialogue = "拜它所赐，我彻底从半梦半醒的状态中清醒过来了。",);

WaitForClick(); //··
//文本框清空
Text.Clear();
//创建背景2
Picture.Create(name = "bg2", image = "//背景/B_第一章/08H_鸦巢公寓303室_屋内深夜黑灯.png", scale = 2, x = 960, y = 540, alpha = 0,);
//图片持续移动！！！并淡入
Picture.KeepMove(name = "bg2", x_began = 960, y_began = 540, x_ended = -960, y_ended = 540, scale_began = 2, scale_ended = 2, angle_began = 0, angle_ended = 0, time = 30, curve = "uniform", alpha_began = 0, alpha_ended = 1, alpha_time = 0.5,);
//旁白
Script.Narration(dialogue = "我站起身来环顾了一圈室内，虽然光线很昏暗，但瞳孔还是迅速适应了过来。",);

WaitForClick(); //··
//旁白
Script.Narration(dialogue = "我很快找到了墙上电灯开关所在的位置，朝它走了过去。",);

WaitForClick(); //··
//台词
Script.Dialogue(name = "我", dialogue = "头部受伤，吗？",);

WaitForClick(); //··
//旁白
Script.Narration(dialogue = "对于自己头疼加失忆的现状，我只能做出这种理解。",);

WaitForClick(); //··
//旁白
Script.Narration(dialogue = "好在，我虽然失忆了，但似乎并未失去基本的常识，至少仍能冷静地思考我当前的处境。",);
//更改图片不透明度
Picture.Alpha(name = "bg2", alpha_began = 1, alpha_ended = 0, time = 1,);
//打断图片的持续运动！！！
Picture.StopMove("bg2");
//删除图片
Picture.Release("bg2");

WaitForClick(); //··
//旁白
Script.Narration(dialogue = "这样想着，我来到了电灯开关前。",);
//创建图片：电灯开关
Picture.Create(name = "openlight", image = "B_第一章/06_电灯开关.png", alpha = 0,);
//展开入场
Picture.ExpandIn(name = "openlight", direction = "vertical", time = 0.5,);

WaitForClick(); //··
//旁白
Script.Narration(dialogue = "就在我平平常常地伸出手打算按下开关的时候——",);

WaitForClick(); //··
//台词，变速
Script.Dialogue(name = "我", dialogue = "……？", speed = 10);

WaitForClick(); //··
//台词，变速
Script.Dialogue(name = "我", dialogue = "怎么……回事？", speed = 10);

WaitForClick(); //··
//旁白
Script.Narration(dialogue = "按不动。",);

WaitForClick(); //··
//旁白
Script.Narration(dialogue = "电灯开关的塑料触感顺着手指传来。但无论我怎么用力它都巍然不动，根本无法按下去。",);

WaitForClick(); //··
//收起离场
Picture.ExpandOut(name = "openlight", direction = "vertical", time = 0.5,);
//旁白
Script.Narration(dialogue = "我又试着去按了旁边的几个开关，全都一样无法按动。",);

WaitForClick(); //··
//台词
Script.Dialogue(name = "我", dialogue = "假的？这开关只是摆设？");

WaitForClick(); //··
//旁白
Script.Narration(dialogue = "嘴上这么说着的同时，我心中产生了一种不妙的预感。",);

WaitForClick(); //··
//旁白
Script.Narration(dialogue = "就像是要回应我的预感一样，在向后退去的时候，我的脚突然被绊住了。",);

WaitForClick(); //··
//文本框清空
Text.Clear();
//播放音效
SE.Play(audio = "//SE/C_布料声/04_倒地.ogg", volume = 0.6, loop = false, );
//图片振动
Picture.Vibrate("bg1", "medium");
//背景遮罩向右离场
Picture.CoveringOut(name = "bg1", direction = "right", time = 0.25,);
//更改图片
Picture.Change(name = "bg1", image = "//背景/B_第一章/08F_鸦巢公寓303室_正门深夜黑灯.png", time = 0, );
//背景遮罩向左入场
Picture.CoveringIn(name = "bg1", direction = "left", time = 0.25,);
//图片振动
Picture.Vibrate("bg1", "medium");
//台词
Script.Dialogue(name = "我", dialogue = "<size=42>什——！？</size>");
//等待
//WaitCommand(0.2);
//图片振动
//Picture.Vibrate("bg1", "medium");

WaitForClick(); //··
//旁白
Script.Narration(dialogue = "不，真正吓了我一跳的不是看到了尸体，而是……",);

WaitForClick(); //··
//旁白
Script.Narration(dialogue = "刚刚被绊到的那一下，我丝毫没有“踢中了一具尸体”的实感。",);

WaitForClick(); //··
//旁白
Script.Narration(dialogue = "不像是踢到了肉体，倒像是踢到了一块坚硬的墙壁。",);

WaitForClick(); //··
//旁白
Script.Narration(dialogue = "这种感觉，该怎么形容呢……",);

WaitForClick(); //··
//旁白
Script.Narration(dialogue = "就像是打游戏的时候在空无一物的地方撞到了空气墙一样令人错愕。",);

WaitForClick(); //··
//旁白
Script.Narration(dialogue = "我蹲下身，用手戳了戳尸体的裤子。",);

WaitForClick(); //··
//旁白
Script.Narration(dialogue = "果然又是那种感觉，虽然指尖传来的明显是布料的质感，但裤子本身在被戳中时却像石头一样坚硬。",);

WaitForClick(); //··
//旁白
Script.Narration(dialogue = "能摸到，却碰不动。",);

WaitForClick(); //··
//旁白
Script.Narration(dialogue = "难道说这具尸体也是假的吗？是和墙上那些电灯开关一样的模型？还是说……",);

WaitForClick(); //··
//台词，变速
Script.Dialogue(name = "我", dialogue = "是我……出了问题？", speed = 5);

WaitForClick(); //··
cmd_block
{
    //旁白
    at 0, Script.Narration(dialogue = "话说回来，倒在这里的这个人是谁啊？",);
    //移动图片
    at 0, Picture.Move(name = "bg1", x_began = 0, y_began = 0, x_ended = 480, y_ended = 270, scale_began = 1, scale_ended = 1.5, time = 0.5, curve = "ease_in",);
}

WaitForClick(); //··
//旁白
Script.Narration(dialogue = "我尝试将他的身体转过来，但这显然是徒劳的努力。整具尸体沉重异常，我的力气像是用在了空处。",);

WaitForClick(); //··
//旁白
Script.Narration(dialogue = "稍加打量，地上的男子已经失去了呼吸。他的上半身浸在血泊之中，面容看上去只有二十岁出头。",);

WaitForClick(); //··
//旁白
Script.Narration(dialogue = "是被什么利器刺中胸口了吗？除了花瓶碎片外，我并没有在周围看到什么锋利的物品。",);

WaitForClick(); //··
cmd_block
{
    //移动图片
    at 0, Picture.Move(name = "bg1", x_began = 480, y_began = 270, x_ended = 0, y_ended = 0, scale_began = 1.5, scale_ended = 1, time = 0.5, curve = "ease_in",);
    //旁白
    at 0, Script.Narration(dialogue = "不过，座椅倾倒、花瓶破碎，柜子上有锐器的划痕，说明这里发生过搏斗。",);
}

WaitForClick(); //··
//旁白
Script.Narration(dialogue = "也就是说，在这间黑灯瞎火的房间中，我和一具尸体倒在了一块？",);

WaitForClick(); //··
//旁白
Script.Narration(dialogue = "而且醒来的时候，我还失忆了？",);

WaitForClick(); //··
//旁白
Script.Narration(dialogue = "不妙的预感愈发强烈，我脑海中已经有些零散的碎片开始自行拼凑在一块了。",);

WaitForClick(); //··
//台词，变速
Script.Dialogue(name = "我", dialogue = "…………", speed = 10);

WaitForClick(); //··
//旁白
Script.Narration(dialogue = "不……我必须确认一下，这件事很重要。",);

WaitForClick(); //··
//旁白
Script.Narration(dialogue = "我必须确认一下……我的相貌。",);

WaitForClick(); //··
//文本框清空
Text.Clear();
//背景向右擦除离场
Picture.CoveringOut(name = "bg1", direction = "right", time = 0.5,);
//旁白
Script.Narration(dialogue = "我在房间中走了一圈，试图寻找卫生间的位置，最终在卧室的一角找到了一扇半掩着的门。",);

WaitForClick(); //··
//旁白
Script.Narration(dialogue = "和刚才的电灯开关与尸体裤脚一样，这扇门也无法推动，我只好侧过身子挤了进去。",);

WaitForClick(); //··
//旁白
Script.Narration(dialogue = "阳台地板反射的月光穿过门缝照进卫生间，给洗手台的镜子打上了一束光亮。",);

WaitForClick(); //··
//旁白
Script.Narration(dialogue = "只要走到那束光亮前，我就能看清自己的长相了。",);

WaitForClick(); //··
//台词，变速
Script.Dialogue(name = "我", dialogue = "唔……", speed = 5);

WaitForClick(); //··
//旁白
Script.Narration(dialogue = "不知为何，我突然紧张了起来。",);

WaitForClick(); //··
//旁白
Script.Narration(dialogue = "紧攥的手心被汗水浸湿。",);

WaitForClick(); //··
//旁白
Script.Narration(dialogue = "我好像已经预感到自己会看到什么了。",);

WaitForClick(); //··
//旁白
Script.Narration(dialogue = "人再怎么失忆，也不至于连自己长什么样子都记不得吧……",);

WaitForClick(); //··
//旁白
Script.Narration(dialogue = "我，睁开了双眼。",);

WaitForClick(); //··
//旁白
Script.Narration(dialogue = "然而，镜子中倒映出的景象，和我预想到的情况完全不一样。",);

WaitForClick(); //··
//文本框清空
Text.Clear();
//文本框隐去
Text.ChangeAlpha(alpha_began = 1, alpha_ended = 0, time = 0.5,);



//读档标记点
ClearScene();

//————————————————————
//———————幽灵探索—————————
//————————————————————


//允许自动
CanAuto(true);
//UI模式：蓝色自由视角
SetUIMode(3);
SetChapter("01", "边界徘徊的七等星");
CanSkip(true);
//设定BGM
BGM.Set(audio = "//BGM/E04-虚影之弦.mp3", volume = 0.4, loop = true, loop_begin = 0, loop_end = 0,);
//创建背景
Picture.Create(name = "bg1", image = "//背景/B_第一章/08J_鸦巢公寓303室_卫生间.png", alpha = 0);
//等待
WaitCommand(0.5);
cmd_block
{
    //睁眼入场
    at 0, Camera.OpenEyes(1.5);
    //更改图片不透明度
    at 0, Picture.Alpha(name = "bg1", alpha_began = 0, alpha_ended = 1, time = 1,);
}
//文本框显现
Text.ChangeAlpha(alpha_began = 0, alpha_ended = 1, time = 0.5,);
//台词
Script.Dialogue(name = "我", dialogue = "<size=36>……？</size>");

WaitForClick(); //··
//台词
Script.Dialogue(name = "我", dialogue = "<b>镜子……照不出我？</b>");

WaitForClick(); //··
//旁白
Script.Narration(dialogue = "镜子中空空如也，我使劲挥了挥手，可它映照出的景象没有丝毫变化。",);

WaitForClick(); //··
//旁白
Script.Narration(dialogue = "不仅如此，本该被我遮挡住的光束，也穿过我的身体正常照进了卫生间，没有在镜面上留下阴影。",);

WaitForClick(); //··
//旁白
Script.Narration(dialogue = "…………",);

WaitForClick(); //··
//旁白
Script.Narration(dialogue = "虽然我已经猜到了，自己可能根本不是活人。",);

WaitForClick(); //··
//旁白
Script.Narration(dialogue = "但我料想中的情况，是镜子中映出了和客厅中那具尸体一样的脸。",);

WaitForClick(); //··
//旁白
Script.Narration(dialogue = "镜子照不出我，也就是说……",);

WaitForClick(); //··
//旁白
Script.Narration(dialogue = "我无法与这个世界，产生物理性的接触……吗？",);

WaitForClick(); //··
//旁白
Script.Narration(dialogue = "……我失魂落魄地走出了卫生间。",);

WaitForClick(); //··
//文本框清空
Text.Clear();
//文本框隐去
Text.ChangeAlpha(alpha_began = 1, alpha_ended = 0, time = 0.5,);
//背景向右擦除离场
Picture.CoveringOut(name = "bg1", direction = "right", time = 0.5,);
//等待
WaitCommand(0.8);
//更改图片
Picture.Change(name = "bg1", image = "//背景/B_第一章/08F_鸦巢公寓303室_正门深夜黑灯.png", time = 0, );
//背景向左擦入离场
Picture.CoveringIn(name = "bg1", direction = "left", time = 0.5,);
//文本框显现
Text.ChangeAlpha(alpha_began = 0, alpha_ended = 1, time = 0.5,);
//旁白
Script.Narration(dialogue = "低头看去，果不其然，我身上穿着和客厅中的那具尸体一样的衣服。",);

WaitForClick(); //··
//旁白
Script.Narration(dialogue = "<b>我是……死者的幽灵。</b>",);

WaitForClick(); //··
//旁白
Script.Narration(dialogue = "虽然不清楚幽灵是什么东西，但可以确定的是，我能看见、能听见、能感受到这间房间里的所有东西，而无法对它们造成任何实际影响。",);

WaitForClick(); //··
//旁白
Script.Narration(dialogue = "这也太奇怪了，那我现在算是什么？既然还有意识残留，那就不能算真正意义上的“死亡”。",);

WaitForClick(); //··
//旁白
Script.Narration(dialogue = "但我不记得任何有关自己的事了，我真的能和客厅里的那具尸体算同一个人吗？",);

WaitForClick(); //··
//旁白
Script.Narration(dialogue = "话说回来，既然我是幽灵，那为什么我的双脚还能坚实地踩在地面上呢？",);

WaitForClick(); //··
//旁白
Script.Narration(dialogue = "光线都能穿过我的身体，那有质量的物体我也应该没法触碰才对啊。",);

WaitForClick(); //··
//旁白
Script.Narration(dialogue = "就在我产生了这个想法的瞬间——",);

WaitForClick(); //··
//文本框清空
Text.Clear();
//禁止跳过
CanSkip(false);
//创建新视频
Picture.CreateMovie(name = "bg3", movie = "//背景/B_第一章/08H_感官切换.mp4", scale = 1, alpha = 1, Loop = false, );
//允许跳过
CanSkip(true);
//台词
Script.Dialogue(name = "我", dialogue = "……！");

WaitForClick(); //··
//旁白
Script.Narration(dialogue = "失重感席卷了我的全身上下。",);

WaitForClick(); //··
cmd_block
{
    //背景向上擦除
    at 0, Picture.CoveringOut(name = "bg1", direction = "up", time = 0.3,);
    //旁白
    at 0, Script.Narration(dialogue = "直到刚才为止的脚踏实地感消失了，我依然站在原地，但脚底传来的却是悬浮在半空的感觉。",);
}

WaitForClick(); //··
//旁白
Script.Narration(dialogue = "意念微微一动，下一秒，我的身体就随着意念所指腾空而起，毫无阻碍地穿过了天花板。",);

WaitForClick(); //··
//文本框清空
Text.Clear();
//文本框隐去
Text.ChangeAlpha(alpha_began = 1, alpha_ended = 0, time = 0.5,);
//设定BGM
BGM.Set(audio = "//BGM/D01-星海迷宫.mp3", volume = 0.4, loop = true, loop_begin = 0, loop_end = 0,);
//播放音效
SE.Play(audio = "//SE/H-环境音/01_风声呼啸.ogg", volume = 0.1, loop = true, );
//等待
WaitCommand(0.5);
//更改图片
Picture.Change(name = "bg1", image = "//背景/B_第一章/11A_鸦巢公寓俯视.png", time = 0, );
//背景向上擦入
Picture.CoveringIn(name = "bg1", direction = "down", time = 0.3,);
//文本框显现
Text.ChangeAlpha(alpha_began = 0, alpha_ended = 1, time = 0.5,);
//旁白
Script.Narration(dialogue = "我……",);

WaitForClick(); //··
//旁白
Script.Narration(dialogue = "果然可以穿过有质量的物体！",);

WaitForClick(); //··
//旁白
Script.Narration(dialogue = "我俯瞰着下方的居民楼，耳边呼啸过夜晚的风声。但我的身体没有感到丝毫凉爽——失去重力的同时，我连触觉也一并失去了。",);

WaitForClick(); //··
//旁白
Script.Narration(dialogue = "原来如此……",);

WaitForClick(); //··
//旁白
Script.Narration(dialogue = "我是个幽灵。在意识苏醒后，我仍保持着人类的常识，觉得自己应该有触觉，所以能感受到自己站在地面上。",);

WaitForClick(); //··
//旁白
Script.Narration(dialogue = "当我反应过来自己可以穿过任何物体、也不必有触觉后，这种感官就消失了。",);

WaitForClick(); //··
//旁白
Script.Narration(dialogue = "同理，如果我现在去想“我的视网膜理应无法接收光线，所以我没有视觉”的话……",);

WaitForClick(); //··
//打断所有音效
SE.Stop();
cmd_block
{
    //播放音效
    at 0, SE.Play(audio = "//SE/E_机械音/02_停电.ogg", volume = 0.2, loop = false, );
    //背景淡出
    at 0, Picture.Alpha(name = "bg1", alpha_began = 1, alpha_ended = 0, time = 0.5,);
    //旁白
    at 0, Script.Narration(dialogue = "我的视觉就会消失。",);
}

WaitForClick(); //··
//旁白
Script.Narration(dialogue = "接下来，当我开始觉得“我还是需要触觉和视觉的”……",);

WaitForClick(); //··
//更改图片
Picture.Change(name = "bg1", image = "//背景/B_第一章/08G_鸦巢公寓303室_屋内深夜黑灯.png", time = 0, );
cmd_block
{
    //播放音效
    at 0, SE.Play(audio = "//SE/C_布料声/02_腾空落地.ogg", volume = 0.6, loop = false, );
    //背景淡入
    at 0, Picture.Alpha(name = "bg1", alpha_began = 0, alpha_ended = 1, time = 0.5,);
    //旁白
    at 0, Script.Narration(dialogue = "我的触觉和视觉就会恢复，而且我又再一次站回到房间的地板上了。",);
}

WaitForClick(); //··
//旁白
Script.Narration(dialogue = "虽然不知道我是怎么死的、又是怎么苏醒过来的，但我大概能理解幽灵是一种怎样的状态了。",);

WaitForClick(); //··
//旁白
Script.Narration(dialogue = "能单方面地感知现实世界，但不与现实世界产生任何交互。想落地就落地，想穿墙就穿墙，身体处于怎样的状态完全由意识决定。",);

WaitForClick(); //··
//旁白
Script.Narration(dialogue = "这就是现在的我。",);

WaitForClick(); //··
//头像
Script.Avatar(name = "我", dialogue = "…………", avater = "蓝/A02_佐野阳向/C17_沉思.png", speed = 30,);

WaitForClick(); //··
//旁白
Script.Narration(dialogue = "很好，总算能把握住一点现状了。",);

WaitForClick(); //··
//旁白
Script.Narration(dialogue = "弄清幽灵是怎么一回事后，下一步要解决就是“我是谁”的问题了。",);

WaitForClick(); //··
//头像
Script.Avatar(name = "我", dialogue = "但很麻烦啊……我又没法移动我的尸体。", avater = "蓝/A02_佐野阳向/C09_无奈.png", speed = 30,);

WaitForClick(); //··
//播放音效
SE.Play(audio = "//SE/B_开关门/03_敲门声.ogg", volume = 0.8, loop = false,);
//台词
Script.Dialogue(name = "？？？", dialogue = "那个，熊取先生，打扰一下，请问您在家吗？");

WaitForClick(); //··
//旁白
Script.Narration(dialogue = "突如其来的敲门声打断了我的思考。",);

WaitForClick(); //··
//旁白
Script.Narration(dialogue = "我都快忘了这个世界上还有其他活人了。",);

WaitForClick(); //··
//旁白
Script.Narration(dialogue = "我现在的这种情况，是否能被他人认知到呢？",);

WaitForClick(); //··
//旁白
Script.Narration(dialogue = "我用意念取消了触觉，穿过房门来到了走廊上。",);

WaitForClick(); //··
//文本框清空
Text.Clear();
//文本框隐去
Text.ChangeAlpha(alpha_began = 1, alpha_ended = 0, time = 0.5,);
//背景向左擦除离场
Picture.CoveringOut(name = "bg1", direction = "left", time = 0.5,);



//读档标记点
ClearScene();

//————————————————————
//———————视角交汇—————————
//————————————————————


//允许自动
CanAuto(true);
//UI模式：蓝色自由视角
SetUIMode(3);
SetChapter("01", "边界徘徊的七等星");
CanSkip(true);
//设定BGM
BGM.Set(audio = "//BGM/D01-星海迷宫.mp3", volume = 0.4, loop = true, loop_begin = 0, loop_end = 0,);
//创建背景，设定坐标
Picture.Create(name = "bg1", image = "//背景/B_第一章/07E_鸦巢公寓三楼走廊_303室门口_夜晚.png", x = 0, y = 80, alpha = 0);
//背景从右擦入入场
Picture.CoveringIn(name = "bg1", direction = "right", time = 0.5,);
//创建菅田敏之立绘，中景，y值在-400~500之间
Tachie.Create(name = "Toshiyuki", image = "D02_菅田敏之/A02_赔笑.png", scale = 1, x = 350, y = -500, angle = 0, alpha = 0, multiply = "#798280",);
//创建本马秀和立绘，中景，y值在-400~500之间
Tachie.Create(name = "Hidekazu", image = "D01_本马秀和/A01_平常.png", scale = 1, x = -350, y = -400, angle = 0, alpha = 0, multiply = "#798280",);
//并行处理
cmd_block
{
    //菅田敏之立绘淡入
    at 0, Tachie.Alpha(name = "Toshiyuki", alpha_began = 0, alpha_ended = 1, time = 0.5,);
    //本马秀和立绘淡入
    at 0, Tachie.Alpha(name = "Hidekazu", alpha_began = 0, alpha_ended = 1, time = 0.5,);
}
//文本框显现
Text.ChangeAlpha(alpha_began = 0, alpha_ended = 1, time = 0.5,);
//切换立绘明暗
Tachie.Multiply(name = "Hidekazu", factor = 0.4,);
//台词
Script.Dialogue(name = "邻居住户", dialogue = "怎么了吗？");

WaitForClick(); //··
//切换立绘明暗
Tachie.Multiply(name = "Toshiyuki", factor = 0.4,);
Tachie.Multiply(name = "Hidekazu", factor = 2.5,);
//台词
Script.Dialogue(name = "物业小哥", dialogue = "啊……菅田先生。");

WaitForClick(); //··
//旁白
Script.Narration(dialogue = "门口站着的是两名二十多岁的男子。",);

WaitForClick(); //··
//切换立绘明暗
Tachie.Multiply(name = "Hidekazu", factor = 0.4,);
//头像
Script.Avatar(name = "我", dialogue = "<size=36>喂！听得见吗——</size>", avater = "蓝/A02_佐野阳向/C14_说明.png", speed = 30,);

WaitForClick(); //··
//旁白
Script.Narration(dialogue = "我站在两人身后喊了一嗓子，但他们显然没有听见，依然在继续交谈着。",);

WaitForClick(); //··
//切换立绘明暗
Tachie.Multiply(name = "Toshiyuki", factor = 2.5,);
//台词
Script.Dialogue(name = "邻居住户", dialogue = "这么晚了，人家都休息了吧。有什么急事一定要现在敲门吗？");

WaitForClick(); //··
//切换立绘明暗
Tachie.Multiply(name = "Toshiyuki", factor = 0.4,);
Tachie.Multiply(name = "Hidekazu", factor = 2.5,);
//台词
Script.Dialogue(name = "物业小哥", dialogue = "那个……");

WaitForClick(); //··
//切换立绘明暗
Tachie.Multiply(name = "Hidekazu", factor = 0.4,);
cmd_block
{
    //菅田敏之立绘淡出
    at 0, Tachie.Alpha(name = "Toshiyuki", alpha_began = 1, alpha_ended = 0, time = 0.5,);
    //本马秀和立绘淡出
    at 0, Tachie.Alpha(name = "Hidekazu", alpha_began = 1, alpha_ended = 0, time = 0.5,);
    //旁白
    at 0, Script.Narration(dialogue = "看样子，我是没法奢望能与活着的人交谈了。",);
}

WaitForClick(); //··
//旁白
Script.Narration(dialogue = "不过没关系，放着不管的话，他们马上也会发现我的尸体。",);

WaitForClick(); //··
//旁白
Script.Narration(dialogue = "只要警察来了，我很快就能搞清楚自己是谁。",);

WaitForClick(); //··
//切换立绘明暗
Tachie.Multiply(name = "Toshiyuki", factor = 2.5,);
Tachie.Multiply(name = "Hidekazu", factor = 2.5,);
//并行处理
cmd_block
{
    //菅田敏之立绘淡入
    at 0, Tachie.Alpha(name = "Toshiyuki", alpha_began = 0, alpha_ended = 1, time = 0.5,);
    //本马秀和立绘淡入
    at 0, Tachie.Alpha(name = "Hidekazu", alpha_began = 0, alpha_ended = 1, time = 0.5,);
}
//切换立绘明暗
Tachie.Multiply(name = "Toshiyuki", factor = 0.4,);
//台词
Script.Dialogue(name = "物业小哥", dialogue = "您用不用VIEW APP？如果用的话，可以打开来看一眼。");

WaitForClick(); //··
//切换立绘明暗
Tachie.Multiply(name = "Toshiyuki", factor = 2.5,);
Tachie.Multiply(name = "Hidekazu", factor = 0.4,);
//台词
Script.Dialogue(name = "邻居住户", dialogue = "……？");
//更改立绘图片
Tachie.Change(name = "Toshiyuki", image = "D02_菅田敏之/A01_平常.png", time = 0.2, );

WaitForClick(); //··
//旁白
Script.Narration(dialogue = "被称呼为菅田先生的那名男子伸手触碰了一下自己戴在耳后的电子设备。看着这个动作，我忽然感到有点熟悉。",);

WaitForClick(); //··
//切换立绘明暗
Tachie.Multiply(name = "Toshiyuki", factor = 0.4,);
//头像
Script.Avatar(name = "我", dialogue = "那个是……", avater = "蓝/A02_佐野阳向/C03_严肃.png", speed = 30,);

WaitForClick(); //··
//旁白
Script.Narration(dialogue = "哦，我想起来了，是是<link=010><color=#0097ff>BMI</color></link>吧。",);

WaitForClick(); //··
cmd_block
{
    //菅田敏之立绘淡出
    at 0, Tachie.Alpha(name = "Toshiyuki", alpha_began = 1, alpha_ended = 0, time = 0.5,);
    //本马秀和立绘淡出
    at 0, Tachie.Alpha(name = "Hidekazu", alpha_began = 1, alpha_ended = 0, time = 0.5,);
    //旁白
    at 0, Script.Narration(dialogue = "既然我能够根据自己的意念获得听觉、视觉、嗅觉、味觉、触觉的话，那能不能附在他人的BMI上获得AR视觉呢？",);
}


WaitForClick(); //··
//旁白
Script.Narration(dialogue = "试一试吧。",);
//更改立绘坐标
Tachie.Position(name = "Toshiyuki", x_began = 0, y_began = 0, x_ended = 0, y_ended = -500, time = 0, curve = "uniform");
//切换立绘明暗
Tachie.Multiply(name = "Toshiyuki", factor = 2.5,);
//菅田敏之立绘淡入
Tachie.Alpha(name = "Toshiyuki", alpha_began = 0, alpha_ended = 1, time = 0.5,);

WaitForClick(); //··
//文本框清空
Text.Clear();
//文本框隐去
Text.ChangeAlpha(alpha_began = 1, alpha_ended = 0, time = 0.5,);
cmd_block
{
    //背景放大
    at 0, Picture.Move(name = "bg1", x_began = 0, y_began = 80, x_ended = 0, y_ended = 0, scale_began = 1, scale_ended = 1.5, time = 1, curve = "ease_out", alpha_began = 1, alpha_ended = 1, alpha_time = 0,);
    //菅田敏之立绘放大
    at 0, Tachie.Move(name = "Toshiyuki", x_began = 0, y_began = -500, x_ended = 0, y_ended = -900, scale_began = 1, scale_ended = 1.5, angle_began = 0, angle_ended = 0, time = 1, curve = "ease_out");
    //菅田敏之立绘淡出
    at 0, Tachie.Alpha(name = "Toshiyuki", alpha_began = 1, alpha_ended = 0, time = 1,);
}
//UI模式：蓝色BMI视角
SetUIMode(2);
//BMI边框进入
UI.Create(name = "BMIO", image = "A_系统UI/01_BMI边框.png", scale = 1.3, alpha = 1,);
UI.Scale(name = "BMIO", scale_began = 1.3, scale_ended = 1, time = 0.5, curve = "uniform",);
//VIEW展开
SE.Play(audio = "//SE/A_系统音效/01_回路启动.ogg", volume = 0.4, loop = false,);
Frame.ViewOn(image = "//UI/B_第一章/04H_房门上的魔法阵.png", color = "blue", duration = 0.7,);
//文本框显现
Text.ChangeAlpha(alpha_began = 0, alpha_ended = 1, time = 0.5,);
//头像
Script.Avatar(name = "我", dialogue = "啊……", avater = "蓝/A02_佐野阳向/C08_吃惊.png", speed = 30,);

WaitForClick(); //··
//旁白
Script.Narration(dialogue = "虽然我知道透过BMI可以看到一些肉眼看不到的光效。",);

WaitForClick(); //··
//旁白
Script.Narration(dialogue = "但门上突然出现的魔法阵还是让我吃了一惊。",);

WaitForClick(); //··
//创建背景
Picture.Create(name = "bg2", image = "//背景/B_第一章/07H_鸦巢公寓三楼走廊_VIEW窗口.png", alpha = 1);
//VIEW关闭
Frame.ViewOff(0);
//旁白
Script.Narration(dialogue = "哦，是这样啊……",);

WaitForClick(); //··
cmd_block
{
    //旁白
    at 0, Script.Narration(dialogue = "我的灵魂，就是被这道魔法阵，召唤出来的吧。",);
    //更改图片
    at 0, Picture.Change(name = "bg2", image = "//背景/B_第一章/07I_鸦巢公寓三楼走廊_魔法阵.png", time = 0.5, );
}

WaitForClick(); //··
//文本框隐去
Text.Clear();
Text.ChangeAlpha(alpha_began = 1, alpha_ended = 0, time = 1,);
//删除背景
Picture.Release("bg1");




//————————————————————
//——————结尾和时间轴————————
//————————————————————



cmd_block
{
    //背景淡出
    at 0, Picture.Alpha(name = "bg2", alpha_began = 1, alpha_ended = 0, time = 1.5,);
    //BGM淡出
    at 0, BGM.Volume(volume_began = 0.4, volume_ended = 0, time = 1.5,);
    //BMI边框退出
    at 0, UI.Scale(name = "BMIO", scale_began = 1, scale_ended = 1.3, time = 0.5, curve = "uniform",);
}
//禁止跳过
CanSkip(false);

//创建时间轴
Picture.Create(name = "time1", image = "//背景/B_第一章/91A_时间轴.png", scale = 1, x = -1050, y = 0, alpha = 0,);
//更改不透明度
Picture.Alpha(name = "time1", alpha_began = 0, alpha_ended = 1, time = 1,);
//移动
Picture.Position(name = "time1", x_began = -1050, y_began = 0, x_ended = -1400, y_ended = 0, time = 1, curve = "uniform");
//切换时间轴
Picture.Change(name = "time1", image = "//背景/B_第一章/91B_时间轴.png", time = 0.3, );
//切换时间轴
Picture.Change(name = "time1", image = "//背景/B_第一章/91C_时间轴.png", time = 0.3, );
//切换时间轴
Picture.Change(name = "time1", image = "//背景/B_第一章/91D_时间轴.png", time = 0.3, );
//切换时间轴
Picture.Change(name = "time1", image = "//背景/B_第一章/91E_时间轴.png", time = 0.3, );
//切换时间轴
Picture.Change(name = "time1", image = "//背景/B_第一章/91F_时间轴.png", time = 0.3, );

WaitForClick(); //··
//更改不透明度
Picture.Alpha(name = "time1", alpha_began = 1, alpha_ended = 0, time = 1,);

StoryArrow(2, true);
WaitCommand(1);
JumpToScript("脚本/V2/sv_01_03.json");