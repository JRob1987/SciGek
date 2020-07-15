using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimations : MonoBehaviour
{
    private Animation _anim;

    private void Awake()
    {
        _anim = GetComponent<Animation>();
    }

    public void IdleAnimation()
    {
        _anim.Play(LevelOneTags.ANIMATION_IDLE);
    }
    public void PlayerWalkAnimation()
    {
        _anim.Play(LevelOneTags.ANIMATION_WALK);
    }

    public void PlayerStopWalkingAnimation()
    {
        _anim.Stop(LevelOneTags.ANIMATION_WALK);
        _anim.Blend(LevelOneTags.ANIMATION_WALK, 0);
        _anim.CrossFade(LevelOneTags.ANIMATION_IDLE);   
    }

    public void WalkToRun()
    {
        _anim.Stop(LevelOneTags.ANIMATION_WALK);
        _anim.Blend(LevelOneTags.ANIMATION_RUN, 0);
    }

    public void PlayerRunAnimation()
    {
        _anim.Play(LevelOneTags.ANIMATION_RUN);
       
    }

    public void PlayerStopRunningAnimation()
    {
        _anim.Stop(LevelOneTags.ANIMATION_RUN);
        _anim.Blend(LevelOneTags.ANIMATION_RUN, 0);
        _anim.CrossFade(LevelOneTags.ANIMATION_IDLE);
    }
    
    public void JumpAnimation()
    {
        _anim.Play(LevelOneTags.ANIMATION_JUMP);
        _anim.PlayQueued(LevelOneTags.ANIMATION_JUMP_FALL);
    }

    public void LandAnimation()
    {
        _anim.Stop(LevelOneTags.ANIMATION_JUMP_FALL);
        _anim.Stop(LevelOneTags.ANIMATION_JUMP_LAND);
        _anim.Blend(LevelOneTags.ANIMATION_JUMP_LAND, 0);
        _anim.CrossFade(LevelOneTags.ANIMATION_IDLE);
    }




} //class
