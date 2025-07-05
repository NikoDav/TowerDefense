using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwordsmanUnitAttack : UnitAttack
{
    [SerializeField] private ShotAudioMultiple _playAudio;

    public override void Attack()
    {
        _elapsedTime += Time.deltaTime;
        if(_elapsedTime>= _delay)
        {
            _target.TakeDamage(_damage);
            _target.SetNewTarget(this.transform);
            _animator.SetTrigger("Hit");
            Instantiate(_playAudio);
            Debug.Log("swordsman attack");
            _elapsedTime = 0;
        }
    }


    private void OnDrawGizmos()
    {
        Gizmos.color = new Color(0, 1, 0, 0.3f);
        Gizmos.DrawSphere(transform.position, _range);
    }

}
