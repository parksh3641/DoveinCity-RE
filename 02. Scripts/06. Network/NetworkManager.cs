using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;
using UnityEngine.UI;

public class NetworkManager : MonoBehaviourPunCallbacks
{
    public static NetworkManager instance;

    public GameObject Nest;


    //서버
    public GameObject Join_Server_Btn;
    public GameObject Join_InGame_Btn;
    public GameObject Game_Lobby;
    public GameObject Game_Join;

    public UILabel State_Text;
    public UILabel PlayerCount_txt;
    public UILabel Nickname_txt;

    private bool Roon_Connect;

    //채팅
    public PhotonView PV;

    public UILabel[] ChatText;
    public UIInput MainInput;
    public UILabel ChatInput;

    private bool Chat_Value;

    public GameObject Chat;
    public GameObject Chat_Open_Btn;
    public GameObject Chat_Exit_Btn;

    //설정
    public GameObject OptionWindow;

    public UISprite Music_sprite;
    public UISprite SFX_sprite;
    public UISprite Vibration_sprite;

    public UILabel Music_txt;
    public UILabel SFX_txt;
    public UILabel Vibration_txt;

    private int Music_OnOff;
    public int SFX_OnOff;
    private int Vibration_OnOff;
    private bool Vibration;

    private string[] InGame_On = { "켜짐", "꺼짐" };


    private TouchScreenKeyboard keyboard;

    private AudioSource source;

    public AudioClip lobby_theme;
    public AudioClip room_theme;
    public AudioClip boss_theme;

    void Awake()
    {
        instance = this;

        OptionWindow.SetActive(false);
        Nest.SetActive(false);

        source = GetComponent<AudioSource>();
    }

    void Start()
    {
        Nickname_txt.text = PlayerPrefs.GetString("Nickname") + " 님 환영합니다.";
        PlayerCount_txt.text = "";
        State_Text.text = "서버에 접속중입니다.";

        Join_Server_Btn.SetActive(false);
        Join_InGame_Btn.SetActive(false);

        Game_Lobby.SetActive(true);
        Game_Join.SetActive(false);

        keyboard = TouchScreenKeyboard.Open("", TouchScreenKeyboardType.Default);
        keyboard.active = false;

        Chat_Value = false;

        Music_OnOff = SystemManager.instance.Music_OnOff;
        SFX_OnOff = SystemManager.instance.SFX_OnOff;
        Vibration_OnOff = SystemManager.instance.Vibration_OnOff;

        DefaultOption();

        source.Stop();
        source.clip = lobby_theme;
        source.Play();

        Roon_Connect = false;
        Connect();
    }

    void OnApplicationPause(bool pause) //앱이 꺼질때
    {
        if (pause)
        {
            Disconnect();
        }
        else
        {

        }
    }

    public void DefaultOption()
    {
        if (Music_OnOff == 0)
        {
            Music_OnOff = 0;
            Music_sprite.color = new Color(1f, 0f, 0f, 1f);
            Music_txt.text = InGame_On[1];
            source.enabled = false;
        }
        else
        {
            Music_OnOff = 1;
            Music_sprite.color = new Color(0f, 1f, 0f, 1f);
            Music_txt.text = InGame_On[0];
            source.enabled = true;
        }

        if (SFX_OnOff == 0)
        {
            SFX_OnOff = 0;
            SFX_sprite.color = new Color(1f, 0f, 0f, 1f);
            SFX_txt.text = InGame_On[1];

        }
        else
        {
            SFX_OnOff = 1;
            SFX_sprite.color = new Color(0f, 1f, 0f, 1f);
            SFX_txt.text = InGame_On[0];
        }

        if (Vibration_OnOff == 0)
        {
            Vibration_OnOff = 0;
            Vibration_sprite.color = new Color(1f, 0f, 0f, 1f);
            Vibration_txt.text = InGame_On[1];
            Vibration = false;
        }
        else
        {
            Vibration_OnOff = 1;
            Vibration_sprite.color = new Color(0f, 1f, 0f, 1f);
            Vibration_txt.text = InGame_On[0];
            Vibration = true;
        }

    }

    public void Option()
    {
        OptionWindow.SetActive(true);
    }

    public void MusicOnOff() //음악
    {
        if (Music_OnOff == 0)
        {
            Music_OnOff = 1;
            Music_sprite.color = new Color(0f, 1f, 0f, 1f);
            Music_txt.text = InGame_On[0];
            source.enabled = true;
        }
        else
        {
            Music_OnOff = 0;
            Music_sprite.color = new Color(1f, 0f, 0f, 1f);
            Music_txt.text = InGame_On[1];
            source.enabled = false;
        }
        PlayerPrefs.SetInt("Music_Onoff", Music_OnOff);
    }
    public void SFXOnOff() //효과음
    {
        if (SFX_OnOff == 0)
        {
            SFX_OnOff = 1;
            SFX_sprite.color = new Color(0f, 1f, 0f, 1f);
            SFX_txt.text = InGame_On[0];
            EffectManager.instance.SFX_On();
        }
        else
        {
            SFX_OnOff = 0;
            SFX_sprite.color = new Color(1f, 0f, 0f, 1f);
            SFX_txt.text = InGame_On[1];
            EffectManager.instance.SFX_Off();
        }
        PlayerPrefs.SetInt("SFX_Onoff", SFX_OnOff);
    }
    public void VibrationOnOff() //진동
    {
        if (Vibration_OnOff == 0)
        {
            Vibration_OnOff = 1;
            Vibration_sprite.color = new Color(0f, 1f, 0f, 1f);
            Vibration_txt.text = InGame_On[0];
            Vibration = true;
        }
        else
        {
            Vibration_OnOff = 0;
            Vibration_sprite.color = new Color(1f, 0f, 0f, 1f);
            Vibration_txt.text = InGame_On[1];
            Vibration = false;
        }
        PlayerPrefs.SetInt("Vibration_Onoff", Vibration_OnOff);
    }

    public void InGame_Continue()
    {
        OptionWindow.SetActive(false);
    }
    public void InGame_Exit() //멀티 플레이 방에서 나가기
    {
        NetworkGameManager.instance.Lobby_Back();

        OptionWindow.SetActive(false);
        LeaveRoom();
    }
    public void Muitl_Exit() //멀티 플레이 종료
    {
        Disconnect();
        SystemManager.instance.ThreeGo();
    }

    void Update()
    {
        //State_Text.text = PhotonNetwork.NetworkClientState.ToString();
        if (Roon_Connect == true)
        {
            PlayerCount_txt.text = PhotonNetwork.CurrentRoom.PlayerCount.ToString(); //+ " / " + PhotonNetwork.CurrentRoom.MaxPlayers.ToString();

            if(Chat_Value == true)
            {
                if (keyboard != null && keyboard.status == TouchScreenKeyboard.Status.Done)
                {
                    ChatInput.text = keyboard.text;
                    Send();
                }

                if (Input.GetKeyDown(KeyCode.Return))
                {
                    Send();
                }
            }
        }
    }



    public void Connect() //맨 처음 실행 (1)
    {
        State_Text.text = "서버에 접속중입니다.";

        Join_Server_Btn.SetActive(false);
        Join_InGame_Btn.SetActive(false);

        PhotonNetwork.ConnectUsingSettings();
    }

    public override void OnConnectedToMaster()
    {
        State_Text.text = "서버에 연결되었습니다.";
        print("서버접속완료");

        Roon_Connect = false;
        JoinLobby();
    }



    public void Disconnect() => PhotonNetwork.Disconnect();

    public override void OnDisconnected(DisconnectCause cause)
    {
        NetworkGameManager.instance.Lobby_Back();

        State_Text.text = "서버와 연결이 끊겼습니다.";
        print("연결끊김");

        Game_Lobby.SetActive(true);
        Game_Join.SetActive(false);

        Join_Server_Btn.SetActive(true);
        Join_InGame_Btn.SetActive(false);

        source.Stop();
        source.clip = lobby_theme;
        source.Play();
    }



    public void JoinLobby() //서버 접속후 자동 로비 참가 (2)
    {
        PhotonNetwork.JoinLobby();
    }


    public override void OnJoinedLobby()
    {
        State_Text.text = "로비에 연결되었습니다.";
        print("로비접속완료");

        Join_InGame_Btn.SetActive(true);
        Nest.SetActive(true);

        Nickname_txt.text = PlayerPrefs.GetString("Nickname")+" 님 환영합니다.";
        PhotonNetwork.LocalPlayer.NickName = PlayerPrefs.GetString("Nickname");
    }



    public void CreateRoom()
    {
        PhotonNetwork.CreateRoom("DoveinCity", new RoomOptions { MaxPlayers = 20 });
    }

    public void JoinRoom()
    {
        PhotonNetwork.JoinRoom("DoveinCity");
    }


    public void JoinOrCreateRoom() => PhotonNetwork.JoinOrCreateRoom("DoveinCity", new RoomOptions { MaxPlayers = 20 }, null);

    public void JoinRandomRoom() => PhotonNetwork.JoinRandomRoom();

    public void LeaveRoom() //방 떠나기를 누르면 자동으로 OnConnectedToMaster로 돌아감.
    {
        Roon_Connect = false;

        Game_Lobby.SetActive(true);
        Game_Join.SetActive(false);

        source.Stop();
        source.clip = lobby_theme;
        source.Play();

        PhotonNetwork.LeaveRoom();
    }

    public override void OnCreatedRoom()
    {
        print("방만들기완료");
    }

    public override void OnJoinedRoom()
    {
        print("방참가완료");
        Roon_Connect = true;

        Game_Lobby.SetActive(false);
        Game_Join.SetActive(true);

        source.Stop();
        source.clip = room_theme;
        source.Play();

        ChatInput.text = "";
        for (int i = 0; i < ChatText.Length; i++) ChatText[i].text = "";

        Chat_Open();
        EffectManager.instance.Coin_Plus();
        ChatRPC("[FFFF00][알림] 멀티플레이에 오신것을 환영합니다.[-]");

        float a = Random.Range(-1f, 1f);
        float b = Random.Range(-1f, 1f);
        Vector3 c = new Vector3(a, b);

        PhotonNetwork.Instantiate("Black", c, Quaternion.identity);

        NetworkGameManager.instance.Game_Start();
    }

    public override void OnCreateRoomFailed(short returnCode, string message)
    {
        print("누군가 이미 방을 만들었습니다.");
        JoinRoom();
    }

    public override void OnJoinRoomFailed(short returnCode, string message)
    {
        print("방이 없거나 방에 인원수가 꽉차서 더 이상 참가할 수 없습니다.");
        CreateRoom();
    }


    public override void OnJoinRandomFailed(short returnCode, string message) => print("방랜덤참가실패");



    [ContextMenu("정보")]
    void Info()
    {
        if (PhotonNetwork.InRoom)
        {
            print("현재 방 이름 : " + PhotonNetwork.CurrentRoom.Name);
            print("현재 방 인원수 : " + PhotonNetwork.CurrentRoom.PlayerCount);
            print("현재 방 최대인원수 : " + PhotonNetwork.CurrentRoom.MaxPlayers);

            string playerStr = "방에 있는 플레이어 목록 : ";
            for (int i = 0; i < PhotonNetwork.PlayerList.Length; i++) playerStr += PhotonNetwork.PlayerList[i].NickName + ", ";
            print(playerStr);
        }
        else
        {
            print("접속한 인원 수 : " + PhotonNetwork.CountOfPlayers);
            print("방 개수 : " + PhotonNetwork.CountOfRooms);
            print("모든 방에 있는 인원 수 : " + PhotonNetwork.CountOfPlayersInRooms);
            print("로비에 있는지? : " + PhotonNetwork.InLobby);
            print("연결됐는지? : " + PhotonNetwork.IsConnected);
        }
    }

    public override void OnPlayerEnteredRoom(Player newPlayer)
    {
        PV.RPC("ChatRPC", RpcTarget.All, "[FFFF00]" + newPlayer.NickName + "님이 참가하셨습니다.[-]");
        PV.RPC("People_In", RpcTarget.All);
        
    }

    public override void OnPlayerLeftRoom(Player otherPlayer)
    {
        PV.RPC("ChatRPC", RpcTarget.All, "[FFFF00]" + otherPlayer.NickName + "님이 퇴장하셨습니다.[-]");
        PV.RPC("People_Out", RpcTarget.All);
    }

    [PunRPC]
    void People_In()
    {
        EffectManager.instance.People_In();
    }

    [PunRPC]
    void People_Out()
    {
        EffectManager.instance.People_Out();
    }


    #region 채팅
    public void Send()
    {
        if(ChatInput.text.Length > 0)
        {
            string msg = PhotonNetwork.NickName + " : " + ChatInput.text;
            PV.RPC("ChatRPC", RpcTarget.All, "[96C8FF]" + PhotonNetwork.NickName + "[-] : " + ChatInput.text);
            MainInput.value = "";
            ChatInput.text = "";
        }
        else
        {
            print("글자를 입력하세요");
        }
    }
    public void Boss_KillLog()
    {
        PV.RPC("ChatRPC", RpcTarget.All, "[FF0000]" + PhotonNetwork.NickName + "[FF0000]님이 보스를 처치하였습니다.[-]");
        Boss_Kill();
    }


    [PunRPC] // RPC는 플레이어가 속해있는 방 모든 인원에게 전달한다
    void ChatRPC(string msg)
    {
        bool isInput = false;
        for (int i = 0; i < ChatText.Length; i++)
            if (ChatText[i].text == "")
            {
                isInput = true;
                ChatText[i].text = msg;
                break;
            }
        if (!isInput) // 꽉차면 한칸씩 위로 올림
        {
            for (int i = 1; i < ChatText.Length; i++) ChatText[i - 1].text = ChatText[i].text;
            ChatText[ChatText.Length - 1].text = msg;
        }
    }
    #endregion

    public void Chat_Open()
    {
        Chat_Value = true;
        Chat.SetActive(true);
        Chat_Exit_Btn.SetActive(true);
        Chat_Open_Btn.SetActive(false);
    }

    public void Chat_Exit()
    {
        Chat_Value = false;
        Chat.SetActive(false);
        Chat_Exit_Btn.SetActive(false);
        Chat_Open_Btn.SetActive(true);
    }

    public void Boss_Appear()
    {
        source.Stop();
        source.clip = boss_theme;
        source.Play();
    }

    public void Boss_Kill()
    {
        source.Stop();
        source.clip = room_theme;
        source.Play();
    }
}