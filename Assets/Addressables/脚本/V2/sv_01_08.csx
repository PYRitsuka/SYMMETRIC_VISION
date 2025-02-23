//C:\Users\10533\Desktop\SYMMETRIC_VISION\makeScript.bat


//—————————————————
//——————章节标题———————
//—————————————————

StoryBlock(8, true);
CanSkip(false);
VisionTrigger(false);
SetChapter("01", "谱线蓝移的七等星");
BGM.Stop();
Picture.CreateMovie(name = "p1", movie = "B_第一章_视频/99B_第一章章节名.mp4", alpha = 1, Loop = false,);
WaitCommand(0.5);
SetUIMode(5);
CanSkip(true);
CanAuto(true);


//—————————————————
//——————绚音登场———————
//—————————————————

//背景创建
Picture.Create(name = "Out", image = "//背景/B_第一章/14_旧居民楼楼道口.png", scale = 1, x = 0, y = 0, alpha = 0,);
//背景创建

//立绘创建
Tachie.Create(name = "Tokino", image = "A04_池田时乃/A02_元气.png", scale = 1.25, x = 0, y = -500, alpha = 0, multiply = "#F9F6F4",); //近景，y值-600~-800
//立绘创建

SetUIMode(1);
BGM.Set(audio = "//BGM/B02-笑语晨辉.mp3", volume = 0.6,);
//三段拉镜特写
Picture.Create(name = "MoveA", image = "//背景/B_第一章/14_旧居民楼楼道口.png", scale = 2, x = 0, y = 0, alpha = 0,);
Picture.Create(name = "MoveB", image = "//背景/B_第一章/14_旧居民楼楼道口.png", scale = 2, x = 0, y = 0, alpha = 0,);
Picture.Create(name = "MoveC", image = "//背景/B_第一章/14_旧居民楼楼道口.png", scale = 1.25, x = 0, y = 0, alpha = 0,);
Tachie.Create(name = "AyaneA", image = "A01_竹内绚音/A01_平常.png", scale = 1, x = 0, y = 0, alpha = 0, multiply = "#F9F6F4",);
Tachie.Create(name = "AyaneB", image = "A01_竹内绚音/A01_平常.png", scale = 1, x = 0, y = 0, alpha = 0, multiply = "#F9F6F4",);
Tachie.Create(name = "AyaneC", image = "A01_竹内绚音/A01_平常.png", scale = 1, x = 0, y = 0, alpha = 0, multiply = "#F9F6F4",);
cmd_block
{
    at 0, Picture.Move(name = "MoveA", x_began = 600, y_began = 250, x_ended = 720, y_ended = 250, scale_began = 2, scale_ended = 2, time = 3.5, curve = "uniform",);
    at 0, Picture.Alpha(name = "MoveA", alpha_began = 0, alpha_ended = 1, time = 0.5,);
    at 0, Tachie.Move(name = "AyaneA", x_began = -325, y_began = 100, x_ended = -375, y_ended = 100, scale_began = 1.6, scale_ended = 1.6, time = 3.5, curve = "uniform",);
    at 0, Tachie.Show(name = "AyaneA", time = 0.5,);
    at 3, Tachie.Hide(name = "AyaneA", time = 0.5,);
    at 3, Picture.Move(name = "MoveB", x_began = -600, y_began = -250, x_ended = -720, y_ended = -250, scale_began = 2, scale_ended = 2, time = 3.5, curve = "uniform",);
    at 3, Picture.Alpha(name = "MoveB", alpha_began = 0, alpha_ended = 1, time = 0.5,);
    at 3, Tachie.Move(name = "AyaneB", x_began = 325, y_began = -400, x_ended = 375, y_ended = -400, scale_began = 1.6, scale_ended = 1.6, time = 3.5, curve = "uniform",);
    at 3, Tachie.Show(name = "AyaneB", time = 0.5,);
    at 6, Tachie.Hide(name = "AyaneB", time = 0.5,);
    at 6, Picture.Move(name = "MoveC", x_began = 0, y_began = -125, x_ended = 0, y_ended = 0, scale_began = 1.25, scale_ended = 1.25, time = 1.5, curve = "uniform",);
    at 6, Picture.Alpha(name = "MoveC", alpha_began = 0, alpha_ended = 1, time = 0.5,);
    at 6, Tachie.Move(name = "AyaneC", x_began = 0, y_began = -200, x_ended = 0, y_ended = -780, scale_began = 1.5, scale_ended = 1.5, time = 1.5, curve = "ease_out",);
    at 6, Tachie.Show(name = "AyaneC", time = 0.5,);
}
Picture.Release("MoveA");
Picture.Release("MoveB");
Tachie.Release("AyaneA");
Tachie.Release("AyaneB");
//三段拉镜特写
WaitCommand(0.5);
Picture.Alpha(name = "Out", alpha_began = 0, alpha_ended = 1, time = 0,);
cmd_block
{
    at 0, Picture.Alpha(name = "MoveC", alpha_began = 1, alpha_ended = 0, time = 0.5,);
    at 0, Tachie.Hide(name = "AyaneC", time = 0.5,);
}
Picture.Release("MoveC");
Tachie.Release("AyaneC");
//BMI开启
SetUIMode(0);
UI.Create(name = "BMIO", image = "A_系统UI/01_BMI边框.png", scale = 1.3, alpha = 1,);
UI.Scale(name = "BMIO", scale_began = 1.3, scale_ended = 1, time = 0.5, curve = "uniform",);
SE.Play(audio = "//SE/A_系统音效/01_回路启动.ogg", volume = 0.4,);
//BMI开启
//通话状态开启
UI.Create(name = "phone", image = "B_第一章/08_通话-池田时乃.png", scale = 1, alpha = 0,);
UI.Move(name = "phone", x_began = -200, x_ended = 0, time = 0.7, curve = "ease_out", alpha_began = 0, alpha_ended = 1, alpha_time = 0.7,);
Tachie.SetCall(name = "Tokino", enabled = true);
//通话状态开启
cmd_block
{
    at 0, Tachie.Show(name = "Tokino", image = "A04_池田时乃/A02_元气.png", time = 0.5,);
    at 0, Text.Show();
}
Script.Text(avater = "", name = "池田 时乃", dialogue = "喂喂，巧露露～听得到吗？时乃的声音能听清吗？",);

WaitForClick();
Script.Text(avater = "粉/A01_竹内绚音/A13_不耐烦.png", name = "竹内 绚音", dialogue = "听到啦，你这什么播音腔啊，听着好怪。",);

WaitForClick();
Script.Expression(name = "Tokino", image = "A04_池田时乃/A01_微笑.png", textname = "池田 时乃", dialogue = "我在录Vlog啦，刚才那个是开场白。",);

WaitForClick();
Script.Text(avater = "粉/A01_竹内绚音/A03_坏笑.png", name = "竹内 绚音", dialogue = "Vlog？你该不会是打算Mewtuber出道吧？",);

WaitForClick();
Script.Expression(name = "Tokino", image = "A04_池田时乃/D01_自信.png", textname = "池田 时乃", dialogue = "是的，正能量反诈系Mewtuber时乃大人是也！",);

WaitForClick();
Script.Text(avater = "粉/A01_竹内绚音/A21_汗颜.png", name = "竹内 绚音", dialogue = "好好好，观众朋友们，镜头前的这位正能量子供系主播上个月刚因为相信别人发明了锂激光等离子光源被骗了10000日元。",);

WaitForClick();
Script.Expression(name = "Tokino", image = "A04_池田时乃/D05_不服气.png", textname = "池田 时乃", dialogue = "我只是想要支持科学发展而已！",);

WaitForClick();
Script.Text(avater = "粉/A01_竹内绚音/A07_自信.png", name = "竹内 绚音", dialogue = "与其关注一个只能躲在镜头后面念开场白的傻妹子，不如来关注关注真正在为反诈事业身体力行的一线调查人员如何？我的频道名是TakUchill……",);

WaitForClick();
Script.Expression(name = "Tokino", image = "A04_池田时乃/A05_不服气.png", textname = "池田 时乃", dialogue = "Cut，不录了。",);

WaitForClick();
Script.Text(avater = "粉/A01_竹内绚音/A21_汗颜.png", name = "竹内 绚音", dialogue = "…………",);

WaitForClick();
Script.Text(avater = "粉/A01_竹内绚音/A03_坏笑.png", name = "竹内 绚音", dialogue = "我猜你下一句话会生硬地转移话题。",);

WaitForClick();
Script.Expression(name = "Tokino", image = "A04_池田时乃/A01_微笑.png", textname = "池田 时乃", dialogue = "话说姐姐为什么要换新BMI啊？原来的那个坏了吗，呃……",);
WaitCommand(0.2);
Tachie.Change(name = "Tokino", image = "A04_池田时乃/A03_无语.png", time = 0.2, );

WaitForClick();
Script.Text(avater = "粉/A01_竹内绚音/A03_坏笑.png", name = "竹内 绚音", dialogue = "哈哈。",);

WaitForClick();
Script.Expression(name = "Tokino", image = "A04_池田时乃/A05_不服气.png", textname = "池田 时乃", dialogue = "讨厌！再这样下去不当姐姐的科学顾问了。",);

WaitForClick();
Script.Text(avater = "粉/A01_竹内绚音/A01_平常.png", name = "竹内 绚音", dialogue = "今天的行动本来也不需要科学顾问吧。好了好了，快帮忙把目的地的照片用短信发给我，我现在连不上网。",);

WaitForClick();
cmd_block
{
    at 0, Script.Text(avater = "", name = "池田 时乃", dialogue = "已经发过去了。",);
    at 0, BGM.Volume(volume_began = 0.6, volume_ended = 0, time = 1,);
}

WaitForClick();
Text.Clear();
BGM.Set(audio = "//BGM/D04-线索分析.mp3", volume = 0.7,);
Tachie.Hide(name = "Tokino",);
SE.Play(audio = "//SE/A_系统音效/01_回路启动.ogg", volume = 0.4,);
Script.Text(avater = "", name = "", dialogue = "时乃发过来的，是Twipo上的一张推文截图。",);
//可滚动网页入场
UI.Create(name = "URL", image = "B_第一章/09A_网页.png", scale = 1, x = 0, y = 825, alpha = 1,);
UI.CreatePage(name = "Page", image = "B_第一章/09B_网页截图.png", scale = 1, x = 0, y = 948, width = 1370, height = 678, direction = "vertical", angle = 0, alpha = 1,);
cmd_block
{
    at 0, UI.Position(name = "URL", x_began = 0, y_began = 825, x_ended = 0, y_ended = 0, time = 0.8, curve = "uniform",);
    at 0, UI.Position(name = "Page", x_began = 0, y_began = 948, x_ended = 0, y_ended = 128, time = 0.8, curve = "uniform",);
}
//可滚动网页入场

WaitForClick();
//提示弹出
SE.Play(audio = "//SE/A_系统音效/07_提示弹出.ogg", volume = 1,);
UI.Create(name = "Hint", image = "B_第一章/10_网页提示.png", scale = 1, x = 526, y = 0, alpha = 1,);
cmd_block
{
    at 0, UI.Position(name = "Hint", x_began = 526, y_began = 0, x_ended = 0, y_ended = 0, time = 0.8, curve = "uniform",);
    at 0, Script.Text(avater = "", name = "", dialogue = "这是我能找到的最早的关于旭町废弃楼房闹鬼传闻的推文。",);
}
//提示弹出

WaitForClick();
Script.Text(avater = "", name = "", dialogue = "就是从这个推文出现后，那间“鬼屋”一夜爆火，SNS上每天都会冒出鬼屋探险的实况。",);

WaitForClick();
Script.Text(avater = "", name = "", dialogue = "有些是明知道这地方有鬼打墙还要来故意找刺激的，也有完全不信邪想要靠实际行动将都市传说证伪的。",);

WaitForClick();
Script.Text(avater = "", name = "", dialogue = "但这些人在逃出来后都无一例外地宣称再也不想接近这幢楼了。",);

WaitForClick();
Script.Text(avater = "", name = "", dialogue = "据说进了楼内以后，待的时间越久迷路越深。最开始是有脚步声和笑声追着你，到后面会变成时隐时现的鬼影远远地在身后跟着。",);

WaitForClick();
Script.Text(avater = "", name = "", dialogue = "而且电子设备的通讯和录像功能一律失灵，迄今为止网上完全搜不到楼内的录像，最多只有零零散散的照片。",);

WaitForClick();
Script.Text(avater = "", name = "", dialogue = "许多人到最后都撑不下去，只好选择花钱消灾。",);

WaitForClick();
//提示收起
cmd_block
{
    at 0, UI.Position(name = "Hint", x_began = 0, y_began = 0, x_ended = 526, y_ended = 0, time = 0.8, curve = "uniform",);
    at 0, Script.Text(avater = "", name = "", dialogue = "最近的一次是昨天，两名巡警进入了楼内，但他们身上没带够10000日元，直到12小时后才精神恍惚地从大楼中脱困。",);
}
UI.Release("Hint");
//提示收起

WaitForClick();
Script.Text(avater = "", name = "", dialogue = "然后昨晚光丘警察署就在网上发布了文章，劝说市民不要靠近旭町的旧团地，等待警方查明这栋楼的产权。",);

WaitForClick();
Script.Text(avater = "", name = "", dialogue = "不过我今天还是找了个法子绕开警戒线溜了进来。",);

WaitForClick();
Script.Text(avater = "", name = "", dialogue = "我倒不是出于对超自然怪谈的兴趣而寻找这里的。",);

WaitForClick();
Script.Text(avater = "", name = "", dialogue = "班里的女生们有不少人喜欢魔法呀、占星术呀、还有灵异事件之类的话题，但我和妹妹时乃都是不相信鬼神之谈的那种人。",);

WaitForClick();
Script.Text(avater = "", name = "", dialogue = "我今天来到这里，是有着别的更重要的目标。",);

WaitForClick();
Script.Text(avater = "", name = "", dialogue = "听说十几年前有个叫『轻轻松松破假象』的论坛，热衷于用科学破解各种都市传说。我今天要做的事就和他们差不多。",);

WaitForClick();
Text.Clear();
//可滚动网页离场
SE.Play(audio = "//SE/A_系统音效/02_回路关闭.ogg", volume = 0.4,);
cmd_block
{
    at 0, UI.Position(name = "URL", x_began = 0, y_began = 0, x_ended = 0, y_ended = 825, time = 0.8, curve = "uniform",);
    at 0, UI.Position(name = "Page", x_began = 0, y_began = 128, x_ended = 0, y_ended = 948, time = 0.8, curve = "uniform",);
}
UI.Release("URL");
UI.Release("Page");
//可滚动网页离场
Script.Text(avater = "粉/A01_竹内绚音/A07_自信.png", name = "竹内 绚音", dialogue = "看来，我们已经找对地方了。",);

WaitForClick();
Script.CharacterShow(name = "Tokino", image = "A04_池田时乃/A01_微笑.png", time = 0.5, textname = "池田 时乃", dialogue = "进入楼内的话就没法保持通话了吧？没有我在的话，光靠姐姐你能弄清鬼打墙的原理吗？",);

WaitForClick();
Script.Text(avater = "粉/A01_竹内绚音/C08_认真聆听.png", name = "竹内 绚音", dialogue = "如果我对犯人的作案手法猜测没错的话，有我耳朵上的这枚高性能载波电极在，全身而退还是没问题的。",);

WaitForClick();
Script.Expression(name = "Tokino", image = "A04_池田时乃/A09_疑惑.png", textname = "池田 时乃", dialogue = "那个居然是高性能载波电极吗？可是我听说这种设备都是靠黑市上的黑客改装而来的，一般很难买到吧？",);

WaitForClick();
Script.Text(avater = "粉/A01_竹内绚音/A22_说明.png", name = "竹内 绚音", dialogue = "二手商店淘来的次品，找维修店老板修了一下勉强能用而已。",);

WaitForClick();
Script.Text(avater = "粉/A01_竹内绚音/A01_平常.png", name = "竹内 绚音", dialogue = "给你打电话就是为了测试一下通话功能有没有激活成功，现在麻烦的是网络我还没调好。",);

WaitForClick();
Script.Expression(name = "Tokino", image = "A04_池田时乃/A01_微笑.png", textname = "池田 时乃", dialogue = "那姐姐不用的载波电极可不可以送我？",);

WaitForClick();
Script.Text(avater = "粉/A01_竹内绚音/A21_汗颜.png", name = "竹内 绚音", dialogue = "想得美，你不会又想从我这儿骗东西拿去卖钱吧？",);

WaitForClick();
Script.Expression(name = "Tokino", image = "A04_池田时乃/A04_装傻.png", textname = "池田 时乃", dialogue = "诶嘿嘿……",);

WaitForClick();
Script.Text(avater = "粉/A01_竹内绚音/A01_平常.png", name = "竹内 绚音", dialogue = "先挂了，半小时后见。",);

WaitForClick();
//通话状态关闭
Text.Clear();
SE.Play(audio = "//SE/A_系统音效/02_回路关闭.ogg", volume = 0.4,);
cmd_block
{
    at 0, Tachie.Hide(name = "Tokino",);
    at 0, UI.Move(name = "phone", x_began = 0, x_ended = -200, time = 0.7, curve = "ease_out", alpha_began = 1, alpha_ended = 0, alpha_time = 0.7,);
}
UI.Release("phone");
Tachie.SetCall(name = "Tokino", enabled = false);
//通话状态关闭
BGM.Volume(volume_began = 0.7, volume_ended = 0, time = 1,);
Script.Text(avater = "", name = "", dialogue = "接下来……",);

WaitForClick();
Script.Text(avater = "", name = "", dialogue = "看着眼前黑幽幽的楼梯口，我不禁咽了咽口水。",);

WaitForClick();
Script.Text(avater = "", name = "", dialogue = "说实话，这地方的环境还真有些阴森。",);

WaitForClick();
Script.Text(avater = "", name = "", dialogue = "四周的居民楼一个人影也看不到，应该是旧团地的拆除工程受M流感疫情影响中断而导致的。",);

WaitForClick();
Script.Text(avater = "", name = "", dialogue = "虽说我不怕鬼，但身处这样寂静到诡异的环境中，还是免不了胡思乱想。",);

WaitForClick();
Script.Text(avater = "", name = "", dialogue = "像这种废弃楼房，放到悬疑小说里，是不是特别容易在里面发现个藏尸什么的……",);

WaitForClick();
Script.Text(avater = "", name = "", dialogue = "不对，清醒一点，绚音。这是现实，不是小说。",);

WaitForClick();
Script.Text(avater = "", name = "", dialogue = "拍了拍自己的脸下定决心后，我向着楼梯迈出了脚步。",);

WaitForClick();
Text.Hide();
cmd_block
{
    at 0, Picture.Scale(name = "Out", scale_began = 1, scale_ended = 1.4, time = 1, curve = "uniform",);
    at 0, Picture.Position(name = "Out", x_began = 0, y_began = 0, x_ended = -220, y_ended = 20, time = 1, curve = "uniform",);
    at 0.8, Picture.Alpha(name = "Out", alpha_began = 1, alpha_ended = 0, time = 0.5,);
}
WaitCommand(1.2);

//读档标记点
ClearScene();

//————————————————————
//———————鬼屋初探—————————
//————————————————————

SetUIMode(0);
UI.Create(name = "BMIO", image = "A_系统UI/01_BMI边框.png", scale = 1, alpha = 1,);
SetChapter("01", "谱线蓝移的七等星");
BGM.Stop();
CanSkip(true);
CanAuto(true);

//背景创建
Picture.Create(name = "BG", image = "//背景/B_第一章/15A_旧居民楼道_直走廊.png", scale = 1, x = 0, y = 0, alpha = 0,);
Picture.Create(name = "Filter", image = "//图片/B_第一章/24_冷色调雾气.png", scale = 1, x = 0, y = 0, alpha = 0,);
//背景创建

BGM.Set(audio = "//BGM/E01-思维螺旋.mp3", volume = 0.7,);
Picture.Alpha(name = "BG", alpha_began = 0, alpha_ended = 1, time = 1,);
Text.Show();
SE.Play(audio = "//SE/Z_剧情音效/01A_旭町鬼屋脚步声.ogg", volume = 0.9,);
Script.Text(avater = "", name = "", dialogue = "昏暗的光线、古旧的墙壁、落灰的地面，还有这单调到令人心慌的脚步回音。",);

WaitForClick();
Script.Text(avater = "", name = "", dialogue = "我走在幽暗狭窄的混凝土通道中，眼前不知何时蒙上了一层阴冷的雾气。",);
Picture.Alpha(name = "Filter", alpha_began = 0, alpha_ended = 1, time = 1,);

WaitForClick();
Script.Text(avater = "", name = "", dialogue = "两旁的房门以一种让人不舒服的整齐感排列着，直至延伸到黑暗尽头。",);

WaitForClick();
Script.Text(avater = "", name = "", dialogue = "我尝试打开BMI的夜视模式，但眼前依旧是漆黑一片，红外探测根本不起作用。",);

WaitForClick();
Script.Text(avater = "", name = "", dialogue = "定位也打不开，指南针乱转一气，手电筒开启后闪两下就会故障关闭。",);

WaitForClick();
Script.Text(avater = "", name = "", dialogue = "真的宛如走入了另一个世界。",);

WaitForClick();
Script.Text(avater = "", name = "", dialogue = "连色调都开始失真的，与现实隔绝的另一个世界。",);

WaitForClick();
Script.Text(avater = "粉/A01_竹内绚音/A16_失神.png", name = "竹内 绚音", dialogue = "…………",);

WaitForClick();
Text.Clear();
SE.Stop();
SE.Play(audio = "//SE/Z_剧情音效/01A_旭町鬼屋脚步声.ogg", volume = 0.9,);
Picture.Change(name = "BG", image = "//背景/B_第一章/15B_旧居民楼道_安全通道前_双向拐角.png", time = 0.5, );
Script.Text(avater = "", name = "", dialogue = "我沉默不语地向前走去，在走廊尽头抵达了第一条岔路。",);

WaitForClick();
Picture.CoveringOut(name = "BG", direction = "left", time = 0.5,);
Script.Text(avater = "", name = "", dialogue = "右转后又向前走了十几米，就找到了上楼的楼梯。",);
Picture.Change(name = "BG", image = "//背景/B_第一章/15H_旧居民楼道_楼梯口开门.png", time = 0, );
Picture.CoveringIn(name = "BG", direction = "right", time = 0.5,);

WaitForClick();
Text.Clear();
Picture.CoveringOut(name = "BG", direction = "up", time = 0.5,);
Picture.Change(name = "BG", image = "//背景/B_第一章/15A_旧居民楼道_直走廊.png", time = 0.3, );
Picture.CoveringIn(name = "BG", direction = "down", time = 0.5,);
Script.Text(avater = "", name = "", dialogue = "二楼和一楼一样，还是单调重复的走廊。",);

WaitForClick();
SE.Stop();
SE.Play(audio = "//SE/Z_剧情音效/01G_旭町鬼屋门轴声.ogg", volume = 0.7,);

WaitForClick();
Script.Text(avater = "", name = "", dialogue = "明明没有风，两旁的房门却时不时发出着吱吱的声音，听得人有些不寒而栗。",);

WaitForClick();
Script.Text(avater = "", name = "", dialogue = "而且……",);

WaitForClick();
Script.Text(avater = "", name = "", dialogue = "怎么总感觉有人在看着我？",);

WaitForClick();
Text.Clear();
SE.Play(audio = "//SE/K-打斗声/01_挥动.ogg", volume = 0.8,);
Picture.CoveringOut(name = "BG", direction = "right", time = 0.25,);
Picture.CoveringIn(name = "BG", direction = "left", time = 0.25,);
Script.Text(avater = "粉/A01_竹内绚音/A18_惊慌.png", name = "竹内 绚音", dialogue = "……！",);

WaitForClick();
Script.Text(avater = "", name = "", dialogue = "我猛地回过头朝身后望去，但那里除了黑暗以外什么也没有。",);

WaitForClick();
Script.Text(avater = "粉/A01_竹内绚音/A15_疑虑.png", name = "竹内 绚音", dialogue = "错觉吗……",);

WaitForClick();
Text.Clear();
SE.Stop();
SE.Play(audio = "//SE/Z_剧情音效/01B_旭町鬼屋脚步声.ogg", volume = 0.7,);
Picture.CoveringOut(name = "BG", direction = "down", time = 0.5,);
Script.Text(avater = "", name = "", dialogue = "二楼的路走着走着就不通了，我只能沿着旁边的消防通道再回到一楼。",);

WaitForClick();
Picture.Change(name = "BG", image = "//背景/B_第一章/15C_旧居民楼道_安全通道前_右转拐角.png", time = 0, );
Picture.CoveringIn(name = "BG", direction = "up", time = 0.5,);
Script.Text(avater = "粉/A01_竹内绚音/A05_吃惊.png", name = "竹内 绚音", dialogue = "诶？",);

WaitForClick();
Script.Text(avater = "", name = "", dialogue = "我记得，一楼的消防通道口应该左右都有路才对啊。",);

WaitForClick();
Script.Text(avater = "", name = "", dialogue = "刚刚来时还是这样。",);

WaitForClick();
Script.Text(avater = "", name = "", dialogue = "是我走到了另一条消防通道前吗？",);

WaitForClick();
Script.Text(avater = "", name = "", dialogue = "还是说……左边凭空多出了一面墙？",);

WaitForClick();
Text.Clear();
SE.Stop();
SE.Play(audio = "//SE/Z_剧情音效/01B_旭町鬼屋脚步声.ogg", volume = 0.7,);
Picture.CoveringOut(name = "BG", direction = "left", time = 0.5,);
Script.Text(avater = "", name = "", dialogue = "右拐，然后向前，我又一次抵达了去往二楼的楼梯口。",);

WaitForClick();
Picture.Change(name = "BG", image = "//背景/B_第一章/15G_旧居民楼道_楼梯口关门.png", time = 0, );
Picture.CoveringIn(name = "BG", direction = "right", time = 0.5,);
Script.Text(avater = "粉/A01_竹内绚音/A15_疑虑.png", name = "竹内 绚音", dialogue = "门关上了……",);

WaitForClick();
Script.Text(avater = "", name = "", dialogue = "明明刚刚还开着的。",);

WaitForClick();
Script.Text(avater = "", name = "", dialogue = "这就是所谓的鬼打墙吗……",);

WaitForClick();
Script.Text(avater = "", name = "", dialogue = "这肯定不是什么灵异现象，而是有人在远程操控开关门。",);

WaitForClick();
Script.Text(avater = "", name = "", dialogue = "可是，刚刚走廊拐角多出来的那面墙是怎么回事？如果那也是机关的话，这么大一面墙移动过来，弄出的动静我应该在二楼也能听到啊。",);

WaitForClick();
Script.Text(avater = "", name = "", dialogue = "想不明白，我只能继续在一楼打转。",);

WaitForClick();
Text.Clear();
Picture.CoveringOut(name = "BG", direction = "left", time = 0.5,);
SE.Stop();
SE.Play(audio = "//SE/Z_剧情音效/01C_旭町鬼屋脚步声.ogg", volume = 0.7,);
Picture.Change(name = "BG", image = "//背景/B_第一章/15A_旧居民楼道_直走廊.png", time = 1, );
Picture.CoveringIn(name = "BG", direction = "right", time = 0.5,);
Script.Text(avater = "", name = "", dialogue = "没过多久，我开始注意到脚步声的异常了。",);

WaitForClick();
Script.Text(avater = "", name = "", dialogue = "脚下明明是混凝土的地面，但每走出一步都能听到轻微的木板声。",);

WaitForClick();
Script.Text(avater = "", name = "", dialogue = "声音还在越变越清晰。",);

WaitForClick();
SE.Stop();
SE.Play(audio = "//SE/Z_剧情音效/01D_旭町鬼屋脚步声.ogg", volume = 0.7,);
Script.Text(avater = "", name = "", dialogue = "感到不安的我不自觉地加快了脚步，但木板的声音始终追逐在我身后挥之不去。",);

WaitForClick();
Script.Text(avater = "粉/A01_竹内绚音/A14_愤怒.png", name = "竹内 绚音", dialogue = "不行……！",);

WaitForClick();
Script.Text(avater = "", name = "", dialogue = "不能就这样被吓到，得趁这个机会弄清真相才行……！",);

WaitForClick();
Script.Text(avater = "", name = "", dialogue = "我按下了BMI的关机键。",);

WaitForClick();
Script.Text(avater = "", name = "", dialogue = "这附近能追着我播放声音的设备只有一个，那就是我的BMI。",);

WaitForClick();
Script.Text(avater = "", name = "", dialogue = "只要确认了关闭BMI能让声音消失，那就离揭穿这幢鬼屋的把戏不远了！",);

WaitForClick();
//关闭BMI
SE.Play(audio = "//SE/A_系统音效/02_回路关闭.ogg", volume = 0.4,);
cmd_block
{
    at 0, UI.Scale(name = "BMIO", scale_began = 1, scale_ended = 1.3, time = 0.5, curve = "uniform",);
    at 0, Text.Hide();
    at 0, BGM.Volume(volume_began = 0.6, volume_ended = 0, time = 1,);
}
SetUIMode(1);
//关闭BMI
Text.Show();
Script.Text(avater = "粉/A01_竹内绚音/A09_认真且平常.png", name = "竹内 绚音", dialogue = "这下让我看看你还能不能篡改我的脚步声。",);

WaitForClick();
Text.Clear();
SE.Play(audio = "//SE/Z_剧情音效/01E_旭町鬼屋脚步声.ogg", volume = 0.7,);
WaitCommand(2.5);
Script.Text(avater = "粉/A01_竹内绚音/A17_慌张.png", name = "竹内 绚音", dialogue = "诶？",);

WaitForClick();
Script.Text(avater = "", name = "", dialogue = "声音没有消失，为什么？",);

WaitForClick();
SE.Stop();
BGM.Set(audio = "//BGM/E02-镜像之惑-改.mp3", volume = 0.6,);
Script.Text(avater = "", name = "", dialogue = "脚步踩在木板上的声音越来越大，逐渐盖过了混凝土应有的声音。",);

WaitForClick();
Script.Text(avater = "", name = "", dialogue = "尽管明知道不该慌张，我还是忍不住跑了起来。",);
//跑步
Camera.KeepBumpy(90, 0.2);
//跑步
Picture.Alpha(name = "BG", alpha_began = 1, alpha_ended = 0, time = 1,);

WaitForClick();
Script.Text(avater = "", name = "", dialogue = "不对呀，没道理啊，我在SNS上看到过一篇没戴BMI进入楼内探险的文字实况，那个帖主就自称没遇上任何鬼打墙的灵异现象。",);

WaitForClick();
Script.Text(avater = "", name = "", dialogue = "有人利用NFC或者蓝牙在BMI内植入病毒，用虚假声音和虚假影像诱导人在楼里转圈圈，从而营造鬼打墙的错觉——我是这么推测的。",);

WaitForClick();
Script.Text(avater = "", name = "", dialogue = "可为什么，即使我关闭了BMI，这幢楼还是很不对劲？",);

WaitForClick();
Script.Text(avater = "", name = "", dialogue = "走廊两侧不是锁上的房门就是钉死的窗户，根本找不到离开的出口。",);

WaitForClick();
SE.Play(audio = "//SE/Z_剧情音效/01F_旭町鬼屋脚步声.ogg", volume = 0.7,);
Script.Text(avater = "", name = "", dialogue = "我的跑步声听上去已经完全变成踩在木板上的声音了。",);

WaitForClick();
Script.Text(avater = "", name = "", dialogue = "走廊两侧不是锁上的房门就是钉死的窗户，根本找不到离开的出口。",);

WaitForClick();
Script.Text(avater = "", name = "", dialogue = "再接下去，会像那些实况探险帖一样，看到有什么鬼影在尾随我吗？",);

WaitForClick();
Script.Text(avater = "", name = "", dialogue = "难道说……这幢楼不是什么人为制造的骗钱鬼屋，而是真的在发生灵异事件？",);

WaitForClick();
Script.Text(avater = "", name = "", dialogue = "那我岂不是已经被不干净的东西缠上了？",);

WaitForClick();
Script.Text(avater = "", name = "", dialogue = "但这是不可能的，这种循序渐进的心理引导太像恐怖电影的氛围营造技巧了，一定有人在背后操纵一切。",);

WaitForClick();
Script.Text(avater = "", name = "", dialogue = "冷静下来好好想想，为什么别人在BMI关机后进入楼内就不会看到灵异现象，而我关闭BMI就没用。",);

WaitForClick();
Script.Text(avater = "", name = "", dialogue = "要说区别的话，那位帖主是在上楼前关闭的BMI，而我是已经在楼内走了一阵后才关的。",);

WaitForClick();
Script.Text(avater = "", name = "", dialogue = "等一等，该不会……",);

WaitForClick();
//开启BMI
Text.Hide();
SE.Play(audio = "//SE/A_系统音效/01_回路启动.ogg", volume = 0.4,);
// cmd_block
// {
//     at 0, UI.PlayAnimation(name = "BMIU", image_array = "A_系统UI/BMI开机/BMI开机(1).png", release = false, scale = 1, x = 0, y = 0, angle = 0, alpha = 1,);
//     //at 0, UI.CreateMovie(name = "BMIU", movie = "A_系统UI/08_BMI开机.mov", scale = 1, x = 0, y = 0, angle = 0, alpha = 1, Loop = false, );
//     at 1, UI.Scale(name = "BMIO", scale_began = 1.3, scale_ended = 1, time = 0.5, curve = "uniform",);
//     at 1, Picture.Alpha(name = "BG", alpha_began = 0, alpha_ended = 1, time = 0.5,);
// }
Camera.StopMove();
SetUIMode(0);
//开启BMI
Text.Show();
Script.Text(avater = "", name = "", dialogue = "我重新打开了BMI。",);

WaitForClick();
Script.Text(avater = "", name = "", dialogue = "如果对方连BMI的关机动画都能伪造的话……？",);

WaitForClick();
Script.Text(avater = "", name = "", dialogue = "我再次打开夜视模式，不过这回不再探查红外线，而是将功能改为了检测LED光。",);
BGM.Volume(volume_began = 0.6, volume_ended = 0, time = 1,);

WaitForClick();
Script.Text(avater = "", name = "", dialogue = "刹那的灵光一现让我想到了新的可能性。",);

WaitForClick();
Script.Text(avater = "", name = "", dialogue = "特意买来来<link=020><color=#f0519c>高性能的载波电极</color></link>就是为了干这个用的！",);

WaitForClick();
Text.Clear();
//通知展开
SE.Play(audio = "//SE/A_系统音效/03_通话启动.ogg", volume = 0.5,);
UI.Create(name = "notice", image = "B_第一章/11A_检测到Lifi信号.png", scale = 1, x = 0, y = 110, alpha = 0,);
UI.ExpandIn(name = "notice", direction = "horizontal", time = 0.5,);
//通知展开
BGM.Set(audio = "//BGM/G02-电波解析.mp3", volume = 0.7,);
Script.Text(avater = "粉/A01_竹内绚音/A06_兴奋.png", name = "竹内 绚音", dialogue = "果然是，，<link=021><color=#f0519c></b>Li-Fi</color></link>！",);

WaitForClick();
Script.Text(avater = "", name = "", dialogue = "在连移动信号都接收不到的楼内居然检测出了Li-Fi，除了有人搞鬼以外找不到第二种解释了。",);

WaitForClick();
Script.Text(avater = "", name = "", dialogue = "我就知道肯定不会是真闹鬼。",);

WaitForClick();
//通知收起
SE.Play(audio = "//SE/A_系统音效/09_退出界面.ogg", volume = 0.6,);
UI.ExpandOut(name = "notice", direction = "horizontal", time = 0.5,);
UI.Release("notice");
//通知收起
Script.Text(avater = "", name = "", dialogue = "和我预想的差不多，鬼打墙的现象确实是有人往我BMI内植入病毒造成的。",);

WaitForClick();
Script.Text(avater = "", name = "", dialogue = "只不过对方的手段比我想得更周全，居然连BMI的开关机功能都能劫持。",);

WaitForClick();
Script.Text(avater = "", name = "", dialogue = "任何电子设备只要进入楼内就会被Li-Fi控制，使用者的一切操作反馈都会被拦截，替换成预先准备好的“灵异视频”。",);

WaitForClick();
Script.Text(avater = "粉/A01_竹内绚音/A09_认真且平常.png", name = "竹内 绚音", dialogue = "那我只要解析信号，弄清他往我的BMI里植入了什么就可以了。",);

WaitForClick();
Text.Clear();
//通知展开
SE.Play(audio = "//SE/A_系统音效/03_通话启动.ogg", volume = 0.5,);
UI.Create(name = "notice", image = "B_第一章/11B_信号解析报告.png", scale = 1, x = 0, y = 110, alpha = 0,);
UI.ExpandIn(name = "notice", direction = "horizontal", time = 0.5,);
//通知展开
Script.Text(avater = "粉/A01_竹内绚音/A09_认真且平常.png", name = "竹内 绚音", dialogue = "搞定！",);

WaitForClick();
//通知收起
SE.Play(audio = "//SE/A_系统音效/09_退出界面.ogg", volume = 0.6,);
UI.ExpandOut(name = "notice", direction = "horizontal", time = 0.5,);
UI.Release("notice");
//通知收起
Text.Clear();
Picture.Hide(name = "BG", time = 0.5);
//黑入代码展开
SE.Play(audio = "//SE/A_系统音效/11_确认提示.ogg", volume = 0.5,);
UI.Create(name = "code", image = "B_第一章/11C_信号解析报告.png", scale = 1, x = -600, y = 140, alpha = 0,);
UI.ExpandIn(name = "code", direction = "vertical", time = 0.5,);
//黑入代码展开
Script.Text(avater = "粉/A01_竹内绚音/A04_愣住.png", name = "竹内 绚音", dialogue = "呃……",);

WaitForClick();
Script.Text(avater = "", name = "", dialogue = "坏了，信号解析结果全是代码，我也看不懂啊。",);

WaitForClick();
Script.Text(avater = "", name = "", dialogue = "不过从里面频繁出现的单词“Audio”和“Vision”来看，我的BMI应该是被植入了两样病毒。",);

WaitForClick();
Script.Text(avater = "", name = "", dialogue = "一是音频替换，在我做出特定动作的时候——比如走路时——向我播放鞋子踩在老旧木板上的音频。",);

WaitForClick();
Script.Text(avater = "", name = "", dialogue = "二是AR特效，我眼前这片朦胧的雾气应该就是AR效果。",);

WaitForClick();
Text.Clear();
//黑入六边形
UI.Create(name = "hackingA", image = "B_第一章/11D_修改中.png", scale = 1, x = 0, y = 110, alpha = 0,);
UI.Create(name = "hackingB", image = "B_第一章/11E_加载圈.png", scale = 1, x = 0, y = 140, alpha = 0,);
UI.Create(name = "hackingC", image = "B_第一章/11F_覆盖层.png", scale = 1, x = 0, y = 110, alpha = 0,);
UI.Create(name = "hackingD", image = "B_第一章/11G_覆盖层文字.png", scale = 1, x = 0, y = 110, alpha = 0,);
UI.Move(name = "hackingA", scale_began = 1.2, scale_ended = 1, time = 0.5, curve = "uniform", alpha_began = 0, alpha_ended = 1, alpha_time = 0.5,);
UI.KeepMove(name = "hackingB",x_began = 0, y_began = 140, x_ended = 0, y_ended = 140, angle_began = 0, angle_ended = -1200, time = 5, curve = "uniform", alpha_began = 0, alpha_ended = 1, alpha_time = 0.5,);
SE.Play(audio = "//SE/A_系统音效/18_黑入信号.ogg", volume = 0.8,);
WaitCommand(2);
cmd_block
{
    at 0, UI.Move(name = "hackingC", scale_began = 1.5, scale_ended = 1, angle_began = 0, angle_ended = 180, time = 0.5, curve = "uniform", alpha_began = 0, alpha_ended = 1, alpha_time = 0.5,);
    at 0, UI.Move(name = "hackingD", scale_began = 1.5, scale_ended = 1, time = 0.5, curve = "uniform", alpha_began = 0, alpha_ended = 1, alpha_time = 0.5,);
    at 0, Picture.Hide(name = "Filter", time = 1);
    at 0, Script.Text(avater = "", name = "", dialogue = "像这样操作的话，就能隔离木马，把雾气消除掉。",);
}
UI.StopMove("hackingB");
Picture.Release("Filter");
UI.Change(name = "hackingA", image = "//UI/A_系统UI/07_六边形边框.png", time = 0, );
UI.Release("hackingB");
//黑入六边形

WaitForClick();
//黑入窗口关闭
SE.Play(audio = "//SE/A_系统音效/09_退出界面.ogg", volume = 0.5,);
cmd_block
{
    at 0, UI.Move(name = "hackingA", x_began = 0, y_began = 110, x_ended = 0, y_ended = 10, time = 0.5, curve = "uniform", alpha_began = 1, alpha_ended = 0, alpha_time = 0.5,);
    at 0, UI.Move(name = "hackingC", x_began = 0, y_began = 110, x_ended = 0, y_ended = 10, time = 0.5, curve = "uniform", alpha_began = 1, alpha_ended = 0, alpha_time = 0.5,);
    at 0, UI.Move(name = "hackingD", x_began = 0, y_began = 110, x_ended = 0, y_ended = 10, time = 0.5, curve = "uniform", alpha_began = 1, alpha_ended = 0, alpha_time = 0.5,);
    at 0, UI.Move(name = "code", x_began = -600, y_began = 140, x_ended = -700, y_ended = 140, time = 0.5, curve = "uniform", alpha_began = 1, alpha_ended = 0, alpha_time = 0.5,);
    at 0, Script.Text(avater = "", name = "", dialogue = "然后，如果我没猜错的话——",);
}
UI.Release("hackingA");
UI.Release("hackingC");
UI.Release("hackingD");
UI.Release("code");
//黑入窗口关闭

WaitForClick();
Picture.Change(name = "BG", image = "//背景/B_第一章/15C_旧居民楼道_安全通道前_右转拐角.png", time = 0, );
Picture.Show(name = "BG", time = 0.5,);
Script.Text(avater = "", name = "", dialogue = "我原路返回了刚才的消防通道口。",);

WaitForClick();
Script.Text(avater = "", name = "", dialogue = "在那里，凭空多出的那面墙——",);

WaitForClick();
//黑入六边形
UI.Create(name = "hackingA", image = "B_第一章/11D_修改中.png", scale = 1, x = 0, y = 110, alpha = 0,);
UI.Create(name = "hackingB", image = "B_第一章/11E_加载圈.png", scale = 1, x = 0, y = 140, alpha = 0,);
UI.Create(name = "hackingC", image = "B_第一章/11F_覆盖层.png", scale = 1, x = 0, y = 110, alpha = 0,);
UI.Create(name = "hackingD", image = "B_第一章/11G_覆盖层文字.png", scale = 1, x = 0, y = 110, alpha = 0,);
UI.Move(name = "hackingA", scale_began = 1.2, scale_ended = 1, time = 0.5, curve = "uniform", alpha_began = 0, alpha_ended = 1, alpha_time = 0.5,);
UI.KeepMove(name = "hackingB", x_began = 0, y_began = 140, x_ended = 0, y_ended = 140, angle_began = 0, angle_ended = -1200, time = 5, curve = "uniform", alpha_began = 0, alpha_ended = 1, alpha_time = 0.5,);
SE.Play(audio = "//SE/A_系统音效/18_黑入信号.ogg", volume = 0.8,);
WaitCommand(2);
cmd_block
{
    at 0, UI.Move(name = "hackingC", scale_began = 1.5, scale_ended = 1, angle_began = 0, angle_ended = 180, time = 0.5, curve = "uniform", alpha_began = 0, alpha_ended = 1, alpha_time = 0.5,);
    at 0, UI.Move(name = "hackingD", scale_began = 1.5, scale_ended = 1, time = 0.5, curve = "uniform", alpha_began = 0, alpha_ended = 1, alpha_time = 0.5,);
    at 0, Picture.Change(name = "BG", image = "//背景/B_第一章/15D_旧居民楼道_安全通道前_AR墙壁标记.png", time = 1, );
    at 0.5, Script.Text(avater = "", name = "", dialogue = "也是AR，是虚假的影像！",);
}
UI.StopMove("hackingB");
Picture.Release("Filter");
UI.Change(name = "hackingA", image = "//UI/A_系统UI/07_六边形边框.png", time = 0, );
UI.Release("hackingB");
//黑入六边形

WaitForClick();
//黑入窗口关闭
SE.Play(audio = "//SE/A_系统音效/09_退出界面.ogg", volume = 0.5,);
cmd_block
{
    at 0, UI.Move(name = "hackingA", x_began = 0, y_began = 110, x_ended = 0, y_ended = 10, time = 0.5, curve = "uniform", alpha_began = 1, alpha_ended = 0, alpha_time = 0.5,);
    at 0, UI.Move(name = "hackingC", x_began = 0, y_began = 110, x_ended = 0, y_ended = 10, time = 0.5, curve = "uniform", alpha_began = 1, alpha_ended = 0, alpha_time = 0.5,);
    at 0, UI.Move(name = "hackingD", x_began = 0, y_began = 110, x_ended = 0, y_ended = 10, time = 0.5, curve = "uniform", alpha_began = 1, alpha_ended = 0, alpha_time = 0.5,);
    at 0, Script.Text(avater = "粉/A01_竹内绚音/A01_平常.png", name = "竹内 绚音", dialogue = "这就是鬼打墙的真面目吗！",);
}
UI.Release("hackingA");
UI.Release("hackingC");
UI.Release("hackingD");
//黑入窗口关闭

WaitForClick();
cmd_block
{
    at 0, Picture.Change(name = "BG", image = "//背景/B_第一章/15E_旧居民楼道_AR墙壁标记.png", time = 0.5, );
    at 0, Script.Text(avater = "", name = "", dialogue = "我走上前去，向着这面假墙伸出了右手。不出意料的话我的手应该会直接穿过墙面。",);
}


WaitForClick();
cmd_block
{
    at 0, Picture.Position(name = "BG", x_began = 0, y_began = 0, x_ended = 80, y_ended = 0, time = 0.5, curve = "uniform",);
    at 0, Picture.Scale(name = "BG", scale_began = 1, scale_ended = 1.2, time = 0.5, curve = "uniform",);
    at 0, Script.Text(avater = "", name = "", dialogue = "然而……",);
}

WaitForClick();
Text.Clear();
SE.Stop();
SE.Play(audio = "//SE/Z_剧情音效/01H_旭町鬼屋鬼叫声.ogg", volume = 0.9,);
BGM.Stop();
Picture.Vibrate("BG", "medium"); 
Script.Text(avater = "粉/A01_竹内绚音/A14_愤怒.png", name = "竹内 绚音", dialogue = "……！",);

WaitForClick();
Script.Text(avater = "", name = "", dialogue = "在我的手穿过墙的前一瞬间，一阵妖异的声响突然从眼前传来，吓得我把手往回一缩。",);

WaitForClick();
Script.Text(avater = "粉/A01_竹内绚音/A10_认真且严肃.png", name = "竹内 绚音", dialogue = "什么啊，装神弄鬼。",);

WaitForClick();
Script.Text(avater = "", name = "", dialogue = "这是对方为了防止AR墙面被识破而制做的音频吧，只要有人敢碰墙就播放音效，如此一来就能把人吓跑。",);

WaitForClick();
Script.Text(avater = "", name = "", dialogue = "不过，既然知道了原理，那就吓不住我了。",);

WaitForClick();
cmd_block
{
    at 0, Picture.Scale(name = "BG", scale_began = 1.2, scale_ended = 1, time = 0.5, curve = "uniform",);、
    at 0, Picture.Position(name = "BG", x_began = 80, y_began = 0, x_ended = 0, y_ended = 0, time = 0.5, curve = "uniform",);
    at 0, Picture.Change(name = "BG", image = "//背景/B_第一章/15F_旧居民楼道_AR墙壁穿透.png", time = 1, );
    at 0, Script.Text(avater = "", name = "", dialogue = "我再一次伸出手，这回果然顺利穿过了墙壁。",);
}

WaitForClick();
Text.Hide();
Picture.CoveringOut(name = "BG", direction = "up", time = 0.5,);

//读档标记点
ClearScene();

//————————————————————
//———————两名黑客—————————
//————————————————————

SetUIMode(0);
UI.Create(name = "BMIO", image = "A_系统UI/01_BMI边框.png", scale = 1, alpha = 1,);
SetChapter("01", "谱线蓝移的七等星");
BGM.Stop();
CanSkip(true);
CanAuto(true);

//背景创建
Picture.Create(name = "BG", image = "//背景/B_第一章/15I_旧居民楼道_鸟居房间.png", scale = 1, x = 0, y = 0, alpha = 0,);
//背景创建

BGM.Set(audio = "//BGM/E04-虚影之弦.mp3", volume = 0.6,);
Text.Show();
Script.Text(avater = "", name = "", dialogue = "如此一来，退路就确保了。",);

WaitForClick();
Script.Text(avater = "", name = "", dialogue = "我并不打算现在离开这幢楼房，因为幕后黑手还没揪出来。",);

WaitForClick();
Script.Text(avater = "", name = "", dialogue = "Li-Fi信号源分布在走廊两侧的各个房间内，无法确认哪一间才是对方的藏身之处。",);

WaitForClick();
Script.Text(avater = "", name = "", dialogue = "但我的心里，大概已经有了答案。",);

WaitForClick();
Text.Clear();
Picture.Show(name = "BG", time = 1,);
Script.Text(avater = "", name = "", dialogue = "在三楼，我找到了松鼠箱推文中提到的那个设有鸟居的房间。",);

WaitForClick();
Script.Text(avater = "", name = "", dialogue = "这间房间是氛围最诡异的，因为它没有任何AR特效，鸟居和神龛都是真货，也不知道是从哪儿搞来的。",);

WaitForClick();
Script.Text(avater = "", name = "", dialogue = "弄这么大费周章就为了骗50000日元，我都有点不忍心揭穿对方了。",);

WaitForClick();
Script.Text(avater = "", name = "", dialogue = "但违法就是违法，不以成本论对错，无论如何我今天都是要坏他好事的。",);

WaitForClick();
Text.Clear();
Picture.CoveringOut(name = "BG", direction = "down", time = 0.5,);
Script.Text(avater = "", name = "", dialogue = "搜索一圈后，我在神龛下方找到了一条密道，好像是通往二楼的一个隐藏房间。",);

WaitForClick();
Text.Clear();
Picture.Change(name = "BG", image = "//背景/B_第一章/15J_旧居民楼道_地下暗道.png", time = 0, );
Picture.CoveringIn(name = "BG", direction = "up", time = 0.5,);
Script.Text(avater = "", name = "", dialogue = "我小心翼翼地穿过混凝土通道，脑海中不禁再一次回想起小说中看到的“旧楼藏尸”的场景。",);

WaitForClick();
Script.Text(avater = "粉/A01_竹内绚音/A12_叹气.png", name = "竹内 绚音", dialogue = "啊啊，不要再想这个了，晚上会做噩梦的……",);

WaitForClick();
SE.Play(audio = "//SE/D_脚步声/08_登场的脚步声.ogg", volume = 0.9,);
cmd_block
{
    at 0, Picture.Change(name = "BG", image = "//背景/B_第一章/15K_旧居民楼道_暗道铁门.png", time = 1, );
    at 0, Script.Text(avater = "", name = "", dialogue = "来到通道尽头的房间门前，我的脚步停顿了下来。",);
}

WaitForClick();
Script.Text(avater = "", name = "", dialogue = "因为——房内传来了人的声音。",);

WaitForClick();
Script.Text(avater = "粉/A01_竹内绚音/A11_思考时走神.png", name = "竹内 绚音", dialogue = "一个……不对，是两个人？",);

WaitForClick();
Script.Text(avater = "", name = "", dialogue = "居然是两名黑客合伙作案。",);

WaitForClick();
Script.Text(avater = "", name = "", dialogue = "他们还没注意到我已经接近他们藏身的房间了，所以是植入完病毒后就放任不管了吗？",);

WaitForClick();
cmd_block
{
    at 0, Picture.Change(name = "BG", image = "//背景/B_第一章/15K_旧居民楼道_暗道铁门2.png", time = 0.5, );
    at 0, Script.Text(avater = "", name = "黑客A", dialogue = "你说真的？昨晚你去了太阳城王子大酒店？",);
}

WaitForClick();
Script.Text(avater = "", name = "黑客B", dialogue = "是啊，我还在那儿见到数字厅的政务官大人了。",);

WaitForClick();
Script.Text(avater = "", name = "黑客A", dialogue = "数字厅不是……起草了《BMI生产技术规范条例》的那个部门吗？",);

WaitForClick();
Script.Text(avater = "", name = "黑客B", dialogue = "所以我是见到大人物会面了啊，除了政务官大人外，还有一群黑衣黑帽的人也在酒店谈生意。依我看呐，他们是卯月会的。",);

WaitForClick();
Script.Text(avater = "", name = "黑客A", dialogue = "该不会是要联合起来打压我们这些底层黑客吧？",);

WaitForClick();
Script.Text(avater = "", name = "黑客B", dialogue = "怎么可能，那些大人物是不会看上我们这些小角色的。",);

WaitForClick();
Script.Text(avater = "", name = "黑客A", dialogue = "但是他们的一举一动决定了我们这些小角色的饭碗啊。你想想，要是政府决定推广Li-Fi，那我们的钱不就挣不着了。",);

WaitForClick();
Script.Text(avater = "", name = "黑客B", dialogue = "也是，我也想知道他们都谈了些什么，会不会影响到咱们的财路。",);

WaitForClick();
cmd_block
{
    at 0, Picture.Change(name = "BG", image = "//背景/B_第一章/15K_旧居民楼道_暗道铁门.png", time = 0.5, );
    at 0, Script.Text(avater = "", name = "", dialogue = "有技术想挣钱就给我去找正经的工作啊！招摇撞骗算什么财路。",);
}

WaitForClick();
Script.Text(avater = "", name = "", dialogue = "我从口袋中掏出一支录音笔，悄悄贴到了门缝旁。",);

WaitForClick();
cmd_block
{
    at 0, Picture.Change(name = "BG", image = "//背景/B_第一章/15K_旧居民楼道_暗道铁门2.png", time = 0.5, );
    at 0, Script.Text(avater = "", name = "黑客A", dialogue = "不过那个叫卯月会的是不是也算个不错的出路？我听说他们一直在积极找业内人谈合作。",);
}

WaitForClick();
Script.Text(avater = "", name = "黑客B", dialogue = "别吧，人家是黑道背景诶，正儿八经的犯罪团伙，跟他们合作也太危险了。",);

WaitForClick();
cmd_block
{
    at 0, Picture.Change(name = "BG", image = "//背景/B_第一章/15K_旧居民楼道_暗道铁门.png", time = 0.5, );
    at 0, Script.Text(avater = "", name = "", dialogue = "就在我放置好录音笔打算把手收回来的时候——",);
}

WaitForClick();
Text.Clear();
SE.Play(audio = "//SE/I-器件音/08_鬼屋机关声.ogg", volume = 1,);
BGM.Stop();
WaitCommand(1);
Script.Text(avater = "粉/A01_竹内绚音/A05_吃惊.png", name = "竹内 绚音", dialogue = "……有机关！？",);




















