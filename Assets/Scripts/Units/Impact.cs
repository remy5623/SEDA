using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Impact : MonoBehaviour
{
    [Tooltip("Is this a source of Buffs or nerfs for other structures?")]
    public bool impactSource;
    [Tooltip("multiplier to output from the buff Source")]                                                                                                                                       
    public float buffAmount;                                            
    [Tooltip("multiplier to output from the nerf Source")]                                               
    public float nerfAmount;                                          
    [Tooltip("list of objects this applies the buff to if insideImpactRadius")]
    public List<GameObject> tileImpactBuff;                            
    [Tooltip("list of objects this applies the nerf to if insideImpactRadius")]
    public List<GameObject> tileImapctNerf;                             
}
