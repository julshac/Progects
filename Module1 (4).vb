Module Module1

    Sub Main()
        Dim a, b, c, d As Integer

        Console.WriteLine("Введите a:")
        a = Console.ReadLine
        Console.WriteLine("Введите b:")
        b = Console.ReadLine
        Console.WriteLine("Введите c:")
        c = Console.ReadLine
        Console.WriteLine("Введите d:")
        d = Console.ReadLine

        Console.WriteLine("Случай 1 (Ладья):")
        If a = c Or b = d Then
            Console.WriteLine("Ладья ({0},{1}) угрожает фигуре ({2},{3})", a, b, c, d)
        Else
            Console.WriteLine("Ладья ({0},{1}) не угрожает фигуре ({2},{3})", a, b, c, d)
        End If

        Console.WriteLine("Случай 2 (Слон):")
        If a + b = c + d Or b - a = d - c Then
            Console.WriteLine("Слон ({0},{1}) угрожает фигуре ({2},{3})", a, b, c, d)
        Else
            Console.WriteLine("Слон ({0},{1}) не угрожает фигуре ({2},{3})", a, b, c, d)
        End If

        Console.WriteLine("Случай 3 (Король:")
        If Math.Abs(a - c) <= 1 And Math.Abs(b - d) <= 1 Then
            Console.WriteLine("Король ({0},{1}) попадает на поле ({2},{3})", a, b, c, d)
        Else
            Console.WriteLine("Король ({0},{1}) не попадает на поле ({2},{3})", a, b, c, d)
        End If

        Console.WriteLine("Случай 4 (Ферзь):")
        If a = c Or b = d Or a + b = c + d Or b - a = d - c Then
            Console.WriteLine("Ферзь ({0},{1}) угрожает фигуре ({2},{3})", a, b, c, d)
        Else
            Console.WriteLine("Ферзь ({0},{1}) не угрожает фигуре ({2},{3})", a, b, c, d)
        End If

        Console.WriteLine("Случай 5 (Конь):")
        If (c = a + 1 And d = b + 2) _
           Or (c = a + 2 And d = b + 1) _
           Or (c = a + 2 And d = b - 1) _
           Or (c = a + 1 And d = b - 2) _
           Or (c = a - 1 And d = b - 2) _
           Or (c = a - 2 And d = b - 1) _
           Or (c = a - 2 And d = b + 1) _
           Or (c = a - 1 And d = b + 2) Then
            Console.WriteLine("Конь ({0},{1}) угрожает фигуре ({2},{3})", a, b, c, d)
        Else
            Console.WriteLine("Конь ({0},{1}) не угрожает фигуре ({2},{3})", a, b, c, d)
        End If

        Console.ReadLine()
    End Sub

End Module
