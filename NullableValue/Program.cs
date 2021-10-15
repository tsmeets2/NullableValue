// See https://aka.ms/new-console-template for more information


using NullableValue.Data;

Console.WriteLine("Hello, World!");

var context = new TestContext();
Console.WriteLine( context.MenuGroups.Count() );
