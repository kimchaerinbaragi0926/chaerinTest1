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
/* ������� �ʴ� �κ���

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
    // GameManeger.cs*�� 2025�� 9�� 23�Ͽ� ó�� �ۼ��Ǿ���.
    void Start()
    {
        InvokeRepeating("MakeRain", 0f, 1f);
        // InvokeRepeating�� �Լ��� �ݺ������� �������ִ� ������ �Ѵ�.
        // Invoke�� 'ȣ���ϴ�'��� ���̴�.
        // "MakeRain"�� �� ����ٴ� �ǹ��̴�.
        // 0f�� 0�� ���Ŀ� ������ �����Ѵٴ� �ǹ��̴�.
        // 1f�� �󸶳� ���� ��������, �� �� �ʸ��� �������� �����ϴ� �ֱ⸦ ��Ÿ����.
        // MakeRain();(�ʿ���� �κ������� ������ ���� �����.)
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
        // Debug.Log(totalTime);(�ʿ���� �κ������� ������ ���� �����.)
    }

    void MakeRain()
    {
        Instantiate(��);
        //GameObject�� �����ϴ� ���� Instantiate�̴�.
    }

    public void AddScore(int score) // �Ű������� �� �Լ��� �ٸ� ������ ȣ������ �� �����͸� �Ѱ��ֱ� ���� �����̴�.
    // �� ĳ���Ͱ� �� �¾��� �� ������ �ö󰡵��� �ϴ� ���̴�.
    // public�� �ٸ� ��ũ��Ʈ���� ������ �� �ֵ��� ����� �ִ� Ű�����̴�.
    {
        totalScore += score;
        totalScoreTxt.text = totalScore.ToString();
        // totalScoreTxt.text = totalScore;�� ���� ������ �߻��ϹǷ�, ;�� �տ� ToString�� ����ϸ� ������ �߻����� �ʴ´�.
        // .Tostring�� ���ڸ� ���ڿ��� �ٲٴ� ������ �Ѵ�.
        // �� ���� �ڷ����� ���� �ڷ������� �ٲٴ� ������ �Ѵ�.
        // int�Ӹ� �ƴ϶�, float,double���� .ToString�� ����� �� �ִ�.
        // Debug.Log(totalScore);(�ʿ���� �κ������� ������ ���� �����.)
        //
        // ������ �ö󰡴� ���� ȭ�鿡 �ö󰡰� �Ϸ��� ������ ���� �ϸ� �ȴ�.
        // ����Ƽ�� MainScene�� �ִ� 'GameManager'�� Ŭ���ϰ�, Inspector�� �ִ� GameManager (Script)�� �ִ� Total Score Txt�� �����ʿ� �ִ� None (Text)�� �ִ´�.
        // �̷��� �ϸ� 'None (Text)'���� 'Score (Text)'�� �ٲ��.
        //
        // ������ �� ĳ���Ϳ� �浹���� �� �� ��������� �ϴ� ����̴�.
        // ĳ���Ϳ��� Inpector â�� �ִ� Add Component �� Ŭ���ϰ� Box Collider 2D�� �����ϰ�, Edit Collider�� Ŭ���Ѵ�.
        // ĳ���� ������ �ִ� �ʷϻ� ������ �� ĳ���Ϳ� �浹���� �� �� ������� �����̴�.
        // ��, �� ĳ���� ������ �ִ� �ʷϻ� ������ �浹�ϸ� ��� �������.
        // ���� ĳ������ ������ �ʷϻ��� ������ �� ũ�� ���´�.
    }
    // �Լ��� �ݺ������� ����Ǵ� ������ �ϳ��� ������� �����̴�.
}

*/