//C:\Users\10533\Desktop\SYMMETRIC_VISION\makeScript.bat


//————————————————————
//———————章节标题—————————
//————————————————————

StoryBlock(4, true);
CanSkip(false);
VisionTrigger(false);
SetChapter("01", "边界徘徊的七等星");
BGM.Stop();
SetUIMode(5);
CanSkip(true);
CanAuto(true);

//————————————————————
//———————走访之前—————————
//————————————————————

//背景创建
Picture.Create(name = "Room", image = "//背景/B_第一章/02B_鸦巢公寓物业室_夜晚.png", scale = 1, x = 0, y = 0, alpha = 0,);
Picture.Create(name = "Out", image = "//背景/B_第一章/04G_鸦巢公寓大门_夜晚_警戒带.png", scale = 1, x = 0, y = 0, alpha = 0,);
//背景创建

//立绘创建
Tachie.Create(name = "Hidekazu", image = "D01_本马秀和/A01_平常.png", scale = 1.25, x = 0, y = -600, alpha = 0, multiply = "#f0f0de",); //近景，y值-600~-800
Tachie.Create(name = "Yusuke", image = "B05_草加裕介/A01_平静.png", scale = 1, x = 0, y = -525, alpha = 0, multiply = "#f0f0de",); //中景，y值-400~-525
Tachie.Create(name = "Police", image = "F组/F02_女警察.png", scale = 1, x = 0, y = -475, alpha = 0, multiply = "#c8c5be",); //中景，y值-400~-525
//立绘创建

Text.Show();
Script.Text(dialogue = "2035年9月7日（星期五）晚，23时35分。",speed = 30,);


WaitForClick();
Text.Hide();
BGM.Set(audio = "//BGM/B01-理论推演.mp3", volume = 0.7,);
Picture.Alpha(name = "Room", alpha_began = 0, alpha_ended = 1, time = 1,);
//BMI开启
SetUIMode(2);
UI.Create(name = "BMIO", image = "A_系统UI/01_BMI边框.png", scale = 1.3, alpha = 1,);
UI.Scale(name = "BMIO", scale_began = 1.3, scale_ended = 1, time = 0.5, curve = "uniform",);
SE.Play(audio = "//SE/A_系统音效/01_回路启动.ogg", volume = 0.4,);
//BMI开启
cmd_block
{
    at 0, Tachie.Alpha(name = "Hidekazu", alpha_began = 0, alpha_ended = 1, time = 0.5,);
    at 0, Text.Show();
}
Script.Text(dialogue = "我附在草加裕介的BMI上，看到了物业小哥本马秀和传来的地图。", );

WaitForClick();
//图片入场（立绘让位）
cmd_block
{
    at 0, Picture.Create(name = "pic1", image = "//图片/B_第一章/14_鸦巢公寓一楼地图.png", scale = 0.48, x = 1000, y = 0, alpha = 0,);
    at 0, Picture.Move(name = "pic1", x_began = 1000, x_ended = 400, time = 0.7, curve = "ease_in", alpha_began = 0, alpha_ended = 1, alpha_time = 0.7,);
    at 0, Tachie.Position(name = "Hidekazu", x_began = 0, x_ended = -500, time = 0.7, curve = "ease_in");
    at 0, Script.Text(name = "本马 秀和", dialogue = "这就是鸦巢公寓的模型图。", );
}
//图片入场（立绘让位）

WaitForClick();
Script.Expression(name = "Hidekazu", image = "D01_本马秀和/A05_疑问.png", textname = "本马 秀和", dialogue = "一楼有两个门可以进入大厅，不过都会被走廊中的监控摄像头拍到。",);

WaitForClick();
Script.Expression(name = "Hidekazu", image = "D01_本马秀和/A01_平常.png", textname = "本马 秀和", dialogue = "对面这栋楼是吉田姐的住所，我们的物业室是将她家一楼对门的房间当岗亭使用了。",);

WaitForClick();
Script.Text(avater = "蓝/B05_草加裕介/A01_平静.png", name = "草加 裕介", dialogue = "房东女士家的户型，有点少见啊。",);

WaitForClick();
Script.Expression(name = "Hidekazu", image = "D01_本马秀和/A02_赔笑.png", textname = "本马 秀和", dialogue = "听说这里曾经是个工厂，公寓那边是原本的员工宿舍楼。后来厂房拆掉了，有人重新建了栋别墅起来，所以看着户型很怪。",);

WaitForClick();
cmd_block
{
    at 0, Picture.Change(name = "pic1", image = "//图片/B_第一章/15_鸦巢公寓二楼地图.png", time = 0.5, );
    at 0, Script.Expression(name = "Hidekazu", image = "D01_本马秀和/A01_平常.png", textname = "本马 秀和", dialogue = "公寓只有一个楼梯可以上下楼，虽然二楼走廊尽头还有一个后门楼梯，但已经很久没有使用过了。",);
}

WaitForClick();
Script.Text(name = "本马 秀和", dialogue = "二楼的三户人家分别是201室的<b>坂丘健一郎</b>、202室的<b>荻原大辅</b>、还有203室的<b>森川雅史</b>和<b>早津智</b>。", );

WaitForClick();
Script.Text(avater = "蓝/B05_草加裕介/A02_微笑.png", name = "草加 裕介", dialogue = "荻原大辅、森川雅史和早津智就是和你一起撞开303室房门的那几位吧？",);

WaitForClick();
Script.Expression(name = "Hidekazu", image = "D01_本马秀和/A02_赔笑.png", textname = "本马 秀和", dialogue = "是的，其中森川雅史和早津智是合租的大学生，荻原先生则是独居。",);

WaitForClick();
cmd_block
{
    at 0, Picture.Change(name = "pic1", image = "//图片/B_第一章/16_鸦巢公寓三楼地图.png", time = 0.5, );
    at 0, Script.Expression(name = "Hidekazu", image = "D01_本马秀和/A01_平常.png", textname = "本马 秀和", dialogue = "三楼的301室暂时没人租，所以是空屋。302室是<b>菅田敏之</b>先生家，他和妻子<b>菅田泉美</b>同居。",);
}

WaitForClick();
Script.Text(name = "本马 秀和", dialogue = "损坏的监控在303室门口，我就是在更换新摄像头时看到了303室门上的魔法阵，所以才喊人来撞开房门的。", );

WaitForClick();
Script.Text(avater = "蓝/B05_草加裕介/A19_谨慎.png", name = "草加 裕介", dialogue = "VIEW中的魔法阵……这个我在你的录像中也看到了。不过你确定它是突然出现的吗？",);

WaitForClick();
Script.Expression(name = "Hidekazu", image = "D01_本马秀和/A06_慌.png", textname = "本马 秀和", dialogue = "这个……我也有点记不清了。但我刚开始安装新摄像头时，门上应该是没有魔法阵的。",);

WaitForClick();
Script.Text(avater = "蓝/B05_草加裕介/A04_思考.png", name = "草加 裕介", dialogue = "也就是说，有人知道你控制着机器人上了三楼，所以<b>故意往VIEW里放了个魔法阵吸引你的注意力</b>，目的是引诱你进入房间发现尸体。",);

WaitForClick();
Script.Expression(name = "Hidekazu", image = "D01_本马秀和/A03_惊讶.png", textname = "本马 秀和", dialogue = "啊……！",);

WaitForClick();
Script.Expression(name = "Hidekazu", image = "D01_本马秀和/A05_疑问.png", textname = "本马 秀和", dialogue = "我是被凶手诱导着发现尸体的吗？这我还真没想到！",);

WaitForClick();
Script.Text(name = "本马 秀和", dialogue = "那这个凶手难道是一名黑客？他一直在监视着公寓周围，还利用了我？", );

WaitForClick();
Script.Text(avater = "蓝/B05_草加裕介/A01_平静.png", name = "草加 裕介", dialogue = "不排除这种可能，所以今晚我的同事要辛苦一下在这附近巡巡逻了。",);

WaitForClick();
Tachie.Multiply(name = "Hidekazu", factor = 0.4,);
Script.Text(dialogue = "唔，黑客吗……",);

WaitForClick();
Script.Text(dialogue = "感觉两人的猜想不太对。如果是犯人是黑客，要选择无人的房间来作案的话，会<b>更倾向于装了电子锁的301室空屋</b>才对。",);

WaitForClick();
Script.Text(dialogue = "当然也有一种可能：并不是犯人选择了303室，而是我出于某种理由入侵了303室，犯人尾随在我身后进入了房间。",);

WaitForClick();
Script.Text(dialogue = "这样一来，我又是为什么来到鸦巢公寓的呢？为什么熊取昌二会声称他根本不认识我呢？",);

WaitForClick();
Script.Text(dialogue = "想不明白……还是先静观其变吧。",);

WaitForClick();
//关闭BMI
SE.Play(audio = "//SE/A_系统音效/09_退出界面.ogg", volume = 0.7,);
cmd_block
{
    at 0, UI.Scale(name = "BMIO", scale_began = 1, scale_ended = 1.3, time = 0.5, curve = "uniform",);
    at 0, SetUIMode(3);
    //关闭BMI
    at 0, Text.Hide();
    at 0, Tachie.Hide(name = "Hidekazu",);
    at 0, Picture.Alpha(name = "pic1", alpha_began = 1, alpha_ended = 0, time = 0.5,);
}
Tachie.Multiply(name = "Hidekazu", factor = 2.5,);
Picture.Release("pic1");
WaitCommand(1);
Text.Show();
Script.Text(dialogue = "时间已过零点，草加裕介开始了亲自对目击者们进行盘问。",);

WaitForClick();
Script.Text(dialogue = "我从他的BMI上离开，继续以幽灵的视角旁观着警方的搜查工作。",);

WaitForClick();
Script.CharacterShow(name = "Yusuke", image = "B05_草加裕介/A02_微笑.png", textname = "草加 裕介", dialogue = "你的值班时间是16时到24时，现在已经到你下班的时间了吧？",);

WaitForClick();
Tachie.Set(name = "Hidekazu", scale = 1, x = 0, y = -400,);
Script.Character(nameA = "Yusuke", nameB = "Hidekazu", imageB = "D01_本马秀和/A02_赔笑.png", textname = "", dialogue = "听到这话，本马秀和尴尬地苦笑了两声。",);

WaitForClick();
Script.Text(name = "本马 秀和", dialogue = "现在这状况……不是明显下不了班了吗。", );

WaitForClick();
Script.Character(nameA = "Hidekazu", nameB = "Yusuke", imageB = "B05_草加裕介/A01_平静.png", textname = "草加 裕介", dialogue = "你说自己在案发前三个小时内一直待在物业室里玩VIEW，这件事有人能替你证明吗？",);

WaitForClick();
Script.Character(nameA = "Yusuke", nameB = "Hidekazu", imageB = "D01_本马秀和/A01_平常.png", textname = "本马 秀和", dialogue = "啊？这不可能有吧，就算物业室中途来过几名业主，也没人能持续三个小时证明我没出门啊。",);

WaitForClick();
Script.Expression(name = "Hidekazu", image = "D01_本马秀和/A04_紧张.png", textname = "本马 秀和", dialogue = "警官你可不能怀疑我！如果我中途有时间出门作案，那只要随便有个人在那段时间看到我不在物业室就完蛋了。我哪敢撒这个谎啊……",);

WaitForClick();
Script.Character(nameA = "Hidekazu", nameB = "Yusuke", imageB = "B05_草加裕介/A02_微笑.png", textname = "草加 裕介", dialogue = "好吧，我会去SEGMA公司调取VIEW的服务器数据，这样就能确认你这三个小时里是否一直在线了。",);

WaitForClick();
Script.Character(nameA = "Yusuke", nameB = "Hidekazu", imageB = "D01_本马秀和/A01_平常.png", textname = "本马 秀和", dialogue = "辛苦警官了……",);

WaitForClick();
Script.CharacterHide(name = "Hidekazu", textname = "", dialogue = "物证搜查受挫以后，草加裕介转而试图从目击者身上寻求突破口，亲自做起了本该由手下警员执行的例行问讯工作。",);

WaitForClick();
Script.Text(dialogue = "看他愁眉苦脸的样子，这应该并不是警方习惯的搜查方法。但现在也只能这么做了。",);

WaitForClick();
Text.Hide();
Picture.CoveringOut(name = "Room", direction = "right", time = 0.5,);
BGM.Volume(volume_began = 0.7, volume_ended = 0, time = 1,);
WaitCommand(0.5);
Picture.CoveringIn(name = "Out", direction = "left", time = 0.5,);
BGM.Set(audio = "//BGM/B04-会议记录.mp3", volume = 0.7,);
//立绘平移入场（从左侧）
cmd_block
{
    at 0, Tachie.Position(name = "Police", x_began = -300, x_ended = 0, time = 0.7, curve = "ease_out",);
    at 0, Tachie.Alpha(name = "Police", alpha_began = 0, alpha_ended = 1, time = 0.7,);
}
//立绘平移入场（从左侧）
Text.Show();
Script.Text(name = "女警员", dialogue = "草加警官，我叫人检查了周边街道的消防箱，没发现有丢失的安全斧锤。", );

WaitForClick();
Tachie.Multiply(name = "Yusuke", color = "#c8c5be", factor = 1,);
Script.Character(nameA = "Police", nameB = "Yusuke", imageB = "B05_草加裕介/A01_平静.png", textname = "草加 裕介", dialogue = "这样啊。",);

WaitForClick();
Script.Character(nameA = "Yusuke", nameB = "Police", textname = "女警员", dialogue = "熊取昌二的BMI也检查完了，不过怎么说呢……十分可疑。",);

WaitForClick();
Script.Character(nameA = "Police", nameB = "Yusuke", imageB = "B05_草加裕介/A17_怀疑.png", textname = "草加 裕介", dialogue = "哦？",);

WaitForClick();
Script.Character(nameA = "Yusuke", nameB = "Police", textname = "女警员", dialogue = "他的通话记录数量很少，像是刻意删除过。按理来说销售员这种职业应该经常需要打电话才对。",);

WaitForClick();
Script.Text(name = "女警员", dialogue = "网页浏览记录和相册也一片空白，根本查不到有效线索。", );

WaitForClick();
Script.Text(name = "女警员", dialogue = "最关键的是，虽然熊取昌二的BMI位置信息确实显示他<b>去过池袋的健身房</b>……", );

WaitForClick();
Script.Text(name = "女警员", dialogue = "但我刚才打电话询问了那家健身房，他们今天恰好因为出了一例流感而<b>暂停营业</b>了。", );

WaitForClick();
Script.Character(nameA = "Police", nameB = "Yusuke", imageB = "B05_草加裕介/A03_严肃.png", textname = "草加 裕介", dialogue = "<size=38>什么！？</size>",);

WaitForClick();
Script.Text(dialogue = "草加裕介皱起了眉头。",);

WaitForClick();
Script.Expression(name = "Yusuke", image = "B05_草加裕介/A19_谨慎.png", textname = "草加 裕介", dialogue = "这样，今晚你们在附近找家旅馆安置下熊取昌二，然后把房间监视起来。",);

WaitForClick();
Script.Text(name = "草加 裕介", dialogue = "为了不让他起疑心，最好是你们来付钱，旅馆和房间让他自己选。", );

WaitForClick();
Script.Character(nameA = "Yusuke", nameB = "Police", textname = "女警员", dialogue = "我明白了。",);

WaitForClick();
Text.Clear();
//立绘平移离场（向左侧）
SE.Play(audio = "//SE/D_脚步声/08_登场的脚步声.ogg", volume = 0.7,);
cmd_block
{
    at 0, Tachie.Position(name = "Police", x_began = 0, x_ended = -300, time = 0.7, curve = "ease_in",);
    at 0, Tachie.Alpha(name = "Police", alpha_began = 1, alpha_ended = 0, time = 0.7,);
}
//立绘平移离场（向左侧）
//上下黑边入场
Picture.Create(name = "blackcover", image = "//背景/上下黑边.png", alpha = 1,);
cmd_block
{
    at 0, Picture.Scale(name = "blackcover", scale_began = 1, scale_ended = 0.8, time = 1, curve = "uniform",);
    //上下黑边入场
    at 0, Script.Text(dialogue = "…………",);
}

WaitForClick();
Script.Text(dialogue = "303室的那个住户，在明知自己身背命案嫌疑的情况下，居然还伪造了自己的行程数据？",);

WaitForClick();
SE.Stop();
Script.Text(dialogue = "也就是说，且不管他是不是杀害我的凶手，他都有必须隐瞒自己真实行踪的理由吗……",);

WaitForClick();
Picture.CoveringOut(name = "Out", direction = "right", time = 0.5,);
Script.Text(dialogue = "看来，今晚有必要去他住的旅馆看看了。",);

WaitForClick();
Script.Text(dialogue = "既然我可以无视墙壁阻碍出入任何场所，那就该好好利用这份能力才是。",);

WaitForClick();
cmd_block
{
    at 0, Text.Hide();
    at 0, BGM.Volume(volume_began = 0.7, volume_ended = 0, time = 0.5,);
}

//读档标记点
ClearScene();

//————————————————————
//———————菅田敏之—————————
//————————————————————

SetUIMode(3);
SetChapter("01", "边界徘徊的七等星");
BGM.Stop();
CanSkip(true);
CanAuto(true);

//背景创建
Picture.Create(name = "Far", image = "//背景/B_第一章/07B_鸦巢公寓三楼走廊_楼梯口_夜晚.png", scale = 1, x = 0, y = 0, alpha = 0,);
Picture.Create(name = "Video", image = "//背景/B_第一章/09A_鸦巢公寓302室_茶几视角.png", scale = 1, x = 0, y = 0, alpha = 0,);
Picture.Create(name = "Near", image = "//背景/B_第一章/07D_鸦巢公寓三楼走廊_303室门口_夜晚亮灯.png", scale = 1, x = 0, y = 100, alpha = 0,);
Picture.Create(name = "Memory", image = "//背景/B_第一章/07E_鸦巢公寓三楼走廊_303室门口_夜晚.png", scale = 1, x = 0, y = 100, alpha = 0,);
//背景创建

//立绘创建
Tachie.Create(name = "Toshiyuki", image = "D02_菅田敏之/A06_惊慌.png", scale = 1, x = 0, y = -525, alpha = 0, multiply = "#e1e8ef",); //中景，y值-400~-525
Tachie.Create(name = "Izumi", image = "D03_菅田泉美/A04_不悦.png", scale = 1, x = 0, y = -425, alpha = 0, multiply = "#e1e8ef",); //中景，y值-400~-525
Tachie.Create(name = "Yusuke", image = "B05_草加裕介/A01_平静.png", scale = 1, x = 0, y = -525, alpha = 0, multiply = "#e1e8ef",); //中景，y值-400~-525
Tachie.Create(name = "Sofa", image = "D02_菅田敏之/Z01_沙发前.png", scale = 0.55, x = 0, y = 0, alpha = 0, multiply = "#ffffff",); //竖条
Tachie.Create(name = "Daisuke", image = "D06_荻原大辅/A01.png", scale = 1, x = 0, y = -500, alpha = 0, multiply = "#798280",); //中景，y值-400~-525
Tachie.Create(name = "Masashi", image = "D04_森川雅史/A04_严肃.png", scale = 1, x = -350, y = -500, alpha = 0, multiply = "#798280",); //中景靠左
Tachie.Create(name = "Satoshi", image = "D05_早津智/A01_平淡.png", scale = 1, x = 350, y = -450, alpha = 0, multiply = "#798280",); //中景靠右
Tachie.Create(name = "ToshiyukiM", image = "D02_菅田敏之/A05_严肃.png", scale = 1, x = 0, y = -525, alpha = 0, multiply = "#798280",); //中景，y值-400~-525
//立绘创建

BGM.Set(audio = "//BGM/D04-线索分析.mp3", volume = 0.7,);
Picture.CoveringIn(name = "Far", direction = "left", time = 1,);
//立绘平移入场（从景深）
SE.Play(audio = "//SE/D_脚步声/03_急促的脚步声.ogg", volume = 1,);
cmd_block
{
    at 0, Tachie.Move(name = "Izumi", x_began = 210, y_began = -200, x_ended = 0, y_ended = -425, scale_began = 0.8, scale_ended = 1, time = 1, curve = "ease_out",);
    at 0, Tachie.Alpha(name = "Izumi", alpha_began = 0, alpha_ended = 1, time = 1,);
}
//立绘平移入场（从景深）
Text.Show();
Script.Text(name = "菅田 泉美", dialogue = "警官先生，这、这是怎么了？我家先生他犯什么事了吗？", );

WaitForClick();
Script.Text(dialogue = "刚一上楼，一名年轻女子就急匆匆地朝草加跑了过来，菅田敏之跟在她身后拼命地想拦住她。",);

WaitForClick();
SE.Stop();
//菅田敏之追上菅田泉美
cmd_block
{
    at 0, Tachie.Move(name = "Izumi", x_began = 0, y_began = -425, x_ended = -200, y_ended = -425, time = 0.8, curve = "ease_out",);
    at 0, Tachie.Move(name = "Toshiyuki", x_began = 210, y_began = -350, x_ended = 200, y_ended = -525, scale_began = 0.8, scale_ended = 1, time = 0.8, curve = "ease_out",);
    at 0, Tachie.Alpha(name = "Toshiyuki", alpha_began = 0, alpha_ended = 1, time = 0.5,);
    at 0, Script.Text(name = "菅田 敏之", dialogue = "泉美，你干嘛啊！都说了是隔壁发生了案子，跟我们家没关系！", );
}

WaitForClick();
Tachie.Multiply(name = "Toshiyuki", factor = 0.4,);
Script.Expression(name = "Izumi", image = "D03_菅田泉美/A06_失望.png", textname = "菅田 泉美", dialogue = "你放开！",);

WaitForClick();
cmd_block
{
    at 0, Tachie.Hide(name = "Toshiyuki",);
    at 0, Tachie.Hide(name = "Izumi",);
    at 0, Script.Text(dialogue = "菅田泉美烦躁地一把将丈夫的手甩开，没有听他讲话。",);
}
Tachie.Multiply(name = "Toshiyuki", factor = 2.5,);

WaitForClick();
Script.CharacterShow(name = "Yusuke", image = "B05_草加裕介/A08_苦笑.png", textname = "草加 裕介", dialogue = "这位女士，请您不要激动，您的丈夫没犯什么事。是303室发生了一起谋杀案，他是我们重要的目击证人。",);

WaitForClick();
Tachie.Set(name = "Izumi", scale = 1, x = -50, y = -425,);
Script.Character(nameA = "Yusuke", nameB = "Izumi", imageB = "D03_菅田泉美/A07_恐慌.png", textname = "菅田 泉美", dialogue = "<size=42>谋、谋、谋杀案！？</size>",);

WaitForClick();
//菅田泉美颤抖，撞上身后的菅田敏之
Tachie.Set(name = "Toshiyuki", scale = 1, x = 220, y = -525,);
SE.Play(audio = "//SE/D_脚步声/01_后退两步.ogg", volume = 1,);
cmd_block
{
    at 0, Tachie.Vibrate("Izumi", "medium");
    at 0.3, Tachie.Move(name = "Izumi", x_began = -50, x_ended = 50, time = 0.2, curve = "uniform");
    at 0.5, Tachie.Show(name = "Toshiyuki", image = "D02_菅田敏之/A03_吃惊.png",);
    at 0.8, Script.Text(dialogue = "菅田泉美有些踉跄地后退了两步，被丈夫从身后扶住了。",);
}

WaitForClick();
Tachie.Multiply(name = "Toshiyuki", factor = 0.4,);
Script.Expression(name = "Izumi", image = "D03_菅田泉美/A03_害怕.png", textname = "菅田 泉美", dialogue = "不行……我我我今晚不要在家睡了，让我出去！",);

WaitForClick();
Script.SpeakerHide(nameA = "Toshiyuki", nameB = "Izumi", time = 0.2, textname = "", textname = "", dialogue = "",);
Script.CharacterShow(name = "Yusuke", image = "B05_草加裕介/A14_感兴趣.png", textname = "草加 裕介", dialogue = "您不用慌张，我们警方会一整晚守在公寓周围，您待在家中是不会有危险的。",);

WaitForClick();
Tachie.Set(name = "Toshiyuki", scale = 1, x = 0, y = -525,);
Script.Character(nameA = "Yusuke", nameB = "Toshiyuki", imageB = "D02_菅田敏之/A02_赔笑.png", textname = "菅田 敏之", dialogue = "对呀，你害怕什么呀，有我在家呢，坏人闯不进来。",);

WaitForClick();
Text.Clear();
Tachie.Hide(name = "Toshiyuki", time = 0.2,);
//菅田泉美躲到草加裕介身后
Tachie.Set(name = "Yusuke", scale = 1, x = -100, y = -525,);
Tachie.Show(name = "Yusuke", image = "B05_草加裕介/A02_微笑.png", time = 0.2,);
Tachie.Change(name = "Izumi", image = "D03_菅田泉美/A04_不悦.png", time = 0.2, );
WaitCommand(0.3);
cmd_block
{
    at 0, Tachie.Move(name = "Izumi", x_began = 380, x_ended = 180, time = 0.5, curve = "ease_out",);
    at 0, Tachie.Show(name = "Izumi",);
}
Script.Text(dialogue = "然而菅田泉美依然表现得十分恐慌，她一个闪身躲到草加身后，用警戒的目光瞪向了自己的丈夫。",);

WaitForClick();
Tachie.Multiply(name = "Yusuke", factor = 0.4,);
Script.Text(name = "菅田 泉美", dialogue = "那你解释清楚！电话里的那个声音是怎么回事！", );

WaitForClick();
Script.SpeakerHide(nameA = "Yusuke", nameB = "Izumi", time = 0.2, textname = "", textname = "", dialogue = "",);
Script.CharacterShow(name = "Toshiyuki", textname = "菅田 敏之", dialogue = "不是，我解释了呀！那不是楼下一群学生开派对闹出的动静……吗……？",);

WaitForClick();
Script.Expression(name = "Toshiyuki", image = "D02_菅田敏之/A06_惊慌.png", textname = "", dialogue = "说着说着，菅田敏之突然迟疑了起来。",);

WaitForClick();
Tachie.Set(name = "Yusuke", scale = 1, x = 0, y = -525,);
Script.Character(nameA = "Toshiyuki", nameB = "Yusuke", imageB = "B05_草加裕介/A01_平静.png", textname = "草加 裕介", dialogue = "怎么回事？您今晚在电话中听到过什么可疑的声音吗？",);

WaitForClick();
Tachie.Set(name = "Izumi", scale = 1, x = 0, y = -425,);
Script.Character(nameA = "Yusuke", nameB = "Izumi", textname = "菅田 泉美", dialogue = "我今晚临时有事，一直在公司加班，刚一回家就看到门口停满了警车。",);

WaitForClick();
Script.Text(name = "菅田 泉美", dialogue = "我大概<b>9点左右</b>给敏君打过视频电话，那个时候我分明听到了有人砸墙和打碎玻璃的声音！", );

WaitForClick();
Script.Expression(name = "Izumi", image = "D03_菅田泉美/A06_失望.png", textname = "菅田 泉美", dialogue = "我就知道开派对不会砸墙砸玻璃！警察先生，他在骗我！",);

WaitForClick();
Script.Character(nameA = "Izumi", nameB = "Toshiyuki", imageB = "D02_菅田敏之/A02_赔笑.png", textname = "", dialogue = "菅田敏之的表情哭笑不得。",);

WaitForClick();
Script.Text(avater = "", name = "菅田 敏之", dialogue = "那就是我搞错了呗，203室就在303室楼下，我误以为声音是从楼下传来的不是很正常吗？这哪里说谎了……",);

WaitForClick();
Script.Character(nameA = "Toshiyuki", nameB = "Yusuke", imageB = "B05_草加裕介/A19_谨慎.png", textname = "草加 裕介", dialogue = "也就是说，菅田泉美女士在晚上21时给丈夫打过一通电话，正好听到了隔壁屋传来的打斗声。",);

WaitForClick();
Script.Expression(name = "Yusuke", image = "B05_草加裕介/A18_敏锐.png", textname = "草加 裕介", dialogue = "而菅田敏之先生误以为是楼下大学生开派对的声音，所以当时没有在意，对吧？",);

WaitForClick();
Script.Character(nameA = "Yusuke", nameB = "Toshiyuki", imageB = "D02_菅田敏之/A01_平常.png", textname = "菅田 敏之", dialogue = "对的，就是这么回事。",);

WaitForClick();
Script.Text(avater = "", name = "", dialogue = "菅田敏之使劲点了点头。",);

WaitForClick();
Script.Character(nameA = "Toshiyuki", nameB = "Izumi", imageB = "D03_菅田泉美/A02_赌气.png", textname = "菅田 泉美", dialogue = "你发誓你没有在骗我。",);

WaitForClick();
Script.Character(nameA = "Izumi", nameB = "Toshiyuki", imageB = "D02_菅田敏之/A02_赔笑.png", textname = "菅田 敏之", dialogue = "我……我骗你干嘛呀，我难道还能是杀人凶手不成？泉美你到底有多不信任我啊……",);

WaitForClick();
Script.Character(nameA = "Toshiyuki", nameB = "Yusuke", imageB = "B05_草加裕介/A14_感兴趣.png", textname = "草加 裕介", dialogue = "请问两位有留存当时的通话录音吗？",);

WaitForClick();
Script.Character(nameA = "Yusuke", nameB = "Izumi", imageB = "D03_菅田泉美/A05_无聊.png", textname = "菅田 泉美", dialogue = "我有，不过是通话录像，平时工作需要我每次视频电话或者视频会议都会录下来。",);

WaitForClick();
Script.CharacterHide(name = "Izumi", textname = "", dialogue = "菅田泉美从包里拿出一台台<link=012><color=#0097ff>平板电脑</color></link>，找到了这段通话录像。",);

WaitForClick();
Text.Clear();
WaitCommand(0.2);
Picture.Alpha(name = "Video", alpha_began = 0, alpha_ended = 1, time = 0.5,);
BGM.Volume(volume_began = 0.7, volume_ended = 0.35, time = 0.3,);
//竖条入场（从下方）
cmd_block
{
    at 0, Tachie.Move(name = "Sofa", x_began = 0, y_began = -300, x_ended = 0, y_ended = 0, time = 0.5, curve = "ease_out",);
    at 0, Tachie.Alpha(name = "Sofa", alpha_began = 0, alpha_ended = 1, time = 0.5,);
}
//竖条入场（从下方）
Script.Text(avater = "蓝/D03_菅田泉美/A05_无聊.png", name = "菅田 泉美", dialogue = "喂，敏君，你现在在什么地方？没有出门干坏事吧？", );

WaitForClick();
Script.Text(avater = "蓝/D02_菅田敏之/A02_赔笑.png", name = "菅田 敏之", dialogue = "没有，我当然在家！我没事大半夜出门干嘛？", );

WaitForClick();
Script.Text(avater = "蓝/D03_菅田泉美/A02_赌气.png", name = "菅田 泉美", dialogue = "这样啊，我看你包里带了瓶香水还以为你晚上要出去见人呢。", );

WaitForClick();
Tachie.Multiply(name = "Sofa", factor = 0.4,);
Script.Text(dialogue = "这是……妻子怀疑丈夫有外遇，所以打电话突击检查吗？", );

WaitForClick();
Script.Text(dialogue = "从背景来看，菅田敏之确实是在家里，但两人还是在电话中拉扯了半天。", );

WaitForClick();
Script.Text(dialogue = "然后，就在通话录音显示的时间来到<b>20时55分</b>的时候——", );

WaitForClick();
Text.Hide();
SE.Play(audio = "//SE/I-器件音/03_303的打斗声.ogg", volume = 1,);
WaitCommand(2.5);
Text.Show();
Tachie.Multiply(name = "Sofa", factor = 2.5,);
Tachie.Vibrate("Sofa", "weak");
Script.Text(avater = "蓝/D02_菅田敏之/A03_吃惊.png", name = "菅田 敏之", dialogue = "<size=38>！？</size>", );

WaitForClick();
Script.Text(dialogue = "背景中突然传来了嘈杂的声响。", );

WaitForClick();
Script.Text(dialogue = "是椅子倒地和花瓶破碎的声音。", );

WaitForClick();
Script.Text(dialogue = "菅田敏之被吓得一抖，回头看了一眼。", );

WaitForClick();
Script.Text(avater = "蓝/D03_菅田泉美/A04_不悦.png", name = "菅田 泉美", dialogue = "你那边在干嘛啊？怎么这么吵？", );

WaitForClick();
Script.Text(avater = "蓝/D02_菅田敏之/A08_平淡.png", name = "菅田 敏之", dialogue = "是楼下那两个大学生租户搞出来的动静吧，他们好像在家里开派对。", );

WaitForClick();
//竖条离场（向上方）
cmd_block
{
    at 0, Tachie.Move(name = "Sofa", x_began = 0, y_began = 0, x_ended = 0, y_ended = 300, time = 0.5, curve = "ease_in");
    at 0, Tachie.Alpha(name = "Sofa", alpha_began = 1, alpha_ended = 0, time = 0.5,);
    at 0, Script.Text(dialogue = "菅田敏之站起身来离开了镜头一段时间，不过没多久又回来了。", );
}
//竖条离场（向上方）

WaitForClick();
//竖条入场（从上方）
cmd_block
{
    at 0, Tachie.Move(name = "Sofa", x_began = 0, y_began = 300, x_ended = 0, y_ended = 0, time = 0.5, curve = "ease_out",);
    at 0, Tachie.Alpha(name = "Sofa", alpha_began = 0, alpha_ended = 1, time = 0.5,);
    at 0, Script.Text(avater = "蓝/D02_菅田敏之/A01_平常.png", name = "菅田 敏之", dialogue = "啊，马上Akatsuki君要开始直播了，没什么事的话我先挂啦！", );
}
//竖条入场（从上方）

WaitForClick();
Script.Text(avater = "蓝/D03_菅田泉美/A06_失望.png", name = "菅田 泉美", dialogue = "喂，等等啊，喂——！", );
Tachie.Change(name = "Sofa", image = "D02_菅田敏之/Z02_沙发前.png", time = 0, );

WaitForClick();
Text.Clear();
SE.Play(audio = "//SE/A_系统音效/09_退出界面.ogg", volume = 0.7,);
cmd_block
{
    at 0, Picture.Alpha(name = "Video", alpha_began = 1, alpha_ended = 0, time = 0.5,);
    at 0, Tachie.Alpha(name = "Sofa", alpha_began = 1, alpha_ended = 0, time = 0.5,);
    at 0, BGM.Volume(volume_began = 0.35, volume_ended = 0.7, time = 0.5,);
}
Script.CharacterShow(name = "Izumi", image = "D03_菅田泉美/A04_不悦.png", textname = "菅田 泉美", dialogue = "你看，他听到响声后还离开了一段时间，这不是去确认声音来源了吗？怎么会没发现隔壁出人命了？",);

WaitForClick();
Script.Character(nameA = "Izumi", nameB = "Toshiyuki", imageB = "D02_菅田敏之/A03_吃惊.png", textname = "菅田 敏之", dialogue = "啊？我没有想确认声音来源啊，我只是站起来喝口水，不到十五秒就回来了!",);

WaitForClick();
Script.Expression(name = "Toshiyuki", image = "D02_菅田敏之/A02_赔笑.png", textname = "菅田 敏之", dialogue = "听到打斗声时我人在家里坐得好好的，这不正好是我的不在场证明吗？我有什么好怀疑的？",);

WaitForClick();
Script.Character(nameA = "Toshiyuki", nameB = "Izumi", imageB = "D03_菅田泉美/A02_赌气.png", textname = "菅田 泉美", dialogue = "哼……",);

WaitForClick();
Script.Text(avater = "", name = "", dialogue = "菅田泉美气鼓鼓地别过了头去。",);

WaitForClick();
Script.Character(nameA = "Izumi", nameB = "Yusuke", imageB = "B05_草加裕介/A19_谨慎.png", textname = "草加 裕介", dialogue = "…………",);

WaitForClick();
Script.Expression(name = "Yusuke", image = "B05_草加裕介/A02_微笑.png", textname = "草加 裕介", dialogue = "感谢两位提供的线索，这对于警方确定被害人死亡时间很有帮助。",);

WaitForClick();
Script.Character(nameA = "Yusuke", nameB = "Toshiyuki", imageB = "D02_菅田敏之/A02_赔笑.png", textname = "菅田 敏之", dialogue = "草加警官，您别介意啊。泉美平时就有些多疑，我真没有刻意隐瞒什么，请你们一定要相信我的证词。",);

WaitForClick();
Script.Character(nameA = "Toshiyuki", nameB = "Izumi", textname = "菅田 泉美", dialogue = "我没有多疑！是敏君你总是把我当小孩子哄！",);

WaitForClick();
Text.Clear();
Tachie.BackandForce(name = "Izumi", oy = -425, y = 40, time = 0.2, curve = "uniform");
Tachie.BackandForce(name = "Izumi", oy = -425, y = 40, time = 0.2, curve = "uniform");
//立绘平移离场（向景深）
SE.Play(audio = "//SE/D_脚步声/07_急促的脚步声淡出.ogg", volume = 1,);
cmd_block
{
    at 0, Tachie.Move(name = "Izumi", x_began = 0, y_began = -425, x_ended = 180, y_ended = -250, scale_began = 1, scale_ended = 0.8, time = 1, curve = "ease_in");
    at 0, Tachie.Alpha(name = "Izumi", alpha_began = 1, alpha_ended = 0, time = 1,);
    at 0, Script.Text(dialogue = "菅田泉美愤愤地跺了跺脚，然后就没再理会丈夫，一个人闷闷不乐地回房去了。",);
}
//立绘平移离场（向景深）

WaitForClick();
Script.CharacterShow(name = "Yusuke", image = "B05_草加裕介/A02_微笑.png", textname = "草加 裕介", dialogue = "那么，菅田先生，可否借一步说话？关于发现案发现场的细节，我还有些问题想问你。",);

WaitForClick();
cmd_block
{
    at 0, Text.Hide();
    at 0, Tachie.Hide("Yusuke");
}
Picture.CoveringOut(name = "Far", direction = "right", time = 0.75,);
Tachie.Multiply(name = "Yusuke", color = "#e5e5e5",);
Tachie.Multiply(name = "Toshiyuki", color = "#e5e5e5",);
WaitCommand(1);
Picture.CoveringIn(name = "Near", direction = "left", time = 0.75,);
cmd_block
{
    at 0, Text.Show();
    at 0, Script.CharacterShow(name = "Yusuke", image = "B05_草加裕介/A01_平静.png", textname = "草加 裕介", dialogue = "菅田先生，我就开门见山地问了，在发现303室门上的魔法阵图案后，第一个提出要把门撞开的就是你吧？",);
}

WaitForClick();
Script.Character(nameA = "Yusuke", nameB = "Toshiyuki", imageB = "D02_菅田敏之/A02_赔笑.png", textname = "菅田 敏之", dialogue = "是我没错。",);

WaitForClick();
//重点提示（打断BGM）
cmd_block
{
    at 0, Script.Character(nameA = "Toshiyuki", nameB = "Yusuke", imageB = "B05_草加裕介/A17_怀疑.png", textname = "草加 裕介", dialogue = "那，<b>你为什么没有想到去先去请示一下房东吉田雪绘女士呢？</b>",);
    at 0.5, SE.Play(audio = "//SE/G_氛围音/05_重点提示.ogg", volume = 0.6, loop = false, );
    at 0.5, BGM.Stop();
}
//重点提示（打断BGM）


WaitForClick();
Script.Character(nameA = "Yusuke", nameB = "Toshiyuki", imageB = "D02_菅田敏之/A03_吃惊.png", textname = "菅田 敏之", dialogue = "啊？",);

WaitForClick();
Script.Character(nameA = "Toshiyuki", nameB = "Yusuke", imageB = "B05_草加裕介/A18_敏锐.png", textname = "", dialogue = "菅田敏之愣住了，他抬起头，只见到草加裕介看向自己的目光突然变得锋利如剑。",);

WaitForClick();
Tachie.Hide(name = "Yusuke", time = 0.2,);
BGM.Set(audio = "//BGM/E01-思维螺旋.mp3", volume = 0.7,);
//对手戏演出预备
Picture.Create(name = "bgR", image = "//背景/B_第一章/07D_鸦巢公寓三楼走廊_303室门口_夜晚亮灯.png", scale = 1.5, x = -840, y = 0, alpha = 0,);
Picture.Create(name = "bgL", image = "//背景/B_第一章/07D_鸦巢公寓三楼走廊_303室门口_夜晚亮灯.png", scale = 1.5, x = 840, y = 0, alpha = 0,);
Tachie.Create(name = "tcR", image = "D02_菅田敏之/A04_心虚.png", scale = 1.5, x = 400, y = -1024, alpha = 0, multiply = "#E5E5E5",);
Tachie.Create(name = "tcL", image = "B05_草加裕介/A18_敏锐.png", scale = 1.5, x = -400, y = -1024, alpha = 0, multiply = "#E5E5E5",);
//对手戏演出预备
cmd_block
{
    at 0, Script.KeepMoveShow(bg = "bgR", tc = "tcR", tcimage = "D02_菅田敏之/A04_心虚.png", direction = "right", bgx = -840, bgy = 0, tcx = 400, tcy = -1024,);
    at 0, Script.Text(name = "菅田 敏之", dialogue = "我……不，我怎么会知道雪绘姐手里有303室的钥匙？我又没有钥匙需要放在房东那儿保管。",);
}

WaitForClick();
cmd_block
{
    at 0, Script.KeepMoveAbove(bgh = "bgR", tch = "tcR", bg = "bgL", tc = "tcL", tcimage = "B05_草加裕介/A18_敏锐.png", direction = "left", bgx = 840, bgy = 0, tcx = -400, tcy = -1024,);
    at 0, Script.Text(name = "草加 裕介", dialogue = "原来如此。那为什么你能一时间反应过来要撞门呢？就好像已经知道303室里有人需要急救一样。",);
}

WaitForClick();
cmd_block
{
    at 0, Script.KeepMoveBelow(bgh = "bgL", tch = "tcL", bg = "bgR", tc = "tcR", tcimage = "D02_菅田敏之/A06_惊慌.png", direction = "right", bgx = -840, bgy = 0, tcx = 400, tcy = -1024,);
    at 0, Script.Text(name = "菅田 敏之", dialogue = "这、这是什么意思？",);
}

WaitForClick();
cmd_block
{
    at 0, Script.KeepMoveAbove(bgh = "bgR", tch = "tcR", bg = "bgL", tc = "tcL", tcimage = "B05_草加裕介/A20_迫视.png", direction = "left", bgx = 840, bgy = 0, tcx = -400, tcy = -1024,);
    at 0, Script.Text(name = "", dialogue = "草加裕介眯起眼，以居高临下的姿态直视着菅田敏之的双眼。",);
}

WaitForClick();
cmd_block
{
    at 0, Script.KeepMoveHide(bg = "bgR", tc = "tcR", time = 0,);
    at 0, Script.KeepMoveHide(bg = "bgL", tc = "tcL", time = 1,);
    at 0, Script.Text(name = "", dialogue = "没错，我也察觉到了，菅田敏之<b>刚刚说了句谎</b>。",);
}

WaitForClick();
//回忆转场
Text.Hide();
cmd_block
{
    at 0, BGM.Volume(volume_began = 0.7, volume_ended = 0.35, time = 0.6,);
    at 0, SE.Play(audio = "//SE/A_系统音效/15_回忆转场.ogg", volume = 0.3,);
    at 0, Camera.SparkingWhite(0.3);
    at 0.3, Filter.MemoryOn();
    at 0.3, Picture.Alpha(name = "Memory", alpha_began = 0, alpha_ended = 1, time = 0,);
    at 0.3, Tachie.Show(name = "Masashi", image = "D04_森川雅史/A04_严肃.png", alpha = 1, time = 0,);
    at 0.3, Tachie.Show(name = "Satoshi", image = "D05_早津智/A01_平淡.png", alpha = 1, time = 0,);
    at 0.3, Tachie.Multiply(name = "Satoshi", factor = 0.4,);
    at 0.3, Camera.WhiteRestore(0.3);
    at 0.3, WaitCommand(0.3);
}
Text.Show();
//回忆转场
Script.Dialogue(name = "森川 雅史", dialogue = "发生什么事了？",);

WaitForClick();
Script.SpeakerHide(nameA = "Satoshi", nameB = "Masashi", time = 0.2,);
Script.CharacterShow(name = "ToshiyukiM", image = "D02_菅田敏之/A05_严肃.png", time = 0.2, textname = "菅田 敏之", dialogue = "你们几个，晚上有没有听到过桌椅倾倒和花瓶砸在地上的声音？",);

WaitForClick();
Script.Character(nameA = "ToshiyukiM", nameB = "Daisuke", imageB = "D06_荻原大辅/A01.png", textname = "荻原 大辅", dialogue = "我好像听到过，不过那不是你们两个小子搞出来的动静吗？",);

WaitForClick();
Tachie.Hide(name = "Daisuke", time = 0.2,);
Script.SpeakerShow(nameA = "Satoshi", nameB = "Masashi", time = 0.2, textname = "早津 智", dialogue = "哈？我们？",);

WaitForClick();
Script.SpeakerHide(nameA = "Masashi", nameB = "Satoshi", time = 0.2,);
Script.CharacterShow(name = "Daisuke", time = 0.2, textname = "荻原 大辅", dialogue = "不是你们聚了群小年轻在房间里搞派对吗？吵吵嚷嚷的。",);

WaitForClick();
Tachie.Hide(name = "Daisuke", time = 0.2,);
Script.SpeakerShow(nameA = "Satoshi", nameB = "Masashi", time = 0.2, textname = "早津 智", dialogue = "喂，大叔，你有没有搞错啊？我们是开派对又不是打架，怎么会敲桌子砸板凳啊？",);

WaitForClick();
Script.SpeakerHide(nameA = "Masashi", nameB = "Satoshi", time = 0.2,);
Script.CharacterShow(name = "ToshiyukiM", image = "D02_菅田敏之/A05_严肃.png", time = 0.2, textname = "菅田 敏之", dialogue = "别争了。那应该是303室传出的声响，这间屋子出事了。",);

WaitForClick();
Text.Clear();
//回忆转场
cmd_block
{
    at 0, SE.Play(audio = "//SE/A_系统音效/15_回忆转场.ogg", volume = 0.3,);
    at 0, Camera.SparkingWhite(0.3);
    at 0.3, Picture.Change(name = "Memory", image = "//背景/B_第一章/07B_鸦巢公寓三楼走廊_楼梯口_夜晚.png", time = 0,);
    at 0.3, Tachie.Set(name = "Izumi", scale = 1, x = 0, y = -425,);
    at 0.3, Tachie.Show(name = "Izumi", image = "D03_菅田泉美/A04_不悦.png", alpha = 1, time = 0,);
    at 0.3, Tachie.Hide(name = "ToshiyukiM", time = 0,);
    at 0.3, Tachie.Multiply(name = "ToshiyukiM", color = "#e1e8ef",);
    at 0.3, Camera.WhiteRestore(0.3);
    at 0.3, WaitCommand(0.3);
}
//回忆转场
Script.Dialogue(name = "菅田 泉美", dialogue = "那你解释清楚！电话里的那个声音是怎么回事！",);

WaitForClick();
Script.Character(nameA = "Izumi", nameB = "ToshiyukiM", imageB = "D02_菅田敏之/A02_赔笑.png", textname = "菅田 敏之", dialogue = "不是，我解释了呀！那不是楼下一群学生开派对闹出的动静……吗……？",);

WaitForClick();
Script.Expression(name = "ToshiyukiM", image = "D02_菅田敏之/A06_惊慌.png", textname = "", dialogue = "",);
WaitCommand(0.5);
//回忆转场反
Text.Hide();
cmd_block
{
    at 0, BGM.Volume(volume_began = 0.35, volume_ended = 0.7, time = 0.6,);
    at 0, SE.Play(audio = "//SE/A_系统音效/16_回忆转场反.ogg", volume = 0.3,);
    at 0, Camera.SparkingWhite(0.3);
    at 0.3, Filter.MemoryOff();
    at 0.3, Picture.Alpha(name = "Memory", alpha_began = 1, alpha_ended = 0, time = 0,);
    at 0.3, Tachie.Hide(name = "ToshiyukiM", time = 0,);
    at 0.3, Camera.WhiteRestore(0.3);
    at 0.3, WaitCommand(0.3);
}
Text.Show();
//回忆转场反
Script.Text(dialogue = "那个时候，菅田敏之已经反应过来自己听到的声音是303室内的打斗声了，所以才会第一时间想到撞门。",);

WaitForClick();
Script.Text(dialogue = "可在刚刚，他却假装自己是才想起来这件事。",);

WaitForClick();
cmd_block
{
    at 0, Script.KeepMoveShow(bg = "bgR", tc = "tcR", tcimage = "D02_菅田敏之/A03_吃惊.png", direction = "right", bgx = -840, bgy = 0, tcx = 400, tcy = -1024,);
    at 0, Script.Text(name = "菅田 敏之", dialogue = "我……",);
}

WaitForClick();
cmd_block
{
    at 0, Script.KeepMoveAbove(bgh = "bgR", tch = "tcR", bg = "bgL", tc = "tcL", tcimage = "B05_草加裕介/A18_敏锐.png", direction = "left", bgx = 840, bgy = 0, tcx = -400, tcy = -1024,);
    at 0, Script.Text(name = "草加 裕介", dialogue = "菅田先生，在指责妻子多疑之前，建议您还是先改改自己不诚实的坏毛病吧。",);
}

WaitForClick();
cmd_block
{
    at 0, Tachie.Hide(name = "tcL", time = 0.5,);
    at 0, Script.Text(name = "", dialogue = "说罢，草加便抛下原地发愣的菅田，自己一人快步走下楼去了。",);
    at 0.5, Tachie.StopMove("tcL");
}

WaitForClick();
cmd_block
{
    at 0, Script.KeepMoveHide(bg = "bgR", tc = "tcR", time = 0,);
    at 0, Script.KeepMoveShow(bg = "bgR", tc = "tcR", tcimage = "D02_菅田敏之/A04_心虚.png", direction = "right", bgx = -840, bgy = 0, tcx = 400, tcy = -1024, time = 0,);
    at 0, Picture.Alpha(name = "bgL", alpha_began = 1, alpha_ended = 0, time = 0.5,);
    at 0, Script.Text(name = "菅田 敏之", dialogue = "什么……意思嘛……", speed = 10,);
    at 0.5, Picture.StopMove("bgL");
}

WaitForClick();
cmd_block
{
    at 0, Script.KeepMoveHide(bg = "bgR", tc = "tcR", time = 1,);
    at 0, Text.Hide();
}
cmd_block
{
    at 0, Picture.CoveringOut(name = "Near", direction = "up", time = 0.5,);
    at 0, BGM.Volume(volume_began = 0.7, volume_ended = 0, time = 0.5,);
}
WaitCommand(0.5);

//读档标记点
ClearScene();

//————————————————————
//———————二楼住户—————————
//————————————————————

SetUIMode(3);
SetChapter("01", "边界徘徊的七等星");
BGM.Stop();
CanSkip(true);
CanAuto(true);

//背景创建
Picture.Create(name = "201", image = "//背景/B_第一章/06A_鸦巢公寓二楼走廊_201室房门.png", scale = 1, x = 0, y = 0, alpha = 0,);
Picture.Create(name = "202", image = "//背景/B_第一章/06D_鸦巢公寓二楼走廊_202室房门.png", scale = 1, x = 0, y = 0, alpha = 0,);
Picture.Create(name = "203", image = "//背景/B_第一章/06E_鸦巢公寓二楼走廊_203室房门.png", scale = 1, x = 0, y = 0, alpha = 0,);
Picture.Create(name = "Room", image = "//背景/B_第一章/02B_鸦巢公寓物业室_夜晚.png", scale = 1, x = 0, y = 0, alpha = 0,);
//背景创建

//立绘创建
Tachie.Create(name = "Yusuke", image = "B05_草加裕介/A01_平静.png", scale = 1, x = 0, y = -525, alpha = 0, multiply = "#D2CEC9",); //中景，y值-400~-525
Tachie.Create(name = "Police", image = "F组/F02_女警察.png", scale = 1, x = 0, y = -475, alpha = 0, multiply = "#D2CEC9",); //中景，y值-400~-525
Tachie.Create(name = "Daisuke", image = "D06_荻原大辅/A01.png", scale = 1, x = 0, y = -500, alpha = 0, multiply = "#F6F6F6",); //中景，y值-400~-525
Tachie.Create(name = "Satoshi", image = "D05_早津智/A01_平淡.png", scale = 1, x = 0, y = -450, alpha = 0, multiply = "#E0E0E0",);  //中景，y值-400~-525
Tachie.Create(name = "Kenichiro", image = "D07_坂丘健一郎/A01.png", scale = 1, x = 0, y = -450, alpha = 0, multiply = "#D2CEC9",);  //中景，y值-400~-525
Tachie.Create(name = "Hidekazu", image = "D01_本马秀和/A01_平常.png", scale = 1, x = 0, y = -400, alpha = 0, multiply = "#F0F0DE",); //中景，y值-400~-525
//立绘创建

BGM.Set(audio = "//BGM/B04-会议记录.mp3", volume = 0.7,);
Picture.CoveringIn(name = "201", direction = "down", time = 0.5,);
Text.Show();
Script.Text(dialogue = "在二楼，草加裕介迎面遇上了从一楼上来的女警官。",);

WaitForClick();
Script.CharacterShow(name = "Police", textname = "女警员", dialogue = "草加警官，监控室那边找到了重要线索，正打算请你去一趟呢！",);

WaitForClick();
Script.Character(nameA = "Police", nameB = "Yusuke", imageB = "B05_草加裕介/A01_平静.png", textname = "草加 裕介", dialogue = "我知道了，稍等我一会儿。让监控室那边先别急，着重检查一下<b>20时55分</b>前后的公寓监控录像，被害人很可能是这段时间里遇害的！",);

WaitForClick();
Script.Character(nameA = "Yusuke", nameB = "Police", textname = "女警员", dialogue = "是。",);

WaitForClick();
SE.Play(audio = "//SE/D_脚步声/07_急促的脚步声淡出.ogg", volume = 0.8, loop = false,);
cmd_block
{
    at 0, Script.CharacterHide(name = "Police", time = 0.7, textname = "", dialogue = "",);
    at 0, Tachie.Position(name = "Police", x_began = 0, x_ended = 300, time = 0.7, curve = "ease_in");
    at 0, Text.Hide();
}
Picture.CoveringOut(name = "201", direction = "left", time = 0.5,);
WaitCommand(0.3);
Picture.CoveringIn(name = "203", direction = "right", time = 0.5,);
Text.Show();
Script.Text(dialogue = "草加裕介来到大学生合租的203室门前，正打算敲门时，隔壁202室的房门打开了。",);

WaitForClick();
Text.Clear();
SE.Play(audio = "//SE/B_开关门/06_鸦巢公寓开门声.ogg", volume = 0.8,);
Picture.CoveringOut(name = "203", direction = "right", time = 0.5,);
Picture.CoveringIn(name = "202", direction = "left", time = 0.5,);
Script.CharacterShow(name = "Daisuke", textname = "荻原 大辅", dialogue = "啊，草加警官。",);

WaitForClick();
Tachie.Multiply(name = "Yusuke", color = "#F6F6F6",);
Script.Character(nameA = "Daisuke", nameB = "Yusuke", imageB = "B05_草加裕介/A02_微笑.png", textname = "草加 裕介", dialogue = "你是……荻原大辅先生吧？正好，我刚打算找您。",);

WaitForClick();
Script.Character(nameA = "Yusuke", nameB = "Daisuke", textname = "荻原 大辅", dialogue = "是要问我今晚的行踪吗？我一整晚都一个人在家，除了被本马君喊上去的那次以外没上过楼。可惜没人能证明我在家。",);

WaitForClick();
Script.Character(nameA = "Daisuke", nameB = "Yusuke", imageB = "B05_草加裕介/A02_微笑.png", textname = "草加 裕介", dialogue = "哦，这个您不必担心，二楼的走廊监控是正常运行的，您没有出过门的事监控可以证明。",);

WaitForClick();
Script.Expression(name = "Yusuke", image = "B05_草加裕介/A01_平静.png", textname = "草加 裕介", dialogue = "请问一下，<b>20时55分</b>前后，你是否有听到屋外传来过搏斗声？",);

WaitForClick();
Script.Character(nameA = "Yusuke", nameB = "Daisuke", textname = "荻原 大辅", dialogue = "嗯……我确实听到过疑似搏斗的声响，但具体什么时间我记不清了。",);

WaitForClick();
Script.Character(nameA = "Daisuke", nameB = "Yusuke", imageB = "B05_草加裕介/A01_平静.png", textname = "草加 裕介", dialogue = "你听到的声音，是这样的吗？",);

WaitForClick();
Tachie.Multiply(name = "Yusuke", factor = 0.4,);
SE.Play(audio = "//SE/I-器件音/03_303的打斗声.ogg", volume = 1,);
WaitCommand(3);
Tachie.Multiply(name = "Yusuke", factor = 2.5,);
Script.Text(dialogue = "草加裕介用BMI播放了自己刚刚转录下来的菅田夫妇的通话录像片段。",);

WaitForClick();
SE.Stop();
Script.Character(nameA = "Yusuke", nameB = "Daisuke", textname = "荻原 大辅", dialogue = "啊，对！我想起来了，就是这个声音！我当时还以为是隔壁开派对的大学生们不小心撞翻了桌子。",);

WaitForClick();
Script.Character(nameA = "Daisuke", nameB = "Yusuke", imageB = "B05_草加裕介/A05_迟疑.png", textname = "草加 裕介", dialogue = "203室的大学生们，一整晚都这么吵吗？",);

WaitForClick();
Script.Character(nameA = "Yusuke", nameB = "Daisuke", textname = "荻原 大辅", dialogue = "倒也不是，我记得我有段时间被吵得受不了了，就给物业打了投诉电话，那之后他们就安分了不少。",);

WaitForClick();
Script.Character(nameA = "Daisuke", nameB = "Yusuke", imageB = "B05_草加裕介/A02_微笑.png", textname = "草加 裕介", dialogue = "好的，谢谢您的配合。",);

WaitForClick();
Script.Character(nameA = "Yusuke", nameB = "Daisuke", textname = "荻原 大辅", dialogue = "能帮到你们就好。",);

WaitForClick();
cmd_block
{
    at 0, Text.Clear();
    at 0, Tachie.Hide(name = "Daisuke",);
}
Picture.CoveringOut(name = "202", direction = "left", time = 0.5,);
WaitCommand(0.3);
Picture.CoveringIn(name = "203", direction = "right", time = 0.5,);
SE.Play(audio = "//SE/B_开关门/03_敲门声.ogg", volume = 0.8,);
Script.Text(dialogue = "询问完荻原大辅后，草加敲响了203室的房门。",);

WaitForClick();
Text.Clear();
SE.Play(audio = "//SE/B_开关门/06_鸦巢公寓开门声.ogg", volume = 0.8,);
Picture.Change(name = "203", image = "//背景/B_第一章/06F_鸦巢公寓二楼走廊_203室房门.png", time = 0.5, );
Tachie.Multiply(name = "Yusuke", color = "#E0E0E0",);
cmd_block
{
    at 0, Tachie.Position(name = "Satoshi", x_began = -180, x_ended = 0, time = 1, curve = "ease_out",);
    at 0, Script.CharacterShow(name = "Satoshi", time = 1, textname = "早津 智", dialogue = "啊，是警察。",);
}

WaitForClick();
Script.CharacterHide(name = "Satoshi", textname = "早津 智", time = 0.7, dialogue = "喂！森川，别打电话了！警察找你！",);

WaitForClick();
Script.CharacterShow(name = "Yusuke", image = "B05_草加裕介/A02_微笑.png", textname = "草加 裕介", dialogue = "不用麻烦您的室友了，我就问些简单的问题，耽误不了您几分钟的。",);

WaitForClick();
Script.Character(nameA = "Yusuke", nameB = "Satoshi", imageB = "D05_早津智/A02_疑惑.png", textname = "早津 智", dialogue = "啊？哦。那你快问吧。",);

WaitForClick();
Script.Character(nameA = "Satoshi", nameB = "Yusuke", imageB = "B05_草加裕介/A02_微笑.png", textname = "草加 裕介", dialogue = "你们今晚的派对来了几个人参加？从几点开到了几点？",);

WaitForClick();
Script.Character(nameA = "Yusuke", nameB = "Satoshi", imageB = "D05_早津智/A03_疑问.png", textname = "早津 智", dialogue = "几人？我数数……我、森川、崎尾、濑户、还有室村，吉田姐中途也来了，所以总共是六个人。",);

WaitForClick();
Script.Character(nameA = "Satoshi", nameB = "Yusuke", imageB = "B05_草加裕介/A01_平静.png", textname = "草加 裕介", dialogue = "吉田姐？你是说房东吉田雪绘？",);

WaitForClick();
Script.Character(nameA = "Yusuke", nameB = "Satoshi", imageB = "D05_早津智/A01_平淡.png", textname = "早津 智", dialogue = "是，她本来是来提醒我们不要扰民的，但大家听说她是是<link=013><color=#0097ff>ES5</color></link>开服老玩家，就把她拉进来一起玩了。",);

WaitForClick();
Script.Character(nameA = "Satoshi", nameB = "Yusuke", imageB = "B05_草加裕介/A17_怀疑.png", textname = "草加 裕介", dialogue = "…………",);

WaitForClick();
Script.Expression(name = "Yusuke", image = "B05_草加裕介/A01_平静.png", textname = "草加 裕介", dialogue = "好的，我明白了。那您今晚有没有听过这样的打斗声？",);

WaitForClick();
Tachie.Multiply(name = "Yusuke", factor = 0.4,);
SE.Play(audio = "//SE/I-器件音/03_303的打斗声.ogg", volume = 1,);
WaitCommand(3);
Tachie.Multiply(name = "Yusuke", factor = 2.5,);
Script.Text(dialogue = "草加裕介又播放了一次刚才的录音。",);

WaitForClick();
SE.Stop();
Script.Character(nameA = "Yusuke", nameB = "Satoshi", imageB = "D05_早津智/A02_疑惑.png", textname = "", dialogue = "然而，早津只是茫然地摇了摇头。",);

WaitForClick();
Script.Expression(name = "Satoshi", image = "D05_早津智/A01_平淡.png", textname = "早津 智", dialogue = "没听到过，我们一整晚大部分时间都开着着<link=014><color=#0097ff>VR沉浸模式</color></link>，外界的声音很难吵到我们。",);

WaitForClick();
Script.Character(nameA = "Satoshi", nameB = "Yusuke", imageB = "B05_草加裕介/A02_微笑.png", textname = "草加 裕介", dialogue = "可以了，谢谢您的配合。",);

WaitForClick();
cmd_block
{
    at 0, Text.Clear();
    at 0, Tachie.Hide(name = "Yusuke",);
}
Picture.CoveringOut(name = "203", direction = "right", time = 0.5,);
WaitCommand(0.3);
Picture.CoveringIn(name = "201", direction = "left", time = 0.5,);
Script.Text(dialogue = "最后，草加来到了201室的门口。",);

WaitForClick();
Script.Text(dialogue = "二楼的三户人家中，只有201室的住户我还一次都没有见过。",);

WaitForClick();
Script.Text(dialogue = "根据本马秀和的描述，这家住着的应该是一位性格乖僻的独居老人，名叫坂丘健一郎。",);

WaitForClick();
//回忆转场
Text.Hide();
cmd_block
{
    at 0, BGM.Volume(volume_began = 0.7, volume_ended = 0.35, time = 0.6,);
    at 0, SE.Play(audio = "//SE/A_系统音效/15_回忆转场.ogg", volume = 0.3,);
    at 0, Camera.SparkingWhite(0.3);
    at 0.3, Filter.MemoryOn();
    at 0.3, Picture.Alpha(name = "Room", alpha_began = 0, alpha_ended = 1, time = 0,);
    at 0.3, Tachie.Show(name = "Hidekazu", image = "D01_本马秀和/A01_平常.png", alpha = 1, time = 0,);
    at 0.3, Camera.WhiteRestore(0.3);
    at 0.3, WaitCommand(0.3);
}
Text.Show();
//回忆转场
Script.Text(name = "本马 秀和", dialogue = "坂丘先生啊……提起他我就头疼。",);

WaitForClick();
Script.Text(name = "本马 秀和", dialogue = "坂丘先生的物业费已经很久没交了，而且他的脾气还很臭，敲门总是不开，我们物业内部都没人愿意上他家门催收。",);

WaitForClick();
Script.Text(name = "本马 秀和", dialogue = "据说他以前还在马路上碰瓷过无人驾驶的汽车，最后居然还讹到了对方的钱——啊，这个我也只是道听途说，警官您千万别当真。",);

WaitForClick();
//回忆转场反
Text.Hide();
cmd_block
{
    at 0, BGM.Volume(volume_began = 0.35, volume_ended = 0.7, time = 0.6,);
    at 0, SE.Play(audio = "//SE/A_系统音效/16_回忆转场反.ogg", volume = 0.3,);
    at 0, Camera.SparkingWhite(0.3);
    at 0.3, Filter.MemoryOff();
    at 0.3, Picture.Alpha(name = "Room", alpha_began = 1, alpha_ended = 0, time = 0,);
    at 0.3, Tachie.Hide(name = "Hidekazu", time = 0,);
    at 0.3, Camera.WhiteRestore(0.3);
    at 0.3, WaitCommand(0.3);
}
Text.Show();
//回忆转场反
Script.Text(dialogue = "就是这样一个怪老头。",);

WaitForClick();
SE.Play(audio = "//SE/B_开关门/04_更大声的敲门.ogg", volume = 0.8,);
cmd_block
{
    at 0, Picture.Move(name = "201", x_began = 0, y_began = 0, x_ended = 250, y_ended = 50, scale_began = 1, scale_ended = 1.25, time = 0.5, curve = "uniform",);
    at 0, Script.Text(dialogue = "这一回，草加裕介把门敲得格外响。",);
}

WaitForClick();
Script.Text(avater = "蓝/B05_草加裕介/A02_微笑.png", name = "草加 裕介", dialogue = "坂丘老先生在吗？我是练马警察署的警察，有些事想打扰一下。",);

WaitForClick();
Script.Text(dialogue = "良久，门内没有回应。",);

WaitForClick();
Picture.Move(name = "201", x_began = 250, y_began = 50, x_ended = 0, y_ended = 0, scale_began = 1.25, scale_ended = 1, time = 0.5, curve = "uniform",);
Tachie.Multiply(name = "Yusuke", color = "#D2CEC9",);
Script.CharacterShow(name = "Yusuke", image = "B05_草加裕介/A07_麻烦.png", textname = "草加 裕介", dialogue = "不会已经睡了吧……",);

WaitForClick();
Script.CharacterHide(name = "Yusuke", textname = "", dialogue = "然而，就在草加打算离开时，门突然打开了。",);
SE.Play(audio = "//SE/B_开关门/06_鸦巢公寓开门声.ogg", volume = 0.8,);
Picture.Change(name = "201", image = "//背景/B_第一章/06B_鸦巢公寓二楼走廊_201室房门.png", time = 0.5, );

WaitForClick();
cmd_block
{
    at 0, Tachie.Move(name = "Kenichiro", x_began = -180, y_began = -420, x_ended = 0, y_ended = -450, scale_began = 0.9, scale_ended = 1, time = 1.2, curve = "ease_out",);
    at 0, Script.CharacterShow(name = "Kenichiro", time = 1.2, textname = "", dialogue = "一个小老头的脑袋从门内探了出来。",);
}

WaitForClick();
Script.Text(avater = "", name = "坂丘 健一郎", dialogue = "……什么事？",);

WaitForClick();
Script.Character(nameA = "Kenichiro", nameB = "Yusuke", imageB = "B05_草加裕介/A02_微笑.png", textname = "草加 裕介", dialogue = "老先生您好，我是练马警署的警察，您家楼上发生了一起伤人案，我有些事想询问一下。",);

WaitForClick();
Script.Character(nameA = "Yusuke", nameB = "Kenichiro", textname = "坂丘 健一郎", dialogue = "伤人案……？",);

WaitForClick();
Script.Text(avater = "", name = "", dialogue = "坂丘健一郎的眼睛眯了一下。",);

WaitForClick();
Script.Character(nameA = "Kenichiro", nameB = "Yusuke", imageB = "B05_草加裕介/A15_留意.png", textname = "草加 裕介", dialogue = "请问您在20时55分左右听到过疑似打斗的声响吗？有桌椅倒下和花瓶砸碎在地上的声音。",);

WaitForClick();
Script.Character(nameA = "Yusuke", nameB = "Kenichiro", textname = "坂丘 健一郎", dialogue = "坂丘闭上眼摇了摇头，然后伸手指向了自己的耳朵。",);

WaitForClick();
Script.Text(avater = "", name = "", dialogue = "起初我以为他是想说自己不使用BMI，但很快我就反应过来自己误会了。",);

WaitForClick();
Script.Text(avater = "", name = "", dialogue = "——这位老人，有听力障碍。",);

WaitForClick();
Script.Character(nameA = "Kenichiro", nameB = "Yusuke", imageB = "B05_草加裕介/A15_留意.png", textname = "草加 裕介", dialogue = "这样啊……感谢您的配合，这么晚登门打扰万分抱歉。",);

WaitForClick();
Text.Clear();
cmd_block
{
    at 0, Tachie.Switch(name_A = "Yusuke", time_A = 0.2, name_B = "Kenichiro", time_B = 0.2,);
    at 0.6, Tachie.Move(name = "Kenichiro", x_began = 0, y_began = -450, x_ended = -180, y_ended = -420, scale_began = 1, scale_ended = 0.9, time = 1, curve = "ease_in");
    at 0.6, Tachie.Hide(name = "Kenichiro", time = 1,);
    at 1.6, SE.Play(audio = "//SE/B_开关门/05_撞门声.ogg", volume = 0.7,);
    at 1.6, Picture.Change(name = "201", image = "//背景/B_第一章/06A_鸦巢公寓二楼走廊_201室房门.png", time = 0.5, );
    at 1.6, Script.Text(avater = "", name = "", dialogue = "坂丘没有再回话，只是砰的一声把门关上了。",);
}

WaitForClick();
Script.CharacterShow(name = "Yusuke", image = "B05_草加裕介/A01_平静.png", textname = "草加 裕介", dialogue = "呼……",);

WaitForClick();
Script.Text(avater = "", name = "草加 裕介", dialogue = "行了，该去监控室了。",);

WaitForClick();
Script.Expression(name = "Yusuke", image = "B05_草加裕介/A08_苦笑.png", textname = "草加 裕介", dialogue = "但愿这次的搜查……能顺利吧。",);

WaitForClick();
//场景离场
Text.Clear();
Tachie.Hide(name = "Yusuke",);
Text.Hide();
cmd_block
{
    at 0, Picture.Alpha(name = "201", alpha_began = 1, alpha_ended = 0, time = 1.5,);
    at 0, BGM.Volume(volume_began = 0.7, volume_ended = 0, time = 1.5,);
}
//场景离场
CanSkip(false);
WaitCommand(1);

//时间轴整理
Picture.Create(name = "time1", image = "//背景/B_第一章/91F_时间轴.png", scale = 1, x = -1500, y = 0, alpha = 0,);
Picture.Alpha(name = "time1", alpha_began = 0, alpha_ended = 1, time = 1,);
Picture.Change(name = "time1", image = "//背景/B_第一章/91G_时间轴.png", time = 0.3, );
Picture.Change(name = "time1", image = "//背景/B_第一章/91H_时间轴.png", time = 0.3, );

WaitForClick();
Picture.Position(name = "time1", x_began = -1500, x_ended = 1020, time = 1, curve = "uniform");
Picture.Change(name = "time1", image = "//背景/B_第一章/91I_时间轴.png", time = 0.3, );

WaitForClick();
Picture.Alpha(name = "time1", alpha_began = 1, alpha_ended = 0, time = 1,);
//时间轴整理

StoryArrow(4, true);
WaitCommand(1);
JumpToScript("脚本/V2/sv_01_05.json");

