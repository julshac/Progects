Module Module2
    ''' <summary>
    '''Функция, разбивающая выражение на список из чисел и операций 
    ''' </summary>

    Function BuildExpressionEntryList(ByVal str As String) As List(Of ExpressioEntry)
        Dim list As New List(Of ExpressioEntry)
        Dim curLevel As Integer = 1
        Dim curActionLevel As Integer = 0
        Dim expEntry As ExpressioEntry
        Dim actSymbols As Char() = ("()+-*/").ToCharArray()
        Dim valueStartIndex As Integer
        Dim valueEndIndex As Integer

        For i = 0 To str.Length - 1
            Select Case str(i)
                Case "("
                    curActionLevel += 1
                    curLevel += 1
                    expEntry = New ExpressioEntry With {.Value = str(i), .Rank = curActionLevel}
                Case ")"
                    expEntry = New ExpressioEntry With {.Value = str(i), .Rank = curActionLevel}
                    curActionLevel -= 1
                    curLevel -= 1
                Case "+", "*", "/"
                    expEntry = New ExpressioEntry With {.Value = str(i), .Rank = curActionLevel}
                Case "-"
                    If (list.Count = 0) Or (list(list.Count - 1).Rank <> curLevel) Then
                        valueStartIndex = i
                        valueEndIndex = str.IndexOfAny(actSymbols, i + 1)
                        expEntry = New ExpressioEntry With {.Value = str.Substring(valueStartIndex, (valueEndIndex - valueStartIndex)), .Rank = curLevel}
                        i = valueEndIndex - 1
                    Else
                        expEntry = New ExpressioEntry With {.Value = str(i), .Rank = curActionLevel}
                    End If
                Case Else
                    valueStartIndex = i
                    valueEndIndex = str.IndexOfAny(actSymbols, i + 1)
                    expEntry = New ExpressioEntry With {.Value = str.Substring(valueStartIndex, (valueEndIndex - valueStartIndex)), .Rank = curLevel}
                    i = valueEndIndex - 1
            End Select
            list.Add(expEntry)
        Next

        Return list
    End Function
    ''' <summary>
    ''' Функция, выполняющая расчет выражения.
    ''' </summary>

    Function CalculateExpression(ByVal index As Integer, ByRef list As List(Of ExpressioEntry)) As List(Of ExpressioEntry)
        Dim res As String
        Dim val1, val2, action As String

        'удаляем скобки'
        list.RemoveAt(index + 4)
        list.RemoveAt(index)

        val1 = list(index).Value
        val2 = list(index + 2).Value
        action = list(index + 1).Value

        Select Case action
            Case "+"
                res = (Double.Parse(val1) + Double.Parse(val2)).ToString
            Case "-"
                res = (Double.Parse(val1) - Double.Parse(val2)).ToString
            Case "/"
                res = (Double.Parse(val1) / Double.Parse(val2)).ToString
            Case Else ' "*"
                res = (Double.Parse(val1) * Double.Parse(val2)).ToString
        End Select

        Dim curExp As ExpressioEntry = list(index)
        curExp.Value = res
        curExp.Rank -= 1
        list(index) = curExp

        list.RemoveAt(index + 2)
        list.RemoveAt(index + 1)

        Return list
    End Function
End Module

