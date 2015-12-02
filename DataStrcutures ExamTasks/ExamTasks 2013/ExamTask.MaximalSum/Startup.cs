namespace ExamTask.MaximalPath
{
    using System;
    using System.Collections.Generic;

    public class Startup
    {
        public static long maxSum = 0;
        public static long totalSum = 0;
        public static HashSet<Node> usedNodes = new HashSet<Node>();
        public static HashSet<long> visited = new HashSet<long>();

        public static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            Dictionary<int, Node> nodes = new Dictionary<int, Node>();

            int maxNode = 0;

            for (int i = 0; i < n - 1; i++)
            {
                string connection = Console.ReadLine();

                string[] separatedConnection = connection.Split(new char[] { '(', ')', '-', '<' }, StringSplitOptions.RemoveEmptyEntries);

                int parent = int.Parse(separatedConnection[0]);
                int child = int.Parse(separatedConnection[1]);

                Node parentNode = new Node(parent);
                Node childNode = new Node(child);

                if (nodes.ContainsKey(parent))
                {
                    parentNode = nodes[parent];
                }
                else
                {
                    parentNode = new Node(parent);
                    nodes.Add(parent, parentNode);
                }

                if (nodes.ContainsKey(child))
                {
                    childNode = nodes[child];
                }
                else
                {
                    childNode = new Node(child);
                    nodes.Add(child, childNode);
                }

                parentNode.AddChild(childNode);
                childNode.AddChild(parentNode);

                if (child > maxNode)
                {
                    maxNode = child;
                }
                if (parent > maxNode)
                {
                    maxNode = parent;
                }
            }

            foreach (var node in nodes)
            {  
                if (node.Value.NumberOfChildren == 1)
                {
                    usedNodes.Clear();
                    DFS(node.Value, 0); // uses the static maxSum

                    usedNodes.Clear(); // clear the visited nodes
                    DFSTotalSum(node.Value, 1); // uses the static totalSum
                }
            }

            Console.WriteLine(maxSum);
            // Console.WriteLine(totalSum);
        }

        public static void DFS(Node node, long currentSum)
        {
            currentSum += node.Value;
            usedNodes.Add(node);

            for (int i = 0; i < node.NumberOfChildren; i++)
            {
                if (usedNodes.Contains(node.GetNode(i)))
                {
                    continue;
                }

                DFS(node.GetNode(i), currentSum);
            }

            // if the current node has one child only (i.e it only 'sees' its parent in this double-direction tree)
            // and if curr > max
            if (node.NumberOfChildren == 1 && currentSum > maxSum)
            {
                maxSum = currentSum;
            }
        }

        public static void DFSTotalSum(Node node, int depth)
        {
            if (!visited.Contains(node.Value))
            {
                visited.Add(node.Value);
                totalSum += node.Value;
                depth++; // just for visual printing with depth outlining
                // Console.WriteLine(new string(' ', depth * 2) + node.Value);
            }
            usedNodes.Add(node);


            for (int i = 0; i < node.NumberOfChildren; i++)
            {

                if (usedNodes.Contains(node.GetNode(i)))
                {
                    continue;
                }

                DFSTotalSum(node.GetNode(i), depth);
            }
        }

        public class Node
        {
            private long value;
            private List<Node> children;
            private bool hasParent;

            public Node(long value)
            {
                this.value = value;
                this.children = new List<Node>();
            }

            public void AddChild(Node child)
            {
                child.hasParent = true;
                this.children.Add(child);
            }

            public long Value
            {
                get { return this.value; }
            }

            public int NumberOfChildren
            {
                get
                {
                    return this.children.Count;
                }
            }

            public Node GetNode(int index)
            {
                return this.children[index];
            }
        }
    }
}
