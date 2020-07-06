using static System.Console;

namespace EnumApp
{
    class Program
    {
        enum DialogResult
        {
            YES = 20,
            NO = 30,
            CANCEL = 50,
            CONFIRM = 60,
            OK = 70
        }

        static void Main(string[] args)
        {
            /* WriteLine(DialogResult.OK);
             WriteLine((int)DialogResult.OK);
             WriteLine(DialogResult.NO); */

            DialogResult result = DialogResult.YES;

            if (result == DialogResult.YES) WriteLine("YES를 선택했습니다!!");
        }
    }
}
