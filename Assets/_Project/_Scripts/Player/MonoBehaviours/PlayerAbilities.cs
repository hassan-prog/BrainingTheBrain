using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class PlayerAbilities : MonoBehaviour
{
    [SerializeField] private List<AbilityBase> _abilities;

    private PlayerInputHandler _playerInputhandler;
    public AbilityBase ActiveAbility { get; private set; }

    public void Init(PlayerInputHandler playerInputHandler)
    {
        _playerInputhandler = playerInputHandler;
    }

    private void OnEnable()
    {
        _playerInputhandler.OnAbilityUse += PerformAbility;
    }

    private void OnDisable()
    {
        _playerInputhandler.OnAbilityUse -= PerformAbility;
    }

    public void PerformAbility(AbilityType type)
    {
        ActiveAbility = _abilities.FirstOrDefault(x => x.AbilityType == type)?.ActivateAbility(gameObject);
        if (ActiveAbility != null
            && ActiveAbility.AbilityType == AbilityType.Invisibility
            && ActiveAbility.IsActive)
        {
            PlayerProperties.IsInvisible = true;
        }
        else PlayerProperties.IsInvisible = false;
    }
}

