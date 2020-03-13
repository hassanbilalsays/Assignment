using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Assignment1
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] splitResult;
            StringBuilder tempArray = new StringBuilder();
            string[] fileText = System.IO.File.ReadAllLines("C:\\Users\\Hassan Bilal\\source\\repos\\Assignment1\\Assignment1\\grid.txt");
            int cols = 0, rows = 0, var1 = 0, var2 = 0, var3 = 0, var4 = 0;
            for (int i = 0; i < fileText.Length; i++)
            {
                splitResult = fileText[i].Split(new char[] { '\t', '\n' });
                if (i == 0)
                {
                    for (int j = 0; j < splitResult.Length; j++)
                    {
                        if (j == 0)
                        {
                            cols = Convert.ToInt32(splitResult[j]);
                         
                        }
                        else
                        {
                            rows = Convert.ToInt32(splitResult[j]);
                       
                        }
                    }
                }
                else if (i == 1)
                {
                    for (int j = 0; j < splitResult.Length; j++)
                    {
                        if (j == 0)
                        {
                            var1 = Convert.ToInt32(splitResult[j]);
                          
                        }
                        else
                        {
                            var2 = Convert.ToInt32(splitResult[j]);
                       
                        }
                    }
                }
                else if (i == 2)
                {
                    for (int j = 0; j < splitResult.Length; j++)
                    {
                        if (j == 0)
                        {

                            var3 = Convert.ToInt32(splitResult[j]);
                        
                        }
                        else
                        {
                            var4 = Convert.ToInt32(splitResult[j]);
                          
                        }
                    }
                }
                else {
                    for (int j = 0; j < splitResult.Length; j++)
                    {
                        tempArray.Append(splitResult[j].ToString());
                       
                    }
                }
            }
            Node[,] node = new Node[rows, cols];
            Node[,] BFS = new Node[rows, cols];
            Node[,] DFS = new Node[rows, cols];
            Node[,] UCS = new Node[rows, cols];
            Node[,] DLS = new Node[rows, cols];
            Node[,] IDP = new Node[rows, cols];
            Node[,] IDS1 = new Node[rows, cols];
            Node[,] Bidirectional = new Node[rows, cols];
            int Num = 0;
            for (int i = rows - 1; i >= 0; i--)
            {
                for (int j = 0; j < cols; j++)
                {
                    node[i, j] = new Node();
                    node[i, j].data.Append(tempArray[Num].ToString());
                    node[i, j].color = "White";
                    node[i, j].x = i;
                    node[i, j].y = j;
                    BFS[i, j] = new Node();
                    BFS[i, j].data.Append(tempArray[Num].ToString());
                    BFS[i, j].color = "White";
                    BFS[i, j].x = i;
                    BFS[i, j].y = j;
                    DFS[i, j] = new Node();
                    DFS[i, j].data.Append(tempArray[Num].ToString());
                    DFS[i, j].color = "White";
                    DFS[i, j].x = i;
                    DFS[i, j].y = j;
                    UCS[i, j] = new Node();
                    UCS[i, j].data.Append(tempArray[Num].ToString());
                    UCS[i, j].color = "White";
                    UCS[i, j].x = i;
                    UCS[i, j].y = j;
                    DLS[i, j] = new Node();
                    DLS[i, j].data.Append(tempArray[Num].ToString());
                    DLS[i, j].color = "White";
                    DLS[i, j].x = i;
                    DLS[i, j].y = j;
                    DLS[i, j] = new Node();
                    DLS[i, j].data.Append(tempArray[Num].ToString());
                    DLS[i, j].color = "White";
                    DLS[i, j].x = i;
                    DLS[i, j].y = j;
                    IDP[i, j] = new Node();
                    IDP[i, j].data.Append(tempArray[Num].ToString());
                    IDP[i, j].color = "White";
                    IDP[i, j].x = i;
                    IDP[i, j].y = j;
                    IDS1[i, j] = new Node();
                    IDS1[i, j].data.Append(tempArray[Num].ToString());
                    IDS1[i, j].color = "White";
                    IDS1[i, j].x = i;
                    IDS1[i, j].y = j;
                    Bidirectional[i, j] = new Node();
                    Bidirectional[i, j].data.Append(tempArray[Num].ToString());
                    Bidirectional[i, j].color = "White";
                    Bidirectional[i, j].x = i;
                    Bidirectional[i, j].y = j;
                    Num++;
                }
            }
            Console.WriteLine(cols + "\t" + rows + "\n" + var1 + "\t" + var2 + "\n" + var3 + "\t" + var4 + "\n");
            for (int i = rows - 1; i >= 0; i--)
            {
                for (int j = 0; j < cols; j++)
                {
                    if (j == cols)
                    {
                        Console.Write(node[i, j].data.ToString());

                    }
                    else
                    {
                        Console.Write(node[i, j].data.ToString() + '\t');
                    }
                }
               
            }
            Algorithms algo = new Algorithms();
            Console.Clear();



            Console.WriteLine("Breath First Search!!!");
            List<Graph_Node> list = algo.BFS(BFS, var2, var1, var4, var3, rows, cols);
            String goal_node = (var4 + "/" + var3).ToString();
            Console.WriteLine("Length: {0}", list.Count);
            String[] a = list[list.Count - 1].arr;
            Display(list, BFS, a, goal_node, cols, rows, var1, var2, var3, var4);


            Console.Clear();
            Console.WriteLine("Depth First Search!!!");
            list = algo.DFS(DFS, var2, var1, var4, var3, rows, cols);
            goal_node = (var4 + "/" + var3).ToString();
            Console.WriteLine("Length: {0}", list.Count);
            a = list[list.Count - 1].arr;
            Display(list, DFS, a, goal_node, cols, rows, var1, var2, var3, var4);


            Console.Clear();
            Console.WriteLine("Uniform Cost Search!!!");
            List<Graph_Node> list1 = algo.Uniform_Cost_Search(UCS, var2, var1, var4, var3, rows, cols);
            goal_node = (var4 + "/" + var3).ToString();
            Console.WriteLine("Length: {0}", list1.Count);
            a = list1[list1.Count - 1].arr;
            Display_UCS(list1, UCS, a, goal_node, cols, rows, var1, var2, var3, var4);


            Console.Clear();
            Console.WriteLine("Depth Limited Search!!!");
            list = algo.DLS(DLS, var2, var1, var4, var3, rows, cols, 13);
            goal_node = (var4 + "/" + var3).ToString();
            Console.WriteLine("Length: {0}", list.Count);
            a = list[list.Count - 1].arr;
            Display(list, DLS, a, goal_node, cols, rows, var1, var2, var3, var4);

            Console.Clear();
            Console.WriteLine("Iterative Deepening Search!!!");
            int limit_iteration = 0;
            list = algo.DLS(IDP, var2, var1, var4, var3, rows, cols, limit_iteration);
            String[] _child = list[list.Count - 1].arr;
            String parent = list[list.Count - 1].parent;
            String[] _parent = parent.Split('/');
            goal_node = (var4 + "/" + var3).ToString();
            while (_child[0] != goal_node && _child[1] != goal_node && _child[2] != goal_node)
            {
                for (int i = 0; i < rows; i++)
                {
                    for (int j = 0; j < cols; j++)
                    {
                        IDP[i, j].data = IDS1[i, j].data;
                        IDP[i, j].color = "White";
                        IDP[i, j].cost = 0;
                    }
                }
                limit_iteration++;
                list = algo.DLS(IDP, var2, var1, var4, var3, rows, cols, limit_iteration);
                _child = list[list.Count - 1].arr;
                parent = list[list.Count - 1].parent;
                _parent = parent.Split('/');
            }
            goal_node = (var4 + "/" + var3).ToString();
            Console.WriteLine("Length: {0}", list.Count);
            a = list[list.Count - 1].arr;
            Display(list, IDP, a, goal_node, cols, rows, var1, var2, var3, var4);
            Console.Clear();
            Console.WriteLine("Bidirectional!!!");
            list = algo.Bidirectional(Bidirectional, var2, var1, var4, var3, rows, cols);
            goal_node = (var4 + "/" + var3).ToString();
            Console.WriteLine("Length: {0}", list.Count);
            a = list[list.Count - 1].arr;
            BiDirectional_Display(list, Bidirectional, a, cols, rows, var1, var2, var3, var4, algo);

        }
        static void Display(List<Graph_Node> list, Node[,] arry, String[] a, String goal_node, int Cols, int Rows, int var1, int var2, int var3, int var4)
        {
            int cost_sum = 0;
            int count = 0;
            for (int i = list.Count - 1; i >= 0; i--)
            {
                a = list[i].arr;
                for (int j = 0; j < a.Length; j++)
                {
                    if (a[j] == goal_node)
                    {
                        String[] index = goal_node.Split('/');
                        arry[Convert.ToInt32(index[0]), Convert.ToInt32(index[1])].data.Replace('0', 'X');
                        index = list[i].parent.Split('/');
                        arry[Convert.ToInt32(index[0]), Convert.ToInt32(index[1])].data.Replace('0', 'X');
                        goal_node = list[i].parent;
                        cost_sum += list[i].cost[j];
                        count = 1;
                        break;
                    }
                }
            }
            if (count == 1)
            {
                Console.WriteLine("Total Cost: " + cost_sum);
                Console.WriteLine(Cols + "\t" + Rows + "\n" + var1 + "\t" + var2 + "\n" + var3 + "\t" + var4 + "\n");
                for (int i = Rows - 1; i >= 0; i--)
                {
                    for (int j = 0; j < Cols; j++)
                    {
                        if (j == Cols)
                        {
                            Console.Write(arry[i, j].data.ToString());
                        }
                        else
                        {
                            Console.Write(arry[i, j].data.ToString() + '\t');
                        }
                    }
                    Console.WriteLine();
                }
            }
            else
            {
                Console.WriteLine("Path Not Exist!!!");
            }
            Console.ReadKey();
        }

        static void Display_UCS(List<Graph_Node> list, Node[,] arry, String[] a, String goal_node, int Cols, int Rows, int var1, int var2, int var3, int var4)
        {
            int cost_sum = 0;
            int count = 0;
            for (int i = list.Count - 1; i >= 0; i--)
            {
                a = list[i].arr;
                for (int j = 0; j < a.Length; j++)
                {
                    if (a[j] == goal_node)
                    {
                        String[] index = goal_node.Split('/');
                        arry[Convert.ToInt32(index[0]), Convert.ToInt32(index[1])].data.Replace('0', 'X');
                        index = list[i].parent.Split('/');
                        arry[Convert.ToInt32(index[0]), Convert.ToInt32(index[1])].data.Replace('0', 'X');
                        goal_node = list[i].parent;
                        if (i == list.Count - 1)
                        {
                            cost_sum = list[i].cost[j];
                        }
                        count = 1;
                        break;
                    }
                }
            }
            if (count == 1)
            {
                Console.WriteLine("Total Cost: " + cost_sum);
                Console.WriteLine(Cols + "\t" + Rows + "\n" + var1 + "\t" + var2 + "\n" + var3 + "\t" + var4 + "\n");
                for (int i = Rows - 1; i >= 0; i--)
                {
                    for (int j = 0; j < Cols; j++)
                    {
                        if (j == Cols)
                        {
                            Console.Write(arry[i, j].data.ToString());
                        }
                        else
                        {
                            Console.Write(arry[i, j].data.ToString() + '\t');
                        }
                    }
                    Console.WriteLine();
                }
            }
            else
            {
                Console.WriteLine("Path Not Exist!!!");
            }
            Console.ReadKey();
        }

        static void BiDirectional_Display(List<Graph_Node> list, Node[,] arry, String[] a, int Cols, int Rows, int var1, int var2, int var3, int var4, Algorithms algo)
        {
            int cost_sum = 0;
            int count = 0, count1 = 0;
            for (int i = algo.strt_count - 1; i >= 0; i--)
            {
                a = list[i].arr;
                for (int j = 0; j < a.Length; j++)
                {
                    if (a[j] == algo.from)
                    {
                        String[] index = algo.from.Split('/');
                        arry[Convert.ToInt32(index[0]), Convert.ToInt32(index[1])].data.Replace('0', 'X');
                        index = list[i].parent.Split('/');
                        arry[Convert.ToInt32(index[0]), Convert.ToInt32(index[1])].data.Replace('0', 'X');
                        algo.from = list[i].parent;
                        cost_sum += list[i].cost[j];
                        count = 1;
                        break;
                    }
                }
            }

            for (int i = list.Count - 1; i >= 0; i--)
            {
                a = list[i].arr;
                for (int j = 0; j < a.Length; j++)
                {
                    if (a[j] == algo.to)
                    {
                        String[] index = algo.to.Split('/');
                        arry[Convert.ToInt32(index[0]), Convert.ToInt32(index[1])].data.Replace('0', 'X');
                        index = list[i].parent.Split('/');
                        arry[Convert.ToInt32(index[0]), Convert.ToInt32(index[1])].data.Replace('0', 'X');
                        algo.to = list[i].parent;
                        cost_sum += list[i].cost[j];
                        count1 = 1;
                        break;
                    }
                }
            }
            if (count == 1 && count1 == 1)
            {
                Console.WriteLine("Total Cost: " + (cost_sum + algo.sum));
                Console.WriteLine(Cols + "\t" + Rows + "\n" + var1 + "\t" + var2 + "\n" + var3 + "\t" + var4 + "\n");
                for (int i = Rows - 1; i >= 0; i--)
                {
                    for (int j = 0; j < Cols; j++)
                    {
                        if (j == Cols)
                        {
                            Console.Write(arry[i, j].data.ToString());
                        }
                        else
                        {
                            Console.Write(arry[i, j].data.ToString() + '\t');
                        }
                    }
                    Console.WriteLine();
                }
            }
            else
            {
                Console.WriteLine("Path Not Exist!!!");
            }
            Console.ReadKey();
        }




    }
    }

