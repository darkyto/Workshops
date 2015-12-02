namespace Example.GraphBfsDfs
{
    using System;
    using System.Collections.Generic;

    //Vertex
    public class Vertex
    {
        public Vertex(string label)
        {
            this.VertexLabel = label;
        }

        public string VertexLabel { get; private set; }

    }

    public class Edge
    {
        //Constructor
        public Edge(Vertex from, Vertex to, int weight)
        {
            this.FromVertex = from;
            this.ToVertex = to;
            this.Weight = weight;
        }
        //Property
        public Vertex FromVertex { get; private set; }
        public Vertex ToVertex { get; private set; }
        public int Weight { get; private set; }
    }

    public class Graph
    {
        private HashSet<Vertex> _vertexes;
        private Dictionary<Vertex, LinkedList<Edge>> _VertexEdgeMapping;

        private int totalWeight;

        public Graph(bool isDirect)
        {
            this.IsDirectGraph = isDirect;
            this._vertexes = new HashSet<Vertex>();
            this._VertexEdgeMapping = new Dictionary<Vertex, LinkedList<Edge>>();;
        }

        public bool IsDirectGraph { get; set; }

        public int TotalWeight { get { return this.totalWeight; } set { this.totalWeight = value; } }

        public bool AddVertex(Vertex vertex)
        {
            try
            {
                this._vertexes.Add(vertex);
                this._VertexEdgeMapping.Add(vertex, new LinkedList<Edge>());
                return true;
            }
            catch (Exception e)
            {
                Console.WriteLine("Add vertex failed! {0}", e.Message);
                return false;
            }
        }

        public bool AddEdge(Vertex from, Vertex to, int weight)
        {
            try
            {
                Edge newEdge = new Edge(from, to, weight);
                this._VertexEdgeMapping[from].AddLast(newEdge);
                if (IsDirectGraph == false)
                {
                    Edge backEdge = new Edge(to, from, weight);
                    this._VertexEdgeMapping[to].AddLast(backEdge);
                }
                return true;
            }
            catch (Exception e)
            {
                Console.WriteLine("Add edge failed! {0}", e.Message);
                return false;
            }
        }

        public bool BreadthFirstSearch(Vertex rootVertex)
        {
            Console.WriteLine("******* Breadth First Search  ********");
            const string white = "white";
            const string gray = "gray";
            const string black = "black";
            Dictionary<Vertex, string> color = new Dictionary<Vertex, string>();
            Dictionary<Vertex, Vertex> parent = new Dictionary<Vertex, Vertex>();

            foreach (Vertex vertex in this._vertexes)
            {
                color.Add(vertex, white);
                parent.Add(vertex, null);
            }

            color[rootVertex] = gray;

            Queue<Vertex> queue = new Queue<Vertex>();
            queue.Enqueue(rootVertex);

            while (queue.Count != 0)
            {
                Vertex temp = queue.Dequeue();
                foreach (Edge edge in _VertexEdgeMapping[temp])
                {
                    if (color[edge.ToVertex] == white)
                    {
                        color[edge.ToVertex] = gray;
                        parent[edge.ToVertex] = temp;
                        queue.Enqueue(edge.ToVertex);

                    }
                }
                color[temp] = black;
                Console.WriteLine("Vertex {0} has been found!", temp.VertexLabel);
            }

            return true;
        }

        public bool DepthSearchFirst()
        {
            Console.WriteLine("******* Depth First Search  ********");
            const string white = "white";

            Dictionary<Vertex, string> color = new Dictionary<Vertex, string>();
            Dictionary<Vertex, Vertex> parent = new Dictionary<Vertex, Vertex>();
            foreach (Vertex vertex in _vertexes)
            {
                color.Add(vertex, white);
                parent.Add(vertex, null);
            }

            foreach (Vertex vertex in _vertexes)
            {
                if (color[vertex] == white)
                {
                    DFS_Visit(vertex, color, parent);
                }
            }

            return true;
        }

        private bool DFS_Visit(Vertex vertex, Dictionary<Vertex, string> color, Dictionary<Vertex, Vertex> parent)
        {
            const string white = "white";
            const string gray = "gray";
            const string black = "black";

            color[vertex] = gray;
            foreach (Edge edge in this._VertexEdgeMapping[vertex])
            {
                if (color[edge.ToVertex] == white)
                {
                    parent[edge.ToVertex] = vertex;
                    DFS_Visit(edge.ToVertex, color, parent);
                }
                totalWeight += edge.Weight;
            }

            color[vertex] = black;
            Console.WriteLine("Vertex {0} has benn found!", vertex.VertexLabel);
            return true;
        }
    }

    public class Tester
    {
        public static void Main(string[] args)
        {
            // Direct Graph
            Graph G = new Graph(true);
            Vertex u = new Vertex("u");
            Vertex v = new Vertex("v");
            Vertex w = new Vertex("w");
            Vertex x = new Vertex("x");
            Vertex y = new Vertex("y");
            Vertex z = new Vertex("z");
            // Add vertexes
            G.AddVertex(u);
            G.AddVertex(v);
            G.AddVertex(w);
            G.AddVertex(x);
            G.AddVertex(y);
            G.AddVertex(z);
            // Add edges
            G.AddEdge(u, v, 3);
            G.AddEdge(u, x, 3);
            G.AddEdge(v, y, 3);
            G.AddEdge(w, y, 3);
            G.AddEdge(w, z, 3);
            G.AddEdge(x, v, 3);
            G.AddEdge(y, x, 3);
            G.AddEdge(z, z, 3);
            //Depth Search First
            G.DepthSearchFirst();
            Console.WriteLine(G.TotalWeight);


            //Undirect Graph
            Graph UG = new Graph(false);
            Vertex ur = new Vertex("r");
            Vertex us = new Vertex("s");
            Vertex ut = new Vertex("t");
            Vertex uu = new Vertex("u");
            Vertex uv = new Vertex("v");
            Vertex uw = new Vertex("w");
            Vertex ux = new Vertex("x");
            Vertex uy = new Vertex("y");

            // Add vertexes
            UG.AddVertex(ur);
            UG.AddVertex(us);
            UG.AddVertex(ut);
            UG.AddVertex(uu);
            UG.AddVertex(uv);
            UG.AddVertex(uw);
            UG.AddVertex(ux);
            UG.AddVertex(uy);
            // Add Edge
            UG.AddEdge(ur, uv, 3);
            UG.AddEdge(ur, us, 3);
            UG.AddEdge(us, uw, 3);
            UG.AddEdge(ut, uu, 3);
            UG.AddEdge(ut, uw, 3);
            UG.AddEdge(ut, ux, 3);
            UG.AddEdge(uu, ux, 3);
            UG.AddEdge(uu, uy, 3);
            UG.AddEdge(uw, ux, 3);
            UG.AddEdge(ux, uy, 3);

            //Breadth First Search
            UG.BreadthFirstSearch(us);
        }
    }


}
