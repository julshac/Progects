Module Module1

    Sub Main()
        Dim userArr(-1) As Integer
        Dim value, countOfFlips As Integer

        Do
            Console.WriteLine("Введите размер блина: ")
            value = Console.ReadLine()
            If value = 0 Then
                Exit Do
            Else
                ReDim Preserve userArr(userArr.Length)
                userArr(userArr.Length - 1) = value
            End If
        Loop

        Console.WriteLine("-----------------------------")
        countOfFlips = Sort(userArr)
        Console.WriteLine("-----------------------------")
        Console.WriteLine("Количество поворотов: {0}", countOfFlips)

        Console.ReadLine()
    End Sub

    Function Flip(ByRef curArr() As Integer, ByVal endIndex As Integer) As Integer()
        Dim swap, i, length As Integer
        length = endIndex + 1
        For i = 0 To (length / 2) - 1
            swap = curArr(i)
            curArr(i) = curArr(endIndex - i)
            curArr(endIndex - i) = swap
        Next
        Return curArr
    End Function

    Function Sort(ByRef curArr() As Integer) As Integer
        Dim indexMaxElem, currMaxValue, minValue, countOfFixed As Integer
        Dim moves As Integer = 0

        If curArr.Length < 2 Then
            Return 0
        End If

        minValue = curArr.Min()
        indexMaxElem = 0
        For i = 1 To curArr.Length - 1
            If curArr(i) > curArr(indexMaxElem) Then
                indexMaxElem = i
            End If
        Next
        currMaxValue = curArr(indexMaxElem)
        curArr = Flip(curArr, indexMaxElem)
        Console.WriteLine(ShowArr(curArr))
        curArr = Flip(curArr, curArr.Length - 1)
        Console.WriteLine(ShowArr(curArr))
        currMaxValue -= 1
        countOfFixed = 1
        moves = 2

        Do While currMaxValue > minValue
            indexMaxElem = 0
            For i = 1 To curArr.Length - 1
                If curArr(i) = currMaxValue Then
                    indexMaxElem = i
                    Exit For
                End If
            Next
            currMaxValue = curArr(indexMaxElem)
            curArr = Flip(curArr, indexMaxElem)
            Console.WriteLine(ShowArr(curArr))
            curArr = Flip(curArr, curArr.Length - countOfFixed - 1)
            Console.WriteLine(ShowArr(curArr))
            currMaxValue -= 1
            countOfFixed += 1
            moves += 2
        Loop

        Return moves
    End Function

    Function ShowArr(ByVal arr() As Integer) As String
        Dim str As String = String.Empty
        For Each element In arr
            str += element.ToString + " "
        Next
        Return str
    End Function

End Module
