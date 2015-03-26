Module Module2

    Sub Main()
        Dim FibIter, Num, FibRec As UInteger
        Dim StartTime1, EndTime1, Delta1, value As Double
        Dim StartTime, EndTime, Delta As Double

        Dim streamCsv As System.IO.StreamWriter
        streamCsv = My.Computer.FileSystem.OpenTextFileWriter("data.csv", False) ' Создали
        streamCsv.WriteLine("Входное чило (Num);Время выполнения (итерационный метод) (сек);Время выполнения (рекурсивный метод) (сек)") 'пишим строку 1


        Console.Write("Введите границу чисел Фибоначчи: ")
        Num = Console.ReadLine()

        For value = 1 To 47

            StartTime1 = Timer
            FibIter = FindFibonacciIteration(Num)
            EndTime1 = Timer
            Delta1 = EndTime1 - StartTime1
            Console.WriteLine("Число Фибоначчи (итерационный метод): {0}", FibIter)
            Console.WriteLine("Время выполения (в секундах): {0}", Delta1)

            StartTime = Timer
            FibRec = FindFibonacciRecursion(Num)
            EndTime = Timer
            Delta = EndTime - StartTime
            Console.WriteLine("Число Фибоначчи (рекурсивный метод): {0}", FibRec)
            Console.WriteLine("Время выполнения (в секундах): {0}", Delta)

            streamCsv.WriteLine("{0};{1};{2}", FibIter, Delta1, Delta) 'пишим строку 2

            Num += 1
        Next

        streamCsv.Close() 'Закрываем-сохраняем
        'Файлик в директории программы
        Console.ReadLine()
    End Sub
    Function FindFibonacciIteration(ByVal boundary As UInteger)
        Dim number1, number2, numbFib, count As UInteger
        number1 = 0
        number2 = 1
        numbFib = 1
        For count = 2 To boundary
            numbFib = number1 + number2
            number1 = number2
            number2 = numbFib
        Next

        Return numbFib
    End Function
    Function FindFibonacciRecursion(ByVal lim As UInteger)

        If lim < 3 Then
            Return 1
        Else
            Return FindFibonacciRecursion(lim - 1) + FindFibonacciRecursion(lim - 2)
        End If
    End Function

End Module
