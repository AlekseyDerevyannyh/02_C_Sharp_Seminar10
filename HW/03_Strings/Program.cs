// Даны две строки. Определить можно ли из символов первой строки, собрать вторую.
// Допускается любое количество пробелов. Регистр символов различный в любой последовательности.
// Пример:
// Строка 1. Tom Marvolo Riddle
// Строка 2. I am Lord Voldemort
// Ответ: Да
// Строка 1. Tom Marvolo Riddle
// Строка 2. Lord Voldemort
// Ответ: Нет - остались свободные символы.
using System;
using static System.Console;

Clear();
string Text1 = "Tom Marvolo Riddle";
string Text2 = "I am Lord Voldemort";
WriteLine("Строка 1. " + Text1);
WriteLine("Строка 2. " + Text2);
// Перед сравнением строк сначала удаляем из них пробелы, затем все буквы меняем на строчные и производим сортировку/
// После такого преобразования возможность составить одну строку из другой по условиям задачи будет
// означать полное совпадение преобразованных строк
StringCompare(SortString(DeleteSpaces(Text1).ToLower()), SortString(DeleteSpaces(Text2).ToLower()));


string SortString (string text) {
	char[] textSymbol = StringToChar(text);				// переводим строку в массив символов
	for (int i = 0; i < textSymbol.Length - 1; i ++) {	// производим сортировку массива символов
		int indexMin = i;
		for (int j = i + 1; j < textSymbol.Length; j ++) {
			if (textSymbol[j] < textSymbol[indexMin]) indexMin = j;
		}
		char tmp = textSymbol[i];
		textSymbol[i] = textSymbol[indexMin];
		textSymbol[indexMin] = tmp;
	}
	return CharToString(textSymbol);			// возвращаем сортированную строку
}

char[] StringToChar (string text) {
	char[] result = new char[text.Length];
	for (int i = 0; i < result.Length; i ++) {		
		result[i] = text[i];
	}
	return result;
}

string CharToString (char[] text) {
	string result = String.Empty;
	for (int i = 0; i < text.Length; i ++) {
		result += $"{text[i]}";
	}
	return result;
}

void StringCompare (string text1, string text2) {
	if (text1.Length < text2.Length) {
		WriteLine("Ответ: Нет - не хватает символов");
		return;
	}
	if (text1.Length > text2.Length) {
		WriteLine("Ответ: Нет - остались свободные символы");
		return;
	}
	if (text1.Length == text2.Length) {
		if (text1 == text2)	 {
			WriteLine("Ответ: Да");
			return;
		} else {
			WriteLine("Ответ: Нет - не хватает символов и остаются не задействованные символы");
			return;
		}
	}
}

string DeleteSpaces (string text) {
	string result = String.Empty;
	for (int i = 0; i < text.Length; i ++)
		if (text[i] != ' ')		result += $"{text[i]}";
	return result;
}
