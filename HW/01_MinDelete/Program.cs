// Задача 59: Из двумерного массива целых чисел удалить строку и столбец,
// на пересечении которых расположен наименьший элемент.
using System;
using static System.Console;

Clear();
Write("Введите количество строк массива: ");
int m = Convert.ToInt32(ReadLine());
Write("Введите количество столбцов массива: ");
int n = Convert.ToInt32(ReadLine());
int[,] Array = GetRandomArray(m, n, 10, 99);
PrintArray(Array);
WriteLine();
WriteLine("Массив с удалёнными строкой и столбцом на пересечении которых расположен наименьший элемент:");
PrintArray(DeleteMinElement(Array));


int[,] DeleteMinElement (int[,] array) {
	if (array.GetLength(0) < 2 || array.GetLength(1) < 2) {
		WriteLine("ОШИБКА! Размерности массива должны быть >= 2");
		return new int[,]{{0}};
	}
	int[,] result = new int[array.GetLength(0) - 1, array.GetLength(1) - 1];
	int[] indexMin = FindIndexMinElement(array);
	for (int i = 0; i < array.GetLength(0); i ++)
		for (int j = 0; j < array.GetLength(1); j ++) {
			if (i < indexMin[0] && j < indexMin[1]) { result[i, j] = array[i, j];			continue; }
			if (i > indexMin[0] && j < indexMin[1]) { result[i - 1, j] = array[i, j];		continue; }
			if (i < indexMin[0] && j > indexMin[1]) { result[i, j - 1] = array[i, j];		continue; }
			if (i > indexMin[0] && j > indexMin[1]) { result[i - 1, j - 1] = array[i, j];	continue; }
		}
	return result;
}

int[] FindIndexMinElement (int[,] array) {
	int[] minIndex = {0, 0};
	for (int i = 0; i < array.GetLength(0); i ++)
		for (int j = 0; j < array.GetLength(1); j ++)
			if (array[i, j] < array[minIndex[0], minIndex[1]]) {
				minIndex[0] = i;
				minIndex[1] = j;
			}
	return minIndex;
}

int[,] GetRandomArray (int row, int column, int minValue, int maxValue) {
	int[,] result = new int[row, column];
	for (int i = 0; i < row ; i ++) {
		for (int j = 0; j < column; j ++) {
			result[i, j] = new Random().Next(minValue, maxValue + 1);
		}
	}
	return result;
}

void PrintArray(int[,] array) {
	for (int i = 0; i < array.GetLength(0); i ++) {
		for (int j = 0; j < array.GetLength(1); j ++) {
			Write($"{array[i, j]} ");
		}
		WriteLine();
	}
}
