//C:\Users\10533\Desktop\SYMMETRIC_VISION\makeScript.bat


//————————————————————
//———————章节标题—————————
//————————————————————

StoryBlock(1, true);
VisionTrigger(false);
SetChapter( "01", "边界徘徊的七等星");
CanSkip(false);
BGM.Set(audio = "//BGM/A01_Pulse_PVver.mp3", volume = 0, loop = true, loop_begin = 0, loop_end = 0,);
Picture.CreateMovie( name = "p1", movie = "B_第一章_视频/99A_第一章章节名.mp4", alpha = 1, Loop = false,);
WaitCommand(0.5);
SetUIMode(5);
CanSkip(true);
CanAuto(true);


//————————————————————
//———————物业室中—————————
//————————————————————

Text.Clear();
Text.ChangeAlpha( alpha_began = 0, alpha_ended = 1, time = 0.5,);
Text.ShowText( mode = "narration", dialogue = "2035年9月7日（星期五）晚。",);

WaitForClick(); //··
Text.Clear();
Text.ChangeAlpha( alpha_began = 1, alpha_ended = 0, time = 0.5,);
BGM.Set( audio = "//BGM/B03-实验室的讨论.mp3", volume = 0.7, loop = true, loop_begin = 0, loop_end = 0,);//设定BGM
SetUIMode(4);
Picture.Create( name = "bg1", image = "//背景/B_第一章/02B_鸦巢公寓物业室_夜晚.png", alpha = 0,);
Picture.Alpha( name = "bg1", alpha_began = 0, alpha_ended = 1, time = 1,); //背景淡入
UI.Create( name = "BMIO", image = "A_系统UI/01_BMI边框.png", scale = 1.3, alpha = 1,);
UI.Scale( name = "BMIO", scale_began = 1.3, scale_ended = 1, time = 0.5, curve = "uniform",); //BMI边框进入
SE.Play( audio = "//SE/A_系统音效/01_回路启动.ogg", volume = 0.4, loop = false,);
Frame.ViewOn( image = "//UI/B_第一章/02A_百货店.png", color = "gray", duration = 0.7,); //VIEW展开
Text.ChangeAlpha( alpha_began = 0, alpha_ended = 1, time = 0.5,);
Text.ShowText( mode = "dialogue", name = "本马 秀和", dialogue = "让我看看，这一回的目标地点是在百货商店吗……",);

WaitForClick(); //··
Text.ShowText( mode = "narration", dialogue = "<b>本马秀和</b>坐在公寓的物业室内，眼前展开着着<link=003><color=#ff6000>AR</color></link>全景地图。",);

WaitForClick(); //··
Text.ShowText( mode = "narration", dialogue = "这是最近非常热门的虚拟地球APP『VIEW』。",);

WaitForClick(); //··
Text.ShowText( mode = "narration", dialogue = "由于过去的一年里里<link=004><color=#ff6000>M流感</color></link>在东京的肆虐，大量的市民蜗居在家。VIEW APP就是在这种情况下应时而生的云旅游产品。",);

WaitForClick(); //··
Text.ShowText( mode = "narration", dialogue = "不过本马秀和现在并没有在使用VIEW的地图功能，而是它最近刚刚推出的『AR寻宝挑战』。",);

WaitForClick(); //··
Text.ShowText( mode = "dialogue", name = "本马 秀和", dialogue = "下一个步骤，扫描周围的地形以获得线索。",);

WaitForClick(); //··
SE.Play( audio = "//SE/A_系统音效/03_通话启动.ogg", volume = 0.4, loop = false,);
UI.Create( name = "notion1", image = "//UI/B_第一章/03A_扫描弹窗.png", scale = 1, x = 0, y = 110, alpha = 0,); //弹窗
cmd_block
{
    at 0, Text.ShowText( mode = "narration", dialogue = "本马秀和坐在旋转椅上原地转了一圈，耳朵上的设备在这短暂的十秒内完成了对房间地形的采集。",);
    at 0, UI.ExpandIn( name = "notion1", direction = "horizontal", time = 0.5,); //横向展开
}

WaitForClick(); //··
Text.ShowText( mode = "narration", dialogue = "这些地形数据会被上传到VIEW APP的服务器中，成为『虚拟地球』的一部分。",);

WaitForClick(); //··
Text.ShowText( mode = "narration", dialogue = "作为报酬，上传者将获得寻宝游戏的提示。",);

WaitForClick(); //··
Text.Clear();
UI.Change( name = "notion1", image = "//UI/B_第一章/03B_扫描弹窗.png", time = 0,);//切换图片
WaitCommand(0.5);
UI.ExpandOut( name = "notion1", direction = "horizontal", time = 0.5,); //横向收起
UI.Release("notion1");
SE.Play( audio = "//SE/A_系统音效/11_确认提示.ogg", volume = 0.5, loop = false,);
UI.Create( name = "notion2", image = "//UI/B_第一章/03C_提示.png", scale = 1, x = 0, y = 110, alpha = 0,);
UI.ExpandIn( name = "notion2", direction = "horizontal", time = 0.5,); //弹窗展开
Text.ShowText( mode = "narration", dialogue = "看到这串提示后，本马秀和微微一笑。",);

WaitForClick(); //··
SE.Play( audio = "//SE/A_系统音效/09_退出界面.ogg", volume = 0.7, loop = false,);
UI.ExpandOut( name = "notion2", direction = "horizontal", time = 0.5,);
UI.Release("notion2"); //弹窗收起
Frame.ViewChange( image = "//UI/B_第一章/02B_百货店.png", duration = 0.5,);
Text.ShowText( mode = "narration", dialogue = "如他所料，当在平面图上找不出藏宝点时，往往意味着线索藏在了地下。",);

WaitForClick(); //··
Text.Clear();
Frame.ViewChange( image = "//UI/B_第一章/02C_百货店.png", duration = 0.5,);
Text.ShowText( mode = "dialogue", name = "本马 秀和", dialogue = "啊，找到了。",);

WaitForClick(); //··
Text.ShowText( mode = "dialogue", name = "本马 秀和", dialogue = "才2千金币啊……给得也太少了吧。",);

WaitForClick(); //··
SE.Play( audio = "//SE/A_系统音效/02_回路关闭.ogg", volume = 0.4, loop = false,);
Frame.ViewOff( 0.7); //关闭VIEW
Text.ShowText( mode = "dialogue", name = "本马 秀和", dialogue = "算了算了，再打发半个小时就能下班了……",);

WaitForClick(); //··
Text.ShowText( mode = "narration", dialogue = "这是本马秀和今晚解决的第5个寻宝挑战。作为当晚值班的物业人员，他已经摸了三个小时鱼了。",);

WaitForClick(); //··
Text.Clear();
Picture.CoveringOut( name = "bg1", direction = "right", time = 0.5,); //向右擦除
Tachie.Create( name = "Hidekazu", image = "D01_本马秀和/A01_平常.png", scale = 1, x = 0, y = -400, alpha = 0, multiply = "#FFFFFF",); //创建立绘，中景的y值在400~500之间
Tachie.Alpha( name = "Hidekazu", alpha_began = 0, alpha_ended = 1, time = 1,);//立绘淡入
Text.ShowText( mode = "narration", dialogue = "本马秀和今年23岁，是从外地来东京打工的。",);

WaitForClick(); //··
Text.ShowText( mode = "narration", dialogue = "他所在的这家物业公司要负责管理高野台三丁目的5幢公寓。不过本马秀和主要做的是夜间值班，所以相对比较清闲。",);

WaitForClick(); //··
Tachie.Alpha( name = "Hidekazu", alpha_began = 1, alpha_ended = 0, time = 0.5,);//立绘淡出
Tachie.Release("Hidekazu");
Text.ShowText( mode = "narration", dialogue = "以短波信号对人体有害为由抗议安装装<link=005><color=#ff6000>基站</color></link>的中年妇女、叫嚷着要把把<link=006><color=#ff6000>上一届物业</color></link>换回来的家庭主妇、还有闭门不出拖欠物业费的怪老头……",);

WaitForClick(); //··
Text.ShowText( mode = "narration", dialogue = "本马秀和烦透了这群人，但出于岗位职责他又不好开口抱怨。",);

WaitForClick(); //··
Text.ShowText( mode = "narration", dialogue = "久而久之，他养成了“如非工作需要，尽量不与业主交流”的习惯。",);

WaitForClick(); //··
Text.ShowText( mode = "narration", dialogue = "今晚又有两名大学生租房客叫了一群同学在家里开派对，吵得隔壁邻居打电话来投诉。",);

WaitForClick(); //··
Text.ShowText( mode = "narration", dialogue = "本马秀和与这群大学生并不怎么处得来，他以前就因为高中辍学的学历而被对方嘲讽是走关系才受聘当的物业。",);

WaitForClick(); //··
Text.ShowText( mode = "narration", dialogue = "好在房东吉田女士是个乐于助人的人，她亲自登门劝说，把扰民问题平息了下来。",);

WaitForClick(); //··
Text.ShowText( mode = "avatar", name = "本马 秀和", dialogue = "要是我也能有吉田姐那样的社交能力就好了……", avater = "灰/D01_本马秀和/A02_赔笑.png",);

WaitForClick(); //··
Tachie.Create( name = "Yukie", image = "B04_吉田雪绘/B02_微笑.png", scale = 1, x = 0, y = -450, alpha = 0, multiply = "#FFFFFF",); //创建立绘
cmd_block
{
    at 0, Tachie.Alpha( name = "Yukie", alpha_began = 0, alpha_ended = 1, time = 1,);//立绘淡入
    at 0, Text.ShowText( mode = "narration", dialogue = "房东<b>吉田雪绘</b>是本马秀和最尊敬的人。",);
}

WaitForClick(); //··
Text.ShowText( mode = "narration", dialogue = "她在这片街区拥有两幢房子，一幢是自己家的三层别墅，另一幢是对面的的<link=007><color=#ff6000>鸦巢公寓</color></link>。",);

WaitForClick(); //··
Text.ShowText( mode = "narration", dialogue = "尽管家里很有钱，但吉田女士平日里待人友善，丝毫没有精英阶层的架子。她与公寓的所有租户的关系都很好，这样的社交能力令本马秀和无比羡慕。",);

WaitForClick(); //··
Tachie.Alpha(name = "Yukie", alpha_began = 1, alpha_ended = 0, time = 0.5,);//立绘淡出
Tachie.Release("Yukie");
Text.ShowText( mode = "narration", dialogue = "自己这种辍学出身……能窝在值班的岗位上没事打打游戏就不错了，不该对工作有更多苛求。",);

WaitForClick(); //··
SE.Play(audio = "//SE/B_开关门/01_自动门开启.ogg", volume = 1, loop = false,);
Text.ShowText( mode = "avatar", name = "本马 秀和", dialogue = "咦？", avater = "灰/D01_本马秀和/A01_平常.png",);

WaitForClick(); //··
Text.ShowText( mode = "narration", dialogue = "就在本马秀和走神的时候，一台机器人走进了物业室。",);

WaitForClick(); //··
Text.Clear();
Picture.Change( name = "bg1", image = "//背景/B_第一章/02C_鸦巢公寓物业室_机器人.png", time = 0);
Picture.CoveringIn( name = "bg1", direction = "left", time = 0.5,); //切换图片并向右擦入
Script.Narration(dialogue = "它的圆形脑袋上，顶着一个包裹。",);

WaitForClick(); //··
Script.Avatar(name = "本马 秀和", dialogue = "快递？这么晚了怎么还会有快递送到？", avater = "灰/D01_本马秀和/A01_平常.png",);

WaitForClick(); //··
Script.Narration(dialogue = "不过，当本马秀和看清机器人上的标志时，他立刻明白了这是怎么回事。",);

WaitForClick(); //··
Script.Avatar(name = "本马 秀和", dialogue = "谁啊……怎么还能用VIEW来送快递的？", avater = "灰/D01_本马秀和/A01_平常.png",);

WaitForClick(); //··
Script.Narration(dialogue = "正如方才所言，VIEW不单单是个全景地图APP：它还有着其他丰富的功能。",);

WaitForClick(); //··
Script.Narration(dialogue = "除了寻宝解谜游戏外，VIEW还提供机器人租赁服务。",);

WaitForClick(); //··
Script.Narration(dialogue = "使用寻宝挑战奖励的金币能够租用用<link=008><color=#ff6000>城市街头的服务机器人</color></link>，然后这些机器人就会在现实中代为完成用户在VIEW中的动作。",);

WaitForClick(); //··
Script.Narration(dialogue = "正是这种“虚拟世界的交互可以影响现实”的机制，使得VIEW APP在东京迅速风靡。",);

WaitForClick(); //··
Text.Clear();
Picture.Change( name = "bg1", image = "//背景/B_第一章/02D_鸦巢公寓物业室_快递.png", time = 0.5);
Text.ShowText( mode = "avatar", name = "本马 秀和", dialogue = "居然会有人在VIEW中租机器人来送快递……", avater = "灰/D01_本马秀和/A01_平常.png",);

WaitForClick(); //··
Text.ShowText( mode = "narration", dialogue = "本马秀和取下包裹，在弹出的确认框中点了签收。",);

WaitForClick(); //··
Text.Clear();
SE.Play(audio = "//SE/B_开关门/02_自动门关闭.ogg", volume = 1, loop = false,);
Picture.Change( name = "bg1", image = "//背景/B_第一章/02B_鸦巢公寓物业室_夜晚.png", time = 1);
SE.Stop(); //打断SE
SE.Play(audio = "//SE/C_布料声/01_腾空而起.ogg", volume = 0.9, loop = false,);
Frame.PictureOn(image = "//图片/B_第一章/03_监控摄像头.png", color = "gray", duration = 0.3,); //图片框体展开
Script.Avatar(name = "本马 秀和", dialogue = "监控摄像头？", avater = "灰/D01_本马秀和/A01_平常.png",);

WaitForClick(); //··
Script.Narration(dialogue = "本马秀和想起来了，就在两天前，有几个小孩玩弹弓时把鸦巢公寓三楼走廊的监控摄像头给砸坏了。",);

WaitForClick(); //··
Script.Narration(dialogue = "住在三楼的菅田太太要求物业立即进行更换，否则自己住在家里没有安全感。",);

WaitForClick(); //··
Script.Narration(dialogue = "物业许诺过两天之内一定修好，结果离期限都只剩下不到一小时了，网购的监控摄像头才刚刚到货。",);

WaitForClick(); //··
Script.Narration(dialogue = "再不赶快给三楼走廊换上的话，明天大概又要听菅田太太抱怨了。",);

WaitForClick(); //··
SE.Play(audio = "//SE/C_布料声/02_腾空落地.ogg", volume = 0.9, loop = false,);
Frame.PictureOff(0.3); //图片框体收起
Script.Narration(dialogue = "想到这里，本马秀和心中有了危机感，他立即翻出工具箱，快步走到公寓楼下。",);

WaitForClick(); //··
Text.Clear();
Text.ChangeAlpha(alpha_began = 1, alpha_ended = 0, time = 0.5,);
cmd_block
{
    at 0, Picture.CoveringOut(name = "bg1", direction = "right", time = 0.5,); //向右擦除
    at 0, BGM.Volume(volume_began = 0.7, volume_ended = 0, time = 1,);//BGM淡出
}
WaitCommand(0.5);


PrintCommand("Debug, this should not be printed during Load!!!");
ClearScene();

//————————————————————
//———————修理监控—————————
//————————————————————


SetUIMode(4);
SetChapter("01", "边界徘徊的七等星");
BGM.Stop();
CanSkip(true);
CanAuto(true);
UI.Create(name = "BMIO", image = "A_系统UI/01_BMI边框.png", scale = 1, alpha = 1,);
Picture.Create(name = "bg1", image = "//背景/B_第一章/03B_鸦巢公寓停车场_夜晚.png", alpha = 0);



BGM.Set(audio = "//BGM/B01-理论推演.mp3", volume = 0.7, loop = true, loop_begin = 0, loop_end = 0,);//设定BGM
Picture.CoveringIn(name = "bg1", direction = "left", time = 0.5,); //切换背景并向右擦入
Text.ChangeAlpha(alpha_began = 0, alpha_ended = 1, time = 0.5,);
Script.Narration(dialogue = "出门的时候，本马秀和无意中瞥见了停在路边充电的那台机器人。",);

WaitForClick(); //··
Script.Avatar(name = "本马 秀和", dialogue = "说起来，今晚赚了不少金币来着。", avater = "灰/D01_本马秀和/A01_平常.png",);

WaitForClick(); //··
Script.Avatar(name = "本马 秀和", dialogue = "既然能用机器人送快递的话，那我是不是也可以用机器人修监控……？", avater = "灰/D01_本马秀和/A01_平常.png",);

WaitForClick(); //··
Script.Avatar(name = "本马 秀和", dialogue = "（这样不就可以避免在楼里遇上不想敷衍的家伙了吗？）", avater = "灰/D01_本马秀和/A02_赔笑.png",);

WaitForClick(); //··
Script.Dialogue(name = "？？？", dialogue = "本马小哥？",);

WaitForClick(); //··
Script.Narration(dialogue = "就在这时，身后的二楼阳台传来了一名女性的声音。",);

WaitForClick(); //··
Text.Clear();
Picture.CoveringOut(name = "bg1", direction = "left", time = 0.5,); //向左擦除
Picture.Change(name = "bg1", image = "//背景/B_第一章/03C_鸦巢公寓停车场_夜晚_朝向吉田家.png", time = 0);
Picture.CoveringIn(name = "bg1", direction = "right", time = 0.5,); //切换背景并向左擦入
Tachie.Create(name = "Yukie", image = "B04_吉田雪绘/Z01_平常.png", scale = 0.7, x = 0, y = -500, alpha = 0, multiply = "#FFFFFF",); //创建立绘
cmd_block //立绘淡入入场
{
    at 0, Tachie.Position(name = "Yukie", x_began = 0, x_ended = 0, y_began = -500, y_ended = -100, time = 0.5, curve = "ease_in");
    at 0, Tachie.Alpha(name = "Yukie", alpha_began = 0, alpha_ended = 1, time = 0.5,);
}
Script.Avatar(name = "本马 秀和", dialogue = "吉、吉田姐？", avater = "灰/D01_本马秀和/A02_赔笑.png",);

WaitForClick(); //··
cmd_block //切立绘放发言
{
    at 0, Tachie.Change(name = "Yukie", image = "B04_吉田雪绘/Z03_笑眯眯.png", time = 0.2,);
    at 0, Script.Dialogue(name = "吉田 雪绘", dialogue = "哈哈，被我抓住了吧！离0点还早，别想翘班哦～",);
}

WaitForClick(); //··
Script.Avatar(name = "本马 秀和", dialogue = "啊？不是，我、我……", avater = "灰/D01_本马秀和/A04_紧张.png",);

WaitForClick(); //··
cmd_block //切立绘放发言
{
    at 0, Tachie.Change(name = "Yukie", image = "B04_吉田雪绘/Z05_严肃.png", time = 0.2,);
    at 0, Script.Dialogue(name = "吉田 雪绘", dialogue = "手别藏在身后，让我看看你拿的是什么。",);
}

WaitForClick(); //··
Script.Narration(dialogue = "本马秀和犹犹豫豫地把监控摄像头拿到了身前。",);

WaitForClick(); //··
cmd_block //切立绘放发言
{
    at 0, Tachie.Change(name = "Yukie", image = "B04_吉田雪绘/Z01_平常.png", time = 0.2,);
    at 0, Script.Dialogue(name = "吉田 雪绘", dialogue = "监控摄像头？你是想给那边充电的机器人改装上自己的摄像头吗？",);
}

WaitForClick(); //··
Script.Avatar(name = "本马 秀和", dialogue = "不是的，您误会了，我……", avater = "灰/D01_本马秀和/A04_紧张.png",);

WaitForClick(); //··
cmd_block //切立绘放发言
{
    at 0, Tachie.Change(name = "Yukie", image = "B04_吉田雪绘/Z05_严肃.png", time = 0.2,);
    at 0, Script.Dialogue(name = "吉田 雪绘", dialogue = "将公用的机器人据为己有是违法行为，而且你这是在侵犯市民们的隐私。",);
}

WaitForClick(); //··
cmd_block //切立绘放发言
{
    at 0, Tachie.Change(name = "Yukie", image = "B04_吉田雪绘/Z08_惊讶.png", time = 0.2,);
    at 0, Script.Dialogue(name = "吉田 雪绘", dialogue = "我的公寓楼中居然潜藏着不法分子，看来我不得不秉公灭私了——",);
}

WaitForClick(); //··
Script.Avatar(name = "本马 秀和", dialogue = "<size=40>吉田姐！？</size>", avater = "灰/D01_本马秀和/A03_惊讶.png",);

WaitForClick(); //··
cmd_block //切立绘放发言
{
    at 0, Tachie.Change(name = "Yukie", image = "B04_吉田雪绘/Z04_wink.png", time = 0.2,);
    at 0, Script.Dialogue(name = "吉田 雪绘", dialogue = "哈哈哈哈，开个玩笑而已啦。",);
}

WaitForClick(); //··
Script.Dialogue(name = "吉田 雪绘", dialogue = "你是想去修三楼监控对吧？别忘了给走廊断下电，注意安全。",);

WaitForClick(); //··
Text.Clear();
cmd_block //立绘淡出离场
{
    at 0, Tachie.Position(name = "Yukie", x_began = 0, x_ended = 0, y_began = -100, y_ended = 300, time = 0.5, curve = "ease_in");
    at 0, Tachie.Alpha(name = "Yukie", alpha_began = 1, alpha_ended = 0, time = 0.5,);
}
Tachie.Release("Yukie");
Script.Narration(dialogue = "望着吉田雪绘转身回到屋内的身影，本马秀和愣在了原地。",);

WaitForClick(); //··
Script.Narration(dialogue = "尽管已经认识半年之久，他还是没能完全适应房东女士独有的逗人玩的方式。",);

WaitForClick(); //··
Script.Narration(dialogue = "不过吉田雪绘的提醒很是时候，本马秀和确实忘了给走廊断电。",);

WaitForClick(); //··
Text.Clear();
Text.ChangeAlpha(alpha_began = 1, alpha_ended = 0, time = 0.5,);
Picture.CoveringOut(name = "bg1", direction = "right", time = 0.5,);
WaitCommand(1);
Picture.Change(name = "bg1", image = "//背景/B_第一章/03B_鸦巢公寓停车场_夜晚.png", time = 0);
Picture.CoveringIn(name = "bg1", direction = "left", time = 0.5,); //切换背景并向右擦入
Text.ChangeAlpha(alpha_began = 0, alpha_ended = 1, time = 0.5,);
Script.Narration(dialogue = "<b>上楼用主控电脑关闭监控电源后</b>，本马秀和再次从大门走出，此时吉田雪绘已经从阳台回卧室去了。",);

WaitForClick(); //··
Script.Avatar(name = "本马 秀和", dialogue = "现在没有什么遗漏的了吧。", avater = "灰/D01_本马秀和/A01_平常.png",);

WaitForClick(); //··
Text.Clear();
SE.Play(audio = "//SE/A_系统音效/01_回路启动.ogg", volume = 0.4, loop = false,);
Frame.ViewOn(image = "//UI/B_第一章/04I_黑屏.png", color = "gray", duration = 0.7,); //VIEW展开
Script.Narration(dialogue = "打开VIEW。",);

WaitForClick(); //··
cmd_block
{
    at 0, Frame.ViewChange(image = "//UI/B_第一章/04B_鸦巢公寓停车场.png", duration = 0.5,);
    at 0, Script.Narration(dialogue = "选择租用机器人。",);
}

WaitForClick(); //··
Script.Narration(dialogue = "带上工具箱。",);

WaitForClick(); //··
cmd_block
{
    at 0, Frame.ViewChange(image = "//UI/B_第一章/04A_鸦巢公寓正门.png", duration = 0.5,);
    at 0, Script.Narration(dialogue = "进入公寓大门。",);
}

WaitForClick(); //··
cmd_block
{
    at 0, Frame.ViewChange(image = "//UI/B_第一章/04C_鸦巢公寓二楼.png", duration = 0.5,);
    at 0, Script.Narration(dialogue = "爬上楼梯。",);
}

WaitForClick(); //··
cmd_block
{
    at 0, Frame.ViewChange(image = "//UI/B_第一章/04D_鸦巢公寓三楼.png", duration = 0.5,);
    at 0, Script.Narration(dialogue = "来到三楼走廊。",);
}

WaitForClick(); //··
cmd_block
{
    at 0, Frame.ViewChange(image = "//UI/B_第一章/04E_鸦巢公寓303室.png", duration = 0.5,);
    at 0, Script.Narration(dialogue = "这里就是被砸坏的监控摄像头所在处了。",);
}

WaitForClick(); //··
cmd_block
{
    at 0, Frame.ViewChange(image = "//UI/B_第一章/04F_鸦巢公寓三楼监控.png", duration = 0.5,);
    at 0, Script.Narration(dialogue = "本马秀和熟练地开始安装新摄像头的作业，他的动作会通过VIEW同步给三楼的机器人。",);
}

WaitForClick(); //··
Text.Clear();
Picture.Change(name = "bg1", image = "//背景/B_第一章/03D_鸦巢公寓停车场_夜晚_修理监控.png", time = 0); //背景秒切
Frame.ViewOff(0); //关闭VIEW
Picture.ClockOut(name = "bg1", time = 1,); //时钟离场
WaitCommand(0.5);
Picture.ClockIn(name = "bg1", time = 1,); //时钟离场
Frame.ViewOn(image = "//UI/B_第一章/04F_鸦巢公寓三楼监控.png", color = "gray", duration = 0,); //VIEW展开
Picture.Change(name = "bg1", image = "//背景/B_第一章/03B_鸦巢公寓停车场_夜晚.png", time = 0); //背景秒切
Script.Avatar(name = "本马 秀和", dialogue = "搞定。", avater = "灰/D01_本马秀和/A01_平常.png",);

WaitForClick(); //··
Script.Narration(dialogue = "一分钟后，工作完成了。",);

WaitForClick(); //··
Script.Narration(dialogue = "机器人全程开着降噪运行，没有打扰到任何住户。",);

WaitForClick(); //··
Script.Avatar(name = "本马 秀和", dialogue = "接下来是不是只要我取消租用，它就会自己找台充电桩停下？", avater = "灰/D01_本马秀和/A01_平常.png",);

WaitForClick(); //··
Script.Narration(dialogue = "就在本马秀和这么想时——",);

WaitForClick(); //··
cmd_block
{
    at 0, Frame.ViewChange(image = "//UI/B_第一章/04G_红光监控.png", duration = 0.5,);
    at 0, BGM.Volume(volume_began = 0.7, volume_ended = 0, time = 1,);//BGM淡出
    at 0.5, Script.Narration(dialogue = "他的余光中，突然闯入了一丝微弱的红光。",);
}

WaitForClick(); //··
Script.Avatar(name = "本马 秀和", dialogue = "……？", avater = "灰/D01_本马秀和/A01_平常.png", speed = 10);

WaitForClick(); //··
Script.Narration(dialogue = "光是从旁边303室的方向照过来的。",);

WaitForClick(); //··
Script.Avatar(name = "本马 秀和", dialogue = "哪来的光——", avater = "灰/D01_本马秀和/A01_平常.png");

WaitForClick(); //··
Text.Clear();
cmd_block
{
    at 0, Frame.ViewChange(image = "//UI/B_第一章/04H_房门上的魔法阵.png", duration = 0.5,);
    at 0, SE.Play(audio = "//SE/G_氛围音/01_尖锐的滑音.ogg", volume = 0.7, loop = false,);
    at 2, Script.Avatar(name = "本马 秀和", dialogue = "<size=48>！？</size>", avater = "灰/D01_本马秀和/A03_惊讶.png");
}

WaitForClick(); //··
BGM.Set(audio = "//BGM/E01-思维螺旋.mp3", volume = 0.7, loop = true, loop_begin = 0, loop_end = 0,);//设定BGM
Script.Narration(dialogue = "一道散发着血红光芒的魔法阵，赫然印在了303室的门上。",);

WaitForClick(); //··
Script.Avatar(name = "本马 秀和", dialogue = "<size=38>什、什么东西！？</size>", avater = "灰/D01_本马秀和/A04_紧张.png");

WaitForClick(); //··
SE.Stop(); //打断SE
SE.Play(audio = "//SE/D_脚步声/01_后退两步.ogg", volume = 1, loop = false,);
Script.Narration(dialogue = "本马秀和下意识地向后退了两步，但他马上反应过来这是VIEW中的视角，自己现在人还站在楼下。",);

WaitForClick(); //··
Script.Narration(dialogue = "可他明明记得，<b>一分钟前自己沿着走廊过来时，门上还没有这道魔法阵</b>。",);

WaitForClick(); //··
Script.Avatar(name = "本马 秀和", dialogue = "谁搞的恶作剧啊……", avater = "灰/D01_本马秀和/A04_紧张.png");

WaitForClick(); //··
Script.Narration(dialogue = "深夜的鸦巢公寓寂静无声，即使隔着着<link=003><color=#ff6000>AR</color></link>，本马秀和也能感受到门上的图案透露着一股难以名状的阴森感。",);

WaitForClick(); //··
Script.Avatar(name = "本马 秀和", dialogue = "…………", avater = "灰/D01_本马秀和/A01_平常.png",);

WaitForClick(); //··
Script.Narration(dialogue = "心中浮上了不好的预感。",);

WaitForClick(); //··
Script.Narration(dialogue = "诡异的字符与图案，就如同要将人的魂魄摄取一般，牵引着本马秀和的心神。",);

WaitForClick(); //··
Script.Avatar(name = "本马 秀和", dialogue = "不行。", avater = "灰/D01_本马秀和/A01_平常.png",);

WaitForClick(); //··
Script.Avatar(name = "本马 秀和", dialogue = "这个房间，有问题……", avater = "灰/D01_本马秀和/A04_紧张.png");

WaitForClick(); //··
Script.Narration(dialogue = "本马秀和回过神来，他已经意识到身为物业值班的自己该做些什么了。",);

WaitForClick(); //··
Text.Clear();
SE.Play(audio = "//SE/A_系统音效/02_回路关闭.ogg", volume = 0.4, loop = false,);
Frame.ViewOff(0.7); //关闭VIEW
Picture.CoveringOut(name = "bg1", direction = "left", time = 0.5,); //向左擦除
SE.Stop(); //打断SE
SE.Play(audio = "//SE/D_脚步声/02_急促的跑步声.ogg", volume = 0.6, loop = false,);
Script.Narration(dialogue = "他拔腿冲向公寓的大门。",);

WaitForClick(); //··
Text.Clear();
Text.ChangeAlpha(alpha_began = 1, alpha_ended = 0, time = 0.5,);



ClearScene();

//————————————————————
//———————探查走廊—————————
//————————————————————


//允许自动
SetUIMode(4);
SetChapter("01", "边界徘徊的七等星");
BGM.Stop();
CanSkip(true);
CanAuto(true);
BGM.Set(audio = "//BGM/E01-思维螺旋.mp3", volume = 0.7, loop = true, loop_begin = 0, loop_end = 0,);//设定BGM
UI.Create(name = "BMIO", image = "A_系统UI/01_BMI边框.png", scale = 1, alpha = 1,);
Picture.Create(name = "bg1", image = "//背景/B_第一章/07E_鸦巢公寓三楼走廊_303室门口_夜晚.png", alpha = 0);
Picture.Position(name = "bg1", x_began = 0, y_began = 0, x_ended = 0, y_ended = 80, time = 0, curve = "uniform");



WaitCommand(1.5);
Picture.CoveringIn(name = "bg1", direction = "right", time = 0.5,); //向右擦入
SE.Stop(); //打断SE
Text.ChangeAlpha(alpha_began = 0, alpha_ended = 1, time = 0.5,);
Script.Narration(dialogue = "来到三楼，机器人正停在刚刚修好的监控摄像头下方。",);

WaitForClick(); //··
Script.Narration(dialogue = "一旁就是303室的房门，但……",);

WaitForClick(); //··
Picture.Create(name = "bg2", image = "//背景/B_第一章/07F_鸦巢公寓三楼走廊_303室房门.png", alpha = 0,);
cmd_block
{
    at 0, Picture.Alpha(name = "bg2", alpha_began = 0, alpha_ended = 1, time = 0.5,); //背景淡入
    at 0, Script.Avatar(name = "本马 秀和", dialogue = "诶？", avater = "灰/D01_本马秀和/A01_平常.png");
}

WaitForClick(); //··
Script.Narration(dialogue = "并没有看到什么魔法阵。",);

WaitForClick(); //··
Script.Narration(dialogue = "303室的房门和隔壁302室一样，没有任何异常。",);

WaitForClick(); //··
Text.Clear();
SE.Play(audio = "//SE/A_系统音效/01_回路启动.ogg", volume = 0.4, loop = false,);
Frame.ViewOn(image = "//UI/B_第一章/04H_房门上的魔法阵.png", color = "gray", duration = 0.7,); //VIEW展开
Script.Narration(dialogue = "不过，打开VIEW后就能看到了。",);

WaitForClick(); //··
Script.Narration(dialogue = "近距离观察门上的诡异图案，让本马秀和不禁有些脊背发凉。",);

WaitForClick(); //··
Script.Narration(dialogue = "这是有人用VIEW贴在门上的AR光效……！",);

WaitForClick(); //··
cmd_block
{
    at 0, Frame.ViewChange(image = "//UI/B_第一章/04D_鸦巢公寓三楼.png", duration = 0.5,);
    at 0, Script.Narration(dialogue = "转头看一眼，隔壁302室和301室的房门都很正常，只有303室的门被人贴上了魔法阵。",);
}

WaitForClick(); //··
cmd_block
{
    at 0, Frame.ViewOff(0.7); //关闭VIEW
    at 0, SE.Play(audio = "//SE/A_系统音效/02_回路关闭.ogg", volume = 0.4, loop = false,);
    at 0.5, Script.Narration(dialogue = "303室门窗紧闭，屋内一片漆黑。",);
}

WaitForClick(); //··
SE.Play(audio = "//SE/B_开关门/03_敲门声.ogg", volume = 0.8, loop = false,);
Script.Avatar(name = "本马 秀和", dialogue = "那个，熊取先生，打扰一下，请问您在家吗？", avater = "灰/D01_本马秀和/A01_平常.png");

WaitForClick(); //··
Script.Narration(dialogue = "半分钟的沉默过去，屋内没有任何响应。",);

WaitForClick(); //··
Script.Dialogue(name = "？？？", dialogue = "怎么了吗？",);

WaitForClick(); //··
Script.Narration(dialogue = "反而是身后传来了动静。",);

WaitForClick(); //··
Text.Clear();
Picture.Alpha(name = "bg2", alpha_began = 1, alpha_ended = 0, time = 0.5,); //背景淡出
Tachie.Create(name = "Toshiyuki", image = "D02_菅田敏之/A01_平常.png", scale = 1.25, x = 0, y = -750, alpha = 0, multiply = "#798280",); //创建立绘，近景的y值在750~850之间
Tachie.Alpha(name = "Toshiyuki", alpha_began = 0, alpha_ended = 1, time = 0.5,);//立绘淡入
Script.Narration(dialogue = "是302室的住户<b>菅田敏之</b>先生。",);

WaitForClick(); //··
Script.Avatar(name = "本马 秀和", dialogue = "啊……菅田先生。", avater = "灰/D01_本马秀和/A01_平常.png");

WaitForClick(); //··
Script.Dialogue(name = "菅田 敏之", dialogue = "这么晚了，人家都休息了吧。有什么急事一定要现在敲门吗？",);

WaitForClick(); //··
Script.Avatar(name = "本马 秀和", dialogue = "那个……", avater = "灰/D01_本马秀和/A01_平常.png");

WaitForClick(); //··
Script.Avatar(name = "本马 秀和", dialogue = "您用不用VIEW？如果用的话，可以打开来看一眼。", avater = "灰/D01_本马秀和/A02_赔笑.png");

WaitForClick(); //··
cmd_block //切立绘放发言
{
    at 0, Tachie.Change(name = "Toshiyuki", image = "D02_菅田敏之/A08_平淡.png", time = 0.2,);
    at 0, Script.Dialogue(name = "菅田 敏之", dialogue = "……？",);
}

WaitForClick(); //··
Script.Narration(dialogue = "菅田敏之疑惑地打开VIEW，AR地图在他眼前铺展开来。",);

WaitForClick(); //··
SE.Play(audio = "//SE/A_系统音效/01_回路启动.ogg", volume = 0.4, loop = false,);
cmd_block //切立绘放发言
{
    at 0, Tachie.Change(name = "Toshiyuki", image = "D02_菅田敏之/Z03_VIEW展开.png", time = 0.5,);
    at 0, Script.Narration(dialogue = "紧接着，他立马就注意到了303室门上的异状。",);
}

WaitForClick(); //··
Script.Dialogue(name = "菅田 敏之", dialogue = "<size=38>这、这什么东西啊！？</size>",);

WaitForClick(); //··
Script.Avatar(name = "本马 秀和", dialogue = "我也不知道……我上楼修理监控摄像头，来的时候还没有这道魔法阵，一转头它就突然出现了。", avater = "灰/D01_本马秀和/A04_紧张.png");

WaitForClick(); //··
SE.Play(audio = "//SE/A_系统音效/02_回路关闭.ogg", volume = 0.4, loop = false,);
cmd_block //切立绘放发言
{
    at 0, Tachie.Change(name = "Toshiyuki", image = "D02_菅田敏之/A05_严肃.png", time = 0.5,);
    at 0, Script.Dialogue(name = "菅田 敏之", dialogue = "什么？",);
}

WaitForClick(); //··
Script.Narration(dialogue = "本马秀和与菅田敏之对视了一眼，在短暂的迟疑之后，两人都从对方的眼中读出了和自己一样的担忧。",);

WaitForClick(); //··
cmd_block //切立绘放发言
{
    at 0, Tachie.Alpha(name = "Toshiyuki", alpha_began = 1, alpha_ended = 0, time = 0.5,);//立绘淡出
    at 0, Script.Narration(dialogue = "简直就像是恐怖电影里的桥段。",);
}

WaitForClick(); //··
Script.Narration(dialogue = "一个密闭的房间，门上出现了一个诡异的记号。",);

WaitForClick(); //··
Script.Narration(dialogue = "下一步就该是等人们撞开房门后，在屋内发现尸体了。",);

WaitForClick(); //··
Text.Clear();
Picture.Alpha(name = "bg2", alpha_began = 0, alpha_ended = 1, time = 0.5,); //背景淡入
SE.Play(audio = "//SE/B_开关门/03_敲门声.ogg", volume = 0.8, loop = false,);
Script.Avatar(name = "菅田 敏之", dialogue = "那个，熊取先生，打扰一下，请问您在家吗？", avater = "灰/D02_菅田敏之/A05_严肃.png");

WaitForClick(); //··
Script.Narration(dialogue = "屋内依然没动静。",);

WaitForClick(); //··
Picture.Alpha(name = "bg2", alpha_began = 1, alpha_ended = 0, time = 0.5,); //背景淡出
cmd_block
{
    at 0, Picture.Move(name = "bg1", x_began = 0, y_began = 80, x_ended = 240, y_ended = 205, scale_began = 1, scale_ended = 1.5, time = 1, curve = "ease_in");//图片移动
    at 0, Script.Narration(dialogue = "菅田敏之走到窗前，打开手电，试图让手电光穿过百叶窗的缝隙照进屋内。",);
}

WaitForClick(); //··
Script.Narration(dialogue = "本马秀和凑上去，努力地想看清屋内的状况。",);

WaitForClick(); //··
cmd_block //切立绘放发言
{
    at 0, Picture.Move(name = "bg1", x_began = 240, y_began = 205, x_ended = 320, y_ended = 272, scale_began = 1.5, scale_ended = 2, time = 1, curve = "ease_in", alpha_began = 1, alpha_ended = 0, alpha_time = 1);//图片淡出
    at 0, Script.Avatar(name = "本马 秀和", dialogue = "这是……", avater = "灰/D01_本马秀和/A01_平常.png");
}

WaitForClick(); //··
Picture.Release("bg1");
Script.Avatar(name = "本马 秀和", dialogue = "地板上……碎了一个花瓶？", avater = "灰/D01_本马秀和/A04_紧张.png");

WaitForClick(); //··
Script.Avatar(name = "菅田 敏之", dialogue = "<size=38>……！</size>", avater = "灰/D02_菅田敏之/A03_吃惊.png");

WaitForClick(); //··
Script.Narration(dialogue = "菅田敏之脸色忽然一变，好像想起了什么。",);

WaitForClick(); //··
Text.Clear();
Picture.Alpha(name = "bg2", alpha_began = 0, alpha_ended = 1, time = 0.5,); //背景淡入
SE.Play(audio = "//SE/B_开关门/04_更大声的敲门.ogg", volume = 1, loop = false,);
Script.Avatar(name = "菅田 敏之", dialogue = "喂！熊取君，你在家吗！", avater = "灰/D02_菅田敏之/A03_吃惊.png");

WaitForClick(); //··
Script.Narration(dialogue = "303室的门把手在设计上是锁死的，任凭菅田怎么按也按不动。",);

WaitForClick(); //··
Script.Avatar(name = "本马 秀和", dialogue = "到、到底怎么了？", avater = "灰/D01_本马秀和/A04_紧张.png");

WaitForClick(); //··
Script.Avatar(name = "菅田 敏之", dialogue = "小哥，你去喊一下房东，问她303室的房门密码是多少。", avater = "灰/D02_菅田敏之/A05_严肃.png");

WaitForClick(); //··
Script.Avatar(name = "本马 秀和", dialogue = "可这……不是电子锁。", avater = "灰/D01_本马秀和/A01_平常.png");

WaitForClick(); //··
Script.Avatar(name = "菅田 敏之", dialogue = "啊？", avater = "灰/D02_菅田敏之/A05_严肃.png");

WaitForClick(); //··
Script.Avatar(name = "菅田 敏之", dialogue = "哦……确实啊，整栋公寓就他一家用的是机械锁。", avater = "灰/D02_菅田敏之/A05_严肃.png");

WaitForClick(); //··
cmd_block
{
    at 0, Picture.Move(name = "bg2", x_began = 0, y_began = 0, x_ended = 288, y_ended = 162, scale_began = 1, scale_ended = 1.5, time = 0.7, curve = "ease_in");//图片移动
    at 0, Script.Narration(dialogue = "菅田敏之又用手电照向门缝。为了不占用公共空间，公寓的防盗门都是向内开的，所以能勉强透过门缝看见门锁的状况。",);
}

WaitForClick(); //··
cmd_block
{
    at 0, Picture.Move(name = "bg2", x_began = 288, y_began = 162, x_ended = 0, y_ended = 0, scale_began = 1.5, scale_ended = 1, time = 0.7, curve = "ease_out");//图片移动
    at 0, Script.Avatar(name = "菅田 敏之", dialogue = "不行，看样子<b>插销是插死了</b>。", avater = "灰/D02_菅田敏之/A05_严肃.png");
}

WaitForClick(); //··
Script.Avatar(name = "菅田 敏之", dialogue = "你会开锁吗？", avater = "灰/D02_菅田敏之/A05_严肃.png");

WaitForClick(); //··
Script.Avatar(name = "本马 秀和", dialogue = "不会……物业没有培训过我们开锁技能。", avater = "灰/D01_本马秀和/A01_平常.png");

WaitForClick(); //··
Script.Avatar(name = "菅田 敏之", dialogue = "那就去二楼喊两个邻居过来，把这扇门撞开。", avater = "灰/D02_菅田敏之/A05_严肃.png");

WaitForClick(); //··
Script.Avatar(name = "本马 秀和", dialogue = "啊？可这样不会涉嫌非法入侵他人住宅吗？", avater = "灰/D01_本马秀和/A04_紧张.png");

WaitForClick(); //··
Script.Avatar(name = "菅田 敏之", dialogue = "被问责的话我来担。", avater = "灰/D02_菅田敏之/A05_严肃.png");

WaitForClick(); //··
Text.Clear();
cmd_block  //文本框、BGM、背景先后离场
{
    at 0, Text.ChangeAlpha(alpha_began = 1, alpha_ended = 0, time = 0.5,);
    at 0, BGM.Volume(volume_began = 0.7, volume_ended = 0, time = 1,);
    at 0.5, Picture.CoveringOut(name = "bg2", direction = "down", time = 0.5,); //向下擦除
}



ClearScene();

//————————————————————
//———————发现尸体—————————
//————————————————————


//允许自动
SetUIMode(4);
SetChapter("01", "边界徘徊的七等星");
BGM.Stop();
CanSkip(true);
CanAuto(true);
UI.Create(name = "BMIO", image = "A_系统UI/01_BMI边框.png", scale = 1, alpha = 1,);
Picture.Create(name = "bg2", image = "//背景/B_第一章/06A_鸦巢公寓二楼走廊_201室房门.png", alpha = 0);


SE.Play(audio = "//SE/D_脚步声/03_急促的脚步声.ogg", volume = 1, loop = false,);
WaitCommand(0.3);
Picture.Change(name = "bg2", image = "//背景/B_第一章/06A_鸦巢公寓二楼走廊_201室房门.png", time = 0);
Picture.Position(name = "bg2", x_began = 0, y_began = 0, x_ended = 0, y_ended = 0, time = 0, curve = "uniform");
Picture.CoveringIn(name = "bg2", direction = "up", time = 0.5,); //向上擦入
WaitCommand(1);
BGM.Set(audio = "//BGM/E02-镜像之惑.mp3", volume = 0.6, loop = true, loop_begin = 0, loop_end = 0,);//设定BGM
SE.Play(audio = "//SE/D_脚步声/04_杂乱的脚步声.ogg", volume = 0.8, loop = false,);
Picture.CoveringOut(name = "bg2", direction = "up", time = 0.5,); //向上擦除
Picture.Change(name = "bg2", image = "//背景/B_第一章/07E_鸦巢公寓三楼走廊_303室门口_夜晚.png", time = 0);
Picture.Position(name = "bg2", x_began = 0, y_began = 0, x_ended = 0, y_ended = 80, time = 0, curve = "uniform");
Picture.CoveringIn(name = "bg2", direction = "down", time = 0.5,); //向下擦入
Text.ChangeAlpha(alpha_began = 0, alpha_ended = 1, time = 0.5,);
Script.Narration(dialogue = "本马秀和去二楼喊来了三名住户。",);

WaitForClick(); //··
Tachie.Create(name = "Daisuke", image = "D06_荻原大辅/A01.png", scale = 1, x = 0, y = -500, alpha = 0, multiply = "#798280",); //创建立绘荻原大辅
cmd_block
{
    at 0, Tachie.Alpha(name = "Daisuke", alpha_began = 0, alpha_ended = 1, time = 0.5,);
    at 0, Script.Narration(dialogue = "202室的荻原大辅。",);
}

WaitForClick(); //··
Tachie.Alpha(name = "Daisuke", alpha_began = 1, alpha_ended = 0, time = 0.5,);
Tachie.Create(name = "Masashi", image = "D04_森川雅史/A04_严肃.png", scale = 1, x = -350, y = -500, alpha = 0, multiply = "#798280",); //创建立绘森川雅史
Tachie.Create(name = "Satoshi", image = "D05_早津智/A01_平淡.png", scale = 1, x = 350, y = -450, alpha = 0, multiply = "#798280",); //创建立绘早津智
cmd_block
{
    at 0, Tachie.Alpha(name = "Masashi", alpha_began = 0, alpha_ended = 1, time = 0.5,);
    at 0, Tachie.Alpha(name = "Satoshi", alpha_began = 0, alpha_ended = 1, time = 0.5,);
    at 0, Script.Narration(dialogue = "还有203室的大学生租户森川雅史和早津智。",);
}

WaitForClick(); //··
Tachie.Multiply(name = "Satoshi", color = "#798280", factor = 0.3,); //立绘亮度减半
Script.Dialogue(name = "森川 雅史", dialogue = "发生什么事了？",);

WaitForClick(); //··
cmd_block
{
    at 0, Tachie.Alpha(name = "Satoshi", alpha_began = 1, alpha_ended = 0, time = 0.2,);
    at 0, Tachie.Alpha(name = "Masashi", alpha_began = 1, alpha_ended = 0, time = 0.2,);
    at 0.1, Tachie.Create(name = "Toshiyuki", image = "D02_菅田敏之/A05_严肃.png", scale = 1.25, x = 0, y = -750, alpha = 0, multiply = "#798280",); //创建立绘菅田敏之
    at 0.2, Tachie.Alpha(name = "Toshiyuki", alpha_began = 0, alpha_ended = 1, time = 0.2,);
    at 0.2, Script.Dialogue(name = "菅田 敏之", dialogue = "你们几个，晚上有没有听到过桌椅倾倒和花瓶砸在地上的声音？",);
}

WaitForClick(); //··
cmd_block
{
    at 0, Tachie.Switch(name_A = "Toshiyuki", image_A = "D02_菅田敏之/A05_严肃.png", time_A = 0.2, name_B = "Daisuke", image_B = "D06_荻原大辅/A01.png", time_B = 0.2,);//切换立绘
    at 0.2, Script.Dialogue(name = "荻原 大辅", dialogue = "我好像听到过，不过那不是你们两个小子搞出来的动静吗？",);
}

WaitForClick(); //··
Tachie.Alpha(name = "Daisuke", alpha_began = 1, alpha_ended = 0, time = 0.2,);
Tachie.Multiply(name = "Satoshi", color = "#798280", factor = 1,); //立绘亮度复原
Tachie.Multiply(name = "Masashi", color = "#798280", factor = 0.3,);
cmd_block
{
    at 0, Tachie.Alpha(name = "Masashi", alpha_began = 0, alpha_ended = 1, time = 0.2,);
    at 0, Tachie.Alpha(name = "Satoshi", alpha_began = 0, alpha_ended = 1, time = 0.2,);
    at 0, Script.Dialogue(name = "早津 智", dialogue = "哈？我们？",);
}

WaitForClick(); //··
Tachie.Set(name = "Daisuke", image = "D06_荻原大辅/A01.png", scale = 1.25, x = 0, y = -750, alpha = 0, multiply = "#798280",); //放大居中荻原大辅立绘
cmd_block
{
    at 0, Tachie.Alpha(name = "Satoshi", alpha_began = 1, alpha_ended = 0, time = 0.2,);
    at 0, Tachie.Alpha(name = "Masashi", alpha_began = 1, alpha_ended = 0, time = 0.2,);
    at 0.2, Tachie.Alpha(name = "Daisuke", alpha_began = 0, alpha_ended = 1, time = 0.2,);
    at 0.2, Script.Dialogue(name = "荻原 大辅", dialogue = "不是你们聚了群小年轻在房间里搞搞<link=009><color=#ff6000>派对</color></link>吗？吵吵嚷嚷的。",);
}

WaitForClick(); //··
Tachie.Alpha(name = "Daisuke", alpha_began = 1, alpha_ended = 0, time = 0.2,);
Tachie.Set(name = "Satoshi", image = "D05_早津智/A04_厌烦.png", scale = 1.25, x = 0, y = -650, alpha = 0, multiply = "#798280",); //放大居中早津智立绘
Tachie.Set(name = "Masashi", image = "D04_森川雅史/A04_严肃.png", scale = 1.25, x = 0, y = -700, alpha = 0, multiply = "#798280",); //放大居中森川雅史立绘
cmd_block
{
    at 0, Tachie.Alpha(name = "Satoshi", alpha_began = 0, alpha_ended = 1, time = 0.2,);
    at 0, Script.Dialogue(name = "早津 智", dialogue = "喂，大叔，你有没有搞错啊？我们是开派对又不是打架，怎么会敲桌子砸板凳啊？",);
}

WaitForClick(); //··
Tachie.Alpha(name = "Satoshi", alpha_began = 1, alpha_ended = 0, time = 0.2,);
cmd_block
{
    at 0, Tachie.Alpha(name = "Toshiyuki", alpha_began = 0, alpha_ended = 1, time = 0.2,);
    at 0, Script.Dialogue(name = "菅田 敏之", dialogue = "别争了。那应该是303室传出的声响，这间屋子出事了。",);
}

WaitForClick(); //··
Tachie.Alpha(name = "Toshiyuki", alpha_began = 1, alpha_ended = 0, time = 0.2,);
cmd_block
{
    at 0, Frame.PictureOn(image = "//图片/B_第一章/05_门上的魔法阵.png", color = "gray", duration = 0.3,); //图片框体展开
    at 0, Script.Narration(dialogue = "菅田敏之说着，将自己方才拍下的魔法阵照片与透过百叶窗缝看到的碎花瓶照片传给了三人。",);
}

WaitForClick(); //··
Frame.PictureOff(0.3);
cmd_block
{
    at 0, Tachie.Alpha(name = "Masashi", alpha_began = 0, alpha_ended = 1, time = 0.2,);
    at 0, Script.Dialogue(name = "森川 雅史", dialogue = "这是……魔法阵？",);
}

WaitForClick(); //··
Script.Avatar(name = "本马 秀和", dialogue = "我们已经敲了半天门了，但这家的住户始终没有回应。", avater = "灰/D01_本马秀和/A01_平常.png");

WaitForClick(); //··
Tachie.Alpha(name = "Masashi", alpha_began = 1, alpha_ended = 0, time = 0.2,);
Tachie.Set(name = "Masashi", image = "D04_森川雅史/A04_严肃.png", scale = 1.25, x = -450, y = -700, alpha = 0, multiply = "#798280",); //设定森川雅史立绘位置
Tachie.Set(name = "Satoshi", image = "D05_早津智/A03_疑问.png", scale = 1.25, x = 450, y = -650, alpha = 0, multiply = "#798280",); //设定早津智立绘位置
cmd_block
{
    at 0, Tachie.Alpha(name = "Masashi", alpha_began = 0, alpha_ended = 1, time = 0.2,);
    at 0, Tachie.Alpha(name = "Satoshi", alpha_began = 0, alpha_ended = 1, time = 0.2,);
    at 0, Script.Narration(dialogue = "两名大学生面面相觑，还是荻原大辅最快反应了过来。",);
}

WaitForClick(); //··
cmd_block
{
    at 0, Tachie.Alpha(name = "Masashi", alpha_began = 1, alpha_ended = 0, time = 0.2,);
    at 0, Tachie.Alpha(name = "Satoshi", alpha_began = 1, alpha_ended = 0, time = 0.2,);
    at 0.2, Tachie.Alpha(name = "Daisuke", alpha_began = 0, alpha_ended = 1, time = 0.2,);
    at 0.2, Script.Dialogue(name = "荻原 大辅", dialogue = "我们该做什么？把房门撞开吗？",);
}

WaitForClick(); //··
Script.Avatar(name = "本马 秀和", dialogue = "…………", avater = "灰/D01_本马秀和/A01_平常.png");

WaitForClick(); //··
Tachie.Alpha(name = "Daisuke", alpha_began = 1, alpha_ended = 0, time = 0.2,);
Script.Narration(dialogue = "本马秀和一言不发地点了点头。",);

WaitForClick(); //··
cmd_block
{
    at 0, Tachie.Alpha(name = "Toshiyuki", alpha_began = 0, alpha_ended = 1, time = 0.2,);
    at 0, Script.Dialogue(name = "菅田 敏之", dialogue = "来帮把手，让那台机器人也过来一起撞。",);
}

WaitForClick(); //··
Text.Clear();
Tachie.Alpha(name = "Toshiyuki", alpha_began = 1, alpha_ended = 0, time = 0.2,);
Tachie.Set(name = "Masashi", image = "D04_森川雅史/A04_严肃.png", scale = 1, x = -750, y = -450, alpha = 0, multiply = "#798280",); //四名配角一字排开
Tachie.Set(name = "Satoshi", image = "D05_早津智/A01_平淡.png", scale = 1, x = -250, y = -400, alpha = 0, multiply = "#798280",);
Tachie.Set(name = "Toshiyuki", image = "D02_菅田敏之/A05_严肃.png", scale = 1, x = 250, y = -450, alpha = 0, multiply = "#798280",);
Tachie.Set(name = "Daisuke", image = "D06_荻原大辅/A01.png", scale = 1, x = 750, y = -450, alpha = 0, multiply = "#798280",);
Picture.Create(name = "bg1", image = "//背景/B_第一章/07F_鸦巢公寓三楼走廊_303室房门.png", alpha = 0); //切换背景
Picture.Alpha(name = "bg1", alpha_began = 0, alpha_ended = 1, time = 0.5,);
Picture.Release("bg2");
cmd_block
{
    at 0, Tachie.Alpha(name = "Masashi", alpha_began = 0, alpha_ended = 1, time = 0.2,);
    at 0, Tachie.Alpha(name = "Satoshi", alpha_began = 0, alpha_ended = 1, time = 0.2,);
    at 0, Tachie.Alpha(name = "Toshiyuki", alpha_began = 0, alpha_ended = 1, time = 0.2,);
    at 0, Tachie.Alpha(name = "Daisuke", alpha_began = 0, alpha_ended = 1, time = 0.2,);
    at 0, Script.Narration(dialogue = "五个人在门前排开，机器人在首，准备一同发力撞开房门。",);
}

WaitForClick(); //··
Tachie.Multiply(name = "Masashi", color = "#798280", factor = 0.3,);
Tachie.Multiply(name = "Satoshi", color = "#798280", factor = 0.3,);
Tachie.Multiply(name = "Toshiyuki", color = "#798280", factor = 0.3,);
Script.Dialogue(name = "荻原 大辅", dialogue = "准备，一、二……",);

WaitForClick(); //··
Script.Dialogue(name = "荻原 大辅", dialogue = "<size=40>喝啊——！</size>",);

WaitForClick(); //··
Tachie.Multiply(name = "Daisuke", color = "#798280", factor = 0.3,);
Script.Narration(dialogue = "在荻原大辅的号令下，众人一齐撞向房门。",);

WaitForClick(); //··
Text.Clear();
cmd_block //全员立绘淡出
{
    at 0, Tachie.Alpha(name = "Masashi", alpha_began = 1, alpha_ended = 0, time = 0.2,);
    at 0, Tachie.Alpha(name = "Satoshi", alpha_began = 1, alpha_ended = 0, time = 0.2,);
    at 0, Tachie.Alpha(name = "Toshiyuki", alpha_began = 1, alpha_ended = 0, time = 0.2,);
    at 0, Tachie.Alpha(name = "Daisuke", alpha_began = 1, alpha_ended = 0, time = 0.2,);
}
SE.Play(audio = "//SE/B_开关门/05_撞门声.ogg", volume = 1, loop = false,);
Picture.Vibrate("bg1", "strong");//屏幕振动
WaitCommand(0.5);
Tachie.Set(name = "Daisuke", image = "D06_荻原大辅/A01.png", scale = 1.25, x = 0, y = -750, alpha = 0, multiply = "#798280",); //放大居中荻原大辅立绘
Tachie.Alpha(name = "Daisuke", alpha_began = 0, alpha_ended = 1, time = 0.2,);
Script.Dialogue(name = "荻原 大辅", dialogue = "好结实……！",);

WaitForClick(); //··
Tachie.Alpha(name = "Daisuke", alpha_began = 1, alpha_ended = 0, time = 0.2,);
Tachie.Set(name = "Toshiyuki", image = "D02_菅田敏之/A05_严肃.png", scale = 1.25, x = 0, y = -750, alpha = 0, multiply = "#798280",); //放大居中菅田敏之立绘
cmd_block
{
    at 0, Tachie.Alpha(name = "Toshiyuki", alpha_began = 0, alpha_ended = 1, time = 0.2,);
    at 0, Script.Dialogue(name = "菅田 敏之", dialogue = "那就将施力点朝外，对准门锁的位置。一、二——",);
}

WaitForClick(); //··
Text.Clear();
Tachie.Alpha(name = "Toshiyuki", alpha_began = 1, alpha_ended = 0, time = 0.2,);
cmd_block
{
    at 0, SE.Play(audio = "//SE/B_开关门/05_撞门声.ogg", volume = 1, loop = false,);
    at 0, Picture.Vibrate("bg1", "strong");//屏幕振动
    at 0, BGM.Volume(volume_began = 0.7, volume_ended = 0, time = 0.5,);//BGM淡出
    at 0, Picture.Scale(name = "bg1", scale_began = 1, scale_ended = 1.5, time = 0.3, curve = "uniform",); //门放大
    at 0.2, Picture.Alpha(name = "bg1", alpha_began = 1, alpha_ended = 0, time = 0.2,);
}
Script.Narration(dialogue = "“磅！”的一声，门开了。",);

WaitForClick(); //··
Script.Narration(dialogue = "巨大的惯性让五人踉踉跄跄地冲进了屋内。",);

WaitForClick(); //··
Script.Narration(dialogue = "本马秀和下意识地想扶住墙，却恰好按到了灯的开关。",);

WaitForClick(); //··
Text.Clear();
cmd_block
{
    at 0, Text.ChangeAlpha(alpha_began = 1, alpha_ended = 0, time = 0.5,);
    at 0, SE.Play(audio = "//SE/E_机械音/01_电灯开关.ogg", volume = 1, loop = false,);
    at 0.2, Camera.SparkingWhite(1); //屏幕闪白
}
Text.ChangeAlpha(alpha_began = 0, alpha_ended = 1, time = 0.5,);
Script.Narration(dialogue = "前所未有的紧张感涌上心头。",);

WaitForClick(); //··
SE.Play(audio = "//SE/G_氛围音/02_心跳一次.ogg", volume = 0.8, loop = false,);
Script.Narration(dialogue = "映入眼帘的画面是——",);

WaitForClick(); //··
Text.Clear();
Text.ChangeAlpha(alpha_began = 1, alpha_ended = 0, time = 1,);
Picture.Create(name = "bg2", image = "//背景/B_第一章/08B_鸦巢公寓303室_正门夜晚尸体.png", scale = 3, x = 1500, y =900, alpha = 1);
Picture.Release("bg1");
CanSkip(false); //禁止跳过
WaitCommand(0.5);
cmd_block
{
    at 0, SE.Play(audio = "//SE/G_氛围音/03_恐怖的登场.ogg", volume = 0.7, loop = false,);
    at 0, Camera.WhiteRestore(0.5); //屏幕闪白恢复
    at 0.1, Picture.Move(name = "bg2", x_began = 1500, y_began = 900, x_ended = 0, y_ended = 0, scale_began = 3, scale_ended = 1, time = 0.5, curve = "ease_in");//图片移动
}



//————————————————————
//————————结尾——————————
//————————————————————



StoryArrow(1, true);
WaitCommand(3.5);
Picture.Alpha(name = "bg2", alpha_began = 1, alpha_ended = 0, time = 1,);
JumpToScript("脚本/V2/sv_01_02.json");