using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace snakeGame
{
    internal class Snake
    {
        enum Direccion
        {
            Arriba,Abajo,Izquierda,Derecha
        }
        public bool Vivo { get; set; }
        public ConsoleColor ColorCabeza { get; set; }
        public ConsoleColor ColorCuerpo { get; set; }
        public Ventana VentanaC { get; set; }
        public List<Point> Cuerpo { get; set; }
        public Point Cabeza { get; set; }

        private Direccion _direccion;

        public Snake(Point posicion, ConsoleColor colorCabeza, ConsoleColor colorCuerpo,
        Ventana ventana)
        {
            ColorCabeza = colorCabeza;
            ColorCuerpo = colorCuerpo;
            VentanaC = ventana;
            Cabeza = posicion;
            Cuerpo = new List<Point>();
            
            _direccion = Direccion.Derecha;
        }

        public void IniciarCuerpo(int numPartes)
        {
            int x = Cabeza.X - 1;
            for (int i = 0; i < numPartes; i++)
            {
                Console.SetCursorPosition(x, Cabeza.Y);
                Console.Write("█"); //alt + 178
                Cuerpo.Add(new Point(x, Cabeza.Y));
                x--;
            }
        }

        public void Mover()
        {
            Teclado();
            Point posicionCabezaAnterior = Cabeza;
            MoverCabeza();
            MoverCuerpo(posicionCabezaAnterior);
        }

        public void MoverCabeza()
        {
            Console.ForegroundColor = ColorCabeza;
            Console.SetCursorPosition(Cabeza.X, Cabeza.Y);
            Console.Write(" ");
            switch (_direccion)
            {
                case Direccion.Derecha:
                    Cabeza = new Point(Cabeza.X + 1, Cabeza.Y);
                    break;
                case Direccion.Izquierda:
                    Cabeza = new Point(Cabeza.X - 1, Cabeza.Y);
                    break;
                case Direccion.Abajo:
                    Cabeza = new Point(Cabeza.X, Cabeza.Y + 1);
                    break;
                case Direccion.Arriba:
                    Cabeza = new Point(Cabeza.X, Cabeza.Y - 1);
                    break;

            }
            Console.SetCursorPosition(Cabeza.X, Cabeza.Y);
            Console.Write("█"); // ALT + 219
        }

        private void MoverCuerpo(Point posicionCabezaAnterior)
        {
            Console.ForegroundColor = ColorCuerpo;
            Console.SetCursorPosition(posicionCabezaAnterior.x,posicionCabezaAnterior.y);
            Console.Write("█"); // alt + 178
            Cuerpo.Insert(0, posicionCabezaAnterior);

            Console.SetCursorPosition(Cuerpo[Cuerpo.Count - 1].X, Cuerpo[Cuerpo.Count - 1].Y); 
            Console.Write(" ");
            Cuerpo.Remove(Cuerpo[Cuerpo.Count - 1]);
        }

        private void Teclado()
        {
            if (Console.KeyAvailable)
            {
                ConsoleKeyInfo tecla = Console.ReadKey(true);
                if(tecla.Key == ConsoleKey.RightArrow)
                    _direccion = Direccion.Derecha;
                if(tecla.Key == ConsoleKey.LeftArrow)
                    _direccion = Direccion.Izquierda;
                if(tecla.Key == ConsoleKey.UpArrow)
                    _direccion = Direccion.Arriba;
                if(tecla.Key == ConsoleKey.DownArrow)
                    _direccion = Direccion.Abajo;
               
            }   
        }

    }


}
