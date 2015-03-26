Module Module1

    Sub Main()
        Dim figure, Sum, count, result As Integer

        Console.Write("Введите число: ")
        figure = Console.ReadLine()


        Do
            Do While figure > 0
                count = figure Mod 10
                Sum = Sum + count
                figure = figure \ 10
                result = Sum
            Loop
            figure = result
            Sum = 0
        Loop Until figure < 10
        
        Console.WriteLine("Полученное число: {0}", result)
        Console.ReadLine()
    End Sub

End Module
