using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


namespace ConsoleApplication1
{
    class Program
    {
        static void Main(string[] args)
        {
            string[,] ticTacMatrix = { { " - 00", " - 01", " - 02" }, { " - 10", " - 11", " - 12" }, { " - 20", " - 21", " - 22" } };
            Console.WriteLine("WELECOME TO THE TIC TAC TOE GAME");
            Console.WriteLine("Following is the tic tac matrix with each cell having following format");
            Console.WriteLine("========================================================================");
            display(ticTacMatrix);
            Console.WriteLine("========================================================================");
            Console.WriteLine("Kindly enter the cell address and then the value to the cell i.e 'O' or 'X' whenever it's your turn");
            Console.WriteLine("The game starts by tossing a coin with 'O' on one face and 'X' on other face");
            Console.WriteLine("If you get 'O' you start else it's my turn");
            Console.WriteLine("========================================================================");

            
            Random rnd = new Random();

            char[] arr = {'O', 'X'};
            int win = 0;
            char compSymbol, playerSymbol, curSymbol = 'O';
            int  r = rnd.Next(arr.Count());
            string turn = arr[r] == 'O' ? "You get to start !!!" : "Oops..! I get to start"; 
            Console.WriteLine("You got '" + arr[r] + "'. " + turn);
            playerSymbol = arr[r];
            compSymbol = arr[arr.Length - r - 1];
            int i, j, count = 0;
            
            try
            {
                    
                while (win == 0 && count < 9)
                {
                    
                    if(playerSymbol == curSymbol)
                    {
                        Console.WriteLine("Please Enter your location where you want to place " + playerSymbol);
                        string loc = Console.ReadLine();
                        i = Int32.Parse(loc[0].ToString());
                        j = Int32.Parse(loc[1].ToString());
                        if(ticTacMatrix[i,j] == " - " + i.ToString() + j.ToString())
                                ticTacMatrix[i,j] = curSymbol.ToString() + "- " +  i.ToString() + j.ToString();
                        
                    }
                    else
                    {
                        int insertStatus = 0;
                        do
                        {
                            i = rnd.Next(0,3);
                            j = rnd.Next(0,3);
                            Console.WriteLine(" - " + i.ToString() + j.ToString());
                            if(ticTacMatrix[i,j] == " - " + i.ToString() + j.ToString()){
                                ticTacMatrix[i,j] = curSymbol.ToString() + "- " +  i.ToString() + j.ToString();
                                insertStatus = 1;
                            }

                        }while(insertStatus == 0);

                        //Console.WriteLine(num);
                    }
                            

                    display(ticTacMatrix);
                    count++;
                    if(count > 3)
                    {
                        
                        win = checkWinner(ticTacMatrix, i, j, curSymbol);
                        

                        if(win == 1 ){
                            if(curSymbol == playerSymbol)
                                Console.WriteLine("Congratulations !! You Won !!");
                            else
                                Console.WriteLine("Better luck next time");
                        }

                    }

                    curSymbol = changeCurSymbol(curSymbol);
                    
                }
            }
            catch (System.Exception)
            {
                
                Console.WriteLine("Oops..! Wrong input.. Game Terminated");
            }  
            Console.ReadKey();
        }

        static void display(string[,] ticTacMatrix)
        {
            for (int i = 0; i< 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    Console.Write(ticTacMatrix[i, j] + "\t");
                }
                Console.WriteLine("");

            }
        }

        static char changeCurSymbol(char curSymbol)
        {
            if(curSymbol == 'O')
                return 'X';
            return 'O';
        }
        
        static int checkWinner(string[,] ticTacMatrix, int i, int j, char curSymbol)
        {
            
            int flag = 0;
            for(int p = 0; p < 3; p++)
            {
                
                if(ticTacMatrix[i,p] != curSymbol.ToString() + "- " +  i.ToString() + p.ToString())
                    flag = 1;
            }
            if(flag == 0)
                return 1;

            flag = 0;
            for(int p = 0; p < 3; p++)
            {
                
                if(ticTacMatrix[p,j] != curSymbol.ToString() + "- " +  p.ToString() + j.ToString())
                    flag = 1;
            }
            
            if(flag == 0)
                return 1;
            flag = 0;
            for(int p = 0; p < 3; p++)
            {
                if(ticTacMatrix[p,p] != curSymbol.ToString() + "- " +  p.ToString() + p.ToString())
                    flag = 1;
            }
            if(flag == 0)
                return 1;

            flag = 0;
            for(int p = 0, q = 2; p < 3; p++, q--)
            {
                if(ticTacMatrix[p,q] != curSymbol.ToString() + "- " +  p.ToString() + q.ToString())
                    flag = 1;
            }
            if(flag == 0)
                return 1;

            
            return 0;
        }
    }
}
