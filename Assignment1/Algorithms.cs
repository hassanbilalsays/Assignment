using System;
using System.Collections.Generic;
using System.Text;

namespace Assignment1
{
    class Algorithms
    {
        public string from, to;
        public int strt_count = 0;
        public int end_count = 0;
        public int sum = 0;
        public List<Graph_Node> BFS(Node[,] arr, int strt_row, int strt_col, int goal_row, int goal_col, int rows, int cols)
        {
            int check = 0;
            List<Graph_Node> graph = new List<Graph_Node>();
            int x = 0, y = 0;
            Queue<Node> obj = new Queue<Node>();
            obj.Enqueue(arr[strt_row, strt_col]);
            arr[strt_row, strt_col].color = "Black";
            int i = 0;
            while (obj.Count != 0 && arr[goal_row, goal_col].color != "Black")
            {

                Node n = new Node();
                n = obj.Dequeue();
                Graph_Node _graph = new Graph_Node();
                _graph.parent = (n.x + "/" + n.y).ToString();
                if (n.x < rows - 1)
                {
                    String com = arr[n.x + 1, n.y].data.ToString();
                    String color = arr[n.x + 1, n.y].color.ToString();
                    if (com != "1" && color != "Black") //Up Condition
                    {
                        obj.Enqueue(arr[n.x + 1, n.y]);
                        _graph.cost[0] = 2;
                        x = n.x + 1;

                        _graph.arr[0] = (x + "/" + n.y).ToString();
                        arr[n.x + 1, n.y].color = "Black";
                        check = 1;
                    }
                }
                if (n.y < cols - 1)
                {
                    String com = arr[n.x, n.y + 1].data.ToString();
                    String color = arr[n.x, n.y + 1].color.ToString();
                    if (com != "1" && color != "Black") //Up Condition
                    {
                        obj.Enqueue(arr[n.x, n.y + 1]);
                        _graph.cost[1] = 2;
                        y = n.y + 1;
                        _graph.arr[1] = (n.x + "/" + y).ToString();
                        arr[n.x, n.y + 1].color = "Black";
                        check = 1;
                    }
                }
                if (n.x < rows - 1 && n.y < cols - 1)
                {
                    String com = arr[n.x + 1, n.y + 1].data.ToString();
                    String color = arr[n.x + 1, n.y + 1].color.ToString();
                    if (com != "1" && color != "Black") //Up Condition
                    {
                        obj.Enqueue(arr[n.x + 1, n.y + 1]);
                        _graph.cost[2] = 3;
                        x = n.x + 1;
                        y = n.y + 1;
                        _graph.arr[2] = (x + "/" + y).ToString();
                        arr[n.x + 1, n.y + 1].color = "Black";
                        check = 1;
                    }
                }
                if (check == 1)
                {
                    graph.Add(_graph);
                    check = 0;
                }

            }
            return graph;
        }

        public List<Graph_Node> DFS(Node[,] arr, int strt_row, int strt_col, int goal_row, int goal_col, int rows, int cols)
        {
            int check = 0;
            List<Graph_Node> graph = new List<Graph_Node>();
            int x = 0, y = 0;
            Stack<Node> obj = new Stack<Node>();
            obj.Push(arr[strt_row, strt_col]);
            arr[strt_row, strt_col].color = "Black";
            int i = 0;
            while (obj.Count != 0 && arr[goal_row, goal_col].color != "Black")
            {

                Node n = new Node();
                n = obj.Pop();
                Graph_Node _graph = new Graph_Node();
                if (n.x < rows - 1)
                {
                    String com = arr[n.x + 1, n.y].data.ToString();
                    String color = arr[n.x + 1, n.y].color.ToString();
                    if (com != "1" && color != "Black") //Up Condition
                    {

                        _graph.parent = (n.x + "/" + n.y).ToString();

                        obj.Push(arr[n.x + 1, n.y]);
                        _graph.cost[0] = 2;
                        x = n.x + 1;

                        _graph.arr[0] = (x + "/" + n.y).ToString();
                        arr[n.x + 1, n.y].color = "Black";
                        check = 1;
                    }
                }
                if (n.y < cols - 1)
                {
                    String com = arr[n.x, n.y + 1].data.ToString();
                    String color = arr[n.x, n.y + 1].color.ToString();
                    if (com != "1" && color != "Black") //Up Condition
                    {
                        _graph.parent = (n.x + "/" + n.y).ToString();

                        obj.Push(arr[n.x, n.y + 1]);
                        _graph.cost[1] = 2;
                        y = n.y + 1;
                        _graph.arr[1] = (n.x + "/" + y).ToString();
                        arr[n.x, n.y + 1].color = "Black";
                        //graph.Add(_graph);
                        check = 1;
                    }
                }
                if (n.x < rows - 1 && n.y < cols - 1)
                {
                    String com = arr[n.x + 1, n.y + 1].data.ToString();
                    String color = arr[n.x + 1, n.y + 1].color.ToString();
                    if (com != "1" && color != "Black") //Up Condition
                    {
                        _graph.parent = (n.x + "/" + n.y).ToString();

                        obj.Push(arr[n.x + 1, n.y + 1]);
                        _graph.cost[2] = 3;
                        x = n.x + 1;
                        y = n.y + 1;
                        _graph.arr[2] = (x + "/" + y).ToString();
                        arr[n.x + 1, n.y + 1].color = "Black";
                        
                        check = 1;
                    }
                }
                if (check == 1)
                {
                    graph.Add(_graph);
                    check = 0;
                }


            }
            return graph;
        }

        public List<Graph_Node> Uniform_Cost_Search(Node[,] arr, int strt_row, int strt_col, int goal_row, int goal_col, int rows, int cols)
        {
            int check = 0;
            int cost_ri8 = 0;
            int cost_up = 0;
            int cost_diagonal = 0;
            List<Graph_Node> graph = new List<Graph_Node>();
            int x = 0, y = 0;
            Priority_Queue obj = new Priority_Queue();
           
            arr[strt_row, strt_col].cost = 0;
            obj.Enqueue(arr[strt_row, strt_col]);
            arr[strt_row, strt_col].color = "Black";
            int i = 0, j = 0, k = 0;
            Graph_Node _graph = new Graph_Node();
            while (obj.count != 0 && arr[goal_row, goal_col].color != "Black")
            {

                Node n = new Node();
                n = (Node)obj.Dequeue();
                _graph = new Graph_Node();
                if (n.x < rows - 1)
                {
                    String com = arr[n.x + 1, n.y].data.ToString();
                    String color = arr[n.x + 1, n.y].color.ToString();
                    if (com != "1" && color != "Black") //Up Condition
                    {
                        _graph.parent = (n.x + "/" + n.y).ToString();

                        arr[n.x + 1, n.y].cost = arr[n.x, n.y].cost + 2;
                        obj.Enqueue(arr[n.x + 1, n.y]);
                        _graph.cost[0] = arr[n.x + 1, n.y].cost;
                        x = n.x + 1;

                        _graph.arr[0] = (x + "/" + n.y).ToString();
                        arr[n.x + 1, n.y].color = "Black";
                        check = 1;
                    }
                }
                if (n.y < cols - 1)
                {
                    String com = arr[n.x, n.y + 1].data.ToString();
                    String color = arr[n.x, n.y + 1].color.ToString();
                    if (com != "1" && color != "Black") //Up Condition
                    {
                        _graph.parent = (n.x + "/" + n.y).ToString();


                        arr[n.x, n.y + 1].cost = arr[n.x, n.y].cost + 2;
                        obj.Enqueue(arr[n.x, n.y + 1]);
                        _graph.cost[1] = arr[n.x, n.y + 1].cost;

                        y = n.y + 1;
                        _graph.arr[1] = (n.x + "/" + y).ToString();
                        arr[n.x, n.y + 1].color = "Black";
                        check = 1;
                    }
                }
                if (n.x < rows - 1 && n.y < cols - 1)
                {
                    String com = arr[n.x + 1, n.y + 1].data.ToString();
                    String color = arr[n.x + 1, n.y + 1].color.ToString();
                    if (com != "1" && color != "Black") //Up Condition
                    {
                        _graph.parent = (n.x + "/" + n.y).ToString();

                        arr[n.x + 1, n.y + 1].cost = arr[n.x, n.y].cost + 3;
                        obj.Enqueue(arr[n.x + 1, n.y + 1]);
                        _graph.cost[2] = arr[n.x + 1, n.y + 1].cost;
                        x = n.x + 1;
                        y = n.y + 1;
                        _graph.arr[2] = (x + "/" + y).ToString();
                        arr[n.x + 1, n.y + 1].color = "Black";
                        check = 1;
                    }
                }
                if (check == 1)
                {
                    graph.Add(_graph);
                    check = 0;
                }

                i = 1;

            }
            return graph;
        }


        public List<Graph_Node> DLS(Node[,] arr, int strt_row, int strt_col, int goal_row, int goal_col, int rows, int cols, int depth)
        {
            int check = 0;
            List<Graph_Node> graph = new List<Graph_Node>();
            int x = 0, y = 0;
            Stack<Node> obj = new Stack<Node>();
            obj.Push(arr[strt_row, strt_col]);
            arr[strt_row, strt_col].color = "Black";

         
            while (obj.Count != 0 && arr[goal_row, goal_col].color != "Black")
            {

                if (depth >= 0)
                {
                    
                    Node n = new Node();
                    n = obj.Pop();
                    Graph_Node _graph = new Graph_Node();
                    if (n.x < rows - 1)
                    {
                        String com = arr[n.x + 1, n.y].data.ToString();
                        String color = arr[n.x + 1, n.y].color.ToString();
                        if (com != "1" && color != "Black") //Up Condition
                        {

                            _graph.parent = (n.x + "/" + n.y).ToString();

                            obj.Push(arr[n.x + 1, n.y]);
                            _graph.cost[0] = 2;
                            x = n.x + 1;

                            _graph.arr[0] = (x + "/" + n.y).ToString();
                            arr[n.x + 1, n.y].color = "Black";
                            check = 1;
                        }
                    }
                    if (n.y < cols - 1)
                    {
                        String com = arr[n.x, n.y + 1].data.ToString();
                        String color = arr[n.x, n.y + 1].color.ToString();
                        if (com != "1" && color != "Black") //Up Condition
                        {
                            _graph.parent = (n.x + "/" + n.y).ToString();

                            obj.Push(arr[n.x, n.y + 1]);
                            _graph.cost[1] = 2;
                            y = n.y + 1;
                            _graph.arr[1] = (n.x + "/" + y).ToString();
                            arr[n.x, n.y + 1].color = "Black";
                           
                            check = 1;
                        }
                    }
                    if (n.x < rows - 1 && n.y < cols - 1)
                    {
                        String com = arr[n.x + 1, n.y + 1].data.ToString();
                        String color = arr[n.x + 1, n.y + 1].color.ToString();
                        if (com != "1" && color != "Black") //Up Condition
                        {
                            _graph.parent = (n.x + "/" + n.y).ToString();

                            obj.Push(arr[n.x + 1, n.y + 1]);
                            _graph.cost[2] = 3;
                            x = n.x + 1;
                            y = n.y + 1;
                            _graph.arr[2] = (x + "/" + y).ToString();
                            arr[n.x + 1, n.y + 1].color = "Black";
                      
                            check = 1;
                        }
                    }
                    if (check == 1)
                    {
                        graph.Add(_graph);
                        check = 0;
                    }

                }
                else
                {
                    break;
                }
                depth--;
            }
            return graph;
        }

        public List<Graph_Node> IDS(Node[,] arr, int strt_row, int strt_col, int goal_row, int goal_col, int rows, int cols, int depth)
        {
            List<Graph_Node> graph = new List<Graph_Node>();
            int check = 0;

            int x = 0, y = 0;
            Stack<Node> obj = new Stack<Node>();
            obj.Push(arr[strt_row, strt_col]);
            arr[strt_row, strt_col].color = "Black";
            int i = 0;
            while (obj.Count != 0 && arr[goal_row, goal_col].color != "Black")
            {
                if (depth >= 0)
                {
                    Node n = new Node();
                    n = obj.Pop();
                    Graph_Node _graph = new Graph_Node();
                    if (n.x < rows - 1)
                    {
                        String com = arr[n.x + 1, n.y].data.ToString();
                        String color = arr[n.x + 1, n.y].color.ToString();
                        if (com != "1" && color != "Black") //Up Condition
                        {

                            _graph.parent = (n.x + "/" + n.y).ToString();

                            obj.Push(arr[n.x + 1, n.y]);
                            _graph.cost[0] = 2;
                            x = n.x + 1;

                            _graph.arr[0] = (x + "/" + n.y).ToString();
                            arr[n.x + 1, n.y].color = "Black";
                            check = 1;
                        }
                    }
                    if (n.y < cols - 1)
                    {
                        String com = arr[n.x, n.y + 1].data.ToString();
                        String color = arr[n.x, n.y + 1].color.ToString();
                        if (com != "1" && color != "Black") //Right Condition
                        {
                            _graph.parent = (n.x + "/" + n.y).ToString();

                            obj.Push(arr[n.x, n.y + 1]);
                            _graph.cost[1] = 2;
                            y = n.y + 1;
                            _graph.arr[1] = (n.x + "/" + y).ToString();
                            arr[n.x, n.y + 1].color = "Black";
                            //graph.Add(_graph);
                            check = 1;
                        }
                    }
                    if (n.x < rows - 1 && n.y < cols - 1)
                    {
                        String com = arr[n.x + 1, n.y + 1].data.ToString();
                        String color = arr[n.x + 1, n.y + 1].color.ToString();
                        if (com != "1" && color != "Black") //Diagonal Condition
                        {
                            _graph.parent = (n.x + "/" + n.y).ToString();

                            obj.Push(arr[n.x + 1, n.y + 1]);
                            _graph.cost[2] = 3;
                            x = n.x + 1;
                            y = n.y + 1;
                            _graph.arr[2] = (x + "/" + y).ToString();
                            arr[n.x + 1, n.y + 1].color = "Black";
                            //graph.Add(_graph);
                            check = 1;
                        }
                    }
                    if (check == 1)
                    {
                        graph.Add(_graph);
                        check = 0;
                    }
                }
                else
                {
                    break;
                }
                depth--;
            }

            return graph;
        }

        public List<Graph_Node> Bidirectional(Node[,] arr, int strt_row, int strt_col, int end_row, int end_col, int rows, int cols)
        {
            Queue<Node> queue_Strt = new Queue<Node>();
            Queue<Node> queue_goal = new Queue<Node>();

            List<Graph_Node> strt_path = new List<Graph_Node>();
            List<Graph_Node> end_path = new List<Graph_Node>();

            queue_Strt.Enqueue(arr[strt_row, strt_col]);
            arr[strt_row, strt_col].color = "Black";

            queue_goal.Enqueue(arr[end_row, end_col]);
            arr[end_row, end_col].color = "Black";
            int check = 0, _check = 0;
            int meeting_point = 0, _meeting_point = 0;
            while (queue_Strt.Count != 0 && queue_goal.Count != 0)
            {
                Graph_Node graph = new Graph_Node();
                Node strt_node = queue_Strt.Dequeue();
                Node end_node = queue_goal.Dequeue();


                graph.parent = (strt_node.x + "/" + strt_node.y).ToString();
                if (strt_node.x < rows - 1)
                {
                    String data = arr[strt_node.x + 1, strt_node.y].data.ToString();
                    String color = arr[strt_node.x + 1, strt_node.y].color;
                    if (arr[strt_node.x + 1, strt_node.y].value == 2)
                    {
                        sum = 2;
                        meeting_point = 1;
                        from = graph.parent;
                        to = (strt_node.x + 1 + "/" + strt_node.y).ToString();
                    }
                    if (data == "0" && color != "Black")
                    {
                        queue_Strt.Enqueue(arr[strt_node.x + 1, strt_node.y]);
                        arr[strt_node.x + 1, strt_node.y].value = 1;
                        graph.cost[0] = 2;
                        int x = strt_node.x + 1;

                        graph.arr[0] = (x + "/" + strt_node.y).ToString();
                        arr[strt_node.x + 1, strt_node.y].color = "Black";
                        check = 1;
                    }

                }

                if (strt_node.y < cols - 1)
                {
                    String data = arr[strt_node.x, strt_node.y + 1].data.ToString();
                    String color = arr[strt_node.x, strt_node.y + 1].color;

                    if (arr[strt_node.x, strt_node.y + 1].value == 2)
                    {
                        sum = 2;
                        meeting_point = 1;
                        from = graph.parent;
                        to = (strt_node.x + "/" + strt_node.y + 1).ToString();
                    }

                    if (data == "0" && color != "Black")
                    {
                        queue_Strt.Enqueue(arr[strt_node.x, strt_node.y + 1]);
                        arr[strt_node.x, strt_node.y + 1].value = 1;
                        graph.cost[1] = 2;
                        int y = strt_node.y + 1;

                        graph.arr[1] = (strt_node.x + "/" + y).ToString();
                        arr[strt_node.x, strt_node.y + 1].color = "Black";
                        check = 1;
                    }

                }

                if (strt_node.x < rows - 1 && strt_node.y < cols - 1)
                {
                    String data = arr[strt_node.x + 1, strt_node.y + 1].data.ToString();
                    String color = arr[strt_node.x + 1, strt_node.y + 1].color;

                    if (arr[strt_node.x + 1, strt_node.y + 1].value == 2)
                    {
                        sum = 3;
                        meeting_point = 1;
                        from = graph.parent;
                        to = (strt_node.x + 1 + "/" + (strt_node.y + 1)).ToString();
                    }

                    if (data == "0" && color != "Black")
                    {
                        queue_Strt.Enqueue(arr[strt_node.x + 1, strt_node.y + 1]);
                        arr[strt_node.x + 1, strt_node.y + 1].value = 1;
                        graph.cost[2] = 3;
                        int y = strt_node.y + 1;
                        int x = strt_node.x + 1;
                        graph.arr[2] = (x + "/" + y).ToString();
                        arr[strt_node.x + 1, strt_node.y + 1].color = "Black";
                        check = 1;
                    }

                }
                strt_path.Add(graph);
                if (meeting_point == 1)
                {
                    break;
                }
                //////////////////////////////////////////////////////////////////////////////////
                Graph_Node _graph = new Graph_Node();
                _graph.parent = (end_node.x + "/" + end_node.y).ToString();
                if (end_node.x > 0)
                {
                    String data = arr[end_node.x - 1, end_node.y].data.ToString();
                    String color = arr[end_node.x - 1, end_node.y].color;
                    if (arr[end_node.x - 1, end_node.y].value == 1)
                    {
                        sum = 2;
                        _meeting_point = 1;
                        to = _graph.parent;
                        from = ((end_node.x - 1) + "/" + end_node.y).ToString();
                    }
                    if (data == "0" && color != "Black")
                    {
                        queue_goal.Enqueue(arr[end_node.x - 1, end_node.y]);
                        arr[end_node.x - 1, end_node.y].value = 2;
                        _graph.cost[0] = 2;
                        int x = end_node.x - 1;

                        _graph.arr[0] = (x + "/" + end_node.y).ToString();
                        arr[end_node.x - 1, end_node.y].color = "Black";
                        _check = 1;
                    }

                }

                if (end_node.y > 0)
                {
                    String data = arr[end_node.x, end_node.y - 1].data.ToString();
                    String color = arr[end_node.x, end_node.y - 1].color;

                    if (arr[end_node.x, end_node.y - 1].value == 1)
                    {
                        sum = 2;
                        _meeting_point = 1;
                        to = _graph.parent;
                        from = (end_node.x + "/" + (end_node.y - 1)).ToString();
                    }

                    if (data == "0" && color != "Black")
                    {
                        queue_goal.Enqueue(arr[end_node.x, end_node.y - 1]);
                        arr[end_node.x, end_node.y - 1].value = 2;
                        _graph.cost[1] = 2;
                        int y = end_node.y - 1;

                        _graph.arr[1] = (end_node.x + "/" + y).ToString();
                        arr[end_node.x, end_node.y - 1].color = "Black";
                        _check = 1;
                    }

                }

                if (end_node.x > 0 && end_node.y > 0)
                {
                    String data = arr[end_node.x - 1, end_node.y - 1].data.ToString();
                    String color = arr[end_node.x - 1, end_node.y - 1].color;

                    if (arr[end_node.x - 1, end_node.y - 1].value == 1)
                    {
                        sum = 3;
                        _meeting_point = 1;
                        to = _graph.parent;
                        from = ((end_node.x - 1) + "/" + (end_node.y - 1)).ToString();
                    }

                    if (data == "0" && color != "Black")
                    {
                        queue_goal.Enqueue(arr[end_node.x - 1, end_node.y - 1]);
                        arr[end_node.x - 1, end_node.y - 1].value = 2;
                        _graph.cost[2] = 3;
                        int y = end_node.y - 1;
                        int x = end_node.x - 1;
                        _graph.arr[2] = (x + "/" + y).ToString();
                        arr[end_node.x - 1, end_node.y - 1].color = "Black";
                        _check = 1;
                    }

                }
                end_path.Add(_graph);
                if (_meeting_point == 1)
                {
                    break;
                }

            }
            strt_count = strt_path.Count;
            end_count = end_path.Count;
            for (int i = 0; i < end_path.Count; i++)
            {
                strt_path.Add(end_path[i]);
            }
            return strt_path;
        }
    }
}
