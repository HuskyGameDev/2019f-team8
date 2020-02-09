﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface Powerup : MonoBehaviour
{
    
    Powerup newPowerup(int value)
    {
        switch(value)
        {
            case 0:
                return new Invulnerability();
            case 1:
                return new Slow_Cannon_Speed();
            case 2:
                return new Spelling();
        }
        
    }
    
}
