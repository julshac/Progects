'Программист Бобров А.В.
Imports System.Console
Imports System.Math
Module Module2
    Sub main()
        Title = "Математическая задача"
        Dim a, b, e, x0, x1, x2 As Double
        WriteLine("F(x)=tan(x) + (1 / 3) * tan(x) ^ 3 + (1 / 5) * tan(x) ^ 5 - (1 / 3)")
        Write("Введите начало интервала: ")
        a = ReadLine()
        Write("Введите конец интервала: ")
        b = ReadLine()
        Write("Введите точность: ")
        e = ReadLine()

        'Первый случай'
        If F(a) * Fpr(a) > 0 Then
            x0 = b
            x1 = x0 - (F(x0) * (a - x0)) / (F(a) - F(x0))
            x2 = (x0 * (F(x1) - x1 * F(x0))) / (F(x1) - F(x0))
            While Abs(x2 - x1) >= e
                x0 = x1
                x1 = x2
                x2 = x1 - (F(x1) * (x0 - x1)) / (F(x0) - F(x1))
            End While
        Else
            x0 = a
            x1 = x0 - (F(x0) * (x0 - b)) / (F(x0) - F(b))
            x2 = x1 - (F(x1) * (x0 - x1)) / (F(x0) - F(x1))
            While Abs(x2 - x1) >= e
                x0 = x1
                x1 = x2
                x2 = x1 - (F(x1) * (x0 - x1)) / (F(x0) - F(x1))
            End While
        End If

        'Второй случай'
        If F(b) * Fpr(b) > 0 Then
            x0 = a
            x1 = x0 - (F(x0) * (b - x0)) / (F(b) - F(x0))
            x2 = x1 - (F(x1) * (x0 - x1)) / (F(x0) - F(x1))
            While Abs(x2 - x1) >= e
                x0 = x1
                x1 = x2
                x2 = x1 - (F(x1) * (x0 - x1)) / (F(x0) - F(x1))
            End While
        Else
            x0 = b
            x1 = x0 - (F(x0) * (x0 - a)) / (F(x0) - F(a))
            x2 = x1 - (F(x1) * (x0 - x1)) / (F(x0) - F(x1))
            While Abs(x2 - x1) >= e
                x0 = x1
                x1 = x2
                x2 = x1 - (F(x1) * (x0 - x1)) / (F(x0) - F(x1))
            End While
        End If
        WriteLine("x = {0:f3}", x2)
        ReadKey()
    End Sub
    Function F(ByVal x As Double) As Double
        Return Tan(x) + (1 / 3) * Tan(x) ^ 3 + (1 / 5) * Tan(x) ^ 5 - (1 / 3)
    End Function
    Function Fpr(ByVal x As Double) As Double
        Return 2 * Tan(x) ^ 5 / Cos(x) ^ 2 + 4 * Tan(x) ^ 3 / Cos(x) ^ 4 - 2 * Tan(x) ^ 3 / Cos(x) ^ 2 + 2 * Tan(x) / Cos(x) ^ 2 - 2 * Tan(x) / Cos(x) ^ 4
    End Function

End Module
