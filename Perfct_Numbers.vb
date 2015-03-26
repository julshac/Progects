Module Module1
    Sub Main()
        Dim N As Integer

        Console.WriteLine("Введите натуральное число N: ")
        N = Console.ReadLine()

        Dim perfects As List(Of Long)
        perfects = GetFirstPerfects(N)
        For Each perfect In perfects
            Console.WriteLine("Совершенное число: {0}", perfect)
        Next

        Console.ReadLine()

    End Sub

    Function IsSimple(ByVal valueInt As Integer, ByVal perfects As List(Of Long)) As Boolean
        Dim result As Boolean = True

        Dim i As Integer
        Dim value As Single
        value = valueInt
        For i = 1 To perfects.Count - 1
            If value Mod perfects(i) = 0.0 Then
                result = False
                Exit For
            End If
        Next i

        Return result
    End Function

    Function GetFirstPerfects(ByVal count As Long) As List(Of Long)
        Dim perfects As List(Of Long)
        Dim base As Integer
        perfects = New List(Of Long)

        base = 2
        Do While perfects.Count < count
            If IsSimple(2 ^ (base - 1), perfects) Then
                perfects.Add(2 ^ (base - 1) * (2 ^ (base) - 1))
            End If
            base += 1
            If base > 3 Then
                base += 1
            End If

        Loop


        Return perfects
    End Function

End Module



