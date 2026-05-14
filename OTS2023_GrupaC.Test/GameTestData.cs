using NUnit.Framework;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace OTS2026_GrupaD.Test
{
    
        public class moveupsuccsesfull_GameTestData
        {
         public static IEnumerable Moveupsuccsesful_GameTestData()
        {

            yield return new TestCaseData(1, 4, 8,3,2,7);
            yield return new TestCaseData(6,15,4,4,4,4);
            yield return new TestCaseData(12, 23, 0, 11, 22, -1);
            yield return new TestCaseData(0, 0, 0, -1, -1, -1);
            yield return new TestCaseData(29, 29, 29, 28, 28, 28);
        }
            
        }
    }

