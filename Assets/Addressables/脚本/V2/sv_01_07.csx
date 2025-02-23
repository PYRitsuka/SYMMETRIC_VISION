//C:\Users\10533\Desktop\SYMMETRIC_VISION\makeScript.bat


//————————————————————
//——————开场字幕阶段————————
//————————————————————

StoryBlock(7, true);
CanSkip(false);
VisionTrigger(false);
SetChapter("01", "谱线蓝移的七等星");
BGM.Stop();
SetUIMode(5);
CanSkip(false);
CanAuto(true);

Text.SetTextSpeed(1000);

Picture.CreateMovie(name = "p1", movie = "B_第一章_视频/01A_开场字幕.mp4", alpha = 1, Loop = false,);
Picture.Create(name = "p2", image = "B_第一章/01A_开场字幕.png", alpha = 1,);
Script.Text(avater = "", name = "君岛 孝", dialogue = "粒子在秩序的支配下规律运动——守恒。",);
BGM.Set(audio = "//BGM/开场台词01.mp3", volume = 1, loop = false,);

WaitForClick();
Picture.Release("p2");
Picture.CreateMovie(name = "p1", movie = "B_第一章_视频/01B_开场字幕.mp4", alpha = 1, Loop = false,);
Picture.Create(name = "p2", image = "B_第一章/01B_开场字幕.png", alpha = 1,);
Script.Text(avater = "", name = "君岛 孝", dialogue = "自然在时间的演化中趋于无序——破缺。",);
BGM.Set(audio = "//BGM/开场台词02.mp3", volume = 1, loop = false,);

WaitForClick();
Picture.Release("p1");
Picture.CreateMovie(name = "p2", movie = "B_第一章_视频/01C_开场字幕.mp4", alpha = 1, Loop = false,);
Picture.Create(name = "p2", image = "B_第一章/01C_开场字幕.png", alpha = 1,);
Script.Text(avater = "", name = "君岛 孝", dialogue = "傲慢的学者，总妄图究明宇宙的全貌。",);
BGM.Set(audio = "//BGM/开场台词03.mp3", volume = 1, loop = false,);

WaitForClick();
Picture.Release("p2");
Picture.CreateMovie(name = "p1", movie = "B_第一章_视频/01D_开场字幕.mp4", alpha = 1, Loop = false,);
Picture.Create(name = "p2", image = "B_第一章/01D_开场字幕.png", alpha = 1,);
Script.Text(avater = "", name = "君岛 孝", dialogue = "殊不知生命的有限智慧，才是造物主对既定命运的反抗。",);
BGM.Set(audio = "//BGM/开场台词04.mp3", volume = 1, loop = false,);

WaitForClick();
Picture.Release("p1");
Picture.CreateMovie(name = "p2", movie = "B_第一章_视频/01E_开场字幕.mp4", alpha = 1, Loop = false,);
Picture.Create(name = "p2", image = "B_第一章/01E_开场字幕.png", alpha = 1,);
Script.Text(avater = "", name = "君岛 孝", dialogue = "我们将视线跨越光年，",);
BGM.Set(audio = "//BGM/开场台词05.mp3", volume = 1, loop = false,);

WaitForClick();
Picture.Release("p2");
Picture.CreateMovie(name = "p1", movie = "B_第一章_视频/01F_开场字幕.mp4", alpha = 1, Loop = false,);
Picture.Create(name = "p2", image = "B_第一章/01F_开场字幕.png", alpha = 1,);
Script.Text(avater = "", name = "君岛 孝", dialogue = "只为在世界尽头，找到证明自己曾求索过的镜像。",);
BGM.Set(audio = "//BGM/开场台词06.mp3", volume = 1, loop = false,);

WaitForClick();
Picture.Release("p1");
Picture.CreateMovie(name = "p2", movie = "B_第一章_视频/01G_开场字幕.mp4", alpha = 1, Loop = false,);
Picture.Create(name = "p2", image = "B_第一章/01G_开场字幕.png", alpha = 1,);
Script.Text(avater = "", name = "君岛 孝", dialogue = "这可以说是，反抗者们为人类献上的，自由的礼赞。",);
BGM.Set(audio = "//BGM/开场台词07.mp3", volume = 1, loop = false,);

WaitForClick();
Picture.Release("p2");
Picture.CreateMovie(name = "p1", movie = "B_第一章_视频/01H_开场字幕.mp4", alpha = 1, Loop = false,);
WaitCommand(0.5);

CanSkip(true); 
WaitCommand(2);

//读档标记点
ClearScene();

//————————————————————
//——————未来道具研究所———————
//————————————————————

SetUIMode(5);
SetChapter("01", "谱线蓝移的七等星");
BGM.Stop();
CanSkip(true);
CanAuto(true);

//背景创建
Picture.Create(name = "Room", image = "//背景/B_第一章/13A_未来道具研究所.png", scale = 1, x = 0, y = 0, alpha = 0,);
//背景创建

//立绘创建
Tachie.Create(name = "Suzuha", image = "B01_阿万音铃羽/A01_放松.png", scale = 1.25, x = 0, y = -650, alpha = 0, multiply = "#F7F5EC",); //近景，y值-600~-800
Tachie.Create(name = "Ruka", image = "C07_漆原琉华/A02_微笑.png", scale = 1.25, x = 0, y = -650, alpha = 0, multiply = "#F7F5EC",); //近景，y值-600~-800
//立绘创建

Text.Show();
Script.Text(avater = "", name = "", dialogue = "2035年9月7日（星期五）晚，，<link=015><color=#ff6000>未来道具研究所</color></link>。",);

WaitForClick();
Text.Hide();
SE.Play(audio = "//SE/B_开关门/07_钥匙开铁门.ogg", volume = 1,);
WaitCommand(1);
BGM.Set(audio = "//BGM/D06-桥田至.mp3", volume = 0.6,);
//三段拉镜特写
Picture.Create(name = "MoveA", image = "//背景/B_第一章/13A_未来道具研究所.png", scale = 2, x = 0, y = 0, alpha = 0,);
Picture.Create(name = "MoveB", image = "//背景/B_第一章/13A_未来道具研究所.png", scale = 2, x = 0, y = 0, alpha = 0,);
Picture.Create(name = "MoveC", image = "//背景/B_第一章/13A_未来道具研究所.png", scale = 1.25, x = 0, y = 0, alpha = 0,);
Tachie.Create(name = "SuzuhaA", image = "B01_阿万音铃羽/A01_放松.png", scale = 1, x = 0, y = 0, alpha = 0, multiply = "#F7F5EC",);
Tachie.Create(name = "SuzuhaB", image = "B01_阿万音铃羽/A01_放松.png", scale = 1, x = 0, y = 0, alpha = 0, multiply = "#F7F5EC",);
Tachie.Create(name = "SuzuhaC", image = "B01_阿万音铃羽/A01_放松.png", scale = 1, x = 0, y = 0, alpha = 0, multiply = "#F7F5EC",);
cmd_block
{
    at 0, Picture.Move(name = "MoveA", x_began = 600, y_began = 250, x_ended = 720, y_ended = 250, scale_began = 2, scale_ended = 2, time = 3.5, curve = "uniform",);
    at 0, Picture.Alpha(name = "MoveA", alpha_began = 0, alpha_ended = 1, time = 0.5,);
    at 0, Tachie.Move(name = "SuzuhaA", x_began = -325, y_began = 100, x_ended = -375, y_ended = 100, scale_began = 1.6, scale_ended = 1.6, time = 3.5, curve = "uniform",);
    at 0, Tachie.Show(name = "SuzuhaA", time = 0.5,);
    at 3, Tachie.Hide(name = "SuzuhaA", time = 0.5,);
    at 3, Picture.Move(name = "MoveB", x_began = -600, y_began = -250, x_ended = -720, y_ended = -250, scale_began = 2, scale_ended = 2, time = 3.5, curve = "uniform",);
    at 3, Picture.Alpha(name = "MoveB", alpha_began = 0, alpha_ended = 1, time = 0.5,);
    at 3, Tachie.Move(name = "SuzuhaB", x_began = 325, y_began = -400, x_ended = 375, y_ended = -400, scale_began = 1.6, scale_ended = 1.6, time = 3.5, curve = "uniform",);
    at 3, Tachie.Show(name = "SuzuhaB", time = 0.5,);
    at 6, Tachie.Hide(name = "SuzuhaB", time = 0.5,);
    at 6, Picture.Move(name = "MoveC", x_began = 0, y_began = -125, x_ended = 0, y_ended = 0, scale_began = 1.25, scale_ended = 1.25, time = 1.5, curve = "uniform",);
    at 6, Picture.Alpha(name = "MoveC", alpha_began = 0, alpha_ended = 1, time = 0.5,);
    at 6, Tachie.Move(name = "SuzuhaC", x_began = 0, y_began = -200, x_ended = 0, y_ended = -780, scale_began = 1.5, scale_ended = 1.5, time = 1.5, curve = "ease_out",);
    at 6, Tachie.Show(name = "SuzuhaC", time = 0.5,);
}
Picture.Release("MoveA");
Picture.Release("MoveB");
Tachie.Release("SuzuhaA");
Tachie.Release("SuzuhaB");
//三段拉镜特写
Text.Show();
Script.Text(avater = "", name = "", dialogue = "走入房间内的，是阔别秋叶原已经一年之久的铃羽。",);

WaitForClick();
Picture.Alpha(name = "Room", alpha_began = 0, alpha_ended = 1, time = 0,);
cmd_block
{
    at 0, Picture.Alpha(name = "MoveC", alpha_began = 1, alpha_ended = 0, time = 0.5,);
    at 0, Tachie.Hide(name = "SuzuhaC", time = 0.5,);
}
Picture.Release("MoveC");
Tachie.Release("SuzuhaC");
Script.CharacterShow(name = "Suzuha", image = "B01_阿万音铃羽/A12_愉悦.png", time = 0.5, textname = "阿万音 铃羽", dialogue = "晚上好chi～～su～！",);

WaitForClick();
Script.Expression(name = "Suzuha", image = "B01_阿万音铃羽/A31_提议.png", textname = "阿万音 铃羽", dialogue = "咦？好像没人在呢。",);

WaitForClick();
Script.Expression(name = "Suzuha", image = "B01_阿万音铃羽/A08_傲娇.png", textname = "阿万音 铃羽", dialogue = "呜哇，桌上都落灰了，这是多久没来过人了啊。",);

WaitForClick();
Text.Hide();
SE.Play(audio = "//SE/C_布料声/03_蹲下身.ogg", volume = 0.8,);
cmd_block
{
    at 0, Tachie.Hide(name = "Suzuha", time = 0.7,);
    at 0, Tachie.Position(name = "Suzuha", y_began = -650, y_ended = -750, time = 0.7, curve = "uniform",);
}
WaitCommand(0.2);
Picture.CoveringOut(name = "Room", direction = "right", time = 0.5,);
Picture.Change(name = "Room", image = "//背景/B_第一章/13B_未来道具研究所_货架.png", time = 0, );
Picture.CoveringIn(name = "Room", direction = "left", time = 0.5,);
SE.Play(audio = "//SE/I-器件音/06_翻箱倒柜.ogg", volume = 1,);
WaitCommand(5);
SE.Stop();
//图片入场（从上方）
Picture.Create(name = "pic1", image = "//图片/B_第一章/21_电波劫持者.png", scale = 0.5, x = 0, y = 210, alpha = 0,);
Picture.Move(name = "pic1", y_began = 210, y_ended = 110, time = 0.5, curve = "uniform", alpha_began = 0, alpha_ended = 1, alpha_time = 0.7,);
//图片入场（从上方）
Text.Show();
Script.Text(avater = "灰/B01_阿万音铃羽/A04_笑眯眯.png", name = "阿万音 铃羽", dialogue = "其他的未来道具都带走了，就剩电波劫持者还丢在这里，所以才让我回来取一趟吗？",);

WaitForClick();
Script.Text(avater = "灰/B01_阿万音铃羽/A34_不满.png", name = "阿万音 铃羽", dialogue = "这么危险的东西被扔在了Lab没人管他都不知道，也太不负责了吧。",);

WaitForClick();
Text.Clear();
Tachie.Set(name = "Suzuha", y= -650,);
//图片离场（向下方）
Picture.Move(name = "pic1", y_began = 110, y_ended = 10, time = 0.5, curve = "uniform", alpha_began = 1, alpha_ended = 0, alpha_time = 0.5,);
Picture.Release("pic1");
//图片离场（向下方）
Script.CharacterShow(name = "Suzuha", image = "B01_阿万音铃羽/A19_吃瘪.png", textname = "阿万音 铃羽", dialogue = "真是的，我不在的这段时间都发生了什么呀……",);

WaitForClick();
SE.Play(audio = "//SE/C_布料声/10_倒地.ogg", volume = 1,);
Script.Expression(name = "Suzuha", image = "B01_阿万音铃羽/A01_放松.png", textname = "阿万音 铃羽", dialogue = "嗯？",);

WaitForClick();
Text.Clear();
Tachie.Hide(name = "Suzuha", time = 0.5,);
SE.Play(audio = "//SE/C_布料声/01_腾空而起.ogg", volume = 0.9,);
//图片入场（从上方）
Picture.Create(name = "pic1", image = "//图片/B_第一章/22_世界线变动率测量仪.png", scale = 0.5, x = 0, y = 210, alpha = 0,);
Picture.Move(name = "pic1", y_began = 210, y_ended = 110, time = 0.5, curve = "uniform", alpha_began = 0, alpha_ended = 1, alpha_time = 0.7,);
//图片入场（从上方）
Script.Text(avater = "灰/B01_阿万音铃羽/A31_提议.png", name = "阿万音 铃羽", dialogue = "世界线变动率测量仪？为什么会放在这个地方？",);

WaitForClick();
Script.Text(avater = "灰/B01_阿万音铃羽/A15_生气.png", name = "阿万音 铃羽", dialogue = "<size=38>等等，1.048590%！？</size>",);

WaitForClick();
Text.Hide();
SE.Play(audio = "//SE/C_布料声/02_腾空落地.ogg", volume = 1,);
//图片离场（向下方）
Picture.Move(name = "pic1", y_began = 110, y_ended = 10, time = 0.5, curve = "uniform", alpha_began = 1, alpha_ended = 0, alpha_time = 0.5,);
Picture.Release("pic1");
//图片离场（向下方）
Picture.Change(name = "Room", image = "//背景/B_第一章/13A_未来道具研究所.png", time = 0.5, );
//电话呼叫
SE.Play(audio = "//SE/A_系统音效/03_通话启动.ogg", volume = 0.5,);
UI.Create(name = "call", image = "B_第一章/07_通话呼叫.png", scale = 1, x = 0, y = 110, alpha = 0,);
UI.ExpandIn(name = "call", direction = "horizontal", time = 0.5,);
WaitCommand(1);
UI.ExpandOut(name = "call", direction = "horizontal", time = 0.5,);
UI.Release("call");
Tachie.SetCall(name = "Ruka", enabled = true);
//立绘同屏入场（排开）
Tachie.Set(name = "Ruka", x = 350,);
Tachie.Set(name = "Suzuha", x = -350,);
cmd_block
{
    //    at 0, Tachie.Show(name = "Ruka", time = 0.5,);
    //    at 0, Script.CharacterShow(name = "Suzuha", image = "B01_阿万音铃羽/A13_生气.png", textname = "阿万音 铃羽", dialogue = "绹姐！",);
    at 0, Tachie.Show(name = "Ruka", time = 0.5,);
    at 0, Tachie.Show(name = "Suzuha", image = "B01_阿万音铃羽/A13_生气.png", time = 0.5,);
    at 0.5, Text.Show();
    at 1, Script.Text(avater = "", name = "阿万音 铃羽", dialogue = "琉华哥！",);
}
//立绘同屏入场（排开）

WaitForClick();
//立绘同屏离场（向左侧）
cmd_block
{
    at 0, Tachie.Alpha(name = "Suzuha", alpha_began = 1, alpha_ended = 0, time = 0.5,);
    at 0, Tachie.Position(name = "Suzuha", x_began = -350, x_ended = -700, time = 0.5, curve = "uniform",);
    at 0, Tachie.Position(name = "Ruka", x_began = 350, x_ended = 0, time = 0.5, curve = "uniform",);
    at 0, Script.Text(avater = "", name = "漆原 琉华", dialogue = "铃羽？怎么了？",);
}
//立绘同屏入场（向左侧）

WaitForClick();
Tachie.Set(name = "Suzuha", x = 0,);
Script.Character(nameA = "Ruka", nameB = "Suzuha", imageB = "B01_阿万音铃羽/A14_生气.png", textname = "阿万音 铃羽", dialogue = "世界线变动率！你能看到吗？我把视野给你共享过去了，这个变动率是什么情况？",);

WaitForClick();
Script.Character(nameA = "Suzuha", nameB = "Ruka", imageB = "C07_漆原琉华/A03_微笑.png", textname = "漆原 琉华", dialogue = "哦，你说那个啊。",);

WaitForClick();
Script.Character(nameA = "Ruka", nameB = "Suzuha", imageB = "B01_阿万音铃羽/A32_讨论.png", textname = "阿万音 铃羽", dialogue = "啊？",);

WaitForClick();
Script.Character(nameA = "Suzuha", nameB = "Ruka", imageB = "KEEP", textname = "漆原 琉华", dialogue = "原本是1.048596%对吧？那个末位数字最近半年已经变动很多次了。",);

WaitForClick();
Script.Text(avater = "", name = "漆原 琉华", dialogue = "不过每次都只是加1减1这种微小的变化，大概只是故障吧。",);

WaitForClick();
Script.Character(nameA = "Ruka", nameB = "Suzuha", imageB = "B01_阿万音铃羽/A13_生气.png", textname = "阿万音 铃羽", dialogue = "故障什么的也太草率了吧！这台辉光管的数字可是从我四岁起就一次也没有变过耶。",);

WaitForClick();
Script.Text(avater = "", name = "阿万音 铃羽", dialogue = "不是说除了冈部叔叔以外，没有人能观测到数值变动吗？",);

WaitForClick();
Script.Character(nameA = "Suzuha", nameB = "Ruka", imageB = "C07_漆原琉华/A05_闭眼笑.png", textname = "漆原 琉华", dialogue = "问题不大啦～凶真哥说世界线偶尔发生小幅度晃动是正常现象，不会脱离命运石之门的收束范围，没准哪天数字又跳回去了呢。",);

WaitForClick();
Script.Expression(name = "Ruka", image = "C07_漆原琉华/A01_平常.png", textname = "漆原 琉华", dialogue = "况且这台世界线变动率测量仪本来就是是<link=016><color=#ff6000>仿制品</color></link>，出现误差也可能是精度太差导致的。",);

WaitForClick();
Script.Text(avater = "", name = "漆原 琉华", dialogue = "两年前的那次世界线变动，它不就没能探测出来吗？",);

WaitForClick();
Script.Character(nameA = "Ruka", nameB = "Suzuha", imageB = "B01_阿万音铃羽/A34_不满.png", textname = "阿万音 铃羽", dialogue = "唔……总觉得你们在瞒着我什么。",);

WaitForClick();
Script.Character(nameA = "Suzuha", nameB = "Ruka", imageB = "C07_漆原琉华/A05_闭眼笑.png", textname = "漆原 琉华", dialogue = "哈哈，真要说被瞒着也是我被瞒着了吧。凶真哥他们这两年在美国搞什么研究，我完全不清楚。",);

WaitForClick();
Script.Character(nameA = "Ruka", nameB = "Suzuha", imageB = "B01_阿万音铃羽/A10_愉悦.png", textname = "阿万音 铃羽", dialogue = "研究所看上去也很久没来人了。琉华哥你们都不在秋叶原吗？",);

WaitForClick();
Script.Character(nameA = "Suzuha", nameB = "Ruka", imageB = "C07_漆原琉华/A02_微笑.png", textname = "漆原 琉华", dialogue = "嗯，章一伯伯生病了，我要留在青森照顾他。",);

WaitForClick();
Script.Character(nameA = "Ruka", nameB = "Suzuha", imageB = "B01_阿万音铃羽/A16_忧伤.png", textname = "阿万音 铃羽", dialogue = "那家伙真不负责啊，自己的老丈人出狱后他不接走照顾，反倒丢给了你和真由理姐。",);

WaitForClick();
Script.Character(nameA = "Suzuha", nameB = "Ruka", imageB = "C07_漆原琉华/A03_微笑.png", textname = "漆原 琉华", dialogue = "正好，铃羽你回东京了对吧？有空帮我跑一趟练马吗？",);

WaitForClick();
Script.Character(nameA = "Ruka", nameB = "Suzuha", imageB = "B01_阿万音铃羽/A33_异议.png", textname = "阿万音 铃羽", dialogue = "练马？",);

WaitForClick();
Tachie.Switch(name_A = "Suzuha", time_A = 0.2, name_B = "Ruka", time_B = 0.2, alpha_B = 1,);
//图片入场（立绘让位）
cmd_block
{
    at 0, Picture.Create(name = "pic1", image = "//图片/B_第一章/23_磁单极子.png", scale = 0.5, x = 1000, y = 0, alpha = 0,);
    at 0, Picture.Move(name = "pic1", x_began = 1000, x_ended = 400, time = 0.7, curve = "ease_in", alpha_began = 0, alpha_ended = 1, alpha_time = 0.7,);
    at 0, Tachie.Position(name = "Ruka", x_began = 0, x_ended = -400, time = 0.7, curve = "ease_in");
    at 0, Script.Expression(name = "Ruka", image = "C07_漆原琉华/A01_平常.png", textname = "漆原 琉华", dialogue = "两小时前，EGI系统监测到了疑似似<link=017><color=#ff6000>磁单极子</color></link>的反应，地点在练马的高野台。",);
}
//图片入场（立绘让位）

WaitForClick();
Tachie.Set(name = "Suzuha", x = -400,);
Script.Character(nameA = "Ruka", nameB = "Suzuha", imageB = "B01_阿万音铃羽/A14_生气.png", textname = "阿万音 铃羽", dialogue = "你是说，磁单极子出现在了东京？",);

WaitForClick();
Tachie.Switch(name_A = "Suzuha", time_A = 0.2, name_B = "Ruka", time_B = 0.2, alpha_B = 1,);
//图片离场（立绘归位）
cmd_block
{
    at 0, Picture.Move(name = "pic1", x_began = 400, x_ended = 1000, time = 0.7, curve = "uniform", alpha_began = 1, alpha_ended = 0, alpha_time = 0.7,);
    at 0, Tachie.Position(name = "Ruka", x_began = -400, x_ended = 0, time = 0.7, curve = "uniform");
    at 0, Script.Expression(name = "Ruka", image = "C07_漆原琉华/A09_生气.png", textname = "漆原 琉华", dialogue = "是的，我查了一下，高野台那一带基本都是住宅区，要是被当地居民捡到磁单极子会很麻烦。", );
}
Picture.Release("pic1");
//图片离场（立绘归位）

WaitForClick();
Script.Expression(name = "Ruka", image = "C07_漆原琉华/A01_平常.png", textname = "漆原 琉华", dialogue = "所以要拜托你尽快前去回收一下，骑GRAPER去一趟很快的。",);

WaitForClick();
Tachie.Set(name = "Suzuha", x = 0,);
Script.Character(nameA = "Ruka", nameB = "Suzuha", imageB = "B01_阿万音铃羽/A03_放松.png", textname = "阿万音 铃羽", dialogue = "Okey Dokey，任务目标是回收掉落在练马区的磁单极子，我马上就出发。",);

WaitForClick();
Text.Hide();
Tachie.Hide("Suzuha");
Picture.Alpha(name = "Room", alpha_began = 1, alpha_ended = 0, time = 1,);
SE.Play(audio = "//SE/B_开关门/08_关门并锁门.ogg", volume = 1,);
WaitCommand(2);
SE.Stop();
SE.Play(audio = "//SE/I-器件音/07_金属撞击声.ogg", volume = 1,);
BGM.Volume(volume_began = 0.6, volume_ended = 0, time = 1,);
Text.Show();
Script.Text(avater = "", name = "阿万音 铃羽", dialogue = "谁呀？怎么在这么窄的楼道停了台机器人？",);

WaitForClick();
Script.Text(avater = "", name = "漆原 琉华", dialogue = "没事吧？",);

WaitForClick();
Script.Text(avater = "", name = "阿万音 铃羽", dialogue = "咦，这个商标……",);

WaitForClick();
Script.Text(avater = "", name = "阿万音 铃羽", dialogue = "喂，琉华哥。",);

WaitForClick();
Script.Text(avater = "", name = "漆原 琉华", dialogue = "嗯？",);

WaitForClick();
Script.Text(avater = "", name = "阿万音 铃羽", dialogue = "最近在东京突然流行起来的VIEW APP所使用的街道服务机器人……",);

WaitForClick();
Script.Text(avater = "", name = "阿万音 铃羽", dialogue = "它们的生产公司……",);

WaitForClick();
Script.Text(avater = "", name = "阿万音 铃羽", dialogue = "该不会是那个———<link=019><color=#ff6000>EXOSEKLETON</color></link>吧？",);

WaitForClick();
Text.Hide();
CanSkip(false);
StoryArrow(7, true);
WaitCommand(1);
JumpToScript("脚本/V2/sv_01_08.json");

