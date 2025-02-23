//C:\Users\10533\Desktop\SYMMETRIC_VISION\makeScript.bat


//————————————————————
//———————章节标题—————————
//————————————————————

StoryBlock(6, true);
CanSkip(false);
VisionTrigger(false);
SetChapter("01", "边界徘徊的七等星");
BGM.Stop();
SetUIMode(5);
CanSkip(true);
CanAuto(true);

//————————————————————
//———————心弥登场—————————
//————————————————————

//背景创建
Picture.Create(name = "Room", image = "//背景/B_第一章/02B_鸦巢公寓物业室_夜晚.png", scale = 1, x = 0, y = 0, alpha = 0,);
Picture.Create(name = "Move", image = "//背景/B_第一章/02B_鸦巢公寓物业室_夜晚.png", scale = 1, x = 0, y = 0, alpha = 0,);
//背景创建

//立绘创建
Tachie.Create(name = "Kokomi", image = "B02_五十岚心弥/A10_落寞.png", scale = 1.25, x = 0, y = -675, alpha = 0, multiply = "#F0F0DE",); //近景，y值-600~-800
Tachie.Create(name = "Yukie", image = "B04_吉田雪绘/B01_平常.png", scale = 1, x = 0, y = -450, alpha = 0, multiply = "#F0F0DE",); //中景，y值-400~-525
//立绘创建

Text.Show();
Script.Text(dialogue = "2035年9月8日（星期六）凌晨，0时22分。", speed = 30,);

WaitForClick();
Text.Hide();
SetUIMode(4);
Picture.Alpha(name = "Room", alpha_began = 0, alpha_ended = 1, time = 1,);
//BMI开启
SetUIMode(2);
UI.Create(name = "BMIO", image = "A_系统UI/01_BMI边框.png", scale = 1.3, alpha = 1,);
SE.Play(audio = "//SE/A_系统音效/01_回路启动.ogg", volume = 0.4,);
UI.Scale(name = "BMIO", scale_began = 1.3, scale_ended = 1, time = 0.5, curve = "uniform",);
//BMI开启
Text.Show();
Script.Text(avater = "", name = "", dialogue = "我附在草加警官的BMI上，见到了来访的SEGMA公司社员。",);

WaitForClick();
Text.Clear();
//五十岚心弥登场特写
Picture.KeepMove(name = "Move", x_began = -150, y_began = -135, x_ended = 150, y_ended = -135, scale_began = 1.25, scale_ended = 1.25, angle_began = 0, angle_ended = 0, time = 120, curve = "uniform", alpha_began = 0, alpha_ended = 1, alpha_time = 1,);
cmd_block
{
    at 0, Tachie.Alpha(name = "Kokomi", alpha_began = 0, alpha_ended = 1, time = 1,);
    at 0, Tachie.KeepMove(name = "Kokomi", x_began = -220, y_began = -875, x_ended = -420, y_ended = -875, scale_began = 1.5, scale_ended = 1.5, angle_began = 0, angle_ended = 0, time = 120, curve = "uniform",);
}
Script.Text(avater = "蓝/A02_佐野阳向/C18_受击.png", name = "佐野 阳向", dialogue = "<size=42>！？</size>",);
SE.Play(audio = "//SE/G_氛围音/02_心跳一次.ogg", volume = 0.8,);

WaitForClick();
BGM.Set(audio = "//BGM/K01-时之雨.mp3", volume = 0.7,);
Tachie.Multiply(name = "Kokomi", factor = 0.4,);
Script.Text(avater = "", name = "", dialogue = "不知为何，见到这名女子的瞬间，我的内心猛地一颤。",);

WaitForClick();
Script.Text(avater = "", name = "", dialogue = "强烈的熟悉感在脑海中涌现，仿佛要冲破记忆的界限让我回想起什么。",);

WaitForClick();
//闪回转场
Text.Hide();
CanSkip(false);
Camera.SparkingWhite(0.3);
WaitCommand(0.3);
UI.Create(name = "black", image = "A_系统UI/02_黑屏.png", scale = 1, x = 0, y = 0, angle = 0, alpha = 1,);
Picture.StopMove("Move");
Tachie.StopMove("Kokomi");
Picture.Alpha(name = "Move", alpha_began = 1, alpha_ended = 0, time = 0,);
Tachie.Alpha(name = "Kokomi", alpha_began = 1, alpha_ended = 0, time = 0,);
cmd_block
{
    at 0, Camera.WhiteRestore(0.3);
    at 0, UI.CreateMovie(name = "mv", movie = "//图片/B_第一章_视频/04_五十岚心弥闪回.mp4", alpha = 0, Loop = false,);
    at 0, UI.Alpha(name = "mv", alpha_began = 0, alpha_ended = 1, time = 1,);
}
UI.Alpha(name = "black", alpha_began = 1, alpha_ended = 0, time = 1,);
UI.Release("black");
CanSkip(true);
//闪回转场
Text.Show();
Script.Text(avater = "", name = "", dialogue = "这种感觉……！",);
//心跳一次
SE.Play(audio = "//SE/G_氛围音/02_心跳一次.ogg", volume = 0.8,);
Picture.Vibrate("Room", "weak");
//心跳一次

WaitForClick();
Text.Hide();
//五十岚心弥的反应
Tachie.Set(name = "Kokomi", scale = 1.25, x = 0, y = -675,);
Tachie.Multiply(name = "Kokomi", factor = 2.5,);
Tachie.Show(name = "Kokomi", alpha = 1, time = 0.5, );
WaitCommand(0.5);
Tachie.Change(name = "Kokomi", image = "B02_五十岚心弥/A02_吃惊.png", time = 1, );
WaitCommand(0.5);
Tachie.Change(name = "Kokomi", image = "B02_五十岚心弥/A01_平静.png", time = 1, );
Text.Show();
Script.Text(avater = "", name = "女子", dialogue = "警官好。",);

WaitForClick();
//身份档案入场
SE.Play(audio = "//SE/A_系统音效/01_回路启动.ogg", volume = 0.4,);
UI.Create(name = "Tag", image = "B_第一章/05_五十岚心弥身份档案.png", scale = 1, x = 50, y = 100, alpha = 0,);
cmd_block
{
    at 0, UI.Position(name = "Tag", x_began = 50, y_began = 100, x_ended = 0, y_ended = 0, time = 0.5, curve = "ease_out",);
    at 0, UI.Alpha(name = "Tag", alpha_began = 0, alpha_ended = 1, time = 0.5,);
    at 0, Script.Text(avater = "", name = "", dialogue = "从草加警官扫出的身份档案上，可以得知她的名字叫五十岚心弥。",);
}
//身份档案入场

WaitForClick();
Tachie.Multiply(name = "Kokomi", factor = 0.4,);
Script.Text(avater = "", name = "", dialogue = "名字也感觉很熟悉，这名女子肯定与我关系匪浅。",);

WaitForClick();
//身份档案离场
SE.Play(audio = "//SE/A_系统音效/02_回路关闭.ogg", volume = 0.4,);
cmd_block
{
    at 0, UI.Position(name = "Tag", x_began = 0, y_began = 0, x_ended = 50, y_ended = 100, time = 0.5, curve = "uniform",);
    at 0, UI.Alpha(name = "Tag", alpha_began = 1, alpha_ended = 0, time = 0.5,);
    at 0, Script.Text(avater = "", name = "", dialogue = "要知道，就连我在得知自己的名字叫佐野阳向的时候，都没有产生过如此强烈的记忆波动。",);
}
UI.Release("Tag");
//身份档案离场

WaitForClick();
Script.Text(avater = "", name = "", dialogue = "她……到底是谁？",);

WaitForClick();
Tachie.Multiply(name = "Kokomi", factor = 2.5,);
Script.Text(avater = "蓝/B05_草加裕介/A02_微笑.png", name = "草加 裕介", dialogue = "请坐，五十岚小姐。不必紧张，我们警方正在附近调查案子，有些事正好想找您聊聊。",);

WaitForClick();
SE.Play(audio = "//SE/C_布料声/03_蹲下身.ogg", volume = 0.8,);
cmd_block
{
    at 0, Tachie.Position(name = "Kokomi", y_began = -675, y_ended = -725, time = 0.7, curve = "uniform",);
    at 0, Script.Expression(name = "Kokomi", image = "B02_五十岚心弥/A04_担忧.png", textname = "", dialogue = "五十岚心弥接过警察递来的一次性纸杯，缓缓坐下了。",);
}

WaitForClick();
Script.Expression(name = "Kokomi", image = "B02_五十岚心弥/A08_微笑.png", textname = "五十岚 心弥", dialogue = "谢谢……",);

WaitForClick();
Script.Text(avater = "蓝/B05_草加裕介/A02_微笑.png", name = "草加 裕介", dialogue = "您是在SEGMA公司工作的对吧？",);

WaitForClick();
Script.Expression(name = "Kokomi", image = "B02_五十岚心弥/A04_担忧.png", textname = "五十岚 心弥", dialogue = "是的，我的职位……算是志村社长身边的助理吧。",);

WaitForClick();
Script.Text(avater = "蓝/B05_草加裕介/A02_微笑.png", name = "草加 裕介", dialogue = "很荣幸见到您，我听说最近那个很流行的VIEW APP就是你们公司开发……",);

WaitForClick();
SE.Play(audio = "//SE/I-器件音/05_从椅子上急站起身.ogg", volume = 0.8,);
cmd_block
{
    at 0, Tachie.Position(name = "Kokomi", y_began = -725, y_ended = -675, time = 0.2, curve = "uniform",);
    at 0, Script.Text(avater = "", name = "", dialogue = "草加裕介话音未落，五十岚突然将他打断了。",);
}

WaitForClick();
Script.Expression(name = "Kokomi", image = "B02_五十岚心弥/A09_抑制.png", textname = "五十岚 心弥", dialogue = "那个！能不能请告诉我这里发生了什么案子？我、我是来这幢公寓楼找人的。",);

WaitForClick();
Script.Text(avater = "蓝/B05_草加裕介/A14_感兴趣.png", name = "草加 裕介", dialogue = "不好意思，这个我们暂时还不能透露。不过请问一下您找的人是……",);

WaitForClick();
Script.Text(avater = "", name = "五十岚 心弥", dialogue = "我的同事！他今晚来这幢公寓和人谈生意，但现在早就过了预定时间了他还没给我回复，我担心他……会不会出事了。",);

WaitForClick();
Script.Text(avater = "蓝/B05_草加裕介/A08_苦笑.png", name = "草加 裕介", dialogue = "您的这个同事，莫非是叫佐野阳向？",);

WaitForClick();
Tachie.Change(name = "Kokomi", image = "B02_五十岚心弥/A02_吃惊.png", time = 0.2, );
cmd_block
{
    at 0, Tachie.Vibrate("Kokomi", "weak");
    at 0, Script.Text(avater = "", name = "五十岚 心弥", dialogue = "诶？",);
}

WaitForClick();
Script.Text(avater = "", name = "五十岚 心弥", dialogue = "为什么……你会……",);

WaitForClick();
Text.Clear();
Tachie.Hide(name = "Kokomi",);
cmd_block
{
    at 0, Tachie.Move(name = "Yukie", x_began = 510, y_began = -880, x_ended = 310, y_ended = -880, scale_began = 1.5, scale_ended = 1.5, time = 0.7, curve = "ease_out",);
    at 0, Tachie.Alpha(name = "Yukie", alpha_began = 0, alpha_ended = 1, time = 0.7,);
    at 0, Script.Text(avater = "", name = "", dialogue = "就在这时，吉田雪绘从一旁走上前来，悄悄地凑到了草加耳边。",);
}

WaitForClick();
Script.Expression(name = "Yukie", image = "B04_吉田雪绘/B02_微笑.png", textname = "吉田 雪绘", dialogue = "喂，你别太急躁了。这孩子与被害人还说不定是什么关系呢，询问的时候最好温柔一些，不要刺激到她。",);

WaitForClick();
Script.CharacterHide(name = "Yukie", textname = "", dialogue = "草加裕介摆了摆手，意思是不用担心，自己会有分寸。",);

WaitForClick();
Text.Hide();
cmd_block
{
    at 0, BGM.Volume(volume_began = 0.7, volume_ended = 0, time = 1,);
    at 0, Picture.ClockOut(name = "Room", time = 1,);
}
WaitCommand(0.5);

//读档标记点
ClearScene();

//————————————————————
//———————案情交流—————————
//————————————————————

SetUIMode(2);
UI.Create(name = "BMIO", image = "A_系统UI/01_BMI边框.png", scale = 1, alpha = 1,);
SetChapter("01", "边界徘徊的七等星");
BGM.Stop();
CanSkip(true);
CanAuto(true);

//背景创建
Picture.Create(name = "Room", image = "//背景/B_第一章/02B_鸦巢公寓物业室_夜晚.png", scale = 1, x = 0, y = 0, alpha = 0,);
//背景创建

//立绘创建
Tachie.Create(name = "Kokomi", image = "B02_五十岚心弥/A05_严肃.png", scale = 1.25, x = 0, y = -675, alpha = 0, multiply = "#F0F0DE",); //近景，y值-600~-800
Tachie.Create(name = "Police", image = "F组/F02_女警察.png", scale = 1, x = 0, y = -475, alpha = 0, multiply = "#F0F0DE",); //中景，y值-400~-525
Tachie.Create(name = "Yusuke", image = "B05_草加裕介/A17_怀疑.png", scale = 1, x = 0, y = -525, alpha = 0, multiply = "#F0F0DE",); //中景，y值-400~-525
//立绘创建

BGM.Set(audio = "//BGM/B01-理论推演.mp3", volume = 0.7,);
Picture.ClockIn(name = "Room", time = 1,);
Tachie.Show(name = "Kokomi",);
Text.Show();
Script.Text(avater = "蓝/B05_草加裕介/A08_苦笑.png", name = "草加 裕介", dialogue = "五十岚小姐，请您冷静下来听我说。",);

WaitForClick();
Script.Text(avater = "蓝/B05_草加裕介/A16_悲伤.png", name = "草加 裕介", dialogue = "……佐野阳向先生，已经出意外了。",);

WaitForClick();
Script.Expression(name = "Kokomi", image = "B02_五十岚心弥/A02_吃惊.png", textname = "五十岚 心弥", dialogue = "<size=42>……！</size>",);

WaitForClick();
Script.Text(avater = "蓝/B05_草加裕介/A03_严肃.png", name = "草加 裕介", dialogue = "我们正在全力追查犯人的身份，可以的话……我们需要您的帮助。",);

WaitForClick();
Text.Clear();
Tachie.Change(name = "Kokomi", image = "B02_五十岚心弥/A09_抑制.png", time = 0.2, );
SE.Play(audio = "//SE/C_布料声/07_布料拍打3.ogg", volume = 0.6,);
Tachie.Vibrate("Kokomi", "weak");
WaitCommand(0.5);
cmd_block
{
    at 0, Tachie.Position(name = "Kokomi", y_began = -675, y_ended = -725, time = 0.3, curve = "uniform",);
    at 0, Script.Text(avater = "", name = "", dialogue = "五十岚心弥有些虚弱地瘫坐在了椅子上，我隐约听到她嘴里好像在嘀咕些什么。",);
}

WaitForClick();
Script.Expression(name = "Kokomi", image = "B02_五十岚心弥/A10_落寞.png", textname = "五十岚 心弥", dialogue = "<size=30>为什么……这……不可能啊……</size>",);

WaitForClick();
Script.CharacterHide(name = "Kokomi", textname = "", dialogue = "草加裕介耐心地沉默下来，静静地等待对方有所回应。",);

WaitForClick();
Script.CharacterShow(name = "Kokomi", image = "B02_五十岚心弥/A06_沉思.png", textname = "", dialogue = "良晌，五十岚心弥从萎靡中恢复了一些。她表现的很克制，并没有流露出不可接受的情绪。",);

WaitForClick();
Script.Expression(name = "Kokomi", image = "B02_五十岚心弥/A04_担忧.png", textname = "五十岚 心弥", dialogue = "已经送医院了吗？",);

WaitForClick();
Script.Text(avater = "蓝/B05_草加裕介/A01_平静.png", name = "草加 裕介", dialogue = "是的。",);

WaitForClick();
Script.Expression(name = "Kokomi", image = "B02_五十岚心弥/A11_无奈.png", textname = "五十岚 心弥", dialogue = "还有抢救回来的可能吗？",);

WaitForClick();
Script.Text(avater = "蓝/B05_草加裕介/A16_悲伤.png", name = "草加 裕介", dialogue = "恐怕……",);

WaitForClick();
Script.Text(avater = "", name = "", dialogue = "草加裕介遗憾地摇了摇头。",);

WaitForClick();
Script.Expression(name = "Kokomi", image = "B02_五十岚心弥/A06_沉思.png", textname = "五十岚 心弥", dialogue = "…………",);

WaitForClick();
Script.Expression(name = "Kokomi", image = "B02_五十岚心弥/A04_担忧.png", textname = "五十岚 心弥", dialogue = "是自杀？他杀？还是意外？",);

WaitForClick();
Script.Text(avater = "蓝/B05_草加裕介/A19_谨慎.png", name = "草加 裕介", dialogue = "我们正在从不同方向调查。",);

WaitForClick();
Script.Expression(name = "Kokomi", image = "B02_五十岚心弥/A05_严肃.png", textname = "五十岚 心弥", dialogue = "除了佐野君外，还有别的人出意外吗？",);

WaitForClick();
Script.Text(avater = "蓝/B05_草加裕介/A17_怀疑.png", name = "草加 裕介", dialogue = "……？",);

WaitForClick();
Script.Text(avater = "", name = "", dialogue = "被问到这个问题的时候，就连草加也愣了一下。",);

WaitForClick();
Script.Text(avater = "蓝/B05_草加裕介/A17_怀疑.png", name = "草加 裕介", dialogue = "如果你问的是这幢公寓里的人的话，没有。",);

WaitForClick();
Script.Expression(name = "Kokomi", image = "B02_五十岚心弥/A06_沉思.png", textname = "五十岚 心弥", dialogue = "这样啊……",);

WaitForClick();
Script.Expression(name = "Kokomi", image = "B02_五十岚心弥/A01_平静.png", textname = "五十岚 心弥", dialogue = "好吧，我明白了，我会配合你们调查的，有知道的事情我都会说出来。",);

WaitForClick();
Script.CharacterHide(name = "Kokomi", textname = "", dialogue = "交涉异常顺利，这让草加颇感意外地挑了挑眉。",);

WaitForClick();
Script.Text(avater = "蓝/B05_草加裕介/A02_微笑.png", name = "草加 裕介", dialogue = "先请问一下，您和佐野阳向先生的关系是？",);

WaitForClick();
Script.CharacterShow(name = "Kokomi", textname = "五十岚 心弥", dialogue = "<b>普通同事。</b>他是总架构师，我是测试师。",);

WaitForClick();
Script.Text(avater = "蓝/B05_草加裕介/A02_微笑.png", name = "草加 裕介", dialogue = "您也参与了VIEW的开发吗？",);

WaitForClick();
Script.Expression(name = "Kokomi", image = "B02_五十岚心弥/A06_沉思.png", textname = "五十岚 心弥", dialogue = "是的，不过我参与的不多，多数时候是帮忙采购设备和编写测试程序。",);

WaitForClick();
Script.Text(avater = "蓝/B05_草加裕介/A02_微笑.png", name = "草加 裕介", dialogue = "那正好，我们有张图片想请您看一下。",);

WaitForClick();
//展示图片（隐去立绘）
Text.Clear();
Tachie.Hide(name = "Kokomi", image = "B02_五十岚心弥/A01_平静.png",);
SE.Play(audio = "//SE/A_系统音效/03_通话启动.ogg", volume = 0.4,);
Frame.PictureOn(image = "//图片/B_第一章/05_门上的魔法阵.png", color = "blue", duration = 0.3,);
//展示图片（隐去立绘）
Script.Text(avater = "", name = "", dialogue = "草加裕介用BMI将图片共享了过去。",);

WaitForClick();
Script.Text(avater = "蓝/B05_草加裕介/A19_谨慎.png", name = "草加 裕介", dialogue = "这是在案发现场的门上发现的，有目击线索称在使用VIEW的全景地图看走廊旁的房门时，突然出现了这个图案。您对此有什么头绪吗？",);

WaitForClick();
Script.Text(avater = "", name = "", dialogue = "五十岚心弥歪着脑袋观察了一会儿，然后面无表情地摇了摇头。",);

WaitForClick();
Script.Text(avater = "蓝/B02_五十岚心弥/A05_严肃.png", name = "五十岚 心弥", dialogue = "我也不知道这是什么，是从什么黑魔法类书籍上抄下来的图案吗？",);

WaitForClick();
Script.Text(avater = "蓝/B02_五十岚心弥/A07_思索.png", name = "五十岚 心弥", dialogue = "中间那个眼睛，倒是有点像全视之眼。",);

WaitForClick();
//收起图片（显示立绘）
SE.Play(audio = "//SE/A_系统音效/09_退出界面.ogg", volume = 0.7,);
Frame.PictureOff(0.3);
cmd_block
{
    at 0, Tachie.Show(name = "Kokomi", image = "B02_五十岚心弥/A01_平静.png",);
    //收起图片（显示立绘）
    at 0, Script.Text(avater = "蓝/B05_草加裕介/A15_留意.png", name = "草加 裕介", dialogue = "那能否通过查询服务器找出把这张图片上传到VIEW中的人？",);
}

WaitForClick();
Script.Text(avater = "", name = "五十岚 心弥", dialogue = "应该可以。",);

WaitForClick();
Script.Text(avater = "蓝/B05_草加裕介/A07_麻烦.png", name = "草加 裕介", dialogue = "那就好，我们在这方面可能需要您的帮助。",);

WaitForClick();
//展示图片（隐去立绘）
Text.Clear();
Tachie.Hide(name = "Kokomi",);
SE.Play(audio = "//SE/A_系统音效/03_通话启动.ogg", volume = 0.4,);
Frame.PictureOn(image = "//图片/B_第一章/19_打伞人.png", color = "blue", duration = 0.3,);
//展示图片（隐去立绘）
Script.Text(avater = "蓝/B05_草加裕介/A15_留意.png", name = "草加 裕介", dialogue = "然后……请问您对照片上的这个人有印象吗？",);

WaitForClick();
Script.Text(avater = "", name = "", dialogue = "五十岚心弥的目光略微惊讶了一瞬，但随即又恢复了淡漠的表情。",);

WaitForClick();
Script.Text(avater = "蓝/B02_五十岚心弥/A06_沉思.png", name = "五十岚 心弥", dialogue = "衣服穿成这么厚又看不到脸，就算是认识的人我也不可能认出来吧。",);

WaitForClick();
Script.Text(avater = "蓝/B05_草加裕介/A14_感兴趣.png", name = "草加 裕介", dialogue = "那就是认识了？",);

WaitForClick();
Script.Text(avater = "蓝/B02_五十岚心弥/A01_平静.png", name = "五十岚 心弥", dialogue = "不，不认识。",);

WaitForClick();
//收起图片（显示立绘）
SE.Play(audio = "//SE/A_系统音效/09_退出界面.ogg", volume = 0.7,);
Frame.PictureOff(0.3);
cmd_block
{
    at 0, Tachie.Show(name = "Kokomi", image = "B02_五十岚心弥/A01_平静.png",);
    //收起图片（显示立绘）
    at 0, Script.Text(avater = "蓝/B05_草加裕介/A01_平静.png", name = "草加 裕介", dialogue = "这个人是我们正在追查的嫌疑人。所以我想向您打听一下，佐野阳向先生近来有没有和人发生过工作或者财务上的纠纷。",);
}

WaitForClick();
Script.Expression(name = "Kokomi", image = "B02_五十岚心弥/A11_无奈.png", textname = "五十岚 心弥", dialogue = "没有……至少我没听说过。",);

WaitForClick();
Script.Expression(name = "Kokomi", image = "B02_五十岚心弥/A07_思索.png", textname = "五十岚 心弥", dialogue = "我只知道他和社长之间不太和睦，但两个人平时更多是互相不感冒的态度。",);

WaitForClick();
Script.Text(avater = "蓝/B05_草加裕介/A01_平静.png", name = "草加 裕介", dialogue = "了解了。您刚才提到佐野阳向先生今晚来到鸦巢公寓是有生意要谈？",);

WaitForClick();
Script.Expression(name = "Kokomi", image = "B02_五十岚心弥/A10_落寞.png", textname = "五十岚 心弥", dialogue = "…………",);

WaitForClick();
Script.Text(avater = "", name = "", dialogue = "五十岚心弥没有回答，草加等待了十几秒才发现她走神了。",);

WaitForClick();
Script.Text(avater = "蓝/B05_草加裕介/A15_留意.png", name = "草加 裕介", dialogue = "五十岚小姐？",);

WaitForClick();
Script.Expression(name = "Kokomi", image = "B02_五十岚心弥/A11_无奈.png", textname = "五十岚 心弥", dialogue = "……啊，啊？",);
WaitCommand(0.1);
Tachie.Change(name = "Kokomi", image = "B02_五十岚心弥/Z01_走神.png", time = 0.2, );
WaitCommand(0.3);
Tachie.Change(name = "Kokomi", image = "B02_五十岚心弥/A02_吃惊.png", time = 0.2, );

WaitForClick();
Script.Text(avater = "蓝/B05_草加裕介/A16_悲伤.png", name = "草加 裕介", dialogue = "您是不是有些疲劳？要不先回家休息，我们有需要再与您联系？",);

WaitForClick();
Script.Expression(name = "Kokomi", image = "B02_五十岚心弥/A10_落寞.png", textname = "五十岚 心弥", dialogue = "哦，不好意思，有些走神了，您刚刚是问佐野君来谈生意的事吗？",);

WaitForClick();
Script.Expression(name = "Kokomi", image = "B02_五十岚心弥/A01_平静.png", textname = "五十岚 心弥", dialogue = "他只跟我说了今晚有生意要谈，没说具体和谁谈什么。",);

WaitForClick();
Script.CharacterHide(name = "Kokomi", textname = "", dialogue = "说着，五十岚心弥将一张聊天记录的截图共享了出来。",);

WaitForClick();
//显示聊天记录
SE.Play(audio = "//SE/A_系统音效/03_通话启动.ogg", volume = 0.4,);
UI.Create(name = "Rine", image = "//UI/B_第一章/06_聊天记录.png", scale = 1, x = 0, y = 95, alpha = 0,);
UI.ExpandIn(name = "Rine", direction = "vertical", time = 0.7,);
//显示聊天记录
Script.Text(avater = "", name = "", dialogue = "…………",);

WaitForClick();
Script.Text(avater = "", name = "", dialogue = "我好像看到了错字。",);

WaitForClick();
Script.Text(avater = "蓝/B05_草加裕介/A17_怀疑.png", name = "草加 裕介", dialogue = "这就是您和佐野阳向先生最后一次联系？",);

WaitForClick();
Script.Text(avater = "蓝/B02_五十岚心弥/A10_落寞.png", name = "五十岚 心弥", dialogue = "是的，之后我一直等到零点他都没回消息，我有些担心就主动过来了。",);

WaitForClick();
Script.Text(avater = "蓝/B02_五十岚心弥/A11_无奈.png", name = "五十岚 心弥", dialogue = "没想到……竟然真的……",);

WaitForClick();
Script.Text(avater = "蓝/B05_草加裕介/A02_微笑.png", name = "草加 裕介", dialogue = "十分感谢，您提供的线索对我们很重要。",);

WaitForClick();
//关闭聊天记录
SE.Play(audio = "//SE/A_系统音效/09_退出界面.ogg", volume = 0.7,);
UI.ExpandOut(name = "Rine", direction = "vertical", time = 0.7,);
UI.Release("Rine");
//关闭聊天记录
cmd_block
{
    at 0, Tachie.Show(name = "Kokomi", image = "B02_五十岚心弥/A01_平静.png",);
    at 0, Script.Text(avater = "蓝/B05_草加裕介/A19_谨慎.png", name = "草加 裕介", dialogue = "最后我想向您确认一件事，您在<b>20时55分前后</b>去过什么地方？",);
}

WaitForClick();
Script.Expression(name = "Kokomi", image = "B02_五十岚心弥/A06_沉思.png", textname = "五十岚 心弥", dialogue = "8点半啊……当时我在乘地铁回家。",);

WaitForClick();
Script.Text(avater = "蓝/B05_草加裕介/A07_麻烦.png", name = "草加 裕介", dialogue = "那个，我问的是九点前后……",);

WaitForClick();
Script.Expression(name = "Kokomi", image = "B02_五十岚心弥/A02_吃惊.png", textname = "五十岚 心弥", dialogue = "哦，不好意思！九点钟……我九点钟应该在家吧……",);

WaitForClick();
Script.Text(avater = "", name = "", dialogue = "草加裕介担忧地看了五十岚一眼，她的精神状态确实不太好，也许不该再纠缠不休地问下去了。",);

WaitForClick();
Script.Text(avater = "蓝/B05_草加裕介/A01_平静.png", name = "草加 裕介", dialogue = "感谢您的配合，五十岚小姐。您也不用有太大的心理压力，佐野阳向先生的事我深表遗憾，但我们警方一定会负责任地将犯人抓捕归案。",);

WaitForClick();
Script.Text(avater = "蓝/B05_草加裕介/A02_微笑.png", name = "草加 裕介", dialogue = "时间已经很晚了，您先回家休息吧，案件有什么进展我们会随时与您联系。",);

WaitForClick();
Tachie.Change(name = "Kokomi", image = "B02_五十岚心弥/A01_平静.png", time = 0.2, );
SE.Play(audio = "//SE/C_布料声/08_布料掀起1.ogg", volume = 1,);
cmd_block
{
    at 0, Tachie.Position(name = "Kokomi", y_began = -725, y_ended = -675, time = 0.5, curve = "uniform",);
    at 0, Script.Text(avater = "", name = "五十岚 心弥", dialogue = "嗯，谢谢警官。我可能确实有些不舒服，就先回家休息了。",);
}

WaitForClick();
Script.CharacterHide(name = "Kokomi", time = 0.7, textname = "", dialogue = "五十岚心弥从椅子上站起，在向警察欠身行了一礼后，缓步走出了物业室的大门。",);

WaitForClick();
SE.Play(audio = "//SE/B_开关门/01_自动门开启.ogg", volume = 1,);
//关闭BMI
cmd_block
{
    at 0, UI.Scale(name = "BMIO", scale_began = 1, scale_ended = 1.3, time = 0.5, curve = "uniform",);
    at 0, SetUIMode(3);
    at 0, Text.Hide();
    //关闭BMI
    at 3, SE.Play(audio = "//SE/B_开关门/02_自动门关闭.ogg", volume = 1,);
}
WaitCommand(3);
//立绘平移入场（从右侧）
cmd_block
{
    at 0, Tachie.Position(name = "Police", x_began = 300, x_ended = 0, time = 0.7, curve = "ease_out",);
    at 0, Tachie.Alpha(name = "Police", alpha_began = 0, alpha_ended = 1, time = 0.7,);
}
//立绘平移入场（从右侧）
Text.Show();
Script.Text(avater = "", name = "女警员", dialogue = "草加警官。", );

WaitForClick();
//立绘同屏入场（从右侧）
cmd_block
{
    at 0, Tachie.Alpha(name = "Yusuke", alpha_began = 0, alpha_ended = 1, time = 0.7,);
    at 0, Tachie.Position(name = "Yusuke", x_began = 700, x_ended = 350, time = 0.7, curve = "ease_out",);
    at 0, Tachie.Position(name = "Police", x_began = 0, x_ended = -350, time = 0.7, curve = "ease_out",);
}
//立绘同屏入场（从右侧）
Tachie.Multiply(name = "Police", factor = 0.4,);
Script.Text(avater = "", name = "草加 裕介", dialogue = "嗯？",);

WaitForClick();
Script.Speaker(nameA = "Police", nameB = "Yusuke", textname = "女警员", dialogue = "被害人的载波电极损坏得很严重，估计难以恢复完整数据。",);

WaitForClick();
Script.Speaker(nameA = "Yusuke", nameB = "Police", imageA = "B05_草加裕介/A04_思考.png", textname = "草加 裕介", dialogue = "…………",);

WaitForClick();
Script.Expression(name = "Yusuke", image = "B05_草加裕介/A01_平静.png", textname = "五十岚 心弥", dialogue = "我知道了。",);

WaitForClick();
Script.Text(avater = "", name = "草加 裕介", dialogue = "总之先从被害人的人际关系开始查起吧，向检察院申请一下调取一下公民信息库。", );

WaitForClick();
Script.Speaker(nameA = "Police", nameB = "Yusuke", textname = "女警员", dialogue = "是。",);

WaitForClick();
Text.Hide();
cmd_block
{
    at 0, Tachie.Hide(name = "Police",);
    at 0, Tachie.Hide(name = "Yusuke",);
    at 0.5, BGM.Volume(volume_began = 0.7, volume_ended = 0, time = 1,);
    at 0.5, Picture.Alpha(name = "Room", alpha_began = 1, alpha_ended = 0, time = 1,);
}
WaitCommand(0.5);

//读档标记点
ClearScene();

//————————————————————
//———————湖畔沉思—————————
//————————————————————

SetUIMode(3);
SetChapter("01", "边界徘徊的七等星");
BGM.Stop();
CanSkip(true);
CanAuto(true);

Text.Show();
Script.Text(avater = "", name = "", dialogue = "之后的调查我就没有继续旁观下去了。",);

WaitForClick();
Script.Text(avater = "", name = "", dialogue = "也许是对吉田雪绘说过的话有些在意，我跟上了从公寓离开的五十岚心弥。",);

WaitForClick();
Script.Text(avater = "", name = "", dialogue = "心想着，能不能在她独身一人时，得到些她和我关系的线索。",);

WaitForClick();
Script.Text(avater = "", name = "", dialogue = "…………",);

WaitForClick();
BGM.Set(audio = "//BGM/J02-忆之庭.mp3", volume = 0.7,);
Script.Text(avater = "", name = "", dialogue = "我悄无声息地走在她身后，脑海中也开始思考起了一些比较沉重的问题。",);

WaitForClick();
Script.Text(avater = "", name = "", dialogue = "我……死了。",);

WaitForClick();
Script.Text(avater = "", name = "", dialogue = "但我的意识还苏醒着，无法体会到死亡的实感。",);

WaitForClick();
Script.Text(avater = "", name = "", dialogue = "我有亲人吗？朋友总该有的吧。他们得知我死讯的时候，会不会感到悲痛呢？",);

WaitForClick();
Script.Text(avater = "", name = "", dialogue = "人的死亡不过一瞬之间，但却会给身边亲近的人带来久久无法愈合的伤害。",);

WaitForClick();
Script.Text(avater = "", name = "", dialogue = "我能够平静地接受自己身为幽灵的现实，但与我亲近的人呢？",);

WaitForClick();
Script.Text(avater = "", name = "", dialogue = "只是……",);

WaitForClick();
Script.Text(avater = "", name = "", dialogue = "我在心中诘责起了自己一个问题。",);

WaitForClick();
Script.Text(avater = "", name = "", dialogue = "你……真的是因为在意五十岚心弥，才离开案发现场不继续旁观调查的吗？",);

WaitForClick();
Script.Text(avater = "", name = "", dialogue = "还是说，你在逃避？",);

WaitForClick();
Script.Text(avater = "", name = "", dialogue = "你在逃避从警察口中，得知关于你亲人朋友的消息？",);

WaitForClick();
Script.Text(avater = "", name = "", dialogue = "思绪陷入沉顿。",);

WaitForClick();
Script.Text(avater = "", name = "", dialogue = "就这样，一路走到了城市中的公园。",);

WaitForClick();
Text.Hide();
Picture.Create(name = "CG", image = "B_第一章/20A_公园里的五十岚心弥.png", scale = 1, x = 0, y = 0, angle = 0, alpha = 0,);
Picture.Alpha(name = "CG", alpha_began = 0, alpha_ended = 1, time = 2,);
Text.Show();
Script.Text(avater = "", name = "五十岚 心弥", dialogue = "…………",);

WaitForClick();
Script.Text(avater = "", name = "", dialogue = "深夜来到公园的五十岚心弥，在湖边驻足了下来。",);

WaitForClick();
Script.Text(avater = "", name = "", dialogue = "她垂着头，将面容隐藏在幽暗的夜色中，让我无法看清她脸上的表情。",);

WaitForClick();
Script.Text(avater = "", name = "", dialogue = "我有些心慌，担心等她抬起头来后，脸上会出现我最不愿看到的……眼泪的痕迹。",);

WaitForClick();
Script.Text(avater = "", name = "", dialogue = "果然，当我借着月光再度观察时，在她眼中看到了一朵晶莹的泪花。",);

WaitForClick();
Script.Text(avater = "", name = "", dialogue = "沉寂良久之后，女孩抬起头来，将目光投向了在城市万家灯火的映照下显得了无生气的夜空。",);

WaitForClick();
Picture.Change(name = "CG", image = "B_第一章/20B_公园里的五十岚心弥.png", time = 1,);
Script.Text(avater = "", name = "五十岚 心弥", dialogue = "<size=30>如果……这也是对我的报复的话……</size>",);

WaitForClick();
Script.Text(avater = "", name = "五十岚 心弥", dialogue = "你一定要平安无事啊……<b>前辈</b>。",);

WaitForClick();
Text.Hide();
cmd_block
{
    at 0, Picture.Alpha(name = "CG", alpha_began = 1, alpha_ended = 0, time = 2,);
    at 1, BGM.Volume(volume_began = 0.7, volume_ended = 0, time = 3,);
}
//章节过渡
CanSkip(false);
Picture.Create(name = "CPT", image = "A_公用图片/01_章节过渡.png", scale = 1, x = 0, y = 0, angle = 0, alpha = 0,);
Picture.Alpha(name = "CPT", alpha_began = 0, alpha_ended = 1, time = 1,);
WaitCommand(2.5);
Picture.Alpha(name = "CPT", alpha_began = 1, alpha_ended = 0, time = 0.5,);
//章节过渡

StoryArrow(6, true);
WaitCommand(1);
JumpToScript("脚本/V2/sv_01_07.json");