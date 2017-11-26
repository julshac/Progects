Imports System.Diagnostics

Module Module3


    Sub Main()
        Dim FibIter, Num, FibRec As UInteger
        Dim interval As Stopwatch
        Dim Delta1, Delta2 As Long

        Dim streamCsv As System.IO.StreamWriter
        streamCsv = My.Computer.FileSystem.OpenTextFileWriter("data3.csv", False) ' Создали
        streamCsv.WriteLine("Входное чило (Num);Время выполнения (итерационный метод) (такты);Время выполнения (рекурсивный метод) (такты)") 'пишим строку 1

        Console.Write("Введите границу чисел Фибоначчи: ")
        Num = Console.ReadLine()

        For value = 1 To 47

            interval = Stopwatch.StartNew()
            FibIter = FindFibonacciIteration(value)
            interval.Stop()
            Delta1 = interval.ElapsedTicks

            interval = Stopwatch.StartNew()
            FibRec = FindFibonacciRecursionOptim(value, 0, 0, 1)
            interval.Stop()
            Delta2 = interval.ElapsedTicks

        streamCsv.WriteLine("{0};{1};{2}", FibIter, Delta1, Delta2) 'пишем строку 2

            Num += 1
        Next

        
        streamCsv.Close() 'Закрываем-сохраняем
        'Файлик в директории программы
        Console.ReadLine()
    End Sub

End Module


