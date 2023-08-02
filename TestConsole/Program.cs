using SCAUConverter;

Console.WriteLine("Hello, World!");


var path1 = @"E:\Download\1.xlsx";
var path2 = @"E:\Download\2.xlsx";

var tt = Converter.CreateTimetable(path1);

Console.WriteLine(tt);
