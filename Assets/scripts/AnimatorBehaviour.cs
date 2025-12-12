using UnityEngine;

public class AnimationBehaviour : MonoBehaviour
{
    [SerializeField] private Animator _animator;

    void Start()
    {
        if (_animator == null)
        {
            _animator = GetComponentInChildren<Animator>();
        }
    }
    public void Move(Vector3 direction)
    {
        
        _animator.SetFloat("speed", direction.magnitude, 0.1f, Time.deltaTime);
    }
    public void Dance()
    {
        if (_animator.GetBool("Dance"))
        {
            _animator.SetBool("Dance", false);
            
        }
        else {
            _animator.SetBool("Dance", true);
            
        }
        
    }
}
