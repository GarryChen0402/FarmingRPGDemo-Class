using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationOverrides : MonoBehaviour
{
    [SerializeField] private GameObject character = null;
    [SerializeField] private SO_AnimationType[] soAnimationTypeArray = null;

    private Dictionary<AnimationClip, SO_AnimationType> animationTypeDictionryByAnimation;
    private Dictionary<string, SO_AnimationType> animationTypeDictionaryByCompositeAttrubuteKey;

    private void Start()
    {
        animationTypeDictionryByAnimation = new Dictionary<AnimationClip, SO_AnimationType>();
        foreach(SO_AnimationType item in soAnimationTypeArray)
        {
            animationTypeDictionryByAnimation.Add(item.animationClip, item);
        }

        animationTypeDictionaryByCompositeAttrubuteKey = new Dictionary<string, SO_AnimationType>();
        foreach(SO_AnimationType item in soAnimationTypeArray)
        {
            string key = item.characterPart.ToString() + item.partVariantColour.ToString() + item.partVariantType.ToString() + item.animationName.ToString();
            animationTypeDictionaryByCompositeAttrubuteKey.Add(key, item); 
        }

    }

    public void ApplyCharacterCustomisationParameters(List<CharacterAttribute> characterAttributeList)
    {
        foreach (CharacterAttribute characterAttribute in characterAttributeList)
        {
            Animator currentAnimatior = null;
            List<KeyValuePair<AnimationClip, AnimationClip>> animsKeyValuePairList = new List<KeyValuePair<AnimationClip, AnimationClip>>();

            string animatorSOAssetName = characterAttribute.characterPart.ToString();

            Animator[] animatorsArray = character.GetComponentsInChildren<Animator>();

            foreach (Animator animator in animatorsArray)
            {
                if (animator.name == animatorSOAssetName)
                {
                    currentAnimatior = animator;
                    break;
                }
            }

            AnimatorOverrideController aoc = new AnimatorOverrideController(currentAnimatior.runtimeAnimatorController);
            List<AnimationClip> animationsList = new List<AnimationClip>(aoc.animationClips);

            foreach (AnimationClip animationClip in animationsList)
            {
                SO_AnimationType so_animtationType;
                bool foundAnimation = animationTypeDictionryByAnimation.TryGetValue(animationClip, out so_animtationType);

                if (foundAnimation)
                {
                    string key = characterAttribute.characterPart.ToString() + characterAttribute.partVariantColour.ToString() +
                        characterAttribute.partVariantType.ToString() + so_animtationType.animationName.ToString();
                    SO_AnimationType swapSO_AnimationType;
                    bool foundSwapAnimation = animationTypeDictionaryByCompositeAttrubuteKey.TryGetValue(key, out swapSO_AnimationType);
                    if (foundSwapAnimation)
                    {
                        AnimationClip swapAnimationClip = swapSO_AnimationType.animationClip;

                        animsKeyValuePairList.Add(new KeyValuePair<AnimationClip, AnimationClip>(animationClip, swapAnimationClip));
                    }

                }
            }
            aoc.ApplyOverrides(animsKeyValuePairList);
            currentAnimatior.runtimeAnimatorController = aoc;
        }
    }
}