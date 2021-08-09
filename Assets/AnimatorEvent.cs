using UnityEngine;

public class AnimatorEvent : MonoBehaviour
{
    void RotPlayer()
    {
        transform.rotation = Quaternion.Euler(0, 45, 0);
    }
}
