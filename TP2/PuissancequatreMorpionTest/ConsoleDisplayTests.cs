using Xunit;
using System.IO;
using System;
using MorpionApp;

namespace PuissancequatreMorpionTest;

public class ConsoleDipslayTests
{
     [Fact]
        public void WriteLine_ClearsConsoleAndWritesText()
        {
            // Arrange
            string text = "Hello, world!";
            var consoleOutput = new StringWriter();
            Console.SetOut(consoleOutput);

            // Act
            ConsoleDisplay.WriteLine(text);

            // Assert
            Assert.Equal($"{text}{Environment.NewLine}", consoleOutput.ToString());
        }
}