using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace YardDefense
{
    [Serializable]
    public struct ScienceNum
    {
        //Should always be between 1 and 9.9999
        public float baseValue;
        public int eFactor;

        public static ScienceNum operator +(ScienceNum sn1, ScienceNum sn2)
        {
            //Bring the 2 numbers to the same power of 10.
            int factorDiff = sn1.eFactor - sn2.eFactor;
            if (factorDiff >= 8)
                return sn1;
                
            sn2.baseValue /= Mathf.Pow(10, factorDiff);
            sn2.eFactor += factorDiff;
            
            //Add
            sn1.baseValue += sn2.baseValue;
            
            //If 0, then 0 can be returned now to avoid div/0 errors
            if(sn1.baseValue == 0)
                return sn1;
            
            //Convert resulting baseValue back to single digit range
            int eChange = Mathf.FloorToInt(Mathf.Log10(Mathf.Abs(sn1.baseValue)));
            sn1.baseValue /= Mathf.Pow(10, eChange);
            sn1.eFactor += eChange;
            return sn1;            
        }

        public static ScienceNum operator -(ScienceNum sn1, ScienceNum sn2)
        {
            //Bring the 2 numbers to the same power of 10.
            int factorDiff = sn1.eFactor - sn2.eFactor; //1
            if (factorDiff >= 8)
                return sn1;
            sn2.baseValue /= Mathf.Pow(10,factorDiff);
            sn2.eFactor += factorDiff;
            
            //Subtract
            sn1.baseValue -= sn2.baseValue;
            
            //If 0, then 0 can be returned now to avoid div/0 errors
            if (sn1.baseValue == 0)
                return sn1;
            
            //Convert resulting baseValue back to single digit range
            int eChange = Mathf.FloorToInt(Mathf.Log10(Mathf.Abs(sn1.baseValue)));
            sn1.baseValue /= Mathf.Pow(10, eChange);
            sn1.eFactor += eChange;
            return sn1;
        }
        
        public static ScienceNum operator *(ScienceNum sn1, ScienceNum sn2)
        {
            sn1.baseValue *= sn2.baseValue;
            sn1.eFactor += sn2.eFactor;
            
            if (sn1.baseValue >= 10f)
            {
                sn1.eFactor += 1;
                sn1.baseValue /= 10;
            }
            
            return sn1;
        }

        public static ScienceNum operator /(ScienceNum sn1, ScienceNum sn2)
        {

            sn1.baseValue /= sn2.baseValue;
            sn1.eFactor -= sn2.eFactor;

            if (sn1.baseValue < 1f)
            {
                sn1.eFactor -= 1;
                sn1.baseValue *= 10;
            }

            return sn1;
        }

        public float Conversion()
        {
            return baseValue * Mathf.Pow(10, eFactor);
        }

        public override string ToString()
        {
            return String.Format("{0}e{1}", baseValue, eFactor);
        }

        public static ScienceNum FromString(string str)
        {
            ScienceNum scienceNum = new ScienceNum();
            var split = str.Split('e');
            scienceNum.baseValue = Convert.ToSingle(split[0]);
            scienceNum.eFactor = Convert.ToInt32(split[1]);
            return scienceNum;
        }
    }
}
