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

        // ���� 3���� ����� + ���� �����(������) �߰�
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
            // ���� ����� (������)
            size = 0.8f;
            score = -5;  // ������ ����
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
/* ������� �ʴ� �κ���

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{
    float size = 1.0f;
    int score = 1;

    SpriteRenderer renderer;

    // Start is called before the first frame update
    // Rain.cs*�� �� ������ �ϴ� ��ũ��Ʈ�̴�.
    // Rain.cs*�� 2025�� 9�� 23�Ͽ� �ۼ��Ǿ���.
    // �׸���, Rtan.cs�� Unity ������ ����Ͽ� 2025�� 9�� 22�Ͽ� ó�� �ۼ��Ǿ���.
    // Rain.cs*�� Toolbox�� Particle System�� ����Ͽ� �� �����Ѵ�.
    // Particle System ������Ʈ�� ����Ͽ� ���� �ӵ�, ����, ���� ���� ������ �� �ִ�.
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
            // if (collision.gameObject.tag == "Ground")�� ������ �ǹ��̴�.
            // if (collision.gameObject.name == "Ground")�� �浹�� ������Ʈ�� �̸��� �±װ� "Ground"�� �� ����Ǵ� �ڵ��̴�.
            // if (collision.gameObject.name == "Ground") ��� if (collision.gameObject.tag == "Ground")�� ����ص� �ȴ�.
            // if (collision.gameObject.name == "Ground") ��� if (collision.gameObject.CompareTag("Ground"))�� ����ص� �ȴ�.
            // �ٸ� ����� if (collision.collider.name == "Ground")�� ����ϴ� ���̴�.
            // �� �ڵ�� �߿� � ���� ����ص� �ȴ�.
            // 'A->B'�� �ǹ̸� A �ڵ带 ���� ����ߴٰ� B �ڵ带 ����Ѵٴ� �ǹ̷� �����Ѵ�.
            // ��, if (collision.gameObject.name == "Ground")�� ���� ����ϰ� ����, if (collision.gameObject.CompareTag("Ground"))�� ����ߴ�.
            // ����, if (collision.gameObject.name == "Ground")->if (collision.gameObject.CompareTag("Ground"))�̴�.
        {
            // �̰��� ���� �浹�� ������Ʈ�� �̸��� "Ground"�� �� ����Ǵ� �ڵ��̴�.
            // if (collision.gameObject.tag == "Ground")���� �������� ������ ����.
            // tag�� ���� ������Ʈ�� ������ �±׸� ���� �� �ְ�, name�� ������Ʈ���� ������ �̸��� ������ �Ѵٴ� ���̴�.
            // �̰��� �� ���� ���ϸ�, tag�� �׷��� ��Ÿ����, name�� ���� ������Ʈ�� ��Ÿ���ٰ� �� �� �ִ�.
            // ����, tag�� ����� ���� ���� ������Ʈ�� ������ �±׸� ���� �� ������, name�� ����� ���� �� ������Ʈ�� ������ �̸��� ������ �Ѵٴ� ���� ����ؾ� �Ѵ�.
            // ���������, tag�� ������Ʈ�� �׷�ȭ�ϴ� �� �����ϰ�, name�� Ư�� ������Ʈ�� �ĺ��ϴ� �� �����ϴ�.
            // �̶�, if (collision.gameObject.tag == "Ground")�� ����ϸ� ���� ������Ʈ�� ������ �±׸� ���� �� �ֱ� ������, �浹�� ������Ʈ�� "Ground" �±׸� ���� ��� ������Ʈ�� �浹���� �� ����ȴ�.
            // �ݸ鿡, if (collision.gameObject.name == "Ground")�� ����ϸ� �浹�� ������Ʈ�� �̸��� ��Ȯ�� "Ground"�� ���� ����ȴ�.
            // ����, �� ��쿡�� name�� ����ϴ� ���� �� �����ϴ�.
            // ���������, �� �ڵ�, �� if (collision.gameObject.name == "Ground")�� �浹�� ������Ʈ�� �̸��� "Ground"�� �� ����Ǵ� �ڵ��̴�.
            // �׸���, �� �ڵ�� �浹�� ������Ʈ�� "Ground"�� �� �� ������Ʈ�� �ı��ϴ� ������ �Ѵ�.
            // ��, �� ���� ������ �� ������Ʈ�� ��������� �ϴ� ���̴�.
            // �� �� ���: �� ���� ������ �� ������Ʈ�� �ı��Ѵ�.
            // Debug.Log("�浹")(�ʿ���� �κ������� ������ ���� �����.)
            Destroy(this.gameObject); // Destroy(this.gameObject);�� �ƴ϶� Destroy(collision.gameObject);�� �����, �� ���� ��Ƶ� ������� �ʾҴ�.
            // ��, ����� ���� �� ������Ʈ����.
            // ����, �� ������Ʈ�� �ı��Ϸ��� this.gameObject�� ����ؾ� �Ѵ�.
            // this�� ���� ��ũ��Ʈ�� �پ��ִ� ������Ʈ�� �ǹ��Ѵ�.
            // gameObject�� ��ũ��Ʈ�� �پ��ִ� ������Ʈ ��ü�� �ǹ��Ѵ�.
            // ����, this.gameObject�� ���� ��ũ��Ʈ�� �پ��ִ� ������Ʈ ��ü�� �ǹ��Ѵ�.
            // ���������, Destroy(this.gameObject)�� ���� ��ũ��Ʈ�� �پ��ִ� ������Ʈ�� �ı��ϴ� �ڵ��̴�.
            // this.gameObject�� ������� �ʰ� �׳� gameObject�� ����ص� �ȴ�.(this�� ���� �����ϱ� ����)(��, Destroy(gameObject);�� �ᵵ �ȴ�.)(�̷��� �ص� �ȴ�.)
            // this�� ������� ��, ���� �ƴ϶� �� ������� ������, �� ��ũ��Ʈ�� �� ������Ʈ�� �پ��ֱ� �����̴�.
            // this�� ����� �� �ִ� �ڵ�� ����.
            // �̰��� Ȯ���� �� �ִ� �����, Unity �����Ϳ��� �� ������Ʈ�� ������ ��, �ν����� â���� �� ��ũ��Ʈ�� �پ��ִ��� Ȯ���ϴ� ���̴�.
            // ����Ƽ â���� �������� ��ġ�� ��� �޴��� Window > General > Inspector�� Ŭ���ϸ� �ν����� â�� ��Ÿ����.
            // �ν����� â���� �� ������Ʈ�� �����ϸ�, �� ��ũ��Ʈ�� �پ��ִ� ���� Ȯ���� �� �ִ�.
            // �ν����� â�� ��ü���� ��ġ��, ����Ƽ �������� �����ʿ� ��ġ�� �ִ�.
            // Destroy(������Ʈ) �Լ��� ������Ʈ�� �ı��ϴ� �Լ��̴�.
        }

        if (collision.gameObject.CompareTag("Player")) // CompareTag�� Tag�� ����Ƽ â�� Inspector�� Tag�� ���� ����.
            // ��, Player�� �±��ϸ� if (collision.gameObject.CompareTag("Player"))�� �� �� �ִ�.
        {
            GameManager.Instance.AddScore(score); // GameManager.Instance.MakeRain();�� ����, 'GameManager.cs*'���� public�� ���� �ʾұ� ������ ������ �߻��Ѵ�.
            Destroy(this.gameObject); // �̰��� �±׵� 'Player'�� Rain�� �ε�����, Rain�� �ı��ǵ��� �ϴ� ���̴�. �̴� 'Ground'�� ���� �Լ� �Ǵ� �ڵ��̴�.
        }
    }
}


*/