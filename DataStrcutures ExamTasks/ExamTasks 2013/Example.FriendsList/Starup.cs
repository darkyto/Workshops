namespace Example.FriendsList
{
    using System;
    using System.Collections.Generic;

    public class Program
    {

        public class Person
        {
            private List<Person> friendsList;
            private bool hasParent;

            public Person(string name)
            {
                this.Name = name;
                this.friendsList = new List<Person>();
                this.HasParent = false;
            }

            public string Name { get; set; }

            public bool HasParent
            {
                get { return this.hasParent; }
                set { this.hasParent = value; }
            }

            public List<Person> Friends
            {
                get
                {
                    return this.friendsList;
                }
            }

            public void isFriendOf(Person person)
            {
                person.hasParent = true;
                this.friendsList.Add(person);
            }

            public override string ToString()
            {
                return this.Name;
            }
        }

        public class DepthFirstAlgorithm
        {
            private HashSet<string> visited;

            public DepthFirstAlgorithm()
            {
                this.visited = new HashSet<string>();
            }
            public Person BuildFriendGraph()
            {
                Person Aaron = new Person("Aaron");
                Person Betty = new Person("Betty");
                Person Brian = new Person("Brian");
                Aaron.isFriendOf(Betty);
                Aaron.isFriendOf(Brian);

                Person Catherine = new Person("Catherine");
                Person Carson = new Person("Carson");
                Person Darian = new Person("Darian");
                Person Derek = new Person("Derek");
                Betty.isFriendOf(Catherine);
                Betty.isFriendOf(Darian);
                Brian.isFriendOf(Carson);
                Brian.isFriendOf(Derek);

                return Aaron;
            }

            public Person Search(Person root, string nameToSearchFor)
            {
                if (nameToSearchFor == root.Name)
                    return root;

                Person personFound = null;
                for (int i = 0; i < root.Friends.Count; i++)
                {
                    personFound = Search(root.Friends[i], nameToSearchFor);
                    if (personFound != null)
                        break;
                }
                return personFound;
            }

            public void Traverse(Person root, int depth)
            {
                if (!visited.Contains(root.Name))
                {
                    visited.Add(root.Name);
                    depth++;
                }

                Console.WriteLine(new string(' ', depth * 3) + root.Name);
                for (int i = 0; i < root.Friends.Count; i++)
                {
                    Traverse(root.Friends[i], depth);
                }
            }
        }

        static void Main(string[] args)
        {
            DepthFirstAlgorithm dfs = new DepthFirstAlgorithm();
            Person root = dfs.BuildFriendGraph();
            Console.WriteLine("Traverse\n------");
            dfs.Traverse(root, 1);

            Console.WriteLine("\nSearch\n------");
            Person p = dfs.Search(root, "Catherine");
            Console.WriteLine(p == null ? "Person not found" : p.Name);
            p = dfs.Search(root, "Alex");
            Console.WriteLine(p == null ? "Person not found" : p.Name);
        }
    }
}