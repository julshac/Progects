Module Module1
    '**********************************************************************************
    'Автор: Шац Юлия.
    '**********************************************************************************
    'Редакция от 23.01.2014.
    '**********************************************************************************
    'Выводит решения 3ех данных задач.

    Sub Main()

        Dim number1 As Single
        Dim number2 As Integer
        Dim number3 As Integer

        Console.WriteLine("Задание1: ")
        number1 = FindAverage()
        Console.WriteLine("Ответ:{0}", number1)
        Console.ReadLine()

        Console.WriteLine("Задание2: ")
        number2 = CounterTrue()
        Console.WriteLine("Ответ:{0}", number2)
        Console.ReadLine()

        Console.WriteLine("Задание3: ")
        number3 = Diagonal()
        Console.WriteLine("Ответ:{0}", number3)
        Console.ReadLine()

    End Sub
    '****************************************************************************************************
    'Автор: Шац Юлия.
    '****************************************************************************************************
    'Редакция от 23.01.2014.
    '****************************************************************************************************
    'Функция, которая находит среднее арифметическое всех элементов на нечетных строчках двухмерного массива.

    Public Function FindAverage() As Single
        Dim sum, n, m, i, j As Integer
        Dim average As Single
        Randomize()

        Console.WriteLine("Введите размерность массива: ")
        n = Console.ReadLine()
        Console.WriteLine("Введите размерность массива: ")
        m = Console.ReadLine()

        Dim currArr(n, m) As Integer
        For i = 1 To n
            Console.WriteLine()
            For j = 1 To m
                currArr(i, j) = Rnd()
                Console.Write(currArr(i, j))
            Next
        Next
        Console.WriteLine()

        Dim lineCounter As Integer = 0
        sum = 0
        For i = 1 To n Step 2
            lineCounter += 1
            For j = 1 To m
                sum = sum + currArr(i, j)
            Next
        Next
        average = sum / lineCounter  ' среднее арифметическое элементов массива

        Return average
    End Function
    '****************************************************************************************************
    'Автор: Шац Юлия.
    '****************************************************************************************************
    'Редакция от 23.01.2014.
    '****************************************************************************************************
    'Функция, которая подсчитывает количество элементов, значение которых равно TRUE в двухмерном массиве.

    Function CounterTrue() As Integer
        Dim counter, i, j, m, n As Integer
        Randomize()

        Console.WriteLine("Введите размерность массива: ")
        n = Console.ReadLine()
        Console.WriteLine("Введите размерность массива: ")
        m = Console.ReadLine()

        Dim boolArray(n, m) As Boolean
        For i = 1 To n
            Console.WriteLine()
            For j = 1 To m
                boolArray(i, j) = Rnd()
                Console.Write(boolArray(i, j))
            Next
        Next
        Console.WriteLine()

        For i = 1 To n
            For j = 1 To m
                If boolArray(i, j) = True Then
                    counter += 1
                Else
                    i += 1
                End If
            Next
        Next
        Return counter
    End Function
    '**************************************************************************************************************************************
    'Автор: Шац Юлия.
    '**************************************************************************************************************************************
    'Редакция от 23.01.2014.
    '**************************************************************************************************************************************
    'Функция, которая определяет сумму элементов на диагоналях в трехмерном массиве с одинаковым количеством элементов по всем размерностям.

    Function Diagonal() As Integer
        Dim N, i, j, k As Integer
        Dim valueOfSumDiag As Integer = 0
        Randomize()

        Console.WriteLine("Введите размерность массива: ")
        n = Console.ReadLine()

        Dim threeDimArray(N - 1, N - 1, N - 1) As Integer
        For i = 0 To N - 1
            For j = 0 To N - 1
                For k = 0 To N - 1
                    threeDimArray(i, j, k) = 1
                Next
            Next
        Next

        For dimention = 0 To N - 1
            valueOfSumDiag += threeDimArray(dimention, dimention, dimention)
            valueOfSumDiag += threeDimArray(dimention, dimention, N - 1 - dimention)
            valueOfSumDiag += threeDimArray(N - 1 - dimention, N - 1 - dimention, dimention)
            valueOfSumDiag += threeDimArray(dimention, N - 1 - dimention, dimention)
        Next

        Return valueOfSumDiag
    End Function
End Module
