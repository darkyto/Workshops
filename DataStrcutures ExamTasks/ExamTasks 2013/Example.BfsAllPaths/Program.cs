namespace Example.BfsAllPaths
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Program
    {
        private static int totalAge;
        private static int childlessCount;

        private static int totalAgeParents;
        private static int parentsWithChildrenCount;

        private static int totalAgeParentWithRoot;
        private static int parentsWithChildrenCountWithRoot;

        public static void Main()
        {
            var root = new Person("Albert", 65);

            var benny = new Person("Benny", 42);
            var carlos = new Person("Carlos", 40);
            var diana = new Person("Diana", 32);

            var emmy = new Person("Emmy", 18);
            var fani = new Person("Fani", 22);
            var katia = new Person("katia", 16);
            var nick = new Person("Nick", 17);
            var philip = new Person("Philip", 16);


            benny.AddChild(emmy);
            benny.AddChild(fani);
            benny.AddChild(katia);

            carlos.AddChild(nick);
            carlos.AddChild(philip);

            root.AddChild(benny);
            root.AddChild(carlos);
            root.AddChild(diana);

            var bfsPaths = BFS(root);
            foreach (var path in bfsPaths)
            {
                Console.WriteLine(path);
            }

            Console.WriteLine("Average age of family members with no childrens : " + totalAge/childlessCount);

            Console.WriteLine("Average age of family members with childrens (without root) : " + totalAgeParents / parentsWithChildrenCount);

            Console.WriteLine("Average age of family members with childrens (with root) : " + totalAgeParentWithRoot / parentsWithChildrenCountWithRoot);
        }

        private static IEnumerable<string> BFS(Person root)
        {
            var queue = new Queue<Tuple<string, Person>>();
            queue.Enqueue(new Tuple<string, Person>(root.Name, root));
            var temp = root.Age;
            totalAgeParentWithRoot += temp;
            parentsWithChildrenCountWithRoot = 1;

            while (queue.Any())
            {
                var node = queue.Dequeue();

                if (node.Item2.Children.Any())
                {
                    foreach (var child in node.Item2.Children)
                    {
                        queue.Enqueue(new Tuple<string, Person>(node.Item1 + " >>[isParentOf]>> " + child.Name, child));

                        if (child.Children.Count == 0)
                        {
                            Console.WriteLine("Family member without childs: "+ child.Name);
                            totalAge += child.Age;
                            childlessCount++;
                        }

                        if (child.HasParent && child.Children.Count > 0)
                        {
                            // get only the family members and that have childrens (without ROOT)
                            totalAgeParents += child.Age;
                            parentsWithChildrenCount++;

                            // with root
                            totalAgeParentWithRoot += child.Age;
                            parentsWithChildrenCountWithRoot++;
                        }
                    }
                }
                else
                {
                    yield return node.Item1;
                }
            }
        }

        public class Person
        {
            private bool hasParent;

            public Person(string name, int age)
            {
                this.Name = name;
                this.Children = new List<Person>();
                this.HasParent = false;
                this.Age = age;
            }

            public string Name { get; set; }

            public int Age { get; set; }

            public List<Person> Children { get; set; }

            public bool HasParent
            {
                get { return this.hasParent; }
                set { this.hasParent = value; }
            }

            public void AddChild(Person person)
            {
                person.hasParent = true;
                this.Children.Add(person);
            }
        }
    }
}
