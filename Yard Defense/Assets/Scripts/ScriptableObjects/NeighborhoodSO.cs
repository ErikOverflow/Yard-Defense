using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace YardDefense
{
    [CreateAssetMenu(fileName = "New neighborhood", menuName = "Create new neighborhood", order = 1)]
    public class NeighborhoodSO : ScriptableObject
    {
        public List<WaveSO> waves;
    }
}