using UnityEngine;

public class End : MonoBehaviour
{
    public class ExitGame : MonoBehaviour
    {
        // ��ư�� Ŭ���Ǿ��� �� ȣ��� �Լ�
        public void Exit()
        {
            Debug.Log("������ �����մϴ�.");
            Application.Quit(); // ���� ����
        }
    }
}
