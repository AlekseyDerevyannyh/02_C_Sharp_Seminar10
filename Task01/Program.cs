// 
using System;
using static System.Console;
Clear();
WriteLine(String.Join(", ", Encrypt(new int[]{0, 1, 1, 1, 1, 0, 0, 0, 1 }, new int[]{2, 3, 3, 1 })));


double[] Encrypt(int[] data, int[] info) {
	double[] result = new double[info.Length];
	int count = 0;
	for (int i = 0; i < info.Length; i ++ )
		for (int j = 0; j < info[i]; j ++) {
			result[i] += data[count] * Math.Pow(2, info[i] - j - 1);
			count ++;
		}
	return result;
}
