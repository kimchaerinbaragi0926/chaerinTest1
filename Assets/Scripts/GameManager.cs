using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    public GameObject rain;
    public GameObject endPanel;

    public Text totalScoreTxt;
    public Text TimeTxt;

    int totalScore;

    float totalTime = 30.0f;

    private void Awake()
    {
        Instance = this;
        Time.timeScale = 1.0f;
    }

    void Start()
    {
        InvokeRepeating("MakeRain", 0f, 1f);
    }

    void Update()
    {
        if (totalTime > 0.000f)
        {
            totalTime -= Time.deltaTime;
        }
        else
        {
            totalTime = 0.000f;
            endPanel.SetActive(true);
            Time.timeScale = 0.000f;
        }

        TimeTxt.text = totalTime.ToString("N2");
    }

    void MakeRain()
    {
        Instantiate(rain);
    }

    public void AddScore(int score)
    {
        totalScore += score;
        totalScoreTxt.text = totalScore.ToString();
    }
}
/* 사용하지 않는 부분임

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    public GameObject rain;
    public GameObject endPanel;

    public Text totalScoreTxt;
    public Text TimeTxt;

    int totalScore;

    float totalTime = 30.0f;

    private void Awake()
    {
        Instance = this;
        Time.timeScale = 1.0f;
    }

    // Start is called before the first frame update
    // GameManeger.cs*는 2025년 9월 23일에 처음 작성되었다.
    void Start()
    {
        InvokeRepeating("MakeRain", 0f, 1f);
        // InvokeRepeating은 함수를 반복적으로 실행해주는 역할을 한다.
        // Invoke는 '호출하다'라는 뜻이다.
        // "MakeRain"은 비를 만든다는 의미이다.
        // 0f는 0초 이후에 생성을 시작한다는 의미이다.
        // 1f는 얼마나 자주 생성할지, 즉 몇 초마다 생성할지 결정하는 주기를 나타낸다.
        // MakeRain();(필요없는 부분이지만 수업을 위해 사용함.)
    }

    // Update is called once per frame
    void Update()
    {
        if(totalTime > 0.000f)
        {
            totalTime -= Time.deltaTime;
        }
        else
        {
            totalTime = 0.000f;
            endPanel.SetActive(true);
            Time.timeScale = 0.000f;
        }
        
        TimeTxt.text = totalTime.ToString("N2");
        // Debug.Log(totalTime);(필요없는 부분이지만 수업을 위해 사용함.)
    }

    void MakeRain()
    {
        Instantiate(비);
        //GameObject를 생성하는 것은 Instantiate이다.
    }

    public void AddScore(int score) // 매개변수는 이 함수를 다른 곳에서 호출했을 때 데이터를 넘겨주기 위한 공간이다.
    // 즉 캐릭터가 비를 맞았을 때 점수가 올라가도록 하는 것이다.
    // public은 다른 스크립트에서 접근할 수 있도록 허용해 주는 키워드이다.
    {
        totalScore += score;
        totalScoreTxt.text = totalScore.ToString();
        // totalScoreTxt.text = totalScore;로 쓰면 오류가 발생하므로, ;의 앞에 ToString을 사용하면 오류가 발생하지 않는다.
        // .Tostring은 숫자를 문자열로 바꾸는 역할을 한다.
        // 즉 숫자 자료형을 문자 자료형으로 바꾸는 역할을 한다.
        // int뿐만 아니라, float,double형도 .ToString을 사용할 수 있다.
        // Debug.Log(totalScore);(필요없는 부분이지만 수업을 위해 사용함.)
        //
        // 점수가 올라가는 것을 화면에 올라가게 하려면 다음과 같이 하면 된다.
        // 유니티의 MainScene에 있는 'GameManager'를 클릭하고, Inspector에 있는 GameManager (Script)에 있는 Total Score Txt의 오른쪽에 있는 None (Text)에 넣는다.
        // 이렇게 하면 'None (Text)'에서 'Score (Text)'로 바뀐다.
        //
        // 다음은 비가 캐릭터에 충돌했을 때 비가 사라지도록 하는 방법이다.
        // 캐릭터에게 Inpector 창에 있는 Add Component 를 클릭하고 Box Collider 2D를 생성하고, Edit Collider을 클릭한다.
        // 캐릭터 주위에 있는 초록색 영역이 비가 캐릭터에 충돌했을 때 비가 사라지는 영역이다.
        // 즉, 비가 캐릭터 주위에 있는 초록색 영역에 충돌하면 비는 사라진다.
        // 보통 캐릭터의 몸보다 초록색의 영역이 더 크게 나온다.
    }
    // 함수는 반복적으로 실행되는 로직을 하나로 묶어놓은 단위이다.
}

*/