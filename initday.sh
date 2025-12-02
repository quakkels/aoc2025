#!/usr/bin/env bash

SOLUTION_NAME="${1}"
CONSOLE_PROJECT_NAME="$SOLUTION_NAME.Cli"
TEST_PROJECT_NAME="${SOLUTION_NAME}.Tests"

ROOT_DIR="$(pwd)/${SOLUTION_NAME}"
mkdir -p "$ROOT_DIR"
cd "$ROOT_DIR"

dotnet new sln -n "$SOLUTION_NAME" --force

dotnet new console -n "$CONSOLE_PROJECT_NAME" \
	--use-program-main \
	--framework net8.0 

sed -i 's/<Nullable>enable<\/Nullable>/<Nullable>disable<\/Nullable>/' \
	"$CONSOLE_PROJECT_NAME/$CONSOLE_PROJECT_NAME.csproj"

dotnet new xunit -n "$TEST_PROJECT_NAME" --framework net8.0

sed -i 's/<Nullable>enable<\/Nullable>/<Nullable>disable<\/Nullable>/' \
	"$TEST_PROJECT_NAME/$TEST_PROJECT_NAME.csproj"

dotnet sln add "$CONSOLE_PROJECT_NAME/$CONSOLE_PROJECT_NAME.csproj"
dotnet sln add "$TEST_PROJECT_NAME/$TEST_PROJECT_NAME.csproj"
dotnet add "$TEST_PROJECT_NAME/$TEST_PROJECT_NAME.csproj" \
	reference "$CONSOLE_PROJECT_NAME/$CONSOLE_PROJECT_NAME.csproj"

touch "$ROOT_DIR/part1.txt"
touch "$ROOT_DIR/test.txt"

cat > $CONSOLE_PROJECT_NAME/Program.cs << EOF
namespace ${CONSOLE_PROJECT_NAME};

class Program
{
	static void Main(string[] args)
	{
		var lines = File.ReadAllLines(args[0]);
		var input = lines.ToList();
		Solve(input);
	}

static void Solve(List<string> input)
{
	foreach ( var line in input) {
		Console.WriteLine($"({line.Count()}) {line}");
	}
}
}
EOF
