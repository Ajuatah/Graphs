using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Graphs
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Graph graph = new Graph(4);
            graph.AddEdge(0, 1);
            graph.AddEdge(0, 2);
            graph.AddEdge(1, 2);
            graph.AddEdge(2, 0);
            graph.AddEdge(2, 3);
            graph.AddEdge(3, 3);

            //print adjecency Matrix
            graph.PrintAdjecencyMatrix();

            Console.WriteLine("BFS traversal starting from vertex 1: ");
            graph.BFS(1);

            Console.WriteLine("DFS traversal starting from vertex 1: ");
            graph.DFS(1);

            Console.ReadLine(); 

        }
    }
    // Adjacency list representation
    class Graph
    {
        //total number of vertices 
        private int Vertex;
        //adjency list array for all vertices 
        private List<Int32>[] adjacency;

        //contructor 
        public Graph(int v1)
        {
            Vertex = v1;
            adjacency = new List<Int32>[v1];
            //instantiate adjacency list for all vertices 

            for (int i = 0; i < v1; i++)
            {
                adjacency[i] = new List<Int32>();
            }
        }

        //add edge for v -->w

        public void AddEdge(int v1, int w1)
        {
            adjacency[v1].Add(w1);
        }

        //BFS uses queue as a base 
        public void BFS(int s1)
        {
            bool[] visited = new bool[Vertex];

            //create  queue for BFS

            Queue<int> queue = new Queue<int>();
            visited[s1] = true;
            queue.Enqueue(s1);

            //loop through all nodes in queue
            while (queue.Count != 0)
            {
                //deque a vertex from queue and print it.
                s1 = queue.Dequeue();
                Console.Write("next ->" + s1);

                //get all adjecent vertices of s

                foreach (Int32 next in adjacency[s1])
                {
                    if (!visited[next])
                    {
                        visited[next] = true;
                        queue.Enqueue(next);
                    }
                }

            }
        }

        //DFS traversal 

        public void DFS(int s1)
        {
            bool[] visited = new bool[Vertex];


            //For DFS use stack

            Stack<int> stack = new Stack<int>();
            visited[s1] = true;
            stack.Push(s1);


            while (stack.Count != 0)
            {
                s1 = stack.Pop();
                Console.Write("next ->" + s1);
                foreach (int i in adjacency[s1])
                {
                    if (!visited[i])
                    {
                        visited[i] = true;
                        stack.Push(i);
                    }
                }
            }
        }


        public void PrintAdjecencyMatrix()
        {
            for(int i =0; i<Vertex; i++)
            {
                Console.Write(i + " :[");
                string s1 = "";
                foreach(var k in adjacency[i])
                {
                    s1 = s1 + (k + " , ");
                }

                s1 =s1.Substring(0, s1.Length - 1);
                s1 = s1 + "]";
                Console.Write(s1);
                Console.WriteLine();
            }
        }


    }
}
