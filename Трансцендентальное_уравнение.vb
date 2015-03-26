Module Module1

    Sub Main()
        Dim value1, value2, value3, a, b, e, f, x As Single
        Dim count As Integer

        Console.WriteLine("F(x)=tan(x) + (1 / 3) * tan(x) ^ 3 + (1 / 5) * tan(x) ^ 5 - (1 / 3)")
        Console.WriteLine("Введите начало интервала: a= ")
        a = Console.ReadLine()

        Console.WriteLine("Введите конец интервала: b= ")
        b = Console.ReadLine()

        Console.WriteLine("Введите точность: e= ")
        e = Console.ReadLine()

        value1 = Formula(a)
        value2 = Formula(b)
        value3 = Formula(f)

        If (value1 And value2) < 0 Then
            count = 1
            Do
                f = (a + b) / 2
                If value1 * value2 <= 0 Then
                    b = f
                Else
                    a = f
                End If
                count += 1
            Loop Until b - a < e
            x = (a + b) / 2
        Else
            x = a - 1
        End If
        If x = a - 1 Then
            Console.WriteLine("Корней нет на данном интервале")
        Else
            Console.WriteLine("x = {0}, n = {1}", x, count)
        End If
        Console.ReadLine()

    End Sub
    Function Formula(ByVal sinx As Single) As Single
        Dim y As Single
        y = Math.Tan(sinx) + (1 / 3) * Math.Tan(sinx) ^ 3 + (1 / 5) * Math.Tan(sinx) ^ 5 - (1 / 3)
        Return y
    End Function
End Module
