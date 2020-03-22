using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LanguageManager : MonoBehaviour
{
    public static LanguageManager instance;

    public int Value = 0; //0 셀렉트 ,1 인게임, 2 튜토리얼

    public GameObject Default_Notion;
    public GameObject Skill_Notion;


    //셀렉트 - 메인화면
    public UILabel Main_Adventure;

    public UILabel Main_Nest;
    public UILabel Main_Achievements;
    public UILabel Main_Shop;
    public UILabel Main_Quest;
    public UILabel Main_Book;

    //TOP_UI
    public UILabel Main_NickName;
    public UILabel Main_HighScore;
    public UILabel Main_Rank;

    //점수 상세창
    public UILabel Main_Detail_Total;

    //등급 상세창
    public UILabel Main_Detail_Rank;
    public UILabel Main_Detail_Coin;
    public UILabel Main_Detail_Score;

    //게임 종료창
    public UILabel Main_GameEnd_Title;
    public UILabel Main_GameEnd_Info;
    public UILabel Main_GameEnd_Yes;
    public UILabel Main_GameEnd_No;

    //평점 주기창
    public UILabel Main_GameRate_Title;
    public UILabel Main_GameRate_Info;
    public UILabel Main_GameRate_Yes;
    public UILabel Main_GameRate_No;

    private List<UILabel> Main_txt = new List<UILabel>();

    private string[] Main_Korean = { "모험", "둥지", "업적", "상점", "기록", "도감" ,"닉네임","최고 점수","등급","합계","등급","코인","점수",
    "게임 종료","게임을 종료하시겠습니까?","예","아니요","게임 평가","\n게임에 대한 평점을 남겨주세요\n감사의 표시로 200다이아를 드릴께요!\n","예","아니요"};

    private string[] Main_English = { "Adventure", "Nest", "Achv", "Shop", "Record", "Book","NICKNAME","HIGH SCORE","RANK","Total","Rank","Coin","Score",
    "Confirm Exit","Do you want to quit the game?","Okay","Cancel","Rate Game","Would you mind taking a moment to rate it?\nThen I'll give you 200 gems as a token of my gratitude!","Rate it Now","No Thanks"};

    private string[] Main_Chinese = { "冒险", "巢穴", "业绩", "商店", "记录", "图鉴","昵称","最高分","等级","合计","等级","硬币","分数",
    "游戏结束","确定要结束游戏吗?","是","不是","游戏评价","\n请给游戏留下评分?\n为表示感谢,给您200个宝石!\n","估量","不用了"};

    private string[] Main_Japanese = { "冒険", "巣", "業績", "店", "記録", "図鑑","ニックネーム","最高点","ランク","合計","ランク","コイン","スコア",
    "終了を確認","ゲームを終了しますか?","はい","いいえ","ゲーム評価","少し時間を取って評価していただけますか\nそれから私はあなたに感謝として200ダイヤモンドを与えます！","今すぐ評価する","遠慮します"};


    //옵션창
    public UILabel Option_Title;
    public UILabel Option_Music;
    public UILabel Option_Sfx;
    public UILabel Option_Vibration;
    public UILabel Option_Google; 
    public UILabel Option_Language;
    public UILabel Option_Language_Title;
    public UILabel Option_Language_txt;
    public UILabel Option_Cupoon;
    public UILabel Option_Changename;
    public UILabel Option_Credit;
    public UILabel Option_Help;

    //쿠폰 창
    public UILabel Option_Detail_Cupoon;
    public UILabel Option_Detail_Exchange;

    //이름 변경창
    public UILabel Option_Detail_Nickname;

    //도움말
    public UILabel Option_Detail_Help;
    public UILabel Option_Detail_Blog;
    public UILabel Option_Detail_Rate;

    public UILabel Option_On_1;
    public UILabel Option_On_2;
    public UILabel Option_On_3;
    public UILabel Option_On_4;

    private List<UILabel> Option_txt = new List<UILabel>();

    private string[] Option_Korean = { "설정", "음악", "효과음", "진동", "구글 플레이 로그인", "언어", "언어", "한국어", "쿠폰", "이름 변경", "제작진", "도움말",
    "쿠폰 입력","교환","이름 변경","도움말","블로그","평가하기"};
    private string[] Option_Korean_On = { "켜짐", "꺼짐" };

    private string[] Option_English = {"Option", "Music", "SFX", "Vibration", "Google Play Sign_in", "Language","Language", "English", "Coupon", "Change Name", "Credit", "Help",
    "Enter Coupon","Exchange","Change Name","Help","Blog","Rate"};
    private string[] Option_English_On = { "ON", "OFF" };

    private string[] Option_Chinese = { "设定", "音乐", "效果音", "振动", "Google Play 登录 ", "语言", "语言", "簡体中文", "优惠券", "更名", "制作组", "助词",
    "输入优惠券","交换","更名","助词","博客","估价"};
    private string[] Option_Chinese_On = { "打开", "熄灭" };

    private string[] Option_Japanese = { "設定", "音楽", "効果音", "振動", "Google Play サインイン", "言語", "言語", "日本語", "クーポン", "名前の変更", "スタッフ", "ヘルプ",
    "クーポンを入力","交換","名前を変える","助けて","ブログ","評価"};
    private string[] Option_Japanese_On = { "オン", "オフ" };

    //게임 선택창
    public UILabel GameStart_Level;
    public UILabel GameStart_Tutorial;
    public UILabel GameStart_SinglePlay;
    public UILabel GameStart_Easy;
    public UILabel GameStart_Normal;
    public UILabel GameStart_Hard;
    public UILabel GameStart_Easy_Info;
    public UILabel GameStart_Normal_Info;
    public UILabel GameStart_Hard_Info;
    public UILabel GameStart_MultiPlay;
    public UILabel GameStart_1vs1;
    public UILabel GameStart_MultiInfo;

    //조력자 선택창
    public UILabel GameStart_Aid;
    public UILabel GameStart_Owl_Levelup;
    public UILabel GameStart_Owl_Info;
    public UILabel GameStart_Duck_Levelup;
    public UILabel GameStart_Duck_Info;
    public UILabel GameStart_Nothing;
    public UILabel GameStart_GameStart;
    public UILabel GameStart_UnRocked;
    public UILabel GameStart_UnRocked2;

    private List<UILabel> GameStart_txt = new List<UILabel>();


    private string[] GameStart_Korean = { "난이도 선택","튜토리얼","싱글 플레이","쉬움","보통","어려움","초보자를 위한 모드입니다.","일반적인 모험 모드입니다.","하드코어 유저를 위한 모드입니다.",
    "멀티 플레이","접속하기","사람들과 함께 보스를 처지하고 전리품을 획득하세요!","조력자 선택","레벨 업","밤에 체력을 회복합니다.","레벨 업","날아오는 물체를 막아줍니다.","없음","모험 시작!","잠금 해제","잠금 해제"};

    private string[] GameStart_English = { "Select Difficulties","Tutorial","Single Play","Easy","Normal","Hard","This mode is for beginners.","Typical Adventure mode.","Mode for hardcore users.",
    "Multi Play"," Connect","Eliminate the Boss with People and Win the spoils!","Select Helper","Level Up","Rejuvenate at night.","Level Up","It blocks the flying object.","None","Start adventure!","Unlock","Unlock"};

    private string[] GameStart_Chinese = { "难易度选择","教程","Single Play","下", "中", "上","是为新手设计的模式。","一般的冒险模式。","为硬核用户的模式。",
    "Multi Play","连接","与人一起处置老板,获得战利品!","助手的选择","升级","晚上恢复体力。","等级","阻挡飞来的物体。","无","冒险开始!","解锁","解锁"};

    private string[] GameStart_Japanese = { "難易度選択","チュートリアル","チュートリアル","下", "中", "上","このモードは初心者向けです。","通常のアドベンチャーモード。","このモードは、ハードコアユーザー向けです。",
    "マルチプレイ","つなぐ","人と一緒にボスを倒して戦利品を獲得してください!","ヘルパーの選択","レベルアップ","夜に若返り。","レベルアップ","飛行物体を防ぎます。","なし","冒険スタート!","ロック解除","ロック解除"};

    //둥지
    public UILabel Nest_Main_Black;
    public UILabel Nest_Main_White;
    public UILabel Nest_Main_Eagle;
    public UILabel Nest_Main_Dora;

    public UILabel Nest_Detail_Skin;
    public UILabel Nest_SunShine_Skin;
    public UILabel Nest_Clocking_Skin;
    public UILabel Nest_Rainbow_Skin;
    public UILabel Nest_None_Skin;

    public UILabel Nest_Detail_Select;

    public UILabel Nest_Detail_DoveStats;
    public UILabel Nest_Detail_Health;
    public UILabel Nest_Detail_Strong_Weather;
    public UILabel Nest_Detail_Diffculty;
    public UILabel Nest_Detail_Weak_Weather;

    public UILabel Nest_Detail_Skill;
    public UILabel Nest_Detail_SkillPoint;
    public UILabel Nest_Detail_Skill_Reset;
    public UILabel Nest_Detail_Skill_Level_Up;

    public UILabel Nest_Detail_Skill_1;
    public UILabel Nest_Detail_Skill_2;
    public UILabel Nest_Detail_Skill_3;
    public UILabel Nest_Detail_Skill_4;
    public UILabel Nest_Detail_Skill_5;
    public UILabel Nest_Detail_Skill_6;
    public UILabel Nest_Detail_Skill_7;
    public UILabel Nest_Detail_Skill_8;
    public UILabel Nest_Detail_Skill_9;
    public UILabel Nest_Detail_Skill_10;

    private List<UILabel> Nest_txt = new List<UILabel>();

    private string[] Nest_Korean = { "구구","루루","수리수리","도라","스킨","태양광\n스킨","클로킹\n스킨","무지개\n스킨","출시\n예정",
    "선택","비둘기 정보","체력","강한 날씨","난이도","약한 날씨","스킬","스킬 포인트","초기화","레벨업 하기",
    "체력 증가","스킬 지속시간 증가","코인 값 증가","아이템 지속시간 증가","무적 시간 증가","이동 속도 증가","피버모드 시간 증가","스킬 쿨타임 감소","점수 2배 획득 확률","코인 2배 획득 확률"};

    public string[] Nest_Info_Korean = { "둥지", "구구", "루루", "수리수리", "도라", "착용 가능", "착용 불가", "착용 해제", "쉬움", "보통", "어려움", "낮", "밤", "비" };


    private string[] Nest_English = { "GuGu", "LuLu", "SuliSuli","Dora","SKIN","Sunshine\nSkin","Cloaking\nSkin","Rainbow\nSkin","Coming\nSoon",
    "SELECT","Dove Stats","HEALTH","STRONG  WEATHER","DIFFICULTY","WEAK WEATHER","SKILL","SKILL POINT","Reset","Level Up",
    "Increase Health","Increase Skill Duration","Increase Coin Value","Increase Item Duration","Increase Invincible Time","Increase Speed","Increase Fever Mode Time","Reduced Skill Cooltime",
    "Twice the Score","Twice the Coin"};

    public string[] Nest_Info_English = { "Nest" , "Gugu", "Lulu", "Sulisuli", "Dora" ,"Wearable","Cannot Wear","Wear off","Easy","Noraml","Hard","Sunshine","Night","Rain"};

    private string[] Nest_Chinese = { "古古", "露露", "苏里苏里", "多拉", "主题","太阳能\n皮肤", "隐蔽\n皮肤","彩虹\n皮肤","计划上市",
    "选择","鸽子的情报","体力","强天气","难易度","弱天气","技能","扣球","初始化","等级做",
    "体力增加","技能持续时间增加","硬币价格增加","单品持续时间增加","无敌时间增加","移动速度增加","比弗莫德时间增加","等待时间减少","分数双得率","硬币双倍获得概率"};

    public string[] Nest_Info_Chinese = { "巢穴", "古古", "露露", "苏里苏里", "多拉", "可以穿着", "不可穿戴", "解套", "下", "中", "上", "昼", "夜", "雨" };

    private string[] Nest_Japanese = { "ググ", "ルル", "スリスリ", "ドーラ", "スキン", "太陽光\nスキン","透明\nスキン","虹\nnスキン","発売予定",
    "選択","鳩の情報","体力","強い天気","難易度","弱い天気","スキル","スキル点数","リセット","レベルアップ",
    "体力増加","スキル持続時間増加","コインの値増加","アイテムの継続時間増加","無敵時間増加","速度増加","最大モード時間を増加","スキルクールタイム短縮",
    "スコアの2倍","コインの二倍"};

    public string[] Nest_Info_Japanese = { "巣", "ググ", "ルル", "スリスリ", "ドーラ", "着用可能", "着用不可能", "着用解除", "下", "中", "上", "昼", "夜","雨"};


    public UILabel Achieve_Title;
    public UILabel Achieve_Google;

    private List<UILabel> Achieve_txt = new List<UILabel>();

    private string[] Achieve_Korean = { "업적","구글 업적" };
    private string[] Achieve_English = { "Achievements", "Google Achv" };
    private string[] Achieve_Chinese = { "业绩", "Google 业绩" };
    private string[] Achieve_Japanese = { "業績", "Google 業績" };


    public UILabel Shop_Title;
    public UILabel Shop_Egg_Info;
    public UILabel Shop_Incubator;
    public UILabel Shop_Egg_Title;
    public UILabel Shop_Free;
    public UILabel Shop_Item_Title;
    public UILabel Shop_Coin_Title;
    public UILabel Shop_Free2;
    //알 정보
    public UILabel Shop_Egg_Info_Title;
    public UILabel Shop_Egg_Info_Common;
    //부화기
    public UILabel Shop_Incubator_Exit;
    public UILabel Shop_Incubator_Alarm;

    private List<UILabel> Shop_txt = new List<UILabel>();

    private string[] Shop_Korean = { "상점", "알 정보", "알 부화기", "알", "무료", "아이템", "코인", "무료", "알 정보", "공통", "나가기","클릭한 알은 바로 열립니다"};
    private string[] Shop_English = { "Shop","Egg Info","Incubator","Egg","Free","Item","Coin","Free","Egg Infomation","Common","Exit", "The touched egg opens immediately" };
    private string[] Shop_Chinese = { "店","鸡蛋信息","卵培养箱","蛋","免费的","项目","硬币","免费的","鸡蛋信息" ,"共同","出口","您触摸的鸡蛋会立即打开"};
    private string[] Shop_Japanese = { "店","卵情報", "卵孵化", "卵","無料", "アイテム", "コイン", "無料","卵情報", "共通", "出口" , "クリックした卵はすぐ孵化します" };

    public string[] Shop_Main_Korean = { "비둘기 알", "부엉이 알", "독수리 알", "황금 알", "입장권", "광고 시청", "코인 주머니", "코인 바구니", "코인 통" };
    public string[] Shop_Rare_Korean = { "희귀", "초희귀", "영웅", "전설", "어려움 난이도" };
    public string[] Shop_Buy_Korean = { "구매", "시청" };

    public string[] Incubator_Egg_Korean = { "코인", "다이아", "도라의 깃털", "태양광 스킨", "클로킹 스킨", "무지개 스킨", "루루 캐릭터", "수리수리 캐릭터", "도라 캐릭터", "부엉이", "오리" };
    public string[] Incubator_Rare_Korean = { "소비 아이템", "퀘스트 아이템", "스킨 아이템", "캐릭터 아이템" };


    public string[] Shop_Main_English = { "Dove Egg", "Owl Egg","Eagle Egg", "Gold Egg", "Admission", "Watch an Ad", "Pouch of Coins", "Bucket of Coins", "Barrel of Gems" };
    public string[] Shop_Rare_English = { "Rare", "Super Rare", "Epic", "Legendary", "Hard Level" };
    public string[] Shop_Buy_English = { "Confirm", "Watch" };

    public string[] Incubator_Egg_English= { "Coin", "Gem", "Dora's Feather", "Sunshine Skin", "Clocking Skin", "Rainbow Skin", "Character LuLu", "Character SuliSuli", "Character Dora", "Owl", "Duck" };
    public string[] Incubator_Rare_English = { "Consumption Item", "Quest Item", "Skin Item", "Character Item" };


    public string[] Shop_Main_Chinese = { "鸽子蛋" , "猫头鹰卵", "老鹰蛋", "金蛋", "门票", "观看广告", "硬币袋", "硬币篮子", "硬币筒" };
    public string[] Shop_Rare_Chinese = { "稀有", "超级稀有", "史诗般的", "传说", "难易度" };
    public string[] Shop_Buy_Chinese = { "采购", "收视" };

    public string[] Incubator_Egg_Chinese = { "硬币", "宝石", "主题羽毛", "太阳能皮肤", "隐蔽皮肤", "彩虹皮肤", "角色露露", "角色苏里苏里", "角色多拉", "猫头鹰", "鸭" };
    public string[] Incubator_Rare_Chinese = { "消费项目", "奎斯特单品", "皮肤项目","角色项目"};


    public string[] Shop_Main_Japanese = { "鳩アル", "フクロウの卵", "ワシアルの卵", "金の卵" ,"入場券", "広告視聴", "コインポケット","コインバスケット","コイン桶"};
    public string[] Shop_Rare_Japanese = { "希少", "超希少", "英雄", "伝説","ハードレベル"};
    public string[] Shop_Buy_Japanese = { "確認","見る" };

    public string[] Incubator_Egg_Japanese = { "コイン","宝石" ,"ドラの羽", "太陽光スキン", "透明スキン", "虹nスキン", "キャラクタールル", "キャラクタースリスリ", "キャラクタードラ", "フクロウ", "アヒル"};
    public string[] Incubator_Rare_Japanese = { "消費アイテム" ,"ミッションアイテム","スキンアイテム","キャラクターアイテム"};


    public UILabel Book_Title;
    public UILabel Book_Object;
    public UILabel Book_Item;
    public UILabel Book_Dead;

    private List<UILabel> Book_txt = new List<UILabel>();

    private string[] Book_Korean = { "도감","오브젝트","아이템","사망 수집" };
    private string[] Book_English = { "Book" ,"Object","Item","Death Collection"};
    private string[] Book_Chinese = { "图鉴", "客体", "项目", "死亡收集" };
    private string[] Book_Japanese = { "図鑑", "客体", "アイテム", "死亡収集" };

    public string[] Book_Dead_Korean = { "배고파서 사망", "충돌 사고", "쳐맞아 사망", "교통 사고", "의문사", "UFO 납치", "???", "???", "???" };
    public string[] Book_Dead_English = { "Died of Hunger", "Collision", "Beaten to Death", "Car Accident", "Mysterious Death", "Kidnapping to UFO", "???", "???", "???" };
    public string[] Book_Dead_Chinese = { "饿死", "撞死", "被打死", "交通事故", "死于未知", "UFO绑架", "???", "???", "???" };
    public string[] Book_Dead_Japanese = { "お腹すいて死亡", "衝突事故", "殴打死亡", "交通事故", "突然死", "UFO拉致", "???", "???", "???" };


    public UILabel Record_Title;

    private List<UILabel> Record_txt = new List<UILabel>();

    public string[] Record_Korean = { "기록" };
    public string[] Record_English = { "Record" };
    public string[] Record_Chinese = { "记录" };
    public string[] Record_Japanese = { "記録" };

    public string[] Record_Main_Korean = { "난이도", "단계", "점수", "생존 시간", "사망 원인" };
    public string[] Record_Name_Korean = { "구구", "루루", "수리수리", "도라" };
    public string[] Record_Level_Korean = { "쉬움", "보통", "어려움" };

    public string[] Record_Main_English = { "Level","Stage","Score","Survival Time","Cause of Death" };
    public string[] Record_Name_English = { "GuGu", "LuLu", "SuliSuli", "Dora" };
    public string[] Record_Level_English = { "Easy","Normal","Hard" };

    public string[] Record_Main_Chinese = { "难易度", "阶段", "分数", "生存时间", "死亡原因" };
    public string[] Record_Name_Chinese = { "古古", "露露", "苏里苏里", "多拉" };
    public string[] Record_Level_Chinese = { "下", "中", "上" };

    public string[] Record_Main_Japanese = { "レベル", "ステージ", "スコア", "生存時間", "死亡原因" };
    public string[] Record_Name_Japanese = { "ググ", "ルル", "スリスリ", "ドーラ" };
    public string[] Record_Level_Japanese = { "下", "中", "上" };

    public string On = "";
    public string Off = "";

    public int Language;

    //인게임

    public UILabel InGame_Score; //점수
    public UILabel InGame_Best; //최고 점수

    //옵션
    public UILabel InGame_Option_Title;
    public UILabel InGame_Option_Music;
    public UILabel InGame_Option_SFX;
    public UILabel InGame_Option_Vibration;
    public UILabel InGame_Option_Exit;
    public UILabel InGame_Option_Continue;

    //게임 오버창
    public UILabel InGame_Over_Title;
    public UILabel InGame_Over_Reason; //사망 원인 :
    public UILabel InGame_Over_Ad;
    public UILabel InGame_Over_Continue;
    public UILabel InGame_Over_Exit;

    //게임 결과창
    public UILabel InGame_End_Title;
    public UILabel InGame_End_NowScore;
    public UILabel InGame_End_HighScore;
    public UILabel InGame_End_NowStage;
    public UILabel InGame_End_HighStage;
    public UILabel InGame_End_NowTimer;
    public UILabel InGame_End_HighTimer;
    public UILabel InGame_End_GetDiamond;
    public UILabel InGame_End_GetCoin;
    public UILabel InGame_End_GetFeather;
    public UILabel InGame_End_Ad;
    public UILabel InGame_End_Exit;


    private List<UILabel> InGame_txt = new List<UILabel>();

    private string[] InGame_Korean = { "점수", "최고점수", "설정", "음악", "효과음", "진동", "나가기", "계속하기",
    "게임 오버","사망 원인 : ","광고 시청","이어 하기","포기하기",
    "게임 결과","현재 점수","최고 점수","현재 단계","최고 단계","생존 시간","최대 생존 시간","획득 다이아","획득 코인","획득 깃털","광고 시청 코인 +100%","떠나기" };

    public string[] InGame_Level_Korean = { "쉬움", "보통", "어려움" };
    public string[] InGame_Korean_On = { "켜짐", "꺼짐" };
    public string[] InGame_Notion_Korean = { "체력", "코인", "다이아", "깃털", "점수" };

    public string InGame_Stage_Korean = " 단계";
    public string InGame_Count_Korean = "남은 횟수 : ";
    public string InGame_Best_Korean = "최고 기록!";
    public string InGame_UFO_Korean = "경고 : UFO가 다가오고 있습니다.";


    private string[] InGame_English = { "Score", "Best", "Option", "Music", "SFX", "Vibration", "Exit", "Continue",
    "Game Over","Cause of Death : ","Watch an Ad","Continue","Leave",
    "Game Result","Now Score","High Score","Now Stage","High Stage","Now Survival Time","High Survival Time","Get Gems","Get Coins","Get Feathers","Watch an Ad Coin +100%","Leave" };

    public string[] InGame_Level_English = { "Easy", "Normal", "Hard" };
    public string[] InGame_English_On = { "ON", "OFF" };
    public string[] InGame_Notion_English = { "HP", "Coin", "Gem", "Feather","Score" };

    public string InGame_Stage_English = " Stage";
    public string InGame_Count_English = "Remain Count : ";
    public string InGame_Best_English = "Best Record!";
    public string InGame_UFO_English = "Warning: UFO is coming.";


    private string[] InGame_Chinese = { "分数","最高分","设定","音乐","效果音","振动","出口","继续",
    "游戏结束","死亡原因 : ","观看广告","接续","放弃",
    "游戏结束","现分","最高分","现在阶段","最高阶段","生存时间","高生存时间","获得宝石","获得硬币","获得羽毛","观看广告 硬币 +100%","离开"};

    public string[] InGame_Level_Chinese = { "下", "中", "上" };
    public string[] InGame_Chinese_On = { "打开", "熄灭" };
    public string[] InGame_Notion_Chinese = { "生命值", "硬币", "钻石", "羽毛", "分数" };

    public string InGame_Stage_Chinese = " 阶段";
    public string InGame_Count_Chinese = "余数 : ";
    public string InGame_Best_Chinese = "创最高纪录!";
    public string InGame_UFO_Chinese = "警告：UFO正在逼近。";


    private string[] InGame_Japanese = { "スコア","ベスト","オプション","音楽","効果音","振動","出口","継続",
    "ゲームオーバー","死亡原因 : ","広告視聴","継続","放棄",
    "ゲームの結果","現在のスコア","最高スコア","現在の段階","最高の段階","生存時間","大生存時間","獲得宝石","獲得コイン","獲得羽","広告視聴 コイン +100%","発つ"};

    public string[] InGame_Level_Japanese = { "下", "中", "上" };
    public string[] InGame_Japanese_On = { "オン", "オフ" };
    public string[] InGame_Notion_Japanese = { "体力", "コイン", "宝石", "羽" ,"スコア"};

    public string InGame_Stage_Japanese = " 段階";
    public string InGame_Count_Japanese = "残回数 : ";
    public string InGame_Best_Japanese = "最高記録！";
    public string InGame_UFO_Japanese = "警告：UFOが近かづいてきています。";








    public string[] Main_God_Korean = { "야생의 산신령이 대화를 걸어왔다. ", "원하는 상자를 골라보거라. 선물을 하나 주마.", "허허허 그 선물이 마음에 들겠구나.",
        "(산신령은 구름 속으로 유유히 사라졌다.)" };
    public string[] Main_Mole1_Korean = { "야생의 두더지가 대화를 걸어왔다.", "지하세계 한 번 가볼래?" , "좋아. 그럼 지하세계로 보내줄께." ,"싫어? 그러면 어쩔 수 없지." ,
        "(아무 일도 일어나지 않았다.)" };
    public string[] Main_Mole2_Korean = { "나 쓰다듬어줄래?", "이상한 느낌이다.", "(두더지를 쓰다듬자 몸이 이상하다.)" };
    public string[] Main_God_Present_Korean = {"1번 상자","2번 상자","3번 상자"  };
    public string[] Main_Mole_Present_Korean = { "그래!","좋아!","싫어!" };
    public string[] Main_Talk_Name_Korean = { "산신령", "두더지" };
    public string[] Box_Present_Korean = { "꽝!", "자석", "미니 포션", "기압계", "해킹툴", "시간의 모래시계" };

    public string[] Main_God_English = { "A wild mountain spirit has spoken.", "Choose the box you want. I'll give you a present.", "Hahaha. I'm sure you'll like that present.", "(The mountain god disappeared gently into the clouds.)" };
    public string[] Main_Mole1_English = { "Wild moles have been talking.", "Do you want to go to the underworld?", "All right, Then, I'll send you to the underworld.",
        "You don't want to? Then there's nothing you can do.", "(Nothing happened.)" };
    public string[] Main_Mole2_English = { "Can you stroke me?", "It feels strange.", "(I feel strange when I stroke a mole.)" };
    public string[] Main_God_Present_English = { "Box 1", "Box 2", "Box 3" };
    public string[] Main_Mole_Present_English = { "Okay!", "Good!", "Hate!" };
    public string[] Main_Talk_Name_English = { "Mountain spirit", "Mole" };
    public string[] Box_Present_English = { "BAM!", "Magnet", "Mini potion", "Barometer", "Hack Tool", "Hourglass of time" };

    public string[] Main_God_Chinese = { "野生的山神走了过来。", "挑出你想要的箱子来。 送一份礼物。", "呵呵,那件礼物我可中意了。", "(山神在云中悠悠地消失了。)" };
    public string[] Main_Mole1_Chinese = { "野生的鼹鼠走过来了。", "去地下世界看看?", "好吧,那我就送你到地下世界去。", "讨厌吗?那没有办法。", "(什么事都没有发生。)" };
    public string[] Main_Mole2_Chinese = { "能抚摸我吗?", "感觉怪怪的。", "抚摸着鼹鼠,身体怪怪的。" };
    public string[] Main_God_Present_Chinese = { "一号箱", "2号箱", "3号箱" };
    public string[] Main_Mole_Present_Chinese = { "是啊!", "好!", "不要!" };
    public string[] Main_Talk_Name_Chinese = { "山神", "鼹鼠" };
    public string[] Box_Present_Chinese = { "咣!", "磁铁", "迷你动作", "气压计", "黑客工具", "时间的沙漏" };

    public string[] Main_God_Japanese = { "野生の山神霊が話をかけてきた。", "希望のボックスを選んで見なさい。 プレゼントを一つあげよう。", "ホホホそのプレゼントが心に挙げましょね。", "(山神霊は雲の中に悠々と消えた。)" };
    public string[] Main_Mole1_Japanese = { "野生のモグラが話をかけてきた。", "地下世界に一度行ってみる?", "良い。 それでは,地下世界に送ってあげるよ。", "嫌い?それでは,仕方ない。", "(何も起こらなかった。)" };
    public string[] Main_Mole2_Japanese = { "私なでてくれる?", "おかしいな感じだ。", "モグラをなでると者の体がおかしい。" };
    public string[] Main_God_Present_Japanese = { "1回箱", "2回箱", "3回箱" };
    public string[] Main_Mole_Present_Japanese = { "はい!", "好き!", "いや!" };
    public string[] Main_Talk_Name_Japanese = { "山神霊", "モグラ" };
    public string[] Box_Present_Japanese = { "ブーム!", "磁石", "ミニポーション", "気圧計", "ハッキングツール", "時間の砂時計" };

    //튜토리얼
    public UILabel Tutorial_Option_Title;
    public UILabel Tutorial_Option_Exit;
    public UILabel Tutorial_Option_Continue;

    private List<UILabel> Tutorial_txt = new List<UILabel>();

    private string[] Tutorial_Korean = { "설정", "나가기", "계속하기" };
    public string[] Tutorial_Title_Korean = { "튜토리얼", "잘했어요!", "체력","사망하였습니다." };

    private string[] Tutorial_English = { "Option","Continue","Exit" };
    public string[] Tutorial_Title_English = { "Tutorial","Good!","HP", "You Died." };

    private string[] Tutorial_Chinese = { "设定", "出口", "继续" };
    public string[] Tutorial_Title_Chinese = { "教程","好!", "生命值", "已死亡。" };

    private string[] Tutorial_Japanese = { "オプション", "出口", "継続" };
    public string[] Tutorial_Title_Japanese = { "チュートリアル", "良い!", "体力", "死亡しました。" };

    void Awake()
    {
        instance = this;
        Language = PlayerPrefs.GetInt("Language", 0);

        if (Value == 0)
        {
            Default_Notion.SetActive(false);

            Main_txt.Add(Main_Adventure);
            Main_txt.Add(Main_Nest);
            Main_txt.Add(Main_Achievements);
            Main_txt.Add(Main_Shop);
            Main_txt.Add(Main_Quest);
            Main_txt.Add(Main_Book);
            Main_txt.Add(Main_NickName);
            Main_txt.Add(Main_HighScore);
            Main_txt.Add(Main_Rank);

            Main_txt.Add(Main_Detail_Total);
            Main_txt.Add(Main_Detail_Rank);
            Main_txt.Add(Main_Detail_Coin);
            Main_txt.Add(Main_Detail_Score);
            Main_txt.Add(Main_GameEnd_Title);
            Main_txt.Add(Main_GameEnd_Info);
            Main_txt.Add(Main_GameEnd_Yes);
            Main_txt.Add(Main_GameEnd_No);
            Main_txt.Add(Main_GameRate_Title);
            Main_txt.Add(Main_GameRate_Info);
            Main_txt.Add(Main_GameRate_Yes);
            Main_txt.Add(Main_GameRate_No);

            Option_txt.Add(Option_Title);
            Option_txt.Add(Option_Music);
            Option_txt.Add(Option_Sfx);
            Option_txt.Add(Option_Vibration);
            Option_txt.Add(Option_Google);
            Option_txt.Add(Option_Language);
            Option_txt.Add(Option_Language_Title);
            Option_txt.Add(Option_Language_txt);
            Option_txt.Add(Option_Cupoon);
            Option_txt.Add(Option_Changename);
            Option_txt.Add(Option_Credit);
            Option_txt.Add(Option_Help);

            Option_txt.Add(Option_Detail_Cupoon);
            Option_txt.Add(Option_Detail_Exchange);
            Option_txt.Add(Option_Detail_Nickname);
            Option_txt.Add(Option_Detail_Help);
            Option_txt.Add(Option_Detail_Blog);
            Option_txt.Add(Option_Detail_Rate);

            GameStart_txt.Add(GameStart_Level);
            GameStart_txt.Add(GameStart_Tutorial);
            GameStart_txt.Add(GameStart_SinglePlay);
            GameStart_txt.Add(GameStart_Easy);
            GameStart_txt.Add(GameStart_Normal);
            GameStart_txt.Add(GameStart_Hard);
            GameStart_txt.Add(GameStart_Easy_Info);
            GameStart_txt.Add(GameStart_Normal_Info);
            GameStart_txt.Add(GameStart_Hard_Info);
            GameStart_txt.Add(GameStart_MultiPlay);
            GameStart_txt.Add(GameStart_1vs1);
            GameStart_txt.Add(GameStart_MultiInfo);

            GameStart_txt.Add(GameStart_Aid);
            GameStart_txt.Add(GameStart_Owl_Levelup);
            GameStart_txt.Add(GameStart_Owl_Info);
            GameStart_txt.Add(GameStart_Duck_Levelup);
            GameStart_txt.Add(GameStart_Duck_Info);
            GameStart_txt.Add(GameStart_Nothing);
            GameStart_txt.Add(GameStart_GameStart);
            GameStart_txt.Add(GameStart_UnRocked);
            GameStart_txt.Add(GameStart_UnRocked2);

            Nest_txt.Add(Nest_Main_Black);
            Nest_txt.Add(Nest_Main_White);
            Nest_txt.Add(Nest_Main_Eagle);
            Nest_txt.Add(Nest_Main_Dora);

            Nest_txt.Add(Nest_Detail_Skin);
            Nest_txt.Add(Nest_SunShine_Skin);
            Nest_txt.Add(Nest_Clocking_Skin);
            Nest_txt.Add(Nest_Rainbow_Skin);
            Nest_txt.Add(Nest_None_Skin);

            Nest_txt.Add(Nest_Detail_Select);

            Nest_txt.Add(Nest_Detail_DoveStats);
            Nest_txt.Add(Nest_Detail_Health);
            Nest_txt.Add(Nest_Detail_Strong_Weather);
            Nest_txt.Add(Nest_Detail_Diffculty);
            Nest_txt.Add(Nest_Detail_Weak_Weather);

            Nest_txt.Add(Nest_Detail_Skill);
            Nest_txt.Add(Nest_Detail_SkillPoint);
            Nest_txt.Add(Nest_Detail_Skill_Reset);
            Nest_txt.Add(Nest_Detail_Skill_Level_Up);

            Nest_txt.Add(Nest_Detail_Skill_1);
            Nest_txt.Add(Nest_Detail_Skill_2);
            Nest_txt.Add(Nest_Detail_Skill_3);
            Nest_txt.Add(Nest_Detail_Skill_4);
            Nest_txt.Add(Nest_Detail_Skill_5);
            Nest_txt.Add(Nest_Detail_Skill_6);
            Nest_txt.Add(Nest_Detail_Skill_7);
            Nest_txt.Add(Nest_Detail_Skill_8);
            Nest_txt.Add(Nest_Detail_Skill_9);
            Nest_txt.Add(Nest_Detail_Skill_10);

            Achieve_txt.Add(Achieve_Title);
            Achieve_txt.Add(Achieve_Google);

            Shop_txt.Add(Shop_Title);
            Shop_txt.Add(Shop_Egg_Info);
            Shop_txt.Add(Shop_Incubator);
            Shop_txt.Add(Shop_Egg_Title);
            Shop_txt.Add(Shop_Free);
            Shop_txt.Add(Shop_Item_Title);
            Shop_txt.Add(Shop_Coin_Title);
            Shop_txt.Add(Shop_Free2);
            Shop_txt.Add(Shop_Egg_Info_Title);
            Shop_txt.Add(Shop_Egg_Info_Common);
            Shop_txt.Add(Shop_Incubator_Exit);
            Shop_txt.Add(Shop_Incubator_Alarm);

            Book_txt.Add(Book_Title);
            Book_txt.Add(Book_Object);
            Book_txt.Add(Book_Item);
            Book_txt.Add(Book_Dead);

            Record_txt.Add(Record_Title);
        }
        else if (Value == 1)
        {
            Default_Notion.SetActive(false);
            Skill_Notion.SetActive(false);

            InGame_txt.Add(InGame_Score);
            InGame_txt.Add(InGame_Best);

            InGame_txt.Add(InGame_Option_Title);
            InGame_txt.Add(InGame_Option_Music);
            InGame_txt.Add(InGame_Option_SFX);
            InGame_txt.Add(InGame_Option_Vibration);
            InGame_txt.Add(InGame_Option_Exit);
            InGame_txt.Add(InGame_Option_Continue);

            InGame_txt.Add(InGame_Over_Title);
            InGame_txt.Add(InGame_Over_Reason);
            InGame_txt.Add(InGame_Over_Ad);
            InGame_txt.Add(InGame_Over_Continue);
            InGame_txt.Add(InGame_Over_Exit);

            InGame_txt.Add(InGame_End_Title);
            InGame_txt.Add(InGame_End_NowScore);
            InGame_txt.Add(InGame_End_HighScore);
            InGame_txt.Add(InGame_End_NowStage);
            InGame_txt.Add(InGame_End_HighStage);
            InGame_txt.Add(InGame_End_NowTimer);
            InGame_txt.Add(InGame_End_HighTimer);
            InGame_txt.Add(InGame_End_GetDiamond);
            InGame_txt.Add(InGame_End_GetCoin);
            InGame_txt.Add(InGame_End_GetFeather);
            InGame_txt.Add(InGame_End_Ad);
            InGame_txt.Add(InGame_End_Exit);
        }
        else if (Value == 2)
        {
            Default_Notion.SetActive(false);
            Skill_Notion.SetActive(false);

            Tutorial_txt.Add(Tutorial_Option_Title);
            Tutorial_txt.Add(Tutorial_Option_Exit);
            Tutorial_txt.Add(Tutorial_Option_Continue);
        }
        else if (Value == 3)
        {
            Default_Notion.SetActive(false);
        }
        Change_Language(Language);

    }

    //언어 설정
    public void Korean()
    {
        Language = 0;
        PlayerPrefs.SetInt("Language", Language);
        Change_Language(Language);
        SelectManager.instance.Exit();
        //SelectManager.instance.Exit();
    }
    public void English()
    {
        Language = 1;
        PlayerPrefs.SetInt("Language", Language);
        Change_Language(Language);
        SelectManager.instance.Exit();
        //SelectManager.instance.Exit();
    }
    public void Chinese()
    {
        Language = 2;
        PlayerPrefs.SetInt("Language", Language);
        Change_Language(Language);
        SelectManager.instance.Exit();
        //SelectManager.instance.Exit();
    }
    public void Japanese()
    {
        Language = 3;
        PlayerPrefs.SetInt("Language", Language);
        Change_Language(Language);
        SelectManager.instance.Exit();
        //SelectManager.instance.Exit();
    }
    public void Change_Language(int number)
    {
        if(number == 0)
        {
            if(Value == 0)
            {
                On = Option_Korean_On[0];
                Off = Option_Korean_On[1];

                for (int i = 0; i < Main_txt.Count; i++)
                {
                    Main_txt[i].text = Main_Korean[i];
                }

                for (int i = 0; i < Option_txt.Count; i++)
                {
                    Option_txt[i].text = Option_Korean[i];
                }

                for (int i = 0; i < GameStart_txt.Count; i++)
                {
                    GameStart_txt[i].text = GameStart_Korean[i];
                }

                for (int i = 0; i < Nest_txt.Count; i++)
                {
                    Nest_txt[i].text = Nest_Korean[i];
                }

                for (int i = 0; i < Achieve_txt.Count; i++)
                {
                    Achieve_txt[i].text = Achieve_Korean[i];
                }

                for (int i = 0; i < Shop_txt.Count; i++)
                {
                    Shop_txt[i].text = Shop_Korean[i];
                }

                for (int i = 0; i < Book_txt.Count; i++)
                {
                    Book_txt[i].text = Book_Korean[i];
                }

                for (int i = 0; i < Record_txt.Count; i++)
                {
                    Record_txt[i].text = Record_Korean[i];
                }

                SelectManager.instance.DefaultOption();
            }
            else if(Value == 1)
            {
                for (int i = 0; i < InGame_txt.Count; i++)
                {
                    InGame_txt[i].text = InGame_Korean[i];
                }
            }
            else if (Value == 2)
            {
                for (int i = 0; i < Tutorial_txt.Count; i++)
                {
                    Tutorial_txt[i].text = Tutorial_Korean[i];
                }
            }

        }
        else if(number == 1)
        {
            if (Value == 0)
            {
                On = Option_English_On[0];
                Off = Option_English_On[1];

                for (int i = 0; i < Main_txt.Count; i++)
                {
                    Main_txt[i].text = Main_English[i];
                }

                for (int i = 0; i < Option_txt.Count; i++)
                {
                    Option_txt[i].text = Option_English[i];
                }

                for (int i = 0; i < GameStart_txt.Count; i++)
                {
                    GameStart_txt[i].text = GameStart_English[i];
                }

                for (int i = 0; i < Nest_txt.Count; i++)
                {
                    Nest_txt[i].text = Nest_English[i];
                }

                for (int i = 0; i < Achieve_txt.Count; i++)
                {
                    Achieve_txt[i].text = Achieve_English[i];
                }

                for (int i = 0; i < Shop_txt.Count; i++)
                {
                    Shop_txt[i].text = Shop_English[i];
                }

                for (int i = 0; i < Book_txt.Count; i++)
                {
                    Book_txt[i].text = Book_English[i];
                }

                for (int i = 0; i < Record_txt.Count; i++)
                {
                    Record_txt[i].text = Record_English[i];
                }

                SelectManager.instance.DefaultOption();
            }
            else if (Value == 1)
            {
                for (int i = 0; i < InGame_txt.Count; i++)
                {
                    InGame_txt[i].text = InGame_English[i];
                }
            }
            else if (Value == 2)
            {
                for (int i = 0; i < Tutorial_txt.Count; i++)
                {
                    Tutorial_txt[i].text = Tutorial_English[i];
                }
            }
        }
        else if (number == 2)
        {
            if (Value == 0)
            {
                On = Option_Chinese_On[0];
                Off = Option_Chinese_On[1];

                for (int i = 0; i < Main_txt.Count; i++)
                {
                    Main_txt[i].text = Main_Chinese[i];
                }

                for (int i = 0; i < Option_txt.Count; i++)
                {
                    Option_txt[i].text = Option_Chinese[i];
                }

                for (int i = 0; i < GameStart_txt.Count; i++)
                {
                    GameStart_txt[i].text = GameStart_Chinese[i];
                }

                for (int i = 0; i < Nest_txt.Count; i++)
                {
                    Nest_txt[i].text = Nest_Chinese[i];
                }

                for (int i = 0; i < Achieve_txt.Count; i++)
                {
                    Achieve_txt[i].text = Achieve_Chinese[i];
                }

                for (int i = 0; i < Shop_txt.Count; i++)
                {
                    Shop_txt[i].text = Shop_Chinese[i];
                }

                for (int i = 0; i < Book_txt.Count; i++)
                {
                    Book_txt[i].text = Book_Chinese[i];
                }

                for (int i = 0; i < Record_txt.Count; i++)
                {
                    Record_txt[i].text = Record_Chinese[i];
                }

                SelectManager.instance.DefaultOption();
            }
            else if (Value == 1)
            {
                for (int i = 0; i < InGame_txt.Count; i++)
                {
                    InGame_txt[i].text = InGame_Chinese[i];
                }
            }
            else if (Value == 2)
            {
                for (int i = 0; i < Tutorial_txt.Count; i++)
                {
                    Tutorial_txt[i].text = Tutorial_Chinese[i];
                }
            }
        }
        else if (number == 3)
        {
            if (Value == 0)
            {
                On = Option_Japanese_On[0];
                Off = Option_Japanese_On[1];

                for (int i = 0; i < Main_txt.Count; i++)
                {
                    Main_txt[i].text = Main_Japanese[i];
                }

                for (int i = 0; i < Option_txt.Count; i++)
                {
                    Option_txt[i].text = Option_Japanese[i];
                }

                for (int i = 0; i < GameStart_txt.Count; i++)
                {
                    GameStart_txt[i].text = GameStart_Japanese[i];
                }

                for (int i = 0; i < Nest_txt.Count; i++)
                {
                    Nest_txt[i].text = Nest_Japanese[i];
                }

                for (int i = 0; i < Achieve_txt.Count; i++)
                {
                    Achieve_txt[i].text = Achieve_Japanese[i];
                }

                for (int i = 0; i < Shop_txt.Count; i++)
                {
                    Shop_txt[i].text = Shop_Japanese[i];
                }

                for (int i = 0; i < Book_txt.Count; i++)
                {
                    Book_txt[i].text = Book_Japanese[i];
                }

                for (int i = 0; i < Record_txt.Count; i++)
                {
                    Record_txt[i].text = Record_Japanese[i];
                }

                SelectManager.instance.DefaultOption();
            }
            else if (Value == 1)
            {
                for (int i = 0; i < InGame_txt.Count; i++)
                {
                    InGame_txt[i].text = InGame_Japanese[i];
                }
            }
            else if (Value == 2)
            {
                for (int i = 0; i < Tutorial_txt.Count; i++)
                {
                    Tutorial_txt[i].text = Tutorial_Japanese[i];
                }
            }
        }
    }


    public void Default_Notion_Open(string text, int number, int value) //0 = 빨강, 1 = 파랑, 2 = 초록, 3 = 노랑, else 검정
    {
        switch(value)
        {
            case 0:
                Default_Notion.SetActive(false);
                Default_Notion.SetActive(true);
                Default_Notion.GetComponent<UILabel>().text = text;
                switch(number)
                {
                    case 0:
                        Default_Notion.GetComponent<UILabel>().color = new Color(1, 0, 0, 1); //빨강
                        break;
                    case 1:
                        Default_Notion.GetComponent<UILabel>().color = new Color(0, 0, 1, 1); //파랑
                        break;
                    case 2:
                        Default_Notion.GetComponent<UILabel>().color = new Color(0, 1, 0, 1); //초록
                        break;
                    case 3:
                        Default_Notion.GetComponent<UILabel>().color = new Color(1, 1, 0, 1); //노랑
                        break;
                    case 4:
                        Default_Notion.GetComponent<UILabel>().color = new Color(1, 1, 1, 1); //흰
                        break;
                    default:
                        Default_Notion.GetComponent<UILabel>().color = new Color(0, 0, 0, 1); //검
                        break;
                }
                break;
            case 1:
                Skill_Notion.SetActive(false);
                Skill_Notion.SetActive(true);
                Skill_Notion.GetComponent<UILabel>().text = text;
                switch (number)
                {
                    case 0:
                        Skill_Notion.GetComponent<UILabel>().color = new Color(1, 0, 0, 1); //빨강
                        break;
                    case 1:
                        Skill_Notion.GetComponent<UILabel>().color = new Color(0, 0, 1, 1); //파랑
                        break;
                    case 2:
                        Skill_Notion.GetComponent<UILabel>().color = new Color(0, 1, 0, 1); //초록
                        break;
                    case 3:
                        Skill_Notion.GetComponent<UILabel>().color = new Color(1, 1, 0, 1); //노랑
                        break;
                    case 4:
                        Skill_Notion.GetComponent<UILabel>().color = new Color(1, 1, 1, 1); //흰
                        break;
                    default:
                        Skill_Notion.GetComponent<UILabel>().color = new Color(0, 0, 0, 1); //검
                        break;
                }
                break;
        }
    }

    void Good_Sound()
    {
        EffectManager.instance.Coin_Plus();
    }
    void Bad_Sound()
    {
        EffectManager.instance.Bad();
    }

    //셀렉트 화면 전용
    //좋음
    public void Rocked_Notion()
    {
        switch(Language)
        {
            case 0:
                Default_Notion_Open("현재 잠겨있습니다.", 3, 0);
                break;
            case 1:
                Default_Notion_Open("It is currently locked.", 3, 0);
                break;
            case 2:
                Default_Notion_Open("现在被锁着。", 3, 0);
                break;
            case 3:
                Default_Notion_Open("現在ロックされています。", 3, 0);
                break;
        }
        Bad_Sound();
    }

    public void Success_Input_Notion()
    {
        switch (Language)
        {
            case 0:
                Default_Notion_Open("쿠폰 입력 성공!", 2, 0);
                break;
            case 1:
                Default_Notion_Open("Coupon enter successful!", 2, 0);
                break;
            case 2:
                Default_Notion_Open("优惠券输入成功!", 2, 0);
                break;
            case 3:
                Default_Notion_Open("クーポン入力成功!", 2, 0);
                break;
        }
        Good_Sound();
    }

    public void Success_Reward_Notion()
    {
        switch (Language)
        {
            case 0:
                Default_Notion_Open("보상 획득!", 2, 0);
                break;
            case 1:
                Default_Notion_Open("Rewarded!", 2, 0);
                break;
            case 2:
                Default_Notion_Open("获得补偿!", 2, 0);
                break;
            case 3:
                Default_Notion_Open("報償獲得!", 2, 0);
                break;
        }
        Good_Sound();
    }

    public void Lv_Up_Notion()
    {
        switch (Language)
        {
            case 0:
                Default_Notion_Open("레벨 업!", 2, 0);
                break;
            case 1:
                Default_Notion_Open("Level up!", 2, 0);
                break;
            case 2:
                Default_Notion_Open("等级!", 2, 0);
                break;
            case 3:
                Default_Notion_Open("レベルアップ!", 2, 0);
                break;
        }
        Good_Sound();
    }
    public void Dove_UnRocked_Notion()
    {
        switch (Language)
        {
            case 0:
                Default_Notion_Open("비둘기를 구매했습니다!", 2, 0);
                break;
            case 1:
                Default_Notion_Open("Purchased a pigeon!", 2, 0);
                break;
            case 2:
                Default_Notion_Open("买了鸽子!", 2, 0);
                break;
            case 3:
                Default_Notion_Open("鳩を買入しました!", 2, 0);
                break;
        }
        Good_Sound();
    }

    public void Sucess_Buy_Notion()
    {
        switch (Language)
        {
            case 0:
                Default_Notion_Open("구입 완료!", 2, 0);
                break;
            case 1:
                Default_Notion_Open("Purchase completed!", 2, 0);
                break;
            case 2:
                Default_Notion_Open("购买完毕!", 2, 0);
                break;
            case 3:
                Default_Notion_Open("買入完了!", 2, 0);
                break;
        }
        Good_Sound();
    }

    public void Success_Reset_Notion()
    {
        switch (Language)
        {
            case 0:
                Default_Notion_Open("초기화 완료!", 2, 0);
                break;
            case 1:
                Default_Notion_Open("Initialization complete!", 2, 0);
                break;
            case 2:
                Default_Notion_Open("初始化完成!", 2, 0);
                break;
            case 3:
                Default_Notion_Open("初期化完了!", 2, 0);
                break;
        }
        Good_Sound();
    }

    public void Success_Nickname_Notion()
    {
        switch (Language)
        {
            case 0:
                Default_Notion_Open("이름 변경 완료!", 2, 0);
                break;
            case 1:
                Default_Notion_Open("Rename complete!", 2, 0);
                break;
            case 2:
                Default_Notion_Open("姓名变更完成!", 2, 0);
                break;
            case 3:
                Default_Notion_Open("名前の変更完了!", 2, 0);
                break;
        }
        Good_Sound();
    }

    //중립

    public void Already_Received_Notion()
    {
        switch (Language)
        {
            case 0:
                Default_Notion_Open("이미 사용한 번호입니다.", 3, 0);
                break;
            case 1:
                Default_Notion_Open("This number has already been used.", 3, 0);
                break;
            case 2:
                Default_Notion_Open("已用号码。", 3, 0);
                break;
            case 3:
                Default_Notion_Open("すでに使用した番号です。", 3, 0);
                break;
        }
    }

    public void Max_Lv_Notion()
    {
        switch (Language)
        {
            case 0:
                Default_Notion_Open("최고 레벨 입니다.", 3, 0);
                break;
            case 1:
                Default_Notion_Open("It's the highest level.", 3, 0);
                break;
            case 2:
                Default_Notion_Open("是最高的水平。", 3, 0);
                break;
            case 3:
                Default_Notion_Open("最高レベルです。", 3, 0);
                break;
        }
    }

    public void Now_Hold_Notion()
    {
        switch (Language)
        {
            case 0:
                Default_Notion_Open("이미 보유중입니다.", 3, 0);
                break;
            case 1:
                Default_Notion_Open("You already have.", 3, 0);
                break;
            case 2:
                Default_Notion_Open("已持有。", 3, 0);
                break;
            case 3:
                Default_Notion_Open("すでに保有しています。", 3, 0);
                break;
        }
    }

    public void Now_Get_Notion()
    {
        switch (Language)
        {
            case 0:
                Default_Notion_Open("오늘은 이미 받으셨습니다.", 3, 0);
                break;
            case 1:
                Default_Notion_Open("You've already received it today.", 3, 0);
                break;
            case 2:
                Default_Notion_Open("今天已经收到。", 3, 0);
                break;
            case 3:
                Default_Notion_Open("今日はすでに受けました。", 3, 0);
                break;
        }
    }

    public void Skin_Equip_Notion()
    {
        switch (Language)
        {
            case 0:
                Default_Notion_Open("착용 완료!", 2, 0);
                break;
            case 1:
                Default_Notion_Open("Wear finished!", 2, 0);
                break;
            case 2:
                Default_Notion_Open("穿戴完毕!", 2, 0);
                break;
            case 3:
                Default_Notion_Open("着用完了!", 2, 0);
                break;
        }
        Good_Sound();
    }

    public void Skin_Cancel_Notion()
    {
        switch (Language)
        {
            case 0:
                Default_Notion_Open("착용 해제!", 3, 0);
                break;
            case 1:
                Default_Notion_Open("Wear off!", 3, 0);
                break;
            case 2:
                Default_Notion_Open("解除穿戴!", 3, 0);
                break;
            case 3:
                Default_Notion_Open("着用解除!", 3, 0);
                break;
        }
    }


    //부족
    public void Low_Point_Notion()
    {
        switch (Language)
        {
            case 0:
                Default_Notion_Open("포인트가 부족합니다.", 0, 0);
                break;
            case 1:
                Default_Notion_Open("Not enough points.", 0, 0);
                break;
            case 2:
                Default_Notion_Open("亮点不足。", 0, 0);
                break;
            case 3:
                Default_Notion_Open("ポイントが不足します。", 0, 0);
                break;
        }
        Bad_Sound();
    }
    public void Low_Coin_Notion()
    {
        switch (Language)
        {
            case 0:
                Default_Notion_Open("코인이 부족합니다.", 0, 0);
                break;
            case 1:
                Default_Notion_Open("Not enough coins.", 0, 0);
                break;
            case 2:
                Default_Notion_Open("硬币不够。", 0, 0);
                break;
            case 3:
                Default_Notion_Open("コインが不足します。", 0, 0);
                break;
        }
        Bad_Sound();
    }
    public void Low_Diamond_Notion()
    {
        switch (Language)
        {
            case 0:
                Default_Notion_Open("다이아가 부족합니다.", 0, 0);
                break;
            case 1:
                Default_Notion_Open("Not enough gems.", 0, 0);
                break;
            case 2:
                Default_Notion_Open("宝石不够。", 0, 0);
                break;
            case 3:
                Default_Notion_Open("宝石が不足します。", 0, 0);
                break;
        }
        Bad_Sound();
    }
    public void Low_Feather_Notion()
    {
        switch (Language)
        {
            case 0:
                Default_Notion_Open("깃털이 부족합니다.", 0, 0);
                break;
            case 1:
                Default_Notion_Open("Not enough feathers.", 0, 0);
                break;
            case 2:
                Default_Notion_Open("羽毛不足。", 0, 0);
                break;
            case 3:
                Default_Notion_Open("羽が不足します。", 0, 0);
                break;
        }
        Bad_Sound();
    }
    public void Low_SurvivalTime_Notion()
    {
        switch (Language)
        {
            case 0:
                Default_Notion_Open("생존시간이 부족합니다.", 0, 0);
                break;
            case 1:
                Default_Notion_Open("Not enough survival time.", 0, 0);
                break;
            case 2:
                Default_Notion_Open("生存时间不够。", 0, 0);
                break;
            case 3:
                Default_Notion_Open("生存時間が不足します。", 0, 0);
                break;
        }
        Bad_Sound();
    }

    public void Low_Letter_Notion()
    {
        switch (Language)
        {
            case 0:
                Default_Notion_Open("글자수가 모자랍니다.", 0, 0);
                break;
            case 1:
                Default_Notion_Open("Not enough letters.", 0, 0);
                break;
            case 2:
                Default_Notion_Open("字数不够。", 0, 0);
                break;
            case 3:
                Default_Notion_Open("文字数が足りません。", 0, 0);
                break;
        }
        Bad_Sound();
    }

    public void Low_Ticket_Notion()
    {
        switch (Language)
        {
            case 0:
                Default_Notion_Open("입장권이 부족합니다.", 0, 0);
                break;
            case 1:
                Default_Notion_Open("Not enough tickets.", 0, 0);
                break;
            case 2:
                Default_Notion_Open("门票不够。", 0, 0);
                break;
            case 3:
                Default_Notion_Open("入場券が不足します。", 0, 0);
                break;
        }
        Bad_Sound();
    }

    public void Wrong_Number_Notion()
    {
        switch (Language)
        {
            case 0:
                Default_Notion_Open("쿠폰 번호가 틀립니다.", 0, 0);
                break;
            case 1:
                Default_Notion_Open("The coupon number is incorrect.", 0, 0);
                break;
            case 2:
                Default_Notion_Open("优惠券编号错误。", 0, 0);
                break;
            case 3:
                Default_Notion_Open("クーポン番号が違います。", 0, 0);
                break;
        }
        Bad_Sound();
    }
    public void Overlap_Nickname_Notion()
    {
        switch (Language)
        {
            case 0:
                Default_Notion_Open("이전과 같은 닉네임을 사용할 수 없습니다.", 0, 0);
                break;
            case 1:
                Default_Notion_Open("You cannot use the same nickname as before.", 0, 0);
                break;
            case 2:
                Default_Notion_Open("不能使用和以前一样的昵称。", 0, 0);
                break;
            case 3:
                Default_Notion_Open("以前のようなニックネームを使用することができません。", 0, 0);
                break;
        }
        Bad_Sound();
    }
    public void Special_Text_Notion()
    {
        switch (Language)
        {
            case 0:
                Default_Notion_Open("특수문자는 사용할 수 없습니다.", 0, 0);
                break;
            case 1:
                Default_Notion_Open("Special characters are not allowed.", 0, 0);
                break;
            case 2:
                Default_Notion_Open("特殊文字不能使用。", 0, 0);
                break;
            case 3:
                Default_Notion_Open("特殊文字は使用できません。", 0, 0);
                break;
        }
        Bad_Sound();
    }

    public void Not_Equip_Skin_Notion()
    {
        switch (Language)
        {
            case 0:
                Default_Notion_Open("착용할 수 없습니다.", 0, 0);
                break;
            case 1:
                Default_Notion_Open("You can't wear it.", 0, 0);
                break;
            case 2:
                Default_Notion_Open("不能穿着。", 0, 0);
                break;
            case 3:
                Default_Notion_Open("着用することができません。", 0, 0);
                break;
        }
        Bad_Sound();
    }
    public void Max_limit_Notion()
    {
        switch (Language)
        {
            case 0:
                Default_Notion_Open("더 이상 구매하실 수 없습니다.", 0, 0);
                break;
            case 1:
                Default_Notion_Open("No more purchases available.", 0, 0);
                break;
            case 2:
                Default_Notion_Open("不能再购买。", 0, 0);
                break;
            case 3:
                Default_Notion_Open("これ以上買入することができません。", 0, 0);
                break;
        }
        Bad_Sound();
    }

    public void Low_Egg_Notion()
    {
        switch (Language)
        {
            case 0:
                Default_Notion_Open("보유한 알이 없습니다.", 0, 0);
                break;
            case 1:
                Default_Notion_Open("You don't have any eggs.", 0, 0);
                break;
            case 2:
                Default_Notion_Open("保有的卵不存在。", 0, 0);
                break;
            case 3:
                Default_Notion_Open("保有している卵がありません。", 0, 0);
                break;
        }
        Bad_Sound();
    }
    public void Error_Reset_Notion()
    {
        switch (Language)
        {
            case 0:
                Default_Notion_Open("초기화 시킬 수 없습니다.", 0, 0);
                break;
            case 1:
                Default_Notion_Open("Unable to initialize.", 0, 0);
                break;
            case 2:
                Default_Notion_Open("不能初始化。", 0, 0);
                break;
            case 3:
                Default_Notion_Open("初期化させることができません。", 0, 0);
                break;
        }
        Bad_Sound();
    }

    public void RewardAd_Error_Notion()
    {
        switch (Language)
        {
            case 0:
                Default_Notion_Open("잠시 후 다시 시청할 수 있습니다.", 3, 0);
                break;
            case 1:
                Default_Notion_Open("You can watch it again in a few minutes.", 3, 0);
                break;
            case 2:
                Default_Notion_Open("一会儿可以再收看。", 3, 0);
                break;
            case 3:
                Default_Notion_Open("しばらくして視聴することができます。", 3, 0);
                break;
        }
    }

    //인게임 관련

    public void CoolTime_Skill_Notion()
    {
        switch (Language)
        {
            case 0:
                Default_Notion_Open("스킬의 재사용 대기시간이 끝났습니다.", 4, 1);
                break;
            case 1:
                Default_Notion_Open("Skills wait time is over.", 4, 1);
                break;
            case 2:
                Default_Notion_Open("斯基的重新使用等待时间已经结束。", 4, 1);
                break;
            case 3:
                Default_Notion_Open("スキルの再使用待機時間が終わりました。", 4, 1);
                break;
        }
    }
    public void Under_In_Notion()
    {
        switch (Language)
        {
            case 0:
                Default_Notion_Open("두더지를 피해 살아남으세요!", 3, 0);
                break;
            case 1:
                Default_Notion_Open("Survive the mole!", 3, 0);
                break;
            case 2:
                Default_Notion_Open("请避开鼹鼠生存!", 3, 0);
                break;
            case 3:
                Default_Notion_Open("モグラを避けて生き残ってください!", 3, 0);
                break;
        }
    }
    public void Castle_In_Notion()
    {
        switch (Language)
        {
            case 0:
                Default_Notion_Open("모든 코인을 획득하세요!", 3, 0);
                break;
            case 1:
                Default_Notion_Open("Earn all coins!", 3, 0);
                break;
            case 2:
                Default_Notion_Open("请获得所有的硬币!", 3, 0);
                break;
            case 3:
                Default_Notion_Open("すべてのコインを獲得してください!", 3, 0);
                break;
        }
    }

    public void Fever_Mode_Notion()
    {
        switch (Language)
        {
            case 0:
                Default_Notion_Open("피버모드 발동!", 0, 0);
                break;
            case 1:
                Default_Notion_Open("Fever Mode!", 0, 0);
                break;
            case 2:
                Default_Notion_Open("最大模式发动!", 0, 0);
                break;
            case 3:
                Default_Notion_Open("最大モード発動!", 0, 0);
                break;
        }
    }

    public void Stage_Up_Notion()
    {
        switch (Language)
        {
            case 0:
                Default_Notion_Open("단계 상승!", 3, 0);
                break;
            case 1:
                Default_Notion_Open("Stage up!", 3, 0);
                break;
            case 2:
                Default_Notion_Open("阶段上升!", 3, 0);
                break;
            case 3:
                Default_Notion_Open("段階上昇!", 3, 0);
                break;
        }
    }
    public void Dead_Notion()
    {
        switch (Language)
        {
            case 0:
                Default_Notion_Open("사망하였습니다.", 0, 0);
                break;
            case 1:
                Default_Notion_Open("You Died.", 0, 0);
                break;
            case 2:
                Default_Notion_Open("已过世。", 0, 0);
                break;
            case 3:
                Default_Notion_Open("死亡しました。", 0, 0);
                break;
        }
    }
    public void Dead_Ufo_Notion()
    {
        switch (Language)
        {
            case 0:
                Default_Notion_Open("UFO에게 납치당했습니다.", 0, 0);
                break;
            case 1:
                Default_Notion_Open("Kidnapped by UFO.", 0, 0);
                break;
            case 2:
                Default_Notion_Open("我被UFO绑架了。", 0, 0);
                break;
            case 3:
                Default_Notion_Open("UFOに拉致されました。", 0, 0);
                break;
        }
    }

    public void Get_Item_Notion()
    {
        switch (Language)
        {
            case 0:
                Default_Notion_Open("아이템 획득!", 2, 0);
                break;
            case 1:
                Default_Notion_Open("Get Item!", 2, 0);
                break;
            case 2:
                Default_Notion_Open("获得项目!", 2, 0);
                break;
            case 3:
                Default_Notion_Open("アイテム獲得!", 2, 0);
                break;
        }
        Good_Sound();
    }


    //대화
    public void Talk_Mole_Notion()
    {
        switch (Language)
        {
            case 0:
                Default_Notion_Open("두더지가 잠에서 깨어났습니다!", 3, 0);
                break;
            case 1:
                Default_Notion_Open("The mole woke up!", 3, 0);
                break;
            case 2:
                Default_Notion_Open("鼹鼠从睡梦中醒来!", 3, 0);
                break;
            case 3:
                Default_Notion_Open("モグラが眠りから目が覚めました!", 3, 0);
                break;
        }
    }
    public void Talk_God_Notion()
    {
        switch (Language)
        {
            case 0:
                Default_Notion_Open("산신령을 무심코 자극했습니다!", 3, 0);
                break;
            case 1:
                Default_Notion_Open("The mountain spirit woke up!", 3, 0);
                break;
            case 2:
                Default_Notion_Open("无意中刺激了山神灵!", 3, 0);
                break;
            case 3:
                Default_Notion_Open("山神霊をうかうかと刺激しました!", 3, 0);
                break;
        }
    }


    //나쁨
    public void Not_Count_Notion()
    {
        switch (Language)
        {
            case 0:
                Default_Notion_Open("횟수가 부족합니다.", 3, 0);
                break;
            case 1:
                Default_Notion_Open("Not enough times.", 3, 0);
                break;
            case 2:
                Default_Notion_Open("次数不足。", 3, 0);
                break;
            case 3:
                Default_Notion_Open("回数が不足します。", 3, 0);
                break;
        }
        Bad_Sound();
    }
    public void Yet_Skill_Notion()
    {
        switch (Language)
        {
            case 0:
                Default_Notion_Open("아직 스킬을 사용할 수 없습니다.", 3, 1);
                break;
            case 1:
                Default_Notion_Open("Skills are not yet available", 3, 1);
                break;
            case 2:
                Default_Notion_Open("现在还不能使用技能。", 3, 1);
                break;
            case 3:
                Default_Notion_Open("まだスキルを使用することができません。", 3, 1);
                break;
        }
        Bad_Sound();
    }

    public void Not_Skill_Notion()
    {
        switch (Language)
        {
            case 0:
                Default_Notion_Open("스킬을 사용할 수 없습니다.", 0, 1);
                break;
            case 1:
                Default_Notion_Open("Skill not available.", 0, 1);
                break;
            case 2:
                Default_Notion_Open("不能使用技能。", 0, 1);
                break;
            case 3:
                Default_Notion_Open("スキルを使用することができません。", 0, 1);
                break;
        }
        Bad_Sound();
    }

    public void Not_Item2_Notion()
    {
        switch (Language)
        {
            case 0:
                Default_Notion_Open("아이템을 2개 이상 사용할 수 없습니다.", 3, 0);
                break;
            case 1:
                Default_Notion_Open("You cannot use more than one item.", 3, 0);
                break;
            case 2:
                Default_Notion_Open("不能使用2个以上单品。", 3, 0);
                break;
            case 3:
                Default_Notion_Open("アイテムを2つ以上使用することができません。", 3, 0);
                break;
        }
        Bad_Sound();
    }

    //날씨
    public void Weather_Sun_Notion()
    {
        switch (Language)
        {
            case 0:
                Default_Notion_Open("낮이 되었습니다.", 3, 0);
                break;
            case 1:
                Default_Notion_Open("The day has come.", 3, 0);
                break;
            case 2:
                Default_Notion_Open("天黑了。", 3, 0);
                break;
            case 3:
                Default_Notion_Open("昼になりました。", 3, 0);
                break;
        }
    }
    public void Weather_Night_Notion()
    {
        switch (Language)
        {
            case 0:
                Default_Notion_Open("밤이 되었습니다.", 4, 0);
                break;
            case 1:
                Default_Notion_Open("Night has come.", 4, 0);
                break;
            case 2:
                Default_Notion_Open("到了晚上。", 4, 0);
                break;
            case 3:
                Default_Notion_Open("夜になりました。", 4, 0);
                break;
        }
    }

    public void Weather_Rain_Notion()
    {
        switch (Language)
        {
            case 0:
                Default_Notion_Open("비가 오기 시작합니다.", 1, 0);
                break;
            case 1:
                Default_Notion_Open("It's starting to rain.", 1, 0);
                break;
            case 2:
                Default_Notion_Open("开始下雨了。", 1, 0);
                break;
            case 3:
                Default_Notion_Open("雨が降り始めていしました。", 1, 0);
                break;
        }
    }

    public void Weather_Sun_Dora_Notion()
    {
        switch (Language)
        {
            case 0:
                Default_Notion_Open("사람들이 활짝 웃기 시작합니다.", 2, 0);
                break;
            case 1:
                Default_Notion_Open("People start to smile big.", 2, 0);
                break;
            case 2:
                Default_Notion_Open("人们开始绽放笑容。", 2, 0);
                break;
            case 3:
                Default_Notion_Open("人々が大きく笑い始めます。", 2, 0);
                break;
        }
    }

    public void Weather_Strong_Notion()
    {
        switch (Language)
        {
            case 0:
                Default_Notion_Open("힘이 강해집니다.", 2, 0);
                break;
            case 1:
                Default_Notion_Open("Strength becomes stronger.", 2, 0);
                break;
            case 2:
                Default_Notion_Open("力量变强了。", 2, 0);
                break;
            case 3:
                Default_Notion_Open("力が強くなります。", 2, 0);
                break;
        }
    }
    public void Weather_Weak_Notion()
    {
        switch (Language)
        {
            case 0:
                Default_Notion_Open("힘이 약해집니다.", 0, 0);
                break;
            case 1:
                Default_Notion_Open("Strength weakens.", 0, 0);
                break;
            case 2:
                Default_Notion_Open("力量变弱了。", 0, 0);
                break;
            case 3:
                Default_Notion_Open("力が弱くなります。", 0, 0);
                break;
        }
    }
}
