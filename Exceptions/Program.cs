// See https://aka.ms/new-console-template for more information

for (int i = 0; i < 10; i++)
{
    try
    {
        if (i == 6)
        {
            throw new Exception("Method A");
        }
        Console.WriteLine($"Multiply {i * i}");
    }
    catch (Exception ex)
    {
        LogError(i);
    }
}

Console.ReadLine();

void LogError(int index)
{
    Console.WriteLine($"Error in index {index}");
}

void MethodA(int a)
{
    try
    {
        if (a == 6)
        {
            throw new Exception("Method A");
        }
        Console.WriteLine($"Multiply {a * a}");
    }
    catch (Exception ex)
    {
        throw ex;
    }
}