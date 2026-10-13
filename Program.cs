using System.Runtime.InteropServices;

namespace C_入门实践
{
    internal class Program
    {
        static void Main(string[] args)
        {
            #region 1 控制台设置
            //影藏光标
            Console.CursorVisible = false;
            int width = 50;
            int height = 30;
            Console.SetWindowSize(width, height);
            Console.SetBufferSize(width, height);
            #endregion

            #region 2 多个场景
            //当前所在场景的ID
            int nowSceneID = 1;
            while (true)
            {
                bool isQuitWhile = false;
                bool isBadEnd = false;
                bool isHappyEnd = false;
                //不同的场景ID 进行不同的逻辑处理
                switch (nowSceneID)
                {
                    case 1:
                        //开始场景
                        Console.Clear();
                        //Console.WriteLine("开始场景");
                        #region 3 开始场景逻辑
                        Console.SetCursorPosition(width / 2 - 7, 6);
                        Console.Write("大兔兔营救tuutua");

                        //当前选项的编号
                        int nowSelIndex = 0;
                        //输入 可以构造一个开始界面的死循环
                        while (true)
                        {
                            if (isQuitWhile == true)
                                break;
                            //显示 内容
                            //先设置光标位置 再显示内容
                            Console.SetCursorPosition(width / 2 - 4, 13);
                            Console.ForegroundColor = nowSelIndex == 0 ? ConsoleColor.Red : ConsoleColor.White;
                            Console.Write("开始游戏");
                            Console.SetCursorPosition(width / 2 - 4, 16);
                            Console.ForegroundColor = nowSelIndex == 1 ? ConsoleColor.Red : ConsoleColor.White;
                            Console.Write("退出游戏");
                            //检测 输入
                            char input = Console.ReadKey(true).KeyChar;
                            switch (input)
                            {
                                case 'W':
                                case 'w':
                                    if (nowSelIndex != 0)
                                        nowSelIndex = 0;
                                    break;
                                case 'S':
                                case 's':
                                    if (nowSelIndex != 1)
                                        nowSelIndex = 1;
                                    break;
                                case 'J':
                                case 'j':
                                    if (nowSelIndex == 0)
                                    {
                                        //1 改变当前的场景ID
                                        nowSceneID = 2;
                                        //2 退出内层的while循环
                                        isQuitWhile = true;
                                    }
                                    else
                                    {
                                        //关闭控制台 在调试模式没用
                                        Environment.Exit(0);
                                    }
                                    break;
                            }
                        }
                        #endregion
                        break;
                    case 2:
                        //游戏场景
                        Console.Clear();
                        //Console.WriteLine("游戏场景");

                        #region 4 不变的红墙
                        Console.ForegroundColor = ConsoleColor.Red;
                        //画墙
                        //墙
                        for (int i = 1; i <= width; i +=2)
                        {
                            Console.SetCursorPosition(i,0);
                            Console.Write("■");
                            Console.SetCursorPosition(i, height - 8);
                            Console.Write("■");
                            Console.SetCursorPosition(i, height-1);
                            Console.Write("■");
                        }
                        for (int i = 1; i <= height - 1; i++)
                        {
                            Console.SetCursorPosition(1, i);
                            Console.Write("■");
                            Console.SetCursorPosition(width-1, i);
                            Console.Write("■");
                        }
                        #endregion

                        #region 5 boss属性相关
                        int bossX = 27;
                        int bossY = 15;
                        int bossAtkMin = 7;
                        int bossAtkMax = 16;
                        int bossHp = 100;
                        string bossIcon = "■";
                        ConsoleColor bossColor = ConsoleColor.Green;
                        #endregion

                        #region 6 玩家属性相关
                        int playerX = 7;
                        int playerY = 5;
                        int playerAtkMin = 8;
                        int playerAtkMax = 12;
                        int playerHp = 100;
                        string playerIcon = "●";
                        ConsoleColor playerColor = ConsoleColor.Yellow;

                        char playerInput;
                        #endregion

                        #region 8 公主相关
                        int princessX = 23;
                        int princessY = 5;
                        string princessIcon = "▲";
                        ConsoleColor princesssColor = ConsoleColor.Blue;
                        #endregion

                        #region 7 玩家战斗相关
                        bool isFight = false;
                        bool isWin = false;
                        #endregion

                        while (true)
                        {
                            if (isBadEnd == true)
                            {
                                Console.SetCursorPosition(2, height - 7);
                                Console.ForegroundColor = ConsoleColor.White;
                                Console.Write("                                            ");
                                Console.SetCursorPosition(2, height - 7);
                                Console.Write("按J键继续");
                                playerInput = Console.ReadKey(true).KeyChar;
                                if (playerInput == 'J' || playerInput == 'j')
                                    break;
                            }
                            else if(isHappyEnd == true)
                            {
                                break;
                            }
                            #region 5 boss属性相关
                            if (bossHp > 0)
                            {
                                //绘制Boss图标
                                Console.SetCursorPosition(bossX, bossY);
                                Console.ForegroundColor = bossColor;
                                Console.Write(bossIcon);
                            }
                            #endregion
                            else
                            {
                                //公主显示逻辑
                                Console.SetCursorPosition(princessX, princessY);
                                Console.ForegroundColor = princesssColor;
                                Console.Write(princessIcon);
                            }


                            Console.SetCursorPosition(playerX, playerY);
                            Console.ForegroundColor= playerColor;
                            Console.Write(playerIcon);
                            //得到玩家输入
                            playerInput = Console.ReadKey(true).KeyChar;
                            //战斗状态处理逻辑
                            if (isFight)
                            {
                                if (playerInput == 'J' || playerInput == 'j')
                                {
                                    //擦除
                                    Console.SetCursorPosition(2, height - 5);
                                    Console.Write("                                            ");
                                    Console.SetCursorPosition(2, height - 4);
                                    Console.Write("                                            ");
                                    //处理战斗
                                    //玩家打怪物
                                    Random r = new Random();
                                    int atk = r.Next(playerAtkMin, playerAtkMax);
                                    bossHp -= atk;
                                    //打印信息
                                    Console.SetCursorPosition(2, height - 5);
                                    Console.Write("                                            ");
                                    Console.SetCursorPosition(2, height - 5);
                                    Console.ForegroundColor = ConsoleColor.Yellow;
                                    Console.Write("你对Boss造成了{0}点伤害,Boss剩余{1}血量",atk,bossHp);
                                    if (bossHp > 0)
                                    {
                                        //怪物打玩家
                                        atk = r.Next(bossAtkMin, bossAtkMax);
                                        playerHp -= atk;
                                        //打印信息
                                        Console.SetCursorPosition(2, height - 4);
                                        Console.Write("                                            ");
                                        Console.SetCursorPosition(2, height - 4);
                                        Console.ForegroundColor = ConsoleColor.DarkYellow;
                                        Console.Write("Boss对你造成了{0}点伤害,你剩余{1}血量", atk, playerHp);
                                        if (playerHp <= 0)
                                        {
                                            //失败逻辑
                                            Console.SetCursorPosition(2, height - 4);
                                            Console.ForegroundColor = ConsoleColor.Magenta;
                                            Console.Write("Boss对你造成了{0}点伤害,你剩余{1}血量", atk, playerHp);    
                                            Console.SetCursorPosition(2, height - 3);
                                            Console.Write("很遗憾，你未能通过Boss的试炼");
                                            isBadEnd = true;
                                            //isFight = false;
                                            nowSceneID = 1;
                                        }
                                    }
                                    else
                                    {
                                        //打赢Boss
                                        Console.SetCursorPosition(bossX,bossY);
                                        Console.Write("  ");
                                        Console.SetCursorPosition(2, height - 7);
                                        Console.Write("                                            ");
                                        Console.SetCursorPosition(2, height - 5);
                                        Console.Write("                                            ");
                                        Console.SetCursorPosition(2, height - 4);
                                        Console.Write("                                            ");
                                        Console.SetCursorPosition(2, height - 5);
                                        Console.ForegroundColor = ConsoleColor.Magenta;
                                        Console.SetCursorPosition(2, height - 7);
                                        Console.Write("你战胜了Boss，快去营救tuutua");
                                        Console.SetCursorPosition(2, height - 6);
                                        Console.Write("请在tuutua身边按J键继续");
                                        isFight = false;


                                    }
                                }
                            }
                            //非战斗状态处理逻辑
                            else if(!isFight && !isWin)
                            {
                                #region 6 玩家移动相关
                                //擦除
                                Console.SetCursorPosition(playerX, playerY);
                                Console.Write(" ");
                                //改位置
                                switch (playerInput)
                                {
                                    case 'W':
                                    case 'w':
                                        playerY--;
                                        if (playerY < 1)
                                        {
                                            playerY++;
                                        }
                                        else if (playerX == bossX && playerY == bossY && bossHp > 0)
                                        {
                                            playerY++;
                                        }
                                        else if (playerX == princessX && playerY == princessY && bossHp <= 0)
                                        {
                                            playerY++;
                                        }
                                            break;
                                    case 'A':
                                    case 'a':
                                        playerX -= 2;
                                        if (playerX <= 1)
                                        {
                                            playerX += 2;
                                        }
                                        else if (playerX == bossX && playerY == bossY && bossHp > 0)
                                        {
                                            playerX += 2;
                                        }
                                        else if (playerX == princessX && playerY == princessY && bossHp <= 0)
                                        {
                                            playerX+=2;
                                        }
                                        break;
                                    case 'S':
                                    case 's':
                                        playerY++;
                                        if (playerY >= height - 8)
                                        {
                                            playerY--;
                                        }
                                        else if (playerX == bossX && playerY == bossY && bossHp > 0)
                                        {
                                            playerY--;
                                        }
                                        else if (playerX == princessX && playerY == princessY && bossHp <= 0)
                                        {
                                            playerY--;
                                        }
                                        break;
                                    case 'D':
                                    case 'd':
                                        playerX += 2;
                                        if (playerX >= width - 2)
                                        {
                                            playerX -= 2;
                                        }
                                        else if (playerX == bossX && playerY == bossY && bossHp > 0)
                                        {
                                            playerX -= 2;
                                        }
                                        else if (playerX == princessX && playerY == princessY && bossHp <= 0)
                                        {
                                            playerX -= 2;
                                        }
                                        break;
                                    case 'J':
                                    case 'j':
                                        //开始战斗
                                        if ((playerX == bossX && playerY == bossY - 1 ||
                                           playerX == bossX && playerY == bossY + 1 ||
                                           playerX == bossX - 2 && playerY == bossY ||
                                           playerX == bossX + 2 && playerY == bossY) && bossHp > 0)
                                        {
                                            isFight = true;
                                            Console.SetCursorPosition(2, height - 7);
                                            Console.ForegroundColor = ConsoleColor.White;
                                            Console.Write("开始和Boss战斗了，按J键继续");
                                            Console.SetCursorPosition(2, height - 5);
                                            Console.Write("玩家当前血量为{0}", playerHp);
                                            Console.SetCursorPosition(2, height - 4);
                                            Console.Write("Boss当前血量为{0}", bossHp);
                                        }
                                        //要让玩家不能在移动
                                        //下方能显示信息

                                        //公主交互
                                        else if((playerX == princessX && playerY == princessY - 1 ||
                                                 playerX == princessX && playerY == princessY + 1 ||
                                                 playerX == princessX - 2 && playerY == princessY ||
                                                 playerX == princessX + 2 && playerY == princessY) && bossHp <= 0)
                                        {
                                            isWin = true;
                                        }
                                        break;
                                }
                                if ((playerX == bossX && playerY == bossY - 1 ||
                                     playerX == bossX && playerY == bossY + 1 ||
                                     playerX == bossX - 2 && playerY == bossY ||
                                     playerX == bossX + 2 && playerY == bossY) && bossHp > 0 && playerHp > 0)
                                {
                                    Console.SetCursorPosition(2, height - 7);
                                    Console.ForegroundColor = ConsoleColor.White;
                                    Console.Write("按J键开始和Boss战斗");
                                }
                                else
                                {
                                    Console.SetCursorPosition(2, height - 7);
                                    Console.ForegroundColor = ConsoleColor.White;
                                    if (bossHp > 0)
                                    {
                                        Console.Write("                                            ");
                                    }
                                    
                                }
                                #endregion
                            }
                            if (isWin)
                            {
                                Console.SetCursorPosition(playerX, playerY);
                                Console.ForegroundColor = playerColor;
                                Console.Write(playerIcon);
                                Console.SetCursorPosition(2, height - 5);
                                Console.ForegroundColor = ConsoleColor.Yellow;
                                Console.Write("Tuutua非常感激");
                                Console.SetCursorPosition(2, height - 4);
                                Console.Write("大兔兔和tuutua从此过上了幸福的生活");
                                playerInput = Console.ReadKey(true).KeyChar;
                                if (playerInput == 'J' || playerInput == 'j')
                                {
                                    nowSceneID = 3;
                                    isHappyEnd = true;
                                }
                                else
                                {
                                    playerInput = Console.ReadKey(true).KeyChar;
                                }
                            }
                        }
                        break;
                    case 3:
                        //结束场景
                        Console.Clear();
                        //Console.WriteLine("结束场景");
                        Console.SetCursorPosition(width / 2 - 7, 6);
                        Console.Write("大兔兔游戏胜利");
                        nowSelIndex = 0;
                        while (true)
                        {
                            if (isQuitWhile == true)
                                break;
                            //显示 内容
                            //先设置光标位置 再显示内容
                            Console.SetCursorPosition(width / 2 - 4, 13);
                            Console.ForegroundColor = nowSelIndex == 0 ? ConsoleColor.Red : ConsoleColor.White;
                            Console.Write("返回主菜单");
                            Console.SetCursorPosition(width / 2 - 4, 16);
                            Console.ForegroundColor = nowSelIndex == 1 ? ConsoleColor.Red : ConsoleColor.White;
                            Console.Write("退出游戏");
                            //检测 输入
                            char input = Console.ReadKey(true).KeyChar;
                            switch (input)
                            {
                                case 'W':
                                case 'w':
                                    if (nowSelIndex != 0)
                                        nowSelIndex = 0;
                                    break;
                                case 'S':
                                case 's':
                                    if (nowSelIndex != 1)
                                        nowSelIndex = 1;
                                    break;
                                case 'J':
                                case 'j':
                                    if (nowSelIndex == 0)
                                    {
                                        //1 改变当前的场景ID
                                        nowSceneID = 1;
                                        //2 退出内层的while循环
                                        isQuitWhile = true;
                                    }
                                    else
                                    {
                                        //关闭控制台 在调试模式没用
                                        Environment.Exit(0);
                                    }
                                    break;
                            }
                        }
                        break;
                }
            }
            #endregion
        }
    }
}
