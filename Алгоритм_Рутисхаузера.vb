Module Module1
    Public Structure ExpressioEntry
        Public Value As String
        Public Rank As Integer
    End Structure

    Sub Main()
        Dim userString As String

        Console.WriteLine("Введите выражение: ")
        userString = Console.ReadLine()

        Dim list As New List(Of ExpressioEntry)
        list = BuildExpressionEntryList(userString)

        Dim maxRank As Integer = 1
        Dim index As Integer
        For i = 0 To list.Count - 1
            If list(i).Rank > maxRank Then
                maxRank = list(i).Rank
                index = i
            End If
        Next

        ' Так как неизвестно положение внутренних скобок, то приходится выполнять поиск индекса элемента с максимальным весом.
        Do While list.Count > 1
            If list(index).Rank = maxRank Then
                list = CalculateExpression(index - 1, list)
                maxRank -= 1

                For i = 0 To list.Count - 1
                    If list(i).Rank = maxRank Then
                        index = i
                        Exit For
                    End If
                Next
            End If
        Loop

        Console.WriteLine("Ответ: {0}", list(0).Value)

        Console.ReadLine()
    End Sub

End Module

