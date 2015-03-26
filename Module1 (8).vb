Module Module1

    '*************************************************************************************************************
    'Авторs: Канайлов Г., Шац Ю.
    '*************************************************************************************************************
    'Редакция от 28.05.2014.
    '*************************************************************************************************************
    'Программа, которая выполняет поиск подстроки в строке с использованием алгоритма КПМ (Кнута-Морриса-Пратта).

    Sub Main()
        Dim str, subStr As String
        Console.Write("Введите исходную строку: ")
        str = Console.ReadLine()
        Console.Write("Введите искомую подстроку: ")
        subStr = Console.ReadLine()

        Dim result As Integer = FindSubstring(str, subStr)
        If result = -1 Then
            Console.Write("Данной подстроки нет в исходной строке")
        Else
            Console.Write("Индекс первого вхождения подстроки в исходную строку: {0}", result + 1)
        End If

        Console.WriteLine()
        Comparison()

        Console.ReadLine()
    End Sub

    ''' <summary>
    ''' Функция, выполняющая поиск подстроки в строке.
    ''' </summary>

    Public Function FindSubstring(ByVal str As String, ByVal subStr As String) As Integer
        Dim index As Integer = -1
        Dim arrOfPref() = GetPrefixFunction(subStr)
        Dim indK As Integer = 0
        For i = 0 To str.Length - 1
            Do While indK > 0 And subStr(indK) <> str(i)
                indK = arrOfPref(indK - 1)
            Loop
            If subStr(indK) = str(i) Then
                indK = indK + 1
            End If
            If indK = subStr.Length Then
                index = i - subStr.Length + 1
                Exit For
            End If
        Next
        Return index
    End Function

    ''' <summary>
    ''' Префикс-функция.
    ''' </summary>

    Private Function GetPrefixFunction(ByVal str As String) As Integer()
        Dim arrOfPref(str.Length - 1) As Integer
        Dim indI, IndJ As Integer

        For indI = 1 To str.Length - 1
            IndJ = arrOfPref(indI - 1)
            Do While ((IndJ > 0) And (str(IndJ) <> str(indI)))
                IndJ = arrOfPref(IndJ - 1)
            Loop
            If str(indI) = str(IndJ) Then
                arrOfPref(indI) = IndJ + 1
                IndJ += 1
            End If
        Next
        ReDim Preserve arrOfPref(arrOfPref.Length - 1)

        Return arrOfPref
    End Function
End Module

''' <summary>
'''  Исследование времени выполнения наивного алгоритма, алгоритма Рабина-Карпа и КМП на тестовых примерах.
''' </summary>

Module Modile2

    Sub Comparison()

        Dim str, subStr As String
        Console.WriteLine()
        Console.WriteLine("Сравнение быстродействия алгоритмов:")
        Console.WriteLine("Введите тестовое значение строки:")
        str = Console.ReadLine()
        Console.WriteLine("Введите тестовое значение подстроки:")
        subStr = Console.ReadLine()
        Dim native(), algRK(), algKMP() As Long
        native = NaiveAlgorithm(str, subStr)
        algRK = AlgRabinaKarpa(str, subStr)
        algKMP = FindSubstring(str, subStr)

        Console.WriteLine("Время выполнения наивного алгоритма:")
        For i = 0 To UBound(native)
            Console.Write(native(i) & " : ")
        Next
        Console.WriteLine()
        Console.WriteLine("Время выполнения алгоритма Рабина-Карпа:")
        For i = 0 To UBound(algRK)
            Console.Write(algRK(i) & " : ")
        Next
        Console.WriteLine()
        Console.WriteLine("Время выполнения алгоритма Кнута-Мориса-Прата (КМП):")
        For i = 0 To UBound(algKMP)
            Console.Write(algKMP(i) & " : ")
        Next

    End Sub

    ''' <summary>
    ''' Функция, реализующая наивный алгоритм поиска подстроки в строке.
    ''' </summary>

    Function NaiveAlgorithm(ByVal str As String, ByVal subStr As String) As Long()
        Dim counterofTime() As Long = {Now.Second, Now.Millisecond, Now.Ticks}

        Dim indI As Integer
        For i = 0 To str.Length - 1
            indI = 0
            For k = 0 To subStr.Length - 1
                If str(i + k) = subStr(k) Then
                    indI += 1
                End If
            Next
            If indI = subStr.Length - 1 Then
                Exit For
            End If
        Next
        If indI <> subStr.Length - 1 Then
            indI = -1
        End If

        counterofTime(0) = Now.Second - counterofTime(0)
        counterofTime(1) = Now.Millisecond - counterofTime(1)
        counterofTime(2) = Now.Ticks - counterofTime(2)
        Return counterofTime
    End Function

    ''' <summary>
    ''' Функция, реализующая алгоритм Рабина-Карпа поиска подстроки в строке.
    ''' </summary>

    Function AlgRabinaKarpa(ByVal str As String, ByVal subStr As String) As Long()
        Dim counterofTime() As Long = {Now.Second, Now.Millisecond, Now.Ticks}
        Dim arrInd(str.Length) As Integer
        Dim i As Integer = 0
        Dim hashStr2 As Integer = GetHashCode(subStr)
        For ind = 1 To str.Length
            If hashStr2 = GetHashCode(Mid(str, ind, subStr.Length)) Then
                If subStr = Mid(str, ind, subStr.Length) Then
                    arrInd(i) = ind
                    i += 1
                End If
            End If
        Next
        ReDim Preserve arrInd(0 To i - 1)

        counterofTime(0) = Now.Second - counterofTime(0)
        counterofTime(1) = Now.Millisecond - counterofTime(1)
        counterofTime(2) = Now.Ticks - counterofTime(2)
        Return counterofTime
    End Function

    ''' <summary>
    ''' Функция, реализующая алгоритм КПМ (Кнута-Морриса-Пратта) поиска подстроки в строке.
    ''' </summary>

    Public Function FindSubstring(ByVal str As String, ByVal subStr As String) As Long()
        Dim counterofTime() As Long = {Now.Second, Now.Millisecond, Now.Ticks}
        Dim index As Integer = -1
        Dim arrOfPref() = GetPrefixFunction(subStr)
        Dim indK As Integer = 0
        For i = 0 To str.Length - 1
            Do While indK > 0 And subStr(indK) <> str(i)
                indK = arrOfPref(indK - 1)
            Loop
            If subStr(indK) = str(i) Then
                indK = indK + 1
            End If
            If indK = subStr.Length Then
                index = i - subStr.Length + 1
                Exit For
            End If
        Next

        counterofTime(0) = Now.Second - counterofTime(0)
        counterofTime(1) = Now.Millisecond - counterofTime(1)
        counterofTime(2) = Now.Ticks - counterofTime(2)
        Return counterofTime
    End Function

    ' Возвращает хеш-значение

    Public Function GetHashCode(ByVal strValue As String) As Long
        Const base As Integer = 65521
        Dim checksumA As Long = 0
        Dim adler As Integer = 0
        Dim checksuB As Long = 0
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

    ''' <summary>
    ''' Префикс-функция.
    ''' </summary>

    Private Function GetPrefixFunction(ByVal str As String) As Integer()
        Dim arrOfPref(str.Length - 1) As Integer
        Dim indI, IndJ As Integer

        For indI = 1 To str.Length - 1
            IndJ = arrOfPref(indI - 1)
            Do While ((IndJ > 0) And (str(IndJ) <> str(indI)))
                IndJ = arrOfPref(IndJ - 1)
            Loop
            If str(indI) = str(IndJ) Then
                arrOfPref(indI) = IndJ + 1
                IndJ += 1
            End If
        Next
        ReDim Preserve arrOfPref(arrOfPref.Length - 1)

        Return arrOfPref
    End Function

End Module
