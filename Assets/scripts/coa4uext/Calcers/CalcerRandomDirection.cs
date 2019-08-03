using System;
using System.Collections.Generic;
using UnityEngine;

namespace coa4u
{
    public class CalcerRandomDirection : CalcerVector
    {
        Axises axises;

        public CalcerRandomDirection(Axises axises)
        {
            this.axises = axises;
        }

        public override Vector3 value
        {
            get
            {
                float x = UnityEngine.Random.Range(-360.0F, 360.0F);
                float y = UnityEngine.Random.Range(-360.0F, 360.0F);
                float z = UnityEngine.Random.Range(-360.0F, 360.0F);
                switch (axises)
                {
                    case Axises.x:
                        return new Vector3(x, 0, 0);
                    case Axises.y:
                        return new Vector3(0, y, 0);
                    case Axises.z:
                        return new Vector3(0, 0, z);
                    case Axises.xy:
                        return new Vector3(x, y, 0);
                    case Axises.xz:
                        return new Vector3(x, 0, z);
                    case Axises.yz:
                        return new Vector3(0, y, z);
                    case Axises.xyz:
                        return new Vector3(x, y, z);
                    default:
                        return Vector3.zero;
                }
            }
            
        }
    }
}