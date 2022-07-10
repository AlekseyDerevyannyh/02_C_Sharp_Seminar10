// Задача 61: Показать треугольник Паскаля. *Сделать вывод в виде равнобедренного треугольника.

using System;
using static System.Console;

Clear();
Write("Введите размерность треугольника Паскаля: ");
int size = Convert.ToInt32(ReadLine());
PrintIsoscelesTriangle(FillPascalTriangle(size));
WriteLine();

int[,] FillPascalTriangle(int row) {
	int[,] triangle = new int[row, row];
	for (int i = 0; i < row; i ++) {
		triangle[i, 0] = 1;
		triangle[i, i] = 1;
	}
	for (int i = 2; i < row; i ++) 
		for (int j = 1; j <= i; j ++) 
			triangle[i, j] = triangle[i - 1, j - 1] + triangle[i - 1, j];
	return triangle;
}

void PrintIsoscelesTriangle(int[,] triangle) {
	const int cellWidth = 3;	// ширина ячейки, для отображения чисел без перехлёстов
	int col = cellWidth * triangle.GetLength(0);
	for (int i = 0; i < triangle.GetLength(0); i ++) {
		for (int j = 0; j <= i; j ++) {
			SetCursorPosition(col, i + 1);
			if (triangle[i, j] != 0)	Write($"{triangle[i, j],cellWidth}");
			col += cellWidth * 2;
		}
		col = cellWidth * triangle.GetLength(0) - cellWidth * (i + 1);
		WriteLine();
	}
}
