using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace BookRentalShopApp20
{
    public enum BaseMode
    {
        NONE,       // 기본상태
        INSERT,     // 입력상태
        UPDATE,     // 수정상태
        DELETE,
        SELECT
    }

    public class Commons
    {
        public static readonly string CONNSTR = "Data Source=localhost;Port=3306;Database=bookrentalshop;Uid=root;Password=mysql_p@ssw0rd";

        /// <summary>
        /// Md5 암호화 메서드
        /// </summary>
        /// <param name="md5Hash">해시키값</param>
        /// <param name="Ininput">평문 문자열</param>
        /// <returns>암호화된 문자열</returns>
        public static string GetMd5Hash(MD5 md5Hash, string input)
        {
            //인풋값을 바이트로 바꿔서 컴퓨터 해쉬 씌워주는것
            byte[] data = md5Hash.ComputeHash(Encoding.UTF8.GetBytes(input));
            StringBuilder sbuilder = new StringBuilder();

            for (int i = 0; i < data.Length; i++)
            {
                sbuilder.Append(data[i].ToString("x2"));
            }

            return sbuilder.ToString();
        }
    }
   

}
