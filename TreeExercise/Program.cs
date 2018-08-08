using System;
using System.Collections.Generic;

namespace TreeExercise
{
    public class BoTree<T>
    {
        public T end;
        public BoTree()
        {
            nodes = new List<BoTree<T>>();
        }
        public BoTree(T data)
        {
            this.Data = data;
            end = data;
            nodes = new List<BoTree<T>>();
        }
        private BoTree<T> parent;
        public BoTree<T> Parent
        {
            get{return parent;}
        }
        public T Data {get;set;}



        private List<BoTree<T>> nodes;
        private List<BoTree<T>> Nodes
        {
            get{return nodes;}
        }

        public void AddNote(BoTree<T> node)
        {
            if(!nodes.Contains(node))
            {
                node.parent = this;
                nodes.Add(node);
                end = node.end;
            }
        }
        public void AddNote(List<BoTree<T>> nodes)
        {
            foreach(var node in nodes)
            {
                if(!nodes.Contains(node))
                {
                    node.parent = this;
                    nodes.Add(node);
                }
            }
        }
        public void Remote(BoTree<T> node)
        {
            if(nodes.Contains(node))
            {
                nodes.Remove(node);
            }
        }
        public void RemoveAll()
        {
            nodes.Clear();
        }
    }
    public class Student
    {
        public string Name{get;set;}
        public string Sex{get;set;}
        public int Age{get;set;}
        public Student(string name,string sex,int age)
        {
            this.Name = name;
            this.Sex = sex;
            this.Age = age;
        }
        public override string ToString()
        {
            Console.WriteLine("Name:{0},Sex:{1},Age:{2}",this.Name,this.Sex,this.Age);
            return "OK";
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            BoTree<Student> tree1 = new BoTree<Student>();
            tree1.Data = new Student("Nature","Man",22);
            BoTree<Student> tree2 = new BoTree<Student>(new Student("Bob","Man",12));
            tree1.AddNote(tree2);
            tree1.end.ToString();
        }
    }
}
