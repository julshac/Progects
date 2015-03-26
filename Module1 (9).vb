Module Module1

    Sub Main()
        Dim result() As Integer
        Dim str1, str2 As String

        Console.Write("Введите исходную строку: ")
        str1 = Console.ReadLine()
        Console.Write("Введите искомую подстроку: ")
        str2 = Console.ReadLine()

        result = AlgRabinaKarpa(str1, str2)
        Console.WriteLine("Количество вхождений данной подстроки: {0}", result.Length)
        If result.Length = 0 Then
            Console.WriteLine("Данного элемента в строке нет")
        Else
            Console.WriteLine("Индексы первых вхождений:")
            For i = 0 To result.Length - 1
                Console.WriteLine("{0}", result(i))
            Next
        End If

        Console.ReadLine()
    End Sub

    'Str1 - исходная строка
    'Str2 - исходная подстрока

    Function AlgRabinaKarpa(ByVal str1 As String, ByVal str2 As String) As Integer()
        Dim arrInd(str1.Length) As Integer
        Dim i As Integer = 0
        Dim hashStr2 As Integer = GetHashCode(str2)
5:
        For ind = 1 To str1.Length
            If hashStr2 = GetHashCode(Mid(str1, ind, str2.Length)) Then
                If str2 = Mid(str1, ind, str2.Length) Then
                    arrInd(i) = ind
                    i += 1
                End If
            End If
        Next
        ReDim Preserve arrInd(0 To i - 1)
        Return arrInd
    End Function

    ' Возвращает хеш-значение

    Public Function GetHashCode(ByVal strValue As String) As Integer
        Const base As Integer = 65521
        Dim checksumA As Integer = 0
        Dim adler As Integer = 0
        Dim checksuB As Integer = 0
        For Each symb As Char In strValue
            checksumA += (CInt(checksumA) + Asc(symb))
            checksuB += checksumA
        Next
        If checksumA = 0 Then
            Return 0
        Else
            Return (checksuB Mod base) * base + (checksumA Mod base)
        End If
    End Function
End Module
