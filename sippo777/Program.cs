﻿using System; 
using System.Runtime.InteropServices;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace sippo777
{
    class Program
    {
static        int stari = 0, starj = 0, I = 7, J = 7, score = 0, needscore, lvl;
static        string loadlvl = "loadlvl";
static        char[,] array = new char[20, 20];
        static void Main(string[] args)
        {            
            //     Меню
            Console.WriteLine("1.NEW GAME");
            Console.WriteLine("2.LOAD GAME");
            Console.WriteLine("3.EXIT");
            Console.Title = "SUPERGAME";
            ConsoleKeyInfo key1 = Console.ReadKey();
            switch (key1.KeyChar)
            {
                case '1':
                    {
                    Game(1);
                    }
                    break;
                case '2':
                    {
                        Console.Clear();
                        Console.Write("Enter level: ");
                        lvl = Console.Read() - 48;
                        Game(lvl);
                    }
                    break;
                case '3':
                    {
                        return;
                    }
                default: break;
            }
        }
        static void Game(int lvl)
        {


            loadlvl += lvl;
            loadlvl += ".txt";
            needscore = lvl * 10;
            StreamReader sr = new StreamReader(loadlvl);
            I = sr.Read() - 48;
            sr.Read();
            J = sr.Read() - 48;
            sr.Read();
            stari = sr.Read() - 48;
            sr.Read();
            starj = sr.Read() - 48;
            sr.Read();
            for (int i = 0; i < I; i++)
                for (int j = 0; j < J; j++)
                {
                    sr.Read();
                    array[i, j] = (char)sr.Read();
                    if (j == J - 1) sr.Read();
                }
            array[stari, starj] = '*';

            while (true)
            {
                Paint();
                System.Threading.Thread.Sleep(100);
                ConsoleKeyInfo key = Console.ReadKey();
                if ((key.KeyChar == 'd') && (starj != J - 1))
                {
                    if (array[stari, starj + 1] != '+') MoveRight();
                }
                if ((key.KeyChar == 'a') && (starj != 0))
                {
                    if (array[stari, starj - 1] != '+') MoveLeft();
                }
                if ((key.KeyChar == 's') && (stari != I - 1))
                {
                    if (array[stari + 1, starj] != '+') MoveDown();
                }
                if ((key.KeyChar == 'w') && (stari != 0))
                {
                    if (array[stari - 1, starj] != '+') MoveUp();
                }
                if (key.KeyChar == 'e') break;
                if (score >= needscore)
                {
                    score = 0;
                    if (lvl == 5)
                    {
                        Console.Clear();
                        Console.WriteLine("Congratulations! You are winner!");
                        break;
                    }
                    loadlvl = loadlvl.Remove(7, 5);
                    lvl++;
                    loadlvl += lvl;
                    loadlvl += ".txt";
                    needscore = lvl * 10;
                    StreamReader sr1 = new StreamReader(loadlvl);
                    I = sr1.Read() - 48;
                    sr1.Read();
                    J = sr1.Read() - 48;
                    sr1.Read();
                    stari = sr1.Read() - 48;
                    sr1.Read();
                    starj = sr1.Read() - 48;
                    sr1.Read();
                    for (int i = 0; i < I; i++)
                        for (int j = 0; j < J; j++)
                        {
                            sr1.Read();
                            array[i, j] = (char)sr1.Read();
                            if (j == J - 1) sr1.Read();
                        }
                    array[stari, starj] = '*';
                }
            }
        }

static  void Paint()
        {
            Console.Clear();
            Console.WriteLine("SCORE: " + score);
            Console.WriteLine("NEED SCORE: " + needscore);
            for (int i = 0; i < I; i++)
                for (int j = 0; j < J; j++)
                {
                    Console.Write(array[i, j]);
                    if (j == J - 1) Console.WriteLine();
                }
        }

static  void MoveRight()
        {
            if (array[stari, starj + 1] != ' ') score += array[stari, starj + 1] - 48;
            array[stari, starj + 1] = '*';
            array[stari, starj] = ' ';
            starj++;
        }

static  void MoveLeft()
        {
            if (array[stari, starj - 1] != ' ') score += array[stari, starj - 1] - 48;
            array[stari, starj - 1] = '*';
            array[stari, starj] = ' ';
            starj--;
        }

static  void MoveUp()
        {
            if (array[stari - 1, starj] != ' ') score += array[stari - 1, starj] - 48;
            array[stari - 1, starj] = '*';
            array[stari, starj] = ' ';
            stari--;
        }

static  void MoveDown()
        {
            if (array[stari + 1, starj] != ' ') score += array[stari + 1, starj] - 48;
            array[stari + 1, starj] = '*';
            array[stari, starj] = ' ';
            stari++;
        }
    }
}