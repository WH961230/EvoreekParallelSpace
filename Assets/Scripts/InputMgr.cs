using UnityEngine;

public class InputMgr : Singleton<InputMgr>
{
    private bool IsOpenInput = false;
    public void OnInit()
    {
        IsOpenInput = true;
        MonoMgr.GetInstance().AddUpdateEventListener(OnUpdate);
    }

    private void OnUpdate()
    {
        CheckInput();
    }

    private void CheckInput()
    {
        if (IsOpenInput == false)
        {
            return;
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            Debug.Log("按下");
        }
    }
}
