﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IHitable 
{
    void OnHit(Weapon.DamageInfo damageInfo);
    void InstantDead();
}
