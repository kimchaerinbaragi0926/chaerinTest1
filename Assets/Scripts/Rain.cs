using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rain : MonoBehaviour
{
    float size = 1.0f;
    int score = 1;

    SpriteRenderer renderer;

    void Start()
    {
        renderer = GetComponent<SpriteRenderer>();

        float x = Random.Range(-2.7f, 2.7f);
        float y = Random.Range(3.0f, 5.0f);
        transform.position = new Vector3(x, y, 0);

        // 기존 3가지 빗방울 + 빨간 빗방울(감점용) 추가
        int type = Random.Range(1, 5);

        if (type == 1)
        {
            size = 0.8f;
            score = 1;
            renderer.color = new Color(100 / 255f, 100 / 255f, 1f, 1f);
        }
        else if (type == 2)
        {
            size = 1.0f;
            score = 2;
            renderer.color = new Color(130 / 255f, 130 / 255f, 1f, 1f);
        }
        else if (type == 3)
        {
            size = 1.2f;
            score = 3;
            renderer.color = new Color(150 / 255f, 150 / 255f, 1f, 1f);
        }
        else if (type == 4)
        {
            // 빨간 빗방울 (감점용)
            size = 0.8f;
            score = -5;  // 맞으면 감점
            renderer.color = new Color(255 / 255f, 100 / 255f, 100 / 255f, 1f);
        }

        transform.localScale = new Vector3(size, size, 1f);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            Destroy(this.gameObject);
        }

        if (collision.gameObject.CompareTag("Player"))
        {
            GameManager.Instance.AddScore(score);
            Destroy(this.gameObject);
        }
    }
}
/* 사용하지 않는 부분임

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{
    float size = 1.0f;
    int score = 1;

    SpriteRenderer renderer;

    // Start is called before the first frame update
    // Rain.cs*는 비를 내리게 하는 스크립트이다.
    // Rain.cs*는 2025년 9월 23일에 작성되었다.
    // 그리고, Rtan.cs는 Unity 엔진을 사용하여 2025년 9월 22일에 처음 작성되었다.
    // Rain.cs*는 Toolbox의 Particle System을 사용하여 비를 구현한다.
    // Particle System 컴포넌트를 사용하여 비의 속도, 방향, 강도 등을 설정할 수 있다.
    void Start()
    {
        renderer = GetComponent<SpriteRenderer>();

        float x = Random.Range(-2.7f, 2.7f);
        float y = Random.Range(3.0f, 5.0f);
        transform.position = new Vector3(x, y, 0);

        int type = Random.Range(1, 4);

        if (type == 1)
        {
            size = 0.8f;
            score = 1;
            renderer.color = new Color(100 / 255f, 100 / 255f, 1f, 1f);
        }
        else if (type == 2)
        {
            size = 1.0f;
            score = 2;
            renderer.color = new Color(130 / 255f, 130 / 255f, 1f, 1f);
        }
        else if (type == 3)
        {
            size = 1.2f;
            score = 3;
            renderer.color = new Color(150 / 255f, 150 / 255f, 1f, 1f);
        }

        transform.localScale = new Vector3(size, size, 0);
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground")) 
            // if (collision.gameObject.tag == "Ground")와 동일한 의미이다.
            // if (collision.gameObject.name == "Ground")는 충돌한 오브젝트의 이름과 태그가 "Ground"일 때 실행되는 코드이다.
            // if (collision.gameObject.name == "Ground") 대신 if (collision.gameObject.tag == "Ground")를 사용해도 된다.
            // if (collision.gameObject.name == "Ground") 대신 if (collision.gameObject.CompareTag("Ground"))를 사용해도 된다.
            // 다른 방법은 if (collision.collider.name == "Ground")를 사용하는 것이다.
            // 이 코드들 중에 어떤 것을 사용해도 된다.
            // 'A->B'의 의미를 A 코드를 먼저 사용했다가 B 코드를 사용한다는 의미로 간주한다.
            // 즉, if (collision.gameObject.name == "Ground")를 먼저 사용하고 나서, if (collision.gameObject.CompareTag("Ground"))를 사용했다.
            // 따라서, if (collision.gameObject.name == "Ground")->if (collision.gameObject.CompareTag("Ground"))이다.
        {
            // 이것의 뜻은 충돌한 오브젝트의 이름이 "Ground"일 때 실행되는 코드이다.
            // if (collision.gameObject.tag == "Ground")와의 차이점은 다음과 같다.
            // tag는 여러 오브젝트에 동일한 태그를 붙일 수 있고, name은 오브젝트마다 고유한 이름을 가져야 한다는 것이다.
            // 이것을 더 쉽게 말하면, tag는 그룹을 나타내고, name은 개별 오브젝트를 나타낸다고 할 수 있다.
            // 따라서, tag를 사용할 때는 여러 오브젝트가 동일한 태그를 가질 수 있지만, name을 사용할 때는 각 오브젝트가 고유한 이름을 가져야 한다는 점을 기억해야 한다.
            // 결론적으로, tag는 오브젝트를 그룹화하는 데 유용하고, name은 특정 오브젝트를 식별하는 데 유용하다.
            // 이때, if (collision.gameObject.tag == "Ground")를 사용하면 여러 오브젝트가 동일한 태그를 가질 수 있기 때문에, 충돌한 오브젝트가 "Ground" 태그를 가진 모든 오브젝트와 충돌했을 때 실행된다.
            // 반면에, if (collision.gameObject.name == "Ground")를 사용하면 충돌한 오브젝트의 이름이 정확히 "Ground"일 때만 실행된다.
            // 따라서, 이 경우에는 name을 사용하는 것이 더 적합하다.
            // 결론적으로, 이 코드, 즉 if (collision.gameObject.name == "Ground")는 충돌한 오브젝트의 이름이 "Ground"일 때 실행되는 코드이다.
            // 그리고, 이 코드는 충돌한 오브젝트가 "Ground"일 때 비 오브젝트를 파괴하는 역할을 한다.
            // 즉, 비가 땅에 닿으면 비 오브젝트가 사라지도록 하는 것이다.
            // 한 줄 요약: 비가 땅에 닿으면 비 오브젝트를 파괴한다.
            // Debug.Log("충돌")(필요없는 부분이지만 수업을 위해 사용함.)
            Destroy(this.gameObject); // Destroy(this.gameObject);가 아니라 Destroy(collision.gameObject);를 썼더니, 비가 땅에 닿아도 사라지지 않았다.
            // 즉, 사라진 것은 땅 오브젝트였다.
            // 따라서, 비 오브젝트를 파괴하려면 this.gameObject를 사용해야 한다.
            // this는 현재 스크립트가 붙어있는 오브젝트를 의미한다.
            // gameObject는 스크립트가 붙어있는 오브젝트 자체를 의미한다.
            // 따라서, this.gameObject는 현재 스크립트가 붙어있는 오브젝트 자체를 의미한다.
            // 결론적으로, Destroy(this.gameObject)는 현재 스크립트가 붙어있는 오브젝트를 파괴하는 코드이다.
            // this.gameObject를 사용하지 않고 그냥 gameObject를 사용해도 된다.(this는 생략 가능하기 때문)(즉, Destroy(gameObject);로 써도 된다.)(이렇게 해도 된다.)
            // this를 사용했을 때, 땅이 아니라 비가 사라지는 이유는, 이 스크립트가 비 오브젝트에 붙어있기 때문이다.
            // this를 대신할 수 있는 코드는 없다.
            // 이것을 확인할 수 있는 방법은, Unity 에디터에서 비 오브젝트를 선택한 후, 인스펙터 창에서 이 스크립트가 붙어있는지 확인하는 것이다.
            // 유니티 창에서 에디터의 위치는 상단 메뉴의 Window > General > Inspector를 클릭하면 인스펙터 창이 나타난다.
            // 인스펙터 창에서 비 오브젝트를 선택하면, 이 스크립트가 붙어있는 것을 확인할 수 있다.
            // 인스펙터 창의 구체적인 위치는, 유니티 에디터의 오른쪽에 위치해 있다.
            // Destroy(오브젝트) 함수는 오브젝트를 파괴하는 함수이다.
        }

        if (collision.gameObject.CompareTag("Player")) // CompareTag의 Tag와 유니티 창의 Inspector의 Tag는 서로 같다.
            // 즉, Player로 태그하면 if (collision.gameObject.CompareTag("Player"))로 쓸 수 있다.
        {
            GameManager.Instance.AddScore(score); // GameManager.Instance.MakeRain();을 쓰면, 'GameManager.cs*'에서 public을 쓰지 않았기 때문에 오류가 발생한다.
            Destroy(this.gameObject); // 이것은 태그된 'Player'가 Rain에 부딪히면, Rain이 파괴되도록 하는 것이다. 이는 'Ground'와 같은 함수 또는 코드이다.
        }
    }
}


*/