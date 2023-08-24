using SCAUConverter;
using System.Linq.Expressions;
using System.Text.Json;

var sch = Converter.CreateSchedule();

var option = new JsonSerializerOptions
{
	WriteIndented = true,
	IncludeFields = true,
};
var json = JsonSerializer.Serialize(sch,option);
Console.WriteLine(json);

