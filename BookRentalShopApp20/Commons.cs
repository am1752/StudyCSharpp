using System;
using System.Collections.Generic;
using System.Linq;
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
    }
}
