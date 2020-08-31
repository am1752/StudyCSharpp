namespace BookRentalShopApp20
{
    public enum BaseMode
    {
        None,
        INSERT,
        UPDATE,
        DELETE,
        SELECT
    }
    public class Commons
    {
        //공통 DB 연결문자열
        public static readonly string CONNSTR = "Data Source=localhost;Port=3306;Database=bookRentalshop;Uid=root;Password=mysql_p@ssw0rd";

        
    }
}
