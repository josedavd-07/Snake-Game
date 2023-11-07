﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace snakeGame
{
    internal class Ventana
    {
        public string Titulo { get; set; }
        public int Ancho { get; set; }
        public int Altura { get; set; }
        public ConsoleColor ColorFondo { get; set; }
        public ConsoleColor ColorLetra  { get; set; }
        public Point LimiteSuperior { get; set; }
        public Point LimiteInferior { get; set; }
        public Ventana(string titulo, int ancho, int altura,
        ConsoleColor colorFondo, ConsoleColor colorLetra,
        Point limiteSuperior, Point limiteInferior)
        {
            Titulo = titulo;
            Ancho = ancho;
            Altura = altura;
            ColorFondo = colorFondo;
            ColorLetra = colorLetra;
            Init();
            LimiteSuperior = limiteSuperior;
            LimiteInferior = limiteInferior;
        }

        public void Init()
        {
            Console.Title = Titulo;
            Console.SetWindowSize(Ancho, Altura);
            Console.CursorVisible = false;
            Console.BackgroundColor = ColorFondo;
            Console.Clear();
        }

        public void DibujarMarco()
        {
            Console.ForegroundColor = ColorLetra;

            for (int i = LimiteSuperior.X; i < LimiteInferior.X; i++)
            {
                Console.SetCursorPosition(i, LimiteSuperior.Y);
                Console.Write("═");
                Console.SetCursorPosition(i, LimiteInferior.Y);
                Console.Write("═");
            }
            for (int i = LimiteSuperior.Y; i < LimiteInferior.Y; i++)
            {
                Console.SetCursorPosition(LimiteSuperior.X, i);
                Console.Write("║");
                Console.SetCursorPosition(LimiteInferior.X, i);
                Console.Write("║");
            }
            Console.SetCursorPosition(LimiteSuperior.X, LimiteSuperior.Y);
            Console.Write("╔");
            Console.SetCursorPosition(LimiteSuperior.X, LimiteInferior.Y);
            Console.Write("╚");
            Console.SetCursorPosition(LimiteInferior.X, LimiteSuperior.Y);
            Console.Write("╗");
            Console.SetCursorPosition(LimiteInferior.X, LimiteInferior.Y);
            Console.Write("╝");
        }       

    }
}
