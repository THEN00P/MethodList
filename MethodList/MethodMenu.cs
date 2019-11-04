using System;
using System.Collections.Generic;

namespace MethodList {
    public class MethodMenu {
        public class Method {
            public Method(string p_name, Action p_method) {
                this.Name = p_name;
                this.Function = p_method;
            }

            public string Name;
            public Action Function;
        }

        public static List<Method> Methods = new List<Method>();

        private static int selected = 0;
        private static int maxTextWidth = 0;

        public static void NewMethod(string name, Action method) {
            Methods.Add(new Method(name, method));
        }

        public static void RemoveByName(string name) {
            for (int i = 0; i < Methods.Count; i++) {
                if (Methods[i].Name == name) {
                    Methods.Remove(Methods[i]);
                    i--;
                }
            }
        }

        public static void RenderList(string projektName) {
            while (true) {
                Console.Clear();

                if (projektName.Length > maxTextWidth) maxTextWidth = projektName.Length;
                for (int i = 0; i < Methods.Count; i++) {
                    if (Methods[i].Name.Length + 4 > maxTextWidth) maxTextWidth = Methods[i].Name.Length + 4;
                }

                Console.WriteLine(projektName);
                for (int i = 0; i < maxTextWidth; i++) {
                    Console.Write("-");
                }

                Console.WriteLine();

                for (int i = 0; i < Methods.Count; i++) {
                    Console.WriteLine("{0, -" + (maxTextWidth - 4) + "} [{1}]", Methods[i].Name, i == selected ? "X" : " ");
                }

                Console.WriteLine("\nPress ESC to leave.");

                switch (Console.ReadKey().Key) {
                    case ConsoleKey.Escape:
                        return;
                    case ConsoleKey.UpArrow:
                        if (selected > 0) selected--;
                        break;
                    case ConsoleKey.DownArrow:
                        if (selected < Methods.Count - 1) selected++;
                        break;
                    case ConsoleKey.Enter:
                        Console.Clear();
                        Methods[selected].Function.Invoke();
                        break;
                }
            }
        }
    }
}