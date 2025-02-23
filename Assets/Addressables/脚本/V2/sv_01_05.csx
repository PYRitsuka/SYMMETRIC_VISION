//C:\Users\10533\Desktop\SYMMETRIC_VISION\makeScript.bat


//————————————————————
//———————章节标题—————————
//————————————————————

StoryBlock(5, true);
CanSkip(false);
VisionTrigger(false);
SetChapter("01", "边界徘徊的七等星");
BGM.Stop();
SetUIMode(5);
CanSkip(true);
CanAuto(true);

//————————————————————
//———————吉田雪绘—————————
//————————————————————

//背景创建
Picture.Create(name = "BG", image = "//背景/B_第一章/03B_鸦巢公寓停车场_夜晚.png", scale = 1, x = 0, y = 0, alpha = 0,);
Picture.Create(name = "Memory", image = "//背景/B_第一章/06F_鸦巢公寓二楼走廊_203室房门.png", scale = 1, x = 0, y = 0, alpha = 0,);
//背景创建

//立绘创建
Tachie.Create(name = "Yusuke", image = "B05_草加裕介/A01_平静.png", scale = 1, x = 0, y = -525, alpha = 0, multiply = "#C5C0B4",); //中景，y值-400~-525
Tachie.Create(name = "Yukie", image = "B04_吉田雪绘/B01_平常.png", scale = 1, x = 0, y = -450, alpha = 0, multiply = "#C5C0B4",); //中景，y值-400~-525
Tachie.Create(name = "Satoshi", image = "D05_早津智/A01_平淡.png", scale = 1, x = 0, y = -450, alpha = 0, multiply = "#E0E0E0",);  //中景，y值-400~-525
//立绘创建

Text.Show();
Script.Text(dialogue = "2035年9月8日（星期六）凌晨，0时12分。", speed = 30,);

WaitForClick();
Text.Hide();
SetUIMode(3);
BGM.Set(audio = "//BGM/B03-实验室的讨论.mp3", volume = 0.7,);
Picture.Alpha(name = "BG", alpha_began = 0, alpha_ended = 1, time = 1,);
//立绘平移入场（从左侧）
cmd_block
{
    at 0, Tachie.Position(name = "Yukie", x_began = -300, x_ended = 0, time = 0.7, curve = "ease_out",);
    at 0, Tachie.Alpha(name = "Yukie", alpha_began = 0, alpha_ended = 1, time = 0.7,);
    at 0, Text.Show();
}
//立绘平移入场（从左侧）
Script.Text(avater = "", name = "吉田 雪绘", dialogue = "嗨，这位警官请留步！",);

WaitForClick();
Script.Text(avater = "", name = "", dialogue = "来到公寓停车场的时候，一名女性突然出现在物业室门口拦住了草加。",);

WaitForClick();
Script.Character(nameA = "Yukie", nameB = "Yusuke", imageB = "B05_草加裕介/A01_平静.png", textname = "草加 裕介", dialogue = "您是……？",);

WaitForClick();
Script.Character(nameA = "Yusuke", nameB = "Yukie", imageB = "B04_吉田雪绘/B16_声讨.png", textname = "吉田 雪绘", dialogue = "我是你们来到这幢公寓后最该拜会的人，可到现在都没有刑警先生来找我！你们的工资是树獭给的吗？敢这样马虎地办案？",);

WaitForClick();
Script.Character(nameA = "Yukie", nameB = "Yusuke", imageB = "B05_草加裕介/A15_留意.png", textname = "草加 裕介", dialogue = "啊？",);

WaitForClick();
Script.Text(avater = "", name = "", dialogue = "突如其来的指责让草加不由地一愣。",);

WaitForClick();
Script.Character(nameA = "Yusuke", nameB = "Yukie", imageB = "B04_吉田雪绘/B05_严肃.png", textname = "吉田 雪绘", dialogue = "房东，吉田雪绘。",);

WaitForClick();
//吉田雪绘与草加裕介握手
cmd_block
{
    at 0, Tachie.Change(name = "Yukie", image = "B04_吉田雪绘/B01_平常.png", time = 0.2, );
    at 0, Tachie.Alpha(name = "Yusuke", alpha_began = 0, alpha_ended = 1, time = 0.7,);
    at 0, Tachie.Position(name = "Yusuke", x_began = -700, x_ended = -350, time = 0.7, curve = "uniform");
    at 0, Tachie.Position(name = "Yukie", x_began = 0, x_ended = 350, time = 0.7, curve = "uniform");
}
Tachie.Position(name = "Yukie", x_began = 350, x_ended = 250, time = 0.3, curve = "uniform");
Tachie.Position(name = "Yukie", y_began = -450, y_ended = -500, time = 0.15, curve = "uniform");
Tachie.Position(name = "Yukie", y_began = -500, y_ended = -450, time = 0.15, curve = "uniform");
Tachie.Position(name = "Yukie", x_began = 250, x_ended = 350, time = 0.3, curve = "uniform");
Script.Text(avater = "", name = "", dialogue = "吉田雪绘伸出手敷衍地与草加握了一下。",);

WaitForClick();
//双立绘之一平移退场（向右）
cmd_block
{
    at 0, Tachie.Change(name = "Yusuke", image = "B05_草加裕介/A02_微笑.png", time = 0.2, );
    at 0, Tachie.Alpha(name = "Yukie", alpha_began = 1, alpha_ended = 0, time = 0.7,);
    at 0, Tachie.Position(name = "Yusuke", x_began = -350, x_ended = 0, time = 0.7, curve = "uniform");
    at 0, Tachie.Position(name = "Yukie", x_began = 350, x_ended = 700, time = 0.7, curve = "uniform");
    at 0, Script.Text(avater = "", name = "草加 裕介", dialogue = "哦，原来您就是吉田女士啊，幸会。",);
}
//双立绘之一平移退场（向右）
Tachie.Position(name = "Yukie", x_began = 700, x_ended = 0, time = 0, curve = "uniform");

WaitForClick();
Script.CharacterHide(name = "Yusuke", textname = "", dialogue = "草加不动声色地皱了下眉，按照之前的信息，持有303室钥匙的吉田雪绘是他的重点怀疑对象，他本来不想这么早找对方问话的。",);

WaitForClick();
Script.CharacterShow(name = "Yukie", image = "B04_吉田雪绘/B01_平常.png", textname = "吉田 雪绘", dialogue = "我的公寓里发生了骇人听闻的命案，刑警先生，这可是会影响房价的诶！你们怎么可以把我晾在一边？",);

WaitForClick();
Script.Character(nameA = "Yukie", nameB = "Yusuke", imageB = "B05_草加裕介/A15_留意.png", textname = "草加 裕介", dialogue = "非常抱歉，吉田女士，我们不是故意遗漏您的。我正打算来找您。",);

WaitForClick();
Script.Text(avater = "", name = "", dialogue = "草加裕介脸上赔着笑，很自然地撒了个谎。",);

WaitForClick();
Script.Character(nameA = "Yusuke", nameB = "Yukie", imageB = "B04_吉田雪绘/B01_平常.png", textname = "吉田 雪绘", dialogue = "那么，请说说吧。这起命案是怎么回事，为什么会有外人死在我的公寓里，我要求了解一下基本信息。",);

WaitForClick();
Script.Character(nameA = "Yukie", nameB = "Yusuke", imageB = "B05_草加裕介/A05_迟疑.png", textname = "", dialogue = "草加裕介犹豫了片刻，应该是在考虑自己有哪些信息能说哪些信息不能说。",);

WaitForClick();
Script.Expression(name = "Yusuke", image = "B05_草加裕介/A02_微笑.png", textname = "草加 裕介", dialogue = "……那好吧。",);

WaitForClick();
Script.Text(avater = "", name = "草加 裕介", dialogue = "吉田女士，请问您知道VIEW APP吗？",);

WaitForClick();
Script.Character(nameA = "Yusuke", nameB = "Yukie", imageB = "B04_吉田雪绘/B01_平常.png", textname = "吉田 雪绘", dialogue = "当然知道。怎么，案子和VIEW有关系？",);

WaitForClick();
Script.Character(nameA = "Yukie", nameB = "Yusuke", imageB = "B05_草加裕介/A14_感兴趣.png", textname = "草加 裕介", dialogue = "不，只是反应测试而已。我要问的问题和VIEW无关。",);

WaitForClick();
Script.Character(nameA = "Yusuke", nameB = "Yukie", imageB = "B04_吉田雪绘/B06_疑惑.png", textname = "", dialogue = "吉田雪绘一脸嗅到了可疑气味的神情。",);

WaitForClick();
Script.Expression(name = "Yukie", image = "B04_吉田雪绘/B16_声讨.png", textname = "吉田 雪绘", dialogue = "不，<b>你在说谎！</b>",);

WaitForClick();
Script.Expression(name = "Yukie", image = "B04_吉田雪绘/B05_严肃.png", textname = "吉田 雪绘", dialogue = "本马小哥已经告诉我了，303室的门上被人用VIEW挂了个魔法阵，那显然是被害人留下的<b>死亡讯息</b>！",);

WaitForClick();
Script.Expression(name = "Yukie", image = "B04_吉田雪绘/B01_平常.png", textname = "吉田 雪绘", dialogue = "你欲言又止地拿VIEW的话题试探我，说明警方并不打算与我沟通实情。",);

WaitForClick();
Script.Text(avater = "", name = "吉田 雪绘", dialogue = "你们不信任我，对不对？",);

WaitForClick();
Script.Character(nameA = "Yukie", nameB = "Yusuke", imageB = "B05_草加裕介/A10_懊恼.png", textname = "草加 裕介", dialogue = "<size=28>啧……本马那小子，明明告诫过他不要外传现场信息。</size>",);

WaitForClick();
Script.Expression(name = "Yusuke", image = "B05_草加裕介/A14_感兴趣.png", textname = "草加 裕介", dialogue = "不好意思，请您别误会，吉田女士。我们并没有不信任您，只是作为刑警，我有义务对初次见面的人保持小心。",);

WaitForClick();
Script.Character(nameA = "Yusuke", nameB = "Yukie", imageB = "B04_吉田雪绘/B01_平常.png", textname = "吉田 雪绘", dialogue = "你们可以不用怀疑我的，因为我现在就可以证明我不可能参与犯罪。",);

WaitForClick();
//重点提示（打断BGM）
cmd_block
{
    at 0, Script.Expression(name = "Yukie", image = "B04_吉田雪绘/B12_认真.png", textname = "吉田 雪绘", dialogue = "我<b>一整晚都待在家中和朋友连麦</b>，我的朋友和通信记录都能证明。",);
    at 0.1, SE.Play(audio = "//SE/G_氛围音/05_重点提示.ogg", volume = 0.6, loop = false, );
    at 0.1, BGM.Stop();
}
//重点提示（打断BGM）

WaitForClick();
Script.Character(nameA = "Yukie", nameB = "Yusuke", imageB = "B05_草加裕介/A03_严肃.png", textname = "草加 裕介", dialogue = "<size=38>——！？</size>",);

WaitForClick();
//回忆转场
Text.Hide();
cmd_block
{
    at 0, SE.Play(audio = "//SE/A_系统音效/15_回忆转场.ogg", volume = 0.3,);
    at 0, Camera.SparkingWhite(0.3);
    at 0.3, Filter.MemoryOn();
    at 0.3, Picture.Alpha(name = "Memory", alpha_began = 0, alpha_ended = 1, time = 0,);
    at 0.3, Tachie.Change(name = "Yusuke", image = "B05_草加裕介/A02_微笑.png", time = 0,);
    at 0.3, Tachie.Multiply(name = "Yusuke", color = "#E0E0E0",);
    at 0.3, Camera.WhiteRestore(0.3);
    at 0.3, WaitCommand(0.3);
}
Text.Show();
//回忆转场
Script.Text(avater = "", name = "草加 裕介", dialogue = "你们今晚的派对来了几个人参加？从几点开到了几点？",);

WaitForClick();
Script.Character(nameA = "Yusuke", nameB = "Satoshi", imageB = "D05_早津智/A03_疑问.png", textname = "早津 智", dialogue = "几人？我数数……我、森川、崎尾、濑户、还有室村，吉田姐中途也来了，所以总共是六个人。",);

WaitForClick();
Script.Character(nameA = "Satoshi", nameB = "Yusuke", imageB = "B05_草加裕介/A01_平静.png", textname = "草加 裕介", dialogue = "吉田姐？你是说房东吉田雪绘？",);

WaitForClick();
Script.Character(nameA = "Yusuke", nameB = "Satoshi", imageB = "D05_早津智/A01_平淡.png", textname = "早津 智", dialogue = "是，她本来是来提醒我们不要扰民的，但大家听说她是是ES5开服老玩家，就把她拉进来一起玩了。",);

WaitForClick();
//回忆转场反
Text.Hide();
cmd_block
{
    at 0, SE.Play(audio = "//SE/A_系统音效/16_回忆转场反.ogg", volume = 0.3,);
    at 0, Camera.SparkingWhite(0.3);
    at 0.3, Filter.MemoryOff();
    at 0.3, Picture.Alpha(name = "Memory", alpha_began = 1, alpha_ended = 0, time = 0,);
    at 0.3, Tachie.Hide(name = "Satoshi", time = 0,);
    at 0.3, Tachie.Multiply(name = "Yusuke", color = "#C5C0B4",);
    at 0.3, Camera.WhiteRestore(0.3);
    at 0.3, WaitCommand(0.3);
}
Text.Show();
Script.CharacterShow(name = "Yukie", image = "B04_吉田雪绘/B03_笑眯眯.png", textname = "吉田 雪绘", dialogue = "哈，那个表情！你果然知道呢。",);

WaitForClick();
Script.Expression(name = "Yukie", image = "B04_吉田雪绘/B12_认真.png", textname = "吉田 雪绘", dialogue = "——知道我今晚其实在森川君的家里这件事。",);

WaitForClick();
BGM.Set(audio = "//BGM/B03-实验室的讨论.mp3", volume = 0.7,);
Script.Character(nameA = "Yukie", nameB = "Yusuke", imageB = "B05_草加裕介/A17_怀疑.png", textname = "草加 裕介", dialogue = "啊？",);

WaitForClick();
Script.Text(avater = "", name = "", dialogue = "草加裕介愣了两秒，然后才反应过来自己被摆了一道。",);

WaitForClick();
Script.Character(nameA = "Yusuke", nameB = "Yukie", imageB = "B04_吉田雪绘/B01_平常.png", textname = "吉田 雪绘", dialogue = "你们特地将我留到最后，先把公寓住户盘问了一遍——这还不是在怀疑我的表现吗？",);

WaitForClick();
Script.Character(nameA = "Yukie", nameB = "Yusuke", imageB = "B05_草加裕介/A09_烦躁.png", textname = "", dialogue = "草加裕介尴尬地砸了下嘴，他没想到自己居然也会被人套话。",);

WaitForClick();
Script.Character(nameA = "Yusuke", nameB = "Yukie", imageB = "B04_吉田雪绘/B01_平常.png", textname = "吉田 雪绘", dialogue = "所以，到底发生什么事了，怀疑我的原因又是什么，可以让我了解一下吗？",);

WaitForClick();
Script.Character(nameA = "Yukie", nameB = "Yusuke", imageB = "B05_草加裕介/A16_悲伤.png", textname = "草加 裕介", dialogue = "既然您已经明白警方有所顾虑了，那就请配合回答几个问题吧。虽然我本来不想这么早问的……",);

WaitForClick();
Script.Character(nameA = "Yusuke", nameB = "Yukie", imageB = "B04_吉田雪绘/B03_笑眯眯.png", textname = "吉田 雪绘", dialogue = "乐意之至。",);

WaitForClick();
Script.Character(nameA = "Yukie", nameB = "Yusuke", imageB = "B05_草加裕介/A01_平静.png", textname = "草加 裕介", dialogue = "这张是案发现场的照片，然后，这张是我们在半小时前拍摄的尸体的红外照。",);

WaitForClick();
Script.Character(nameA = "Yusuke", nameB = "Yukie", imageB = "B04_吉田雪绘/B01_平常.png", textname = "", dialogue = "草加裕介说着，将两张照片送到了吉田雪绘的眼前。",);

WaitForClick();
//放大立绘进入BMI
Text.Hide();
Picture.Create(name = "BGZ", image = "//背景/B_第一章/03B_鸦巢公寓停车场_夜晚.png", scale = 1, x = 0, y = 0, alpha = 1,);
cmd_block
{
    at 0, Picture.Move(name = "BGZ", y_began = 0, y_ended = -115, scale_began = 1, scale_ended = 1.5, time = 1, curve = "ease_out", alpha_began = 1, alpha_ended = 1, alpha_time = 0,);
    at 0, Tachie.Move(name = "Yukie", y_began = -450, y_ended = -815, scale_began = 1, scale_ended = 1.5, angle_began = 0, angle_ended = 0, time = 1, curve = "ease_out",);
    at 0, Tachie.Alpha(name = "Yukie", alpha_began = 1, alpha_ended = 0, time = 1,);
}
SetUIMode(2);
SE.Play(audio = "//SE/A_系统音效/01_回路启动.ogg", volume = 0.4, loop = false,);
cmd_block
{
    at 0, UI.Create(name = "BMIO", image = "A_系统UI/01_BMI边框.png", scale = 1.3, alpha = 1,);
    at 0, UI.Scale(name = "BMIO", scale_began = 1.3, scale_ended = 1, time = 0.5, curve = "uniform",);
    at 0, Picture.Alpha(name = "BGZ", alpha_began = 1, alpha_ended = 0, time = 1,);
}
Picture.Release("BGZ");
//放大立绘进入BMI
Frame.PictureOn(image = "//图片/B_第一章/18A_尸体照片.png", color = "blue", duration = 0.3,);
Text.Show();
Script.Text(avater = "蓝/B04_吉田雪绘/B18_感兴趣.png", name = "吉田 雪绘", dialogue = "这个倒在血泊中的男子……是生面孔呢。",);

WaitForClick();
Script.Text(avater = "蓝/B05_草加裕介/A19_谨慎.png", name = "草加 裕介", dialogue = "您不认识被害人吗？",);

WaitForClick();
Script.Text(avater = "蓝/B04_吉田雪绘/B15_担忧.png", name = "吉田 雪绘", dialogue = "不看脸的话很难确定，但从衣着和身材特征来看，我应该不认识这个人。",);

WaitForClick();
Frame.PictureChange(image = "//图片/B_第一章/18B_尸体红外.png", duration = 0.5,);
Script.Text(avater = "蓝/B04_吉田雪绘/B09_思考.png", name = "吉田 雪绘", dialogue = "然后，这张红外图是……死亡时间在20时15分到22时15分之间？",);

WaitForClick();
Script.Text(avater = "蓝/B05_草加裕介/A17_怀疑.png", name = "草加 裕介", dialogue = "您居然能看出来？您是医学相关专业的吗？",);

WaitForClick();
Script.Text(avater = "蓝/B04_吉田雪绘/B02_微笑.png", name = "吉田 雪绘", dialogue = "是，以前开过私人诊所。这块地皮也是曾经救治过的一位大老板作为遗产赠送给我的。",);

WaitForClick();
cmd_block
{
    at 0, Frame.PictureOff(0.3);
    at 0, Script.Text(avater = "", name = "", dialogue = "什么老板啊出手这么阔绰……",);
}

WaitForClick();
//退出BMI
Text.Hide();
SetUIMode(3);
SE.Play(audio = "//SE/A_系统音效/02_回路关闭.ogg", volume = 0.4, loop = false,);
UI.Scale(name = "BMIO", scale_began = 1, scale_ended = 1.3, time = 0.5, curve = "uniform",);
UI.Release("BMIO");
Text.Show();
Tachie.Set(name = "Yukie", y = -450, scale = 1,);
Script.CharacterShow(name = "Yusuke", image = "B05_草加裕介/A01_平静.png", textname = "草加 裕介", dialogue = "您的判断非常精准，我们的法医也认为被害人是在<b>20时15分之后</b>死亡的。",);

WaitForClick();
Script.Expression(name = "Yusuke", image = "B05_草加裕介/A02_微笑.png", textname = "草加 裕介", dialogue = "而您是在<b>20时30分</b>参与了203室大学生们的派对，因此您的不在场证明并不完全。",);

WaitForClick();
Script.Character(nameA = "Yusuke", nameB = "Yukie", imageB = "B04_吉田雪绘/B01_平常.png", textname = "吉田 雪绘", dialogue = "原来如此，这就是你们把我当做嫌疑人对待的原因吧？",);

WaitForClick();
Script.Character(nameA = "Yukie", nameB = "Yusuke", imageB = "B05_草加裕介/A02_微笑.png", textname = "草加 裕介", dialogue = "感谢您的理解。不过您也不用太过担心，验尸结果出来后，死亡时间会进一步精确，到那时自然会给您一个公正的交代。",);

WaitForClick();
Script.Character(nameA = "Yusuke", nameB = "Yukie", imageB = "B04_吉田雪绘/B14_wink.png", textname = "吉田 雪绘", dialogue = "好啦好啦，我不强求了解案件详情了。你还有什么想问我的吗？",);

WaitForClick();
Script.Character(nameA = "Yukie", nameB = "Yusuke", imageB = "B05_草加裕介/A02_微笑.png", textname = "草加 裕介", dialogue = "我想向您打听一些关于公寓住户的问题，您应该对每名租房客都比较熟吧？",);

WaitForClick();
Script.Expression(name = "Yusuke", image = "B05_草加裕介/A01_平静.png", textname = "草加 裕介", dialogue = "那位姓坂丘的老人，是听觉不太灵敏吗？",);

WaitForClick();
Script.Character(nameA = "Yusuke", nameB = "Yukie", imageB = "B04_吉田雪绘/B01_平常.png", textname = "吉田 雪绘", dialogue = "是的，他平时很少出门也很少理人，听说以前还因为过马路时听不见喇叭声而出过车祸。",);

WaitForClick();
Tachie.Multiply(name = "Yukie", factor = 0.4,);
Script.Text(avater = "", name = "", dialogue = "车祸……我记得从本马秀和那里听到的版本是碰瓷来着。",);

WaitForClick();
Script.Character(nameA = "Yukie", nameB = "Yusuke", imageB = "B05_草加裕介/A02_微笑.png", textname = "草加 裕介", dialogue = "您觉得303室的熊取先生是个什么样的人？",);

WaitForClick();
Tachie.Multiply(name = "Yukie", factor = 2.5,);
Script.Character(nameA = "Yusuke", nameB = "Yukie", imageB = "B04_吉田雪绘/B02_微笑.png", textname = "吉田 雪绘", dialogue = "熊取大哥……人还不错？有一次泉美被小混混盯上就是他挺身而出把人赶走的。不过熊取大哥平时喜欢独来独往，我跟他也不怎么熟。",);

WaitForClick();
Script.Character(nameA = "Yukie", nameB = "Yusuke", imageB = "B05_草加裕介/A01_平静.png", textname = "草加 裕介", dialogue = "熊取先生是不是个特别注重个人隐私的人？",);

WaitForClick();
Script.Character(nameA = "Yusuke", nameB = "Yukie", imageB = "B04_吉田雪绘/B09_思考.png", textname = "吉田 雪绘", dialogue = "嗯……你这么一说好像还真是。整幢公寓只有他家的客厅窗帘是始终拉着的，很难从窗外看见室内……",);

WaitForClick();
Script.Expression(name = "Yukie", image = "B04_吉田雪绘/B05_严肃.png", textname = "吉田 雪绘", dialogue = "喂，你们该不会怀疑熊取大哥是犯人吧？",);

WaitForClick();
cmd_block
{
    at 0, Tachie.Hide(name = "Yukie",);
    at 0, Text.Hide();
}
Picture.CoveringOut(name = "BG", direction = "up", time = 0.4,);
Picture.Change(name = "BG", image = "//背景/B_第一章/03C_鸦巢公寓停车场_夜晚_朝向吉田家.png", time = 0, );
WaitCommand(0.2);
Picture.CoveringIn(name = "BG", direction = "down", time = 0.4,);
Text.Show();
Script.Text(avater = "", name = "", dialogue = "草加裕介抬头看了一眼，两人的上方就是吉田雪绘家的阳台，从这里正好可以望见对楼303室的客厅窗户。",);

WaitForClick();
Script.Text(avater = "", name = "", dialogue = "几乎同时，一个念头闯入了我的脑海。",);

WaitForClick();
Script.Text(avater = "", name = "", dialogue = "如果在阳台这个位置架枪，是不是正好能……",);

WaitForClick();
Text.Clear();
Picture.CoveringOut(name = "BG", direction = "down", time = 0.4,);
Picture.Change(name = "BG", image = "//背景/B_第一章/03B_鸦巢公寓停车场_夜晚.png", time = 0, );
WaitCommand(0.2);
Picture.CoveringIn(name = "BG", direction = "up", time = 0.4,);
Script.CharacterShow(name = "Yusuke", image = "B05_草加裕介/A02_微笑.png", textname = "草加 裕介", dialogue = "好的，我想问的就这些。感谢您提供的线索。",);

WaitForClick();
Script.Character(nameA = "Yusuke", nameB = "Yukie", imageB = "B04_吉田雪绘/B05_严肃.png", textname = "吉田 雪绘", dialogue = "等一下，你还没回答我的问题呢。警方是不是在怀疑熊取大哥？",);

WaitForClick();
Script.Character(nameA = "Yukie", nameB = "Yusuke", imageB = "B05_草加裕介/A15_留意.png", textname = "草加 裕介", dialogue = "您不是与熊取先生不熟吗？没必要追问这些吧。",);

WaitForClick();
Script.Character(nameA = "Yusuke", nameB = "Yukie", imageB = "B04_吉田雪绘/B16_声讨.png", textname = "吉田 雪绘", dialogue = "这可不行。身为房东，为了社区名誉着想，我不能让你们随意怀疑犯人在我的租客当中。",);

WaitForClick();
Script.Character(nameA = "Yukie", nameB = "Yusuke", imageB = "B05_草加裕介/A05_迟疑.png", textname = "", dialogue = "草加迟疑了稍许，随后露出了坦然的神情。",);

WaitForClick();
Script.Expression(name = "Yusuke", image = "B05_草加裕介/A02_微笑.png", textname = "草加 裕介", dialogue = "那这样如何？我现在正好要去监控室确认监控录像，您应该也是管理公寓监控的责任人之一，和我一起上楼看看吧？",);

WaitForClick();
cmd_block
{
    at 0, Text.Hide();
    at 0, Tachie.Hide(name = "Yusuke",);
    at 0, BGM.Volume(volume_began = 0.7, volume_ended = 0, time = 1,);
    at 0.5, Picture.CoveringOut(name = "BG", direction = "left", time = 0.5,);
}

//读档标记点
ClearScene();

//————————————————————
//———————调查监控—————————
//————————————————————

SetUIMode(3);
SetChapter("01", "边界徘徊的七等星");
BGM.Stop();
CanSkip(true);
CanAuto(true);

//背景创建
Picture.Create(name = "Room", image = "//背景/B_第一章/10D_鸦巢公寓监控室深夜.png", scale = 1, x = 0, y = 0, alpha = 0,);
Picture.Create(name = "Out", image = "//背景/B_第一章/10A_鸦巢公寓监控室阳台.png", scale = 1, x = 0, y = 0, alpha = 0,);
Picture.Create(name = "Camera", image = "//背景/B_第一章/12D_鸦巢公寓三楼走廊_监控视角1.png", scale = 1, x = 0, y = 0, alpha = 0,);
//背景创建

//立绘创建
Tachie.Create(name = "Yusuke", image = "B05_草加裕介/A01_平静.png", scale = 1, x = 0, y = -525, alpha = 0, multiply = "#DCDCDC",); //中景，y值-400~-525
Tachie.Create(name = "Yukie", image = "B04_吉田雪绘/B01_平常.png", scale = 1, x = 0, y = -450, alpha = 0, multiply = "#DCDCDC",); //中景，y值-400~-525
Tachie.Create(name = "Hidekazu", image = "D01_本马秀和/A01_平常.png", scale = 1, x = 0, y = -400, alpha = 0, multiply = "#DCDCDC",); //中景，y值-400~-525
Tachie.Create(name = "Police", image = "F组/F02_女警察.png", scale = 1, x = 0, y = -475, alpha = 0, multiply = "#DCDCDC",); //中景，y值-400~-525
//立绘创建

BGM.Set(audio = "//BGM/B04-会议记录.mp3", volume = 0.7,);
Picture.Create(name = "blackcover", image = "//背景/上下黑边.png", scale = 0.8, alpha = 1,);
Picture.CoveringIn(name = "Room", direction = "right", time = 0.5,);
Text.Show();
Script.Text(avater = "", name = "", dialogue = "监控室位于物业室的二楼，附近五幢公寓的监控录像全都由这个房间的主控电脑集中管理。",);

WaitForClick();
Script.Text(avater = "", name = "", dialogue = "安装走廊监控是由五幢公寓的业主共同投票决定的，目的是防范近几年数目突增的高技术入室盗窃犯罪。",);

WaitForClick();
Script.Text(avater = "", name = "", dialogue = "进入数字化时代以来，黑客活动逐渐成为了违法犯罪的主流。",);

WaitForClick();
Script.Text(avater = "", name = "", dialogue = "这些计算机高手们可以无孔不入地入侵互联网与物联网的方方面面，给人们的生活造成了许多安全隐患。",);

WaitForClick();
Script.Text(avater = "", name = "", dialogue = "熊取昌二对电子锁的不信任，也是源自于此。",);

WaitForClick();
Script.Text(avater = "", name = "", dialogue = "据说这间监控室的墙壁就做了防黑客加固，可以屏蔽外界的电磁信号。各层楼的监控录像，只能通过有线连接汇总到这里。",);

WaitForClick();
Script.Text(avater = "", name = "", dialogue = "监控摄像头本身也不内置任何操作程序，只运行“录像”这一个功能，开关机、调焦、计时、导出全部由主控电脑调度。",);

WaitForClick();
Script.Text(avater = "", name = "", dialogue = "得益于此，警方在调取监控时才能不用去考虑录像被人从外部修改过或是用信号干扰过的可能。",);

WaitForClick();
Text.Clear();
//上下黑边离场
Picture.Scale(name = "blackcover", scale_began = 0.8, scale_ended = 1, time = 1, curve = "uniform",);
Picture.Release("blackcover",);
Script.CharacterShow(name = "Yusuke", image = "B05_草加裕介/A02_微笑.png", textname = "草加 裕介", dialogue = "汇报一下结果吧。",);

WaitForClick();
Script.Character(nameA = "Yusuke", nameB = "Police", textname = "女警员", dialogue = "是。我们分别调取了鸦巢公寓一、二、三楼和南面街道的监控进行检查，其中三楼监控我们只看到了损坏之前的画面。",);

WaitForClick();
Script.CharacterHide(name = "Police", textname = "", dialogue = "",);
Picture.Alpha(name = "Camera", alpha_began = 0, alpha_ended = 1, time = 0.5,);
Script.Text(avater = "蓝/F组/F02_女警察.png", name = "女警员", dialogue = "时间是<b>9月5日下午15时10分</b>，监控摄像头被突然飞来的石子砸坏。",);

WaitForClick();
Script.Text(avater = "蓝/F组/F02_女警察.png", name = "女警员", dialogue = "与本马秀和先生提供的证词“一群孩子玩弹弓时打坏了监控”一致。",);

WaitForClick();
cmd_block
{
    at 0, Picture.Change(name = "Camera", image = "//背景/B_第一章/12E_鸦巢公寓南面街道监控视角1.png", time = 0.5);
    at 0, Script.Text(avater = "蓝/F组/F02_女警察.png", name = "女警员", dialogue = "南面的街道监控可以看到公寓各层楼的阳台。",);
}

WaitForClick();
Script.Text(avater = "蓝/F组/F02_女警察.png", name = "女警员", dialogue = "我们确认了19时00分到23时10分之间没人靠近过阳台楼下的灌木丛，自然也就不可能有人攀爬阳台进出。",);

WaitForClick();
cmd_block
{
    at 0, Picture.Change(name = "Camera", image = "//背景/B_第一章/12C_鸦巢公寓二楼走廊_监控视角1.png", time = 0.5);
    at 0, Script.Text(avater = "蓝/F组/F02_女警察.png", name = "女警员", dialogue = "二楼监控显示森川先生和早津先生在19时20分带了三名同学回家。",);
}

WaitForClick();
cmd_block
{
    at 0, Picture.Change(name = "Camera", image = "//背景/B_第一章/12C_鸦巢公寓二楼走廊_监控视角2.png", time = 0.2);
    at 0, Script.Text(avater = "蓝/F组/F02_女警察.png", name = "女警员", dialogue = "二楼监控显示森川先生和早津先生在19时20分带了三名同学回家。",);
}

WaitForClick();
Script.Text(avater = "蓝/F组/F02_女警察.png", name = "女警员", dialogue = "<b>20时25分</b>，荻原大辅来到走廊上，似乎是为了确认派对噪音的源头是隔壁房间。",);

WaitForClick();
cmd_block
{
    at 0, Picture.Change(name = "Camera", image = "//背景/B_第一章/12C_鸦巢公寓二楼走廊_监控视角3.png", time = 0.2);
    at 0, Script.Text(avater = "蓝/F组/F02_女警察.png", name = "女警员", dialogue = "<b>20时26分</b>，荻原大辅回房。",);
}

WaitForClick();
cmd_block
{
    at 0, Picture.Change(name = "Camera", image = "//背景/B_第一章/12C_鸦巢公寓二楼走廊_监控视角4.png", time = 0.2);
    at 0, Script.Text(avater = "蓝/F组/F02_女警察.png", name = "女警员", dialogue = "<b>20时31分</b>，吉田雪绘来到203室，直到两小时后的<b>22时30分</b>才跟三名学生一起离开房门。",);
}

WaitForClick();
SE.Play(audio = "//SE/A_系统音效/17_信号中断.ogg", volume = 0.6,);
cmd_block
{
    at 0, Picture.Change(name = "Camera", image = "//背景/B_第一章/12F_鸦巢公寓监控黑屏1.png", time = 0.2);
    at 0, Script.Text(avater = "蓝/F组/F02_女警察.png", name = "女警员", dialogue = "然后，<b>23时10分</b>，监控摄像头因断电而关闭。",);
}

WaitForClick();
Text.Clear();
Picture.Alpha(name = "Camera", alpha_began = 1, alpha_ended = 0, time = 0.5,);
Script.CharacterShow(name = "Hidekazu", image = "D01_本马秀和/A01_平常.png", textname = "本马 秀和", dialogue = "断电是因为我在修理三楼监控前关闭了走廊的电源。",);

WaitForClick();
Script.Character(nameA = "Hidekazu", nameB = "Yusuke", imageB = "B05_草加裕介/A02_微笑.png", textname = "草加 裕介", dialogue = "很好，有留意过二楼后门楼梯的通行情况吗？",);

WaitForClick();
Script.Character(nameA = "Yusuke", nameB = "Police", textname = "女警员", dialogue = "从19时00分到23时10分，<b>没有人从二楼后门进出过</b>。",);

WaitForClick();
Script.Text(avater = "", name = "女警员", dialogue = "……但也正是因为二楼后门没拍到有人进出，<b>我们才会对案情感到十分费解</b>。",);

WaitForClick();
Script.Character(nameA = "Police", nameB = "Yusuke", imageB = "B05_草加裕介/A15_留意.png", textname = "草加 裕介", dialogue = "哦？",);

WaitForClick();
//隐去立绘，切换界面
Script.CharacterHide(name = "Yusuke", textname = "", dialogue = "",);
Picture.Change(name = "Camera", image = "//背景/B_第一章/12B_鸦巢公寓一楼走廊_监控视角1.png",);
Picture.Alpha(name = "Camera", alpha_began = 0, alpha_ended = 1, time = 0.5,);
Script.Text(avater = "蓝/F组/F02_女警察.png", name = "女警员", dialogue = "一楼监控和二楼监控基本一致。除了拍到一楼住户进出外，19时20分，五名大学生进入公寓。<b>20时00分</b>，熊取昌二从公寓大门离开。",);
//隐去立绘，切换界面

WaitForClick();
Script.Text(avater = "蓝/F组/F02_女警察.png", name = "女警员", dialogue = "但就在熊取昌二离开大门的同时，有一名戴口罩的男性与他擦肩而过进入了楼梯间。",);

WaitForClick();
Text.Clear();
Picture.Alpha(name = "Camera", alpha_began = 1, alpha_ended = 0, time = 0.5,);
Script.CharacterShow(name = "Yusuke", image = "B05_草加裕介/A03_严肃.png", textname = "", dialogue = "从女警员处收到共享照片的草加裕介瞪大了双眼。",);

WaitForClick();
Script.Expression(name = "Yusuke", image = "B05_草加裕介/A19_谨慎.png", textname = "草加 裕介", dialogue = "这个口罩，难道是……",);

WaitForClick();
Script.Character(nameA = "Yusuke", nameB = "Police", textname = "女警员", dialogue = "是的，根据AI匹配，推测<b>此人就是死者佐野阳向</b>。",);

WaitForClick();
Script.Character(nameA = "Police", nameB = "Yusuke", imageB = "B05_草加裕介/A03_严肃.png", textname = "草加 裕介", dialogue = "<size=38>……！</size>",);

WaitForClick();
Script.Character(nameA = "Yusuke", nameB = "Yukie", imageB = "B04_吉田雪绘/B01_平常.png", textname = "吉田 雪绘", dialogue = "也就是说，这个叫佐野阳向的人是看准了熊取大哥出门才进来的？",);

WaitForClick();
Script.Character(nameA = "Yukie", nameB = "Police", textname = "女警员", dialogue = "不清楚，但我们接下来会详细调查近几天的监控，看他有没有频繁靠近过公寓。",);

WaitForClick();
Script.CharacterHide(name = "Police", textname = "", dialogue = "",);
Picture.Alpha(name = "Camera", alpha_began = 0, alpha_ended = 1, time = 0.5,);
Script.Text(avater = "蓝/F组/F02_女警察.png", name = "女警员", dialogue = "重点来了。",);

WaitForClick();
cmd_block
{
    at 0, Picture.Change(name = "Camera", image = "//背景/B_第一章/12A_鸦巢公寓一楼走廊_打伞人1.png", time = 0.5);
    at 0, Script.Text(avater = "蓝/F组/F02_女警察.png", name = "女警员", dialogue = "<b>20时25分</b>，又有一人进入公寓大门，由于用伞遮住了面部，AI无法判断其性别。",);
}

WaitForClick();
Script.Text(avater = "蓝/B05_草加裕介/A17_怀疑.png", name = "草加 裕介", dialogue = "这个人……",);

WaitForClick();
Script.Text(avater = "", name = "", dialogue = "画面上的这个人把伞压得很低，几乎完全遮住了自己的脸。而且还穿着厚重的大衣，很难看出身材胖瘦。",);

WaitForClick();
Script.Text(avater = "", name = "", dialogue = "比起只戴了口罩进门的我，此人明显把自己遮得更严实。",);

WaitForClick();
cmd_block
{
    at 0, Picture.Change(name = "Camera", image = "//背景/B_第一章/12B_鸦巢公寓一楼走廊_监控视角2.png", time = 0.5);
    at 0, Script.Text(avater = "蓝/F组/F02_女警察.png", name = "女警员", dialogue = "打伞人上楼后，<b>20时31分</b>，吉田雪绘女士进入公寓，与二楼监控的记录吻合。",);
}

WaitForClick();
cmd_block
{
    at 0, Picture.Change(name = "Camera", image = "//背景/B_第一章/12A_鸦巢公寓一楼走廊_打伞人2.png", time = 0.5);
    at 0, Script.Text(avater = "蓝/F组/F02_女警察.png", name = "女警员", dialogue = "<b>21时30分</b>，打伞人再一次出现在公寓门口，进入大门并上楼。",);
}

WaitForClick();
BGM.Stop();
Script.Text(avater = "", name = "", dialogue = "诶？",);

WaitForClick();
//重点提示
cmd_block
{
    at 0, Script.Text(avater = "蓝/F组/F02_女警察.png", name = "女警员", dialogue = "在这之前的一个小时内，我们反复检查了几遍监控录像，<b>并没有拍到打伞人离开过公寓</b>。",);
    at 0.2, SE.Play(audio = "//SE/G_氛围音/05_重点提示.ogg", volume = 0.6, loop = false, );
}
//重点提示

WaitForClick();
Text.Clear();
Picture.Alpha(name = "Camera", alpha_began = 1, alpha_ended = 0, time = 0.5,);
SE.Play(audio = "//SE/I-器件音/04_拍桌子声.ogg", volume = 0.5,);
Picture.Vibrate("Room", "weak");
Script.Text(avater = "", name = "", dialogue = "草加裕介不自觉地一掌拍在了桌面上。",);

WaitForClick();
BGM.Set(audio = "//BGM/E03-谜题校验.mp3", volume = 0.75,);
Script.CharacterShow(name = "Yusuke", image = "B05_草加裕介/A06_施压.png", textname = "草加 裕介", dialogue = "<size=38>没拍到外出？</size>",);

WaitForClick();
Script.Character(nameA = "Yusuke", nameB = "Police", textname = "女警员", dialogue = "是的，最令人费解的地方就在这里，<b>这名打伞人相隔一小时进入了公寓两次，但期间监控完全没拍到他是什么时候出去的。</b>",);

WaitForClick();
Script.Text(avater = "", name = "女警员", dialogue = "而且，此后直到23时10分监控断电，一楼监控都没有拍到他离开，二楼监控也没拍到任何人从楼梯上下来。",);

WaitForClick();
Script.Character(nameA = "Police", nameB = "Yusuke", imageB = "B05_草加裕介/A09_烦躁.png", textname = "草加 裕介", dialogue = "这怎么可能……",);

WaitForClick();
Script.CharacterHide(name = "Yusuke", textname = "", dialogue = "草加裕介的额头上出现了汗珠。",);

WaitForClick();
//立绘站位分散
Tachie.Set(name = "Hidekazu", x = -350,);
Tachie.Set(name = "Yukie", x = 350,);
Script.SpeakerShow(nameA = "Hidekazu", imageA = "D01_本马秀和/A06_慌.png", nameB = "Yukie", imageB = "B04_吉田雪绘/B05_严肃.png", textname = "本马 秀和", dialogue = "难、难道说，杀人凶手现在还待在公寓内没有走！？",);
//立绘站位分散

WaitForClick();
Script.Speaker(nameA = "Yukie", nameB = "Hidekazu", imageA = "B04_吉田雪绘/B16_声讨.png", textname = "吉田 雪绘", dialogue = "冷静点，本马小哥。还没认定这个打伞人就是凶手呢。",);

WaitForClick();
Script.SpeakerHide(nameA = "Hidekazu", nameB = "Yukie", time = 0.2, textname = "", dialogue = "",);
Script.CharacterShow(name = "Yusuke", image = "B05_草加裕介/A17_怀疑.png", time = 0.2, textname = "", dialogue = "你确定二楼的后门没有人离开过吗？",);

WaitForClick();
Script.Character(nameA = "Yusuke", nameB = "Police", textname = "女警员", dialogue = "确定。说到底，除了监控问题外，我还检查了二楼后门的锁。门内侧的读卡器已经损坏很久了，根本刷不开，所以<b>这扇门只能进不能出</b>。",);

WaitForClick();
Script.Text(avater = "", name = "女警员", dialogue = "南面街道的监控也没有拍到打伞人的身影，说明他是从另一侧的小巷来的，而那里是街道监控的死角。",);

WaitForClick();
//立绘站位居中
Tachie.Set(name = "Yukie", x = 0,);
Tachie.Set(name = "Hidekazu", x = 0,);
//立绘站位居中
Script.Character(nameA = "Police", nameB = "Hidekazu", imageB = "D01_本马秀和/A04_紧张.png", textname = "本马 秀和", dialogue = "但这不可能啊！不走一楼也不走二楼，这个人是怎么凭空消失再从大门口出现的？",);

WaitForClick();
Script.Expression(name = "Hidekazu", image = "D01_本马秀和/A03_惊讶.png", textname = "本马 秀和", dialogue = "难道是趁着我给监控断电的空隙溜出了公寓？",);

WaitForClick();
Script.Character(nameA = "Hidekazu", nameB = "Yusuke", imageB = "B05_草加裕介/A10_懊恼.png", textname = "草加 裕介", dialogue = "不，如果是趁着监控断电离开，只能解释他第二次是如何离开公寓的，第一次怎么离开的还是说不通。",);

WaitForClick();
Script.Expression(name = "Yusuke", image = "B05_草加裕介/A09_烦躁.png", textname = "草加 裕介", dialogue = "明明所有可能的出口，都被监控覆盖到了啊……",);

WaitForClick();
Tachie.Multiply(name = "Yusuke", factor = 0.4,);
Script.Text(avater = "", name = "", dialogue = "避开所有监控从公寓中离开，这种事情可能发生吗？",);

//选项
Program.Select
(
    "optionA02",
    "可能是那把黑伞可以变形成螺旋桨？",
    "可能是从三楼走廊跳了下去？",
    "可能是躲进了公寓住户家？",
    "可能是从阳台翻出了公寓？",
);

if (optionA02_1 == true)
{
    Script.Text(avater = "", name = "", dialogue = "直接从走廊飞出去是吧？脑洞挺大。",);

    WaitForClick();
    Tachie.Multiply(name = "Yusuke", factor = 2.5,);
    Script.Expression(name = "Yusuke", image = "B05_草加裕介/A03_严肃.png", textname = "草加 裕介", dialogue = "我能想到的避开监控的方法只有一种，那就是直接从三楼的走廊跳下去。",);
}

if (optionA02_2 == true)
{
    Tachie.Multiply(name = "Yusuke", factor = 2.5,);
    Script.Expression(name = "Yusuke", image = "B05_草加裕介/A03_严肃.png", textname = "草加 裕介", dialogue = "我能想到的避开监控的方法只有一种，那就是直接从三楼的走廊跳下去。",);

    WaitForClick();
    Script.Text(avater = "", name = "", dialogue = "啊，看来草加警官和我想到了一块。",);
}

if (optionA02_3 == true)
{
    Script.Text(avater = "", name = "", dialogue = "那这名公寓住户的房间内要有通向公寓外的密道才行，我觉得建个密道这么大的事是瞒不过房东女士的眼睛的。",);

    WaitForClick();
    Tachie.Multiply(name = "Yusuke", factor = 2.5,);
    Script.Expression(name = "Yusuke", image = "B05_草加裕介/A03_严肃.png", textname = "草加 裕介", dialogue = "我能想到的避开监控的方法只有一种，那就是直接从三楼的走廊跳下去。",);
}

if (optionA02_4 == true)
{
    Script.Text(avater = "", name = "", dialogue = "虽然据警员所说，南面街道监控没拍到有人从阳台翻出，但这台监控并不属于物业管理，存在被犯人修改过的可能。",);

    WaitForClick();
    Tachie.Multiply(name = "Yusuke", factor = 2.5,);
    Script.Expression(name = "Yusuke", image = "B05_草加裕介/A03_严肃.png", textname = "草加 裕介", dialogue = "我能想到的避开监控的方法只有一种，那就是直接从三楼的走廊跳下去。",);
}

WaitForClick();
Script.Character(nameA = "Yusuke", nameB = "Yukie", imageB = "B04_吉田雪绘/B06_疑惑.png", textname = "吉田 雪绘", dialogue = "跳下去……？",);

WaitForClick();
Text.Clear();
//立绘平移离场（向左侧）
SE.Play(audio = "//SE/D_脚步声/09_急促的跑步声2.ogg", volume = 1,);
cmd_block
{
    at 0, Tachie.Position(name = "Yukie", x_began = 0, x_ended = -300, time = 0.5, curve = "ease_in");
    at 0, Tachie.Alpha(name = "Yukie", alpha_began = 1, alpha_ended = 0, time = 0.5,);
}
//立绘平移离场（向左侧）
Script.Text(avater = "", name = "", dialogue = "就在这时，吉田雪绘好像猛然反应过来了什么，她拨开警察朝监控室外的二楼露台走去，从那里远远地望了一眼院内的停车场。",);

WaitForClick();
Text.Clear();
Picture.CoveringOut(name = "Room", direction = "right", time = 0.5,);
Picture.CoveringIn(name = "Out", direction = "left", time = 0.5,);
Script.Text(avater = "蓝/B04_吉田雪绘/B16_声讨.png", name = "吉田 雪绘", dialogue = "我记得我八点半离开家前往公寓的时候，那边楼下停过一辆垃圾车。",);

WaitForClick();
Script.Text(avater = "蓝/B05_草加裕介/A19_谨慎.png", name = "草加 裕介", dialogue = "垃圾车？",);

WaitForClick();
cmd_block
{
    at 0, Picture.Move(name = "Out", x_began = 0, y_began = 0, x_ended = -70, y_ended = -105, scale_began = 1, scale_ended = 1.5, time = 0.8, curve = "ease_out",);
    at 0, Script.Text(avater = "", name = "", dialogue = "草加裕介跟了上来，看到吉田雪绘所指的方向是公寓西侧的灌木丛旁。",);
}

WaitForClick();
Script.Text(avater = "蓝/B04_吉田雪绘/B05_严肃.png", name = "吉田 雪绘", dialogue = "嗯，而且正好就停在303室的正下方。",);

WaitForClick();
Script.Text(avater = "蓝/B04_吉田雪绘/B16_声讨.png", name = "吉田 雪绘", dialogue = "这片停车场空地不在监控范围之内，我在想犯人有没有可能是开着垃圾车来到楼下的。然后离开时借用了车厢的高度作为从三楼往下跳的落脚点。",);

WaitForClick();
Script.Text(avater = "蓝/B04_吉田雪绘/B05_严肃.png", name = "吉田 雪绘", dialogue = "如果是策划好的犯罪，把尸体从三楼抛入车厢带走都是可以做到的。只不过可能是中途出了意外，被害人的大量出血阻碍了犯人的抛尸打算。",);

WaitForClick();
Script.Text(avater = "蓝/B05_草加裕介/A19_谨慎.png", name = "草加 裕介", dialogue = "…………",);

WaitForClick();
Text.Clear();
Picture.CoveringOut(name = "Out", direction = "left", time = 0.5,);
Picture.CoveringIn(name = "Room", direction = "right", time = 0.5,);
Script.Text(avater = "", name = "", dialogue = "草加裕介稍作思考，然后迅速对部下做出了指示。",);

WaitForClick();
Script.CharacterShow(name = "Yusuke", image = "B05_草加裕介/A03_严肃.png", textname = "草加 裕介", dialogue = "立即去调查一下国交省的车辆移动连接记录，看看今晚20时30分前后有哪辆车牌在鸦巢公寓楼下停留过。",);

WaitForClick();
Script.Text(avater = "", name = "草加 裕介", dialogue = "此外，详细检查周边3km内的街道监控，一定要想办法确认打伞人和垃圾车的行踪！",);

WaitForClick();
Script.Character(nameA = "Yusuke", nameB = "Police", textname = "女警员", dialogue = "是！",);

WaitForClick();
//立绘平移离场（向右侧）
SE.Play(audio = "//SE/D_脚步声/09_急促的跑步声2.ogg", volume = 1,);
cmd_block
{
    at 0, Tachie.Position(name = "Police", x_began = 0, x_ended = 300, time = 0.7, curve = "ease_in",);
    at 0, Tachie.Alpha(name = "Police", alpha_began = 1, alpha_ended = 0, time = 0.7,);
    at 0, Text.Hide();
}
//立绘平移离场（向右侧）
//场景音乐淡出
cmd_block
{
    at 0, Picture.Alpha(name = "Room", alpha_began = 1, alpha_ended = 0, time = 1,);
    at 0, BGM.Volume(volume_began = 1, volume_ended = 0, time = 1,);
}
//场景音乐淡出

//读档标记点
ClearScene();

//————————————————————
//———————我的思虑—————————
//————————————————————

SetUIMode(3);
SetChapter("01", "边界徘徊的七等星");
BGM.Stop();
CanSkip(true);
CanAuto(true);

//背景创建
Picture.Create(name = "Room", image = "//背景/B_第一章/10D_鸦巢公寓监控室深夜.png", scale = 1, x = 0, y = 0, alpha = 0,);
//背景创建

//立绘创建
Tachie.Create(name = "Yusuke", image = "B05_草加裕介/A01_平静.png", scale = 1, x = 0, y = -525, alpha = 0, multiply = "#DCDCDC",); //中景，y值-400~-525
Tachie.Create(name = "Police", image = "F组/F01_男警察.png", scale = 1, x = 0, y = -500, alpha = 0, multiply = "#DCDCDC",); //中景，y值-400~-525
//立绘创建

WaitCommand(0.5);
BGM.Set(audio = "//BGM/E01-思维螺旋.mp3", volume = 0.7,);
Text.Show();
Script.Text(avater = "", name = "", dialogue = "之后很长一段时间里，监控室内死气沉沉，每个人都在思考各自的事情。",);

WaitForClick();
Script.Text(avater = "", name = "", dialogue = "也包括……我自己。",);

WaitForClick();
Script.Text(avater = "", name = "", dialogue = "正如我所料，超出常理的事态又一次发生了。",);

WaitForClick();
Script.Text(avater = "", name = "", dialogue = "案发现场缺失的第三者痕迹、监控录像中两次进入公寓却从未外出的打伞人。",);

WaitForClick();
Script.Text(avater = "", name = "", dialogue = "虽然也可以用“犯人清理了案发现场”“打伞人从走廊跳了下去”来解释，但完全无法理解犯人这样做的用意是什么。",);

WaitForClick();
Script.Text(avater = "", name = "", dialogue = "反倒更像是……犯人根本不在乎自己进门的身影会被监控拍到，他是个可以凭空抹消掉自己存在的魔术师，这一切都是他随性为之。",);

WaitForClick();
Script.Text(avater = "", name = "", dialogue = "这幢公寓中，正在发生某种“超常”的事态。",);

WaitForClick();
Script.Text(avater = "", name = "", dialogue = "其中最无法理解的异常，就是我明明已经死了，却仍在观看着自己死后发生的事。",);

WaitForClick();
Script.Text(avater = "", name = "", dialogue = "警方到现在，还在常识的范围内调查我的死亡。",);

WaitForClick();
Script.Text(avater = "", name = "", dialogue = "这样下去他们可能永远也接近不了真相，我继续旁观下去也没有意义。",);

WaitForClick();
Text.Hide();
cmd_block
{
    at 0, Picture.Alpha(name = "Room", alpha_began = 0, alpha_ended = 1, time = 1,);
    at 0, BGM.Volume(volume_began = 1, volume_ended = 0, time = 1,);
}
BGM.Set(audio = "//BGM/B04-会议记录.mp3", volume = 0.7,);
//立绘平移入场（从右侧）
cmd_block
{
    at 0, Tachie.Position(name = "Police", x_began = 300, x_ended = 0, time = 0.7, curve = "ease_out",);
    at 0, Tachie.Alpha(name = "Police", alpha_began = 0, alpha_ended = 1, time = 0.7,);
    at 0, Text.Show();
}
//立绘平移入场（从右侧）
Script.Text(avater = "", name = "男警员", dialogue = "草加警官！",);

WaitForClick();
Script.Text(avater = "", name = "", dialogue = "就在这时，一名男警员的呼喊声打破了沉默。",);

WaitForClick();
Script.Character(nameA = "Police", nameB = "Yusuke", imageB = "B05_草加裕介/A03_严肃.png", textname = "草加 裕介", dialogue = "什么事？",);

WaitForClick();
Script.Character(nameA = "Yusuke", nameB = "Police", textname = "男警员", dialogue = "外面来了一名自称SEGMA公司社员的年轻女子，向我们询问为什么这里拉上了警戒线。",);

WaitForClick();
Script.Character(nameA = "Police", nameB = "Yusuke", imageB = "B05_草加裕介/A19_谨慎.png", textname = "草加 裕介", dialogue = "……！",);

WaitForClick();
Tachie.Multiply(name = "Yusuke", factor = 0.4,);
Script.Text(avater = "", name = "", dialogue = "是我工作的那家公司！",);

WaitForClick();
Tachie.Multiply(name = "Yusuke", factor = 2.5,);
Script.Expression(name = "Yusuke", image = "B05_草加裕介/A18_敏锐.png", textname = "草加 裕介", dialogue = "我这就来！把她请到物业室来，我要亲自和这位女士聊一聊！",);

WaitForClick();
//场景离场
Text.Clear();
Tachie.Hide(name = "Yusuke",);
Text.Hide();
cmd_block
{
    at 0, Picture.Alpha(name = "Room", alpha_began = 1, alpha_ended = 0, time = 1.5,);
    at 0, BGM.Volume(volume_began = 0.7, volume_ended = 0, time = 1.5,);
}
//场景离场
CanSkip(false);
WaitCommand(1);

//时间轴整理
Picture.Create(name = "time1", image = "//背景/B_第一章/91I_时间轴.png", scale = 1, x = -1575, y = 0, alpha = 0,);
Picture.Alpha(name = "time1", alpha_began = 0, alpha_ended = 1, time = 1,);

WaitForClick();
Picture.Position(name = "time1", x_began = -1575, x_ended = 1920, time = 1.5, curve = "uniform");
Picture.Change(name = "time1", image = "//背景/B_第一章/91J_时间轴.png", time = 0.3, );
Picture.Change(name = "time1", image = "//背景/B_第一章/91K_时间轴.png", time = 0.3, );

WaitForClick();
Picture.Change(name = "time1", image = "//背景/B_第一章/91L_时间轴.png", time = 0.3, );

WaitForClick();
Picture.Position(name = "time1", x_began = 1920, x_ended = 850, time = 1, curve = "uniform");
Picture.Change(name = "time1", image = "//背景/B_第一章/91M_时间轴.png", time = 0.3, );

WaitForClick();
Picture.Position(name = "time1", x_began = 850, x_ended = 1560, time = 0.5, curve = "uniform");
Picture.Change(name = "time1", image = "//背景/B_第一章/91N_时间轴.png", time = 0.3, );
Picture.Change(name = "time1", image = "//背景/B_第一章/91O_时间轴.png", time = 0.3, );
Picture.Change(name = "time1", image = "//背景/B_第一章/91P_时间轴.png", time = 0.3, );

WaitForClick();
Picture.Position(name = "time1", x_began = 1560, x_ended = -470, time = 1, curve = "uniform");
Picture.Change(name = "time1", image = "//背景/B_第一章/91Q_时间轴.png", time = 0.3, );

WaitForClick();
Picture.Alpha(name = "time1", alpha_began = 1, alpha_ended = 0, time = 1,);
//时间轴整理

StoryArrow(5, true);
WaitCommand(1);
JumpToScript("脚本/V2/sv_01_06.json");








