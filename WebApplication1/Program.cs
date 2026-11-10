var builder = WebApplication.CreateBuilder();
var app = builder.Build();

// 5 имён: 2 нормальных и 3 с недопустимыми символами
string[] names =
{
    "Иванов Иван Иванович",
    "Петрова Анна Сергеевна",
    "Сидоров Сидор#1",
    "Козлов Ко$ьма Петрович",
    "Н1колаев Николай @"
};

app.MapGet("/", () =>
{
    string name = names[Random.Shared.Next(names.Length)];
    int age = Random.Shared.Next(18, 70);
    bool isStudent = Random.Shared.Next(2) == 0;
    return new Person(name, age, isStudent);
});

app.Run();

record Person(string Name, int Age, bool IsStudent);