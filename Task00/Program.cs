// See https://aka.ms/new-console-template for more information
using System;
using static System.Console;

Clear();

Words ("аисв", new char[5]);

void Words (string alfavit, char[] word, int length = 0) {
	if (length == word.Length) {
		WriteLine($"{new String(word)}");
		return;
	}
	for (int i = 0; i < alfavit.Length; i ++) {
		word[length] = alfavit[i];
		Words(alfavit, word, length + 1);
	}
}