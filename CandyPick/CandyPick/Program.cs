using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CandyPick
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("~~~~~~~~Let's START the Battle~~~~");
            Console.WriteLine(); // làm đẹp
            int[] game = new int[] { 0, 3, 5, 7 };
            printGame(game);
            Console.WriteLine(); // làm đẹp
            while (true)
            { /* logic đi : human -> print -> check -> AI -> print -> checkAI ( loop ) 
               * nếu IF thỏa mãn -> vào trong do xong BREAK xong vòng loop
               */
                human(game);
                Console.WriteLine(); // làm đẹp 
                printGame(game);
                if (has0Line(game))
                {
                    Console.WriteLine(" ~~~~~~ you LOSE T.T ~~~~~~~~~~ Next Time ");
                    break;
                }
                AI(game);
                printGame(game);
                if (has0Line(game))
                {
                    Console.WriteLine("~~~ You WIN ÙwÚ ~~~~ Have nothing to teach u ");
                    break;
                }
                Console.WriteLine();
            }
        }
        static void human(int[] game)
        {
            /* Lấy số liệu 
             * Hàm Pick
             */
            Console.WriteLine("So dong muon lay : ");
            int line = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("So balls muon lay : ");
            int balls = Convert.ToInt32(Console.ReadLine());
            pickball(game, line, balls);
        } // Hàm human : lấy số liệu nhập ngoài đưa Input vào hàm PICKBALL xử lý
        static void AI(int[] game)
        {

            if (has1Line(game))
            {
                Console.WriteLine(">o< im thinking.....wait...");
                int left = 0;
                get1Line(game, out left);
                int balls = game[left] - 1;
                if (balls > 1)
                {
                    pickball(game, left, balls);
                    Console.WriteLine("I pick {0} balls at the line {1}", balls, left);
                }
                else if (balls == 1)
                {
                    pickball(game, left, 1);
                    Console.WriteLine("I pick {0} balls at the line {1}", balls, left);
                }
                else
                {
                    pickball(game, left, 1);
                    Console.WriteLine("I pick {0} balls at the line {1}", 1, left);
                }
                Console.WriteLine("~~~~Hmmmmmmmmmmmmmmm....look at you....");
            }
            if (has2Line(game))
            {
                Console.WriteLine(">o< im thinking.....wait...");
                int left1, left2 = 0;
                get2line(game, out left1, out left2);
                if (game[left1] - game[left2] == 0)
                {
                    pickball(game, left1, game[left1] - 1);
                    Console.WriteLine("I pick {0} balls at the line {1}", game[left1] - 1, left1);
                }
                if (game[left1] > game[left2])
                {
                    int balls = game[left1] - game[left2];
                    pickball(game, left1, balls);
                    Console.WriteLine("I pick {0} balls at the line {1}", balls, left1);
                }
                if (game[left1] < game[left2])
                {
                    int balls = game[left2] - game[left1];
                    pickball(game, left2, balls);
                    Console.WriteLine("I pick {0} balls at the line {1}", balls, left2);
                }
            }
            if (has3Line(game))
            {
                Console.WriteLine(">o< im thinking.....wait...");
                Random rand = new Random();
                int line = rand.Next(1, 3);
                int balls = rand.Next(1, game[line]);
                Console.WriteLine("I pick {0} balls at the line {1}", balls, line);
                pickball(game, line, balls);
            }
        } // Tạo Logic cho máy : chủ yếu là logic các bước đi : các TH1,TH2,TH3
        static void printGame(int[] game)
        {
            Console.Write("Line 1 :");
            for (int i = 0; i < game[1]; i++)
            {
                Console.Write(" O ");
            }
            Console.WriteLine();
            Console.Write("Line 2 :");
            for (int i = 0; i < game[2]; i++)
            {
                Console.Write(" O ");
            }
            Console.WriteLine();
            Console.Write("Line 3 :");
            for (int i = 0; i < game[3]; i++)
            {
                Console.Write(" O ");
            }
            Console.WriteLine();
        } // In dãy bi lúc mới khởi tạo dựa vào những thông số đưa ra trong mãng được khai báo từ đầu
        static void pickball(int[] game, int line, int balls)
        {
            game[line] = game[line] - balls;
        } // Hàm PickBall : hàm hoạt động chủ yếu trong game, In
        static bool has0Line(int[] game)
        {
            if (game[1] == 0 && game[2] == 0 && game[3] == 0)
            {
                return true;
            }
            return false;
        } 
        static bool has1Line(int[] game)
        {
            if (game[1] > 0 && game[2] == 0 && game[3] == 0)
            {
                return true;
            }
            else if (game[1] == 0 && game[2] > 0 && game[3] == 0)
            {
                return true;
            }
            else if (game[1] == 0 && game[2] == 0 && game[3] > 0)
            {
                return true;
            }
            return false;
        }
        static bool has2Line(int[] game)
        {
            if (game[1] > 0 && game[2] > 0 && game[3] == 0)
            {
                return true;
            }
            else if (game[1] == 0 && game[2] > 0 && game[3] > 0)
            {
                return true;
            }
            else if (game[1] > 0 && game[2] == 0 && game[3] > 0)
            {
                return true;
            }
            return false;
        }
        static bool has3Line(int[] game)
        {
            if (game[1] > 0 && game[2] > 0 && game[3] > 0)
            {
                return true;
            }
            return false;
        }
        static void get1Line(int[] game, out int left)
        {
            left = 0;
            if (game[1] > 0 && game[2] == 0 && game[3] == 0)
            {
                left = 1;
            }
            else if (game[1] == 0 && game[2] > 0 && game[3] == 0)
            {
                left = 2;
            }
            else if (game[1] == 0 && game[2] == 0 && game[3] > 0)
            {
                left = 3;
            }
        }
        static void get2line(int[] game, out int left1, out int left2)
        {
            left1 = 0; left2 = 0;
            if (game[1] > 0 && game[2] > 0 && game[3] == 0)
            {
                left1 = 1;
                left2 = 2;
            }
            else if (game[1] == 0 && game[2] > 0 && game[3] > 0)
            {
                left1 = 2;
                left2 = 3;
            }
            else if (game[1] > 0 && game[2] == 0 && game[3] > 0)
            {
                left1 = 1;
                left2 = 3;
            }
        }        
        /* code dài quá nên ko show ra hết được ! coi nào cmt nhen <3 
         * video live xong private nên hỏi lẹ nè ~ do nãy bật sơn tùng ~
         * 
         */
    
    }
}
