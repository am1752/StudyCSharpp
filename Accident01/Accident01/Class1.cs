using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Accident01
{
    public class Class1
    {
        public Dictionary<string, string> dic = new Dictionary<string, string>();
        public Class1(){        
                        
            dic["전국"] = "00";
            dic["서울시"] = "11";
            dic["부산시"] = "26";
            dic["대구시"] = "27";
            dic["인천시"] = "28";
            dic["광주시"] = "29";
            dic["대전시"] = "30";
            dic["울산시"] = "31";
            dic["세종시"] = "36";
            dic["경기도"] = "41";
            dic["강원도"] = "42";
            dic["충청북도"] = "43";
            dic["충청남도"] = "44";
            dic["전라북도"] = "45";
            dic["전라남도"] = "46";
            dic["경상북도"] = "47";
            dic["경상남도"] = "48";
            dic["제주도"] = "50";
        }
      
    }

   
}
