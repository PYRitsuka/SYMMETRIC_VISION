//C:\Users\10533\Desktop\SYMMETRIC_VISION\makeScript.bat


//—————————————————
//——————章节标题———————
//—————————————————
CanSkip(false);
VisionTrigger(false);
SetChapter("01", "谱线蓝移的七等星");
BGM.Stop();
WaitCommand(0.5);
SetUIMode(0);
CanSkip(true);
CanAuto(true);


//—————————————————
//——————绚音登场———————
//—————————————————

//背景创建
Picture.Create(name = "Out", image = "//背景/09B_校园一角.png", scale = 1, x = 0, y = 0, alpha = 0,);
Picture.Create(name = "BG3", image = "//背景/09B_校园一角.png", scale = 2, x = 0, y = 0, alpha = 0,);
Picture.Create(name = "BG2", image = "//背景/09B_校园一角.png", scale = 2, x = 0, y = 0, alpha = 0,);
//背景创建

//立绘创建
Tachie.Create(name = "JMC", image = "江沐橙/4110.png", scale = 1, x = -325, y = -350, alpha = 0, multiply = "#F7F1EA",); //近景，y值-600~-800
Tachie.Create(name = "BXX", image = "白筱筱/1135.png", scale = 1, x = 400, y = -300, alpha = 0, multiply = "#F7F1EA",); //近景，y值-600~-800
Tachie.Create(name = "NPCA", image = "NPC/男学生B.png", scale = 1, x = -500, y = -300, alpha = 0, multiply = "#F7F1EA",); //近景，y值-600~-800
Tachie.Create(name = "NPCB", image = "NPC/男学生C.png", scale = 1, x = 400, y = -275, alpha = 0, multiply = "#F7F1EA",); //近景，y值-600~-800
//立绘创建

BGM.Set(audio = "//BGM/F01.mp3", volume = 0.45,);
Picture.Set(name = "Out", alpha = 1, );
cmd_block
{
    at 0, Tachie.Show(name = "NPCA", alpha = 1, time = 0.5, );
    at 0, Tachie.Show(name = "NPCB", alpha = 1, time = 0.5, );
}
Text.Show();
Script.Text(avater = "", name = "？？", dialogue = "哟两位靓女，这是在搬东西？要不要我们哥俩帮忙啊？",);

WaitForClick();
cmd_block
{
    at 0, Tachie.Hide(name = "NPCA", time = 0.5, );
    at 0, Tachie.Hide(name = "NPCB", time = 0.5, );
}
cmd_block
{
    at 0, Tachie.Show(name = "JMC", alpha = 1, time = 0.5, );
    at 0, Tachie.Show(name = "BXX", alpha = 1, time = 0.5, );
}
Tachie.Multiply(name = "BXX", factor = 0.4,);
Script.Text(avater = "", name = "江沐橙", dialogue = "啊？",);

WaitForClick();
Script.Speaker(nameA = "BXX", nameB = "JMC", imageA = "白筱筱/2931.png", textname = "白筱筱", dialogue = "谢谢，不用了。",);

WaitForClick();
Script.SpeakerHide(nameA = "JMC", nameB = "BXX", time = 0.5,);
Script.SpeakerShow(nameA = "NPCA", nameB = "NPCB", time = 0.5, textname = "路人A", dialogue = "我们没别的意思，就只是想帮个忙，交个朋友。",);

WaitForClick();
//Tachie.Multiply(name = "NPCA", factor = 0.4,);
//Tachie.Multiply(name = "NPCB", factor = 2.5,);
Script.Speaker(nameA = "NPCB", nameB = "NPCA", textname = "路人B", dialogue = "是啊是啊，正好认识认识嘛，都是住附近的。",);
//Script.Text(avater = "", name = "路人B", dialogue = "是啊是啊，正好认识认识嘛，都是住附近的。",);

WaitForClick();
Script.SpeakerHide(nameA = "NPCA", nameB = "NPCB", time = 0.5,);
Script.SpeakerShow(nameA = "BXX", imageA = "白筱筱/2934.png", nameB = "JMC", time = 0.5, textname = "白筱筱", dialogue = "不用麻烦了，我们就走几步路就到了，谢谢你们的好意。",);

WaitForClick();
Script.SpeakerHide(nameA = "JMC", nameB = "BXX", time = 0.5,);
Script.SpeakerShow(nameA = "NPCA", nameB = "NPCB", time = 0.5, textname = "路人A", dialogue = "欸你们住哪栋啊？是不是还要搬上楼，放心交给我们吧。",);

WaitForClick();
Script.SpeakerHide(nameA = "NPCB", nameB = "NPCA", time = 0.5,);
Script.SpeakerShow(nameA = "JMC", imageA = "江沐橙/4326.png", nameB = "BXX", time = 0.5, textname = "江沐橙", dialogue = "真的不用，我们走吧筱筱。",);

WaitForClick();
Text.Clear();
cmd_block
{
    at 0, Tachie.Position(name = "JMC", x_began = -325, y_began = -350, x_ended = 475, y_ended = -350, time = 1, curve = "ease_out",);
    at 0, Tachie.Position(name = "BXX", x_began = 400, y_began = -300, x_ended = 1200, y_ended = -300, time = 1, curve = "ease_out",);
    at 0, Tachie.Hide(name = "BXX", time = 0.5, );
    at 0, Tachie.Position(name = "NPCB", x_began = -1200, y_began = -275, x_ended = -400, y_ended = -275, time = 1, curve = "ease_out",);
    at 0.5, Tachie.Show(name = "NPCB", time = 0.5, );
}
Tachie.Multiply(name = "JMC", factor = 0.4,);
Script.Text(avater = "", name = "路人B", dialogue = "靓女，看你们两个提这么大箱子多辛苦，让我们来帮帮忙嘛～",);

WaitForClick();
Script.Speaker(nameA = "JMC", imageA = "江沐橙/4143.png", nameB = "NPCB", textname = "江沐橙", dialogue = "说了不用了，能不能别纠缠啦！",);

WaitForClick();
Text.Clear();
SE.Stop();
SE.Play(audio = "//SE/C_布料声/21_布料撞击然后摩擦.ogg", volume = 1,);
Tachie.Multiply(name = "NPCB", factor = 2.5,);
Tachie.Position(name = "NPCB", x_began = -400, y_began = -275, x_ended = 0, y_ended = -275, time = 0.5, curve = "uniform",);
Tachie.Change(name = "JMC", image = "江沐橙/4C75.png", time = 0, );
Tachie.Vibrate("JMC", "medium");
Script.Text(avater = "", name = "江沐橙", dialogue = "诶诶别上手！小心我喊人了！",);

WaitForClick();
Text.Hide();
cmd_block
{
    at 0, Tachie.Hide(name = "NPCB", time = 0.5, );
    at 0, Tachie.Hide(name = "JMC", time = 0.5, );
}
SE.Stop();
SE.Play(audio = "//SE/D_脚步声/08_登场的脚步声.ogg", volume = 1,);
WaitCommand(1);
Text.Show();
Script.Text(avater = "", name = "我", dialogue = "怎么回事？好热闹啊。",);

WaitForClick();
Text.Hide();
Tachie.Set(name = "JMC", image = "江沐橙/4C4B.png", x = -325, y = -350,);
Tachie.Set(name = "BXX", image = "白筱筱/2133.png", x = 400, y = -300,);
Tachie.Set(name = "NPCB", x = 400, y = -275,);
cmd_block
{
    at 0, Tachie.Show(name = "NPCA", alpha = 1, time = 0.5, );
    at 0, Tachie.Show(name = "NPCB", alpha = 1, time = 0.5, );
}
WaitCommand(0.5);
cmd_block
{
    at 0, Tachie.Hide(name = "NPCA", time = 0.5, );
    at 0, Tachie.Hide(name = "NPCB", time = 0.5, );
}
WaitCommand(0.5);
Tachie.Multiply(name = "BXX", factor = 2.5,);
cmd_block
{
    at 0, Tachie.Show(name = "JMC", alpha = 1, time = 0.5, );
    at 0, Tachie.Show(name = "BXX", alpha = 1, time = 0.5, );
}
Text.Show();
Script.Text(avater = "", name = "", dialogue = "我打量了一下现场这几人。",);

WaitForClick();
Text.Clear();
cmd_block
{
    at 0, Tachie.Hide(name = "JMC", time = 0.5, );
    at 0, Tachie.Hide(name = "BXX", time = 0.5, );
}
Picture.KeepMove(name = "BG2", x_began = 800, y_began = 0, x_ended = 0, y_ended = 0, scale_began = 2, scale_ended = 2, angle_began = 0, angle_ended = 0, time = 60, curve = "uniform", alpha_began = 0, alpha_ended = 1, alpha_time = 1,);
Tachie.Set(name = "JMC", scale = 1.25, x = -325, y = -500,);
Tachie.Set(name = "BXX", scale = 1.25, x = 400, y = -500,);
cmd_block
{
    at 0, Tachie.KeepMove(name = "JMC", x_began = -375, y_began = -500, x_ended = -325, y_ended = -500, scale_began = 1.25, scale_ended = 1.25, angle_began = 0, angle_ended = 0, time = 30, curve = "uniform",);
    at 0, Tachie.Show(name = "JMC", alpha = 1, time = 0.5, );
}
Script.Text(avater = "", name = "", dialogue = "居然真是她们，我刚刚听声音就觉得耳熟。",);

WaitForClick();
Text.Clear();
Tachie.Hide(name = "JMC", time = 0.5, );
cmd_block
{
    at 0, Picture.Hide(name = "BG2", time = 1, );
    at 0, Picture.KeepMove(name = "BG3", x_began = -800, y_began = 0, x_ended = 0, y_ended = 0, scale_began = 2, scale_ended = 2, angle_began = 0, angle_ended = 0, time = 60, curve = "uniform", alpha_began = 1, alpha_ended = 1, alpha_time = 0,);
}
Picture.StopMove("BG2");
Picture.Release("BG2");
cmd_block
{
    at 0, Tachie.KeepMove(name = "BXX", x_began = 450, y_began = -500, x_ended = 400, y_ended = -500, scale_began = 1.25, scale_ended = 1.25, angle_began = 0, angle_ended = 0, time = 30, curve = "uniform",);
    at 0, Tachie.Show(name = "BXX", alpha = 1, time = 0.5, );
}
Tachie.StopMove("JMC");
Script.Text(avater = "", name = "", dialogue = "从刚刚听到的只言片语，和几个人的神态，我大概了解了状况。",);

WaitForClick();
Tachie.Hide(name = "BXX", time = 0.5, );
Tachie.StopMove("BXX");
Picture.Hide(name = "BG3", time = 1);
Picture.StopMove("BG3");
Picture.Release("BG3");
Tachie.Set(name = "JMC", scale = 1, x = -325, y = -350,);
Tachie.Set(name = "BXX", scale = 1, x = 400, y = -300,);
cmd_block
{
    at 0, Tachie.Show(name = "JMC", alpha = 1, time = 0.5, );
    at 0, Tachie.Show(name = "BXX", alpha = 1, time = 0.5, );
}

WaitForClick();
Text.Clear();
cmd_block
{
    at 0, Tachie.Hide(name = "JMC", time = 0.5, );
    at 0, Tachie.Hide(name = "BXX", time = 0.5, );
}
Tachie.Set(name = "BXX", image = "白筱筱/2213.png", scale = 1.25, x = 0, y = -500,);
Tachie.Show(name = "BXX", time = 0.5, );
Script.Text(avater = "", name = "", dialogue = "白筱筱和我使了一下眼神。",);

WaitForClick();
Script.Text(avater = "", name = "我", dialogue = "搭讪？",);

WaitForClick();
Script.Expression(name = "BXX", image = "白筱筱/2212.png", textname = "白筱筱", dialogue = "嗯。",);