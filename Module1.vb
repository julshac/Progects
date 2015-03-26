Imports System.Diagnostics

Module Module1

    Sub Main()
        Dim FibIter, Num, FibRec As UInteger
        Dim interval As Stopwatch

        Console.Write("Введите границу чисел Фибоначчи: ")
        Num = Console.ReadLine()

        interval = Stopwatch.StartNew()
        FibIter = FindFibonacciIteration(Num)
        interval.Stop()
        Console.WriteLine("Число Фибоначчи (итерационный метод): {0}", FibIter)
        Console.WriteLine("Время выполения (в тактах): {0}", interval.ElapsedTicks)

        interval = Stopwatch.StartNew()
        FibRec = FindFibonacciRecursionOptim(Num, 0, 0, 1)
        interval.Stop()
        Console.WriteLine("Число Фибоначчи (рекурсивный метод): {0}", FibRec)
        Console.WriteLine("Время выполнения (в тактах): {0}", interval.ElapsedTicks)


        Console.ReadLine()
    End Sub

    Function FindFibonacciIteration(ByVal boundary As UInteger) As UInteger
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

    ' Оптимальная функция нахождения числа Фибоначчи, используя рекурсию.
    Function FindFibonacciRecursionOptim(ByVal stopN As Integer, ByVal curN As Integer, ByVal vPred As UInteger, ByVal vCur As UInteger) As UInteger

        curN += 1
        If curN < 3 Then
            vPred = 0
            vCur = 1
        End If
        If curN < stopN Then
            Return FindFibonacciRecursionOptim(stopN, curN, vCur, vPred + vCur)
        Else
            Return vPred + vCur
        End If

    End Function

End Module
