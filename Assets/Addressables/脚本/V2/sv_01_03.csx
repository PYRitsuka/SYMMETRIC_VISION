//C:\Users\10533\Desktop\SYMMETRIC_VISION\makeScript.bat


//————————————————————
//———————章节标题—————————
//————————————————————

StoryBlock(3, true);
CanSkip(false);
VisionTrigger(false);
SetChapter("01", "边界徘徊的七等星");
BGM.Set(audio = "//BGM/A01_Pulse_PVver.mp3", volume = 0, loop = true, loop_begin = 0, loop_end = 0,);
SetUIMode(5);
CanSkip(true);
CanAuto(true);



//————————————————————
//———————草加登场—————————
//————————————————————



//文本框显现
Text.ChangeAlpha(alpha_began = 0, alpha_ended = 1, time = 0.5,);
//旁白
Script.Narration(dialogue = "2035年9月7日（星期五）晚，23时35分。",);

WaitForClick(); //··
//文本框清空
Text.Clear();
//文本框隐藏
Text.ChangeAlpha(alpha_began = 1, alpha_ended = 0, time = 0.5,);
//UI模式：蓝色自由视角
SetUIMode(3);
//创建背景
Picture.Create(name = "bg1", image = "//背景/B_第一章/08A_鸦巢公寓303室_正门夜晚搜证.png", alpha = 0,);
//设定BGM
BGM.Set(audio = "//BGM/B04-会议记录.mp3", volume = 0.7, loop = true, loop_begin = 0, loop_end = 0,);
//背景淡入
Picture.Alpha(name = "bg1", alpha_began = 0, alpha_ended = 1, time = 0.5,);
//文本框显现
Text.ChangeAlpha(alpha_began = 0, alpha_ended = 1, time = 0.5,);
//旁白
Script.Narration(dialogue = "赶到高野台三丁目的警察们，给鸦巢公寓拉上了警戒线。",);
// Sanity Check Auto Play
// JumpToScript( "脚本/V2/sv_01_03.json");
WaitForClick(); //··
//创建草加裕介立绘，中景，y值在-400~500之间
Tachie.Create(name = "Yusuke", image = "B05_草加裕介/A01_平静.png", scale = 1, x = 0, y = -500, angle = 0, alpha = 0, multiply = "#f5f1e9",);
cmd_block
{
    //立绘淡入
    at 0, Tachie.Alpha(name = "Yusuke", alpha_began = 0, alpha_ended = 1, time = 0.75,);
    //旁白
    at 0, Script.Narration(dialogue = "为首的警官名叫草加裕介，是练马警署刑事科的的<link=011><color=#0097ff>警部补</color></link>。",);
}

WaitForClick(); //··
//旁白
Script.Narration(dialogue = "此刻他正用BMI确认着由案发现场的第一发现者本马秀和提供的录像。",);

WaitForClick(); //··
//旁白
Script.Narration(dialogue = "从在303室门口遇见菅田敏之开始，到撞开房门发现尸体结束，中间发生的所有事都在录像中记录得一清二楚。",);

WaitForClick(); //··
//创建本马秀和立绘，中景，y值在-400~500之间
Tachie.Create(name = "Hidekazu", image = "D01_本马秀和/A01_平常.png", scale = 1, x = 700, y = -400, angle = 0, alpha = 0, multiply = "#f5f1e9",);
cmd_block
{
    //本马秀和立绘淡入
    at 0, Tachie.Alpha(name = "Hidekazu", alpha_began = 0, alpha_ended = 1, time = 0.75,);
    //本马秀和立绘进入
    at 0, Tachie.Position(name = "Hidekazu", x_began = 700, y_began = -400, x_ended = 300, y_ended = -400, time = 0.75, curve = "ease_in",);
    //草加裕介立绘左移
    at 0, Tachie.Position(name = "Yusuke", x_began = 0, y_began = -500, x_ended = -400, y_ended = -500, time = 0.75, curve = "ease_in",);
}
//切换立绘明暗
Tachie.Multiply(name = "Yusuke", factor = 0.4,);
//台词
Script.Dialogue(name = "本马 秀和", dialogue = "警官，我的录像……应该没什么问题吧？",);

WaitForClick(); //··
//切换立绘明暗
Tachie.Multiply(name = "Yusuke", factor = 2.5,);
Tachie.Multiply(name = "Hidekazu", factor = 0.4,);
cmd_block
{
    //更改立绘图片
    at 0, Tachie.Change(name = "Yusuke", image = "B05_草加裕介/A02_微笑.png", time = 0.2, );
    //台词
    at 0, Script.Dialogue(name = "草加 裕介", dialogue = "嗯，没问题，非常感谢您提供的线索。能够在发现事情不对时及时录像保留证据，您能有这种意识十分可贵。",);
}

WaitForClick(); //··
//切换立绘明暗
Tachie.Multiply(name = "Yusuke", factor = 0.4,);
Tachie.Multiply(name = "Hidekazu", factor = 2.5,);
cmd_block
{
    //更改立绘图片
    at 0, Tachie.Change(name = "Hidekazu", image = "D01_本马秀和/A02_赔笑.png", time = 0.2, );
    //台词
    at 0, Script.Dialogue(name = "本马 秀和", dialogue = "哦、哦，能帮上忙就好。",);
}


WaitForClick(); //··
//文本框清空
Text.Clear();
cmd_block
{
    //本马秀和立绘淡出
    at 0, Tachie.Alpha(name = "Hidekazu", alpha_began = 1, alpha_ended = 0, time = 0.75,);
    //本马秀和立绘离场
    at 0, Tachie.Position(name = "Hidekazu", x_began = 300, y_began = -400, x_ended = 700, y_ended = -400, time = 0.75, curve = "ease_in",);
    //草加裕介立绘右移
    at 0, Tachie.Position(name = "Yusuke", x_began = -400, y_began = -500, x_ended = 0, y_ended = -500, time = 0.75, curve = "ease_in",);
}
//删除立绘
Tachie.Release("Hidekazu");
//切换立绘明暗
Tachie.Multiply(name = "Yusuke", factor = 2.5,);
cmd_block
{
    //更改立绘图片
    at 0, Tachie.Change(name = "Yusuke", image = "B05_草加裕介/A01_平静.png", time = 0.2, );
    //台词
    at 0, Script.Dialogue(name = "草加 裕介", dialogue = "…………",);
}

WaitForClick(); //··
cmd_block
{
    //更改立绘图片
    at 0, Tachie.Change(name = "Yusuke", image = "B05_草加裕介/A03_严肃.png", time = 0.2, );
    //台词
    at 0, Script.Dialogue(name = "草加 裕介", dialogue = "暂停。",);
}

WaitForClick(); //··
//文本框清空
Text.Clear();
//草加裕介立绘淡出
at 0, Tachie.Alpha(name = "Yusuke", alpha_began = 1, alpha_ended = 0, time = 0.5,);
//开启图片框体
Frame.PictureOn(image = "//图片/B_第一章/04_303室门锁.png", color = "blue", duration = 0.3,);
//旁白
Script.Narration(dialogue = "草加裕介将录像定格在了一个画面。",);

WaitForClick(); //··
//旁白
Script.Narration(dialogue = "这个画面，是本马秀和用手电光透过门缝去确认房门是否上锁时录下的。",);

WaitForClick(); //··
//旁白
Script.Narration(dialogue = "仔细观察的话，可以看到画面中<b>插销的影子嵌进了锁槽</b>里。",);

WaitForClick(); //··
//文本框清空
Text.Clear();
//关闭图片框体
Frame.PictureOff(0.3);
//背景向左擦除离场
Picture.CoveringOut(name = "bg1", direction = "left", time = 0.5,);
//背景更改
Picture.Change(name = "bg1", image = "//背景/B_第一章/08D_鸦巢公寓303室_屋内夜晚搜证.png", time = 0, );
//背景从右擦入入场
Picture.CoveringIn(name = "bg1", direction = "right", time = 0.5,);
//播放SE
SE.Play(audio = "//SE/D_脚步声/05_登场的脚步声.ogg", volume = 0.8, loop = false,);
//背景移动
Picture.Move(name = "bg1", x_began = 0, y_began = 0, x_ended = 190, y_ended = 50, scale_began = 1, scale_ended = 1.2, time = 0.75, curve = "uniform",);
//旁白
Script.Narration(dialogue = "草加裕介来到门前，从地上捡起了录像中看到的门锁插销。",);

WaitForClick(); //··
//旁白
Script.Narration(dialogue = "由于暴力破门的缘故，此时的门锁零件已经七零八落，锁槽也被撞掉在地。",);

WaitForClick(); //··
//旁白
Script.Narration(dialogue = "掉落在插销旁的，还有门上的锁舌。",);

WaitForClick(); //··
//旁白
Script.Narration(dialogue = "一般来说，防盗门关上时锁舌是自动扣上的，而插销则需要从门内使用旋钮或者从门外使用钥匙锁上。",);

WaitForClick(); //··
//旁白
Script.Narration(dialogue = "根据初步勘查，案发现场的303室房间包括阳台在内的所有门窗全部紧闭。",);

WaitForClick(); //··
//旁白
Script.Narration(dialogue = "屋内除了被害人尸体外也没有发现其他人藏身的踪迹。<b>那插销就只有可能是从门外锁上的了。</b>",);

WaitForClick(); //··
//文本框清空
Text.Clear();
//背景移动
Picture.Move(name = "bg1", x_began = 190, y_began = 50, x_ended = 0, y_ended = 0, scale_began = 1.2, scale_ended = 1, time = 0.75, curve = "uniform",);
//更改立绘图片
Tachie.Change(name = "Yusuke", image = "B05_草加裕介/A04_思考.png", time = 0, );
//草加裕介立绘淡入
at 0, Tachie.Alpha(name = "Yusuke", alpha_began = 0, alpha_ended = 1, time = 0.5,);
//旁白
Script.Dialogue(name = "草加 裕介", dialogue = "也就是说，持有303室钥匙的人需要重点调查吗……",);

WaitForClick(); //··
//文本框清空
Text.Clear();
//创建男警员立绘，中景，y值在-400~500之间
Tachie.Create(name = "Police", image = "F组/F01_男警察.png", scale = 1, x = 700, y = -500, angle = 0, alpha = 0, multiply = "#f5f1e9",);
cmd_block
{
    //男警员立绘淡入
    at 0, Tachie.Alpha(name = "Police", alpha_began = 0, alpha_ended = 1, time = 0.75,);
    //男警员立绘进入
    at 0, Tachie.Position(name = "Police", x_began = 800, y_began = -500, x_ended = 400, y_ended = -500, time = 0.75, curve = "ease_in",);
    //草加裕介立绘左移
    at 0, Tachie.Position(name = "Yusuke", x_began = 0, y_began = -500, x_ended = -400, y_ended = -500, time = 0.75, curve = "ease_in",);
}
//切换立绘明暗
Tachie.Multiply(name = "Yusuke", factor = 0.4,);
//台词
Script.Dialogue(name = "男警员", dialogue = "草加警官，根据被害者的所持物品，我们已经确认了他的身份。",);

WaitForClick(); //··
//台词
Script.Dialogue(name = "男警员", dialogue = "死者名叫<b>佐野阳向</b>，24岁，独身，在光丘居住。职业是软件工程师，目前在SEGMA公司担任开发岗。",);

WaitForClick(); //··
//切换立绘明暗
Tachie.Multiply(name = "Yusuke", factor = 2.5,);
Tachie.Multiply(name = "Police", factor = 0.4,);
cmd_block
{
    //更改立绘图片
    at 0, Tachie.Change(name = "Yusuke", image = "B05_草加裕介/A01_平静.png", time = 0.2, );
    //台词
    at 0, Script.Dialogue(name = "草加 裕介", dialogue = "SEGMA公司是说那个吗？志村社长名下的互联网企业，开发了VIEW APP的那个？",);
}

WaitForClick(); //··
//切换立绘明暗
Tachie.Multiply(name = "Yusuke", factor = 0.4,);
Tachie.Multiply(name = "Police", factor = 2.5,);
//台词
Script.Dialogue(name = "男警员", dialogue = "是的，而且结合新闻采访来看，佐野阳向这个名字……就是VIEW的开发者本人。",);

WaitForClick(); //··
//切换立绘明暗
Tachie.Multiply(name = "Yusuke", factor = 2.5,);
Tachie.Multiply(name = "Police", factor = 0.4,);
cmd_block
{
    //更改立绘图片
    at 0, Tachie.Change(name = "Yusuke", image = "B05_草加裕介/A03_严肃.png", time = 0.2, );
    //台词
    at 0, Script.Dialogue(name = "草加 裕介", dialogue = "<size=36>什么！？</size>",);
}

WaitForClick(); //··
//切换立绘明暗
Tachie.Multiply(name = "Yusuke", factor = 0.4,);
Tachie.Multiply(name = "Police", factor = 2.5,);
//台词
Script.Dialogue(name = "男警员", dialogue = "我们已经将死者相貌和新闻中的照片进行了对照，应该不会有错。",);

WaitForClick(); //··
//切换立绘明暗
Tachie.Multiply(name = "Yusuke", factor = 2.5,);
Tachie.Multiply(name = "Police", factor = 0.4,);
cmd_block
{
    //更改立绘图片
    at 0, Tachie.Change(name = "Yusuke", image = "B05_草加裕介/A09_烦躁.png", time = 0.2, );
    //台词
    at 0, Script.Dialogue(name = "草加 裕介", dialogue = "…………",);
}

WaitForClick(); //··
cmd_block
{
    //更改立绘图片
    at 0, Tachie.Change(name = "Yusuke", image = "B05_草加裕介/A10_懊恼.png", time = 0.2, );
    //台词
    at 0, Script.Dialogue(name = "草加 裕介", dialogue = "调查这种人的人际关系会变得很麻烦啊……",);
}

WaitForClick(); //··
cmd_block
{
    //更改立绘图片
    at 0, Tachie.Change(name = "Yusuke", image = "B05_草加裕介/A01_平静.png", time = 0.2, );
    //台词
    at 0, Script.Dialogue(name = "草加 裕介", dialogue = "那这间屋子的户主呢，确认身份了吗？",);
}

WaitForClick(); //··
//切换立绘明暗
Tachie.Multiply(name = "Yusuke", factor = 0.4,);
Tachie.Multiply(name = "Police", factor = 2.5,);
//台词
Script.Dialogue(name = "男警员", dialogue = "303室的户主名叫<b>熊取昌二</b>，是一家贸易公司的销售员。",);

WaitForClick(); //··
//台词
Script.Dialogue(name = "男警员", dialogue = "隔壁屋的菅田敏之先生称他在晚上8点左右看到过熊取昌二出门，此后似乎就没见过他回家。",);

WaitForClick(); //··
//台词
Script.Dialogue(name = "男警员", dialogue = "我找房东女士要来了熊取昌二的BMI号码，考虑到可能打草惊蛇所以还没有打过去。",);

WaitForClick(); //··
//切换立绘明暗
Tachie.Multiply(name = "Yusuke", factor = 2.5,);
Tachie.Multiply(name = "Police", factor = 0.4,);
//台词
Script.Dialogue(name = "草加 裕介", dialogue = "好，定位一下这个号码所在的位置。另外尽快查明熊取昌二与佐野阳向之间的关系。",);

WaitForClick(); //··
//切换立绘明暗
Tachie.Multiply(name = "Yusuke", factor = 0.4,);
Tachie.Multiply(name = "Police", factor = 2.5,);
//台词
Script.Dialogue(name = "男警员", dialogue = "是。",);

WaitForClick(); //··
//文本框清空
Text.Clear();
//切换立绘明暗
Tachie.Multiply(name = "Yusuke", factor = 2.5,);
//文本框隐藏
Text.ChangeAlpha(alpha_began = 1, alpha_ended = 0, time = 0.5,);
cmd_block
{
    //男警员立绘淡出
    at 0, Tachie.Alpha(name = "Police", alpha_began = 1, alpha_ended = 0, time = 0.5,);
    //男警员立绘离场
    at 0, Tachie.Position(name = "Police", x_began = 400, y_began = -500, x_ended = 800, y_ended = -500, time = 0.75, curve = "ease_in",);
    //草加裕介立绘右移
    at 0, Tachie.Position(name = "Yusuke", x_began = -400, y_began = -500, x_ended = 0, y_ended = -500, time = 0.75, curve = "ease_in",);
    //BGM淡出
    at 0.5, BGM.Volume(volume_began = 0.7, volume_ended = 0, time = 1,);
    //草加裕介立绘淡出
    at 1, Tachie.Alpha(name = "Yusuke", alpha_began = 1, alpha_ended = 0, time = 0.5,);
}
//设定BGM（loop_end=0时不循环）
BGM.Set(audio = "//BGM/D01-星海迷宫.mp3", volume = 0.7, loop = true, loop_begin = 0, loop_end = 0,);
//创建上下黑边
Picture.Create(name = "blackcover", image = "//背景/上下黑边.png", alpha = 1,);
cmd_block
{
    //黑边进入
    at 0, Picture.Scale(name = "blackcover", scale_began = 1, scale_ended = 0.8, time = 1, curve = "uniform",);
    //文本框显现
    at 0.5, Text.ChangeAlpha(alpha_began = 0, alpha_ended = 1, time = 0.5,);
}
//头像
Script.Avatar(name = "我", dialogue = "…………", avater = "蓝/A02_佐野阳向/C06_忧郁.png",);

WaitForClick(); //··
//头像
Script.Avatar(name = "我", dialogue = "佐野阳向……这就是我的名字吗？", avater = "蓝/A02_佐野阳向/C17_沉思.png",);

WaitForClick(); //··
//旁白
Script.Narration(dialogue = "我徘徊在房间内，但周围的警察们没有一人能认知到我的存在。",);

WaitForClick(); //··
//旁白
Script.Narration(dialogue = "我尝试过把腿横在草加警官面前看能不能绊倒他，但结果是我的腿被一脚踢开，而他没有受到丝毫影响。",);

WaitForClick(); //··
//旁白
Script.Narration(dialogue = "幽灵……就是孤身一人漂浮在世界之外，只能当一名旁观者的存在。",);

WaitForClick(); //··
//旁白
Script.Narration(dialogue = "手持核酸提取仪和指纹磁性刷的鉴识人员正仔细地检查着屋内的每一寸墙壁和家具。",);

WaitForClick(); //··
//旁白
Script.Narration(dialogue = "旁观他们的搜查，就是我现在唯一能了解自己信息的手段。",);

WaitForClick(); //··
//旁白
Script.Narration(dialogue = "对于变成幽灵、失去记忆的我，只有想要弄清自己死亡真相心情仍在驱动我继续思考下去。",);

WaitForClick(); //··
//文本框清空
Text.Clear();
//文本框隐藏
Text.ChangeAlpha(alpha_began = 1, alpha_ended = 0, time = 0.5,);
cmd_block
{
    //黑边退出
    at 0, Picture.Scale(name = "blackcover", scale_began = 0.8, scale_ended = 1, time = 1, curve = "uniform",);
    //BGM淡出
    at 0, BGM.Volume(volume_began = 0.7, volume_ended = 0, time = 1,);
}
//黑边删除
Picture.Release("blackcover",);
//更改图片
Picture.Change(name = "bg1", image = "//背景/B_第一章/08A_鸦巢公寓303室_正门夜晚搜证.png", time = 1, );
//切换草加裕介立绘并淡入
Tachie.Show(name = "Yusuke", image = "B05_草加裕介/A01_平静.png", alpha = 1, time = 0.5, );
//设定BGM
BGM.Set(audio = "//BGM/B04-会议记录.mp3", volume = 0.7, loop = true, loop_begin = 0, loop_end = 0,);
//文本框显现
Text.ChangeAlpha(alpha_began = 0, alpha_ended = 1, time = 0.5,);
//旁白
Script.Narration(dialogue = "把门锁插销放回原位后，草加裕介来到了尸体的痕迹固定线旁。",);

WaitForClick(); //··
cmd_block
{
    //切换女警员立绘并淡入
    at 0, Tachie.Show(name = "Police", image = "/F组/F02_女警察.png", alpha = 1, time = 0.75, );
    //女警员立绘进入
    at 0, Tachie.Position(name = "Police", x_began = 750, y_began = -475, x_ended = 350, y_ended = -475, time = 0.75, curve = "ease_in",);
    //草加裕介立绘左移
    at 0, Tachie.Position(name = "Yusuke", x_began = 0, y_began = -500, x_ended = -400, y_ended = -500, time = 0.75, curve = "ease_in",);
}
//切换立绘明暗
Tachie.Multiply(name = "Yusuke", factor = 0.4,);
//台词
Script.Dialogue(name = "女警员", dialogue = "草加警官。",);

WaitForClick(); //··
//切换立绘明暗
Tachie.Multiply(name = "Yusuke", factor = 2.5,);
Tachie.Multiply(name = "Police", factor = 0.4,);
Script.Dialogue(name = "草加 裕介", dialogue = "如何？可以对死因做出初步推断了吗？",);

WaitForClick(); //··
//切换立绘明暗
Tachie.Multiply(name = "Yusuke", factor = 0.4,);
Tachie.Multiply(name = "Police", factor = 2.5,);
//台词
Script.Dialogue(name = "女警员", dialogue = "嗯，鉴别组刚刚传来消息，被害人的死因是被4.5mm的气枪弹从正面击中心脏，失血过多导致休克死亡。",);

WaitForClick(); //··
//台词
Script.Dialogue(name = "女警员", dialogue = "值得一提的是，气枪子弹的材质是银的，所以极有可能是收藏品。",);

WaitForClick(); //··
//文本框清空
Text.Clear();
cmd_block
{
    //女警员立绘淡出
    at 0, Tachie.Alpha(name = "Police", alpha_began = 1, alpha_ended = 0, time = 0.5,);
    //草加裕介立绘淡出
    at 0, Tachie.Alpha(name = "Yusuke", alpha_began = 1, alpha_ended = 0, time = 0.5,);
}
//切换立绘明暗
Tachie.Multiply(name = "Yusuke", factor = 2.5,);
cmd_block
{
    //创建图片
    at 0, Picture.Create(name = "pic1", image = "//图片/B_第一章/07_地板上的子弹.png", scale = 0.6, x = 0, y = 210, alpha = 0,);
    //图片进入
    at 0, Picture.Move(name = "pic1", y_began = 210, y_ended = 110, time = 0.5, curve = "uniform", alpha_began = 0, alpha_ended = 1, alpha_time = 0.5,);
    //头像
    at 0, Script.Avatar(name = "女警员", dialogue = "地板上也找到了一枚相同口径的气枪弹，说明犯人行凶时至少开了两枪。", avater = "蓝/F组/F02_女警察.png",);
}

WaitForClick(); //··
//头像
Script.Avatar(name = "草加 裕介", dialogue = "这种子弹真的能射入人的心脏致人死亡吗？它甚至都没在地板上留下弹孔。", avater = "蓝/B05_草加裕介/A07_麻烦.png",);

WaitForClick(); //··
//台词
Script.Avatar(name = "女警员", dialogue = "可能是先击中了别的什么东西才被弹掉在地的吧，气枪的威力本来也无法与真正的火药枪相比。", avater = "蓝/F组/F02_女警察.png",);

WaitForClick(); //··
//旁白
Script.Narration(dialogue = "我下意识地瞟了眼地上的碎花瓶，按这个说法，就是它帮我抵挡了第一枚子弹。",);

WaitForClick(); //··
//台词
Script.Avatar(name = "女警员", dialogue = "另外从血迹来看，被害人在中弹后曾挣扎过一段时间，这导致我们很难确定子弹射来的方向。屋内也没有找到能够发射气枪子弹的凶器。", avater = "蓝/F组/F02_女警察.png",);

WaitForClick(); //··
//文本框清空
Text.Clear();
cmd_block
{
    //文本框隐去
    at 0, Text.ChangeAlpha(alpha_began = 1, alpha_ended = 0, time = 0.5,);
    //图片离场
    at 0, Picture.Move(name = "pic1", y_began = 110, y_ended = 10, time = 0.5, curve = "uniform", alpha_began = 1, alpha_ended = 0, alpha_time = 0.5,);
}
//删除图片
Picture.Release("pic1");
//播放SE
SE.Play(audio = "//SE/D_脚步声/05_登场的脚步声.ogg", volume = 0.8, loop = false,);
//背景移动
Picture.Move(name = "bg1", x_began = 0, y_began = 0, x_ended = 240, y_ended = -135, scale_began = 1, scale_ended = 1.25, time = 0.75, curve = "uniform",);
//更改草加裕介立绘到中央
Tachie.Set(name = "Yusuke", x = 0, y = -500,);
//更改女警员立绘到中央
Tachie.Set(name = "Police", x = 0, y = -475,);
cmd_block
{
    //文本框显现
    at 0, Text.ChangeAlpha(alpha_began = 0, alpha_ended = 1, time = 0.5,);
    //切换草加裕介立绘并淡入
    at 0, Tachie.Show(name = "Yusuke", image = "B05_草加裕介/A04_思考.png", alpha = 1, time = 0.5, );
}
//旁白
Script.Narration(dialogue = "草加裕介垂下头思考了片刻，然后来到了那台被锐器划过的储物柜前。",);

WaitForClick(); //··
cmd_block
{
    //更改立绘图片
    at 0, Tachie.Change(name = "Yusuke", image = "B05_草加裕介/A01_平静.png", time = 0.2, );
    //台词
    at 0, Script.Dialogue(name = "草加 裕介", dialogue = "从常识上考虑的话，屋内有这么明显的搏斗痕迹，子弹应该也是近距离射出的吧。",);
}

WaitForClick(); //··
cmd_block
{
    //切换角色立绘
    at 0, Tachie.Switch(name_A = "Yusuke", time_A = 0.2, name_B = "Police", time_B = 0.2, alpha_B = 1,);
    //台词
    at 0.2, Script.Dialogue(name = "女警员", dialogue = "唔……两个人扭打在一起，一方用了匕首，另一方用了气枪吗？",);
}

WaitForClick(); //··
cmd_block
{
    //切换角色立绘
    at 0, Tachie.Switch(name_A = "Police", time_A = 0.2, name_B = "Yusuke", time_B = 0.2, alpha_B = 1,);
    //台词
    at 0.2, Script.Dialogue(name = "草加 裕介", dialogue = "不，你再仔细看看这个痕迹，这大概不是匕首划出来的。",);
}

WaitForClick(); //··
cmd_block
{
    //草加裕介立绘淡出
    at 0, Tachie.Alpha(name = "Yusuke", alpha_began = 1, alpha_ended = 0, time = 0.5,);
    //旁白
    at 0, Script.Narration(dialogue = "不是匕首……",);
}
//选择肢（影响内置变量option的值）
Program.Select
(
    "optionA01",
    "是柴刀和棒球棍？",
    "是手斧？",
    "是羊角锤？",
);

//条件触发
if (optionA01_1 == true)
{
    //旁白
    at 0, Script.Narration(dialogue = "如果是这样的话，我应该挠脖子挠死。",);

    WaitForClick(); //··
}

cmd_block
{
    //女警员立绘淡入
    at 0, Tachie.Alpha(name = "Police", alpha_began = 0, alpha_ended = 1, time = 0.5,);
    //台词
    at 0, Script.Dialogue(name = "女警员", dialogue = "哦，我明白了，是安全斧锤！",);
}

WaitForClick(); //··
cmd_block
{
    //切换角色立绘
    at 0, Tachie.Switch(name_A = "Police", time_A = 0.2, name_B = "Yusuke", time_B = 0.2, alpha_B = 1,);
    //台词
    at 0.2, Script.Dialogue(name = "草加 裕介", dialogue = "我也是这么想的。能造成这种挥砍痕迹的利器，只有一面是斧刃一面是锤钩的逃生用斧锤。",);
}

WaitForClick(); //··
cmd_block
{
    //切换角色立绘
    at 0, Tachie.Switch(name_A = "Yusuke", time_A = 0.2, name_B = "Police", time_B = 0.2, alpha_B = 1,);
    //台词
    at 0.2, Script.Dialogue(name = "女警员", dialogue = "我这就去叫人检查一下附近街道的消防箱！",);
}

WaitForClick(); //··
//文本框清空
Text.Clear();
//播放SE
SE.Play(audio = "//SE/D_脚步声/07_急促的脚步声淡出.ogg", volume = 0.8, loop = false,);
cmd_block
{
    //文本框隐去
    at 0, Text.ChangeAlpha(alpha_began = 1, alpha_ended = 0, time = 0.5,);
    //女警员立绘淡出
    at 0, Tachie.Alpha(name = "Police", alpha_began = 1, alpha_ended = 0, time = 0.75,);
    //女警员立绘离场
    at 0, Tachie.Position(name = "Police", x_began = 0, y_began = -475, x_ended = 400, y_ended = -475, time = 0.75, curve = "ease_out",);
}
//背景移动
Picture.Move(name = "bg1", x_began = 240, y_began = -135, x_ended = 0, y_ended = 0, scale_began = 1.25, scale_ended = 1, time = 0.75, curve = "uniform",);
//草加裕介立绘淡入
Tachie.Alpha(name = "Yusuke", alpha_began = 0, alpha_ended = 1, time = 0.5,);
//等待
WaitCommand(0.5);
//播放SE
SE.Play(audio = "//SE/C_布料声/03_蹲下身.ogg", volume = 0.8, loop = false,);
cmd_block
{
    //草加裕介立绘淡出
    at 0, Tachie.Alpha(name = "Yusuke", alpha_began = 1, alpha_ended = 0, time = 0.5,);
    //草加裕介立绘下移
    at 0, Tachie.Position(name = "Yusuke", x_began = 0, y_began = -500, x_ended = 0, y_ended = -600, time = 0.5, curve = "uniform",);
    //文本框显现
    at 0, Text.ChangeAlpha(alpha_began = 0, alpha_ended = 1, time = 0.5,);
}
//旁白
Script.Narration(dialogue = "女警员走后，草加裕介蹲下身检查起了摆放在地面上的证物。",);

WaitForClick(); //··
cmd_block
{
    //创建图片
    at 0, Picture.Create(name = "pic1", image = "//图片/B_第一章/08_地板上的证物.png", scale = 0.6, x = 0, y = 210, alpha = 0,);
    //图片进入
    at 0, Picture.Move(name = "pic1", y_began = 210, y_ended = 110, time = 0.5, curve = "uniform", alpha_began = 0, alpha_ended = 1, alpha_time = 0.5,);
    //旁白
    at 0, Script.Narration(dialogue = "这些东西都是警察们在我的裤子口袋中找到的。",);
}

WaitForClick(); //··
//旁白
Script.Narration(dialogue = "右口袋内发现了钱包、钥匙串、数据线，左口袋内发现了手套、口罩、移动电源，不过左口袋里的三样东西都已经被血浸湿。",);

WaitForClick(); //··
//旁白
Script.Narration(dialogue = "我死前耳朵上和其他人一样佩戴着载波电极，不过已经被技术人员拿走修复了。口袋里的移动电源估计就是用来给载波电极充电的。",);

WaitForClick(); //··
//文本框清空
Text.Clear();
//图片离场
Picture.Move(name = "pic1", y_began = 110, y_ended = 10, time = 0.5, curve = "uniform", alpha_began = 1, alpha_ended = 0, alpha_time = 0.5,);
//删除图片
Picture.Release("pic1");
//播放SE
SE.Play(audio = "//SE/C_布料声/03_蹲下身.ogg", volume = 0.8, loop = false,);
cmd_block
{
    //切换草加裕介立绘并淡入
    at 0, Tachie.Show(name = "Yusuke", image = "B05_草加裕介/A01_平静.png", alpha = 1, time = 0.5, );
    //草加裕介立绘上移
    at 0, Tachie.Position(name = "Yusuke", x_began = 0, y_began = -600, x_ended = 0, y_ended = -500, time = 0.5, curve = "uniform",);
    //台词
    at 0, Script.Dialogue(name = "草加 裕介", dialogue = "这是幢居民公寓吧？有被害人入室盗窃的可能性吗？",);
}

WaitForClick(); //··
//文本框清空
Text.Clear();
cmd_block
{
    //切换男警员立绘并淡入
    at 0, Tachie.Show(name = "Police", image = "/F组/F01_男警察.png", alpha = 1, time = 0.75, );
    //男警员立绘进入
    at 0, Tachie.Position(name = "Police", x_began = 800, y_began = -500, x_ended = 400, y_ended = -500, time = 0.75, curve = "ease_in",);
    //草加裕介立绘左移
    at 0, Tachie.Position(name = "Yusuke", x_began = 0, y_began = -500, x_ended = -400, y_ended = -500, time = 0.75, curve = "ease_in",);
}
//切换立绘明暗
Tachie.Multiply(name = "Yusuke", factor = 0.4,);
//台词
Script.Dialogue(name = "男警员", dialogue = "暂时还不清楚，但房间的所有门窗都是从内侧锁上的，我们也没有从被害人身上找到可能用于盗窃的工具。",);

WaitForClick(); //··
//台词
Script.Dialogue(name = "男警员", dialogue = "等指纹鉴定结果出来，应该就能搞清楚了。",);

WaitForClick(); //··
//文本框清空
Text.Clear();
//切换立绘明暗
Tachie.Multiply(name = "Police", factor = 0.4,);
Tachie.Multiply(name = "Yusuke", factor = 2.5,);
//旁白
Script.Narration(dialogue = "就在这时，草加好像突然注意到了什么，将目光投向了一旁的卧室内。",);

WaitForClick(); //··
Tachie.Multiply(name = "Police", factor = 2.5,);
cmd_block
{
    //草加裕介立绘淡出
    at 0, Tachie.Alpha(name = "Yusuke", alpha_began = 1, alpha_ended = 0, time = 0.5,);
    //男警员立绘淡出
    at 0, Tachie.Alpha(name = "Police", alpha_began = 1, alpha_ended = 0, time = 0.5,);
}
cmd_block
{
    //背景移动
    at 0, Picture.Move(name = "bg1", x_began = 0, y_began = 0, x_ended = -165, y_ended = -135, scale_began = 1, scale_ended = 1.25, time = 0.75, curve = "uniform",);
    //旁白
    at 0, Script.Narration(dialogue = "我顺着他的目光望去，注意到卧室的床头柜抽屉夹住了一根数据线。",);
}

WaitForClick(); //··
cmd_block
{
    //创建图片
    at 0, Picture.Create(name = "pic2", image = "//图片/B_第一章/09_抽屉夹缝的数据线.png", scale = 1.1, x = 0, y = 0, alpha = 0,);
    //图片淡入
    at 0, Picture.Alpha(name = "pic2", alpha_began = 0, alpha_ended = 1, time = 0.7,);
    //旁白
    at 0, Script.Narration(dialogue = "草加皱着眉朝抽屉走去。如果有小偷光顾过这个房间的话，这个没合严实的抽屉很可能就有他留下的痕迹。",);
}

WaitForClick(); //··
//旁白
Script.Narration(dialogue = "然而，打开抽屉的瞬间——",);

WaitForClick(); //··
//播放SE
SE.Play(audio = "//SE/I-器件音/01_拉开抽屉.ogg", volume = 1, loop = false,);
cmd_block
{
    //更改图片
    at 0, Picture.Change(name = "pic2", image = "//图片/B_第一章/10_抽屉里的军刀.png", time = 0.7, );
    //旁白
    at 0, Script.Avatar(name = "草加 裕介", dialogue = "……？", avater = "蓝/B05_草加裕介/A03_严肃.png",);
}

WaitForClick(); //··
//头像
Script.Avatar(name = "男警员", dialogue = "草加警官！", avater = "蓝/F组/F01_男警察.png",);

WaitForClick(); //··
//头像
Script.Avatar(name = "草加 裕介", dialogue = "嘘！", avater = "蓝/B05_草加裕介/A03_严肃.png",);

WaitForClick(); //··
//旁白
Script.Narration(dialogue = "草加示意跟过来的警官噤声，然后戴上手套小心翼翼地从抽屉中取出了这柄军刀。",);

WaitForClick(); //··
//设定背景
Picture.Set(name = "bg1", image = "//背景/B_第一章/08D_鸦巢公寓303室_屋内夜晚搜证.png", scale = 1, x = 0, y = 0, angle = 0, alpha = 1, );
//图片淡出
Picture.Alpha(name = "pic2", alpha_began = 1, alpha_ended = 0, time = 0.7,);
//删除图片
Picture.Release("pic2");
//更改草加立绘坐标
Tachie.Set(name = "Yusuke", scale = 1, x = 0, y = -500,);
cmd_block
{
    //切换草加裕介立绘并淡入
    at 0, Tachie.Show(name = "Yusuke", image = "B05_草加裕介/A17_怀疑.png", alpha = 1, time = 0.5, );
    //台词
    at 0, Script.Dialogue(name = "草加 裕介", dialogue = "这个不是凶器……",);
}

WaitForClick(); //··
//文本框清空
Text.Clear();
cmd_block
{
    //切换男警员立绘并淡入
    at 0, Tachie.Show(name = "Police", image = "/F组/F01_男警察.png", alpha = 1, time = 0.75, );
    //男警员立绘进入
    at 0, Tachie.Position(name = "Police", x_began = 800, y_began = -500, x_ended = 400, y_ended = -500, time = 0.75, curve = "ease_in",);
    //草加裕介立绘左移
    at 0, Tachie.Position(name = "Yusuke", x_began = 0, y_began = -500, x_ended = -400, y_ended = -500, time = 0.75, curve = "ease_in",);
}
//切换立绘明暗
Tachie.Multiply(name = "Yusuke", factor = 0.4,);
//台词
Script.Dialogue(name = "男警员", dialogue = "草加警官，抱歉打扰您一下！熊取昌二找到了！",);

WaitForClick(); //··
//切换立绘明暗
Tachie.Multiply(name = "Yusuke", factor = 2.5,);
Tachie.Multiply(name = "Police", factor = 0.4,);
cmd_block
{
    //更改立绘图片
    at 0, Tachie.Change(name = "Yusuke", image = "B05_草加裕介/A03_严肃.png", time = 0.2, );
    //台词
    at 0, Script.Dialogue(name = "草加 裕介", dialogue = "什么？他在什么地方？",);
}

WaitForClick(); //··
//切换立绘明暗
Tachie.Multiply(name = "Yusuke", factor = 0.4,);
Tachie.Multiply(name = "Police", factor = 2.5,);
//台词
Script.Dialogue(name = "男警员", dialogue = "就在公寓楼下！他似乎是刚从外面回来的样子，看到公寓被拉起了警戒线十分惊讶……",);

WaitForClick(); //··
//文本框清空
Text.Clear();
cmd_block
{
    //男警员立绘淡出
    at 0, Tachie.Alpha(name = "Police", alpha_began = 1, alpha_ended = 0, time = 0.5,);
    //草加裕介立绘淡出
    at 0, Tachie.Alpha(name = "Yusuke", alpha_began = 1, alpha_ended = 0, time = 0.5,);
}
//切换立绘明暗
Tachie.Multiply(name = "Yusuke", factor = 2.5,);
//创建背景2
Picture.Create(name = "bg2", image = "//背景/B_第一章/08D_鸦巢公寓303室_屋内夜晚搜证.png", scale = 1.5, x = 240, y = -195, angle = 0, alpha = 0,);
cmd_block
{
    //背景2持续移动并淡入
    at 0, Picture.KeepMove(name = "bg2", x_began = 240, y_began = -195, x_ended = 480, y_ended = -195, scale_began = 1.5, scale_ended = 1.5, time = 16, curve = "uniform", alpha_began = 0, alpha_ended = 1, alpha_time = 0.5,);
    //旁白
    at 0, Script.Narration(dialogue = "话音未落，门外突然传来一阵骚动。",);
}

WaitForClick(); //··
//台词
Script.Dialogue(name = "？？？", dialogue = "喂，这是我家！你们在干什么！？",);

WaitForClick(); //··
//文本框清空
Text.Clear();
//设定背景
Picture.Set(name = "bg1", scale = 1.5, x = 480, y = -270, angle = 0, alpha = 1, );
//创建熊取昌二立绘，近景，y值在-750~800之间
Tachie.Create(name = "Shoji", image = "C06_熊取昌二/A04_不耐烦.png", scale = 1.25, x = 0, y = -750, alpha = 0, multiply = "#f5f1e9",);
//背景2淡出
Picture.Alpha(name = "bg2", alpha_began = 1, alpha_ended = 0, time = 0.5,);
//打断背景2持续运动
Picture.StopMove("bg2");
//删除背景2
Picture.Release("bg2");
//播放SE
SE.Play(audio = "//SE/D_脚步声/03_急促的脚步声.ogg", volume = 0.7, loop = false,);
cmd_block
{
    //熊取昌二立绘放大进入
    at 0, Tachie.TachieMove(name = "Shoji", x_began = -100, y_began = -650, x_ended = 0, y_ended = -750, scale_began = 1, scale_ended = 1.25, time = 1.8, curve = "uniform",);
    //熊取昌二立绘淡入
    at 0, Tachie.Alpha(name = "Shoji", alpha_began = 0, alpha_ended = 1, time = 1.8,);
    //旁白
    at 1.5, Script.Narration(dialogue = "一名戴墨镜的壮汉无视拦在门口的警察闯了进来，他的脸色十分愤怒，看上去对警察未经通告就擅闯自己家门的行为很不爽。",);
}

WaitForClick(); //··
//创建背景3
Picture.Create(name = "bg3", image = "//背景/B_第一章/08D_鸦巢公寓303室_屋内夜晚搜证.png", scale = 1.5, x = 480, y = -270, alpha = 1,);
cmd_block
{
    //熊取昌二立绘淡出
    at 0, Tachie.Alpha(name = "Shoji", alpha_began = 1, alpha_ended = 0, time = 0.5,);
    //旁白
    at 0, Script.Narration(dialogue = "草加裕介无奈地摇了摇头，从怀中掏出自己的警察手册走到了壮汉面前。",);
}

WaitForClick(); //··
//设置背景1参数
Picture.Set(name = "bg1", scale = 1.5, x = -480, y = -140,);
//背景1持续移动，从右向左
Picture.KeepMove(name = "bg1", x_began = -480, y_began = -140, x_ended = -160, y_ended = -140, scale_began = 1.5, scale_ended = 1.5, time = 60, curve = "uniform", alpha_began = 1, alpha_ended = 1, alpha_time = 0,);
//立绘持续移动
Tachie.KeepMove(name = "Yusuke", x_began = 400, y_began = -1000, x_ended = 250, y_ended = -1000, scale_began = 1.5, scale_ended = 1.5, angle_began = 0, angle_ended = 0, time = 60, curve = "uniform",);
cmd_block
{
    //背景3淡出
    at 0, Picture.Alpha(name = "bg3", alpha_began = 1, alpha_ended = 0, time = 1,);
    //切换草加裕介立绘并淡入
    at 0, Tachie.Show(name = "Yusuke", image = "B05_草加裕介/A02_微笑.png", alpha = 1, time = 1, );
    //台词
    at 0, Script.Dialogue(name = "草加 裕介", dialogue = "熊取昌二先生是吧？我是练马警署的草加裕介。",);
}

WaitForClick(); //··
//台词
Script.Dialogue(name = "草加 裕介", dialogue = "有一名男子被发现死在了您的寓所中，还请您配合我们的调查。",);

WaitForClick(); //··
//设置背景3参数
Picture.Set(name = "bg3", scale = 1.5, x = 480, y = -140,);
//背景3持续移动，从左向右
Picture.KeepMove(name = "bg3", x_began = 480, y_began = -140, x_ended = 160, y_ended = -140, scale_began = 1.5, scale_ended = 1.5, time =60, curve = "uniform", alpha_began = 0, alpha_ended = 0, alpha_time = 0,);
//立绘持续移动
Tachie.KeepMove(name = "Shoji", x_began = -400, y_began = -1000, x_ended = -250, y_ended = -1000, scale_began = 1.5, scale_ended = 1.5, angle_began = 0, angle_ended = 0, time = 60, curve = "uniform",);
cmd_block
{
    //草加裕介立绘淡出
    at 0, Tachie.Alpha(name = "Yusuke", alpha_began = 1, alpha_ended = 0, time = 0.5,);
    //背景3淡入
    at 0, Picture.Alpha(name = "bg3", alpha_began = 0, alpha_ended = 1, time = 0.5,);
    //熊取昌二立绘淡入
    at 0, Tachie.Alpha(name = "Shoji", alpha_began = 0, alpha_ended = 1, time = 0.5,);
    //台词
    at 0, Script.Dialogue(name = "熊取 昌二", dialogue = "……哈？",);
}
//打断草加裕介立绘的持续运动
Tachie.StopMove("Yusuke");
//打断背景1的持续运动
Picture.StopMove("bg1");

WaitForClick(); //··
//旁白
Script.Narration(dialogue = "熊取昌二推了下墨镜，脸上露出了难以置信的表情。",);

WaitForClick(); //··
//台词
Script.Dialogue(name = "熊取 昌二", dialogue = "<size=36>有人？ 被发现？ 死在了？ 我家？</size>",);

WaitForClick(); //··
//设置背景1参数
Picture.Set(name = "bg1", scale = 1.5, x = -480, y = -140,);
//背景1持续移动，从右向左
Picture.KeepMove(name = "bg1", x_began = -480, y_began = -140, x_ended = -160, y_ended = -140, scale_began = 1.5, scale_ended = 1.5, time = 60, curve = "uniform", alpha_began = 1, alpha_ended = 1, alpha_time = 0,);
//立绘持续移动
Tachie.KeepMove(name = "Yusuke", x_began = 400, y_began = -1000, x_ended = 250, y_ended = -1000, scale_began = 1.5, scale_ended = 1.5, angle_began = 0, angle_ended = 0, time = 60, curve = "uniform",);
cmd_block
{
    //熊取昌二立绘淡出
    at 0, Tachie.Alpha(name = "Shoji", alpha_began = 1, alpha_ended = 0, time = 0.5,);
    //背景3淡出
    at 0, Picture.Alpha(name = "bg3", alpha_began = 1, alpha_ended = 0, time = 0.5,);
    //草加裕介立绘淡入
    at 0, Tachie.Alpha(name = "Yusuke", alpha_began = 0, alpha_ended = 1, time = 0.5,);
    //台词
    at 0, Script.Dialogue(name = "草加 裕介", dialogue = "是的，请问一下您对照片上的男子有印象吗？",);
}
//打断熊取昌二立绘的持续运动
Tachie.StopMove("Shoji");
//打断背景1的持续运动
Picture.StopMove("bg3");

WaitForClick(); //··
//旁白
Script.Narration(dialogue = "草加裕介的手在空中一挥，将一张AR照片递到了熊取昌二面前。",);

WaitForClick(); //··
//设置背景3参数
Picture.Set(name = "bg3", scale = 1.5, x = 480, y = -140,);
//背景3持续移动，从左向右
Picture.KeepMove(name = "bg3", x_began = 480, y_began = -140, x_ended = 160, y_ended = -140, scale_began = 1.5, scale_ended = 1.5, time = 60, curve = "uniform", alpha_began = 0, alpha_ended = 0, alpha_time = 0,);
//更改立绘图片
Tachie.Change(name = "Shoji", image = "C06_熊取昌二/Z02_照片展开.png", time = 0, );
//立绘持续移动
Tachie.KeepMove(name = "Shoji", x_began = -400, y_began = -1000, x_ended = -250, y_ended = -1000, scale_began = 1.5, scale_ended = 1.5, angle_began = 0, angle_ended = 0, time = 60, curve = "uniform",);
cmd_block
{
    //播放SE
    at 0, SE.Play(audio = "//SE/A_系统音效/01_回路启动.ogg", volume = 0.4, loop = false,);
    //草加裕介立绘淡出
    at 0, Tachie.Alpha(name = "Yusuke", alpha_began = 1, alpha_ended = 0, time = 0.5,);
    //背景3淡入
    at 0, Picture.Alpha(name = "bg3", alpha_began = 0, alpha_ended = 1, time = 0.5,);
    //熊取昌二立绘淡入
    at 0, Tachie.Alpha(name = "Shoji", alpha_began = 0, alpha_ended = 1, time = 0.5,);
    //台词
    at 0, Script.Dialogue(name = "熊取 昌二", dialogue = "不认识。怎么，这就是那名死者？",);
}
//打断草加裕介立绘的持续运动
Tachie.StopMove("Yusuke");
//打断背景1的持续运动
Picture.StopMove("bg1");

WaitForClick(); //··
//设置背景1参数
Picture.Set(name = "bg1", scale = 1.5, x = -480, y = -140,);
//背景1持续移动，从右向左
Picture.KeepMove(name = "bg1", x_began = -480, y_began = -140, x_ended = -160, y_ended = -140, scale_began = 1.5, scale_ended = 1.5, time = 60, curve = "uniform", alpha_began = 1, alpha_ended = 1, alpha_time = 0,);
//立绘持续移动
Tachie.KeepMove(name = "Yusuke", x_began = 400, y_began = -1000, x_ended = 250, y_ended = -1000, scale_began = 1.5, scale_ended = 1.5, angle_began = 0, angle_ended = 0, time = 60, curve = "uniform",);
cmd_block
{
    //熊取昌二立绘淡出
    at 0, Tachie.Alpha(name = "Shoji", alpha_began = 1, alpha_ended = 0, time = 0.5,);
    //背景3淡出
    at 0, Picture.Alpha(name = "bg3", alpha_began = 1, alpha_ended = 0, time = 0.5,);
    //切换草加裕介立绘并淡入
    at 0, Tachie.Show(name = "Yusuke", image = "B05_草加裕介/A07_麻烦.png", alpha = 1, time = 0.5, );
    //台词
    at 0, Script.Dialogue(name = "草加 裕介", dialogue = "<b>不，这是您单位的销售部经理。</b>",);
}
//打断熊取昌二立绘的持续运动
Tachie.StopMove("Shoji");
//打断背景1的持续运动
Picture.StopMove("bg3");

WaitForClick(); //··
//设置背景3参数
Picture.Set(name = "bg3", scale = 1.25, x = 0, y = 0,);
//设置熊取昌二立绘参数
Tachie.Set(name = "Shoji", scale = 1.25, x = 0, y = -750, alpha = 0,);
cmd_block
{
    //草加裕介立绘淡出
    at 0, Tachie.Alpha(name = "Yusuke", alpha_began = 1, alpha_ended = 0, time = 0.5,);
    //背景3淡入
    at 0, Picture.Alpha(name = "bg3", alpha_began = 0, alpha_ended = 1, time = 0.5,);
    //切换熊取昌二立绘并淡入
    at 0, Tachie.Show(name = "Shoji", image = "C06_熊取昌二/A01_紧张.png", alpha = 1, time = 0.5, );
    //旁白
    at 0, Script.Narration(dialogue = "熊取昌二一愣，紧接着立马意识到自己被下套了。",);
}
//打断草加裕介立绘的持续运动
Tachie.StopMove("Yusuke");
//打断背景1的持续运动
Picture.StopMove("bg1");

WaitForClick(); //··
cmd_block
{
    //切换熊取昌二立绘
    at 0, Tachie.Change(name = "Yusuke", image = "C06_熊取昌二/A04_不耐烦.png", time = 0.2, );
    //台词
    at 0, Script.Dialogue(name = "熊取 昌二", dialogue = "<size=40>你……！</size>",);
}

WaitForClick(); //··
//设置草加裕介立绘参数
Tachie.Set(name = "Yusuke", scale = 1.25, x = 800, y = -750, alpha = 0,);
cmd_block
{
    //切换草加裕介立绘并淡入
    at 0, Tachie.Show(name = "Yusuke", image = "B05_草加裕介/A19_谨慎.png", alpha = 1, time = 0.75, );
    //草加裕介立绘进入
    at 0, Tachie.Position(name = "Yusuke", x_began = 800, y_began = -750, x_ended = 400, y_ended = -750, time = 0.75, curve = "ease_in",);
    //熊取昌二立绘左移
    at 0, Tachie.Position(name = "Shoji", x_began = 0, y_began = -750, x_ended = -400, y_ended = -750, time = 0.75, curve = "ease_in",);
}
//切换立绘明暗
Tachie.Multiply(name = "Shoji", factor = 0.4,);
//台词
Script.Dialogue(name = "草加 裕介", dialogue = "熊取先生，请您冷静下来，诚实地配合我们调查。",);

WaitForClick(); //··
//台词
Script.Dialogue(name = "草加 裕介", dialogue = "我理解自己家中发生了案子会让您很不知所措。但如果不管我问什么您都矢口否认的话，即使您真的不认识被害人，我们也很难采信您的陈述。",);

WaitForClick(); //··
//切换立绘明暗
Tachie.Multiply(name = "Shoji", factor = 2.5,);
Tachie.Multiply(name = "Yusuke", factor = 0.4,);
//台词
Script.Dialogue(name = "熊取 昌二", dialogue = "…………",);

WaitForClick(); //··
//文本框清空
Text.Clear();
//设置背景3参数
Picture.Set(name = "bg1", scale = 1, x = 0, y = 0,);
cmd_block
{
    //草加裕介立绘淡出
    at 0, Tachie.Alpha(name = "Yusuke", alpha_began = 1, alpha_ended = 0, time = 0.5,);
    //熊取昌二立绘淡出
    at 0, Tachie.Alpha(name = "Shoji", alpha_began = 1, alpha_ended = 0, time = 0.5,);
    //背景3淡出
    at 0, Picture.Alpha(name = "bg3", alpha_began = 1, alpha_ended = 0, time = 1,);
}
//切换立绘明暗
Tachie.Multiply(name = "Yusuke", factor = 2.5,);
//删除背景3
Picture.Release("bg3");
//设置熊取昌二立绘参数
Tachie.Set(name = "Shoji", scale = 1, x = 0, y = -500, alpha = 0,);
//设置草加裕介立绘参数
Tachie.Set(name = "Yusuke", scale = 1, x = 0, y = -500, alpha = 0,);
cmd_block
{
    //切换熊取昌二立绘并淡入
    at 0, Tachie.Show(name = "Shoji", image = "C06_熊取昌二/A02_严肃.png", alpha = 1, time = 0.5, );
    //台词
    at 0, Script.Dialogue(name = "熊取 昌二", dialogue = "我明白了，但你们不应该这样不加通知擅自登门办案。我想我有权了解我自己的家里发生了什么。",);
}

WaitForClick(); //··
cmd_block
{
    //切换角色立绘
    at 0, Tachie.Switch(name_A = "Shoji", time_A = 0.2, name_B = "Yusuke", image_B = "B05_草加裕介/A01_平静.png", time_B = 0.2, alpha_B = 1,);
    //台词
    at 0.2, Script.Dialogue(name = "草加 裕介", dialogue = "可以。不过在那之前，我们首先要确认熊取先生您是否有作案嫌疑。能否问一下您出门不在家的这段时间的行踪呢？",);
}

WaitForClick(); //··
cmd_block
{
    //切换角色立绘
    at 0, Tachie.Switch(name_A = "Yusuke", time_A = 0.2, name_B = "Shoji", time_B = 0.2, alpha_B = 1,);
    //台词
    at 0.2, Script.Dialogue(name = "熊取 昌二", dialogue = "我？我去了池袋那边的健身房。",);
}

WaitForClick(); //··
cmd_block
{
    //切换角色立绘
    at 0, Tachie.Switch(name_A = "Shoji", time_A = 0.2, name_B = "Yusuke", time_B = 0.2, alpha_B = 1,);
    //台词
    at 0.2, Script.Dialogue(name = "草加 裕介", dialogue = "你在晚上八点离家之后就前往了池袋，直到刚刚才回来，这期间一直不在家，对吗？",);
}


WaitForClick(); //··
cmd_block
{
    //切换角色立绘
    at 0, Tachie.Switch(name_A = "Yusuke", time_A = 0.2, name_B = "Shoji", time_B = 0.2, alpha_B = 1,);
    //台词
    at 0.2, Script.Dialogue(name = "熊取 昌二", dialogue = "没错。",);
}

WaitForClick(); //··
cmd_block
{
    //切换角色立绘
    at 0, Tachie.Switch(name_A = "Shoji", time_A = 0.2, name_B = "Yusuke", time_B = 0.2, alpha_B = 1,);
    //台词
    at 0.2, Script.Dialogue(name = "草加 裕介", dialogue = "可否借用一下您的BMI？我们需要调取一下位置数据以确认您所说的是否属实。",);
}

WaitForClick(); //··
cmd_block
{
    //切换角色立绘
    at 0, Tachie.Switch(name_A = "Yusuke", time_A = 0.2, name_B = "Shoji", time_B = 0.2, alpha_B = 1,);
    //台词
    at 0.2, Script.Dialogue(name = "熊取 昌二", dialogue = "没问题。",);
}

WaitForClick(); //··
cmd_block
{
    //熊取昌二立绘淡出
    at 0, Tachie.Alpha(name = "Shoji", alpha_began = 1, alpha_ended = 0, time = 0.5,);
    //旁白
    at 0, Script.Narration(dialogue = "熊取昌二说着，从耳后摘下自己的载波电极交给了一旁的警察。",);
}

WaitForClick(); //··
cmd_block
{
    //切换草加裕介立绘并淡入
    at 0, Tachie.Show(name = "Yusuke", image = "B05_草加裕介/A02_微笑.png", alpha = 1, time = 0.5, );
    //台词
    at 0, Script.Dialogue(name = "草加 裕介", dialogue = "那么，请先来随我检查一下您家中是否有物品失窃吧，我会将发生的情况一并告诉你。",);
}

WaitForClick(); //··
//文本框清空
Text.Clear();
cmd_block
{
    //文本框隐藏
    at 0, Text.ChangeAlpha(alpha_began = 1, alpha_ended = 0, time = 0.5,);
    //草加裕介立绘淡出
    at 0, Tachie.Alpha(name = "Yusuke", alpha_began = 1, alpha_ended = 0, time = 0.5,);
    //BGM音量调节
    at 0, BGM.Volume(volume_began = 1, volume_ended = 0, time = 1,);
    //时钟离场
    at 0.5, Picture.ClockOut(name = "bg1", time = 1,);
}
//等待
WaitCommand(0.5);



//读档标记点
ClearScene();

//————————————————————
//———————室内检查—————————
//————————————————————


//允许自动
CanAuto(true);
//UI模式：蓝色自由视角
SetUIMode(3);
SetChapter("01", "边界徘徊的七等星");
BGM.Stop();
CanSkip(true);
//创建背景，设定坐标
Picture.Create(name = "bg1", image = "//背景/B_第一章/08A_鸦巢公寓303室_正门夜晚搜证.png", x = 0, y = 0, alpha = 0);
//时钟入场
Picture.ClockIn(name = "bg1", time = 1,);
//设定BGM
BGM.Set(audio = "//BGM/B01-理论推演.mp3", volume = 0.7, loop = true, loop_begin = 0, loop_end = 0,);
//文本框显现
Text.ChangeAlpha(alpha_began = 0, alpha_ended = 1, time = 0.5,);
//旁白
Script.Narration(dialogue = "在熊取昌二的跟随下，草加裕介检查了他家中所有的抽屉和橱柜。",);

WaitForClick(); //··
//旁白
Script.Narration(dialogue = "过程中，他也将我尸体被发现的经过告诉了熊取昌二。",);

WaitForClick(); //··
//文本框清空
Text.Clear();
//创建草加裕介立绘，中景，y值在-400~500之间
Tachie.Create(name = "Yusuke", image = "B05_草加裕介/A01_平静.png", scale = 1, x = 0, y = -500, angle = 0, alpha = 0, multiply = "#f5f1e9",);
//创建熊取昌二立绘，中景，y值在-400~500之间
Tachie.Create(name = "Shoji", image = "C06_熊取昌二/A02_严肃.png", scale = 1, x = 0, y = -500, alpha = 0, multiply = "#f5f1e9",);
cmd_block
{
    //熊取昌二立绘淡入
    at 0, Tachie.Alpha(name = "Shoji", alpha_began = 0, alpha_ended = 1, time = 0.5,);
    //台词
    at 0, Script.Dialogue(name = "熊取 昌二", dialogue = "佐野阳向……我不认识这个人，也从来没听过他的名字。",);
}

WaitForClick(); //··
//台词
Script.Dialogue(name = "熊取 昌二", dialogue = "就算他是VIEW的开发者，我也从没用过这款软件，不信你们可以去查我BMI的安装记录。",);

WaitForClick(); //··
cmd_block
{
    //切换角色立绘
    at 0, Tachie.Switch(name_A = "Shoji", time_A = 0.2, name_B = "Yusuke", time_B = 0.2, alpha_B = 1,);
    //台词
    at 0.2, Script.Dialogue(name = "草加 裕介", dialogue = "可是他却在你出门的时候，死在了你的家中。",);
}

WaitForClick(); //··
cmd_block
{
    //切换角色立绘
    at 0, Tachie.Switch(name_A = "Yusuke", time_A = 0.2, name_B = "Shoji", image_B = "C06_熊取昌二/A01_紧张.png", time_B = 0.2, alpha_B = 1,);
    //台词
    at 0.2, Script.Dialogue(name = "熊取 昌二", dialogue = "是的、是的……所以我也一头雾水不知道发生了什么。",);
}

WaitForClick(); //··
cmd_block
{
    //切换角色立绘
    at 0, Tachie.Switch(name_A = "Shoji", time_A = 0.2, name_B = "Yusuke", image_B = "B05_草加裕介/A02_微笑.png", time_B = 0.2, alpha_B = 1,);
    //台词
    at 0.2, Script.Dialogue(name = "草加 裕介", dialogue = "熊取先生，我看这幢公寓的其他人家都安装了电子锁，可为什么你家用的仍然是传统的机械锁呢？",);
}

WaitForClick(); //··
cmd_block
{
    //切换角色立绘
    at 0, Tachie.Switch(name_A = "Yusuke", time_A = 0.2, name_B = "Shoji", image_B = "C06_熊取昌二/A02_严肃.png", time_B = 0.2, alpha_B = 1,);
    //台词
    at 0.2, Script.Dialogue(name = "熊取 昌二", dialogue = "因为我觉得电子锁不安全，网上每个星期都能看到有人因为电子锁被破解而遭到入户盗窃的新闻。",);
}

WaitForClick(); //··
cmd_block
{
    //切换角色立绘
    at 0, Tachie.Switch(name_A = "Shoji", time_A = 0.2, name_B = "Yusuke", image_B = "B05_草加裕介/A01_平静.png", time_B = 0.2, alpha_B = 1,);
    //台词
    at 0.2, Script.Dialogue(name = "草加 裕介", dialogue = "那你家的防盗门，除了使用钥匙以外应该没法从外侧开门吧？",);
}

WaitForClick(); //··
cmd_block
{
    //切换角色立绘
    at 0, Tachie.Switch(name_A = "Yusuke", time_A = 0.2, name_B = "Shoji", time_B = 0.2, alpha_B = 1,);
    //台词
    at 0.2, Script.Dialogue(name = "熊取 昌二", dialogue = "是的，除非有小偷会撬锁。",);
}

WaitForClick(); //··
cmd_block
{
    //切换角色立绘
    at 0, Tachie.Switch(name_A = "Shoji", time_A = 0.2, name_B = "Yusuke", image_B = "B05_草加裕介/A02_微笑.png", time_B = 0.2, alpha_B = 1,);
    //台词
    at 0.2, Script.Dialogue(name = "草加 裕介", dialogue = "那你家的钥匙都有哪些人持有？",);
}

WaitForClick(); //··
cmd_block
{
    //切换角色立绘
    at 0, Tachie.Switch(name_A = "Yusuke", time_A = 0.2, name_B = "Shoji", time_B = 0.2, alpha_B = 1,);
    //台词
    at 0.2, Script.Dialogue(name = "熊取 昌二", dialogue = "钥匙？我家总共三副门钥匙，一副你刚刚看到了<b>在鞋柜上没被动过</b>，一副<b>在我身上</b>，还有一副备用钥匙依照租赁合同是<b>由房东保管</b>的。",);
}

WaitForClick(); //··
cmd_block
{
    //切换角色立绘
    at 0, Tachie.Switch(name_A = "Shoji", time_A = 0.2, name_B = "Yusuke", image_B = "B05_草加裕介/A07_麻烦.png", time_B = 0.2, alpha_B = 1,);
    //台词
    at 0.2, Script.Dialogue(name = "草加 裕介", dialogue = "原来如此，我明白了。",);
}

WaitForClick(); //··
cmd_block
{
    //切换角色立绘
    at 0, Tachie.Switch(name_A = "Yusuke", time_A = 0.2, name_B = "Shoji", image_B = "C06_熊取昌二/A01_紧张.png", time_B = 0.2, alpha_B = 1,);
    //台词
    at 0.2, Script.Dialogue(name = "熊取 昌二", dialogue = "…………",);
}

WaitForClick(); //··
//播放SE
SE.Play(audio = "//SE/I-器件音/02_摘眼镜.ogg", volume = 0.4, loop = false,);
cmd_block
{
    //更改立绘图片
    at 0, Tachie.Change(name = "Shoji", image = "C06_熊取昌二/B01_紧张.png", time = 0.2, );
    //台词
    at 0, Script.Dialogue(name = "熊取 昌二", dialogue = "看样子，我家确实进过人。",);
}

WaitForClick(); //··
cmd_block
{
    //切换角色立绘
    at 0, Tachie.Switch(name_A = "Shoji", time_A = 0.2, name_B = "Yusuke", time_B = 0.2, alpha_B = 1,);
    //台词
    at 0.2, Script.Dialogue(name = "草加 裕介", dialogue = "哦？",);
}

WaitForClick(); //··
cmd_block
{
    //切换角色立绘
    at 0, Tachie.Switch(name_A = "Yusuke", time_A = 0.2, name_B = "Shoji", image_B = "C06_熊取昌二/B02_严肃.png", time_B = 0.2, alpha_B = 1,);
    //台词
    at 0.2, Script.Dialogue(name = "熊取 昌二", dialogue = "桌面上的那个盒子，不是我家的东西。",);
}

WaitForClick(); //··
//文本框清空
Text.Clear();
//熊取昌二立绘淡出
Tachie.Alpha(name = "Shoji", alpha_began = 1, alpha_ended = 0, time = 0.5,);
cmd_block
{
    //创建图片
    at 0, Picture.Create(name = "pic1", image = "//图片/B_第一章/11_桌上的密码盒.png", scale = 0.6, x = 0, y = 210, alpha = 0,);
    //图片进入
    at 0, Picture.Move(name = "pic1", y_began = 210, y_ended = 110, time = 0.5, curve = "uniform", alpha_began = 0, alpha_ended = 1, alpha_time = 0.5,);
    //旁白
    at 0, Script.Narration(dialogue = "草加裕介拿起盒子端详了一会儿。",);
}

WaitForClick(); //··
//头像
Script.Avatar(name = "草加 裕介", dialogue = "这是个密码盒。", avater = "蓝/B05_草加裕介/A03_严肃.png",);

WaitForClick(); //··
//头像
Script.Avatar(name = "熊取 昌二", dialogue = "我从来没买过这种密码盒。", avater = "蓝/C06_熊取昌二/B02_严肃.png",);

WaitForClick(); //··
//头像
Script.Avatar(name = "男警员", dialogue = "草加警官，需要破开这个盒子看看里面有什么吗？", avater = "蓝/F组/F01_男警察.png",);

WaitForClick(); //··
//头像
Script.Avatar(name = "草加 裕介", dialogue = "怎么可能，证物不能强行破坏。你提取一下指纹，看看哪里被按过不就好了。", avater = "蓝/B05_草加裕介/A01_平静.png",);

WaitForClick(); //··
//头像
Script.Avatar(name = "男警员", dialogue = "哦，也对。", avater = "蓝/F组/F01_男警察.png",);

WaitForClick(); //··
cmd_block
{
    //图片离场
    at 0, Picture.Move(name = "pic1", y_began = 110, y_ended = 10, time = 0.5, curve = "uniform", alpha_began = 1, alpha_ended = 0, alpha_time = 0.5,);
    //旁白
    at 0, Script.Narration(dialogue = "男警员拿出便携式的皮脂显像仪，对着密码盒的每个面各扫了一遍。",);
}
//删除图片
Picture.Release("pic1");

WaitForClick(); //··
//播放SE
SE.Play(audio = "//SE/A_系统音效/14_扫描完毕.ogg", volume = 1, loop = false,);
//旁白
Script.Narration(dialogue = "然后，他遗憾地摇了摇头。",);

WaitForClick(); //··
//创建男警员立绘，中景，y值在-400~500之间
Tachie.Create(name = "Police", image = "F组/F01_男警察.png", scale = 1, x = 0, y = -500, angle = 0, alpha = 0, multiply = "#f5f1e9",);
cmd_block
{
    //男警员立绘淡入
    at 0, Tachie.Alpha(name = "Police", alpha_began = 0, alpha_ended = 1, time = 0.5,);
    //台词
    at 0, Script.Dialogue(name = "男警员", dialogue = "这个密码盒上，没有指纹。",);
}

WaitForClick(); //··
cmd_block
{
    //男警员立绘淡出
    at 0, Tachie.Alpha(name = "Police", alpha_began = 1, alpha_ended = 0, time = 0.5,);
    //旁白
    at 0, Script.Narration(dialogue = "我扭头看了眼地上的证物，其中有从我口袋中搜出的一次性手套。",);
}

WaitForClick(); //··
//旁白
Script.Narration(dialogue = "难道说……这个盒子是我带进来的吗？",);

WaitForClick(); //··
//设置草加裕介立绘参数
Tachie.Set(name = "Yusuke", scale = 1, x = 400, y = -500, alpha = 0,);
//设置男警员立绘参数
Tachie.Set(name = "Police", scale = 1, x = -400, y = -500, alpha = 0,);
//更改立绘图片
Tachie.Change(name = "Yusuke", image = "B05_草加裕介/A01_平静.png", time = 0, );
cmd_block
{
    //草加裕介立绘淡入
    at 0, Tachie.Alpha(name = "Yusuke", alpha_began = 0, alpha_ended = 1, time = 0.5,);
    //男警员立绘淡入
    at 0, Tachie.Alpha(name = "Police", alpha_began = 0, alpha_ended = 1, time = 0.5,);
}
//切换立绘明暗
Tachie.Multiply(name = "Police", factor = 0.4,);
//台词
Script.Dialogue(name = "草加 裕介", dialogue = "那就这样，你回头拿着这个盒子去求助一趟科搜研。",);

WaitForClick(); //··
//切换立绘明暗
Tachie.Multiply(name = "Police", factor = 2.5,);
Tachie.Multiply(name = "Yusuke", factor = 0.4,);
//台词
Script.Dialogue(name = "男警员", dialogue = "是。",);

WaitForClick(); //··
//文本框清空
Text.Clear();
//播放SE
SE.Play(audio = "//SE/D_脚步声/07_急促的脚步声淡出.ogg", volume = 1, loop = false,);
cmd_block
{
    //男警员立绘淡出
    at 0, Tachie.Alpha(name = "Police", alpha_began = 1, alpha_ended = 0, time = 0.75,);
    //男警员立绘离场
    at 0, Tachie.Position(name = "Police", x_began = -400, y_began = -500, x_ended = -800, y_ended = -500, time = 0.75, curve = "ease_in",);
    //草加裕介立绘左移
    at 0, Tachie.Position(name = "Yusuke", x_began = 400, y_began = -500, x_ended = 0, y_ended = -500, time = 0.75, curve = "ease_in",);
}
//切换立绘明暗
Tachie.Multiply(name = "Yusuke", factor = 2.5,);
cmd_block
{
    //更改立绘图片
    at 0, Tachie.Change(name = "Yusuke", image = "B05_草加裕介/A02_微笑.png", time = 0.2, );
    //台词
    at 0, Script.Dialogue(name = "草加 裕介", dialogue = "除此之外呢？有发现丢什么东西吗？",);
}

WaitForClick(); //··
//设置熊取昌二立绘参数
Tachie.Set(name = "Shoji", scale = 1, x = 0, y = -500, alpha = 0,);
cmd_block
{
    //切换角色立绘
    at 0, Tachie.Switch(name_A = "Yusuke", time_A = 0.2, name_B = "Shoji", image_B = "C06_熊取昌二/B01_紧张.png", time_B = 0.2, alpha_B = 1,);
    //旁白
    at 0.2, Script.Narration(dialogue = "熊取昌二犹豫地点了点头。",);
}

WaitForClick(); //··
//台词
Script.Dialogue(name = "熊取 昌二", dialogue = "卧室床头柜的抽屉里……少了样东西。",);

WaitForClick(); //··
cmd_block
{
    //切换角色立绘
    at 0, Tachie.Switch(name_A = "Shoji", time_A = 0.2, name_B = "Yusuke", image_B = "B05_草加裕介/A02_微笑.png", time_B = 0.2, alpha_B = 1,);
    //台词
    at 0.2, Script.Dialogue(name = "草加 裕介", dialogue = "你是说这个吗？",);
}

WaitForClick(); //··
//文本框清空
Text.Clear();
//创建图片
Picture.Create(name = "pic1", image = "//图片/B_第一章/13_军刀.png", scale = 0.7, x = 0, y = 210, alpha = 0,);
cmd_block
{
    //立绘淡出
    at 0, Tachie.Alpha(name = "Yusuke", alpha_began = 1, alpha_ended = 0, time = 0.5,);
    //BGM淡出
    at 0, BGM.Volume(volume_began = 1, volume_ended = 0, time = 1,);
    //播放音效
    at 0.5, SE.Play(audio = "//SE/C_布料声/01_腾空而起.ogg", volume = 1, loop = false, );
    //图片进入
    at 0.5, Picture.Move(name = "pic1", y_began = 210, y_ended = 110, time = 0.5, curve = "uniform", alpha_began = 0, alpha_ended = 1, alpha_time = 0.5,);
    //旁白
    at 0.5, Script.Narration(dialogue = "草加裕介突然从怀里掏出了刚才找到的那把军刀。",);
}

WaitForClick(); //··
//头像
Script.Avatar(name = "熊取 昌二", dialogue = "<size=42>……！</size>", avater = "蓝/C06_熊取昌二/B05_吃惊.png",);

WaitForClick(); //··
//播放音效
SE.Play(audio = "//SE/D_脚步声/01_后退两步.ogg", volume = 1, loop = false, );
//旁白
Script.Narration(dialogue = "熊取昌二一惊，反射般地退后两步摆开了防御架势。",);

WaitForClick(); //··
//头像
Script.Avatar(name = "草加 裕介", dialogue = "别紧张，我连刀鞘都没取下来。", avater = "蓝/B05_草加裕介/A07_麻烦.png",);
//设定BGM
BGM.Set(audio = "//BGM/A01_Pulse_PVver.mp3", volume = 0, loop = true, loop_begin = 0, loop_end = 0,);
BGM.Set(audio = "//BGM/B01-理论推演.mp3", volume = 0.7, loop = true, loop_begin = 0, loop_end = 0,);

WaitForClick(); //··
//旁白
Script.Narration(dialogue = "草加裕介握住刀鞘，将刀柄的一面朝向了熊取。",);

WaitForClick(); //··
//旁白
Script.Narration(dialogue = "就在这时，我注意到了黑色刀柄上有一道暗红色的痕迹。",);

WaitForClick(); //··
//头像
Script.Avatar(name = "佐野 阳向", dialogue = "（这是什么？明明刚才还没有的……）", avater = "蓝/A02_佐野阳向/C07_惊讶.png",);

WaitForClick(); //··
//文本框清空
Text.Clear();
//图片离场
Picture.Move(name = "pic1", y_began = 110, y_ended = 10, time = 0.5, curve = "uniform", alpha_began = 1, alpha_ended = 0, alpha_time = 0.5,);
//删除图片
Picture.Release("pic1");
cmd_block
{
    //切换熊取昌二立绘并淡入
    at 0, Tachie.Show(name = "Shoji", image = "C06_熊取昌二/B04_不耐烦.png", alpha = 1, time = 0.5, );
    //台词
    at 0, Script.Dialogue(name = "熊取 昌二", dialogue = "难道说这是凶器？这不可能！警官，我是合法收藏刀具！在警局报备过的！",);
}

WaitForClick(); //··
cmd_block
{
    //切换角色立绘
    at 0, Tachie.Switch(name_A = "Shoji", time_A = 0.2, name_B = "Yusuke", image_B = "B05_草加裕介/A14_感兴趣.png", time_B = 0.2, alpha_B = 1,);
    //旁白
    at 0.2, Script.Narration(dialogue = "听到这话，草加裕介饶有兴趣地挑了挑眉毛。",);
}

WaitForClick(); //··
//台词
Script.Dialogue(name = "草加 裕介", dialogue = "<b>你……为什么会觉得这是凶器？</b>",);

WaitForClick(); //··
cmd_block
{
    //切换角色立绘
    at 0, Tachie.Switch(name_A = "Yusuke", time_A = 0.2, name_B = "Shoji", image_B = "C06_熊取昌二/B01_紧张.png", time_B = 0.2, alpha_B = 1,);
    //旁白
    at 0.2, Script.Narration(dialogue = "熊取昌二愣住了，他的目光下意识地瞟向了刀柄上的那道暗红色痕迹。",);
}

WaitForClick(); //··
cmd_block
{
    //切换角色立绘
    at 0, Tachie.Switch(name_A = "Shoji", time_A = 0.2, name_B = "Yusuke", image_B = "B05_草加裕介/A14_感兴趣.png", time_B = 0.2, alpha_B = 1,);
    //台词
    at 0.2, Script.Dialogue(name = "草加 裕介", dialogue = "哦，你是看到了这个啊。抱歉抱歉，这是我刚刚不小心蹭到的油漆，不是什么血迹。",);
}

WaitForClick(); //··
cmd_block
{
    //更改立绘图片
    at 0, Tachie.Change(name = "Yusuke", image = "B05_草加裕介/A08_苦笑.png", time = 0.2, );
    //旁白
    at 0, Script.Narration(dialogue = "草加裕介笑着将刀从鞘中拔出，刀刃确实锃亮如新，从没有沾染过血迹。",);
}

WaitForClick(); //··
//文本框清空
Text.Clear();
//草加裕介立绘隐去
Tachie.Hide(name = "Yusuke", time = 0.5,);
//旁白
Script.Narration(dialogue = "原来如此，我说他刚才怎么对抽屉里找到的军刀那么在意，原来是想到了可以借此试探户主的办法。",);

WaitForClick(); //··
//创建上下黑边
Picture.Create(name = "blackcover", image = "//背景/上下黑边.png", alpha = 1,);
cmd_block
{
    //黑边进入
    at 0, Picture.Scale(name = "blackcover", scale_began = 1, scale_ended = 0.8, time = 1, curve = "uniform",);
    //旁白
    at 0, Script.Narration(dialogue = "如果熊取昌二确如他所言一直不在家，那对于没见过我尸体的他，在看到地板上的血迹和柜子上那些划痕后，<b>很容易先入为主地认为我是受利器所伤致死</b>。",);
}

WaitForClick(); //··
//旁白
Script.Narration(dialogue = "反之，如果他是杀害我的凶手，<b>第一反应就不太可能认为刀是凶器</b>。",);

WaitForClick(); //··
//旁白
Script.Narration(dialogue = "简单明了的试探，这个草加警官的办案方法有点意思。",);

WaitForClick(); //··
//文本框清空
Text.Clear();
//黑边退出
Picture.Scale(name = "blackcover", scale_began = 0.8, scale_ended = 1, time = 1, curve = "uniform",);
//黑边删除
Picture.Release("blackcover",);
cmd_block
{
    //切换草加裕介立绘并淡入
    at 0, Tachie.Show(name = "Yusuke", image = "B05_草加裕介/A02_微笑.png", alpha = 1, time = 0.5, );
    //台词
    at 0, Script.Dialogue(name = "草加 裕介", dialogue = "放心，你不用担心自己被怀疑。",);
}

WaitForClick(); //··
//台词
Script.Dialogue(name = "草加 裕介", dialogue = "你也看到了客厅有犯人和被害人搏斗过的痕迹。如果这两人中有这间房子的住户，那他在遭遇攻击时肯定会选择跑进卧室拿刀防身。",);

WaitForClick(); //··
//台词
Script.Dialogue(name = "草加 裕介", dialogue = "但事实上搏斗痕迹只局限在了桌子边，没有向卧室靠近，这说明他们并不知道卧室的抽屉里有刀具。",);

WaitForClick(); //··
cmd_block
{
    //切换角色立绘
    at 0, Tachie.Switch(name_A = "Yusuke", time_A = 0.2, name_B = "Shoji", image_B = "C06_熊取昌二/B06_不悦.png", time_B = 0.2, alpha_B = 1,);
    //旁白
    at 0.2, Script.Dialogue(name = "熊取 昌二", dialogue = "哦，这样啊……",);
}

WaitForClick(); //··
//文本框清空
Text.Clear();
cmd_block
{
    //草加裕介立绘隐去
    at 0, Tachie.Hide(name = "Shoji", time = 0.5,);
    //旁白
    at 0, Script.Narration(dialogue = "看得出来，草加警官对熊取昌二的态度友善了不少。",);
}

WaitForClick(); //··
//旁白
Script.Narration(dialogue = "不过我觉得他这番不靠谱的推理应该是故意说给熊取昌二听的——为了降低对方的戒备心。",);

WaitForClick(); //··
//文本框清空
Text.Clear();
//创建上下黑边
UI.Create(name = "blackcover", image = "//背景/上下黑边.png", alpha = 1,);
cmd_block
{
    //黑边进入
    at 0, UI.Scale(name = "blackcover", scale_began = 1, scale_ended = 0.8, time = 1, curve = "uniform",);
    //文本框隐去
    at 0, Text.ChangeAlpha(alpha_began = 1, alpha_ended = 0, time = 0.5,);
}
//播放音效
SE.Play(audio = "//SE/J-人声/01_窃窃私语声.ogg", volume = 0.6, loop = false, );
//等待
WaitCommand(2.5);
//文本框显现
Text.ChangeAlpha(alpha_began = 0, alpha_ended = 1, time = 0.5,);
//旁白
Script.Narration(dialogue = "就在这时，屋内传来了一阵窃窃私语声。",);

WaitForClick(); //··
//创建男警员立绘
Tachie.Create(name = "PoliceMan", image = "F组/F01_男警察.png", scale = 1, x = -400, y = -500, alpha = 0, multiply = "#f5f1e9",);
//创建女警员立绘
Tachie.Create(name = "PoliceWoman", image = "F组/F02_女警察.png", scale = 1, x = 400, y = -475, alpha = 0, multiply = "#f5f1e9",);
cmd_block
{
    //男警员立绘淡入
    at 0, Tachie.Alpha(name = "PoliceMan", alpha_began = 0, alpha_ended = 1, time = 0.5,);
    //女警员立绘淡入
    at 0, Tachie.Alpha(name = "PoliceWoman", alpha_began = 0, alpha_ended = 1, time = 0.5,);
    //旁白
    at 0, Script.Narration(dialogue = "负责搜集现场物证的警察们不知为何聚在了一起，神情怪异地互相交头接耳。",);
}

WaitForClick(); //··
//文本框清空
Text.Clear();
cmd_block
{
    //黑边退出
    at 0, UI.Scale(name = "blackcover", scale_began = 0.8, scale_ended = 1, time = 1, curve = "uniform",);
    //男警员立绘淡出
    at 0, Tachie.Alpha(name = "PoliceMan", alpha_began = 1, alpha_ended = 0, time = 0.5,);
    //女警员立绘淡出
    at 0, Tachie.Alpha(name = "PoliceWoman", alpha_began = 1, alpha_ended = 0, time = 0.5,);
}
//删除男女警员立绘
Tachie.Release("PoliceMan");
Tachie.Release("PoliceWoman");
//黑边删除
UI.Release("blackcover",);
//打断所有音效
SE.Stop();
cmd_block
{
    //切换并显示草加裕介立绘
    at 0, Tachie.Show(name = "Yusuke", image = "B05_草加裕介/A02_微笑.png", alpha = 1, time = 0.5, );
    //台词
    at 0, Script.Dialogue(name = "草加 裕介", dialogue = "抱歉，熊取先生，我先失陪一下。今晚我们警方会另给你安排一间住所，还请您谅解。",);
}

WaitForClick(); //··
cmd_block
{
    //切换角色立绘
    at 0, Tachie.Switch(name_A = "Yusuke", time_A = 0.2, name_B = "Shoji", image_B = "C06_熊取昌二/B01_紧张.png", time_B = 0.2, alpha_B = 1,);
    //旁白
    at 0.2, Script.Dialogue(name = "熊取 昌二", dialogue = "……我知道了。",);
}

WaitForClick(); //··
//文本框清空
Text.Clear();
//播放音效
SE.Play(audio = "//SE/D_脚步声/08_登场的脚步声.ogg", volume = 0.8, loop = false, );
//熊取昌二退场
cmd_block
{
    at 0, Tachie.Position(name = "Shoji", x_began = 0, y_began = -500, x_ended = -300, y_ended = -500, time = 1, curve = "uniform");
    at 0, Tachie.Alpha(name = "Shoji", alpha_began = 1, alpha_ended = 0, time = 0.7,);
    //文本框隐去
    at 0.5, Text.ChangeAlpha(alpha_began = 1, alpha_ended = 0, time = 0.5,);
}
cmd_block
{
    //BGM淡出
    at 0, BGM.Volume(volume_began = 1, volume_ended = 0, time = 1,);
    //背景切换
    at 0.5, Picture.Change(name = "bg1", image = "//背景/B_第一章/08D_鸦巢公寓303室_屋内夜晚搜证.png", time = 0.5, );
}
cmd_block
{
    //切换并显示草加裕介立绘
    at 0, Tachie.Show(name = "Yusuke", image = "B05_草加裕介/A01_平静.png", alpha = 1, time = 0.5, );
    //文本框显现
    at 0, Text.ChangeAlpha(alpha_began = 0, alpha_ended = 1, time = 0.5,);
}
//旁白
Script.Narration(dialogue = "请走熊取昌二后，草加裕介收起笑容，走到了那群交头接耳的警察们面前。",);

WaitForClick(); //··
//台词
Script.Dialogue(name = "草加 裕介", dialogue = "怎么了？",);

WaitForClick(); //··
cmd_block
{
    //切换女警员立绘并淡入
    at 0, Tachie.Show(name = "Police", image = "/F组/F02_女警察.png", alpha = 1, time = 0.75, );
    //女警员立绘进入
    at 0, Tachie.Position(name = "Police", x_began = 750, y_began = -475, x_ended = 350, y_ended = -475, time = 0.75, curve = "ease_in",);
    //草加裕介立绘左移
    at 0, Tachie.Position(name = "Yusuke", x_began = 0, y_began = -500, x_ended = -400, y_ended = -500, time = 0.75, curve = "ease_in",);
}
//切换立绘明暗
Tachie.Multiply(name = "Yusuke", factor = 0.4,);
//台词
Script.Dialogue(name = "女警员", dialogue = "草加警官……你、你来看这个。",);

WaitForClick(); //··
//切换立绘明暗
Tachie.Multiply(name = "Yusuke", factor = 2.5,);
Tachie.Multiply(name = "Police", factor = 0.4,);
cmd_block
{
    //更改立绘图片
    at 0, Tachie.Change(name = "Yusuke", image = "B05_草加裕介/A17_怀疑.png", time = 0.2, );
    //台词
    at 0, Script.Dialogue(name = "草加 裕介", dialogue = "……?",);
}

WaitForClick(); //··
//切换立绘明暗
Tachie.Multiply(name = "Yusuke", factor = 0.4,);
//旁白
Script.Narration(dialogue = "警察们在空中点点画画，似乎是在用BMI展示某张图像。草加裕介看着他们的操作，眉头逐渐皱了起来。",);

WaitForClick(); //··
//切换立绘明暗
Tachie.Multiply(name = "Police", factor = 2.5,);
//台词
Script.Dialogue(name = "女警员", dialogue = "这里，是被害人的皮肤组织，这里、这里、和这里，是被害人中弹时溅出的血液。",);

WaitForClick(); //··
//台词
Script.Dialogue(name = "女警员", dialogue = "按理来说，屋内发生过搏斗，应该能找出另一人的血迹才对。但……",);

WaitForClick(); //··
cmd_block
{
    //台词
    at 0, Script.Dialogue(name = "女警员", dialogue = "我们仔细搜遍了303室的所有角落，<b>除了熊取昌二正常生活的痕迹以外……什么都没发现。</b>",);
    //播放音效
    at 0.4, SE.Play(audio = "//SE/G_氛围音/05_重点提示.ogg", volume = 0.6, loop = false, );
}

WaitForClick(); //··
//文本框清空
Text.Clear();
cmd_block
{
    //草加裕介立绘淡出
    at 0, Tachie.Alpha(name = "Yusuke", alpha_began = 1, alpha_ended = 0, time = 0.3,);
    //女警员立绘淡出
    at 0, Tachie.Alpha(name = "Police", alpha_began = 1, alpha_ended = 0, time = 0.3,);
}
//切换立绘明暗
Tachie.Multiply(name = "Yusuke", factor = 2.5,);
//草加裕介立绘设置坐标居中
Tachie.Set(name = "Yusuke", scale = 1, x = 0, y = -500,);
//女警察立绘设置坐标居中
Tachie.Set(name = "Police", scale = 1, x = 0, y = -475,);
cmd_block
{
    //切换草加裕介立绘并淡入
    at 0, Tachie.Show(name = "Yusuke", image = "B05_草加裕介/A03_严肃.png", alpha = 1, time = 0.2, );
    //台词
    at 0, Script.Dialogue(name = "草加 裕介", dialogue = "<size=38>……！</size>",);
}

WaitForClick(); //··
cmd_block
{
    //切换角色立绘
    at 0, Tachie.Switch(name_A = "Yusuke", time_A = 0.2, name_B = "Police", time_B = 0.2, alpha_B = 1,);
    //台词
    at 0.2, Script.Dialogue(name = "女警员", dialogue = "脚印、毛发、指纹、衣服纤维——什么都找不到！<b>这间房间根本没进过第三个人！</b>",);
}

WaitForClick(); //··
//设定BGM
BGM.Set(audio = "//BGM/E03-谜题校验.mp3", volume = 0.7, loop = true, loop_begin = 0, loop_end = 0,);
cmd_block
{
    //切换角色立绘
    at 0, Tachie.Switch(name_A = "Police", time_A = 0.2, name_B = "Yusuke", image_B = "B05_草加裕介/A10_懊恼.png", time_B = 0.2, alpha_B = 1,);
    //台词
    at 0.2, Script.Dialogue(name = "草加 裕介", dialogue = "那……熊取昌二是犯人的可能呢？",);
}

WaitForClick(); //··
cmd_block
{
    //切换角色立绘
    at 0, Tachie.Switch(name_A = "Yusuke", time_A = 0.2, name_B = "Police", time_B = 0.2, alpha_B = 1,);
    //台词
    at 0.2, Script.Dialogue(name = "女警员", dialogue = "也很小！熊取昌二的指纹分布位置太分散了，全都集中在常用家具上，和被害人在桌椅上打斗留下的凌乱指纹完全对不上。",);
}

WaitForClick(); //··
cmd_block
{
    //切换角色立绘
    at 0, Tachie.Switch(name_A = "Police", time_A = 0.2, name_B = "Yusuke", image_B = "B05_草加裕介/A09_烦躁.png", time_B = 0.2, alpha_B = 1,);
    //旁白
    at 0.2, Script.Narration(dialogue = "草加裕介的面色越发凝重，刚才试探熊取昌二时的自信和淡定荡然无存。",);
}

WaitForClick(); //··
cmd_block
{
    //切换角色立绘
    at 0, Tachie.Switch(name_A = "Yusuke", time_A = 0.2, name_B = "Police", time_B = 0.2, alpha_B = 1,);
    //台词
    at 0.2, Script.Dialogue(name = "女警员", dialogue = "这不可能，草加警官，这不可能！",);
}

WaitForClick(); //··
//台词
Script.Dialogue(name = "女警员", dialogue = "再怎么厉害的犯人，也做不到完全抹去自己在搏斗现场的生物痕迹，同时保留别人的生物痕迹！这简直就像是……",);

WaitForClick(); //··
cmd_block
{
    //切换角色立绘
    at 0, Tachie.Switch(name_A = "Police", time_A = 0.2, name_B = "Yusuke", image_B = "B05_草加裕介/A03_严肃.png", time_B = 0.2, alpha_B = 1,);
    //台词
    at 0.2, Script.Dialogue(name = "草加 裕介", dialogue = "<b>简直就像是被害人在和一团空气打架一样。</b>",);
}

WaitForClick(); //··
//文本框清空
Text.Clear();
//文本框隐去
Text.ChangeAlpha(alpha_began = 1, alpha_ended = 0, time = 0.5,);
//播放音效
SE.Play(audio = "//SE/G_氛围音/01_尖锐的滑音.ogg", volume = 0.8, loop = false, );
cmd_block
{
    //屏幕闪白
    at 0, Camera.SparkingWhite(0.3);
    //回忆滤镜
    at 0.3, Filter.MemoryOn();
    //草加裕介立绘隐藏
    at 0.3, Tachie.Hide(name = "Yusuke", time = 0,);
    //创建背景2
    at 0.3, Picture.Create(name = "bg2", image = "//背景/B_第一章/07G_鸦巢公寓三楼走廊_303室房门_魔法阵.png", scale = 1, x = 0, y = 0, alpha = 1,);
}
//闪白恢复
Camera.WhiteRestore(0.3);
//等待
WaitCommand(1.5);
cmd_block
{
    //屏幕闪白
    at 0, Camera.SparkingWhite(0.3);
    //关闭回忆滤镜
    at 0.3, Filter.MemoryOff();
    //删除背景2
    at 0.3, Picture.Release("bg2");
}
//闪白恢复
Camera.WhiteRestore(0.3);
//文本框显现
Text.ChangeAlpha(alpha_began = 0, alpha_ended = 1, time = 0.5,);
//旁白
Script.Narration(dialogue = "草加裕介说出这句话的瞬间，我脑海中闪过了门上那道魔法阵的图案。",);

WaitForClick(); //··
cmd_block
{
    //切换草加裕介立绘并淡入
    at 0, Tachie.Show(name = "Yusuke", image = "B05_草加裕介/A19_谨慎.png", alpha = 1, time = 0.5, );
    //台词
    at 0, Script.Dialogue(name = "草加 裕介", dialogue = "肯定有哪里出错了，你们确定仪器没问题吗？",);
}

WaitForClick(); //··
cmd_block
{
    //切换角色立绘
    at 0, Tachie.Switch(name_A = "Yusuke", time_A = 0.2, name_B = "Police", time_B = 0.2, alpha_B = 1,);
    //台词
    at 0.2, Script.Dialogue(name = "女警员", dialogue = "总不可能我们那么多人的仪器同时出问题吧……",);
}

WaitForClick(); //··
cmd_block
{
    //切换角色立绘
    at 0, Tachie.Switch(name_A = "Police", time_A = 0.2, name_B = "Yusuke", time_B = 0.2, alpha_B = 1,);
    //台词
    at 0.2, Script.Dialogue(name = "草加 裕介", dialogue = "现场勘查时的血液检测本来就很粗略，出错也没什么奇怪的。等把物证带回实验室慢慢做DNA分析，总能找出犯人的蛛丝马迹。",);
}

WaitForClick(); //··
cmd_block
{
    //切换角色立绘
    at 0, Tachie.Switch(name_A = "Yusuke", time_A = 0.2, name_B = "Police", time_B = 0.2, alpha_B = 1,);
    //台词
    at 0.2, Script.Dialogue(name = "女警员", dialogue = "是……",);
}

WaitForClick(); //··
//文本框清空
Text.Clear();
//男警员立绘淡出
Tachie.Hide(name = "Police", time = 0.5,);
//旁白
Script.Narration(dialogue = "…………",);

WaitForClick(); //··
//旁白
Script.Narration(dialogue = "不，不对。",);

WaitForClick(); //··
//旁白
Script.Narration(dialogue = "直觉告诉我，草加警官想得简单了。这不是普通的案件。",);

WaitForClick(); //··
//旁白
Script.Narration(dialogue = "随着警方的调查继续下去……肯定还会发生更多超出常理的事态。",);

WaitForClick(); //··
//文本框隐去
Text.Clear();
Text.ChangeAlpha(alpha_began = 1, alpha_ended = 0, time = 1,);




//————————————————————
//—————————结尾—————————
//————————————————————



cmd_block
{
    //背景淡出
    at 0, Picture.Alpha(name = "bg1", alpha_began = 1, alpha_ended = 0, time = 1.5,);
    //BGM淡出
    at 0, BGM.Volume(volume_began = 0.7, volume_ended = 0, time = 1.5,);
}
//禁止跳过
CanSkip(false);
StoryArrow(3, true);
JumpToScript("脚本/V2/sv_01_04.json");