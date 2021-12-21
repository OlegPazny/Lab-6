using System;
using System.Collections.Generic;
using System.Linq;

/*
  Разработчик -> Вирус -> CConficker
  Разработчик -> ПО -> Игрушка -> Сапер
  Разработчик -> ПО -> Текстовый редактор -> Word
  Интерфейс: Набор операций
*/

namespace LW5
{
    class Program
    {
        interface ISetOfOperations
        {
            void info();
        } // Интерфейс

        

        public abstract class Software : Developer
        {
            public string name { set; get; }
            public string type { set; get; }
            public string developer { set; get; }
            public string version { set; get; }

            public override string ToString()
            {
                return $"Software: {name}, {type}, {developer}";
            }

        } // Абстрактный класс

        // 1st (Developer -> Virus -> CConficker)
        class Virus : Developer
        {
            public string name { set; get; }
            public string type { set; get; }
            public void Name()
            {
                Console.WriteLine($"Название вируса: {name}");
            }
            public void Type()
            {
                Console.WriteLine($"Тип вируса: {type}");
            }
        }
        sealed class CConficker : Virus, ISetOfOperations
        {
            public void info()
            {
                Console.WriteLine($"Description: {developer}");
            }

            public override string ToString()
            {
                return $"CConficker: {name}, {type}";
            }
        }

        // 2nd (Developer -> ПО -> Game -> Saper)
        class Game : Software, ISetOfOperations
        {
            public void Developer()
            {
                Console.WriteLine($"Разработчик сапера: {developer} \n");
            }

            public void info()
            {
                Console.WriteLine("<- Game is Saper ->");
            }
        }

        class Saper : Game
        {
            public void Name()
            {
                Console.WriteLine($"Название сапера: {name}");
            }
            public void Type()
            {
                Console.WriteLine($"Тип сапера: {type}");
            }
            public override string ToString()
            {
                return $"Saper: {name}, {type}, {developer}";
            }

            


        }

        class Preview
        {
            public string prev;
            public Preview(string p)
            {
                prev = p;
            }
        } // Композиция

        // 3d (Developer -> ПО -> WordProcessor -> Word)
        class WordProcessor : Software, ISetOfOperations
        {
            public string developer { set; get; }
            public void Developer()
            {
                Console.WriteLine($"Разработчик: {developer} \n");
            }

            public void info()
            {
                Console.WriteLine("<- WordProcessor is Word ->");
            }
        }

        class Word : WordProcessor
        {
            public void Name()
            {
                Console.WriteLine($"Название: {name}");
            }
            public void Type()
            {
                Console.WriteLine($"Тип: {type}");
            }
            public override string ToString()
            {
                return $"Word: {name}, {type}, {developer}";
            }
        }

        // Printer
        class Printer : APrinter
        {
            public string IAmPrinting;
        }
        abstract class APrinter
        {
            public void IamPrinting(Developer someobj)
            {
                Console.WriteLine($"Тип этого обьекта: " + someobj.GetType());
                Console.WriteLine(someobj.ToString());
            }
        }
        // <------------------------>
        class Over
        {
            public string name { get; set; } = "Overriding";

            public Over(string fame)
            {
                this.name = fame;
            }

            public override int GetHashCode()
            {
                Console.WriteLine($"\nHash of {this.name} is: {name.GetHashCode()}\n");
                return name.GetHashCode();
            }

            public override string ToString()
            {
                return $"{name}\n";
            }

            public override bool Equals(object obj)
            {
                if (obj == null)
                    return false;
                Over el = obj as Over;
                if (el as Over == null)
                    return false;

                return el.name == this.name;
            }
        }




        // Лабораторная 6


        //перечисление
        enum Enumerable : byte
        {
            Developer,
            Software,
            WordProcessor,
            Word
        } // Перечисление
        //структура
        struct Person
        {
            public string name { set; get; }
            public float age { set; get; }
            public Person(string name, int age)
            {
                this.age = age;
                this.name = name;
            }
            public void About()
            {
                Console.WriteLine($"Имя автора {name} и возраст автора {age}");
            }
        } // Структура
        //partial класс
        public partial class Developer
        {
            public string developer { set; get; }

            public override string ToString()
            {
                return $"Dev: {developer}";
            }
        }
        //partial класс
        //класс-контейнер
        class Computer
        {
            public List<Software> container { set; get; }
            public Computer()
            {
                container = new List<Software>();
                return;
            }

            public Software this[int index]
            {
                get { return container[index]; }
                set { container[index] = value; }
            }

            public void AddItem(Software s)
            {
                container.Add(s);
            }
            public void DeleteItem(Software s)
            {
                container.Remove(s);
            }

            public void Print()
            {
                Console.WriteLine("Элементы контейнера: ");
                for (int i = 0; i < container.Count; i++)
                {
                    Console.WriteLine("   " + container[i].name);
                }
            }
        } // Класс-Контейнер
        //класс-контроллер
        public static class Controller
        {
            public static void FindCurrentGameType(List<Software> g)//вывод игрушки
            {
                string GameType = "Racing";
                for (int i = 0; i < g.Count; i++)
                {
                    if (g[i].type == GameType)
                    {
                        Console.WriteLine("Текущая игра - " + g[i]);
                    }
                }
            }

            public static void FindVersionEditor(List<Software> g)//вывод т редактора заданной версии
            {
                string ver = "1.1";
                for (int i = 0; i < g.Count; i++)
                {
                    if (g[i].version == ver)
                    {
                        Console.WriteLine("Редактор версии " + ver + ": " + g[i]);
                    }
                }

                string version = "1.2";
                for (int i = 0; i < g.Count; i++)
                {
                    if (g[i].version == version)
                    {
                        Console.WriteLine("Редактор версии " + version + ": " + g[i]);
                    }
                }
            }

            public static void SortedSoftware(List<Software> g)//ПО в алфавитном порядке
            {
                Console.WriteLine("\n" + "Сортировка по алфавитному порядку: ");
                var sortedSoftware = g.OrderBy(u => u.name);
                foreach (var softw in sortedSoftware)
                {
                    Console.WriteLine("   " + softw.name);
                }
            }

        } // Класс-контроллер

        static void Main(string[] args)
        {
            /*CConficker conf = new CConficker { name = "Net-Worm.Win32.Kido.bt", type = "Resident virus" };
            conf.Name();
            conf.Type();
            Saper saper = new Saper { name = "Saper", type = "Game", developer = "Microsoft" };
            saper.Name();
            saper.Type();
            saper.Developer();
            Word word = new Word { name = "Word", type = "Program", developer = "Microsoft"};
            word.Name();
            word.Type();
            word.Developer();
            Printer print = new Printer();
            print.IamPrinting(conf);
            print.IamPrinting(saper);
            print.IamPrinting(word);
            
            Virus Vir = conf as CConficker;
            if (Vir == null)
            {
              Console.WriteLine("Преобразование прошло неудачно");
            }
            else
            {
              Console.WriteLine("Преобразование прошло удачно");
            }
            if (saper is Saper)
            { 
                Saper soft2 = (Saper)saper;
              Console.WriteLine("Преобразование допустимо");
            }
            else
            {
              Console.WriteLine("Преобразование не допустимо");
            }
            
            dynamic[] array = new dynamic[] {conf, saper, word};
            // Одноименные методы
            SomeClass interf = new SomeClass();
            ((IInterface1)interf).Method1();
            ((IInterface2)interf).Method1();*/

            // ЛР 6
            Enumerable a;
            a = Enumerable.Developer;
            Console.WriteLine("Элемент перечисления: " + a);
            Console.WriteLine("Номер элемента перечисления: " + (int)a);

            Person man = new Person("Oleg", 18);
            man.About();

            Computer PC = new Computer();
            Game game1 = new Game { name = "Forza", type = "Racing", developer = "Turn10" };
            Word word1 = new Word { name = "MSWord", type = "Word", developer = "Microsoft", version = "1.1" };
            Saper game2 = new Saper { name = "Saper", type = "Puzzle", developer = "Microsoft", version="1.2" };
            Word word2 = new Word { name = "Notepad", type = "Word", developer = "Microsoft", version = "1.1" };
            PC.AddItem(game1);
            PC.AddItem(word1);
            PC.AddItem(game2);
            PC.AddItem(word2);
            PC.Print();
            PC.DeleteItem(word1);
            Console.WriteLine("\n После удаления элемента:\n");
            PC.Print();

            Controller.FindCurrentGameType(PC.container);
            Controller.FindVersionEditor(PC.container);
            Controller.SortedSoftware(PC.container);

            Console.ReadKey();
            // Game test = new Game();
            // PC.AddItem(test);
            // Controller.FileOutput(PC.container);
        }
    }
}

/*
  Собрать (установить) разное ПО на Компьютер (хранить в виде списка или массива).
  Найти Игрушки определенного типа и текстовый редактор
  заданной версии, вывести все ПО в алфавитном порядке.
*/