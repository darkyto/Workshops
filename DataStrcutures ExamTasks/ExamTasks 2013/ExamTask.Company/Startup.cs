namespace ExamTask.Company
{
    using System;
    using System.Collections.Generic;

    public class Startup
    {
        private static int allSalaries = 0;

        public static void Main()
        {
            int n = int.Parse(Console.ReadLine());
            int m = int.Parse(Console.ReadLine());

            Dictionary<string, Employee> employees = new Dictionary<string, Employee>();

            string bossName = Console.ReadLine();
            Employee boss = new Employee(bossName);
            employees.Add(bossName, boss);

            for (int i = 1; i < n; i++)
            {
                string name = Console.ReadLine();
                Employee employee = new Employee(name);
                employees.Add(name, employee);
            }

            for (int i = 0; i < m; i++)
            {
                string[] names = Console.ReadLine().Split(' ');
                string superior = names[0];
                for (int j = 1; j < names.Length; j++)
                {
                    employees[superior].Subordinates.Add(employees[names[j]]);
                }
            }

            DFS(boss);

            Console.WriteLine(allSalaries);
        }
        public static void DFS(Employee root)
        {
            if (root.Subordinates.Count == 0)
            {
                allSalaries += root.Salary;
                return;
            }

            int salary = 0;
            foreach (var employee in root.Subordinates)
            {
                DFS(employee);
                salary += employee.Salary;
            }

            root.Salary = salary;
            allSalaries += root.Salary;
        }
    }

    public class Employee
    {
        public Employee(string name)
        {
            this.Name = name;
            this.Salary = 1;
            this.Subordinates = new List<Employee>();
        }

        public List<Employee> Subordinates { get; private set; }

        public int Salary { get; set; }

        public string Name { get; set; }
    }
}
