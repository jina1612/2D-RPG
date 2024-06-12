using UnityEngine;

public class End : MonoBehaviour
{
    public class ExitGame : MonoBehaviour
    {
        // 버튼이 클릭되었을 때 호출될 함수
        public void Exit()
        {
            Debug.Log("게임을 종료합니다.");
            Application.Quit(); // 게임 종료
        }
    }
}
