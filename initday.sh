#!/usr/bin/env bash

dotnet new console --name $1 --use-program-main

touch "$1/${1}part1.txt"
touch "$1/${1}test.txt"

cat > $1/Program.cs << EOF
namespace ${1};

class Program
{
	static void Main(string[] args)
	{
		var lines = File.ReadAllLines(args[0]);
		Part1(lines.ToList());
	}

	static void Part1(List<string> input)
	{
		foreach ( var line in input) {
			Console.WriteLine($"({line.Count()}) {line}");
		}
	}
}
EOF
