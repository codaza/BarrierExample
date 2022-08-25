Console.WriteLine("*** Welcome to Barrier class test ***\n");

// Количество одновременно работающих потоков.
// Помните, в ролике на YouTube, было 3 лопатки 😉
// Вот ссылочка, если потеряли: https://youtube.com/shorts/mj2m9qcdb48
const int participantCount = 3;

// Объявляем барьер, который расчитан на три одновременно работающих потока
Barrier barrier = new(participantCount);

// Стартуем тест
Start();

Console.WriteLine("\nTest completed!");

Console.ReadKey();

void Start()
{
    List<Task> tasks = new();

    // Запускаем три потока на выполнение
    // поэтапной задачи, алгоритм которой
    // реализован в методе DoWork()
    for (int i = 0; i < participantCount; i++)
    {
        tasks.Add(Task.Run(() => DoWork()));
    }

    // Дожидаемся окончания работы всех
    // запущенных потоков
    Task.WaitAll(tasks.ToArray());
}

void DoWork()
{
    Console.WriteLine("Step 1");

    // Дожидаемся пока все потоки выполнят первый шаг алгоритма
    barrier.SignalAndWait();

    Console.WriteLine("Step 2");

    // Дожидаемся пока все потоки выполнят второй шаг алгоритма
    barrier.SignalAndWait();

    Console.WriteLine("Step 3");
}