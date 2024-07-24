﻿using System.Text;
//String
using System.Diagnostics;
class Program {
	static void Main() {
		int iteration = 1_000_000;
		StringBuilder sb = new("Hello");
		for (int i = 0; i < iteration; i++)
		{
			sb.Append(" World");
			sb.Append(" ! ! !");
			sb.Replace('o','i');
			Thread.Sleep(2); //untuk mematikan program selama 2 detik
		}
	}
}