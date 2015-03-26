Module Module0
    Sub Main()
        Dim N As Integer

        Console.WriteLine("Введите натуральное число N: ")
        N = Console.ReadLine()

        Dim simples As List(Of Integer)
        simples = GetFirstSimples(N)
        For Each simple In simples
            Console.WriteLine("Простое число: {0}", simple)
        Next

        Console.ReadLine()

    End Sub

    Function IsSimple(ByVal valueInt As Integer, ByVal simples As List(Of Integer)) As Boolean
        Dim result As Boolean = True

        Dim i As Integer
        Dim value As Single
        value = valueInt
        For i = 0 To simples.Count - 1
            If value Mod simples(i) = 0.0 Then
                result = False
                Exit For
            End If
        Next i

        Return result
    End Function

    Function GetFirstSimples(ByVal count As Integer) As List(Of Integer)
        Dim simples As List(Of Integer)
        Dim base As Integer
        simples = New List(Of Integer)

        base = 2
        Do While simples.Count < count
            If IsSimple(base, simples) Then
                simples.Add(base)
            End If
            base += 1
        Loop


        Return simples
    End Function

End Module
