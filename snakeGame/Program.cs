﻿using snakeGame;
using System.Drawing;

Ventana ventana;
Snake snake;
bool jugar = true;

void Iniciar()
{
    ventana = new Ventana("Snake Game", 65, 20, ConsoleColor.Black, ConsoleColor.White,
    new Point(5, 3), new Point(59, 18));
    ventana.DibujarMarco();
    snake = new Snake(new Point(8, 5), ConsoleColor.Red, ConsoleColor.Green, ventana);
    snake.IniciarCuerpo(2);
}
void Game()
{ 
    while (jugar)
    {
        snake.Mover();
        Thread.Sleep(100);
        
    }

}

Iniciar();
Game(); 
Console.ReadKey();