using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.InteropServices;
using MadsMikkel.Schedulator.Core;

namespace Sandbox
{
	class Program
	{
		[DllImport("kernel32.dll")]
		static extern IntPtr GetConsoleWindow();

		[DllImport("user32.dll")]
		static extern bool ShowWindow(IntPtr hWnd, int nCmdShow);

		static void Main(string[] args)
		{
			ShowWindow(GetConsoleWindow(), 0);
			Debug.WriteLine("----   SCHEDULATOR DEBUG SESSION   ----");
			SeeLineOutput();
			Debug.WriteLine("DEBUG STOPPED");
		}

		static void SeeLineOutput()
		{
			SubSection sub1 = new SubSection(0, 10, 10, 5);
			SubSection sub2 = new SubSection(10.5m, 14.3m, 1, 8);
			List<SubSection> subSecs = new List<SubSection> { sub1, sub2 };
			Section vjFa = new Section(subSecs);
			Section FaMd = new Section(subSecs);
			Station s1 = new Station("Vejle");
			Station s2 = new Station("Fredericia");
			Station s3 = new Station("Middelfart");
			s1.Add(s2, vjFa);
			s2.Add(s3, FaMd);
			Line line = new Line(new List<Station>() { s1, s2, s3 });
			Debug.WriteLine(line.ToString());

		}
	}
}
